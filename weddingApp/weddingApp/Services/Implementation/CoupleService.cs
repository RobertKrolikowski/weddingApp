using Microsoft.EntityFrameworkCore;
using weddingApp.Data;
using weddingApp.Model.Entities;
using weddingApp.Services.Interfaces;

namespace weddingApp.Services.Implementation
{
    public class CoupleService : ICoupleService
    {
        private readonly IConfiguration _configuration;
        private readonly WeddingAppContext _db;
        public CoupleService(IConfiguration configuration, WeddingAppContext db)
        {
            _configuration = configuration;
            _db = db;
        }
        public async Task<IEnumerable<Couple>> GetAllCouples()
        {
            var couples = _db.Couples.ToListAsync();
            return await couples;
        }
    }
}
