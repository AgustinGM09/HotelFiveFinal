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
using System.Xml.Linq;
using System.IO;
using Domain;
using DataAccess;
using Presentation.Empleado;

namespace Presentation.Admin
{
    public partial class Pagos : Form
    {
        private ClienteController clienteController;
        private HabitacionController habitacionController;
        private UsuarioController usuarioController;
        private ReservaController reservaController;
        private PagoController pagoController;
        string tipopago = "";
        int iddelpago;
        private int nivelPermiso;

        public Pagos(int reserva)
        {
            InitializeComponent();
            iddelpago = reserva;
            clienteController = new ClienteController();
            usuarioController = new UsuarioController();
            reservaController = new ReservaController();
            pagoController = new PagoController();
            habitacionController = new HabitacionController();
            inicializardatos();

            nivelPermiso = DatosUsuario.GlobalVariables.PermisoUsuarioActual;
            #region Visibiliza solo los botones disponibles para cada perfil
            if (nivelPermiso == 2)
            {
                // Accedo a los elementos del menu para cambiar su visibilidad segùn cada perfil
                

                ToolStripMenuItem gestion = (ToolStripMenuItem)menuStrip1.Items[2];
                gestion.Visible = false;

                ToolStripMenuItem reportes = (ToolStripMenuItem)menuStrip1.Items[4];
                reportes.Visible = false;

                ToolStripMenuItem clientes = (ToolStripMenuItem)menuStrip1.Items[6];
                clientes.Visible = false;
            }
            else if (nivelPermiso == 1)
            {
                ToolStripMenuItem gestion = (ToolStripMenuItem)menuStrip1.Items[2];
                ToolStripMenuItem recepcion = (ToolStripMenuItem)gestion.DropDownItems[0];
                recepcion.Visible = false;

                ToolStripMenuItem reservas = (ToolStripMenuItem)gestion.DropDownItems[3];
                reservas.Visible = false;

                ToolStripMenuItem mantenimiento = (ToolStripMenuItem)menuStrip1.Items[3];
                mantenimiento.Visible = false;

                ToolStripMenuItem usuarios = (ToolStripMenuItem)menuStrip1.Items[5];
                usuarios.Visible = false;

                ToolStripMenuItem clientes = (ToolStripMenuItem)menuStrip1.Items[6];
                clientes.Visible = false;
            }
            else
            {
                ToolStripMenuItem gestion = (ToolStripMenuItem)menuStrip1.Items[2];
                ToolStripMenuItem habitacion = (ToolStripMenuItem)gestion.DropDownItems[1];
                habitacion.Visible = false;

                ToolStripMenuItem pisos = (ToolStripMenuItem)gestion.DropDownItems[2];
                pisos.Visible = false;

                ToolStripMenuItem mantenimiento = (ToolStripMenuItem)menuStrip1.Items[3];
                mantenimiento.Visible = false;

                

                ToolStripMenuItem usuarios = (ToolStripMenuItem)menuStrip1.Items[5];
                usuarios.Visible = false;
            }
            #endregion
        }

