using SisColegio.Data;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Repositories
{
    public class DisciplinaRepository : GenericRepository<Disciplina>, IDisciplinaRepository
    {
        public DisciplinaRepository(MiBaseContext context) : base(context)   
        { 
        }
    }
}
