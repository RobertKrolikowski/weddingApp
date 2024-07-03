using Microsoft.EntityFrameworkCore;
using weddingApp.Data;
using weddingApp.Model.Entities;

namespace weddingApp.Services
{
    public class CoupleService : ICoupleService
    {
        private readonly IConfiguration _configuration;
        private readonly WeddingAppContext _db;
        public CoupleService( IConfiguration configuration, WeddingAppContext db)
        {
            _configuration = configuration; 
            _db = db;
        }


        public async Task<IEnumerable<Couple>> GetAllCouples()
        {
            Task<List<Couple>>? couples = _db.Couples.ToListAsync();
            return await couples;
        }

        public async Task<Couple> GetCouplesById(int id)
        {
            Task<Couple?>? couple = _db.Couples.FirstOrDefaultAsync(x=>x.Id == id);
            return await couple;
        }
        public async Task<Couple> CreateCouple(Couple couple)
        {
            _db.Couples.Add(couple);
            _db.SaveChanges();
            return couple;
        }
    }
}
