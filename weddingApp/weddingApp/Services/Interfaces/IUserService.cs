using weddingApp.Model.Entities;

namespace weddingApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
    }
}
