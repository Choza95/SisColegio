using Microsoft.EntityFrameworkCore;
using SisColegio.Data;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Repositories
{
    public class ProfesoresRepository : GenericRepository<Profesores>, IProfesoresRepository
    {
        public ProfesoresRepository(MiBaseContext context) : base(context)
        {
        }

    }
}