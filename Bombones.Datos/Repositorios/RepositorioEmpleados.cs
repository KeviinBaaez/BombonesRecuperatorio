using Bombones.Datos.Interfaces;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;
using Dapper;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioEmpleados : IRepositorioEmpleados
    {
        public RepositorioEmpleados()
        {

        }

        public List<EmpleadosListDto>? GetLista(SqlConnection conn, Orden orden, Pais? paisSeleccionado)
        {
            string selectQuery = @"SELECT * FROM Empleados e
                                    INNER JOIN Paises p on e.PaisId=p.PaisId";
            List<string> conditional = new List<string>();
            string finalQuery = string.Empty;

            switch (orden)
            {
                case Orden.PaisAZ:
                    conditional.Add(" ORDER BY NOMBRE");
                    break;
                case Orden.PaisZA:
                    conditional.Add(" ORDER BY NOMBRE DESC");
                    break;
                case Orden.ProvinciaEstadoAZ:
                    conditional.Add(" ORDER BY APELLIDO ");
                    break;

                case Orden.ProvinciaEstadoZA:
                    conditional.Add(" ORDER BY APELLIDO DESC");
                    break;
                default:
                    break;

            }
            if (paisSeleccionado is not null)
            {
                conditional.Add(" WHERE e.PaisId=@e.PaisId");
            }
            if (conditional.Any())
            {
                selectQuery += string.Join(" AND ", conditional);
            }
            return conn.Query<EmpleadosListDto>(selectQuery, new { PaisId=paisSeleccionado?.PaisId }).ToList();
        }

    }
}
