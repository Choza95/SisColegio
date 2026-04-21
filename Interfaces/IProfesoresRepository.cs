
using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Models;

namespace SisColegio.Interfaces
{
    public interface IProfesoresRepository : IGenericRepository<Profesores>
    {
        Task<PagedList<Profesores>> GetAllAsync(PostQueryFilter filter);
    }
}
