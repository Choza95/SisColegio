using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Repositories
{
    public class PadreRepository : GenericRepository<Padre>, IPadreRepository
    {
        public PadreRepository(MiBaseContext context) : base (context) 
        {
        }

        public async Task<PagedList<Padre>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.NombreCompleto.ToLower().Contains(buscar) ||
                    x.Ci.ToLower().Contains(buscar));
            }

            return await PagedList<Padre>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }
    }
}
