using Microsoft.EntityFrameworkCore;
using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Models;


namespace SisColegio.Repositories
{
    public class NotaRepository : GenericRepository<Nota>, INotaRepository
    {
        public NotaRepository(MiBaseContext context) : base(context)
        {
        }
        public async Task<PagedList<Nota>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();              
            }

            return await PagedList<Nota>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }
    }
}
