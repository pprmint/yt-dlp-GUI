namespace yt_dlp_GUI
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            labelName = new Label();
            labelSourceUrl = new Label();
            textBoxSourceUrl = new TextBox();
            labelDownloadType = new Label();
            radioButtonVideo = new RadioButton();
            radioButtonAudio = new RadioButton();
            dropdownVideoFormat = new ComboBox();
            dropdownAudioFormat = new ComboBox();
            labelOutputDir = new Label();
            textBoxOutputDir = new TextBox();
            buttonBrowse = new Button();
            buttonStartDownload = new Button();
            contextMenuTroubleshoot = new ContextMenuStrip(components);
            viewCommandToolStripMenuItem = new ToolStripMenuItem();
            folderBrowserDialog = new FolderBrowserDialog();
            textBoxConsoleOut = new TextBox();
            labelUpdateStatus = new Label();
            buttonUpdate = new Button();
            toolTipUpdate = new ToolTip(components);
            toolTipVtdlpVersion = new ToolTip(components);
            labelVideoFormat = new Label();
            labelAudioFormat = new Label();
            dropdownVideoResolution = new ComboBox();
            labelVideoResolution = new Label();
            buttonAbortDownload = new Button();
            buttonAbout = new Button();
            toolTipAbout = new ToolTip(components);
            contextMenuTroubleshoot.SuspendLayout();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI Variable Display", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelName.Location = new Point(6, 9);
            labelName.Margin = new Padding(0);
            labelName.Name = "labelName";
            labelName.Size = new Size(252, 32);
            labelName.TabIndex = 0;
            labelName.Text = "Let's download stuff.";
            // 
            // labelSourceUrl
            // 
            labelSourceUrl.AutoSize = true;
            labelSourceUrl.Location = new Point(9, 53);
            labelSourceUrl.Margin = new Padding(0, 12, 0, 0);
            labelSourceUrl.Name = "labelSourceUrl";
            labelSourceUrl.Size = new Size(74, 16);
            labelSourceUrl.TabIndex = 4;
            labelSourceUrl.Text = "Source URLs";
            // 
            // textBoxSourceUrl
            // 
            textBoxSourceUrl.Location = new Point(12, 72);
            textBoxSourceUrl.Multiline = true;
            textBoxSourceUrl.Name = "textBoxSourceUrl";
            textBoxSourceUrl.ScrollBars = ScrollBars.Vertical;
            textBoxSourceUrl.Size = new Size(406, 72);
            textBoxSourceUrl.TabIndex = 0;
            textBoxSourceUrl.Tag = "sourceUrl";
            // 
            // labelDownloadType
            // 
            labelDownloadType.AutoSize = true;
            labelDownloadType.Location = new Point(9, 159);
            labelDownloadType.Margin = new Padding(0, 12, 0, 0);
            labelDownloadType.Name = "labelDownloadType";
            labelDownloadType.Size = new Size(89, 16);
            labelDownloadType.TabIndex = 6;
            labelDownloadType.Text = "Download type";
            labelDownloadType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // radioButtonVideo
            // 
            radioButtonVideo.AutoSize = true;
            radioButtonVideo.Location = new Point(11, 180);
            radioButtonVideo.Name = "radioButtonVideo";
            radioButtonVideo.Size = new Size(57, 20);
            radioButtonVideo.TabIndex = 1;
            radioButtonVideo.TabStop = true;
            radioButtonVideo.Text = "Video";
            radioButtonVideo.UseVisualStyleBackColor = true;
            // 
            // radioButtonAudio
            // 
            radioButtonAudio.AutoSize = true;
            radioButtonAudio.Location = new Point(74, 180);
            radioButtonAudio.Name = "radioButtonAudio";
            radioButtonAudio.Size = new Size(83, 20);
            radioButtonAudio.TabIndex = 2;
            radioButtonAudio.TabStop = true;
            radioButtonAudio.Text = "Audio only";
            radioButtonAudio.UseVisualStyleBackColor = true;
            // 
            // dropdownVideoFormat
            // 
            dropdownVideoFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            dropdownVideoFormat.FormattingEnabled = true;
            dropdownVideoFormat.Items.AddRange(new object[] { "mp4", "mkv", "mov", "avi", "flv" });
            dropdownVideoFormat.Location = new Point(297, 178);
            dropdownVideoFormat.Name = "dropdownVideoFormat";
            dropdownVideoFormat.Size = new Size(121, 24);
            dropdownVideoFormat.TabIndex = 4;
            dropdownVideoFormat.Tag = "videoFormat";
            dropdownVideoFormat.Visible = false;
            // 
            // dropdownAudioFormat
            // 
            dropdownAudioFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            dropdownAudioFormat.FormattingEnabled = true;
            dropdownAudioFormat.Items.AddRange(new object[] { "mp3", "wav", "flac", "aac", "alac", "m4a", "opus", "vorbis" });
            dropdownAudioFormat.Location = new Point(297, 178);
            dropdownAudioFormat.Name = "dropdownAudioFormat";
            dropdownAudioFormat.Size = new Size(121, 24);
            dropdownAudioFormat.TabIndex = 4;
            dropdownAudioFormat.Tag = "audioFormat";
            dropdownAudioFormat.Visible = false;
            // 
            // labelOutputDir
            // 
            labelOutputDir.AutoSize = true;
            labelOutputDir.Location = new Point(9, 215);
            labelOutputDir.Margin = new Padding(0, 12, 0, 0);
            labelOutputDir.Name = "labelOutputDir";
            labelOutputDir.Size = new Size(96, 16);
            labelOutputDir.TabIndex = 11;
            labelOutputDir.Tag = "outputDir";
            labelOutputDir.Text = "Output directory";
            // 
            // textBoxOutputDir
            // 
            textBoxOutputDir.Location = new Point(12, 234);
            textBoxOutputDir.Name = "textBoxOutputDir";
            textBoxOutputDir.Size = new Size(279, 23);
            textBoxOutputDir.TabIndex = 5;
            textBoxOutputDir.Tag = "outputDir";
            // 
            // buttonBrowse
            // 
            buttonBrowse.Location = new Point(296, 232);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(123, 27);
            buttonBrowse.TabIndex = 6;
            buttonBrowse.Text = "Browse...";
            buttonBrowse.UseVisualStyleBackColor = true;
            buttonBrowse.Click += ButtonBrowse_Click;
            // 
            // buttonStartDownload
            // 
            buttonStartDownload.ContextMenuStrip = contextMenuTroubleshoot;
            buttonStartDownload.Enabled = false;
            buttonStartDownload.Location = new Point(11, 274);
            buttonStartDownload.Margin = new Padding(3, 12, 3, 3);
            buttonStartDownload.Name = "buttonStartDownload";
            buttonStartDownload.Size = new Size(408, 27);
            buttonStartDownload.TabIndex = 7;
            buttonStartDownload.Text = "Start download";
            buttonStartDownload.UseVisualStyleBackColor = true;
            buttonStartDownload.Click += ButtonStartDownload_Click;
            // 
            // contextMenuTroubleshoot
            // 
            contextMenuTroubleshoot.Items.AddRange(new ToolStripItem[] { viewCommandToolStripMenuItem });
            contextMenuTroubleshoot.Name = "contextMenuStrip1";
            contextMenuTroubleshoot.Size = new Size(158, 26);
            // 
            // viewCommandToolStripMenuItem
            // 
            viewCommandToolStripMenuItem.Name = "viewCommandToolStripMenuItem";
            viewCommandToolStripMenuItem.Size = new Size(157, 22);
            viewCommandToolStripMenuItem.Text = "View command";
            viewCommandToolStripMenuItem.Click += ViewCommandToolStripMenuItem_Click;
            // 
            // textBoxConsoleOut
            // 
            textBoxConsoleOut.BorderStyle = BorderStyle.FixedSingle;
            textBoxConsoleOut.Font = new Font("Cascadia Mono", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxConsoleOut.Location = new Point(12, 307);
            textBoxConsoleOut.Margin = new Padding(4, 3, 4, 3);
            textBoxConsoleOut.Name = "textBoxConsoleOut";
            textBoxConsoleOut.ReadOnly = true;
            textBoxConsoleOut.Size = new Size(406, 20);
            textBoxConsoleOut.TabIndex = 15;
            textBoxConsoleOut.TabStop = false;
            textBoxConsoleOut.TextAlign = HorizontalAlignment.Center;
            // 
            // labelUpdateStatus
            // 
            labelUpdateStatus.AutoSize = true;
            labelUpdateStatus.ForeColor = SystemColors.GrayText;
            labelUpdateStatus.Location = new Point(8, 354);
            labelUpdateStatus.Name = "labelUpdateStatus";
            labelUpdateStatus.Size = new Size(0, 16);
            labelUpdateStatus.TabIndex = 16;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Font = new Font("Segoe Fluent Icons", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonUpdate.Location = new Point(393, 344);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Padding = new Padding(1, 1, 0, 0);
            buttonUpdate.Size = new Size(26, 26);
            buttonUpdate.TabIndex = 8;
            buttonUpdate.Text = "";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += ButtonUpdate_Click;
            // 
            // labelVideoFormat
            // 
            labelVideoFormat.AutoSize = true;
            labelVideoFormat.Location = new Point(343, 159);
            labelVideoFormat.Margin = new Padding(0);
            labelVideoFormat.Name = "labelVideoFormat";
            labelVideoFormat.Size = new Size(78, 16);
            labelVideoFormat.TabIndex = 17;
            labelVideoFormat.Text = "Video format";
            labelVideoFormat.TextAlign = ContentAlignment.TopRight;
            // 
            // labelAudioFormat
            // 
            labelAudioFormat.AutoSize = true;
            labelAudioFormat.Location = new Point(343, 159);
            labelAudioFormat.Margin = new Padding(0);
            labelAudioFormat.Name = "labelAudioFormat";
            labelAudioFormat.Size = new Size(78, 16);
            labelAudioFormat.TabIndex = 18;
            labelAudioFormat.Text = "Audio format";
            labelAudioFormat.TextAlign = ContentAlignment.TopRight;
            // 
            // dropdownVideoResolution
            // 
            dropdownVideoResolution.DropDownStyle = ComboBoxStyle.DropDownList;
            dropdownVideoResolution.FormattingEnabled = true;
            dropdownVideoResolution.Items.AddRange(new object[] { "2160p", "1440p", "1080p", "720p", "480p" });
            dropdownVideoResolution.Location = new Point(170, 178);
            dropdownVideoResolution.Name = "dropdownVideoResolution";
            dropdownVideoResolution.Size = new Size(121, 24);
            dropdownVideoResolution.TabIndex = 3;
            // 
            // labelVideoResolution
            // 
            labelVideoResolution.AutoSize = true;
            labelVideoResolution.Location = new Point(199, 159);
            labelVideoResolution.Margin = new Padding(0);
            labelVideoResolution.Name = "labelVideoResolution";
            labelVideoResolution.Size = new Size(96, 16);
            labelVideoResolution.TabIndex = 20;
            labelVideoResolution.Text = "Video resolution";
            labelVideoResolution.TextAlign = ContentAlignment.TopRight;
            // 
            // buttonAbortDownload
            // 
            buttonAbortDownload.ContextMenuStrip = contextMenuTroubleshoot;
            buttonAbortDownload.Location = new Point(11, 274);
            buttonAbortDownload.Name = "buttonAbortDownload";
            buttonAbortDownload.Size = new Size(408, 27);
            buttonAbortDownload.TabIndex = 21;
            buttonAbortDownload.Text = "Abort download";
            buttonAbortDownload.UseVisualStyleBackColor = true;
            buttonAbortDownload.Visible = false;
            buttonAbortDownload.Click += ButtonAbortDownload_Click;
            // 
            // buttonAbout
            // 
            buttonAbout.Font = new Font("Segoe Fluent Icons", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonAbout.Location = new Point(388, 12);
            buttonAbout.Name = "buttonAbout";
            buttonAbout.Padding = new Padding(5, 4, 3, 3);
            buttonAbout.Size = new Size(31, 31);
            buttonAbout.TabIndex = 9;
            buttonAbout.Text = "";
            buttonAbout.UseVisualStyleBackColor = true;
            buttonAbout.Click += ButtonAbout_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 382);
            Controls.Add(buttonAbout);
            Controls.Add(labelVideoResolution);
            Controls.Add(dropdownVideoResolution);
            Controls.Add(labelVideoFormat);
            Controls.Add(buttonUpdate);
            Controls.Add(labelUpdateStatus);
            Controls.Add(textBoxConsoleOut);
            Controls.Add(buttonBrowse);
            Controls.Add(textBoxOutputDir);
            Controls.Add(labelOutputDir);
            Controls.Add(dropdownVideoFormat);
            Controls.Add(radioButtonAudio);
            Controls.Add(radioButtonVideo);
            Controls.Add(labelDownloadType);
            Controls.Add(textBoxSourceUrl);
            Controls.Add(labelSourceUrl);
            Controls.Add(labelName);
            Controls.Add(dropdownAudioFormat);
            Controls.Add(labelAudioFormat);
            Controls.Add(buttonAbortDownload);
            Controls.Add(buttonStartDownload);
            Font = new Font("Segoe UI Variable Small", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "yt-dlp GUI";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            contextMenuTroubleshoot.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelName;
        private Label labelSourceUrl;
        private TextBox textBoxSourceUrl;
        private Label labelDownloadType;
        private RadioButton radioButtonVideo;
        private RadioButton radioButtonAudio;
        private ComboBox dropdownVideoFormat;
        private ComboBox dropdownAudioFormat;
        private Label labelOutputDir;
        private TextBox textBoxOutputDir;
        private Button buttonBrowse;
        private Button buttonStartDownload;
        private FolderBrowserDialog folderBrowserDialog;
        private TextBox textBoxConsoleOut;
        private Label labelUpdateStatus;
        private Button buttonUpdate;
        private ToolTip toolTipUpdate;
        private ToolTip toolTipVtdlpVersion;
        private Label labelVideoFormat;
        private Label labelAudioFormat;
        private ComboBox dropdownVideoResolution;
        private Label labelVideoResolution;
        private Button buttonAbortDownload;
        private Button buttonAbout;
        private ToolTip toolTipAbout;
        private ContextMenuStrip contextMenuTroubleshoot;
        private ToolStripMenuItem viewCommandToolStripMenuItem;
    }
}
