using DataAccess;
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

namespace Presentation.Admin
{
    public partial class PerfilAdmin : Form
    {


        public PerfilAdmin()
        {
            InitializeComponent();
            //CargarDatos();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void CargarDatos()
        {
            txtNombre.Text = "Juan";
            txtApellido.Text = "Perez";
            txtTelefono.Text = "3794800123";
            txtEmail.Text = "email@gmail.com";
            txtDni.Text = "12345678";

            // Agrega filas al DataGridView con los datos proporcionados
            dataGridHistorial.Rows.Add(1, DateTime.Now, "Admin", "Creación de reserva", "Reserva creada para el cliente X");
            dataGridHistorial.Rows.Add(2, DateTime.Now, "Recepcionista", "Actualización de reserva", "Fecha de inicio modificada");
            dataGridHistorial.Rows.Add(3, DateTime.Now, "Gerente", "Cancelación de reserva", "Reserva cancelada por petición del cliente Y");
            dataGridHistorial.Rows.Add(4, DateTime.Now, "Admin", "Creación de reserva", "Reserva para cliente Z en habitación A");
            dataGridHistorial.Rows.Add(5, DateTime.Now, "Recepcionista", "Actualización de reserva", "Cambio de habitación");
            dataGridHistorial.Rows.Add(6, DateTime.Now, "Admin", "Cancelación de reserva", "Reserva cancelada debido a mantenimiento");
            dataGridHistorial.Rows.Add(7, DateTime.Now, "Recepcionista", "Creación de reserva", "Nueva reserva para cliente W");
            dataGridHistorial.Rows.Add(8, DateTime.Now, "Gerente", "Actualización de reserva", "Extensión de la estancia");
            dataGridHistorial.Rows.Add(9, DateTime.Now, "Admin", "Cancelación de reserva", "Cliente V cambió sus planes");
            dataGridHistorial.Rows.Add(10, DateTime.Now, "Recepcionista", "Creación de reserva", "Reserva para evento especial");
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else this.WindowState = FormWindowState.Normal;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void PerfilAdmin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void PerfilAdmin_Load_1(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
