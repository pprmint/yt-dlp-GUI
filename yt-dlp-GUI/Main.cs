using System.Diagnostics;

namespace yt_dlp_GUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            // Define default fonts.
            Font fontRegular = new Font("Segoe UI", 9);
            Font fontDisplay = new Font("Segoe UI", 18, FontStyle.Bold);
            Font fontIconSmall = new Font("Segoe MDL2 Assets", 9);
            Font fontIconBig = new Font("Segoe MDL2 Assets", 12);

            // Use Segoe UI Variable and Fluent Icons on Windows 11.
            if (Environment.OSVersion.Version.Build >= 22000)
            {
                fontRegular = new Font("Segoe UI Variable", 9);
                fontDisplay = new Font("Segoe UI Variable Display", 18, FontStyle.Bold);
                fontIconSmall = new Font("Segoe Fluent Icons", 9);
                fontIconBig = new Font("Segoe Fluent Icons", 12);
            }

            // Set fonts.
            Font = fontRegular;
            labelName.Font = fontDisplay;
            buttonUpdate.Font = fontIconSmall;
            buttonAbout.Font = fontIconBig;

            // Set tooltips.
            toolTipVtdlpVersion.SetToolTip(labelUpdateStatus, "Installed yt-dlp version.");
            toolTipUpdate.SetToolTip(buttonUpdate, "Check for updates and install them if available.");

            // Set default values.
            dropdownVideoFormat.SelectedIndex = 0;
            dropdownVideoResolution.SelectedIndex = 2;
            dropdownAudioFormat.SelectedIndex = 0;
            radioButtonVideo.Checked = true;
            // Update the UI.
            ValidateFormatState();

            // Check yt-dlp version.
            GetVersion();

            // Handle updating of form fields.
            textBoxSourceUrl.TextChanged += UpdateDownloadButtonState;
            radioButtonAudio.CheckedChanged += UpdateFormatState;
            radioButtonVideo.CheckedChanged += UpdateFormatState;
            textBoxOutputDir.TextChanged += UpdateDownloadButtonState;
        }

        // Current directory of where the GUI program is running.
        private readonly string execPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);

        // yt-dlp --version
        private void GetVersion()
        {
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
            };
        }
        // yt-dlp -U
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

            updateThread = new Thread(() =>
            {
                try
                {
                    updateProcess = new Process { StartInfo = updateStartInfo };
                    updateProcess.Start();

                    using (StreamReader reader = updateProcess.StandardOutput)
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            labelUpdateStatus.Invoke((Action)(() => labelUpdateStatus.Text = line.Truncate(59)));
                            Application.DoEvents();
                        }
                    }

                    updateProcess.WaitForExit();
                }
                finally
                {
                    Invoke(() =>
                    {
                        if (updateProcess != null && !updateProcess.HasExited)
                        {
                            updateProcess.Kill();
                        }

                        // Enable controls again.
                        buttonStartDownload.Enabled = true;
                        buttonUpdate.Enabled = true;

                        Cursor = Cursors.Default;
                    });
                }
            });

            // Disable controls.
            buttonStartDownload.Enabled = false;
            buttonUpdate.Enabled = false;

            Cursor = Cursors.WaitCursor;

            updateThread.Start();
        }
        // Run yt-dlp updater
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            InstallUpdates();
        }

        // Check whether form field entries are valid and enable Start download button if so.
        private void ValidateDownloadButtonState()
        {
            bool fieldsFilled =
                !string.IsNullOrEmpty(textBoxSourceUrl.Text)
                && (radioButtonAudio.Checked || radioButtonVideo.Checked)
                && !string.IsNullOrEmpty(textBoxOutputDir.Text);

            buttonStartDownload.Enabled = fieldsFilled;
        }
        // Manually force checking of form validity.
        private void UpdateDownloadButtonState(object? sender, EventArgs e)
        {
            ValidateDownloadButtonState();
        }

        // Toggle visibilty of format dropdowns depending on whether to download video or audio.
        private void ValidateFormatState()
        {
            if (radioButtonVideo.Checked)
            {
                labelVideoResolution.Visible = true;
                dropdownVideoResolution.Visible = true;
                labelVideoFormat.Visible = true;
                dropdownVideoFormat.Visible = true;
                labelAudioFormat.Visible = false;
                dropdownAudioFormat.Visible = false;
            }
            else if (radioButtonAudio.Checked)
            {
                labelVideoResolution.Visible = false;
                dropdownVideoResolution.Visible = false;
                labelVideoFormat.Visible = false;
                dropdownVideoFormat.Visible = false;
                labelAudioFormat.Visible = true;
                dropdownAudioFormat.Visible = true;
            }
        }
        // Manually force checking of format selection.
        private void UpdateFormatState(object? sender, EventArgs e)
        {
            ValidateFormatState();
        }

        // Set directory where files should be downloaded to.
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
            string videoFormat = dropdownVideoFormat.Text;
            string videoResolution = dropdownVideoResolution.Text.TrimEnd('p');
            string audioFormat = dropdownAudioFormat.Text;

            Application.DoEvents();

            ProcessStartInfo updateStartInfo = new()
            {
                // Rember to put the .exe in a subdirectory to the exec path.
                FileName = "C:\\ProgramData\\chocolatey\\bin\\yt-dlp.exe",
                Arguments = radioButtonVideo.Checked
                    ? string.Concat(sourceUrl, " -P ", outputDir, " -f bv*[ext=", videoFormat, "][height<=", videoResolution, "]+ba/b[ext=", videoFormat, "][height<=", videoResolution, "] / bv*+ba/b")
                    : string.Concat(sourceUrl, " -P ", outputDir, " -x --audio-format ", audioFormat, " --ffmpeg-location C:\\ProgramData\\chocolatey\\bin\\ffmpeg.exe"),
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            downloadThread = new Thread(() =>
            {
                try
                {
                    downloadProcess = new Process { StartInfo = updateStartInfo };
                    downloadProcess.Start();

                    using (StreamReader reader = downloadProcess.StandardOutput)
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            textBoxConsoleOut.Invoke((Action)(() => textBoxConsoleOut.Text = line));
                            Application.DoEvents();

                            if (CancelDownloadRequested)
                            {
                                break;
                            }
                        }
                    }

                    downloadProcess.WaitForExit();
                }
                finally
                {
                    Invoke(() =>
                    {
                        if (downloadProcess != null && !downloadProcess.HasExited)
                        {
                            downloadProcess.Kill();
                        }

                        // Enable controls and hide cancel button.
                        textBoxConsoleOut.Text = CancelDownloadRequested ? "Download canceled." : "Download completed.";
                        CancelDownloadRequested = false;

                        textBoxSourceUrl.Enabled = true;
                        radioButtonVideo.Enabled = true;
                        radioButtonAudio.Enabled = true;
                        dropdownVideoFormat.Enabled = true;
                        dropdownVideoResolution.Enabled = true;
                        dropdownAudioFormat.Enabled = true;
                        buttonBrowse.Enabled = true;
                        buttonStartDownload.Visible = true;
                        buttonCancelDownload.Visible = false;
                        buttonUpdate.Enabled = true;
                    });
                }
            });

            // Disable controls and show cancel button.
            textBoxSourceUrl.Enabled = false;
            radioButtonVideo.Enabled = false;
            radioButtonAudio.Enabled = false;
            dropdownVideoFormat.Enabled = false;
            dropdownVideoResolution.Enabled = false;
            dropdownAudioFormat.Enabled = false;
            buttonBrowse.Enabled = false;
            buttonStartDownload.Visible = false;
            buttonCancelDownload.Visible = true;
            buttonCancelDownload.Enabled = true;
            buttonUpdate.Enabled = false;

            textBoxConsoleOut.Text = null;

            downloadThread.Start();
        }

        private bool CancelDownloadRequested = false;

        private void ButtonCancelDownload_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel the download? You may need to clean up partially downloaded files.", "Cancel download", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Set the flag to request cancellation.
                CancelDownloadRequested = true;

                // Disable Cancel download button.
                buttonCancelDownload.Enabled = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if update is in progress.
            if (updateThread != null && updateThread.IsAlive)
            {
                // Inform about pending downloads.
                DialogResult = MessageBox.Show("Updates are checked for or being downloaded. Please wait a moment.", "Checking for updates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }

            // Check if downloads are in progress.
            if (downloadThread != null && downloadThread.IsAlive)
            {
                // Inform about pending downloads.
                DialogResult = MessageBox.Show("Download is still in progress. Please cancel it before closing the application.", "Download in progress", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }

        private Thread updateThread;
        private Process updateProcess;
        private Thread downloadThread;
        private Process downloadProcess;

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            About aboutWindow = new();
            aboutWindow.Show();
        }
    }

    // Thingy to truncate texts.
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

