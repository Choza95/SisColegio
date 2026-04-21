using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Models;

namespace SisColegio.Interfaces
{
    public interface IMateriaRepository :IGenericRepository<Materia>
    {
        Task<PagedList<Materia>> GetAllAsync(PostQueryFilter filter);
    }
}
