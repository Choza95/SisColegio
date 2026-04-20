namespace SisColegio.Dtos
{
    public class DisciplinaDto
    {
        public int? IdEstudiante { get; set; }

        public int? IdAsignacion { get; set; }
        public int Id { get; set; }

        public string? Tipo { get; set; }

        public string? Descripcion { get; set; }

        public DateTime? Fecha { get; set; }
    }
}
