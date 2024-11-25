using Relay_controller_app.Models;

namespace Relay_controller_app.Interfaces
{
    public interface IRelayService
    {

        Task<IEnumerable<Relay>> GetAllRelaysAsync();
        Task<Relay>GetRelayByIdAsync(int id);
        Task<bool> SetRelayStatusAsync(int id,bool status);
        Task<bool> GetRelayStatusAsync(int id);
    }
}
