using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.SqlServer.Server;
using DataAccess;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;
using Domain;
using Presentation.Empleado;

namespace Presentation.Admin
{
    public partial class UsuarioListado : Form
    {
        #region Atributos para rastrear si los formularios se encuentran abiertos
        private bool formularioUsuarioAgregarAbierto;
        private bool formularioUsuarioModificarAbierto;
        private bool formularioReportesReservasAbierto;
        private bool formularioPerfilAdminAbierto;
        private bool formularioReservaListadoAbierto;
        #endregion

        private int idUsuarioSeleccionado; // Indica que la variable de seleccion del dataGri puede ser int o null
        private UsuarioController usuarioController; // Atributo para almacenar la instancia de UsuarioController
        private int nivelPermiso;

        public UsuarioListado()
        {
            InitializeComponent();
            this.usuarioController = new UsuarioController(); // Crear la instancia de UsuarioController
            this.formularioUsuarioAgregarAbierto = false;
            this.formularioReportesReservasAbierto = false;
            this.formularioPerfilAdminAbierto = false;
            this.formularioUsuarioModificarAbierto = false;
            this.formularioReservaListadoAbierto = false;
            lblUsuario.Text =DatosUsuario.GlobalVariables.NombreUsuario +" "+ DatosUsuario.GlobalVariables.ApellidoUsuario;

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
            this.Close();
            Login login = new Login();
            login.Show();
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

        private void UsuarioListado_Load(object sender, EventArgs e)
        {
            CargarGridUsuarios();
        }

        private void CargarGridUsuarios()
        {
            try
            {
                // Obtener la lista de usuarios
                var listaUsuarios = this.usuarioController.ListarUsuarios();

                // Asignar la lista como origen de datos para el DataGridView
                dataGridUsuarios.DataSource = listaUsuarios;
                dataGridUsuarios.AutoGenerateColumns = false; // Deshabilitar la generación automática de columnas

                // Configurar manualmente las columnas que deseas mostrar
                dataGridUsuarios.Columns["TipoUsuario"].HeaderText = "Tipo de Usuario";
                dataGridUsuarios.Columns["Nombre"].HeaderText = "Nombre";
                dataGridUsuarios.Columns["Apellido"].HeaderText = "Apellido";
                dataGridUsuarios.Columns["Dni"].HeaderText = "DNI";
                dataGridUsuarios.Columns["Telefono"].HeaderText = "Teléfono";
                dataGridUsuarios.Columns["Email"].HeaderText = "Email";
                dataGridUsuarios.Columns["Baja"].HeaderText = "Baja";
                
                // Ocultar las columnas que no deseas mostrar
                dataGridUsuarios.Columns["Id"].Visible = false;
                dataGridUsuarios.Columns["Contraseña"].Visible = false;
                dataGridUsuarios.Columns["Baja"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
            private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (formularioUsuarioAgregarAbierto==false 
                && formularioUsuarioModificarAbierto==false
                && formularioReportesReservasAbierto == false
                && formularioPerfilAdminAbierto == false
                && formularioReservaListadoAbierto == false)
            {
                UsuarioAgregar usuarioAgregar = new UsuarioAgregar();
                usuarioAgregar.Show();
                formularioUsuarioAgregarAbierto = true;
                usuarioAgregar.UsuarioAgregado += UsuarioAgregar_UsuarioAgregado; // Se suscribe al evento UsuarioAgregado
                usuarioAgregar.FormClosed += usuarioAgregar_FormClosed;
            } 
        }

        #region Eventos
        // Evento para actualizar el dataGrid una vez agregado el nuevo usuario
        private void UsuarioAgregar_UsuarioAgregado(object sender, EventArgs e)
        {
            CargarGridUsuarios();
        }

        //Evento para actualizar el valor del atributo "formularioUsuarioAgregarAbierto"
        private void usuarioAgregar_FormClosed(object sender, FormClosedEventArgs e)
        {
            formularioUsuarioAgregarAbierto = false;
        }

        private void UsuarioModificar_UsuarioModificado(object sender, EventArgs e)
        {
            CargarGridUsuarios();
        }

        private void usuarioModificar_FormClosed(object sender, FormClosedEventArgs e)
        {
            formularioUsuarioModificarAbierto = false;
        }

        #endregion

        private void btnMoficiar_Click(object sender, EventArgs e)
        {

            if (formularioUsuarioModificarAbierto == false 
                && formularioUsuarioAgregarAbierto == false
                && formularioReportesReservasAbierto == false
                && formularioPerfilAdminAbierto == false
                && formularioReservaListadoAbierto == false)
            {
                if (idUsuarioSeleccionado != null)// Verifica si se selecciono un usuario del dataGrid
                {
                    // Abrir el formulario UsuarioModificar y pasar los detalles del usuario
                    UsuarioModificar usuarioModificar = new UsuarioModificar((int)idUsuarioSeleccionado);
                    // Suscribirte al evento UsuarioAgregado
                    usuarioModificar.Show();
                    formularioUsuarioModificarAbierto = true;
                    usuarioModificar.UsuarioModificado += UsuarioModificar_UsuarioModificado;
                    usuarioModificar.FormClosed += usuarioModificar_FormClosed;
                }
                else
                {
                    MessageBox.Show("Seleccione un usuario para modificarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void dataGridUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridUsuarios.SelectedRows.Count == 1)
            {
                // Obtener el objeto UsuarioDTO seleccionado
                UsuarioDTO usuarioSeleccionado = (UsuarioDTO)dataGridUsuarios.SelectedRows[0].DataBoundItem;

                // Acceder al Id del UsuarioDTO
                string dni = usuarioSeleccionado.Dni;
                int.TryParse(dni, out idUsuarioSeleccionado);
            }
        }


        private void btnReportes_Click(object sender, EventArgs e)
        {
        }

        private void reporteReservas_FormClosed(object sender, FormClosedEventArgs e)
        {
            formularioUsuarioAgregarAbierto = false;
        }

        private void lblPerfil_Click(object sender, EventArgs e)
        {
            
        }

        private void perfilAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            formularioUsuarioAgregarAbierto = false;
        }

        #region Validaciones
        // Evento KeyPress para validar campo txtDni
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
        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            if (!(int.TryParse(txtDni.Text, out int dni)))
            {
                dni = 0;
            }
            if (nombre.Length == 0 && apellido.Length == 0 && dni == 0)
            {
                List<UsuarioDTO> resultados;
                resultados= usuarioController.ListarUsuarios();
                dataGridUsuarios.DataSource= resultados;
            }
            else
            {
                List<UsuarioDTO> resultados;

                resultados = usuarioController.BuscarUsuarios(nombre, apellido, dni);
                // Llena el DataGridView con los resultados
                dataGridUsuarios.DataSource = resultados;
                if (resultados.Count == 0)
                {
                    MessageBox.Show("No se encontraron registros con los criterios de búsqueda ingresados.");
                }
            }
            // Verifica si se encontraron resultados
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            ReservasListado reservasListado = new ReservasListado();
            reservasListado.ShowDialog();
        }

        private void btnHabitaciones_Click(object sender, EventArgs e)
        {
            //HabitacionListadoListado 
        }

        private void btnMinimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click_1(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else this.WindowState = FormWindowState.Normal;
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
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
            // Ocultar el formulario actual en lugar de cerrarlo
            this.Close();
            this.ShowInTaskbar = false;

            // Buscar el formulario Dashboard entre los formularios abiertos
            Dashboard dashboard = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();

            // Si el formulario Dashboard no está abierto, créalo y ábrelo
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
                // Ocultar el formulario actual en lugar de cerrarlo
                this.Close();
                this.ShowInTaskbar = false;

                // Buscar el formulario Recepcion entre los formularios abiertos
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

        private void salidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (DatosUsuario.TienePermisoAdminGerente(DatosUsuario.GlobalVariables.PermisoUsuarioActual))
            {
                // Ocultar el formulario actual en lugar de cerrarlo
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

                // Ocultar el formulario actual en lugar de cerrarlo
                this.Close();
                this.ShowInTaskbar = false;

                // Buscar el formulario Pisos entre los formularios abiertos
                Pisos pisos = Application.OpenForms.OfType<Pisos>().FirstOrDefault();

                // Si el formulario Pisos no está abierto, créalo y ábrelo
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

        private void lisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (DatosUsuario.TienePermisoAdminGerente(DatosUsuario.GlobalVariables.PermisoUsuarioActual))
            {

                this.Close();
                this.ShowInTaskbar = false;

                // Buscar el formulario Reportes entre los formularios abiertos
                ListadoPagos listado = Application.OpenForms.OfType<ListadoPagos>().FirstOrDefault();

                // Si el formulario Reportes no está abierto, créalo y ábrelo
                if (listado == null)
                {
                    listado = new ListadoPagos();
                    listado.Show();
                    this.Close();
                }
                else
                {
                    // Si ya está abierto, simplemente muéstralo
                    listado.Show();
                    listado.ShowInTaskbar = true;
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
                this.ShowInTaskbar = false;

                // Buscar el formulario Reportes entre los formularios abiertos
                UsuarioListado usuarioListado = Application.OpenForms.OfType<UsuarioListado>().FirstOrDefault();

                // Si el formulario Reportes no está abierto, créalo y ábrelo
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

                // Buscar el formulario Reportes entre los formularios abiertos
                ClienteListado clienteListado = Application.OpenForms.OfType<ClienteListado>().FirstOrDefault();

                // Si el formulario Reportes no está abierto, créalo y ábrelo
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
    }
}
