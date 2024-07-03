using Microsoft.EntityFrameworkCore.Metadata.Internal;
using weddingApp.Model.Entities;

namespace weddingApp.Services.Interfaces
{
    public interface IServiceService
    {
        Task<IEnumerable<Service>> GetAllServices();
    }
}
