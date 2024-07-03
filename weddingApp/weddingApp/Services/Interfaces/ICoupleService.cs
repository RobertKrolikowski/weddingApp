using weddingApp.Model.Entities;

namespace weddingApp.Services.Interfaces
{
    public interface ICoupleService
    {
        Task<IEnumerable<Couple>> GetAllCouples();
    }
}
