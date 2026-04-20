namespace SisColegio.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository Usuarios { get; }
        IProfesoresRepository Profesores { get; }
        ITrimestreRepository Trimestre { get; }
        IPadreRepository Padre { get; }
        INotaRepository Nota { get; }
        IMateriaRepository Materia { get; }
        IInscripcionesRepository Inscripciones { get; }
        IEvaluacionesRepository Evaluacione { get; }
        IEstudiantesRepository Estudiante { get; }
        IDisciplinaRepository Disciplina { get; }
        ICursoRepository Curso { get; }
        IAsignacioneRepository Asignacione { get; }
        Task<int> SaveChangesAsync();
    }
}