        private void inicializardatos()
        {
            // Establece el valor del DateTimePicker a la fecha actual
            dateTimePicker.Value = DateTime.Now;

            // Oculta las flechas de arriba y abajo
            dateTimePicker.ShowUpDown = true;

            // Deshabilita la interacción con el DateTimePicker
            dateTimePicker.Enabled = false;

            List<string> NyACliente = reservaController.ObtenerNyAClientePorReserva(iddelpago);
            List<string> datos = reservaController.ObtenerDatosReserva(iddelpago);

            labelUsuario.Text= DatosUsuario.GlobalVariables.NombreUsuario+" "+DatosUsuario.GlobalVariables.ApellidoUsuario;
            lblUsuario.Text=DatosUsuario.GlobalVariables.NombreUsuario+" "+DatosUsuario.GlobalVariables.ApellidoUsuario;

            if (NyACliente.Count > 0)
            {
                // Supongo que solo hay un elemento en la lista (nombre y apellido)
                labelCliente.Text = NyACliente[0];
            }
            else
            {
                labelCliente.Text = "Cliente no encontrado";
            }
            RellenarDatos();
        }
        private void RellenarDatos()
        {
            List<string> datosReserva = reservaController.ObtenerDatosReserva(iddelpago);

            lblDniUsuario.Text = datosReserva[4];
            lblDNi.Text = datosReserva[2];
            lblFechaInicio.Text = datosReserva[7];
            lblFechaFin.Text = datosReserva[8];
            lblNHabitacion.Text = datosReserva[6];
            lblNReserva.Text = datosReserva[0];
            lblTotal.Text = datosReserva[9];
            lblTotalDias.Text = datosReserva[10];
            lblDescripcion.Text = datosReserva[11];

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
            // Muestra un cuadro de diálogo de confirmación
            DialogResult resultado = MessageBox.Show("¿Realmente desea cerrar la aplicación?", "Confirmar Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Comprueba la respuesta del usuario
            if (resultado == DialogResult.Yes)
            {
                // Si el usuario hace clic en "Sí", cierra la aplicación
                Application.Exit();
            }
            // Si el usuario hace clic en "No", no hace nada y la aplicación continúa ejecutándose
        }

        private void btnRealizarPago_Click(object sender, EventArgs e)
        {
            List<string> datos = reservaController.ObtenerDatosReserva(iddelpago);
            string reserva = datos[0];
            int idreserva;
            int.TryParse(reserva, out idreserva);
            DateTime fecha = dateTimePicker.Value;
            string estado = "PAGADO";

            if (tipopagos())
            {
                if (idreserva > 0 && fecha != null)
                {
                    pagoController.RegistrarPago(idreserva, fecha, tipopago, estado);
                    MessageBox.Show("Pago Realizado con Exito");
                    ImprimirPago imprimirPago = new ImprimirPago(idreserva);
                    imprimirPago.ShowDialog();
                    int idHabitacion = reservaController.ObtenerIdHabitacionPorReserva(idreserva); // Necesitarás implementar esta función
                    habitacionController.ActualizarEstadoHabitacion(idHabitacion, "NECESITA LIMPIEZA");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al Realizar el Pago");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un metodo de pago");
            }
        }



        private bool tipopagos()
        {
            if (radioEfectivo.Checked)
            {
                tipopago = "Efectivo";
                return true;
            }
            else if (radioTarjeta.Checked)
            {
                tipopago = "Tarjeta";
                return true;
            }
            else
            {
                return false;
            }
        }
   
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dashboar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.ShowInTaskbar = false;

            // Buscar el formulario Habitaciones entre los formularios abiertos
            Dashboard dashboard = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();

            // Si el formulario Habitaciones no está abierto, créalo y ábrelo
            if (dashboard == null)
            {
                dashboard = new Dashboard();
                dashboard.Show();
                this.Close();
            }
            else
            {
                // Si ya está abierto, simplemente muéstralo
                dashboard.Show();
                dashboard.ShowInTaskbar = true;
                this.Close();
            }
        }

        private void recepciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (DatosUsuario.TienePermisoAdminRecepcionista(DatosUsuario.GlobalVariables.PermisoUsuarioActual))
            {
                this.Close();
                this.ShowInTaskbar = false;

                // Buscar el formulario Habitaciones entre los formularios abiertos
                Recepcion recepcion = Application.OpenForms.OfType<Recepcion>().FirstOrDefault();

                // Si el formulario Habitaciones no está abierto, créalo y ábrelo
                if (recepcion == null)
                {
                    recepcion = new Recepcion();
                    recepcion.Show();
                    this.Close();
                }
                else
                {
                    // Si ya está abierto, simplemente muéstralo
                    recepcion.Show();
                    recepcion.ShowInTaskbar = true;
                    this.Close();
                }
            }
            //else
            {
                //DatosUsuario.Mensajeadminrecepcionista();
            }
        }

