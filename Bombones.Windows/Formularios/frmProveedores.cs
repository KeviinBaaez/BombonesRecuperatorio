using Bombones.Entidades.Entidades;
using Bombones.Servicios.Intefaces;
using Bombones.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Bombones.Windows.Formularios
{
    public partial class frmProveedores : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private readonly IServiciosProvedores? _servicio;
        private List<Provedores>? lista;

        public frmProveedores(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _servicio = serviceProvider?.GetService<IServiciosProvedores>();
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            try
            {
                if (_servicio is null)
                {
                    throw new ApplicationException("dependencias no cargadas");
                }
                lista = _servicio.GetLista();
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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmProveedoresAE frm = new frmProveedoresAE() { Text = "Nuevo Provedor" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            Provedores provedor = frm.GetProvedor();
            if (provedor is null) return;
            try
            {
                if (_servicio is null)
                {
                    throw new ApplicationException("Dependencias no cargadas");
                }
                if (_servicio.Existe(provedor))
                {

                    _servicio.Guardar(provedor);
                    var r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, provedor);
                    GridHelper.AgregarFila(r, dgvDatos);
                    MessageBox.Show("Registro agregado",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registro existente",
                        "error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
