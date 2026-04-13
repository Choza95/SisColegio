using System;
using System.Collections.Generic;

namespace SisColegio.Models;

public partial class Estudiante : BaseEntity
{
    public int? IdUsuario { get; set; }

    public int? IdPadre { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Ci { get; set; }

    public int? Edad { get; set; }


    public virtual ICollection<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

    public virtual Padre? IdPadreNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Inscripcione> Inscripciones { get; set; } = new List<Inscripcione>();

    public virtual ICollection<Nota> Nota { get; set; } = new List<Nota>();
}
