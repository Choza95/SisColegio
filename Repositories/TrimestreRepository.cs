using SisColegio.Data;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Repositories
{
    public class TrimestreRepository : GenericRepository<Trimestre>, ITrimestreRepository
    {
        public TrimestreRepository(MiBaseContext context) : base(context)
        {
        }
    }
}
