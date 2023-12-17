using Domain;
using Presentation.Empleado;
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
    public partial class ListadoPagos : Form
    {
        private PagoController pagoController;
        private int idpago=0;
        private int nivelPermiso;

        public ListadoPagos()
        {
            InitializeComponent();
            pagoController = new PagoController();
            cargardatos();
            lblUsuario.Text=DatosUsuario.GlobalVariables.NombreUsuario+" "+DatosUsuario.GlobalVariables.ApellidoUsuario;
            dateTimePicker1.ShowCheckBox = true;
            dateTimePicker1.Checked = false;
            dateTimePicker2.ShowCheckBox = true;
            dateTimePicker2.Checked = false;

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

        private void cargardatos()
        {
            List<PagoDTO> pagos = pagoController.ListarPagos();

            dataGridListadoPagos.DataSource = pagos;
            dataGridListadoPagos.AutoGenerateColumns = true;
            dataGridListadoPagos.Columns["IdPago"].HeaderText = "N° de Boleta";
            dataGridListadoPagos.Columns["IdReserva"].HeaderText = "N° de Reserva";
            dataGridListadoPagos.Columns["dniCliente"].HeaderText = "Dni del Cliente";
            dataGridListadoPagos.Columns["TipoHabitacion"].HeaderText = "Tipo de Habitacion";
            dataGridListadoPagos.Columns["FechaFactura"].HeaderText = "Fecha de Factura";
            dataGridListadoPagos.Columns["TipodePago"].HeaderText = "Tipo de Pago";

            dataGridListadoPagos.Columns["Estado"].Visible = false;
            dataGridListadoPagos.Columns["idUsuario"].Visible=false;
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

        private void habitacionesToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void pisosToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void toolStripMenuReportes_Click(object sender, EventArgs e)
        {
            //if (DatosUsuario.TienePermisoAdminGerente(DatosUsuario.GlobalVariables.PermisoUsuarioActual))
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<PagoDTO> pagos = pagoController.FiltrarPagosPorFecha(dateTimePicker1.Value);

            dataGridListadoPagos.DataSource = pagos;
            dataGridListadoPagos.AutoGenerateColumns = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dateTimePicker1.ShowCheckBox = true;
            dateTimePicker1.Checked = false;
            dateTimePicker2.ShowCheckBox = true;
            dateTimePicker2.Checked = false;
            cargardatos();
        }

        private void btnBuscarIntervalo_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value < dateTimePicker2.Value)
            {
                List<PagoDTO> pagos = pagoController.FiltrarPagosPorRangoDeFechas(dateTimePicker1.Value, dateTimePicker2.Value);
                dataGridListadoPagos.DataSource = pagos;
                dataGridListadoPagos.AutoGenerateColumns = true;

            }
            else
            {
                MessageBox.Show("Seleccione un Rango Aceptable");
            }
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            //permitir solo la entrada de dígitos numéricos y teclas de control (como Retroceso o Eliminar)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada del carácter no válido
            }
        }

        private void btnBuscarDNI_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                if (int.TryParse(txtDNI.Text, out int dni))
                {
                    List<PagoDTO> pagos = pagoController.FiltrarPagosDni(dni);

                    if (pagos.Any())
                    {
                        dataGridListadoPagos.DataSource = pagos;
                        dataGridListadoPagos.AutoGenerateColumns = true;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron pagos para el DNI ingresado.");
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un número de DNI válido.");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un número de DNI");
            }

        }

        private void dataGridListadoPagos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridListadoPagos.SelectedRows.Count > 0 && dataGridListadoPagos.SelectedRows.Count < 2)
            {
                idpago = (int)dataGridListadoPagos.SelectedRows[0].Cells["idPago"].Value;
            }
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (idpago > 0)// Verifica si se selecciono un cliente del dataGrid
            {
                // Abrir el formulario UsuarioModificar y pasar los detalles del cliente
                DetallePago detallePago = new DetallePago(idpago);
                detallePago.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione pago para ver los detalles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
