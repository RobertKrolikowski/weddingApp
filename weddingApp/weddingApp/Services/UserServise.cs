using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using weddingApp.Data;
using weddingApp.Model.Entities;

namespace weddingApp.Services
{
    public class UserServise : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly WeddingAppContext _db;
        public UserServise(IConfiguration configuration, WeddingAppContext db)
        {
            _configuration = configuration;
            _db = db;
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = _db.Users.ToListAsync();
            return await users;
        }
    }
}
