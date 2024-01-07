namespace yt_dlp_GUI
{
    partial class About
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            pictureBoxFooter = new PictureBox();
            labelName = new Label();
            labelSubtitle = new Label();
            pictureBoxLogo = new PictureBox();
            labelReliesOn = new Label();
            linkLabelGithub = new LinkLabel();
            labelYtdlp = new Label();
            labelYtdlpDescription = new Label();
            linkLabelYtdlpGithub = new LinkLabel();
            linkLabelYtdlpDiscord = new LinkLabel();
            linkLabelFfmpegWebsite = new LinkLabel();
            linkLabelFfmpegGithub = new LinkLabel();
            labelFfmpegDescription = new Label();
            labelFfmpeg = new Label();
            linkLabelProjectWebsite = new LinkLabel();
            toolTipGithub = new ToolTip(components);
            toolTipProjectWebsite = new ToolTip(components);
            toolTipYtdlpGithub = new ToolTip(components);
            toolTipYtdlpDiscord = new ToolTip(components);
            toolTipFfmpegGithub = new ToolTip(components);
            toolTipFfmpegWebsite = new ToolTip(components);
            toolTipWebsite = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)pictureBoxFooter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxFooter
            // 
            pictureBoxFooter.Cursor = Cursors.Hand;
            pictureBoxFooter.ErrorImage = null;
            pictureBoxFooter.Image = (Image)resources.GetObject("pictureBoxFooter.Image");
            pictureBoxFooter.Location = new Point(12, 313);
            pictureBoxFooter.Name = "pictureBoxFooter";
            pictureBoxFooter.Size = new Size(406, 50);
            pictureBoxFooter.TabIndex = 0;
            pictureBoxFooter.TabStop = false;
            pictureBoxFooter.Click += PictureBoxFooter_Click;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI Variable Display", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelName.Location = new Point(6, 9);
            labelName.Margin = new Padding(0, 0, 0, 9);
            labelName.Name = "labelName";
            labelName.Size = new Size(131, 32);
            labelName.TabIndex = 1;
            labelName.Text = "yt-dlp GUI";
            // 
            // labelSubtitle
            // 
            labelSubtitle.AutoSize = true;
            labelSubtitle.Location = new Point(9, 50);
            labelSubtitle.Margin = new Padding(0, 0, 0, 3);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(329, 16);
            labelSubtitle.TabIndex = 2;
            labelSubtitle.Text = "A simple program to use yt-dlp without touching a terminal.";
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = (Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new Point(358, 13);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(60, 60);
            pictureBoxLogo.TabIndex = 3;
            pictureBoxLogo.TabStop = false;
            // 
            // labelReliesOn
            // 
            labelReliesOn.AutoSize = true;
            labelReliesOn.Location = new Point(9, 104);
            labelReliesOn.Margin = new Padding(0);
            labelReliesOn.Name = "labelReliesOn";
            labelReliesOn.Size = new Size(290, 16);
            labelReliesOn.TabIndex = 5;
            labelReliesOn.Text = "This thing relies on the following third-party libraries:";
            // 
            // linkLabelGithub
            // 
            linkLabelGithub.ActiveLinkColor = SystemColors.ActiveCaption;
            linkLabelGithub.AutoSize = true;
            linkLabelGithub.LinkColor = SystemColors.HotTrack;
            linkLabelGithub.Location = new Point(9, 69);
            linkLabelGithub.Margin = new Padding(0);
            linkLabelGithub.Name = "linkLabelGithub";
            linkLabelGithub.Size = new Size(102, 16);
            linkLabelGithub.TabIndex = 6;
            linkLabelGithub.TabStop = true;
            linkLabelGithub.Text = "GitHub repository";
            linkLabelGithub.VisitedLinkColor = SystemColors.Highlight;
            linkLabelGithub.LinkClicked += LinkLabelGithub_LinkClicked;
            // 
            // labelYtdlp
            // 
            labelYtdlp.AutoSize = true;
            labelYtdlp.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelYtdlp.Location = new Point(9, 138);
            labelYtdlp.Margin = new Padding(0, 18, 0, 6);
            labelYtdlp.Name = "labelYtdlp";
            labelYtdlp.Size = new Size(55, 21);
            labelYtdlp.TabIndex = 7;
            labelYtdlp.Text = "yt-dlp";
            // 
            // labelYtdlpDescription
            // 
            labelYtdlpDescription.AutoSize = true;
            labelYtdlpDescription.Location = new Point(9, 165);
            labelYtdlpDescription.Margin = new Padding(0, 0, 0, 3);
            labelYtdlpDescription.Name = "labelYtdlpDescription";
            labelYtdlpDescription.Size = new Size(285, 16);
            labelYtdlpDescription.TabIndex = 8;
            labelYtdlpDescription.Text = "A youtube-dl fork with additional features and fixes.";
            // 
            // linkLabelYtdlpGithub
            // 
            linkLabelYtdlpGithub.ActiveLinkColor = SystemColors.ActiveCaption;
            linkLabelYtdlpGithub.AutoSize = true;
            linkLabelYtdlpGithub.LinkColor = SystemColors.HotTrack;
            linkLabelYtdlpGithub.Location = new Point(9, 184);
            linkLabelYtdlpGithub.Margin = new Padding(0, 0, 3, 0);
            linkLabelYtdlpGithub.Name = "linkLabelYtdlpGithub";
            linkLabelYtdlpGithub.Size = new Size(45, 16);
            linkLabelYtdlpGithub.TabIndex = 9;
            linkLabelYtdlpGithub.TabStop = true;
            linkLabelYtdlpGithub.Text = "Source";
            linkLabelYtdlpGithub.VisitedLinkColor = SystemColors.Highlight;
            linkLabelYtdlpGithub.LinkClicked += LinkLabelYtdlpGithub_LinkClicked;
            // 
            // linkLabelYtdlpDiscord
            // 
            linkLabelYtdlpDiscord.ActiveLinkColor = SystemColors.ActiveCaption;
            linkLabelYtdlpDiscord.AutoSize = true;
            linkLabelYtdlpDiscord.LinkColor = SystemColors.HotTrack;
            linkLabelYtdlpDiscord.Location = new Point(57, 184);
            linkLabelYtdlpDiscord.Margin = new Padding(0, 3, 0, 0);
            linkLabelYtdlpDiscord.Name = "linkLabelYtdlpDiscord";
            linkLabelYtdlpDiscord.Size = new Size(84, 16);
            linkLabelYtdlpDiscord.TabIndex = 10;
            linkLabelYtdlpDiscord.TabStop = true;
            linkLabelYtdlpDiscord.Text = "Discord server";
            linkLabelYtdlpDiscord.VisitedLinkColor = SystemColors.Highlight;
            linkLabelYtdlpDiscord.LinkClicked += LinkLabelYtdlpDiscord_LinkClicked;
            // 
            // linkLabelFfmpegWebsite
            // 
            linkLabelFfmpegWebsite.ActiveLinkColor = SystemColors.ActiveCaption;
            linkLabelFfmpegWebsite.AutoSize = true;
            linkLabelFfmpegWebsite.LinkColor = SystemColors.HotTrack;
            linkLabelFfmpegWebsite.Location = new Point(57, 264);
            linkLabelFfmpegWebsite.Margin = new Padding(0, 3, 0, 0);
            linkLabelFfmpegWebsite.Name = "linkLabelFfmpegWebsite";
            linkLabelFfmpegWebsite.Size = new Size(90, 16);
            linkLabelFfmpegWebsite.TabIndex = 14;
            linkLabelFfmpegWebsite.TabStop = true;
            linkLabelFfmpegWebsite.Text = "Project website";
            linkLabelFfmpegWebsite.VisitedLinkColor = SystemColors.Highlight;
            linkLabelFfmpegWebsite.LinkClicked += LinkLabelFfmpegWebsite_LinkClicked;
            // 
            // linkLabelFfmpegGithub
            // 
            linkLabelFfmpegGithub.ActiveLinkColor = SystemColors.ActiveCaption;
            linkLabelFfmpegGithub.AutoSize = true;
            linkLabelFfmpegGithub.LinkColor = SystemColors.HotTrack;
            linkLabelFfmpegGithub.Location = new Point(9, 264);
            linkLabelFfmpegGithub.Margin = new Padding(0, 0, 3, 0);
            linkLabelFfmpegGithub.Name = "linkLabelFfmpegGithub";
            linkLabelFfmpegGithub.Size = new Size(45, 16);
            linkLabelFfmpegGithub.TabIndex = 13;
            linkLabelFfmpegGithub.TabStop = true;
            linkLabelFfmpegGithub.Text = "Source";
            linkLabelFfmpegGithub.VisitedLinkColor = SystemColors.Highlight;
            linkLabelFfmpegGithub.LinkClicked += LinkLabelFfmpegGithub_LinkClicked;
            // 
            // labelFfmpegDescription
            // 
            labelFfmpegDescription.AutoSize = true;
            labelFfmpegDescription.Location = new Point(9, 245);
            labelFfmpegDescription.Margin = new Padding(0, 0, 0, 3);
            labelFfmpegDescription.Name = "labelFfmpegDescription";
            labelFfmpegDescription.Size = new Size(254, 16);
            labelFfmpegDescription.TabIndex = 12;
            labelFfmpegDescription.Text = "FFmpeg builds for yt-dlp with various patches.";
            // 
            // labelFfmpeg
            // 
            labelFfmpeg.AutoSize = true;
            labelFfmpeg.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelFfmpeg.Location = new Point(9, 218);
            labelFfmpeg.Margin = new Padding(0, 18, 0, 6);
            labelFfmpeg.Name = "labelFfmpeg";
            labelFfmpeg.Size = new Size(70, 21);
            labelFfmpeg.TabIndex = 11;
            labelFfmpeg.Text = "FFmpeg";
            // 
            // linkLabelProjectWebsite
            // 
            linkLabelProjectWebsite.ActiveLinkColor = SystemColors.ActiveCaption;
            linkLabelProjectWebsite.AutoSize = true;
            linkLabelProjectWebsite.LinkColor = SystemColors.HotTrack;
            linkLabelProjectWebsite.Location = new Point(111, 69);
            linkLabelProjectWebsite.Margin = new Padding(0);
            linkLabelProjectWebsite.Name = "linkLabelProjectWebsite";
            linkLabelProjectWebsite.Size = new Size(90, 16);
            linkLabelProjectWebsite.TabIndex = 15;
            linkLabelProjectWebsite.TabStop = true;
            linkLabelProjectWebsite.Text = "Project website";
            linkLabelProjectWebsite.VisitedLinkColor = SystemColors.Highlight;
            linkLabelProjectWebsite.LinkClicked += LinkLabelProjectWebsite_LinkClicked;
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 375);
            Controls.Add(linkLabelProjectWebsite);
            Controls.Add(linkLabelFfmpegWebsite);
            Controls.Add(linkLabelFfmpegGithub);
            Controls.Add(labelFfmpegDescription);
            Controls.Add(labelFfmpeg);
            Controls.Add(linkLabelYtdlpDiscord);
            Controls.Add(linkLabelYtdlpGithub);
            Controls.Add(labelYtdlpDescription);
            Controls.Add(labelYtdlp);
            Controls.Add(linkLabelGithub);
            Controls.Add(labelReliesOn);
            Controls.Add(pictureBoxLogo);
            Controls.Add(labelSubtitle);
            Controls.Add(labelName);
            Controls.Add(pictureBoxFooter);
            Font = new Font("Segoe UI Variable Small", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "About";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "About";
            Load += About_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxFooter).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxFooter;
        private Label labelName;
        private Label labelSubtitle;
        private PictureBox pictureBoxLogo;
        private Label labelReliesOn;
        private LinkLabel linkLabelGithub;
        private Label labelYtdlp;
        private Label labelYtdlpDescription;
        private LinkLabel linkLabelYtdlpGithub;
        private LinkLabel linkLabelYtdlpDiscord;
        private LinkLabel linkLabelFfmpegWebsite;
        private LinkLabel linkLabelFfmpegGithub;
        private Label labelFfmpegDescription;
        private Label labelFfmpeg;
        private LinkLabel linkLabelProjectWebsite;
        private ToolTip toolTipGithub;
        private ToolTip toolTipProjectWebsite;
        private ToolTip toolTipYtdlpGithub;
        private ToolTip toolTipYtdlpDiscord;
        private ToolTip toolTipFfmpegGithub;
        private ToolTip toolTipFfmpegWebsite;
        private ToolTip toolTipWebsite;
    }
}