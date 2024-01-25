using Microsoft.Win32;
using System.Diagnostics;
using System.Media;

namespace yt_dlp_GUI
{
    public partial class Main : Form
    {
        // Required files and paths to run this.
        public readonly string utilsFolder = Path.Combine(Directory.GetCurrentDirectory(), "utils");
        public readonly string tempFolder = Path.Combine(Directory.GetCurrentDirectory(), "temp");
        public readonly string ytdlpExe = Path.Combine(Directory.GetCurrentDirectory(), "utils", "yt-dlp.exe");
        public readonly string ffmpegExe = Path.Combine(Directory.GetCurrentDirectory(), "utils", "ffmpeg.exe");
        public readonly string ffprobeExe = Path.Combine(Directory.GetCurrentDirectory(), "utils", "ffprobe.exe");

        public static string ytdlpCommand = "";

        // Update and download threads.
        private Thread? versionThread;
        private Process? versionProcess;
        private Thread? updateThread;
        private Process? updateProcess;
        private Thread? downloadThread;
        private Process? downloadProcess;

        // ::::::::::::::::::::::::: START
        // Functions for changing top text
        private void SetGreeting()
        {
            string[] Greetings = ["Welcome.", "Hiya.", "Good today.", "Hello there.", "Moin.", "Hola.", "Greetings.", "Let's download stuff."];
            Random randomInt = new();
            labelName.Text = Greetings[randomInt.Next(Greetings.Length)];
        }

        private void SetActivity(string text)
        {
            labelName.Text = string.Concat(text);
        }
        // ::::::::::::::::::::::::::: END

        // Play Windows notification sound, because System.Media.SystemSounds is really limited.
        public static void PlayNotificationSound()
        {
            try
            {
                using RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"AppEvents\Schemes\Apps\.Default\Notification.IM\.Current");
                if (key != null)
                {
                    string? soundPath = key.GetValue(null) as string;
                    if (!string.IsNullOrEmpty(soundPath))
                    {
                        new SoundPlayer(soundPath).Play();
                        return;
                    }
                }
            }
            catch
            { SystemSounds.Beep.Play(); }
        }

