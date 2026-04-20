using SisColegio.Dtos;
using SisColegio.Models;

namespace SisColegio.Interfaces
{
    public interface IInscripcionesService
    {
        Task<IEnumerable<InscripcionesDto>> GetAllAsync();
        Task<InscripcionesDto?> GetByIdAsync(int id);
        Task<InscripcionesDto> AddAsync(InscripcionesDto dto);
        Task<bool> UpdateAsync(int id, InscripcionesDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
