using Microsoft.EntityFrameworkCore;
using weddingApp.Data;
using weddingApp.Model.Entities;
using weddingApp.Services.Interfaces;

namespace weddingApp.Services.Implementation
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
        public Task<Guest> GetGuestById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Guest> CreateGuest(Guest guest)
        {
            throw new NotImplementedException();
        }

        public Task<Guest> UpdateGuest(Guest guest)
        {
            throw new NotImplementedException();
        }
        public Task<Guest> DeleteGuest(Guest guest)
        {
            throw new NotImplementedException();
        }
    }
}
