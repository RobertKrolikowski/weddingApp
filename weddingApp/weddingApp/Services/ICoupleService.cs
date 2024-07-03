using weddingApp.Model.Entities;

namespace weddingApp.Services
{
    public interface ICoupleService
    {
        Task<IEnumerable<Couple>> GetAllCouples();
        Task<Couple> GetCouplesById(int id);
        Task<Couple> CreateCouple(Couple couple);
    }
}
