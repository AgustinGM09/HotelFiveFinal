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
using Domain;
using Presentation.Empleado;


namespace Presentation.Admin
{
    public partial class Dashboard : Form
    {
        private readonly HabitacionController habitacionController;
        private int nivelPermiso;

        public Dashboard()
        {
            InitializeComponent();
            habitacionController = new HabitacionController();
            lblUsuario.Text=DatosUsuario.GlobalVariables.NombreUsuario+" "+DatosUsuario.GlobalVariables.ApellidoUsuario;
            nivelPermiso = DatosUsuario.GlobalVariables.PermisoUsuarioActual;
        }

        #region Codigo para poder arrastrar el formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Controles del formulario
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
        #endregion

        private void recepciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //recepcion.FormClosed += (s, args) => MostrarDashboard();
            // Ocultar el formulario actual en lugar de cerrarlo
            this.Hide();
            this.ShowInTaskbar = false;

            // Buscar el formulario Recepcion entre los formularios abiertos
            Recepcion recepcion = Application.OpenForms.OfType<Recepcion>().FirstOrDefault();

            // Si el formulario Dashboard no está abierto, créalo y ábrelo
            if (recepcion == null)
            {
                recepcion = new Recepcion();
                recepcion.Show();
            }
            else
            {
                // Si ya está abierto, simplemente muéstralo
                recepcion.Show();
                recepcion.ShowInTaskbar = true;
            }

        }
        private void Dashboar_Click(object sender, EventArgs e)
        {
            // Ocultar el formulario actual en lugar de cerrarlo
            this.Hide();
            this.ShowInTaskbar = false;

            // Buscar el formulario Dashboard entre los formularios abiertos
            Dashboard dashboard = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();

            // Si el formulario Dashboard no está abierto, créalo y ábrelo
            if (dashboard == null)
            {
                dashboard = new Dashboard();
                dashboard.Show();
            }
            else
            {
                // Si ya está abierto, simplemente muéstralo
                dashboard.Show();
                dashboard.ShowInTaskbar = true;
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            btnTotalHabitaciones.Text = "Total Habitaciones: " + habitacionController.TotalHabitaciones();
            btnHabitacionesDisponibles.Text = "Habitaciones Disponibles: " + habitacionController.TotalHabitacionesDisponibles();
            btnHabitacionesOcupadas.Text = "Habitaciones Ocupadas: " + habitacionController.TotalHabitacionesOcupadas();
            btnHabitacionesEnLimpieza.Text = "Habitaciones en Limpieza: " + habitacionController.TotalHabitacionesEnLimpieza();

            #region Carga la primera vez la grilla con el total de habitaciones
            // Obtener la lista de habitaciones totales
            List<HabitacionDTO> habitaciones = habitacionController.ObtenerListaHabitacionesTotales();

            // Asignar la lista como origen de datos del DataGridView
            dataGridHabitaciones.DataSource = habitaciones;

            dataGridHabitaciones.AutoResizeColumns();

            // Peronalización de la tabla
            dataGridHabitaciones.Columns["Numero"].DisplayIndex = 0;
            dataGridHabitaciones.Columns["Descripcion"].DisplayIndex = 1;
            dataGridHabitaciones.Columns["IdTipo"].DisplayIndex = 2;
            dataGridHabitaciones.Columns["IdTipo"].HeaderText = "Categoría";
            dataGridHabitaciones.Columns["IdPiso"].HeaderText = "Piso";
            dataGridHabitaciones.Columns["IdHabitacion"].Visible = false;
            #endregion

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
                ToolStripMenuItem  gestion = (ToolStripMenuItem)menuStrip1.Items[2];
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

        private void habitacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ocultar el formulario actual en lugar de cerrarlo
            this.Hide();
            this.ShowInTaskbar = false;

            // Buscar el formulario Habitaciones entre los formularios abiertos
            Habitaciones habitaciones = Application.OpenForms.OfType<Habitaciones>().FirstOrDefault();

            // Si el formulario Habitaciones no está abierto, créalo y ábrelo
            if (habitaciones == null)
            {
               habitaciones = new Habitaciones();
                habitaciones.Show();
            }
            else
            {
                // Si ya está abierto, simplemente muéstralo
                habitaciones.Show();
                habitaciones.ShowInTaskbar = true;
            }
        }

        private void pisosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Ocultar el formulario actual en lugar de cerrarlo
            this.Hide();
            this.ShowInTaskbar = false;

            // Buscar el formulario Pisos entre los formularios abiertos
            Pisos pisos = Application.OpenForms.OfType<Pisos>().FirstOrDefault();

            // Si el formulario Pisos no está abierto, créalo y ábrelo
            if (pisos == null)
            {
                pisos = new Pisos();
                pisos.Show();
            }
            else
            {
                // Si ya está abierto, simplemente muéstralo
                pisos.Show();
                pisos.ShowInTaskbar = true;
            }
        }

        private void btnTotalHabitaciones_Click(object sender, EventArgs e)
        {
            // Obtener la lista de habitaciones totales
            List<HabitacionDTO> habitaciones = habitacionController.ObtenerListaHabitacionesTotales();

            // Asignar la lista como origen de datos del DataGridView
            dataGridHabitaciones.DataSource = habitaciones;
            lblListaHabitacion.Text = "Lista de Habitaciones Totales";

            dataGridHabitaciones.AutoResizeColumns();

            // Peronalización de la tabla
            ConfigurarDataGridView();
        }

