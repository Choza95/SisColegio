using SisColegio.Data;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Repositories
{
    public class PadreRepository : GenericRepository<Padre>, IPadreRepository
    {
        public PadreRepository(MiBaseContext context) : base (context) 
        {
        }
    }
}
