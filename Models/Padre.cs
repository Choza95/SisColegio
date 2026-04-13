using System;
using System.Collections.Generic;

namespace SisColegio.Models;

public partial class Padre : BaseEntity
{
    public int? IdUsuario { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Celular { get; set; }

    public string? Ci { get; set; }


    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
