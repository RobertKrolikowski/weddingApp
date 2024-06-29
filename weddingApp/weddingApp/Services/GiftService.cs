using Microsoft.EntityFrameworkCore;
using weddingApp.Data;
using weddingApp.Model.Entities;

namespace weddingApp.Services
{
    public class GiftService :IGiftService
    {
        private readonly IConfiguration _configuration;
        private readonly WeddingAppContext _db;
        public GiftService(IConfiguration configuration, WeddingAppContext db)
        {
            _configuration = configuration;
            _db = db;
        }
        public async Task<IEnumerable<Gift>> GetAllGifts()
        {
            var gifts = _db.Gifts.ToListAsync();
            return await gifts;
        }
    }
}
