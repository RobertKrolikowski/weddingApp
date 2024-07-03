using Microsoft.EntityFrameworkCore;
using weddingApp.Data;
using weddingApp.Model.Entities;
using weddingApp.Services.Interfaces;

namespace weddingApp.Services.Implementation
{
    public class WeddingEventService : IWeddingEventService
    {
        private readonly IConfiguration _configuration;
        private readonly WeddingAppContext _db;
        public WeddingEventService(IConfiguration configuration, WeddingAppContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        public async Task<IEnumerable<WeddingEvent>> GetAllWeddingEvents()
        {
            var weddingEvents = _db.WeddingEvents.ToListAsync();
            return await weddingEvents;
        }
    }
}