        private void btnHabitacionesDisponibles_Click(object sender, EventArgs e)
        {
            // Obtener la lista de habitaciones disponibles
            List<HabitacionDTO> habitaciones = habitacionController.ObtenerHabitacionesDisponibles();

            // Asignar la lista como origen de datos del DataGridView
            dataGridHabitaciones.DataSource = habitaciones;

            dataGridHabitaciones.AutoResizeColumns();
            lblListaHabitacion.Text = "Habitaciones Disponibles";

            // Peronalización de la tabla
            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            dataGridHabitaciones.Columns["Numero"].DisplayIndex = 0;
            dataGridHabitaciones.Columns["Descripcion"].DisplayIndex = 1;
            dataGridHabitaciones.Columns["IdTipo"].DisplayIndex = 2;
            dataGridHabitaciones.Columns["IdTipo"].HeaderText = "Categoría";
            dataGridHabitaciones.Columns["IdPiso"].HeaderText = "Piso";

            dataGridHabitaciones.Columns["IdHabitacion"].Visible = false;
        }

        private void btnHabitacionesOcupadas_Click(object sender, EventArgs e)
        {
            // Obtener la lista de habitaciones ocupadas
            List<HabitacionDTO> habitaciones = habitacionController.ObtenerHabitacionesOcupadas();

            // Asignar la lista como origen de datos del DataGridView
            dataGridHabitaciones.DataSource = habitaciones;

            lblListaHabitacion.Text = "Lista de Habitaciones Ocupadas";

            dataGridHabitaciones.AutoResizeColumns();

            // Peronalización de la tabla
            ConfigurarDataGridView();
        }

        private void btnHabitacionesEnLimpieza_Click(object sender, EventArgs e)
        {
            // Obtener la lista de habitaciones ocupadas
            List<HabitacionDTO> habitaciones = habitacionController.ObtenerHabitacionesNecesitanLimpieza();

            // Asignar la lista como origen de datos del DataGridView
            dataGridHabitaciones.DataSource = habitaciones;

            lblListaHabitacion.Text = "Lista de Habitaciones en Limpieza";

            dataGridHabitaciones.AutoResizeColumns();

            // Peronalización de la tabla
            ConfigurarDataGridView();
        }

        private void recepciónToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //if (DatosUsuario.TienePermisoAdminRecepcionista(DatosUsuario.GlobalVariables.PermisoUsuarioActual))
            {
                this.Close();
                //this.ShowInTaskbar = false;

                // Buscar el formulario Dashboard entre los formularios abiertos
                Recepcion recepcion = Application.OpenForms.OfType<Recepcion>().FirstOrDefault();

                // Si el formulario Dashboard no está abierto, créalo y ábrelo
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

        private void habitacionesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //if (DatosUsuario.TienePermisoAdminGerente(DatosUsuario.GlobalVariables.PermisoUsuarioActual))
            {
                this.Close();
                //this.ShowInTaskbar = false;

                // Buscar el formulario Dashboard entre los formularios abiertos
                Habitaciones habitaciones = Application.OpenForms.OfType<Habitaciones>().FirstOrDefault();

                // Si el formulario Dashboard no está abierto, créalo y ábrelo
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

        private void pisosToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            //if (DatosUsuario.TienePermisoAdminGerente(DatosUsuario.GlobalVariables.PermisoUsuarioActual))
            {
                this.Close();
                //this.ShowInTaskbar = false;

                // Buscar el formulario Dashboard entre los formularios abiertos
                Pisos pisos = Application.OpenForms.OfType<Pisos>().FirstOrDefault();

                // Si el formulario Dashboard no está abierto, créalo y ábrelo
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
                //this.ShowInTaskbar = false;

                // Buscar el formulario Dashboard entre los formularios abiertos
                Backup backup = Application.OpenForms.OfType<Backup>().FirstOrDefault();

                // Si el formulario Dashboard no está abierto, créalo y ábrelo
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
                //this.ShowInTaskbar = false;

                // Buscar el formulario Dashboard entre los formularios abiertos
                Reportes reportes = Application.OpenForms.OfType<Reportes>().FirstOrDefault();

                // Si el formulario Dashboard no está abierto, créalo y ábrelo
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
                //DatosUsuario.Mensajeadmingerente();
            }
        }

        private void Usuarios_Click(object sender, EventArgs e)
        {
            //if (DatosUsuario.TienePermisoAdmin(DatosUsuario.GlobalVariables.PermisoUsuarioActual))
            {
                this.Close();
                //this.ShowInTaskbar = false;

                // Buscar el formulario Dashboard entre los formularios abiertos
                UsuarioListado usuarioListado = Application.OpenForms.OfType<UsuarioListado>().FirstOrDefault();

                // Si el formulario Dashboard no está abierto, créalo y ábrelo
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

                // Buscar el formulario Dashboard entre los formularios abiertos
                ClienteListado clienteListado = Application.OpenForms.OfType<ClienteListado>().FirstOrDefault();

                // Si el formulario Dashboard no está abierto, créalo y ábrelo
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

                // Buscar el formulario Dashboard entre los formularios abiertos
                ListadoPagos listadoPagos = Application.OpenForms.OfType<ListadoPagos>().FirstOrDefault();

                // Si el formulario Dashboard no está abierto, créalo y ábrelo
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
                //DatosUsuario.Mensajeadminrecepcionista();
            }
        }

        private void reservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (DatosUsuario.TienePermisoAdminGerente(DatosUsuario.GlobalVariables.PermisoUsuarioActual))
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

        private void toolStripMenuReportes_Click_1(object sender, EventArgs e)
        {

        }
    }
}
