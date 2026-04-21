using AutoMapper;
using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Services
{
    public class CursoService : ICursoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        public CursoService(
                             IUnitOfWork unitOfWork,
                             IMapper mapper,
                             IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<IEnumerable<CursoDto>> GetAllAsync()
        {
            var curso = await _unitOfWork.Curso.GetAllAsync();
            return _mapper.Map<IEnumerable<CursoDto>>(curso);
        }

        public async Task<CursoDto?> GetByIdAsync(int id)
        {
            var curso = await _unitOfWork.Curso.GetByIdAsync(id);
            if (curso == null)
                return null;

            return _mapper.Map<CursoDto>(curso);
        }
        public async Task<CursoDto> AddAsync(CursoAddDto dto)
        {
            var objeto = _mapper.Map<Curso>(dto);

            await _unitOfWork.Curso.AddAsync(objeto);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CursoDto>(objeto);
        }

        public async Task<bool> UpdateAsync(int id, CursoAddDto dto)
        {
           
            var objeto = await _unitOfWork.Curso.GetByIdAsync(id);
            if (objeto == null)
                return false;

            objeto.Nombre = dto.Nombre;
            

            _unitOfWork.Curso.Update(objeto);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var curso = await _unitOfWork.Curso.GetByIdAsync(id);
            if (curso == null)
                return false;

            await _unitOfWork.Curso.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResponse<IEnumerable<CursoDto>>> GetAllAsync(PostQueryFilter filter)
        {
            var cursos = await _unitOfWork.Curso.GetAllAsync(filter);
            var cursosDto = _mapper.Map<IEnumerable<CursoDto>>(cursos);

            return new ApiResponse<IEnumerable<CursoDto>>(cursosDto, cursos.MetaData);
        }
    }
}