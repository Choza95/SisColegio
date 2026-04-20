namespace SisColegio.Dtos
{
    public class EstudiantesDto
    {
        public int? IdUsuario { get; set; }

        public int? IdPadre { get; set; }
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Ci { get; set; }

        public int? Edad { get; set; }
    }
}
