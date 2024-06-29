using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using weddingApp.Data;
using weddingApp.Model.DTO_s;
using weddingApp.Model.Entities;

namespace weddingApp.Services
{
    public class ThingService : IThingService
    {
        private readonly IConfiguration _configuration;
        private readonly WeddingAppContext _db;
        public ThingService(IConfiguration configuration, WeddingAppContext db)
        {
            _configuration = configuration;
            _db = db;
        }
        public async Task<IEnumerable<Thing>> GetAllThings()
        {
            Task<List<Thing>>? things = _db.Things.ToListAsync();
            return await things;
        }
        public async Task<Thing> CreateThing(Thing thing)
        {
            _db.Things.Add(thing);
            _db.SaveChanges();
            return thing;
        }

        

    }
}
