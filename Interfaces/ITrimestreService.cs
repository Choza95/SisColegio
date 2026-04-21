using SisColegio.Dtos;

namespace SisColegio.Interfaces
{
    public interface ITrimestreService
    {
        Task<IEnumerable<TrimestreDto>> GetAllAsync();
        Task<TrimestreDto?> GetByIdAsync(int id);
        Task<TrimestreDto> AddAsync(TrimestreAddDto dto);
        Task<bool> UpdateAsync(int id, TrimestreAddDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
