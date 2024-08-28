namespace Bombones.Entidades.Dtos
{
    public class EmpleadosListDto
    {
        public int EmpleadoId { get; set; }
        public string NombreEmpleado { get; set; } = null!;
        public string ApeelidoEmpleado { get; set; } = null!;
        public DateTime FechaContratacion { get; set; }
        public string Direccion { get; set; }
        public string? NombreCiudad { get; set; }
        public string? NombrePais { get; set; }
        public string? NombreProvinciaEstado { get; set; }
    }
}
