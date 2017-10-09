using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFMpegConvertGUI
{
    public partial class MainForm : Form
    {
        private string AppPath = Path.GetDirectoryName(Application.ExecutablePath);

        string[] same = { "flv", "mkv", "mp4" };
        private List<string> supported = new List<string>();

        private string[] audio = new string[] {
            "aac", "amr", "mp3", "ogg", "wma", "wav", "m4a", "oga"
        };

        private string[] video = new string[] {
            "flv", "mkv", "mp4", "wmv", "webm", "h264", "avi", "divx", "xvid", "mjpeg", "m4v", "ogv"
        };

        private string[] image = new string[] {
            "gif", "webp", "png", "jpg", "jpeg", "tif", "tiff", "bmp"
        };

        internal async Task<int> Run( string cmd, string[] args, string working="" )
        {
            List<string> param = new List<string>();
            param.AddRange( args );

            return (await Run( cmd, string.Join( " ", param ) ) );
        }

        internal async Task<int> Run( string cmd, string args, string working="" )
        {
            if ( !File.Exists( cmd ) ) return ( -100 );

            Process p = new Process();

            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p.StartInfo.RedirectStandardOutput = false;
            p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.RedirectStandardError = false;
            if ( !string.IsNullOrEmpty( working ) )
                p.StartInfo.WorkingDirectory = working;
            p.StartInfo.ErrorDialog = true;
            p.StartInfo.ErrorDialogParentHandle = this.Handle;

            p.StartInfo.Arguments = args;
            p.StartInfo.FileName = cmd;

            p.Start();

            //p.BeginOutputReadLine();
            //p.BeginErrorReadLine();
            p.WaitForExit( 5000 );

            bool exited = p.HasExited;

            int exitCode = 0;
            if ( p.HasExited ) exitCode = p.ExitCode;
            //p.CancelOutputRead();
            //p.CancelErrorRead();
            p.Close();

            return ( exitCode );
        }

        internal async Task<int> PerformConvert(string[] files)
        {
            int exit = -1;
            foreach ( Control dst in grpDst.Controls )
            {
                if ( ( dst as RadioButton ).Checked )
                {
                    foreach ( string fsrc in files )
                    {
                        string working = Path.GetDirectoryName(fsrc);
                        string args = SetParams( dst.Text, fsrc );
                        exit = await Run( Path.Combine( AppPath, "ffmpeg.exe" ), args, working );
                    }
                    //if ( exit == 0 ) MessageBox.Show( "OK!" );
                    break;
                }
            }
            return ( exit );
        }

        internal string SetParams( string Dst, string ifile )
        {
            string result = string.Empty;

            string src = Path.GetExtension(ifile).ToLower().TrimStart(new char[] { '.' });
            string dst = Dst.ToLower();

            string fi = Path.GetFileName(ifile.Trim(new char[] { '\"' } ));
            string fo = $"{Path.GetFileNameWithoutExtension(ifile.Trim(new char[] { '\"' } ))}.{dst.ToLower()}";

            List<string> commonargs = new List<string>();
            commonargs.Add( $"-hide_banner" );
            commonargs.Add( $"-y" );
            commonargs.Add( $"-copyts" );
            commonargs.Add( $"-i \"{fi}\"" );

            if ( string.Equals( "aac", dst ) )
            {
                commonargs.Add( $"-acodec aac -b:a 320k -q:a 1" );
            }
            else if ( string.Equals( "amr", dst ) )
            {
                commonargs.Add( $"-acodec libamr_nb -ab 12.2k -ar 8000 -ac 1" );
            }
            else if ( string.Equals( "mp3", dst ) )
            {
                commonargs.Add( $"-acodec libmp3lame -b:a 320k -q:a 1" );
            }
            else if ( string.Equals( "ogg", dst ) )
            {
                commonargs.Add( $"-strict 1 -acodec libvorbis -b:a 320k -q:a 1" );
            }
            else if ( same.Contains( src ) && same.Contains( dst ) )
            {
                commonargs.Add( $"-acodec copy -vcodec copy" );
            }
            else if ( string.Equals( "gif", src ) && same.Contains( dst ) )
            {
                commonargs.Add( $"-vf \"scale=trunc(iw/2)*2:trunc(ih/2)*2\"" );
            }
            else if ( string.Equals( "webm", dst ) )
            {
                commonargs.Add( $"-c:v libvpx -crf 12 -b:v 100K" );
            }
            else if ( string.Equals( "h264", dst ) )
            {
                commonargs.Add( $"-vcodec copy -vbsf h264_mp4toannexb -an" );
            }
            else if ( string.Equals( "mp4", dst ) )
            {
                commonargs.Add( $"-vcodec libx264 -acodec aac -b:a 320k -q:a 1" );
            }
            else if ( string.Equals( "mkv", dst ) )
            {
                commonargs.Add( $"-acodec copy -vcodec copy" );
            }
            else if ( string.Equals( "wav", dst ) )
            {
                commonargs.Add( $"-f wav" );
            }
            else
            {
            }

            if ( audio.Contains( src ) && video.Contains( dst ) )
            {
                //commonargs.Add( $"-r 1 -s 1280,720 -aspect 16:9" );
                commonargs.Add( $"-vn" );
            }
            else if ( audio.Contains( dst ) && video.Contains( src ) )
            {
                commonargs.Add( $"-an" );
            }

            commonargs.Add( $"\"{fo}\"" );
            result = string.Join( " ", commonargs );

            return ( result );
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load( object sender, EventArgs e )
        {
            Icon = Icon.ExtractAssociatedIcon( Application.ExecutablePath );

            supported.AddRange( audio );
            supported.AddRange( video );
            supported.AddRange( image );

            btnConvert.Image = Icon.ToBitmap();

            btnDstMP4.PerformClick();
        }

        private void MainForm_DragOver( object sender, DragEventArgs e )
        {
            e.Effect = DragDropEffects.None;
            if ( e.Data.GetDataPresent( DataFormats.FileDrop ) )
            {
                string[] dragFiles = (string [])e.Data.GetData(DataFormats.FileDrop, true);
                if ( dragFiles.Length > 0 )
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
            return;
        }

        private async void MainForm_DragDrop( object sender, DragEventArgs e )
        {
            // Determine whether string data exists in the drop data. If not, then 
            // the drop effect reflects that the drop cannot occur. 
            if ( e.Data.GetDataPresent( DataFormats.FileDrop ) )
            {
                //e.Effect = DragDropEffects.Copy;
                try
                {
                    string[] dragFiles = (string [])e.Data.GetData(DataFormats.FileDrop, true);
                    if ( dragFiles.Length > 0 )
                    {
                        int exit = await PerformConvert( dragFiles );
                    }
                }
                catch
                {

                }
            }
            return;
        }

        private async void btnConvert_Click( object sender, EventArgs e )
        {
            btnConvert.Enabled = false;
            List<string> fl = new List<string>();
            fl.Add( $"All supported File( s )" );
            fl.Add( $"*.{string.Join( ";*.", supported )}" );
            fl.Add( $"All File(s)|*.*" );
            foreach ( string ft in supported )
            {
                fl.Add( $"{ft.ToUpper()} File(s)|*.{ft}" );
            }
            dlgOpen.Filter = string.Join( "|", fl );

            //dlgOpen.Filter = $@"All supported File(s)|*.{string.Join(";*.", supported)}|All File(s)|*.*";
            //dlgOpen.FileName = string.Join( ";", supported );
            dlgOpen.FileName = string.Empty;
            if ( dlgOpen.ShowDialog() == DialogResult.OK )
            {
                int exit = await PerformConvert( dlgOpen.FileNames );
            }
            btnConvert.Enabled = true;
        }
    }
}
