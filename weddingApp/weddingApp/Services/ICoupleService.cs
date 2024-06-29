using weddingApp.Model.Entities;

namespace weddingApp.Services
{
    public interface ICoupleService
    {
        Task<IEnumerable<Couple>> GetAllCouples();
    }
}
