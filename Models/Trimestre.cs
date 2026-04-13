using System;
using System.Collections.Generic;

namespace SisColegio.Models;

public partial class Trimestre : BaseEntity
{
    public string? Nombre { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Evaluacione> Evaluaciones { get; set; } = new List<Evaluacione>();
}
