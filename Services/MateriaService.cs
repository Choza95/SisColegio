using AutoMapper;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Services
{
    public class MateriaService : IMateriaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public MateriaService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<IEnumerable<MateriaDto>> GetAllAsync()
        {
            var materia = await _unitOfWork.Materia.GetAllAsync();
            return _mapper.Map<IEnumerable<MateriaDto>>(materia);
        }

        public async Task<MateriaDto?> GetByIdAsync(int id)
        {
            var materia = await _unitOfWork.Materia.GetByIdAsync(id);
            if (materia == null)
                return null;

            return _mapper.Map<MateriaDto>(materia);
        }
        public async Task<MateriaDto> AddAsync(MateriaDto dto)
        {
            var objeto = _mapper.Map<Materia>(dto);

            await _unitOfWork.Materia.AddAsync(objeto);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<MateriaDto>(objeto);
        }

        public async Task<bool> UpdateAsync(int id, MateriaDto dto)
        {
            if (id != dto.Id)
                return false;

            var objeto = await _unitOfWork.Materia.GetByIdAsync(id);
            if (objeto == null)
                return false;

            objeto.Nombre = dto.Nombre;
            

            _unitOfWork.Materia.Update(objeto);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var materia = await _unitOfWork.Materia.GetByIdAsync(id);
            if (materia == null)
                return false;

            await _unitOfWork.Materia.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}