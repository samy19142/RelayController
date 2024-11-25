using Relay_controller_app.Interfaces;


namespace Relay_controller_app.Services
{
    public class ArduinoCommunicationService : IArduinoCommunicationService
    {

        private ISerialPortService _serialPort;
        private readonly ILogger<ArduinoCommunicationService> _logger;


        public ArduinoCommunicationService(ILogger<ArduinoCommunicationService> logger,ISerialPortService serialPortService)
        {
            _logger = logger;
            _serialPort = serialPortService;
        }




        public  Task<bool> ConnectAsync(string portName)
        {
            try
            {
                
                return Task.FromResult(_serialPort.OpenPort("COM6",9600));


            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} Error connecting to Arduino");
                return Task.FromResult(false);

            }
        }


        public Task<bool> DisconnectAsync()
        {
            try
            {

                _serialPort.ClosePort();

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} Error close connection to Arduino");
                return Task.FromResult(false);
            }
        }

        public  Task<bool> GetRelayStatusAsync(int pin)
        {

            throw new NotImplementedException();
        }

        public  Task<bool> SendRelayStatusAsync(int pin, bool status)
        {

            try
            {

                if (_serialPort.IsOpen())
                {
                    string setStatus = status ? "1" : "0";

                    _serialPort.WriteData($"{pin}:{setStatus}");

                }

                return Task.FromResult(true);

            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} Error in send command to Arduino");
                return Task.FromResult(false);
            }
            finally {
                _serialPort.ClosePort();
            }
        }
    }
}
