using Relay_controller_app.Interfaces;
using System.IO.Ports;

namespace Relay_controller_app.Services
{
    public class SerialPortService : ISerialPortService
    {

        private SerialPort _serialPort = new SerialPort();
        
        private readonly ILogger<SerialPortService> _logger;

        public SerialPortService(ILogger<SerialPortService> logger)
        {
            _logger = logger;
        }



        public void ClosePort()
        {
            _serialPort?.Close();
            _serialPort?.Dispose();
        }

        public string[] GetAvailablePorts()
        {
            
            return SerialPort.GetPortNames();
        }

        public bool OpenPort(string portName, int baudRate = 9600)
        {
            try
            {

                _serialPort = new SerialPort(portName, baudRate);
                _serialPort.Open();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} Error try open connection");
                return false;
            }
        }



        public string ReadData()
        {
            throw new NotImplementedException();
        }

        public void WriteData(string data)
        {
            try
            {

                _serialPort.WriteLine(data);
            }
            catch (Exception ex) {
                _logger.LogError($"{ex.Message} Error write data in Arduino");
            }
        }

        public bool IsOpen()
        {
            return _serialPort.IsOpen;
        }
    }

}
