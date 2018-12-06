using System;
using System.Collections.Generic;
using System.Configuration;
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

        private static Configuration config = ConfigurationManager.OpenExeConfiguration( Application.ExecutablePath );
        private AppSettingsSection appSection = config.AppSettings;

        string[] same = { "flv", "mkv", "mp4" };
        string[] image2audio = { "ogg", "wma" };
        string[] image2video = { "mkv" };
        string[] video2image = { "webp", "gif" };

        private List<string> supported = new List<string>();
        #region FFmpeg formats
        private Dictionary<string, string> formats = new Dictionary<string, string>()
        {
            {"3dostr",          "3DO STR"},
            {"3g2",             "3GP2 (3GPP2 file format)"},
            {"3gp",             "3GP (3GPP file format)"},
            {"4xm",             "4X Technologies"},
            {"a64",             "a64 - video for Commodore 64"},
            {"aa",              "Audible AA format files"},
            {"aac",             "raw ADTS AAC (Advanced Audio Coding)"},
            {"ac3",             "raw AC-3"},
            {"acm",             "Interplay ACM"},
            {"act",             "ACT Voice file format"},
            {"adf",             "Artworx Data Format"},
            {"adp",             "ADP"},
            {"ads",             "Sony PS2 ADS"},
            {"adts",            "ADTS AAC (Advanced Audio Coding)"},
            {"adx",             "CRI ADX"},
            {"aea",             "MD STUDIO audio"},
            {"afc",             "AFC"},
            {"aiff",            "Audio IFF"},
            {"aix",             "CRI AIX"},
            {"alaw",            "PCM A-law"},
            {"alias_pix",       "Alias/Wavefront PIX image"},
            {"amr",             "3GPP AMR"},
            {"anm",             "Deluxe Paint Animation"},
            {"apc",             "CRYO APC"},
            {"ape",             "Monkey's Audio"},
            {"apng",            "Animated Portable Network Graphics"},
            {"applehttp",       "Apple HTTP Live Streaming"},
            {"aqtitle",         "AQTitle subtitles"},
            {"asf",             "ASF (Advanced / Active Streaming Format)"},
            {"asf_o",           "ASF (Advanced / Active Streaming Format)"},
            {"asf_stream",      "ASF (Advanced / Active Streaming Format)"},
            {"ass",             "SSA (SubStation Alpha) subtitle"},
            {"ast",             "AST (Audio Stream)"},
            {"au",              "Sun AU"},
            {"avi",             "AVI (Audio Video Interleaved)"},
            {"avisynth",        "AviSynth script"},
            {"avm2",            "SWF (ShockWave Flash) (AVM2)"},
            {"avr",             "AVR (Audio Visual Research)"},
            {"avs",             "AVS"},
            {"bethsoftvid",     "Bethesda Softworks VID"},
            {"bfi",             "Brute Force & Ignorance"},
            {"bfstm",           "BFSTM (Binary Cafe Stream)"},
            {"bin",             "Binary text"},
            {"bink",            "Bink"},
            {"bit",             "G.729 BIT file format"},
            {"bmp",             "Windows Bitmap"},
            {"bmp_pipe",        "piped bmp sequence"},
            {"bmv",             "Discworld II BMV"},
            {"boa",             "Black Ops Audio"},
            {"brender_pix",     "BRender PIX image"},
            {"brstm",           "BRSTM (Binary Revolution Stream)"},
            {"c93",             "Interplay C93"},
            {"caca",            "caca (color ASCII art) output device"},
            {"caf",             "Apple CAF (Core Audio Format)"},
            {"cavsvideo",       "raw Chinese AVS (Audio Video Standard) video"},
            {"cdg",             "CD Graphics"},
            {"cdxl",            "Commodore CDXL video"},
            {"cine",            "Phantom Cine"},
            {"concat",          "Virtual concatenation script"},
            {"crc",             "CRC testing"},
            {"dash",            "DASH Muxer"},
            {"data",            "raw data"},
            {"daud",            "D-Cinema audio"},
            {"dcstr",           "Sega DC STR"},
            {"dds_pipe",        "piped dds sequence"},
            {"dfa",             "Chronomaster DFA"},
            {"dirac",           "raw Dirac"},
            {"dnxhd",           "raw DNxHD (SMPTE VC-3)"},
            {"dpx_pipe",        "piped dpx sequence"},
            {"dsf",             "DSD Stream File (DSF)"},
            {"dshow",           "DirectShow capture"},
            {"dsicin",          "Delphine Software International CIN"},
            {"dss",             "Digital Speech Standard (DSS)"},
            {"dts",             "raw DTS"},
            {"dtshd",           "raw DTS-HD"},
            {"dv",              "DV (Digital Video)"},
            {"dvbsub",          "raw dvbsub"},
            {"dvbtxt",          "dvbtxt"},
            {"dvd",             "MPEG-2 PS (DVD VOB)"},
            {"dxa",             "DXA"},
            {"ea",              "Electronic Arts Multimedia"},
            {"ea_cdata",        "Electronic Arts cdata"},
            {"eac3",            "raw E-AC-3"},
            {"epaf",            "Ensoniq Paris Audio File"},
            {"exr_pipe",        "piped exr sequence"},
            {"f32be",           "PCM 32-bit floating-point big-endian"},
            {"f32le",           "PCM 32-bit floating-point little-endian"},
            {"f4v",             "F4V Adobe Flash Video"},
            {"f64be",           "PCM 64-bit floating-point big-endian"},
            {"f64le",           "PCM 64-bit floating-point little-endian"},
            {"ffm",             "FFM (FFserver live feed)"},
            {"ffmetadata",      "FFmpeg metadata in text"},
            {"fifo",            "FIFO queue pseudo-muxer"},
            {"film_cpk",        "Sega FILM / CPK"},
            {"filmstrip",       "Adobe Filmstrip"},
            {"fits",            "Flexible Image Transport System"},
            {"flac",            "raw FLAC"},
            {"flic",            "FLI/FLC/FLX animation"},
            {"flv",             "FLV (Flash Video)"},
            {"framecrc",        "framecrc testing"},
            {"framehash",       "Per-frame hash testing"},
            {"framemd5",        "Per-frame MD5 testing"},
            {"frm",             "Megalux Frame"},
            {"fsb",             "FMOD Sample Bank"},
            {"g722",            "raw G.722"},
            {"g723_1",          "raw G.723.1"},
            {"g726",            "raw big-endian G.726 (\"left-justified\")"},
            {"g726le",          "raw little-endian G.726 (\"right-justified\")"},
            {"g729",            "G.729 raw format demuxer"},
            {"gdigrab",         "GDI API Windows frame grabber"},
            {"gdv",             "Gremlin Digital Video"},
            {"genh",            "GENeric Header"},
            {"gif",             "GIF Animation"},
            {"gsm",             "raw GSM"},
            {"gxf",             "GXF (General eXchange Format)"},
            {"h261",            "raw H.261"},
            {"h263",            "raw H.263"},
            {"h264",            "raw H.264 video"},
            {"hash",            "Hash testing"},
            {"hds",             "HDS Muxer"},
            {"hevc",            "raw HEVC video"},
            {"hls",             "Apple HTTP Live Streaming"},
            {"hnm",             "Cryo HNM v4"},
            {"ico",             "Microsoft Windows ICO"},
            {"idcin",           "id Cinematic"},
            {"idf",             "iCE Draw File"},
            {"iff",             "IFF (Interchange File Format)"},
            {"ilbc",            "iLBC storage"},
            {"image2",          "image2 sequence"},
            {"image2pipe",      "piped image2 sequence"},
            {"ingenient",       "raw Ingenient MJPEG"},
            {"ipmovie",         "Interplay MVE"},
            {"ipod",            "iPod H.264 MP4 (MPEG-4 Part 14)"},
            {"ircam",           "Berkeley/IRCAM/CARL Sound Format"},
            {"ismv",            "ISMV/ISMA (Smooth Streaming)"},
            {"iss",             "Funcom ISS"},
            {"iv8",             "IndigoVision 8000 video"},
            {"ivf",             "On2 IVF"},
            {"ivr",             "IVR (Internet Video Recording)"},
            {"j2k_pipe",        "piped j2k sequence"},
            {"jacosub",         "JACOsub subtitle format"},
            {"jpg",             "JPEG"},
            {"jpeg",            "JPEG"},
            {"jpeg_pipe",       "piped jpeg sequence"},
            {"jpegls_pipe",     "piped jpegls sequence"},
            {"jv",              "Bitmap Brothers JV"},
            {"latm",            "LOAS/LATM"},
            {"lavfi",           "Libavfilter virtual input device"},
            {"libgme",          "Game Music Emu demuxer"},
            {"libmodplug",      "ModPlug demuxer"},
            {"live_flv",        "live RTMP FLV (Flash Video)"},
            {"lmlm4",           "raw lmlm4"},
            {"loas",            "LOAS AudioSyncStream"},
            {"lrc",             "LRC lyrics"},
            {"lvf",             "LVF"},
            {"lxf",             "VR native stream (LXF)"},
            {"m4a",             "QuickTime / MOV"},
            {"m4v",             "raw MPEG-4 video"},
            {"matroska",        "Matroska"},
            {"md5",             "MD5 testing"},
            {"mgsts",           "Metal Gear Solid: The Twin Snakes"},
            {"microdvd",        "MicroDVD subtitle format"},
            {"mj2",             "QuickTime / MOV"},
            {"mjpeg",           "raw MJPEG video"},
            {"mjpeg_2000",      "raw MJPEG 2000 video"},
            {"mkvtimestamp_v2", "extract pts as timecode v2 format, as defined by mkvtoolnix"},
            {"mlp",             "raw MLP"},
            {"mlv",             "Magic Lantern Video (MLV)"},
            {"mm",              "American Laser Games MM"},
            {"mmf",             "Yamaha SMAF"},
            {"mov",             "QuickTime / MOV"},
            {"mp2",             "MP2 (MPEG audio layer 2)"},
            {"mp3",             "MP3 (MPEG audio layer 3)"},
            {"mp4",             "QuickTime / MOV"},
            {"mpc",             "Musepack"},
            {"mpc8",            "Musepack SV8"},
            {"mpeg",            "MPEG-1 Systems / MPEG program stream"},
            {"mpeg1video",      "raw MPEG-1 video"},
            {"mpeg2video",      "raw MPEG-2 video"},
            {"mpegts",          "MPEG-TS (MPEG-2 Transport Stream)"},
            {"mpegtsraw",       "raw MPEG-TS (MPEG-2 Transport Stream)"},
            {"mpegvideo",       "raw MPEG video"},
            {"mpjpeg",          "MIME multipart JPEG"},
            {"mpl2",            "MPL2 subtitles"},
            {"mpsub",           "MPlayer subtitles"},
            {"msf",             "Sony PS3 MSF"},
            {"msnwctcp",        "MSN TCP Webcam stream"},
            {"mtaf",            "Konami PS2 MTAF"},
            {"mtv",             "MTV"},
            {"mulaw",           "PCM mu-law"},
            {"musx",            "Eurocom MUSX"},
            {"mv",              "Silicon Graphics Movie"},
            {"mvi",             "Motion Pixels MVI"},
            {"mxf",             "MXF (Material eXchange Format)"},
            {"mxf_d10",         "MXF (Material eXchange Format) D-10 Mapping"},
            {"mxf_opatom",      "MXF (Material eXchange Format) Operational Pattern Atom"},
            {"mxg",             "MxPEG clip"},
            {"nc",              "NC camera feed"},
            {"nistsphere",      "NIST SPeech HEader REsources"},
            {"nsv",             "Nullsoft Streaming Video"},
            {"null",            "raw null video"},
            {"nut",             "NUT"},
            {"nuv",             "NuppelVideo"},
            {"oga",             "Ogg Audio"},
            {"ogg",             "Ogg"},
            {"ogv",             "Ogg Video"},
            {"oma",             "Sony OpenMG audio"},
            {"opus",            "Ogg Opus"},
            {"paf",             "Amazing Studio Packed Animation File"},
            {"pam_pipe",        "piped pam sequence"},
            {"pbm_pipe",        "piped pbm sequence"},
            {"pcx_pipe",        "piped pcx sequence"},
            {"pgm_pipe",        "piped pgm sequence"},
            {"pgmyuv_pipe",     "piped pgmyuv sequence"},
            {"pictor_pipe",     "piped pictor sequence"},
            {"pjs",             "PJS (Phoenix Japanimation Society) subtitles"},
            {"pmp",             "Playstation Portable PMP"},
            {"png",             "Portable Network Graphics"},
            {"png_pipe",        "piped png sequence"},
            {"ppm_pipe",        "piped ppm sequence"},
            {"psd_pipe",        "piped psd sequence"},
            {"psp",             "PSP MP4 (MPEG-4 Part 14)"},
            {"psxstr",          "Sony Playstation STR"},
            {"pva",             "TechnoTrend PVA"},
            {"pvf",             "PVF (Portable Voice Format)"},
            {"qcp",             "QCP"},
            {"qdraw_pipe",      "piped qdraw sequence"},
            {"r3d",             "REDCODE R3D"},
            {"rawvideo",        "raw video"},
            {"realtext",        "RealText subtitle format"},
            {"redspark",        "RedSpark"},
            {"rl2",             "RL2"},
            {"rm",              "RealMedia"},
            {"roq",             "raw id RoQ"},
            {"rpl",             "RPL / ARMovie"},
            {"rsd",             "GameCube RSD"},
            {"rso",             "Lego Mindstorms RSO"},
            {"rtp",             "RTP output"},
            {"rtp_mpegts",      "RTP/mpegts output format"},
            {"rtsp",            "RTSP output"},
            {"s16be",           "PCM signed 16-bit big-endian"},
            {"s16le",           "PCM signed 16-bit little-endian"},
            {"s24be",           "PCM signed 24-bit big-endian"},
            {"s24le",           "PCM signed 24-bit little-endian"},
            {"s32be",           "PCM signed 32-bit big-endian"},
            {"s32le",           "PCM signed 32-bit little-endian"},
            {"s337m",           "SMPTE 337M"},
            {"s8",              "PCM signed 8-bit"},
            {"sami",            "SAMI subtitle format"},
            {"sap",             "SAP output"},
            {"sbg",             "SBaGen binaural beats script"},
            {"scc",             "Scenarist Closed Captions"},
            {"sdl",             "SDL2 output device"},
            {"sdl2",            "SDL2 output device"},
            {"sdp",             "SDP"},
            {"sdr2",            "SDR2"},
            {"sds",             "MIDI Sample Dump Standard"},
            {"sdx",             "Sample Dump eXchange"},
            {"segment",         "segment"},
            {"sgi_pipe",        "piped sgi sequence"},
            {"shn",             "raw Shorten"},
            {"siff",            "Beam Software SIFF"},
            {"singlejpeg",      "JPEG single image"},
            {"sln",             "Asterisk raw pcm"},
            {"smjpeg",          "Loki SDL MJPEG"},
            {"smk",             "Smacker"},
            {"smoothstreaming", "Smooth Streaming Muxer"},
            {"smush",           "LucasArts Smush"},
            {"sol",             "Sierra SOL"},
            {"sox",             "SoX native"},
            {"spdif",           "IEC 61937 (used on S/PDIF - IEC958)"},
            {"spx",             "Ogg Speex"},
            {"srt",             "SubRip subtitle"},
            {"ssegment",        "streaming segment muxer"},
            {"stl",             "Spruce subtitle format"},
            {"stream_segment",  "streaming segment muxer"},
            {"subviewer",       "SubViewer subtitle format"},
            {"subviewer1",      "SubViewer v1 subtitle format"},
            {"sunrast_pipe",    "piped sunrast sequence"},
            {"sup",             "raw HDMV Presentation Graphic Stream subtitles"},
            {"svag",            "Konami PS2 SVAG"},
            {"svcd",            "MPEG-2 PS (SVCD)"},
            {"svg_pipe",        "piped svg sequence"},
            {"swf",             "SWF (ShockWave Flash)"},
            {"tak",             "raw TAK"},
            {"tedcaptions",     "TED Talks captions"},
            {"tee",             "Multiple muxer tee"},
            {"thp",             "THP"},
            {"tiertexseq",      "Tiertex Limited SEQ"},
            {"tiff",            "TIFF"},
            {"tiff_pipe",       "piped tiff sequence"},
            {"tmv",             "8088flex TMV"},
            {"truehd",          "raw TrueHD"},
            {"tta",             "TTA (True Audio)"},
            {"tty",             "Tele-typewriter"},
            {"txd",             "Renderware TeXture Dictionary"},
            {"u16be",           "PCM unsigned 16-bit big-endian"},
            {"u16le",           "PCM unsigned 16-bit little-endian"},
            {"u24be",           "PCM unsigned 24-bit big-endian"},
            {"u24le",           "PCM unsigned 24-bit little-endian"},
            {"u32be",           "PCM unsigned 32-bit big-endian"},
            {"u32le",           "PCM unsigned 32-bit little-endian"},
            {"u8",              "PCM unsigned 8-bit"},
            {"uncodedframecrc", "uncoded framecrc testing"},
            {"v210",            "Uncompressed 4:2:2 10-bit"},
            {"v210x",           "Uncompressed 4:2:2 10-bit"},
            {"vag",             "Sony PS2 VAG"},
            {"vc1",             "raw VC-1 video"},
            {"vc1test",         "VC-1 test bitstream"},
            {"vcd",             "MPEG-1 Systems / MPEG program stream (VCD)"},
            {"vfwcap",          "VfW video capture"},
            {"vivo",            "Vivo"},
            {"vmd",             "Sierra VMD"},
            {"vob",             "MPEG-2 PS (VOB)"},
            {"vobsub",          "VobSub subtitle format"},
            {"voc",             "Creative Voice"},
            {"vpk",             "Sony PS2 VPK"},
            {"vplayer",         "VPlayer subtitles"},
            {"vqf",             "Nippon Telegraph and Telephone Corporation (NTT) TwinVQ"},
            {"w64",             "Sony Wave64"},
            {"wav",             "WAV / WAVE (Waveform Audio)"},
            {"wc3movie",        "Wing Commander III movie"},
            {"webm",            "WebM"},
            {"webm_chunk",      "WebM Chunk Muxer"},
            {"webm_dash_manifest", "WebM DASH Manifest"},
            {"webp",            "WebP"},
            {"webp_pipe",       "piped webp sequence"},
            {"webvtt",          "WebVTT subtitle"},
            {"wma",             "Windows Media Audio"},
            {"wmv",             "Windows Media Video"},
            {"wsaud",           "Westwood Studios audio"},
            {"wsd",             "Wideband Single-bit Data (WSD)"},
            {"wsvqa",           "Westwood Studios VQA"},
            {"wtv",             "Windows Television (WTV)"},
            {"wv",              "raw WavPack"},
            {"wve",             "Psion 3 audio"},
            {"xa",              "Maxis XA"},
            {"xbin",            "eXtended BINary text (XBIN)"},
            {"xmv",             "Microsoft XMV"},
            {"xpm_pipe",        "piped xpm sequence"},
            {"xvag",            "Sony PS3 XVAG"},
            {"xwma",            "Microsoft xWMA"},
            {"yop",             "Psygnosis YOP"},
            {"yuv4mpegpipe",    "YUV4MPEG pipe"}
        };
        #endregion

        #region file catalog
        private string[] audio = new string[] {
            "aac", "amr", "mp3", "ogg", "wma", "wav", "m4a", "oga"
        };

        private string[] video = new string[] {
            "flv", "mkv", "mp4", "wmv", "webm", "h264", "avi", "divx", "xvid", "mjpeg", "m4v", "ogv", "ogg"
        };

        private string[] image = new string[] {
            "gif", "webp", "png", "jpg", "jpeg", "tif", "tiff", "bmp"
        };
        #endregion

        #region Defalut Convert Params for Target
        private Dictionary<string, string> TargetParams = new Dictionary<string, string>()
        {
            // audio
            { "aac", "-acodec aac -b:a 320k -q:a 1 -write_id3v2 true -write_apetag true" },
            { "amr", "-acodec libamr_nb -ab 12.2k -ar 8000 -ac 1" },
            { "mp3", "-acodec libmp3lame -b:a 320k -q:a 1" },
            //{ "ogg", "-strict 1 -acodec libvorbis -b:a 320k -q:a 6" },
            { "ogg", "-strict 1 -acodec libvorbis -b:a 320k -q:a 6" },
            { "wav", "-f wav" },
            { "wma", "" },
            // video
            { "flv" , "" },
            { "h264", "-vcodec h264_nvenc -preset slow -vbsf h264_mp4toannexb -an" },
            { "mp4" , "-vcodec h264_nvenc -preset slow -level 4.1 -qmin 10 -qmax 52 -acodec aac -b:a 320k -q:a 1 " },
            { "h265" , "-vcodec hevc_nvenc -preset slow -level 4.1 -qmin 10 -qmax 52 -acodec aac -b:a 320k -q:a 1 " },
            { "hevc" , "-vcodec hevc_nvenc -preset slow -level 4.1 -qmin 10 -qmax 52 -acodec aac -b:a 320k -q:a 1 " },
            { "mkv" , "-acodec copy -vcodec copy" },
            { "webm", "-c:v libvpx-vp9 -crf 12 -b:v 100K" },
            { "wmv" , "" },
            // image
            { "bmp" , "" },
            { "gif" , "-vf \"scale=trunc(iw/2)*2:trunc(ih/2)*2\"" },
            { "jpg" , "" },
            { "png" , "" },
            { "tif" , "" },
            { "webp", "-c libwebp" },
            // unknown
            {"unk", "" }
        };
        #endregion

        private static string[] ParseCommandLine( string cmdline )
        {
            List<string> args = new List<string>();

            string[] cmds = cmdline.Split( new char[] { ' ' } );
            string arg = "";
            foreach ( string cmd in cmds )
            {
                if ( cmd.StartsWith( "\"" ) && cmd.EndsWith( "\"" ) )
                {
                    args.Add( cmd.Trim( new char[] { '\"', ' ' } ) );
                    arg = "";
                }
                else if ( cmd.StartsWith( "\"" ) )
                {
                    arg = cmd + " ";
                }
                else if ( cmd.EndsWith( "\"" ) )
                {
                    arg += cmd;
                    args.Add( arg.Trim( new char[] { '\"', ' ' } ) );
                    arg = "";
                }
                else if ( !string.IsNullOrEmpty( arg ) )
                {
                    arg += cmd + " ";
                }
                else
                {
                    if ( !string.IsNullOrEmpty( cmd ) )
                    {
                        args.Add( cmd );
                    }
                    arg = "";
                }
            }
            return ( args.GetRange( 1, args.Count - 1 ).ToArray() );
        }

        internal void alert( string text )
        {
            StringBuilder sb = new StringBuilder();
            int index = 0;
            while ( index < text.Length )
            {
                int tail = text.Length-index;
                sb.AppendLine( text.Substring( index, tail > 80 ? 80 : tail ) );
                index += 80;
                if ( index > 512 ) break;
            }
            MessageBox.Show( this, sb.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning );
        }

        internal async Task<int> Run( string cmd, string[] args, string working = "" )
        {
            List<string> param = new List<string>();
            param.AddRange( args );

            return ( await Run( cmd, string.Join( " ", param ) ) );
        }

        internal async Task<int> Run( string cmd, string args, string working = "" )
        {
            int exitCode = -1000;
            if ( !File.Exists( cmd ) ) return ( exitCode );

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

            //bool exited = p.HasExited;

            if ( p.HasExited ) exitCode = p.ExitCode;
            //p.CancelOutputRead();
            //p.CancelErrorRead();
            p.Close();

            return ( exitCode );
        }

        internal async Task<int> PerformConvert( string[] files )
        {
            int exit = -1;
            foreach ( Control dst in grpDst.Controls )
            {
                if ( ( dst as RadioButton ).Checked )
                {
                    foreach ( string fsrc in files )
                    {
                        if ( File.Exists( fsrc ) )
                        {
                            string working = Path.GetDirectoryName(fsrc);
                            string args = SetParams( dst.Text, fsrc );
                            if ( string.IsNullOrEmpty( args ) ) continue;
                            exit = await Run( Path.Combine( AppPath, "ffmpeg.exe" ), args, working );
                        }
                    }
                    //if ( exit == 0 ) MessageBox.Show( "OK!" );
                    break;
                }
            }
            return ( exit );
        }

        internal async Task ConvertAll(string[] files)
        {
            foreach (Control dst in grpDst.Controls)
            {
                if (dst is RadioButton && (dst as RadioButton).Checked)
                {
                    var total = files.Length;
                    var count = 0;
                    foreach (string fsrc in files)
                    {
                        if (File.Exists(fsrc))
                        {
                            string working = Path.GetDirectoryName(fsrc);
                            string args = SetParams( dst.Text, fsrc );
                            if (string.IsNullOrEmpty(args)) continue;
                            var exit = await Run(Path.Combine(AppPath, "ffmpeg.exe"), args, working);
                            count++;
                            progressBar.Value = Convert.ToInt32( count / total);
                        }
                    }
                    progressBar.Value = 100;
                    //if ( exit == 0 ) MessageBox.Show( "OK!" );
                    break;
                }
            }
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

            if ( !chkForce.Checked && same.Contains( src ) && same.Contains( dst ) )
            {
                commonargs.Add( $"-acodec copy -vcodec copy" );
            }
            else if ( image.Contains( src ) && image2video.Contains( dst ) )
            {
                commonargs.Add( TargetParams["h264"] );
                commonargs.Add( TargetParams["gif"] );
            }
            else if ( image.Contains( src ) && video.Contains( dst ) )
            {
                commonargs.Add( TargetParams[dst] );
                commonargs.Add( TargetParams["gif"] );
            }
            else if ( image.Contains( src ) && image2audio.Contains( dst ) )
            {
                commonargs.Add( TargetParams[dst] );
                commonargs.Add( TargetParams["gif"] );
            }
            else if ( image.Contains( src ) && !image2audio.Contains( dst ) )
            {
                alert( $"Can't convert from [{src}] to [{dst}]." );
                return ( string.Empty );
            }
            else if ( TargetParams.ContainsKey( dst ) )
            {
                commonargs.Add( TargetParams[dst] );
            }
            else
            {
            }

            //if ( audio.Contains( src ) && video.Contains( dst ) )
            //{
            //    //commonargs.Add( $"-r 1 -s 1280,720 -aspect 16:9" );
            //    commonargs.Add( $"-vn" );
            //}
            if ( audio.Contains( src ) || audio.Contains( dst ) && !video.Contains( dst ) )
            {
                commonargs.Add( $"-vn" );
            }
            else if ( image.Contains( src ) && video.Contains( dst ) )
            {
                commonargs.Add( $"-an" );
            }


            commonargs.Add( $"\"{fo}\"" );
            result = string.Join( " ", commonargs );

            return ( result );
        }

        internal void loadSetting()
        {
            foreach ( string k in TargetParams.Keys.ToArray() )
            {
                try
                {
                    TargetParams[k] = appSection.Settings[k].Value;
                }
                catch
                {
                    //appSection.Settings.Add( k, TargetParams[k] );
                }
            }
        }

        internal void saveSetting()
        {
            foreach ( string k in TargetParams.Keys )
            {
                try
                {
                    appSection.Settings[k].Value = TargetParams[k];
                }
                catch
                {
                    appSection.Settings.Add( k, TargetParams[k] );
                }
            }
            config.Save();
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load( object sender, EventArgs e )
        {
            Icon = Icon.ExtractAssociatedIcon( Application.ExecutablePath );

            supported.AddRange( video );
            supported.AddRange( audio );
            supported.AddRange( image );

            btnConvert.Image = Icon.ToBitmap();

            btnDstMP4.PerformClick();

            //MessageBox.Show( $"{ string.Join("\n\r", TargetParams.Values)}" );

            loadSetting();
        }

        private async void MainForm_Shown( object sender, EventArgs e )
        {
            Refresh();

            string[] args = ParseCommandLine(Environment.CommandLine);
            if ( args.Length > 0 )
            {
                int exit = await PerformConvert( args );
            }
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
                        //int exit = await PerformConvert( dragFiles );
                        //PerformConvert(dragFiles);
                        await ConvertAll(dragFiles);
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
            fl.Add( $"All Supported" );
            fl.Add( $"*.{string.Join( ";*.", supported )}" );
            fl.Add( $"All File(s)|*.*" );
            foreach ( string ft in supported )
            {
                string ftdisplay = ft.ToLower();
                if ( formats.ContainsKey( ftdisplay ) )
                    ftdisplay = formats[ftdisplay];
                else
                    ftdisplay = ftdisplay.ToUpper();
                fl.Add( $"{ftdisplay}|*.{ft}" );
            }
            dlgOpen.Filter = string.Join( "|", fl );

            //dlgOpen.Filter = $@"All supported File(s)|*.{string.Join(";*.", supported)}|All File(s)|*.*";
            //dlgOpen.FileName = string.Join( ";", supported );
            dlgOpen.FileName = string.Empty;
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                //int exit = await PerformConvert( dlgOpen.FileNames );
                await ConvertAll(dlgOpen.FileNames);
            }
            btnConvert.Enabled = true;
        }

        private void linkFFmpeg_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            Process.Start( "https://ffmpeg.org" );
        }

        private void tsmiSetParams_Click( object sender, EventArgs e )
        {
            using ( FFmpegConvertGUI.ParamsForm fm = new FFmpegConvertGUI.ParamsForm() )
            {
                fm.Icon = Icon;
                foreach ( Control dst in grpDst.Controls )
                {
                    if ( ( dst as RadioButton ).Checked )
                    {
                        fm.Text = $"Target {dst.Text} {fm.Text}";
                        var k = dst.Text.ToLower();
                        fm.SetParams( TargetParams[k] );
                        if ( fm.ShowDialog() == DialogResult.OK )
                        {
                            TargetParams[k] = fm.GetParams();
                        }
                        break;
                    }
                }
            }
        }

        private void tsmiSaveParams_Click( object sender, EventArgs e )
        {
            saveSetting();
        }

        private void tsmiExit_Click( object sender, EventArgs e )
        {
            Close();
        }
    }
}
