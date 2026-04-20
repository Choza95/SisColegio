using SisColegio.Data;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Repositories
{
    public class InscripcionesRepository : GenericRepository<Inscripcione>, IInscripcionesRepository
    {
        public InscripcionesRepository(MiBaseContext context) : base(context)
        {
        }
    }
}
