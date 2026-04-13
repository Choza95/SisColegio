using System;
using System.Collections.Generic;

namespace SisColegio.Models;

public partial class Profesore : BaseEntity
{
    public int? IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Ci { get; set; }

    public string? Celular { get; set; }

    public string? Titulo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Asignacione> Asignaciones { get; set; } = new List<Asignacione>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
