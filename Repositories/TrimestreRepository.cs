using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Repositories
{
    public class TrimestreRepository : GenericRepository<Trimestre>, ITrimestreRepository
    {
        public TrimestreRepository(MiBaseContext context) : base(context)
        {
        }

        public async Task<PagedList<Trimestre>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.Nombre.ToLower().Contains(buscar));
            }

            return await PagedList<Trimestre>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }
    }

}
