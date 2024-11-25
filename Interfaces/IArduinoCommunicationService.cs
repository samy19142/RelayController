namespace Relay_controller_app.Interfaces
{
    public interface IArduinoCommunicationService
    {
        Task<bool> ConnectAsync(string portName);
        Task<bool> DisconnectAsync();
        Task<bool> SendRelayStatusAsync(int pin, bool status);
        Task<bool> GetRelayStatusAsync(int pin);
    }
}
