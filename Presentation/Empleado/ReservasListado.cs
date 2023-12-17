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
using Presentation.Empleado;

namespace Presentation.Empleado
{
    public partial class ReservasListado : Form
    {
        private int ultimoId = 1;
        public ReservasListado()
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

        private void btnAjustes_Click(object sender, EventArgs e)
        {
            PerfilEmpleado perfil = new PerfilEmpleado();
            perfil.Show();
            this.Hide();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            HistorialReserva reporteEmpleado = new HistorialReserva();
            reporteEmpleado.Show();
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



        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            //permitir solo la entrada de dígitos numéricos y teclas de control (como Retroceso o Eliminar)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada del carácter no válido
            }
        }

        // Evento KeyPress para validar campo txtNombre
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada del carácter no válido
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada del carácter no válido
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ReservaAgregar reservaAgregar = new ReservaAgregar();
            if (reservaAgregar.ShowDialog() == DialogResult.OK)
            {
                // Cuando el formulario de agregar se cierra con DialogResult.OK, significa que el usuario
                // hizo clic en el botón "Aceptar" en el formulario de agregar.

                // Recupera los datos ingresados desde el formulario de agregar
                int idCliente = reservaAgregar.IdClienteIngresado;
                int idUsuario = reservaAgregar.IdUsuarioIngresado;
                int idTipoDePago = reservaAgregar.IdTipoDePagoIngresado;
                string estado = reservaAgregar.EstadoIngresado;
                DateTime fechaInicio = reservaAgregar.FechaInicioIngresada;
                DateTime fechaFin = reservaAgregar.FechaFinIngresada;
                decimal subTotal = reservaAgregar.SubTotalIngresado;
                decimal porcentaje = 0.10m;
                decimal total = subTotal + (subTotal * porcentaje);
                int nuevoId = ultimoId++;

                // Agrega los datos al DataGridView en la vista principal
                dataGridReservas.Rows.Add(nuevoId, idCliente, idUsuario, idTipoDePago, estado, fechaInicio, fechaFin, subTotal, total);
            }
        }
    }
}
