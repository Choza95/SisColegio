using SisColegio.Data;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Repositories
{
    public class MateriaRepository : GenericRepository<Materia>, IMateriaRepository
    {
        public MateriaRepository(MiBaseContext context) : base(context)
        {
        }
    }
}
