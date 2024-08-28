using Bombones.Entidades.Entidades;

namespace Bombones.Windows.Formularios
{
    public partial class frmProveedoresAE : Form
    {
        private Provedores? provedor;
        public frmProveedoresAE()
        {
            InitializeComponent();
        }

        public Provedores? GetProvedor()
        {
            return provedor;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtProveedor.Text))
            {
                valido = false;
                errorProvider1.SetError(txtProveedor, "El Campo es necesario");
            }
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                valido = false;
                errorProvider1.SetError(txtTelefono, "El Campo es necesario");
            }
            if (string.IsNullOrEmpty(txtMail.Text))
            {
                valido = false;
                errorProvider1.SetError(txtMail, "El Campo es necesario");
            }
            return valido;
        }
    }
}
