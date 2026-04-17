using SisColegio.Data;
using SisColegio.Interfaces;

namespace SisColegio.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MiBaseContext _context;
        private IUsuarioRepository? _usuarioRepository;
        private IProfesoresRepository? _profesoresRepository;

        public UnitOfWork(MiBaseContext context)
        {
            _context = context;
        }
        public IUsuarioRepository Usuarios
           => _usuarioRepository ??= new UsuarioRepository(_context);
        public IProfesoresRepository Profesores
          => _profesoresRepository ??= new ProfesoresRepository(_context);


        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
