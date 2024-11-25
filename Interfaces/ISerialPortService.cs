namespace Relay_controller_app.Interfaces
{
    public interface ISerialPortService
    {

        string[] GetAvailablePorts();
        bool OpenPort(string portName, int baudRate = 9600);
        bool IsOpen();
        void ClosePort();
        string ReadData();
        void WriteData(string data);
    }
}
