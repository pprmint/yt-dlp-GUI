using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yt_dlp_GUI
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            // Define default fonts.
            Font fontRegular = new Font("Segoe UI", 9);
            Font fontDisplay = new Font("Segoe UI", 18, FontStyle.Bold);
            Font fontSubheading = new Font("Segoe UI", 18, FontStyle.Bold);

            // Use Segoe UI Variable and Fluent Icons on Windows 11.
            if (Environment.OSVersion.Version.Build >= 22000)
            {
                fontRegular = new Font("Segoe UI Variable", 9);
                fontDisplay = new Font("Segoe UI Variable Display", 18, FontStyle.Bold);
                fontSubheading = new Font("Segoe UI Variable Display", 12, FontStyle.Bold);
            }

            // Set fonts.
            Font = fontRegular;
            labelName.Font = fontDisplay;
        }

        private void PictureBoxFooter_Click(object sender, EventArgs e)
        {
            ProcessStartInfo websiteUrl = new()
            {
                FileName = "https://pprmint.art",
                UseShellExecute = true
            };
            Process.Start(websiteUrl);
        }

        private void linkLabelGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo RepoGithubUrl = new()
            {
                FileName = "https://github.com/pprmint/yt-dlp-GUI",
                UseShellExecute = true
            };
            Process.Start(RepoGithubUrl);
        }

        private void About_Load(object sender, EventArgs e)
        {

        }

        private void linkLabelFfmpegGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo RepoGithubUrl = new()
            {
                FileName = "https://github.com/GyanD/codexffmpeg",
                UseShellExecute = true
            };
            Process.Start(RepoGithubUrl);
        }

        private void linkLabelFfmpegWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo FfmpegUrl = new()
            {
                FileName = "https://ffmpeg.org",
                UseShellExecute = true
            };
            Process.Start(FfmpegUrl);
        }
    }
}
