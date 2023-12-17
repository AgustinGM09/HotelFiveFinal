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
    public partial class PerfilGerente : Form
    {
        public PerfilGerente()
        {
            InitializeComponent();
            CargarDatos();
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
        private void btnHabitaciones_Click(object sender, EventArgs e)
        {
            HabitacionListado habitacionListado = new HabitacionListado();
            habitacionListado.Show();
            this.Hide();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            ReporteGerente reporteGerente = new ReporteGerente();
            reporteGerente.Show();
            this.Hide();
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
            HabitacionListado habitacionListado = new HabitacionListado();
            habitacionListado.Show();
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

        private void CargarDatos()
        {
            txtNombre.Text = "Juan";
            txtApellido.Text = "Perez";
            txtTelefono.Text = "3794800123";
            txtEmail.Text = "email@gmail.com";
            txtDni.Text = "12345678";
        }

    }
}