        private void habitacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (DatosUsuario.TienePermisoAdminGerente(DatosUsuario.GlobalVariables.PermisoUsuarioActual))
            {
                this.Close();
                this.ShowInTaskbar = false;

                // Buscar el formulario Habitaciones entre los formularios abiertos
                Habitaciones habitaciones = Application.OpenForms.OfType<Habitaciones>().FirstOrDefault();

                // Si el formulario Habitaciones no está abierto, créalo y ábrelo
                if (habitaciones == null)
                {
                    habitaciones = new Habitaciones();
                    habitaciones.Show();
                    this.Close();
                }
                else
                {
                    // Si ya está abierto, simplemente muéstralo
                    habitaciones.Show();
                    habitaciones.ShowInTaskbar = true;
                    this.Close();
                }
            }
            //else
            {
                //DatosUsuario.Mensajeadmingerente();
            }
        }

        private void pisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (DatosUsuario.TienePermisoAdminGerente(DatosUsuario.GlobalVariables.PermisoUsuarioActual))
            {
                this.Close();
                this.ShowInTaskbar = false;

                // Buscar el formulario Habitaciones entre los formularios abiertos
                Pisos pisos = Application.OpenForms.OfType<Pisos>().FirstOrDefault();

                // Si el formulario Habitaciones no está abierto, créalo y ábrelo
                if (pisos == null)
                {
                    pisos = new Pisos();
                    pisos.Show();
                    this.Close();
                }
                else
                {
                    // Si ya está abierto, simplemente muéstralo
                    pisos.Show();
                    pisos.ShowInTaskbar = true;
                    this.Close();
                }
            }
            //else
            {
                //DatosUsuario.Mensajeadmingerente();
            }
        }

        private void Mantenimiento_Click(object sender, EventArgs e)
        {
            //if (DatosUsuario.TienePermisoAdmin(DatosUsuario.GlobalVariables.PermisoUsuarioActual))
            {
                this.Close();
                this.ShowInTaskbar = false;

                // Buscar el formulario Habitaciones entre los formularios abiertos
                Backup backup = Application.OpenForms.OfType<Backup>().FirstOrDefault();

                // Si el formulario Habitaciones no está abierto, créalo y ábrelo
                if (backup == null)
                {
                    backup = new Backup();
                    backup.Show();
                    this.Close();
                }
                else
                {
                    // Si ya está abierto, simplemente muéstralo
                    backup.Show();
                    backup.ShowInTaskbar = true;
                    this.Close();
                }
            }
            //else
            {
                //DatosUsuario.Mensajeadmin();
            }
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (DatosUsuario.TienePermisoAdmin(DatosUsuario.GlobalVariables.PermisoUsuarioActual))
            {
                this.Close();
                this.ShowInTaskbar = false;

                // Buscar el formulario Habitaciones entre los formularios abiertos
                Reportes reportes = Application.OpenForms.OfType<Reportes>().FirstOrDefault();

                // Si el formulario Habitaciones no está abierto, créalo y ábrelo
                if (reportes == null)
                {
                    reportes = new Reportes();
                    reportes.Show();
                    this.Close();
                }
                else
                {
                    // Si ya está abierto, simplemente muéstralo
                    reportes.Show();
                    reportes.ShowInTaskbar = true;
                    this.Close();
                }
            }
            //else
            {
                //DatosUsuario.Mensajeadmin();
            }
        }

        private void Usuarios_Click(object sender, EventArgs e)
        {
            //if (DatosUsuario.TienePermisoAdmin(DatosUsuario.GlobalVariables.PermisoUsuarioActual))
            {
                this.Close();
                this.ShowInTaskbar = false;

                // Buscar el formulario Habitaciones entre los formularios abiertos
                UsuarioListado usuarioListado = Application.OpenForms.OfType<UsuarioListado>().FirstOrDefault();

                // Si el formulario Habitaciones no está abierto, créalo y ábrelo
                if (usuarioListado == null)
                {
                    usuarioListado = new UsuarioListado();
                    usuarioListado.Show();
                    this.Close();
                }
                else
                {
                    // Si ya está abierto, simplemente muéstralo
                    usuarioListado.Show();
                    usuarioListado.ShowInTaskbar = true;
                    this.Close();
                }
            }
            //else
            {
                //DatosUsuario.Mensajeadmin();
            }
        }

        private void Clientes_Click(object sender, EventArgs e)
        {
            //if (DatosUsuario.TienePermisoAdminRecepcionista(DatosUsuario.GlobalVariables.PermisoUsuarioActual))
            {
                this.Close();
                this.ShowInTaskbar = false;

                // Buscar el formulario Habitaciones entre los formularios abiertos
                ClienteListado clienteListado = Application.OpenForms.OfType<ClienteListado>().FirstOrDefault();

                // Si el formulario Habitaciones no está abierto, créalo y ábrelo
                if (clienteListado == null)
                {
                    clienteListado = new ClienteListado();
                    clienteListado.Show();
                    this.Close();
                }
                else
                {
                    // Si ya está abierto, simplemente muéstralo
                    clienteListado.Show();
                    clienteListado.ShowInTaskbar = true;
                    this.Close();
                }
            }
            //else
            {
                //DatosUsuario.Mensajeadminrecepcionista();
            }
        }

        private void listadoDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (DatosUsuario.TienePermisoAdminGerente(DatosUsuario.GlobalVariables.PermisoUsuarioActual))
            {
                this.Close();
                this.ShowInTaskbar = false;

                // Buscar el formulario Habitaciones entre los formularios abiertos
                ListadoPagos listadoPagos = Application.OpenForms.OfType<ListadoPagos>().FirstOrDefault();

                // Si el formulario Habitaciones no está abierto, créalo y ábrelo
                if (listadoPagos == null)
                {
                    listadoPagos = new ListadoPagos();
                    listadoPagos.Show();
                    this.Close();
                }
                else
                {
                    // Si ya está abierto, simplemente muéstralo
                    listadoPagos.Show();
                    listadoPagos.ShowInTaskbar = true;
                    this.Close();
                }
            }
            //else
            {
                //DatosUsuario.Mensajeadmingerente();
            }
        }

        private void reservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (DatosUsuario.TienePermisoAdminRecepcionista(DatosUsuario.GlobalVariables.PermisoUsuarioActual))
            {
                this.Close();
                this.ShowInTaskbar = false;

                // Buscar el formulario Dashboard entre los formularios abiertos
                ReservadeCliente reservadeCliente = Application.OpenForms.OfType<ReservadeCliente>().FirstOrDefault();

                // Si el formulario Dashboard no está abierto, créalo y ábrelo
                if (reservadeCliente == null)
                {
                    reservadeCliente = new ReservadeCliente();
                    reservadeCliente.Show();
                    this.Close();
                }
                else
                {
                    // Si ya está abierto, simplemente muéstralo
                    reservadeCliente.Show();
                    reservadeCliente.ShowInTaskbar = true;
                    this.Close();
                }
            }
            //else
            {
                //DatosUsuario.Mensajeadminrecepcionista();
            }
        }
    }
}
