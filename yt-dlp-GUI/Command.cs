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
    public partial class Command : Form
    {
        public Command()
        {
            InitializeComponent();

            labelVersion.Text = string.Concat(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, " ", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo powerShell = new ProcessStartInfo("powershell.exe");
            powerShell.UseShellExecute = true;
            Process.Start(powerShell);
        }

        private void Command_Load(object sender, EventArgs e)
        {
            textBoxCommand.Text = string.Concat("\"", Path.Combine(Directory.GetCurrentDirectory(), "utils", "yt-dlp.exe"), "\" ", Main.ytdlpCommand);
        }

        private void ButtonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxCommand.Text);
        }
    }
}
