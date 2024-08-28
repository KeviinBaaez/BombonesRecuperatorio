using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;
using System.Data.SqlClient;

namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioEmpleados
    {
        List<EmpleadosListDto>? GetLista(SqlConnection conn, Orden orden, Pais? paisSeleccionado = null);
    }
}