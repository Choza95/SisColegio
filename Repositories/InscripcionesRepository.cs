using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Repositories
{
    public class InscripcionesRepository : GenericRepository<Inscripcione>, IInscripcionesRepository
    {
        public InscripcionesRepository(MiBaseContext context) : base(context)
        {
        }


        public async Task<PagedList<Inscripcione>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.IdCurso.ToString().ToLower().Contains(buscar) ||
                    x.IdEstudiante.ToString().ToLower().Contains(buscar) ||
                    x.Id.ToString().ToLower().Contains(buscar));
            }

            return await PagedList<Inscripcione>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }
    }
}
