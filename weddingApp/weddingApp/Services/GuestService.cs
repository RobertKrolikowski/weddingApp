using Microsoft.EntityFrameworkCore;
using weddingApp.Data;
using weddingApp.Model.Entities;

namespace weddingApp.Services
{
    public class GuestService : IGuestService
    {
        private readonly IConfiguration _configuration;
        private readonly WeddingAppContext _db;
        public GuestService(IConfiguration configuration, WeddingAppContext db)
        {
            _configuration = configuration;
            _db = db;
        }
        public async Task<IEnumerable<Guest>> GetAllGuests()
        {
            var guests = _db.Guests.ToListAsync();
            return await guests;

        }
    }
}
