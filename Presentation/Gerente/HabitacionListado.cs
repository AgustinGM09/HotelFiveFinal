using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Gerente
{
    public partial class HabitacionListado : Form
    {
        private int ultimoIdHabitacion = 1;
        public HabitacionListado()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            ReporteGerente reporteGerente = new ReporteGerente();
            reporteGerente.Show();
            this.Hide();
        }

        private void btnAjustes_Click(object sender, EventArgs e)
        {
            PerfilGerente perfil = new PerfilGerente();
            perfil.Show();
            this.Hide();
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void btnMaximizar_Click_1(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            //permitir solo la entrada de dígitos numéricos y teclas de control (como Retroceso o Eliminar)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada del carácter no válido
            }
        }

        // Evento KeyPress para validar campo txtNombre
        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada del carácter no válido
            }
        }

        private void txtTipodeHabitacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada del carácter no válido
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarHabitacion agregarHabitacion = new AgregarHabitacion();
            if (agregarHabitacion.ShowDialog() == DialogResult.OK)
            {
                // Cuando el formulario de agregar se cierra con DialogResult.OK,
                // puedes acceder a los datos ingresados en el formulario de agregar
                string nombreTipoHabitacion = agregarHabitacion.NombreTipoHabitacionIngresado;
                string descripcion = agregarHabitacion.DescripcionIngresada;
                decimal precio = agregarHabitacion.PrecioIngresado;
                int idHabitacion = ultimoIdHabitacion++;

                // Agrega los datos al DataGridView en la vista principal
                dataGridHabitacion.Rows.Add(idHabitacion,nombreTipoHabitacion, descripcion, precio);
            }
        }
    }
}
