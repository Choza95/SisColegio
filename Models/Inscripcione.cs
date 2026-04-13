using System;
using System.Collections.Generic;

namespace SisColegio.Models;

public partial class Inscripcione : BaseEntity
{
    public int? IdEstudiante { get; set; }

    public int? IdCurso { get; set; }

    public DateOnly? FechaInscrito { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Curso? IdCursoNavigation { get; set; }

    public virtual Estudiante? IdEstudianteNavigation { get; set; }
}
