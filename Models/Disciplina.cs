using System;
using System.Collections.Generic;

namespace SisColegio.Models;

public partial class Disciplina : BaseEntity
{
    public int? IdEstudiante { get; set; }

    public int? IdAsignacion { get; set; }

    public string? Tipo { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Asignacione? IdAsignacionNavigation { get; set; }

    public virtual Estudiante? IdEstudianteNavigation { get; set; }
}
