using SisColegio.Data;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Repositories
{
    public class CursoRepository : GenericRepository<Curso>, ICursoRepository
    {
        public CursoRepository(MiBaseContext context) : base(context)
        {
        }
    }
}
