using AutoMapper;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Services
{
    public class EstudiantesService : IEstudiantesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        public EstudiantesService(
                         IUnitOfWork unitOfWork,
                         IMapper mapper,
                         IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<IEnumerable<EstudiantesDto>> GetAllAsync()
        {
            var estudiantes = await _unitOfWork.Estudiante.GetAllAsync();
            return _mapper.Map<IEnumerable<EstudiantesDto>>(estudiantes);
        }

        public async Task<EstudiantesDto?> GetByIdAsync(int id)
        {
            var estudiantes = await _unitOfWork.Estudiante.GetByIdAsync(id);
            if (estudiantes == null)
                return null;

            return _mapper.Map<EstudiantesDto>(estudiantes);
        }
        public async Task<EstudiantesDto> AddAsync(EstudiantesDto dto)
        {
            var objeto = _mapper.Map<Estudiante>(dto);

            await _unitOfWork.Estudiante.AddAsync(objeto);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<EstudiantesDto>(objeto);
        }

        public async Task<bool> UpdateAsync(int id, EstudiantesDto dto)
        {
            if (id != dto.Id)
                return false;

            var objeto = await _unitOfWork.Estudiante.GetByIdAsync(id);
            if (objeto == null)
                return false;

            objeto.IdUsuario = dto.IdUsuario;
            objeto.IdPadre = dto.IdPadre;
            objeto.Nombre = dto.Nombre;
            objeto.Apellido = dto.Apellido;
            objeto.Ci = dto.Ci;
            objeto.Edad = dto.Edad;

            _unitOfWork.Estudiante.Update(objeto);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var estudiantes = await _unitOfWork.Estudiante.GetByIdAsync(id);
            if (estudiantes == null)
                return false;

            await _unitOfWork.Estudiante.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}