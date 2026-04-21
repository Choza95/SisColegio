using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Models;

namespace SisColegio.Interfaces
{
    public interface IEstudiantesRepository : IGenericRepository<Estudiante>
    {
        Task<PagedList<Estudiante>> GetAllAsync(PostQueryFilter filter);
    }
}
