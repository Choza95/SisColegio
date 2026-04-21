using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Models;

namespace SisColegio.Interfaces
{
    public interface IDisciplinaRepository : IGenericRepository<Disciplina>
    {
        Task<PagedList<Disciplina>> GetAllAsync(PostQueryFilter filter);
    }
}
