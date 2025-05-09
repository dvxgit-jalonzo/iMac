namespace iMac.Classes{
    public class SerialConfig{
        public required string PortName { get; set; }
        public required int BaudRate { get; set; }
        public required string Parity { get; set; }
        public required int DataBits { get; set; }
        public required string StopBits { get; set; }
        public required string Handshake { get; set; }
    }
}