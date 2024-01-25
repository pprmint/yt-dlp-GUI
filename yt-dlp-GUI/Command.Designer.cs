namespace yt_dlp_GUI
{
    partial class Command
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
            textBoxCommand = new TextBox();
            buttonCopy = new Button();
            button1 = new Button();
            labelVersion = new Label();
            SuspendLayout();
            // 
            // textBoxCommand
            // 
            textBoxCommand.Location = new Point(12, 12);
            textBoxCommand.Multiline = true;
            textBoxCommand.Name = "textBoxCommand";
            textBoxCommand.PlaceholderText = "yt-dlp command displayed here...";
            textBoxCommand.ReadOnly = true;
            textBoxCommand.ScrollBars = ScrollBars.Vertical;
            textBoxCommand.Size = new Size(776, 257);
            textBoxCommand.TabIndex = 0;
            // 
            // buttonCopy
            // 
            buttonCopy.Location = new Point(12, 284);
            buttonCopy.Margin = new Padding(3, 12, 3, 3);
            buttonCopy.Name = "buttonCopy";
            buttonCopy.Size = new Size(193, 23);
            buttonCopy.TabIndex = 1;
            buttonCopy.Text = "Copy command to clipboard";
            buttonCopy.UseVisualStyleBackColor = true;
            buttonCopy.Click += ButtonCopy_Click;
            // 
            // button1
            // 
            button1.Location = new Point(595, 284);
            button1.Name = "button1";
            button1.Size = new Size(193, 23);
            button1.TabIndex = 2;
            button1.Text = "Open default shell";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // labelVersion
            // 
            labelVersion.AutoSize = true;
            labelVersion.Location = new Point(211, 288);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(102, 15);
            labelVersion.TabIndex = 3;
            labelVersion.Text = "yt-dlp GUI version";
            // 
            // Command
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 319);
            Controls.Add(labelVersion);
            Controls.Add(button1);
            Controls.Add(buttonCopy);
            Controls.Add(textBoxCommand);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Command";
            Text = "Command";
            Load += Command_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxCommand;
        private Button buttonCopy;
        private Button button1;
        private Label labelVersion;
    }
}