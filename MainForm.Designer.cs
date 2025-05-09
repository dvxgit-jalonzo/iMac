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
            alert = new Label();
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
            // alert
            // 
            alert.BackColor = Color.Red;
            alert.Dock = DockStyle.Fill;
            alert.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            alert.ForeColor = Color.White;
            alert.Location = new Point(0, 0);
            alert.Name = "alert";
            alert.Size = new Size(800, 304);
            alert.TabIndex = 2;
            alert.Text = "Alarm Triggered in Cabin 101";
            alert.TextAlign = ContentAlignment.MiddleCenter;
            alert.Visible = false;
            alert.Click += alert_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(alert);
            Controls.Add(logger);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "iMac";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button startSerialPort;
        private RichTextBox logger;
        public Label alert;
    }
}
