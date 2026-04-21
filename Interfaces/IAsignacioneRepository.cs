using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Models;

namespace SisColegio.Interfaces
{
    public interface IAsignacioneRepository :IGenericRepository<Asignacione>
    {
        Task<PagedList<Asignacione>> GetAllAsync(PostQueryFilter filter);
    }
}
