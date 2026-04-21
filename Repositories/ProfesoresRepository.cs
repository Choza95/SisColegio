using Microsoft.EntityFrameworkCore;
using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Repositories
{
    public class ProfesoresRepository : GenericRepository<Profesores>, IProfesoresRepository
    {
        public ProfesoresRepository(MiBaseContext context) : base(context)
        {
        }



        public async Task<PagedList<Profesores>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.Nombre.ToLower().Contains(buscar) ||
                    x.Ci.ToLower().Contains(buscar) ||
                    x.Apellido.ToLower().Contains(buscar));
            }

            return await PagedList<Profesores>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }

    }
}