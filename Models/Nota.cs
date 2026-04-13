using System;
using System.Collections.Generic;

namespace SisColegio.Models;

public partial class Nota : BaseEntity
{
    public int? IdEstudiante { get; set; }

    public int? IdEvaluacion { get; set; }

    public decimal? Nota1 { get; set; }


    public virtual Estudiante? IdEstudianteNavigation { get; set; }

    public virtual Evaluacione? IdEvaluacionNavigation { get; set; }
}
