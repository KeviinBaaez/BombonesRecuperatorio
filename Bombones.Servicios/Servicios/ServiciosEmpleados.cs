using Bombones.Datos.Interfaces;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;
using Bombones.Servicios.Intefaces;
using System.Data.SqlClient;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosEmpleados : IServiciosEmpleados
    {
        private readonly IRepositorioEmpleados? _repositorio;
        private readonly string? _cadena;
        public ServiciosEmpleados(IRepositorioEmpleados? repositorio, string? cadena)
        {
            _repositorio = repositorio;
            _cadena = cadena;
        }



        public List<EmpleadosListDto>? GetLista(Orden orden, Pais? paisSeleccionado)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repositorio!.GetLista(conn, orden, paisSeleccionado);
            }
        }

    }
}
