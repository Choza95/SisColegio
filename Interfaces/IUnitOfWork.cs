namespace SisColegio.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository Usuarios { get; }
        IProfesoresRepository Profesores { get; }
        Task<int> SaveChangesAsync();
    }
}

