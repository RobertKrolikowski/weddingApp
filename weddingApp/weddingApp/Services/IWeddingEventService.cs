using weddingApp.Model.Entities;

namespace weddingApp.Services
{
    public interface IWeddingEventService
    {
        Task<IEnumerable<WeddingEvent>> GetAllWeddingEvents();
    }
}
