using SisColegio.Dtos;

namespace SisColegio.Interfaces
{
    public interface ICursoService
    {
        Task<IEnumerable<CursoDto>> GetAllAsync();
        Task<CursoDto?> GetByIdAsync(int id);
        Task<CursoDto> AddAsync(CursoDto dto);
        Task<bool> UpdateAsync(int id, CursoDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
