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
    public partial class ReporteReservas : Form
    {
        public ReporteReservas()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void ReporteReservas_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void MostrarDatosEnGrafico()
        {
            // Limpiar puntos existentes en el gráfico
            chart1.Series[0].Points.Clear();

            
            foreach (DataGridViewRow row in dataGridReportes.SelectedRows)
            {
                
                string nombre = row.Cells["Nombre"].Value.ToString();
                int reservasHechas = Convert.ToInt32(row.Cells["ReservasHechas"].Value);

                // Agregar puntos al gráfico
                chart1.Series[0].Points.AddXY(nombre, reservasHechas);
            }
        }

        private void MostrarDatosEnGrafico2()
        {
            // Limpiar puntos existentes en el gráfico
            chart1.Series[0].Points.Clear();

            
            foreach (DataGridViewRow row in dataGridReportes.SelectedRows)
            {
                
                string nombre = row.Cells["Nombre"].Value.ToString();
                int reservasHechas = Convert.ToInt32(row.Cells["ReservasHechas"].Value);

                // Agregar puntos al gráfico
                chart1.Series[0].Points.AddXY(nombre, reservasHechas);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnTopClientesIngresos_Click(object sender, EventArgs e)
        {

        }

        /*private void ActualizarGraficos(List<ClientesIngresos> datos)
        {
            // Mapear los datos a topClientesIngresos
            var datosMapeados = datos.Select(d => new ClientesIngresos
            {
                Nombre = d.Nombre,
                Ingresos = d.Ingresos // Ajusta esto según la propiedad correcta en tu clase ClientesIngresos
            }).ToList();

            chart1.Series[0].Points.Clear();
            foreach (var dato in datosMapeados)
            {
                chart1.Series[0].Points.AddXY(dato.Nombre, dato.Ingresos);
            }

            chart2.Series[0].Points.Clear();
            foreach (var dato in datosMapeados)
            {
                chart2.Series[0].Points.AddXY(dato.Nombre, dato.Ingresos);
            }
        }*/

        private void btnTopClientes_Click(object sender, EventArgs e)
        {

        }

        private void ReporteReservas_Load_1(object sender, EventArgs e)
        {
            CargarDatosEstaticos();
            MostrarDatosEnGrafico();
            MostrarDatosEnGrafico2();
        }

        private void CargarDatosEstaticos()
        {
            dataGridReportes.Rows.Add("John", "Doe", "5");
            dataGridReportes.Rows.Add("Jane", "Smith", "8");
            dataGridReportes.Rows.Add("Alice", "Johnson", "3");
            dataGridReportes.Rows.Add("Bob", "Williams", "10");
            dataGridReportes.Rows.Add("Charlie", "Brown", "2");
            dataGridReportes.Rows.Add("David", "Miller", "7");
            dataGridReportes.Rows.Add("Eva", "Jones", "4");
            dataGridReportes.Rows.Add("Frank", "Davis", "6");
            dataGridReportes.Rows.Add("Grace", "Moore", "9");
            dataGridReportes.Rows.Add("Henry", "Taylor", "1");
        }
    }
}
