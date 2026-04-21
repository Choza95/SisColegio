using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Repositories
{
    public class MateriaRepository : GenericRepository<Materia>, IMateriaRepository
    {
        public MateriaRepository(MiBaseContext context) : base(context)
        {
        }


        public async Task<PagedList<Materia>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.Nombre.ToLower().Contains(buscar) ||
                    x.Id.ToString().ToLower().Contains(buscar));
            }

            return await PagedList<Materia>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }
    }
}
