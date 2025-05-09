using System.IO.Ports;
using System.Text.Json;
using System.Windows.Forms;
using System.Media;

namespace iMac.Classes
{
    public class Serial
    {
        private SoundPlayer player = new SoundPlayer();
        private SerialPort? _serialPort;
        private SerialConfig? _serialConfig;
        private const string ConfigPath = "Config.json";

        private readonly Action<string> _dataReceivedCallback;
        private readonly MainForm _mainForm;
        private bool HasActivedAlarm = false;

        public Serial(Action<string> dataReceivedCallback, MainForm mainForm)
        {
            _dataReceivedCallback = dataReceivedCallback;
            _mainForm = mainForm;
        }

        public void StartConnection()
        {
            try
            {
                string json = File.ReadAllText(ConfigPath);
                _serialConfig = JsonSerializer.Deserialize<SerialConfig>(json);

                if (_serialConfig == null)
                {
                    throw new InvalidOperationException("Serial configuration is missing or invalid.");
                }

                _serialPort = new SerialPort
                {
                    PortName = _serialConfig.PortName,
                    BaudRate = _serialConfig.BaudRate,
                    DataBits = _serialConfig.DataBits,
                    Parity = Enum.Parse<Parity>(_serialConfig.Parity),
                    StopBits = Enum.Parse<StopBits>(_serialConfig.StopBits),
                    Handshake = Enum.Parse<Handshake>(_serialConfig.Handshake),
                };

                _serialPort.Open();
                _serialPort.DataReceived += Listen;

                MessageBox.Show(Messages.SerialPortOpenedSuccessfully);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Listen(object sender, SerialDataReceivedEventArgs e)
        {
            string data = _serialPort?.ReadExisting() ?? string.Empty;

    
            _mainForm.Invoke((MethodInvoker)(() =>
            {
                _dataReceivedCallback.Invoke(data);
                ActivateAlarm();
              
            }));
        }
        public void ActivateAlarm()
        {
            if(!HasActivedAlarm)
            {
                _mainForm.alert.Visible = true;
                player.SoundLocation = "Sounds/classic-alarm.wav";
                player.PlayLooping();
                HasActivedAlarm = true;
            }
            
        }

        public void DeactivateAlarm()
        {
            if (HasActivedAlarm)
            {
                _mainForm.alert.Visible = false;
                player.Stop();
                HasActivedAlarm = false;
            }   
        }
    }
}
