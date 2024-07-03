using weddingApp.Model.Entities;

namespace weddingApp.Services.Interfaces
{
    public interface IGiftService
    {
        Task<IEnumerable<Gift>> GetAllGifts();
    }
}
