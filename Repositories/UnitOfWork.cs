using SisColegio.Data;
using SisColegio.Interfaces;

namespace SisColegio.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MiBaseContext _context;
        private IUsuarioRepository? _usuarioRepository;
        private IProfesoresRepository? _profesoresRepository;
        private ITrimestreRepository? _trimestreRepository;
        private IPadreRepository? _padreRepository;
        private INotaRepository? _notaRepository;
        private IMateriaRepository? _materiaRepository;
        private IInscripcionesRepository? _inscripcionesRepository;
        private IEvaluacionesRepository? _evaluacionesRepository;
        private IEstudiantesRepository? _estudiantesRepository;
        private IDisciplinaRepository? _disciplinaRepository;
        private ICursoRepository? _cursoRepository;
        private IAsignacioneRepository? _asignacioneRepository;

        public UnitOfWork(MiBaseContext context)
        {
            _context = context;
        }
        public IUsuarioRepository Usuarios
           => _usuarioRepository ??= new UsuarioRepository(_context);
        public IProfesoresRepository Profesores
          => _profesoresRepository ??= new ProfesoresRepository(_context);
        public ITrimestreRepository Trimestre
          => _trimestreRepository ??= new TrimestreRepository(_context);
        public IPadreRepository Padre
          => _padreRepository ??= new PadreRepository(_context);
        public INotaRepository Nota
          => _notaRepository ??= new NotaRepository(_context);
        public IMateriaRepository Materia
         => _materiaRepository ??= new MateriaRepository(_context);
        public IInscripcionesRepository Inscripciones
         => _inscripcionesRepository ??= new InscripcionesRepository(_context);
        public IEvaluacionesRepository Evaluacione
         => _evaluacionesRepository ??= new EvaluacionesRepository(_context);
        public IEstudiantesRepository Estudiante
         => _estudiantesRepository ??= new EstudianteRepository(_context);
        public IDisciplinaRepository Disciplina
         => _disciplinaRepository ??= new DisciplinaRepository(_context);
        public ICursoRepository Curso
         => _cursoRepository ??= new CursoRepository(_context);
        public IAsignacioneRepository Asignacione
         => _asignacioneRepository ??= new AsignacioneRepository(_context);


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
