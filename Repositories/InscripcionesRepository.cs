using Microsoft.EntityFrameworkCore;
using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Repositories
{
    public class InscripcionesRepository : GenericRepository<Inscripcione>,     
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

        public IEnumerable<Inscripcione?> GetinscripcionesByEstudiante(int idEstudiante)
        {
            var inscripciones = _context.Inscripciones.Where(a => a.IdEstudiante == idEstudiante && a.Borrado == false).Include(a => a.IdCursoNavigation);

            if (inscripciones == null)
                return null;
            return inscripciones;
        }



    }
}
