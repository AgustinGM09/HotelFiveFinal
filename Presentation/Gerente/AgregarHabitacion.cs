using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Gerente
{
    public partial class AgregarHabitacion : Form
    {
        public string NombreTipoHabitacionIngresado { get { return txtTipodeHabitacion.Text; } }
        public string DescripcionIngresada { get { return txtDescripcion.Text; } }
        public decimal PrecioIngresado { get { return decimal.Parse(txtPrecio.Text); } }
        public AgregarHabitacion()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTipodeHabitacion.Text) ||
        string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
        string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // No continúa si falta algún dato
            }

            // Valida que el campo de precio sea un número decimal válido
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido en el campo de precio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // No continúa si el valor de precio no es válido
            }

            // Si pasa todas las validaciones, establece el resultado en OK
            this.DialogResult = DialogResult.OK;

            // Cierra el formulario de agregar
            this.Close();
        }
    }
}
