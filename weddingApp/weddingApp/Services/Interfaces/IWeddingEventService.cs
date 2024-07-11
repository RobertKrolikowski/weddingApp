using weddingApp.Model.Entities;

namespace weddingApp.Services.Interfaces
{
    public interface IWeddingEventService
    {
        Task<IEnumerable<WeddingEvent>> GetAllWeddingEvents();
        Task<WeddingEvent> GetWeddingEventById(int id );
        Task<WeddingEvent> CreateWeddingEvent(WeddingEvent weddingEvent);
        Task<WeddingEvent> UpdateWeddingEvent(WeddingEvent weddingEvent);
        Task<WeddingEvent> DeleteWeddingEvent(WeddingEvent weddingEvent);
        Task AddGift(int idWeddingEvent, int idGift);
        Task RemoveGift(int idWeddingEvent, int idGift);
        Task AddGuest(int idWeddingEvent, int idGuest);
        Task RemoveGuest(int idWeddingEvent, int idGuest);
        Task AddWeddingService(int idWeddingEvent, int idWeddingService);
        Task RemoveWeddingService(int idWeddingEvent, int idWeddingService);
    }
}
