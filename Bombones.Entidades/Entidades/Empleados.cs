namespace Bombones.Entidades.Entidades
{
    public class Empleados
    {
        public int EmpleadoId { get; set; }
        public string NombreEmpleado { get; set; } = null!;
        public string ApeelidoEmpleado { get; set; } = null!;
        public DateTime FechaContratacion { get; set; }
        public string Direccion { get; set; }
        public Ciudad CiudadId { get; set; }
        public ProvinciaEstado ProvinciaEstadoId { get; set; }
        public Pais PaisId { get; set; }
    }
}
