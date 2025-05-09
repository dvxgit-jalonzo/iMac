namespace iMac
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            logger = new RichTextBox();
            DataToSend = new RichTextBox();
            SuspendLayout();
            // 
            // logger
            // 
            logger.BackColor = SystemColors.InactiveCaption;
            logger.BorderStyle = BorderStyle.None;
            logger.Dock = DockStyle.Bottom;
            logger.ForeColor = Color.ForestGreen;
            logger.Location = new Point(0, 304);
            logger.Name = "logger";
            logger.Size = new Size(800, 146);
            logger.TabIndex = 1;
            logger.Text = "";
            logger.TextChanged += logger_TextChanged;
            // 
            // DataToSend
            // 
            DataToSend.BorderStyle = BorderStyle.None;
            DataToSend.Dock = DockStyle.Right;
            DataToSend.Location = new Point(607, 0);
            DataToSend.Name = "DataToSend";
            DataToSend.Size = new Size(193, 304);
            DataToSend.TabIndex = 2;
            DataToSend.Text = "";
            DataToSend.TextChanged += DataToSend_TextChanged;
            DataToSend.KeyDown += DataToSend_KeyDown;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DataToSend);
            Controls.Add(logger);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "iMac";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            ResumeLayout(false);

            // Create a context menu for the tray icon
            trayMenu = new ContextMenuStrip();

            // Add a "Restore" option to bring the window back from the tray
            trayMenu.Items.Add("Restore", null, (s, e) => { ShowForm(); });

            // Add an "Exit" option to close the app
            trayMenu.Items.Add("Exit", null, (s, e) => {
                allowClose = true; // Allow the form to close without being canceled
                Close();           // Close the application
            });

            // Set up the tray icon (system tray notification icon)
            trayIcon = new NotifyIcon()
            {
                Text = "iMac App",                 // Tooltip text
                Icon = SystemIcons.Application,    // Default application icon (can be replaced with custom .ico)
                ContextMenuStrip = trayMenu,       // Attach the context menu to the icon
                Visible = true                     // Make the icon visible in the system tray
            };

            // Restore the window when the tray icon is double-clicked
            trayIcon.DoubleClick += (s, e) => { ShowForm(); };
        }

        #endregion
        private Button startSerialPort;
        private Label label1;
        private RichTextBox logger;
        private RichTextBox DataToSend;
        private void ShowForm()
        {
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
        }
    }
}
