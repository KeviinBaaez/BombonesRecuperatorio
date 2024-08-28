using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;
using Bombones.Servicios.Intefaces;
using Bombones.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Bombones.Windows.Formularios
{
    public partial class frmEmpleados : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private readonly IServiciosEmpleados? _servicio;
        private List<EmpleadosListDto>? lista;
        Orden orden = Orden.Ninguno;
        FiltroContexto filtro;
        private Pais? paisFiltro = null;

        public frmEmpleados(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _servicio = serviceProvider?.GetService<IServiciosEmpleados>();
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            try
            {
                if (_servicio is null)
                {
                    throw new ApplicationException("dependencias no cargadas");
                }
                lista = _servicio.GetLista(orden);
                MostrarDatos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarDatos()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            if (lista is not null)
            {
                foreach (var item in lista)
                {
                    var r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, item);
                    GridHelper.AgregarFila(r, dgvDatos);
                }

            }
        }



        private void nombreAZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lista = _servicio.GetLista(Orden.PaisAZ);
        }

        private void nombreZAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lista = _servicio.GetLista(Orden.PaisZA);
        }

        private void apellidoAZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lista = _servicio.GetLista(Orden.ProvinciaEstadoAZ);
        }

        private void apellidoZAToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            lista = _servicio.GetLista(Orden.ProvinciaEstadoZA);
        }

        private void tsbFiltrar_Click(object sender, EventArgs e)
        {
            frmFormularioFiltro frm = new frmFormularioFiltro(_serviceProvider, filtro);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            paisFiltro = frm.GetPais();
            if (paisFiltro is null) return;
  

            lista = _servicio.GetLista(orden, paisFiltro);
            MostrarDatos();
            tsbFiltrar.Enabled = false;
        }
    }
}
