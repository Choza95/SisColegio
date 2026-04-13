using SisColegio.Models;

namespace SisColegio.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByEmailAsync(string email);
    }
}

