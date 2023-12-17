using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Empleado
{
    public partial class ReservaAgregar : Form
    {
        public int IdClienteIngresado { get { return int.Parse(txtIdCliente.Text); } }
        public int IdUsuarioIngresado { get { return int.Parse(txtIdUsuario.Text); } }
        public int IdTipoDePagoIngresado { get { return int.Parse(txtIdTipoDePago.Text); } }
        public string EstadoIngresado { get { return txtEstado.Text; } }
        public DateTime FechaInicioIngresada { get { return dateFechaInicio.Value; } }
        public DateTime FechaFinIngresada { get { return dateFechaFin.Value; } }
        public decimal SubTotalIngresado { get { return decimal.Parse(txtSubTotal.Text); } }
        public ReservaAgregar()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdCliente.Text) ||
        string.IsNullOrWhiteSpace(txtIdUsuario.Text) ||
        string.IsNullOrWhiteSpace(txtIdTipoDePago.Text) ||
        string.IsNullOrWhiteSpace(txtEstado.Text) ||
        dateFechaInicio.Value == null ||
        dateFechaFin.Value == null ||
        string.IsNullOrWhiteSpace(txtSubTotal.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // No continúa si falta algún dato
            }

            if (!int.TryParse(txtIdCliente.Text, out int idCliente) ||
        !int.TryParse(txtIdUsuario.Text, out int idUsuario) ||
        !int.TryParse(txtIdTipoDePago.Text, out int idTipoDePago) ||
        !decimal.TryParse(txtSubTotal.Text, out decimal subTotal))
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos en los campos correspondientes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // No continúa si algún valor no es válido
            }
            this.DialogResult = DialogResult.OK;

            // Cierra el formulario de agregar.
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
