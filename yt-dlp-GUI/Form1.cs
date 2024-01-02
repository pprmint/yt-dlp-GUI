using System.Diagnostics;
using static System.Windows.Forms.LinkLabel;

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

        // Set to true whenever yt-dlp is running.
        private bool YtDlpRunning = false;

        // yt-dlp --version
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

            buttonStartDownload.Enabled = fieldsFilled && !YtDlpRunning;
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
            } else if (radioButtonAudio.Checked)
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

            try
            {
                using var updateProcess = new Process { StartInfo = updateStartInfo };
                {
                    updateProcess.Start();
                    Cursor = Cursors.WaitCursor;
                    buttonUpdate.Enabled = false;
                    buttonStartDownload.Enabled = false;
                    YtDlpRunning = true;

                    // Write console output to text field next to download button.
                    using (StreamReader reader = updateProcess.StandardOutput)
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            textBoxConsoleOut.Text = line;
                            Application.DoEvents();
                        }
                    }
                    updateProcess.WaitForExit();
                }
            }
            finally
            {
                YtDlpRunning = false;
                textBoxConsoleOut.Text = "Download complete.";
                ValidateDownloadButtonState();
                Cursor = Cursors.Default;
                buttonUpdate.Enabled = true;
                Application.DoEvents();
            }
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

        private void Form1_Load(object sender, EventArgs e)
        {

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

