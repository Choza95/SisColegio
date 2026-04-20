namespace SisColegio.Dtos
{
    public class TrimestreDto
    {
        public string? Nombre { get; set; }
        public int Id { get; set; }

        public DateOnly? FechaInicio { get; set; }

        public DateOnly? FechaFin { get; set; }
    }
}
