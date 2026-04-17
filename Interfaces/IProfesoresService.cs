using SisColegio.Dtos;

namespace SisColegio.Interfaces
{
    public interface IProfesoresService
    {
        Task<IEnumerable<ProfesoresDto>> GetAllAsync();
        Task<ProfesoresDto?> GetByIdAsync(int id);
        Task<ProfesoresDto> AddAsync(ProfesoresDto dto);
        Task<bool> UpdateAsync(int id, ProfesoresDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
