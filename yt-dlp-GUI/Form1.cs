using System.Diagnostics;

namespace yt_dlp_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Set tooltips.
            toolTipYtdlp.SetToolTip(linkLabelYtdlpSource, "Visit the yt-dlp repository on GitHub.");
            toolTipShamelessPlug.SetToolTip(linkLabelShamelessPlug, "Visit my website.");
            toolTipVtdlpVersion.SetToolTip(labelUpdateStatus, "Installed yt-dlp version.");
            toolTipUpdate.SetToolTip(buttonUpdate, "Check for updates and install them if available.");

            // Check yt-dlp version.
            GetVersion();

            // Handle updating of form fields.
            textBoxSourceUrl.TextChanged += UpdateDownloadButtonState;
            radioButtonAudio.CheckedChanged += UpdateDownloadButtonState;
            radioButtonVideo.CheckedChanged += UpdateDownloadButtonState;
            dropdownAudioFormat.SelectedIndexChanged += UpdateDownloadButtonState;
            textBoxOutputDir.TextChanged += UpdateDownloadButtonState;
        }

        // Current directory of where the GUI program is running.
        private readonly string execPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);

        // Set to true whenever yt-dlp is running.
        private bool YtDlpRunning = false;

        private void GetVersion()
        {
            YtDlpRunning = true;
            ProcessStartInfo versionStartInfo = new()
            {
                // Rember to put the .exe in a subdirectory to the exec path.
                FileName = "C:\\ProgramData\\chocolatey\\bin\\yt-dlp.exe",
                Arguments = "--version",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            using var updateProcess = new Process { StartInfo = versionStartInfo };
            {
                updateProcess.Start();
                // Write console output to label in the bottom left corner.
                using (StreamReader reader = updateProcess.StandardOutput)
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        labelUpdateStatus.Text = "yt-dlp " + line;
                    }
                }
                updateProcess.WaitForExit();
                YtDlpRunning = false;
            };
        }

        private void InstallUpdates()
        {
            labelUpdateStatus.Text = "Checking for updates...";
            Application.DoEvents();

            ProcessStartInfo updateStartInfo = new()
            {
                // Rember to put the .exe in a subdirectory to the exec path.
                FileName = "C:\\ProgramData\\chocolatey\\bin\\yt-dlp.exe",
                Arguments = "-U",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            try
            {
                using var updateProcess = new Process { StartInfo = updateStartInfo };
                {
                    updateProcess.Start();
                    Cursor = Cursors.WaitCursor;
                    buttonUpdate.Enabled = false;
                    buttonStartDownload.Enabled = false;
                    YtDlpRunning = true;

                    // Write console output to label in the bottom left corner.
                    using (StreamReader reader = updateProcess.StandardOutput)
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            labelUpdateStatus.Text = line.Truncate(59);
                            Application.DoEvents();
                        }
                    }
                    updateProcess.WaitForExit();
                }
            }
            finally
            {
                YtDlpRunning = false;
                ValidateDownloadButtonState();
                Cursor = Cursors.Default;
                buttonUpdate.Enabled = true;
                Application.DoEvents();
            }
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            InstallUpdates();
        }

        private void ValidateDownloadButtonState()
        {
            bool fieldsFilled =
                !string.IsNullOrEmpty(textBoxSourceUrl.Text)
                && (radioButtonAudio.Checked || radioButtonVideo.Checked)
                && dropdownVideoFormat.SelectedIndex != -1
                && dropdownAudioFormat.SelectedIndex != -1
                && !string.IsNullOrEmpty(textBoxOutputDir.Text);

            buttonStartDownload.Enabled = fieldsFilled && !YtDlpRunning;
        }

        private void UpdateDownloadButtonState(object? sender, EventArgs e)
        {
            ValidateDownloadButtonState();
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
    }

    public static class StringExt
    {
        public static string? Truncate(this string? value, int maxLength, string truncationSuffix = "...")
        {
            return value?.Length > maxLength
                ? string.Concat(value.AsSpan(0, maxLength), truncationSuffix)
                : value;
        }
    }
}

