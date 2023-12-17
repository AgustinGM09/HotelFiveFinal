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

namespace Presentation.Empleado
{
    public partial class HistorialReserva : Form
    {
        public HistorialReserva()
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


        private void btnReservas_Click(object sender, EventArgs e)
        {
            ReservasListado reservasListado = new ReservasListado();
            reservasListado.Show();
            this.Hide();
        }

        private void btnAjustes_Click(object sender, EventArgs e)
        {
            PerfilEmpleado perfil = new PerfilEmpleado();
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

        /*private void ReporteEmpleado_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'hotelFiveDataReservas1.Reservas' Puede moverla o quitarla según sea necesario.
            this.reservasTableAdapter1.Fill(this.hotelFiveDataReservas1.Reservas);
            // TODO: esta línea de código carga datos en la tabla 'hotelFiveDataReservas.Reservas' Puede moverla o quitarla según sea necesario.
            this.reservasTableAdapter.Fill(this.hotelFiveDataReservas.Reservas);
            // Mostrar datos en el gráfico
            MostrarDatosEnGrafico();
            MostrarDatosEnGrafico2();
        }

        private void MostrarDatosEnGrafico()
        {
            // Limpiar puntos existentes en el gráfico
            chart1.Series[0].Points.Clear();

            // Obtener los datos de la tabla Clientes
            foreach (DataRow row in hotelFiveDataReservas1.Reservas.Rows)
            {
                // Suponiendo que tienes columnas llamadas "Nombre" y "ReservasHechas"
                string nombre = row["Nombre"].ToString();
                int reservasHechas = Convert.ToInt32(row["ReservasHechas"]);

                // Agregar puntos al gráfico
                chart1.Series[0].Points.AddXY(nombre, reservasHechas);
            }
        }

        private void MostrarDatosEnGrafico2()
        {
            // Limpiar puntos existentes en el gráfico
            chart2.Series[0].Points.Clear();

            // Obtener los datos de la tabla Clientes
            foreach (DataRow row in hotelFiveDataReservas1.Reservas.Rows)
            {
                // Suponiendo que tienes columnas llamadas "Nombre" y "ReservasHechas"
                string nombre = row["Nombre"].ToString();
                int reservasHechas = Convert.ToInt32(row["Fechas"]);

                // Agregar puntos al gráfico de dona
                chart2.Series[0].Points.AddXY(nombre, reservasHechas);

            }
        }*/
    }
}
