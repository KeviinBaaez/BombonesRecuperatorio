using Bombones.Entidades.Entidades;
using System.Data.SqlClient;

namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioProvedores
    {
        void Agregar(Provedores provedor, SqlConnection conn, SqlTransaction tran);
        bool Existe(Provedores provedor, SqlConnection conn);
        List<Provedores>? GetLista(SqlConnection conn);
    }
}