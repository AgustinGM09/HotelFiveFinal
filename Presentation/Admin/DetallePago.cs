using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Admin
{
    public partial class DetallePago : Form
    {
        private PagoController pagoController;
        int numero;
        public DetallePago(int idpago)
        {
            InitializeComponent();
            pagoController= new PagoController();
            numero = idpago;
            cargardatos();
        }

        private void cargardatos()
        {
            List<string> datos = pagoController.datosdelPago(numero);
            lblReserva.Text = datos[1];
            lblDni.Text = datos[2];
            lblFechaHoy.Text = datos[3];
            lblDescipcion.Text = datos[5];
            lblhabitacion.Text = datos[6];
            lblFechaInicio.Text = datos[7];
            lblFechaFin.Text = datos[8];
            lblTotalDias.Text = datos[14];
            lblTotal.Text = datos[9];
            lblUsuario.Text = datos[15];
            lblNyA.Text = datos[10]+" "+datos[11];
            lblPago.Text = datos[12];
            lblTipoHabitacion.Text = datos[13];
            lblTotal.Text= datos[16];

            this.MouseClick += DetallePago_MouseClick;
        }

        private void DetallePago_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }

}
