using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Repositories
{
    public class EvaluacionesRepository : GenericRepository<Evaluacione>, IEvaluacionesRepository
    {
        public EvaluacionesRepository(MiBaseContext context) : base(context)
        { 
        }


        public async Task<PagedList<Evaluacione>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.Descripcion.ToString().ToLower().Contains(buscar) ||
                    x.Titulo.ToString().ToString().ToLower().Contains(buscar) ||
                    x.Id.ToString().ToLower().Contains(buscar));
            }

            return await PagedList<Evaluacione>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }
    }
}
