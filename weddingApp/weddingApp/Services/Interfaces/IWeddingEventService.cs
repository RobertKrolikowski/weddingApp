using weddingApp.Model.Entities;

namespace weddingApp.Services.Interfaces
{
    public interface IWeddingEventService
    {
        Task<IEnumerable<WeddingEvent>> GetAllWeddingEvents();
    }
}
