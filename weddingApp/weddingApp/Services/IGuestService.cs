using weddingApp.Model.Entities;

namespace weddingApp.Services
{
    public interface IGuestService
    {
        Task<IEnumerable<Guest>> GetAllGuests();
    }
}
