namespace SisColegio.Dtos
{
    public class InscripcionesCursoDto
    {
        public int? IdEstudiante { get; set; }
        public int Id { get; set; }

        public int? IdCurso { get; set; }

        public DateOnly? FechaInscrito { get; set; }

        public string? NombreEstudiante { get; set; }
        public string? Ci { get; set; }
        public string? Edad { get; set; }


    }
}
