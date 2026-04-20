using AutoMapper;
using SisColegio.Dtos;
using SisColegio.Models;

namespace SisColegio.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioCreateDto, Usuario>();
            CreateMap<UsuarioUpdateDto, Usuario>();
            CreateMap<Profesores, ProfesoresDto>();
            CreateMap<Trimestre, TrimestreDto>();
            CreateMap<Padre, PadreDto>();
            CreateMap<Materia, MateriaDto>();
            CreateMap<Inscripcione, InscripcionesDto>();
            CreateMap<Evaluacione, EvaluacionesDto>();
            CreateMap<Estudiante, EstudiantesDto>();
            CreateMap<Disciplina, DisciplinaDto>();
            CreateMap<Curso, CursoDto>();
            CreateMap<Asignacione, AsignacioneDto>();
        }
    }
}

