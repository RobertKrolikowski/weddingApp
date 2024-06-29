using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;
using weddingApp.Data;
using weddingApp.Model.Entities;

namespace weddingApp.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IConfiguration _configuration;
        private readonly WeddingAppContext _db;
        public ServiceService(IConfiguration configuration, WeddingAppContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        public async Task<IEnumerable<Service>> GetAllServices()
        {
            var services = _db.Services.ToListAsync();
            return await services;
        }
    }
}
