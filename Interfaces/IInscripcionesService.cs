using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Models;

namespace SisColegio.Interfaces
{
    public interface IInscripcionesService
    {
        Task<IEnumerable<InscripcionesDto>> GetAllAsync();
        Task<InscripcionesDto?> GetByIdAsync(int id);
        IEnumerable<InscripcionesDto?> GetinscripcionesByEstudiante(int idEstudiante);
        Task<InscripcionesDto> AddAsync(InscripcionesDto dto);
        Task<bool> UpdateAsync(int id, InscripcionesDto dto);
        Task<bool> DeleteAsync(int id);
        Task<ApiResponse<IEnumerable<InscripcionesDto>>> GetAllAsync(PostQueryFilter filter);
    }
}