        public Main()
        {
            // Check for existence of utils folder and yt-dlp + FFmpeg inside it.
            if (!Directory.Exists(utilsFolder))
            {
                MessageBox.Show(string.Concat("The following directory was not found:\n\n", Path.Combine(System.IO.Directory.GetCurrentDirectory(), "utils"), "\n\nTry reinstalling the program."), "Error: utils not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            if (!File.Exists(ytdlpExe))
            {
                MessageBox.Show(string.Concat("The yt-dlp.exe was not found in the following directory:\n\n", Path.Combine(System.IO.Directory.GetCurrentDirectory(), "utils"), "\n\nReinstall the program or download the file manually from:\n\nhttps://github.com/yt-dlp/yt-dlp#installation"), "Error: yt-dlp.exe not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(2);
            }
            if (!File.Exists(ffmpegExe))
            {
                MessageBox.Show(string.Concat("The ffmpeg.exe was not found in the following directory:\n\n", Path.Combine(System.IO.Directory.GetCurrentDirectory(), "utils"), "\n\nReinstall the program or download the essentials package from:\n\nhttps://www.gyan.dev/ffmpeg/builds/\n\nYou can find ffmpeg.exe in the 'bin' folder."), "Error: ffmpeg.exe not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(3);
            }
            if (!File.Exists(ffprobeExe))
            {
                MessageBox.Show(string.Concat("The ffprobe.exe was not found in the following directory:\n\n", Path.Combine(System.IO.Directory.GetCurrentDirectory(), "utils"), "\n\nReinstall the program or download the essentials package from:\n\nhttps://www.gyan.dev/ffmpeg/builds/\n\nYou can find ffprobe.exe in the 'bin' folder."), "Error: ffprobe.exe not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(4);
            }

            InitializeComponent();

            SetGreeting();

            Text = string.Concat("yt-dlp GUI TEST v", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);

            // Define default fonts.
            Font fontRegular = new("Segoe UI", 8);
            Font fontDisplay = new("Segoe UI", 18, FontStyle.Bold);
            Font fontIconSmall = new("Segoe MDL2 Assets", 8);
            Font fontIconBig = new("Segoe MDL2 Assets", 12);

            // Use Segoe UI Variable and Fluent Icons on Windows 11.
            if (Environment.OSVersion.Version.Build >= 22000)
            {
                fontRegular = new("Segoe UI Variable Small", 9);
                fontDisplay = new("Segoe UI Variable Display", 18, FontStyle.Bold);
                fontIconSmall = new("Segoe Fluent Icons", 9);
                fontIconBig = new("Segoe Fluent Icons", 12);
            }

            // Set fonts.
            Font = fontRegular;
            labelName.Font = fontDisplay;
            buttonUpdate.Font = fontIconSmall;
            buttonAbout.Font = fontIconBig;

            // Set tooltips.
            toolTipVtdlpVersion.SetToolTip(labelUpdateStatus, "Installed yt-dlp version.");
            toolTipUpdate.SetToolTip(buttonUpdate, "Check for updates and install them if available.");
            toolTipAbout.SetToolTip(buttonAbout, "View version information and credits to libraries.");

            // :::::::::::::::::::::::::::::: START
            // Form field values from user settings
            // Download type (video or audio).
            if (UserSettings.Default.DownloadType == "audio")
            {
                radioButtonAudio.Checked = true;
            }
            else
            {
                radioButtonVideo.Checked = true;
            }
            // Video format.
            if (UserSettings.Default.VideoFormatIndex < dropdownVideoFormat.Items.Count && UserSettings.Default.VideoFormatIndex >= 0)
            {
                dropdownVideoFormat.SelectedIndex = UserSettings.Default.VideoFormatIndex;
            }
            else
            {
                dropdownVideoFormat.SelectedIndex = 0; // mp4
            };
            // Video resolution.
            if (UserSettings.Default.VideoResolutionIndex < dropdownVideoResolution.Items.Count && UserSettings.Default.VideoResolutionIndex >= 0)
            {
                dropdownVideoResolution.SelectedIndex = UserSettings.Default.VideoResolutionIndex;
            }
            else
            {
                dropdownVideoResolution.SelectedIndex = 2; // 1080p
            };
            // Audio format.
            if (UserSettings.Default.AudioFormatIndex < dropdownAudioFormat.Items.Count && UserSettings.Default.AudioFormatIndex >= 0)
            {
                dropdownAudioFormat.SelectedIndex = UserSettings.Default.AudioFormatIndex;
            }
            else
            {
                dropdownAudioFormat.SelectedIndex = 0; // mp3
            };

            textBoxOutputDir.Text = UserSettings.Default.OutputDir;
            // :::::::::::::::::::::::::::::::: END

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

        // ::::::::::::::: START
        // Get version + Updater
        // yt-dlp --version
        private void GetVersion()
        {
            ProcessStartInfo versionStartInfo = new()
            {
                FileName = ytdlpExe,
                Arguments = "--version",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            versionThread = new Thread(() =>
            {
                try
                {
                    versionProcess = new Process { StartInfo = versionStartInfo };
                    versionProcess.Start();

                    // Write console output to label in the bottom left corner.
                    using (StreamReader reader = versionProcess.StandardOutput)
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            labelUpdateStatus.Invoke((Action)(() => labelUpdateStatus.Text = "yt-dlp " + line));
                        }
                    }

                    versionProcess.WaitForExit();
                }
                finally { }
            });

            versionThread.Start();
        }
        // yt-dlp -U
        private void InstallUpdates()
        {
            labelUpdateStatus.Text = "Checking for updates...";
            SetActivity("Updating...");
            Application.DoEvents();

            ProcessStartInfo updateStartInfo = new()
            {
                FileName = ytdlpExe,
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

                        SetActivity("Update complete.");

                        // Enable controls again.
                        buttonUpdate.Enabled = true;
                        ValidateDownloadButtonState();

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
        // ::::::::::::::::: END

        // About (i) button.
        private void ButtonAbout_Click(object sender, EventArgs e)
        {
            About aboutWindow = new();
            aboutWindow.Show();
        }

        // ::::: START
        // Validations
        // Download
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
        // Formats
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
        // ::::::: END

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

        // Handle download start and abort.
        private void ButtonStartDownload_Click(object sender, EventArgs e)
        {
            string sourceUrl = textBoxSourceUrl.Text.Replace("\r\n", " ");
            string outputDir = textBoxOutputDir.Text;
            string videoFormat = dropdownVideoFormat.Text;
            string videoResolution = dropdownVideoResolution.Text.TrimEnd('p');
            string audioFormat = dropdownAudioFormat.Text;

            SetActivity("Downloading...");

            ytdlpCommand = radioButtonVideo.Checked
                    ? string.Concat(sourceUrl, " -P temp:\"", tempFolder, "\" -P home:\"", outputDir, "\" -f \"bv*[ext=", videoFormat, "][height<=", videoResolution, "]+ba[ext=m4a]/b\" --ffmpeg-location \"", ffmpegExe, "\" --remux-video ", videoFormat, " --windows-filenames")
                    : string.Concat(sourceUrl, " -P temp:\"", tempFolder, "\" -P home:\"", outputDir, "\" -x --audio-format ", audioFormat, " --ffmpeg-location \"", ffmpegExe, "\" --windows-filenames");

            Application.DoEvents();

            ProcessStartInfo downloadStartInfo = new()
            {
                FileName = ytdlpExe,
                Arguments = ytdlpCommand,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            downloadThread = new Thread(() =>
            {
                try
                {
                    downloadProcess = new Process { StartInfo = downloadStartInfo };
                    downloadProcess.Start();

                    using (StreamReader reader = downloadProcess.StandardOutput)
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            textBoxConsoleOut.Invoke((Action)(() => textBoxConsoleOut.Text = line));
                            Application.DoEvents();

                            if (AbortDownloadRequested)
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

                        // Enable controls and hide abort button.
                        if (AbortDownloadRequested)
                        {
                            SetActivity("Download aborted.");
                        }
                        else
                        {
                            SetActivity("Download complete.");
                            PlayNotificationSound();

                        }
                        AbortDownloadRequested = false;
                        buttonAbortDownload.Visible = false;

                        //Re-enable controls.
                        buttonStartDownload.Visible = true;
                        textBoxSourceUrl.Enabled = true;
                        radioButtonVideo.Enabled = true;
                        radioButtonAudio.Enabled = true;
                        dropdownVideoFormat.Enabled = true;
                        dropdownVideoResolution.Enabled = true;
                        dropdownAudioFormat.Enabled = true;
                        buttonBrowse.Enabled = true;
                        buttonUpdate.Enabled = true;
                    });
                }
            });

            // Disable controls and show abort button.
            textBoxSourceUrl.Enabled = false;
            radioButtonVideo.Enabled = false;
            radioButtonAudio.Enabled = false;
            dropdownVideoFormat.Enabled = false;
            dropdownVideoResolution.Enabled = false;
            dropdownAudioFormat.Enabled = false;
            buttonBrowse.Enabled = false;
            buttonStartDownload.Visible = false;
            buttonAbortDownload.Visible = true;
            buttonAbortDownload.Enabled = true;
            buttonUpdate.Enabled = false;

            downloadThread.Start();
        }

        // Context menu to open troubleshooting window.

        // If true, current download will be aborted. Reset to false when new download starts.
        private bool AbortDownloadRequested = false;
        private void ButtonAbortDownload_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to abort the download? You may need to clean up partially downloaded files.", "Abort download", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Set the flag to request abortlation.
                AbortDownloadRequested = true;

                // Disable Abort download button.
                buttonAbortDownload.Enabled = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save user settings.
            UserSettings.Default.DownloadType = (radioButtonVideo.Checked ? "video" : "audio");
            UserSettings.Default.VideoFormatIndex = dropdownVideoFormat.SelectedIndex;
            UserSettings.Default.VideoResolutionIndex = dropdownVideoResolution.SelectedIndex;
            UserSettings.Default.AudioFormatIndex = dropdownAudioFormat.SelectedIndex;
            UserSettings.Default.OutputDir = textBoxOutputDir.Text;
            UserSettings.Default.Save();

            // Checks for ongoing activity while trying to close the program.

            // Check if update is in progress.
            if (updateThread != null && updateThread.IsAlive)
            {
                // Inform about pending downloads.
                DialogResult = MessageBox.Show("Update is still in progress. Please wait a few seconds before closing the application.", "Still updating", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }

            // Check if downloads are in progress.
            if (downloadThread != null && downloadThread.IsAlive)
            {
                // Inform about pending downloads.
                DialogResult = MessageBox.Show("Download is still in progress. Please abort it before closing the application.", "Still downloading", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ViewCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                Command commandWindow = new();
                commandWindow.Show();
            }
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

