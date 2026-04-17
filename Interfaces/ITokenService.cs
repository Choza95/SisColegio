using SisColegio.Dtos;
using SisColegio.Models;

namespace SisColegio.Interfaces
{
    public interface ITokenService
    {
        AuthResponseDto GenerateToken(Usuario usuario);
    }
}

