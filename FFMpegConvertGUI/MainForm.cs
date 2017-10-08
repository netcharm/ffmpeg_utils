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
        private string[] supported = new string[] {
            "*.aac", "*.amr", "*.mp3", "*.ogg", "*.wma", "*.wav",
            "*.gif", "*.webp", "*.png", "*.jpg", "*.tif", "*.bmp",
            "*.flv", "*.mkv", "*.mp4", "*.wmv", "*.webm", "*.h264", "*.avi", "*.divx", "*.xvid" };

        internal async Task<int> Run( string cmd, string[] args, string working = "" )
        {
            List<string> param = new List<string>();
            param.AddRange( args );

            return (await Run( cmd, string.Join( " ", param ) ) );
        }

        internal string SetParams( string Dst, string ifile )
        {
            string result = string.Empty;

            string src = Path.GetExtension(ifile).ToLower().TrimStart(new char[] { '.' });
            string dst = Dst.ToLower();

            //-hide_banner - i
            //amr2aac.cmd -acodec libfaac
            //amr2mp3.cmd -acodec libmp3lame
            //amr2ogg.cmd -strict 1 -acodec libvorbis
            //flv2mkv.cmd -acodec copy -vcodec copy
            //flv2mp4.cmd -acodec copy -vcodec copy
            //gif2mp4.cmd -vf "scale=trunc(in_w/2)*2:trunc(in_h/2)*2"
            //gif2webm.cmd -c:v libvpx -crf 12 -b:v 100K
            //mkv2mp4.cmd -vcodec copy -acodec copy
            //mp42mkv.cmd -vcodec copy -acodec copy
            //wmv2mkv.cmd -acodec copy
            //wmv2mp4.cmd -acodec copy
            string[] same = { "flv", "mkv", "mp4" };
            string fi = Path.GetFileName(ifile.Trim(new char[] { '\"' } ));
            string fo = $"{Path.GetFileNameWithoutExtension(ifile.Trim(new char[] { '\"' } ))}.{dst.ToLower()}";

            if ( string.Equals( "aac", dst ) )
            {
                result = $"-hide_banner -y -i \"{fi}\" -acodec libfaac \"{fo}\"";
            }
            else if ( string.Equals( "amr", dst ) )
            {
                result = $"-hide_banner -y -i \"{fi}\" -acodec libamr_nb -ab 12.2k -ar 8000 -ac 1 \"{fo}\"";
            }
            else if ( string.Equals( "mp3", dst ) )
            {
                result = $"-hide_banner -y -i \"{fi}\" -acodec libmp3lame \"{fo}\"";
            }
            else if ( string.Equals( "ogg", dst ) )
            {
                result = $"-hide_banner -y -i \"{fi}\" -strict 1 -acodec libvorbis \"{fo}\"";
            }
            else if ( same.Contains( src ) && same.Contains( dst ) )
            {
                result = $"-hide_banner -y -i \"{fi}\" -acodec copy -vcodec copy \"{fo}\"";
            }
            else if ( string.Equals( "gif", src ) && same.Contains( dst ) )
            {
                result = $"-hide_banner -y -i \"{fi}\" -vf \"scale = trunc( in_w / 2 ) * 2:trunc( in_h / 2 ) * 2\" \"{fo}\"";
            }
            else if ( string.Equals( "webm", dst ) )
            {
                result = $"-hide_banner -y -i \"{fi}\" -c:v libvpx -crf 12 -b:v 100K \"{fo}\"";
            }
            else if ( string.Equals( "h264", dst ) )
            {
                result = $"-hide_banner -y -i \"{fi}\" -vcodec copy -vbsf h264_mp4toannexb -an \"{fo}\"";
            }
            else if ( string.Equals( "mp4", dst ) )
            {
                result = $"-hide_banner -y -i \"{fi}\" -vcodec libx264 -acodec aac \"{fo}\"";
            }
            else if ( string.Equals( "wav", dst ) )
            {
                result = $"-hide_banner -y -i \"{fi}\" -f wav \"{fo}\"";
            }            
            else
            {
                result = $"-hide_banner -y -i \"{fi}\" \"{fo}\"";
            }

            //MessageBox.Show( result );

            return ( result );
        }

        internal async Task<int> Run( string cmd, string args, string working="" )
        {
            if ( !File.Exists( cmd ) ) return ( -100 );

            ProcessStartInfo psi = new ProcessStartInfo();
            Process p = new Process();

            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p.StartInfo.RedirectStandardOutput = false;
            //p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.RedirectStandardError = false;
            if ( !string.IsNullOrEmpty( working ) )
                p.StartInfo.WorkingDirectory = working;
            p.StartInfo.ErrorDialog = true;
            p.StartInfo.ErrorDialogParentHandle = this.Handle;

            p.StartInfo.Arguments = args;
            p.StartInfo.FileName = cmd;

            p.Start();

            //Console.ReadLine();
            //MessageBox.Show( "End" );

            //p.BeginOutputReadLine();
            //p.BeginErrorReadLine();
            p.WaitForExit(5000);

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

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load( object sender, EventArgs e )
        {
            Icon = Icon.ExtractAssociatedIcon( Application.ExecutablePath );

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
            dlgOpen.Filter = $@"All supported File(s)|{string.Join(";", supported)}|All File(s)|*.*";
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
