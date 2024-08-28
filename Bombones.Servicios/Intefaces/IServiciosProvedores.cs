using Bombones.Entidades.Entidades;

namespace Bombones.Servicios.Intefaces
{
    public interface IServiciosProvedores
    {
        bool Existe(Provedores provedor);
        List<Provedores>? GetLista();
        void Guardar(Provedores provedor);
    }
}