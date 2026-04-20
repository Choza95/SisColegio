using SisColegio.Data;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Repositories
{
    public class EvaluacionesRepository : GenericRepository<Evaluacione>, IEvaluacionesRepository
    {
        public EvaluacionesRepository(MiBaseContext context) : base(context)
        { 
        }
    }
}
