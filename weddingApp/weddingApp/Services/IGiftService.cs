using weddingApp.Model.Entities;

namespace weddingApp.Services
{
    public interface IGiftService
    {
        Task<IEnumerable<Gift>> GetAllGifts();
    }
}
