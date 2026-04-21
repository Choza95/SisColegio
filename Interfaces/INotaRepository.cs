using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Models;

namespace SisColegio.Interfaces
{
    public interface INotaRepository : IGenericRepository<Nota>
    {
        Task<PagedList<Nota>> GetAllAsync(PostQueryFilter filter);
    }
}
