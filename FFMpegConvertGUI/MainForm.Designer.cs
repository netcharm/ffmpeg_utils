namespace FFMpegConvertGUI
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpDst = new System.Windows.Forms.GroupBox();
            this.btnDstHEIC = new System.Windows.Forms.RadioButton();
            this.btnDstHEVC = new System.Windows.Forms.RadioButton();
            this.btnDstH265 = new System.Windows.Forms.RadioButton();
            this.btnDstWAV = new System.Windows.Forms.RadioButton();
            this.btnDstWebP = new System.Windows.Forms.RadioButton();
            this.btnDstH264 = new System.Windows.Forms.RadioButton();
            this.btnDstWebM = new System.Windows.Forms.RadioButton();
            this.btnDstWMV = new System.Windows.Forms.RadioButton();
            this.btnDstMP4 = new System.Windows.Forms.RadioButton();
            this.btnDstMKV = new System.Windows.Forms.RadioButton();
            this.btnDstFLV = new System.Windows.Forms.RadioButton();
            this.btnDstTIF = new System.Windows.Forms.RadioButton();
            this.btnDstJPG = new System.Windows.Forms.RadioButton();
            this.btnDstPNG = new System.Windows.Forms.RadioButton();
            this.btnDstBMP = new System.Windows.Forms.RadioButton();
            this.btnDstGIF = new System.Windows.Forms.RadioButton();
            this.btnDstAAC = new System.Windows.Forms.RadioButton();
            this.btnDstWMA = new System.Windows.Forms.RadioButton();
            this.btnDstOGG = new System.Windows.Forms.RadioButton();
            this.btnDstMP3 = new System.Windows.Forms.RadioButton();
            this.btnDstAMR = new System.Windows.Forms.RadioButton();
            this.btnConvert = new System.Windows.Forms.Button();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.grpPowered = new System.Windows.Forms.GroupBox();
            this.linkFFmpeg = new System.Windows.Forms.LinkLabel();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiSetParams = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveParams = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.chkForce = new System.Windows.Forms.CheckBox();
            this.trkQ = new System.Windows.Forms.TrackBar();
            this.grpDst.SuspendLayout();
            this.grpPowered.SuspendLayout();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkQ)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDst
            // 
            this.grpDst.Controls.Add(this.btnDstHEIC);
            this.grpDst.Controls.Add(this.btnDstHEVC);
            this.grpDst.Controls.Add(this.btnDstH265);
            this.grpDst.Controls.Add(this.btnDstWAV);
            this.grpDst.Controls.Add(this.btnDstWebP);
            this.grpDst.Controls.Add(this.btnDstH264);
            this.grpDst.Controls.Add(this.btnDstWebM);
            this.grpDst.Controls.Add(this.btnDstWMV);
            this.grpDst.Controls.Add(this.btnDstMP4);
            this.grpDst.Controls.Add(this.btnDstMKV);
            this.grpDst.Controls.Add(this.btnDstFLV);
            this.grpDst.Controls.Add(this.btnDstTIF);
            this.grpDst.Controls.Add(this.btnDstJPG);
            this.grpDst.Controls.Add(this.btnDstPNG);
            this.grpDst.Controls.Add(this.btnDstBMP);
            this.grpDst.Controls.Add(this.btnDstGIF);
            this.grpDst.Controls.Add(this.btnDstAAC);
            this.grpDst.Controls.Add(this.btnDstWMA);
            this.grpDst.Controls.Add(this.btnDstOGG);
            this.grpDst.Controls.Add(this.btnDstMP3);
            this.grpDst.Controls.Add(this.btnDstAMR);
            this.grpDst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpDst.Location = new System.Drawing.Point(113, 13);
            this.grpDst.Name = "grpDst";
            this.grpDst.Size = new System.Drawing.Size(209, 187);
            this.grpDst.TabIndex = 1;
            this.grpDst.TabStop = false;
            this.grpDst.Text = "Target";
            // 
            // btnDstHEIC
            // 
            this.btnDstHEIC.AutoSize = true;
            this.btnDstHEIC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDstHEIC.Location = new System.Drawing.Point(18, 152);
            this.btnDstHEIC.Name = "btnDstHEIC";
            this.btnDstHEIC.Size = new System.Drawing.Size(46, 16);
            this.btnDstHEIC.TabIndex = 23;
            this.btnDstHEIC.Text = "HEIC";
            this.btnDstHEIC.UseVisualStyleBackColor = true;
            // 
            // btnDstHEVC
            // 
            this.btnDstHEVC.AutoSize = true;
            this.btnDstHEVC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDstHEVC.Location = new System.Drawing.Point(85, 152);
            this.btnDstHEVC.Name = "btnDstHEVC";
            this.btnDstHEVC.Size = new System.Drawing.Size(46, 16);
            this.btnDstHEVC.TabIndex = 22;
            this.btnDstHEVC.Text = "HEVC";
            this.btnDstHEVC.UseVisualStyleBackColor = true;
            // 
            // btnDstH265
            // 
            this.btnDstH265.AutoSize = true;
            this.btnDstH265.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDstH265.Location = new System.Drawing.Point(152, 152);
            this.btnDstH265.Name = "btnDstH265";
            this.btnDstH265.Size = new System.Drawing.Size(46, 16);
            this.btnDstH265.TabIndex = 21;
            this.btnDstH265.Text = "H265";
            this.btnDstH265.UseVisualStyleBackColor = true;
            // 
            // btnDstWAV
            // 
            this.btnDstWAV.AutoSize = true;
            this.btnDstWAV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDstWAV.Location = new System.Drawing.Point(18, 130);
            this.btnDstWAV.Name = "btnDstWAV";
            this.btnDstWAV.Size = new System.Drawing.Size(40, 16);
            this.btnDstWAV.TabIndex = 20;
            this.btnDstWAV.Text = "WAV";
            this.btnDstWAV.UseVisualStyleBackColor = true;
            // 
            // btnDstWebP
            // 
            this.btnDstWebP.AutoSize = true;
            this.btnDstWebP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDstWebP.Location = new System.Drawing.Point(85, 130);
            this.btnDstWebP.Name = "btnDstWebP";
            this.btnDstWebP.Size = new System.Drawing.Size(46, 16);
            this.btnDstWebP.TabIndex = 19;
            this.btnDstWebP.Text = "WebP";
            this.btnDstWebP.UseVisualStyleBackColor = true;
            // 
            // btnDstH264
            // 
            this.btnDstH264.AutoSize = true;
            this.btnDstH264.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDstH264.Location = new System.Drawing.Point(152, 108);
            this.btnDstH264.Name = "btnDstH264";
            this.btnDstH264.Size = new System.Drawing.Size(46, 16);
            this.btnDstH264.TabIndex = 18;
            this.btnDstH264.Text = "H264";
            this.btnDstH264.UseVisualStyleBackColor = true;
            // 
            // btnDstWebM
            // 
            this.btnDstWebM.AutoSize = true;
            this.btnDstWebM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDstWebM.Location = new System.Drawing.Point(152, 130);
            this.btnDstWebM.Name = "btnDstWebM";
            this.btnDstWebM.Size = new System.Drawing.Size(46, 16);
            this.btnDstWebM.TabIndex = 18;
            this.btnDstWebM.Text = "WebM";
            this.btnDstWebM.UseVisualStyleBackColor = true;
            // 
            // btnDstWMV
            // 
            this.btnDstWMV.AutoSize = true;
            this.btnDstWMV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDstWMV.Location = new System.Drawing.Point(152, 86);
            this.btnDstWMV.Name = "btnDstWMV";
            this.btnDstWMV.Size = new System.Drawing.Size(40, 16);
            this.btnDstWMV.TabIndex = 16;
            this.btnDstWMV.Text = "WMV";
            this.btnDstWMV.UseVisualStyleBackColor = true;
            // 
            // btnDstMP4
            // 
            this.btnDstMP4.AutoSize = true;
            this.btnDstMP4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDstMP4.Location = new System.Drawing.Point(152, 64);
            this.btnDstMP4.Name = "btnDstMP4";
            this.btnDstMP4.Size = new System.Drawing.Size(40, 16);
            this.btnDstMP4.TabIndex = 17;
            this.btnDstMP4.Text = "MP4";
            this.btnDstMP4.UseVisualStyleBackColor = true;
            // 
            // btnDstMKV
            // 
            this.btnDstMKV.AutoSize = true;
            this.btnDstMKV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDstMKV.Location = new System.Drawing.Point(152, 42);
            this.btnDstMKV.Name = "btnDstMKV";
            this.btnDstMKV.Size = new System.Drawing.Size(40, 16);
            this.btnDstMKV.TabIndex = 15;
            this.btnDstMKV.Text = "MKV";
            this.btnDstMKV.UseVisualStyleBackColor = true;
            // 
            // btnDstFLV
            // 
            this.btnDstFLV.AutoSize = true;
            this.btnDstFLV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDstFLV.Location = new System.Drawing.Point(152, 20);
            this.btnDstFLV.Name = "btnDstFLV";
            this.btnDstFLV.Size = new System.Drawing.Size(40, 16);
            this.btnDstFLV.TabIndex = 14;
            this.btnDstFLV.Text = "FLV";
            this.btnDstFLV.UseVisualStyleBackColor = true;
            // 
            // btnDstTIF
            // 
            this.btnDstTIF.AutoSize = true;
            this.btnDstTIF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDstTIF.Location = new System.Drawing.Point(85, 108);
            this.btnDstTIF.Name = "btnDstTIF";
            this.btnDstTIF.Size = new System.Drawing.Size(40, 16);
            this.btnDstTIF.TabIndex = 13;
            this.btnDstTIF.Text = "TIF";
            this.btnDstTIF.UseVisualStyleBackColor = true;
            // 
            // btnDstJPG
            // 
            this.btnDstJPG.AutoSize = true;
            this.btnDstJPG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDstJPG.Location = new System.Drawing.Point(85, 64);
            this.btnDstJPG.Name = "btnDstJPG";
            this.btnDstJPG.Size = new System.Drawing.Size(40, 16);
            this.btnDstJPG.TabIndex = 13;
            this.btnDstJPG.Text = "JPG";
            this.btnDstJPG.UseVisualStyleBackColor = true;
            // 
            // btnDstPNG
            // 
            this.btnDstPNG.AutoSize = true;
            this.btnDstPNG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDstPNG.Location = new System.Drawing.Point(85, 42);
            this.btnDstPNG.Name = "btnDstPNG";
            this.btnDstPNG.Size = new System.Drawing.Size(40, 16);
            this.btnDstPNG.TabIndex = 13;
            this.btnDstPNG.Text = "PNG";
            this.btnDstPNG.UseVisualStyleBackColor = true;
            // 
            // btnDstBMP
            // 
            this.btnDstBMP.AutoSize = true;
            this.btnDstBMP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDstBMP.Location = new System.Drawing.Point(85, 86);
            this.btnDstBMP.Name = "btnDstBMP";
            this.btnDstBMP.Size = new System.Drawing.Size(40, 16);
            this.btnDstBMP.TabIndex = 13;
            this.btnDstBMP.Text = "BMP";
            this.btnDstBMP.UseVisualStyleBackColor = true;
            // 
            // btnDstGIF
            // 
            this.btnDstGIF.AutoSize = true;
            this.btnDstGIF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDstGIF.Location = new System.Drawing.Point(85, 20);
            this.btnDstGIF.Name = "btnDstGIF";
            this.btnDstGIF.Size = new System.Drawing.Size(40, 16);
            this.btnDstGIF.TabIndex = 13;
            this.btnDstGIF.Text = "GIF";
            this.btnDstGIF.UseVisualStyleBackColor = true;
            // 
            // btnDstAAC
            // 
            this.btnDstAAC.AutoSize = true;
            this.btnDstAAC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDstAAC.Location = new System.Drawing.Point(18, 42);
            this.btnDstAAC.Name = "btnDstAAC";
            this.btnDstAAC.Size = new System.Drawing.Size(40, 16);
            this.btnDstAAC.TabIndex = 12;
            this.btnDstAAC.Text = "AAC";
            this.btnDstAAC.UseVisualStyleBackColor = true;
            // 
            // btnDstWMA
            // 
            this.btnDstWMA.AutoSize = true;
            this.btnDstWMA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDstWMA.Location = new System.Drawing.Point(18, 108);
            this.btnDstWMA.Name = "btnDstWMA";
            this.btnDstWMA.Size = new System.Drawing.Size(40, 16);
            this.btnDstWMA.TabIndex = 10;
            this.btnDstWMA.Text = "WMA";
            this.btnDstWMA.UseVisualStyleBackColor = true;
            // 
            // btnDstOGG
            // 
            this.btnDstOGG.AutoSize = true;
            this.btnDstOGG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDstOGG.Location = new System.Drawing.Point(18, 86);
            this.btnDstOGG.Name = "btnDstOGG";
            this.btnDstOGG.Size = new System.Drawing.Size(40, 16);
            this.btnDstOGG.TabIndex = 11;
            this.btnDstOGG.Text = "OGG";
            this.btnDstOGG.UseVisualStyleBackColor = true;
            // 
            // btnDstMP3
            // 
            this.btnDstMP3.AutoSize = true;
            this.btnDstMP3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDstMP3.Location = new System.Drawing.Point(18, 64);
            this.btnDstMP3.Name = "btnDstMP3";
            this.btnDstMP3.Size = new System.Drawing.Size(40, 16);
            this.btnDstMP3.TabIndex = 9;
            this.btnDstMP3.Text = "MP3";
            this.btnDstMP3.UseVisualStyleBackColor = true;
            // 
            // btnDstAMR
            // 
            this.btnDstAMR.AutoSize = true;
            this.btnDstAMR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDstAMR.Location = new System.Drawing.Point(18, 20);
            this.btnDstAMR.Name = "btnDstAMR";
            this.btnDstAMR.Size = new System.Drawing.Size(40, 16);
            this.btnDstAMR.TabIndex = 8;
            this.btnDstAMR.Text = "AMR";
            this.btnDstAMR.UseVisualStyleBackColor = true;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(12, 15);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(95, 80);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "Convert";
            this.btnConvert.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConvert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // dlgOpen
            // 
            this.dlgOpen.Multiselect = true;
            // 
            // grpPowered
            // 
            this.grpPowered.Controls.Add(this.linkFFmpeg);
            this.grpPowered.Location = new System.Drawing.Point(12, 102);
            this.grpPowered.Name = "grpPowered";
            this.grpPowered.Size = new System.Drawing.Size(95, 35);
            this.grpPowered.TabIndex = 3;
            this.grpPowered.TabStop = false;
            this.grpPowered.Text = "Powered By";
            // 
            // linkFFmpeg
            // 
            this.linkFFmpeg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkFFmpeg.AutoEllipsis = true;
            this.linkFFmpeg.Location = new System.Drawing.Point(7, 18);
            this.linkFFmpeg.Name = "linkFFmpeg";
            this.linkFFmpeg.Size = new System.Drawing.Size(82, 35);
            this.linkFFmpeg.TabIndex = 0;
            this.linkFFmpeg.TabStop = true;
            this.linkFFmpeg.Text = "ffmpeg.org";
            this.linkFFmpeg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFFmpeg_LinkClicked);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSetParams,
            this.tsmiSaveParams,
            this.tsmiSep0,
            this.tsmiExit});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(200, 76);
            // 
            // tsmiSetParams
            // 
            this.tsmiSetParams.Name = "tsmiSetParams";
            this.tsmiSetParams.Size = new System.Drawing.Size(199, 22);
            this.tsmiSetParams.Text = "Set Convert Params";
            this.tsmiSetParams.Click += new System.EventHandler(this.tsmiSetParams_Click);
            // 
            // tsmiSaveParams
            // 
            this.tsmiSaveParams.Name = "tsmiSaveParams";
            this.tsmiSaveParams.Size = new System.Drawing.Size(199, 22);
            this.tsmiSaveParams.Text = "Save Convert Params";
            this.tsmiSaveParams.Click += new System.EventHandler(this.tsmiSaveParams_Click);
            // 
            // tsmiSep0
            // 
            this.tsmiSep0.Name = "tsmiSep0";
            this.tsmiSep0.Size = new System.Drawing.Size(196, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(199, 22);
            this.tsmiExit.Text = "Exit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 206);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(310, 11);
            this.progressBar.TabIndex = 4;
            // 
            // chkForce
            // 
            this.chkForce.Location = new System.Drawing.Point(12, 165);
            this.chkForce.Name = "chkForce";
            this.chkForce.Size = new System.Drawing.Size(95, 35);
            this.chkForce.TabIndex = 23;
            this.chkForce.Text = "Force Re-Encode";
            this.chkForce.UseVisualStyleBackColor = true;
            // 
            // trkQ
            // 
            this.trkQ.Location = new System.Drawing.Point(13, 144);
            this.trkQ.Name = "trkQ";
            this.trkQ.Size = new System.Drawing.Size(94, 45);
            this.trkQ.TabIndex = 24;
            this.trkQ.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkQ.Value = 6;
            this.trkQ.ValueChanged += new System.EventHandler(this.trkQ_ValueChanged);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnConvert;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 226);
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.chkForce);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.grpPowered);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.grpDst);
            this.Controls.Add(this.trkQ);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Media Convert";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.MainForm_DragOver);
            this.grpDst.ResumeLayout(false);
            this.grpDst.PerformLayout();
            this.grpPowered.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trkQ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grpDst;
        private System.Windows.Forms.RadioButton btnDstWMV;
        private System.Windows.Forms.RadioButton btnDstMP4;
        private System.Windows.Forms.RadioButton btnDstMKV;
        private System.Windows.Forms.RadioButton btnDstFLV;
        private System.Windows.Forms.RadioButton btnDstGIF;
        private System.Windows.Forms.RadioButton btnDstAAC;
        private System.Windows.Forms.RadioButton btnDstWMA;
        private System.Windows.Forms.RadioButton btnDstOGG;
        private System.Windows.Forms.RadioButton btnDstMP3;
        private System.Windows.Forms.RadioButton btnDstAMR;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.RadioButton btnDstWebM;
        private System.Windows.Forms.RadioButton btnDstWebP;
        private System.Windows.Forms.RadioButton btnDstWAV;
        private System.Windows.Forms.RadioButton btnDstH264;
        private System.Windows.Forms.RadioButton btnDstTIF;
        private System.Windows.Forms.RadioButton btnDstJPG;
        private System.Windows.Forms.RadioButton btnDstPNG;
        private System.Windows.Forms.RadioButton btnDstBMP;
        private System.Windows.Forms.GroupBox grpPowered;
        private System.Windows.Forms.LinkLabel linkFFmpeg;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetParams;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveParams;
        private System.Windows.Forms.ToolStripSeparator tsmiSep0;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.RadioButton btnDstH265;
        private System.Windows.Forms.CheckBox chkForce;
        private System.Windows.Forms.RadioButton btnDstHEIC;
        private System.Windows.Forms.RadioButton btnDstHEVC;
        private System.Windows.Forms.TrackBar trkQ;
    }
}

