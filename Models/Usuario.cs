using System;
using System.Collections.Generic;

namespace SisColegio.Models;

public partial class Usuario : BaseEntity
{
    public string? NombreUsuario { get; set; }

    public string? Email { get; set; }

    public string? Clave { get; set; }

    public string? Rol { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Estudiante? Estudiante { get; set; }

    public virtual Padre? Padre { get; set; }

    public virtual Profesore? Profesore { get; set; }
}
