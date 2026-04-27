using AutoMapper;
using SisColegio.Dtos;
using SisColegio.Models;

namespace SisColegio.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<UsuarioCreateDto, Usuario>().ReverseMap();
            CreateMap<UsuarioUpdateDto, Usuario>().ReverseMap();
            CreateMap<Profesores, ProfesoresDto>().ReverseMap();
            CreateMap<Trimestre, TrimestreDto>().ReverseMap();  
            CreateMap<Padre, PadreDto>().ReverseMap();
            CreateMap<Materia, MateriaDto>().ReverseMap();
            CreateMap<Inscripcione, InscripcionesDto>().ReverseMap();
            CreateMap<Evaluacione, EvaluacionesDto>().ReverseMap();
            CreateMap<Estudiante, EstudiantesDto>().ReverseMap();
            CreateMap<Disciplina, DisciplinaDto>().ReverseMap();
            CreateMap<Curso, CursoDto>().ReverseMap();
            CreateMap<Curso, CursoAddDto>().ReverseMap();
            CreateMap<Asignacione, AsignacioneDto>().ReverseMap();
            CreateMap<Nota,  NotaDto>().ReverseMap();
            CreateMap<Asignacione, AsignacioneAddDto>().ReverseMap();
        }
    }
}

