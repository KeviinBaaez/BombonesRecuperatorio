using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;

namespace Bombones.Servicios.Intefaces
{
    public interface IServiciosEmpleados
    {
        List<EmpleadosListDto>? GetLista(Orden orden, Pais? pais = null);
    }
}