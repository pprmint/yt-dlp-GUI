using System.Diagnostics;

namespace yt_dlp_GUI
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            // Set tooltips.
            toolTipGithub.SetToolTip(linkLabelGithub, "https://github.com/pprmint/yt-dlp-GUI");
            toolTipProjectWebsite.SetToolTip(linkLabelProjectWebsite, "https://pprmint.de/yt-dlp-gui");
            toolTipWebsite.SetToolTip(pictureBoxFooter, "https://pprmint.de");
            // yt-dlp.
            toolTipYtdlpGithub.SetToolTip(linkLabelYtdlpGithub, "https://github.com/yt-dlp/yt-dlp");
            toolTipYtdlpDiscord.SetToolTip(linkLabelYtdlpDiscord, "https://discord.gg/H5MNcFW63r");
            // FFmpeg.
            toolTipFfmpegGithub.SetToolTip(linkLabelFfmpegGithub, "https://github.com/yt-dlp/FFmpeg-Builds");
            toolTipFfmpegWebsite.SetToolTip(linkLabelFfmpegWebsite, "https://ffmpeg.org");

            // yt-dlp GUI version.
            labelName.Text = string.Concat(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, " v", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);

            // Define default fonts.
            Font fontRegular = new("Segoe UI", 9);
            Font fontDisplay = new("Segoe UI", 18, FontStyle.Bold);
            Font fontSubheading = new("Segoe UI", 12, FontStyle.Bold);

            // Use Segoe UI Variable and Fluent Icons on Windows 11.
            if (Environment.OSVersion.Version.Build >= 22000)
            {
                fontRegular = new Font("Segoe UI Variable Small", 9);
                fontDisplay = new Font("Segoe UI Variable Display", 18, FontStyle.Bold);
                fontSubheading = new Font("Segoe UI Variable Display", 12, FontStyle.Bold);
            }

            // Set fonts.
            Font = fontRegular;
            labelName.Font = fontDisplay;
            labelYtdlp.Font = fontSubheading;
            labelFfmpeg.Font = fontSubheading;
        }

        private void PictureBoxFooter_Click(object sender, EventArgs e)
        {
            ProcessStartInfo websiteUrl = new()
            {
                FileName = "https://pprmint.de",
                UseShellExecute = true
            };
            Process.Start(websiteUrl);
        }

        private void LinkLabelGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo RepoGithubUrl = new()
            {
                FileName = "https://github.com/pprmint/yt-dlp-GUI",
                UseShellExecute = true
            };
            Process.Start(RepoGithubUrl);
        }

        private void LinkLabelProjectWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo websiteUrl = new()
            {
                FileName = "https://pprmint.de/yt-dlp-gui",
                UseShellExecute = true
            };
            Process.Start(websiteUrl);
        }

        private void LinkLabelYtdlpGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo RepoGithubUrl = new()
            {
                FileName = "https://github.com/yt-dlp/yt-dlp",
                UseShellExecute = true
            };
            Process.Start(RepoGithubUrl);
        }

        private void LinkLabelYtdlpDiscord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo RepoGithubUrl = new()
            {
                FileName = "https://discord.gg/H5MNcFW63r",
                UseShellExecute = true
            };
            Process.Start(RepoGithubUrl);
        }

        private void LinkLabelFfmpegGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo RepoGithubUrl = new()
            {
                FileName = "https://github.com/yt-dlp/FFmpeg-Builds",
                UseShellExecute = true
            };
            Process.Start(RepoGithubUrl);
        }

        private void LinkLabelFfmpegWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo FfmpegUrl = new()
            {
                FileName = "https://ffmpeg.org",
                UseShellExecute = true
            };
            Process.Start(FfmpegUrl);
        }

        private void About_Load(object sender, EventArgs e)
        {

        }
    }
}
