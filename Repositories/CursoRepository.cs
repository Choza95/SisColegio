using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Repositories
{
    public class CursoRepository : GenericRepository<Curso>, ICursoRepository
    {
        public CursoRepository(MiBaseContext context) : base(context)
        {
        }


        public async Task<PagedList<Curso>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.Nombre.ToString().ToLower().Contains(buscar) ||
                    x.Id.ToString().ToLower().Contains(buscar));
            }

            return await PagedList<Curso>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }
    }
}
