using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Repositories
{
    public class AsignacioneRepository : GenericRepository<Asignacione>, IAsignacioneRepository
    {
        public AsignacioneRepository(MiBaseContext context) : base(context) 
        {
        }


        public async Task<PagedList<Asignacione>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.IdCurso.ToString().ToLower().Contains(buscar) ||
                    x.IdMateria.ToString().ToLower().Contains(buscar) ||
                    x.Id.ToString().ToLower().Contains(buscar));
            }

            return await PagedList<Asignacione>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }


    }
}
