using SisColegio.Data;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Repositories
{
    public class EstudianteRepository : GenericRepository<Estudiante>, IEstudiantesRepository
    {
        public EstudianteRepository(MiBaseContext context) : base(context)
        {
        }
    }
}
