using Microsoft.EntityFrameworkCore;
using weddingApp.Data;
using weddingApp.Model.Entities;
using weddingApp.Services.Interfaces;

namespace weddingApp.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly WeddingAppContext _context;
        public UserService(WeddingAppContext context)
        {
            _context = context;
        }
        public async Task<User> Authenticate(string login, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Login == login);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
                return null;

            return user;
        }
    }
}
