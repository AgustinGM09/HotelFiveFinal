using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Admin
{
    public partial class ImprimirPago : Form
    {
        PagoController pagoController;
        int numero;
        public ImprimirPago(int idreserva)
        {
            InitializeComponent();
            numero = idreserva;
            pagoController = new PagoController();
            cargardatos(numero);
        }

        private void ImprimirFormulario(Form formulario)
        {
            PrintDocument pd = new PrintDocument();

            // Establece el tamaño de página a A4 en orientación horizontal
            pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 700, 1150);
            pd.DefaultPageSettings.Landscape = true; // Establece la orientación a horizontal

            pd.PrintPage += (s, ev) => ImprimirContenido(formulario, ev);

            // Evita que el sistema de impresión pregunte al usuario
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pd;
            printDialog.UseEXDialog = true;

            // No necesitas mostrar el diálogo si ya sabes que el usuario desea imprimir sin preguntar
            // if (printDialog.ShowDialog() == DialogResult.OK)
            // {
            pd.Print();
            // }
        }

        private void ImprimirContenido(Form formulario, PrintPageEventArgs e)
        {
            // Aquí puedes dibujar el contenido que deseas imprimir en la página
            // Por ejemplo, dibujar el contenido del formulario pasado como parámetro
            Bitmap bmp = new Bitmap(formulario.Width, formulario.Height);
            formulario.DrawToBitmap(bmp, new Rectangle(0, 0, formulario.Width, formulario.Height));
            e.Graphics.DrawImage(bmp, e.PageBounds);
        }
        private void cargardatos(int numero)
        {
            List<string> datos = pagoController.ObtenerDetallesPagoPorId(numero);
            string factura = datos[0];
            lblFactura.Text = factura;
            lblReserva.Text = datos[1];
            lblDni.Text = datos[2];
            lblFechaHoy.Text = datos[3];
            lblEstado.Text = datos[4];
            lblDescipcion.Text = datos[5];
            lblhabitacion.Text = datos[6];
            lblFechaInicio.Text = datos[7];
            lblFechaFin.Text = datos[8];
            lblTotal.Text = datos[9];
            lblUsuario.Text = DatosUsuario.GlobalVariables.NombreUsuario+" "+DatosUsuario.GlobalVariables.ApellidoUsuario;
            lblNyA.Text = datos[10]+" "+datos[11];
            lblPago.Text = datos[12];
            lblTipoHabitacion.Text = datos[13];
            this.MouseClick += ImprimirPago_MouseClick;
        }

        private void ImprimirPago_MouseClick(object sender, MouseEventArgs e)
        {
            // El usuario hizo clic en algún lugar del formulario
            // Aquí puedes realizar las acciones que necesitas al hacer clic
            ImprimirFormulario(this);
            // Luego, permitir cerrar la ventana
            this.Close();
        }
    }
}
