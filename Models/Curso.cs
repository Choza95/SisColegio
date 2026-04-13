using System;
using System.Collections.Generic;

namespace SisColegio.Models;

public partial class Curso : BaseEntity
{
    public string? Nombre { get; set; }

    public virtual ICollection<Asignacione> Asignaciones { get; set; } = new List<Asignacione>();

    public virtual ICollection<Inscripcione> Inscripciones { get; set; } = new List<Inscripcione>();
}
