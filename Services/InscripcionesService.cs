using AutoMapper;
using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Services
{
    public class InscripcionesService : IInscripcionesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        public InscripcionesService(
                         IUnitOfWork unitOfWork,
                         IMapper mapper,
                         IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<IEnumerable<InscripcionesDto>> GetAllAsync()
        {
            var inscripciones = await _unitOfWork.Inscripciones.GetAllAsync();
            return _mapper.Map<IEnumerable<InscripcionesDto>>(inscripciones);
        }

        public async Task<InscripcionesDto?> GetByIdAsync(int id)
        {
            var inscripciones = await _unitOfWork.Inscripciones.GetByIdAsync(id);
            if (inscripciones == null)
                return null;

            return _mapper.Map<InscripcionesDto>(inscripciones);
        }

        public IEnumerable<InscripcionesDto?> GetinscripcionesByEstudiante(int idEstudiante)
        {
            var inscripciones = _unitOfWork.Inscripciones.GetinscripcionesByEstudiante(idEstudiante);

            if (inscripciones == null)
                return null;
            return _mapper.Map<IEnumerable<InscripcionesDto>>(inscripciones);
        }


        public async Task<InscripcionesDto> AddAsync(InscripcionesDto dto)
        {
            dto.FechaInscrito = DateOnly.FromDateTime(DateTime.Now);
            var objeto = _mapper.Map<Inscripcione>(dto);

            await _unitOfWork.Inscripciones.AddAsync(objeto);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<InscripcionesDto>(objeto);
        }

        public async Task<bool> UpdateAsync(int id, InscripcionesDto dto)
        {
            if (id != dto.Id)
                return false;

            var objeto = await _unitOfWork.Inscripciones.GetByIdAsync(id);
            if (objeto == null)
                return false;

            objeto.IdEstudiante = dto.IdEstudiante; 
            objeto.IdCurso = dto.IdCurso; 
            objeto.FechaInscrito = dto.FechaInscrito; 

            _unitOfWork.Inscripciones.Update(objeto);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var inscripciones = await _unitOfWork.Inscripciones.GetByIdAsync(id);
            if (inscripciones == null)
                return false;

            await _unitOfWork.Inscripciones.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResponse<IEnumerable<InscripcionesDto>>> GetAllAsync(PostQueryFilter filter)
        {
            var inscripciones = await _unitOfWork.Inscripciones.GetAllAsync(filter);
            var inscripcionesDto = _mapper.Map<IEnumerable<InscripcionesDto>>(inscripciones);

            return new ApiResponse<IEnumerable<InscripcionesDto>>(inscripcionesDto, inscripciones.MetaData);
        }


    }
}