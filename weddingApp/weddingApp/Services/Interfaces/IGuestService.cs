using weddingApp.Model.Entities;

namespace weddingApp.Services.Interfaces
{
    public interface IGuestService
    {
        Task<IEnumerable<Guest>> GetAllGuests();
    }
}
