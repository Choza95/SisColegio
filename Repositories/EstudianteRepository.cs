using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Repositories
{
    public class EstudianteRepository : GenericRepository<Estudiante>, IEstudiantesRepository
    {
        public EstudianteRepository(MiBaseContext context) : base(context)
        {
        }

        public async Task<PagedList<Estudiante>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.Nombre.ToString().ToLower().Contains(buscar) ||
                    x.Apellido.ToString().ToString().ToLower().Contains(buscar) ||
                    x.Ci.ToString().ToLower().Contains(buscar));
            }

            return await PagedList<Estudiante>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }


    }
}
