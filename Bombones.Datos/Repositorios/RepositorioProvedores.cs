using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Dapper;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioProvedores : IRepositorioProvedores
    {
        public RepositorioProvedores()
        {
            
        }

        public void Agregar(Provedores provedor, SqlConnection conn, SqlTransaction tran)
        {
            string insertQuery = @"INSERT INTO Proveedores 
                (NombreProveedor, telefono, Email) 
                VALUES (@NombreProveedor, @Telefono, @Email); 
                SELECT CAST(SCOPE_IDENTITY() as int)";

            int primaryKey = conn.QuerySingle<int>(insertQuery, provedor, tran);
            if (primaryKey > 0)
            {
                provedor.ProvedorId = primaryKey;
                return;
            }
            throw new Exception("No se pudo agregar el registro");
        }

        public bool Existe(Provedores provedor, SqlConnection conn)
        {
            string selectQuery = @"SELECT COUNT(*) FROM Proveedores ";
            string finalQuery = string.Empty;
            string conditional = string.Empty;
            if (provedor.ProvedorId == 0)
            {
                conditional = " WHERE NombreProveedor=@NombreProveedor";
            }
            else
            {
                conditional = @" WHERE NombreProveedor=@NombreProveedor
                            AND ProveedorId=@ProveedorId";
            }
            finalQuery = string.Concat(selectQuery, conditional);
            return conn.QuerySingle<int>(finalQuery, provedor) > 0;
        }

        public List<Provedores>? GetLista(SqlConnection conn)
        {
            string selectQuery = @"SELECT ProveedorId, NombreProveedor, 
                    Telefono, Email FROM Proveedores";
            return conn.Query<Provedores>(selectQuery).ToList();
        }
    }
}
