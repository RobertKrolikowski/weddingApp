using weddingApp.Data;
using weddingApp.Model.Entities;
using weddingApp.Services.Interfaces;

namespace weddingApp.Services.Implementation
{
    public class WeddingServiceService : IWeddingServiceService
    {
        private readonly IConfiguration _configuration;
        private readonly WeddingAppContext _db;
        public WeddingServiceService(IConfiguration configuration, WeddingAppContext db)
        {
            _configuration = configuration;
            _db = db;
        }
        public Task<IEnumerable<WeddingService>> GetAllWeddingServices()
        {
            throw new NotImplementedException();
        }

        public Task<WeddingService> GetWeddingServiceById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WeddingService> CreateWeddingService(WeddingService weddingService)
        {
            throw new NotImplementedException();
        }
        public Task<WeddingService> UpdateWeddinService(WeddingService weddingService)
        {
            throw new NotImplementedException();
        }
        public Task<WeddingService> DeleteWeddingService(WeddingService weddingService)
        {
            throw new NotImplementedException();
        }

    }
}
