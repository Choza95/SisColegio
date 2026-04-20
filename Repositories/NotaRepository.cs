using Microsoft.EntityFrameworkCore;
using SisColegio.Data;
using SisColegio.Interfaces;
using SisColegio.Models;


namespace SisColegio.Repositories
{
    public class NotaRepository : GenericRepository<Nota>, INotaRepository
    {
        public NotaRepository(MiBaseContext context) : base(context)
        {
        }
        //public async Task<Nota?> GetByEmailAsync(string email)
        //{
        //    return await _context.Notas
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(x => x.Email == email && x.Borrado == false);
        //}
    }
}
