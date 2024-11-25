using Relay_controller_app.Interfaces;
using Relay_controller_app.Models;

namespace Relay_controller_app.Services
{
    public class RelayService : IRelayService
    {

        private readonly IArduinoCommunicationService _arduinoCommunicationService;
        private readonly ILogger<RelayService> _logger;
        private readonly List<Relay> _relays;

        public RelayService(
            IArduinoCommunicationService arduinoService,
            ILogger<RelayService> logger
            )
        {
           _arduinoCommunicationService = arduinoService;
            _logger = logger;
            _relays = InitializeRelays();
        }


        static private List<Relay> InitializeRelays() { 
        return Enumerable.Range(1,8).Select(x=> new Relay
        {
            Id = x,
            Name=$"Relay {x}",
            Pin =x,
            Status =false
        }
        ).ToList();
        }


        public  Task<IEnumerable<Relay>> GetAllRelaysAsync()
        {

            return Task.FromResult<IEnumerable<Relay>>( _relays );
        }

        public Task<Relay> GetRelayByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetRelayStatusAsync(int id)
        {
            throw new NotImplementedException();
        }

        public  Task<bool> SetRelayStatusAsync(int id, bool status)
        {
            try
            { 
                    _arduinoCommunicationService.ConnectAsync("COM6");
                    _arduinoCommunicationService.SendRelayStatusAsync(id, status);
                    _arduinoCommunicationService.DisconnectAsync();


                return Task.FromResult(true);
            }
            catch (Exception ex) {
                _logger.LogError($"{ex.Message} Error in send command to Arduino");
                return Task.FromResult(false);
            }
        }
    }
}
