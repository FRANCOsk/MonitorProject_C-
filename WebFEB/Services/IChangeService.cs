using WebFEB.Models;

namespace WebFEB.Services
{
    public interface IChangeService

    {
        Task TrackChange(ChangeDTO action);
        Task<List<ChangeDTO>> GetAllChangesAsync();
        Task<ChangeDTO> GetChangeByIdAsync(int id);
    }
}