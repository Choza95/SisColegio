using System;
using System.Collections.Generic;

namespace SisColegio.Models;

public partial class Materia : BaseEntity
{
    public string? Nombre { get; set; }


    public virtual ICollection<Asignacione> Asignaciones { get; set; } = new List<Asignacione>();
}
