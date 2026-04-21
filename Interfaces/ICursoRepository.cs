using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Models;

namespace SisColegio.Interfaces
{
    public interface ICursoRepository : IGenericRepository<Curso>
    {
        Task<PagedList<Curso>> GetAllAsync(PostQueryFilter filter);
    }
}
