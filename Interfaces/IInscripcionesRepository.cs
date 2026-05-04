using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Models;

namespace SisColegio.Interfaces
{
    public interface IInscripcionesRepository : IGenericRepository<Inscripcione>
    {
        Task<PagedList<Inscripcione>> GetAllAsync(PostQueryFilter filter);
        IEnumerable<Inscripcione?> GetinscripcionesByEstudiante(int idEstudiante);

        IEnumerable<Inscripcione?> GetinscripcionesByCurso(int idCurso);
    }
}
