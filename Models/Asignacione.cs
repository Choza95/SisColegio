    using System;
    using System.Collections.Generic;

    namespace SisColegio.Models;

    public partial class Asignacione : BaseEntity
    {

        public int? IdProfesor { get; set; }

        public int? IdMateria { get; set; }

        public int? IdCurso { get; set; }

        public virtual ICollection<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

        public virtual ICollection<Evaluacione> Evaluaciones { get; set; } = new List<Evaluacione>();

        public virtual Curso? IdCursoNavigation { get; set; }

        public virtual Materia? IdMateriaNavigation { get; set; }

        public virtual Profesores? IdProfesorNavigation { get; set; }
    }
