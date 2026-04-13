using System;
using System.Collections.Generic;

namespace SisColegio.Models;

public partial class Evaluacione : BaseEntity
{
    public int? IdAsignacion { get; set; }

    public int? IdTrimestre { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public string? Tipo { get; set; }

    public decimal? Porcentaje { get; set; }

    public DateTime? FechaPublicacion { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Asignacione? IdAsignacionNavigation { get; set; }

    public virtual Trimestre? IdTrimestreNavigation { get; set; }

    public virtual ICollection<Nota> Nota { get; set; } = new List<Nota>();
}
