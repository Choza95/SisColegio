using SisColegio.Dtos;

namespace SisColegio.Interfaces
{
    public interface ICursoService
    {
        Task<IEnumerable<CursoDto>> GetAllAsync();
        Task<CursoDto?> GetByIdAsync(int id);
        Task<CursoDto> AddAsync(CursoAddDto dto);
        Task<bool> UpdateAsync(int id, CursoAddDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
