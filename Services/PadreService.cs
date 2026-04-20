using AutoMapper;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Services
{
    public class PadreService : IPadreService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public PadreService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<IEnumerable<PadreDto>> GetAllAsync()
        {
            var padre = await _unitOfWork.Padre.GetAllAsync();
            return _mapper.Map<IEnumerable<PadreDto>>(padre);
        }

        public async Task<PadreDto?> GetByIdAsync(int id)
        {
            var padre = await _unitOfWork.Padre.GetByIdAsync(id);
            if (padre == null)
                return null;

            return _mapper.Map<PadreDto>(padre);
        }
        public async Task<PadreDto> AddAsync(PadreDto dto)
        {
            var objeto = _mapper.Map<Padre>(dto);

            await _unitOfWork.Padre.AddAsync(objeto);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<PadreDto>(objeto);
        }
        public async Task<bool> UpdateAsync(int id, PadreDto dto)
        {
            if (id != dto.Id)
                return false;

            var objeto = await _unitOfWork.Padre.GetByIdAsync(id);
            if (objeto == null)
                return false;

            
            objeto.NombreCompleto = dto.NombreCompleto;
            objeto.Celular = dto.Celular;
            objeto.Ci = dto.Ci;
            

            _unitOfWork.Padre.Update(objeto);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var padre = await _unitOfWork.Padre.GetByIdAsync(id);
            if (padre == null)
                return false;

            await _unitOfWork.Padre.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
