using SisColegio.Data;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Repositories
{
    public class AsignacioneRepository : GenericRepository<Asignacione>, IAsignacioneRepository
    {
        public AsignacioneRepository(MiBaseContext context) : base(context) 
        {
        }
    }
}
