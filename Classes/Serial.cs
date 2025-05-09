using System.IO.Ports;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace iMac.Classes
{
    public class Serial(Action<string> dataReceivedCallback)
    {

        private SerialPort? _serialPort;
        private SerialConfig? _serialConfig;
        private const string ConfigPath = "Config.json";

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
                MessageBox.Show(ex.Message, Messages.MessageBoxErrorTitle, MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }

        private void Listen(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (_serialPort != null)
                {
                    string data = _serialPort.ReadExisting();
                    dataReceivedCallback.Invoke(data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Send(string message)
        {
            try
            {
                if (_serialPort != null)
                {
                    _serialPort.Write(message);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     

    }
}

