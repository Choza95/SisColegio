using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Models;

namespace SisColegio.Interfaces
{
    public interface ITrimestreRepository : IGenericRepository<Trimestre>
    {
        Task<PagedList<Trimestre>> GetAllAsync(PostQueryFilter filter);
    }
}
