using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Bombones.Servicios.Intefaces;
using System.Data.SqlClient;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosProvedores : IServiciosProvedores
    {
        private readonly IRepositorioProvedores? _repositorio;
        private readonly string? _cadena;

        public ServiciosProvedores(IRepositorioProvedores? repositorio,
        string? cadena)
        {
            _repositorio = repositorio;
            _cadena = cadena;
        }

        public bool Existe(Provedores provedor)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repositorio!.Existe(provedor, conn);
            }
        }

        public List<Provedores>? GetLista()
        {
            using (var conn = new SqlConnection(_cadena))
            {
               return _repositorio!.GetLista(conn);
            }
        }

        public void Guardar(Provedores provedor)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                using(var tran = conn.BeginTransaction())
                {
                    try
                    {
                        _repositorio!.Agregar(provedor, conn, tran);
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
