using weddingApp.Model.Entities;

namespace weddingApp.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
    }
}
