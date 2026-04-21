using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Models;

namespace SisColegio.Interfaces
{
    public interface IPadreRepository : IGenericRepository<Padre>
    {
        Task<PagedList<Padre>> GetAllAsync(PostQueryFilter filter);
    }
}
