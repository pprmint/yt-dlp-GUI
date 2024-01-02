namespace yt_dlp_GUI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            labelName = new Label();
            linkLabelShamelessPlug = new LinkLabel();
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
            folderBrowserDialog = new FolderBrowserDialog();
            textBoxConsoleOut = new TextBox();
            labelUpdateStatus = new Label();
            linkLabelYtdlpSource = new LinkLabel();
            buttonUpdate = new Button();
            toolTipYtdlp = new ToolTip(components);
            toolTipShamelessPlug = new ToolTip(components);
            toolTipUpdate = new ToolTip(components);
            toolTipVtdlpVersion = new ToolTip(components);
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI Variable Display", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelName.Location = new Point(8, 9);
            labelName.Margin = new Padding(0);
            labelName.Name = "labelName";
            labelName.Size = new Size(223, 32);
            labelName.TabIndex = 0;
            labelName.Text = "Video Downloader";
            // 
            // linkLabelShamelessPlug
            // 
            linkLabelShamelessPlug.ActiveLinkColor = SystemColors.Highlight;
            linkLabelShamelessPlug.AutoSize = true;
            linkLabelShamelessPlug.LinkColor = SystemColors.ActiveCaption;
            linkLabelShamelessPlug.Location = new Point(353, 25);
            linkLabelShamelessPlug.Margin = new Padding(0);
            linkLabelShamelessPlug.Name = "linkLabelShamelessPlug";
            linkLabelShamelessPlug.Size = new Size(67, 16);
            linkLabelShamelessPlug.TabIndex = 10;
            linkLabelShamelessPlug.TabStop = true;
            linkLabelShamelessPlug.Text = "pprmint.art";
            linkLabelShamelessPlug.VisitedLinkColor = SystemColors.ActiveCaption;
            linkLabelShamelessPlug.LinkClicked += LinkLabelShamelessPlug_LinkClicked;
            // 
            // labelSourceUrl
            // 
            labelSourceUrl.AutoSize = true;
            labelSourceUrl.Location = new Point(8, 57);
            labelSourceUrl.Margin = new Padding(0);
            labelSourceUrl.Name = "labelSourceUrl";
            labelSourceUrl.Size = new Size(69, 16);
            labelSourceUrl.TabIndex = 4;
            labelSourceUrl.Text = "Source URL";
            // 
            // textBoxSourceUrl
            // 
            textBoxSourceUrl.Location = new Point(12, 76);
            textBoxSourceUrl.Name = "textBoxSourceUrl";
            textBoxSourceUrl.Size = new Size(406, 23);
            textBoxSourceUrl.TabIndex = 0;
            textBoxSourceUrl.Tag = "sourceUrl";
            // 
            // labelDownloadType
            // 
            labelDownloadType.AutoSize = true;
            labelDownloadType.Location = new Point(8, 118);
            labelDownloadType.Margin = new Padding(0);
            labelDownloadType.Name = "labelDownloadType";
            labelDownloadType.Size = new Size(89, 16);
            labelDownloadType.TabIndex = 6;
            labelDownloadType.Text = "Download type";
            labelDownloadType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // radioButtonVideo
            // 
            radioButtonVideo.AutoSize = true;
            radioButtonVideo.Location = new Point(11, 137);
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
            radioButtonAudio.Location = new Point(74, 137);
            radioButtonAudio.Name = "radioButtonAudio";
            radioButtonAudio.Size = new Size(83, 20);
            radioButtonAudio.TabIndex = 2;
            radioButtonAudio.TabStop = true;
            radioButtonAudio.Text = "Audio only";
            radioButtonAudio.UseVisualStyleBackColor = true;
            // 
            // dropdownVideoFormat
            // 
            dropdownVideoFormat.FormattingEnabled = true;
            dropdownVideoFormat.Items.AddRange(new object[] { "mp4", "gif", "mkv", "webm", "mov", "avi", "flv" });
            dropdownVideoFormat.Location = new Point(170, 137);
            dropdownVideoFormat.Name = "dropdownVideoFormat";
            dropdownVideoFormat.Size = new Size(121, 24);
            dropdownVideoFormat.TabIndex = 3;
            dropdownVideoFormat.Tag = "videoFormat";
            dropdownVideoFormat.Text = "Video format";
            // 
            // dropdownAudioFormat
            // 
            dropdownAudioFormat.FormattingEnabled = true;
            dropdownAudioFormat.Items.AddRange(new object[] { "mp3", "wav", "flac", "aac", "alac", "m4a", "opus", "vorbis" });
            dropdownAudioFormat.Location = new Point(297, 137);
            dropdownAudioFormat.Name = "dropdownAudioFormat";
            dropdownAudioFormat.Size = new Size(121, 24);
            dropdownAudioFormat.TabIndex = 4;
            dropdownAudioFormat.Tag = "audioFormat";
            dropdownAudioFormat.Text = "Audio format";
            // 
            // labelOutputDir
            // 
            labelOutputDir.AutoSize = true;
            labelOutputDir.Location = new Point(8, 179);
            labelOutputDir.Margin = new Padding(0);
            labelOutputDir.Name = "labelOutputDir";
            labelOutputDir.Size = new Size(96, 16);
            labelOutputDir.TabIndex = 11;
            labelOutputDir.Tag = "outputDir";
            labelOutputDir.Text = "Output directory";
            // 
            // textBoxOutputDir
            // 
            textBoxOutputDir.Location = new Point(12, 198);
            textBoxOutputDir.Name = "textBoxOutputDir";
            textBoxOutputDir.Size = new Size(279, 23);
            textBoxOutputDir.TabIndex = 5;
            textBoxOutputDir.Tag = "outputDir";
            // 
            // buttonBrowse
            // 
            buttonBrowse.Location = new Point(297, 196);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(121, 26);
            buttonBrowse.TabIndex = 6;
            buttonBrowse.Text = "Browse...";
            buttonBrowse.UseVisualStyleBackColor = true;
            buttonBrowse.Click += ButtonBrowse_Click;
            // 
            // buttonStartDownload
            // 
            buttonStartDownload.Enabled = false;
            buttonStartDownload.Location = new Point(12, 242);
            buttonStartDownload.Name = "buttonStartDownload";
            buttonStartDownload.Size = new Size(121, 26);
            buttonStartDownload.TabIndex = 7;
            buttonStartDownload.Text = "Start download";
            buttonStartDownload.UseVisualStyleBackColor = true;
            buttonStartDownload.Click += ButtonStartDownload_Click;
            // 
            // textBoxConsoleOut
            // 
            textBoxConsoleOut.BorderStyle = BorderStyle.FixedSingle;
            textBoxConsoleOut.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxConsoleOut.Location = new Point(139, 245);
            textBoxConsoleOut.Name = "textBoxConsoleOut";
            textBoxConsoleOut.ReadOnly = true;
            textBoxConsoleOut.Size = new Size(279, 21);
            textBoxConsoleOut.TabIndex = 15;
            textBoxConsoleOut.TabStop = false;
            // 
            // labelUpdateStatus
            // 
            labelUpdateStatus.AutoSize = true;
            labelUpdateStatus.ForeColor = SystemColors.GrayText;
            labelUpdateStatus.Location = new Point(8, 295);
            labelUpdateStatus.Name = "labelUpdateStatus";
            labelUpdateStatus.Size = new Size(36, 16);
            labelUpdateStatus.TabIndex = 16;
            labelUpdateStatus.Text = "penis";
            // 
            // linkLabelYtdlpSource
            // 
            linkLabelYtdlpSource.ActiveLinkColor = SystemColors.Highlight;
            linkLabelYtdlpSource.AutoSize = true;
            linkLabelYtdlpSource.LinkColor = SystemColors.ActiveCaption;
            linkLabelYtdlpSource.Location = new Point(381, 9);
            linkLabelYtdlpSource.Margin = new Padding(0);
            linkLabelYtdlpSource.Name = "linkLabelYtdlpSource";
            linkLabelYtdlpSource.Size = new Size(39, 16);
            linkLabelYtdlpSource.TabIndex = 9;
            linkLabelYtdlpSource.TabStop = true;
            linkLabelYtdlpSource.Text = "yt-dlp";
            linkLabelYtdlpSource.VisitedLinkColor = SystemColors.ActiveCaption;
            linkLabelYtdlpSource.LinkClicked += LinkLabelYtdlpSource_LinkClicked;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Font = new Font("Segoe Fluent Icons", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonUpdate.Location = new Point(393, 286);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(25, 25);
            buttonUpdate.TabIndex = 8;
            buttonUpdate.Text = "";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += ButtonUpdate_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 323);
            Controls.Add(buttonUpdate);
            Controls.Add(linkLabelYtdlpSource);
            Controls.Add(labelUpdateStatus);
            Controls.Add(textBoxConsoleOut);
            Controls.Add(buttonStartDownload);
            Controls.Add(buttonBrowse);
            Controls.Add(textBoxOutputDir);
            Controls.Add(labelOutputDir);
            Controls.Add(dropdownAudioFormat);
            Controls.Add(dropdownVideoFormat);
            Controls.Add(radioButtonAudio);
            Controls.Add(radioButtonVideo);
            Controls.Add(labelDownloadType);
            Controls.Add(textBoxSourceUrl);
            Controls.Add(labelSourceUrl);
            Controls.Add(linkLabelShamelessPlug);
            Controls.Add(labelName);
            Font = new Font("Segoe UI Variable Small", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "Video Downloader";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelName;
        private LinkLabel linkLabelShamelessPlug;
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
        private LinkLabel linkLabelYtdlpSource;
        private Button buttonUpdate;
        private ToolTip toolTipYtdlp;
        private ToolTip toolTipShamelessPlug;
        private ToolTip toolTipUpdate;
        private ToolTip toolTipVtdlpVersion;
    }
}
