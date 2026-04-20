namespace SisColegio.Dtos
{
    public class InscripcionesDto
    {
        public int? IdEstudiante { get; set; }
        public int Id { get; set; }

        public int? IdCurso { get; set; }

        public DateOnly? FechaInscrito { get; set; }
    }
}
