using System.Diagnostics;

namespace yt_dlp_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Set tooltips.
            toolTipYtdlp.SetToolTip(linkLabelYtdlpSource, "Visit yt-dlp repository on GitHub.");
            toolTipShamelessPlug.SetToolTip(linkLabelShamelessPlug, "Visit my website.");
            toolTipUpdate.SetToolTip(buttonUpdate, "Check for updates.");

            // Check for updates on startup.
            CheckUpdates();

            // Current directory of where the program is running.
            string execPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);

            // Disable Download button until every field has been filled out.
            buttonStartDownload.Enabled = false;

            // Handle updating of form fields.
            textBoxSourceUrl.TextChanged += UpdateDownloadButtonState;
            radioButtonAudio.CheckedChanged += UpdateDownloadButtonState;
            radioButtonVideo.CheckedChanged += UpdateDownloadButtonState;
            dropdownAudioFormat.SelectedIndexChanged += UpdateDownloadButtonState;
            textBoxOutputDir.TextChanged += UpdateDownloadButtonState;
        }

        private void CheckUpdates()
        {
            ProcessStartInfo updateStartInfo = new()
            {
                // Rember to put the .exe in a subdirectory to the exec path.
                FileName = "C:\\ProgramData\\chocolatey\\bin\\yt-dlp.exe",
                Arguments = "-U",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            using var updateProcess = new Process { StartInfo = updateStartInfo };
            {
                buttonUpdate.Enabled = false;
                buttonUpdate.Cursor = Cursors.WaitCursor;
                updateProcess.Start();
                // Write console output to label in the bottom left corner.
                using (StreamReader reader = updateProcess.StandardOutput)
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        labelUpdateStatus.Text = line;
                    }
                }
                updateProcess.WaitForExit();
                buttonUpdate.Enabled = true;
                buttonUpdate.Cursor = Cursors.Default;
            };
        }

        private void UpdateDownloadButtonState(object? sender, EventArgs e)
        {
            buttonStartDownload.Enabled =
                !string.IsNullOrEmpty(textBoxSourceUrl.Text)
                && (radioButtonAudio.Checked || radioButtonVideo.Checked)
                && dropdownVideoFormat.SelectedIndex != -1
                && dropdownAudioFormat.SelectedIndex != -1
                && !string.IsNullOrEmpty(textBoxOutputDir.Text);
        }

        private void ChooseOutputDir()
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxOutputDir.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            ChooseOutputDir();
        }

        private void ButtonStartDownload_Click(object sender, EventArgs e)
        {
            string sourceUrl = textBoxSourceUrl.Text;
            string outputDir = textBoxOutputDir.Text;
            string videoFormat = dropdownVideoFormat.SelectedText;
            string audioFormat = dropdownAudioFormat.SelectedText;
        }

        private void LinkLabelYtdlpSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo githubUrl = new()
            {
                FileName = "https://github.com/yt-dlp/yt-dlp",
                UseShellExecute = true
            };
            Process.Start(githubUrl);
        }

        private void LinkLabelShamelessPlug_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo websiteUrl = new()
            {
                FileName = "https://pprmint.art",
                UseShellExecute = true
            };
            Process.Start(websiteUrl);
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            CheckUpdates();
        }
    }
}

