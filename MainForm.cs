using iMac.Classes;

namespace iMac
{
    public partial class MainForm : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenuStrip trayMenu;
        private bool allowClose = false;

        private Serial _serial;
        public MainForm()
        {
            InitializeComponent();
            _serial = new Serial(UpdateRichTextBox, this);

            // Run this method when the form is about to close
            this.FormClosing += MainForm_FormClosing;

            // Run this method when the form is resized (e.g. minimized)
            this.Resize += MainForm_Resize;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowClose)
            {
                e.Cancel = true;
                Hide(); // Just hide to tray
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide(); // Hides the window and keeps app running in tray
            }
            _serial = new Serial(UpdateRichTextBox, this);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _serial.StartConnection();
        }

        private void UpdateRichTextBox(string data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateRichTextBox), data);
                return;
            }

            //logger.AppendText(data + "\n");
            logger.Text = data + "\n" + logger.Text;
            logger.SelectionStart = 0;
            logger.SelectionLength = 0;
            logger.ScrollToCaret();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        //private void DataToSend_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.SuppressKeyPress = true; // Prevent the newline character

        //        string data = DataToSend.Text.Trim();

        //        if (_serial != null)
        //        {
        //            _serial.Send(data);
        //            DataToSend.Clear();
        //            // Optional: show a message or log sent data
        //        }
        //        else
        //        {
        //            MessageBox.Show("Serial port is not initialized.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //}

        private void logger_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataToSend_TextChanged(object sender, EventArgs e)
        {

        }

        private void alert_Click(object sender, EventArgs e)
        {
            _serial.DeactivateAlarm();

        }
    }
}
