using Microsoft.EntityFrameworkCore.Metadata.Internal;
using weddingApp.Model.Entities;

namespace weddingApp.Services
{
    public interface IServiceService
    {
        Task<IEnumerable<Service>> GetAllServices();
    }
}
