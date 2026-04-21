namespace SisColegio.Dtos
{
    public class TrimestreAddDto
    {
        public string? Nombre { get; set; }
        public DateOnly? FechaInicio { get; set; }

        public DateOnly? FechaFin { get; set; }
    }
}
