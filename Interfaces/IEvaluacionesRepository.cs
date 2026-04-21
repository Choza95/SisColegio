using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Models;

namespace SisColegio.Interfaces
{
    public interface IEvaluacionesRepository : IGenericRepository<Evaluacione>
    {

        Task<PagedList<Evaluacione>> GetAllAsync(PostQueryFilter filter);
    }
}
