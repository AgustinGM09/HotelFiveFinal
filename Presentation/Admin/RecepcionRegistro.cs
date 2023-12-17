using DataAccess;
using Domain;
using Presentation.Empleado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Admin
{
    public partial class RecepcionRegistro : Form
    {

        private int nroHabitacion; //ID de la habitacion que se va a reservar
        private readonly HabitacionController habitacionController;
        private readonly UsuarioController usuarioController;
        private ClienteReservaController clienteReservaController;
        private ClienteDTO cliente;
        private HabitacionDTO habitacion;
        private UsuarioDTO usuario;
        private ClienteController clienteController;
        private int nivelPermiso;

        public RecepcionRegistro(int p_nroHabitacion)
        {
            InitializeComponent();
            this.nroHabitacion = p_nroHabitacion;
            habitacionController = new HabitacionController();
            clienteReservaController = new ClienteReservaController();
            clienteController = new ClienteController();
            lblUsuario.Text=DatosUsuario.GlobalVariables.NombreUsuario+" "+DatosUsuario.GlobalVariables.ApellidoUsuario;
            nivelPermiso = DatosUsuario.GlobalVariables.PermisoUsuarioActual;
            //this.usuario = usuarioController.ObtenerUsuarioPorId(1);
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

        private void RecepcionRegistro_Load(object sender, EventArgs e)
        {
            HabitacionDTO habitacion = habitacionController.ObtenerHabitacionPorId(nroHabitacion);
            this.habitacion = habitacion;
            //MessageBox.Show("Habitacion seleccionada número: " +habitacion.Numero, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblNumero.Text = "Número: " + habitacion.Numero;
            lblDetalles.Text = "Detalles: " + habitacion.Descripcion;
            lblCategoria.Text = "Categoria: " + habitacion.IdTipo;
            lblPiso.Text = "Piso: " + habitacion.IdPiso;
            lblPrecio.Text = "Precio: " + habitacion.Precio;
            //Validar dtpFechaEntrada
            // Obtén la fecha actual
            DateTime fechaActual = DateTime.Now;

            // Establece la fecha mínima en el DateTimePicker para ser la fecha actual
            dtpFechaEntrada.MinDate = fechaActual;
            dtpFechaEntrada.Enabled = false;

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
                ToolStripMenuItem habitaciones = (ToolStripMenuItem)gestion.DropDownItems[1];
                habitaciones.Visible = false;

                ToolStripMenuItem pisos = (ToolStripMenuItem)gestion.DropDownItems[2];
                pisos.Visible = false;

                ToolStripMenuItem mantenimiento = (ToolStripMenuItem)menuStrip1.Items[3];
                mantenimiento.Visible = false;

                

                ToolStripMenuItem usuarios = (ToolStripMenuItem)menuStrip1.Items[5];
                usuarios.Visible = false;
            }
            #endregion
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            if (int.TryParse(txtDni.Text, out int dni))
            {
                // Crea una instancia de tu controlador de clientes
                ClienteController clienteController = new ClienteController();

                // Busca al cliente por DNI
                ClienteDTO cliente = clienteController.BuscarClientePorDni(dni);

                // Verifica si se encontró al cliente
                if (cliente != null)
                {
                    this.cliente = cliente;

                    // Muestra una alerta informando que se encontró al cliente
                    MessageBox.Show($"Cliente encontrado:\nNombre: {cliente.Nombre}\nApellido: {cliente.Apellido}\nEmail: {cliente.Email}",
                        "Cliente Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cargar la información del cliente en los controles del formulario
                    txtNombre.Text = cliente.Nombre;
                    txtApellido.Text = cliente.Apellido;
                    txtEmail.Text = cliente.Email;
                    txtTelefono.Text = cliente.Telefono.ToString();
                    txtFechaNacimiento.Text = cliente.FechaNacimiento;

                    // Deshabilita la edición de los campos
                    txtNombre.Enabled = false;
                    txtApellido.Enabled = false;
                    txtEmail.Enabled = false;
                    txtTelefono.Enabled = false;
                    txtFechaNacimiento.Enabled = false;
                    txtDni.Enabled = false;
                    btnBuscar.Enabled = false;
                    btnRegistrarCliente.Enabled = false;
                    btnBuscarReserva.Enabled = false;
                }
                else
                {
                    // Muestra una alerta informando que no se encontró al cliente
                    MessageBox.Show("Cliente no encontrado", "Cliente No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Muestra una alerta informando que el DNI ingresado no es válido
                MessageBox.Show("Por favor, ingrese un DNI válido.", "DNI Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Verifica que los datos del cliente no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Por favor, complete los datos del cliente antes de registrar la reserva.", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener las fechas de entrada y salida desde los DateTimePicker
            DateTime fechaEntrada = dtpFechaEntrada.Value;
            DateTime fechaSalida = dtpFechaSalida.Value;

            // Validar que la fecha de salida sea mayor o igual a la fecha de entrada
            if (fechaSalida < fechaEntrada)
            {
                MessageBox.Show("La fecha de salida no puede ser menor que la fecha de entrada, seleccione fecha de entrada y luego de salida en caso de ser iguales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblPrecioTotal.Text = "Precio Total:";
                return; // Salir del método si hay un error
            }

            // Calcular la duración de la estadía en días, incluyendo el día de salida
            int duracionEstadia = (int)(fechaSalida - fechaEntrada).TotalDays + 1;

            // Obtener el precio por día de la habitación
            HabitacionDTO habitacion = habitacionController.ObtenerHabitacionPorId(nroHabitacion);

            // Convertir el precio a tipo entero
            if (int.TryParse(habitacion.Precio, out int precioPorDia))
            {
                // Asegurarse de que el precio por día sea mayor que cero
                if (precioPorDia > 0)
                {
                    // Calcular el precio total de la estadía
                    int precioTotal = duracionEstadia > 0 ? duracionEstadia * precioPorDia : precioPorDia;

                    // Mostrar el precio total
                    lblPrecioTotal.Text = "Precio Total: " + precioTotal.ToString();

                    // Mostrar en una alerta los datos antes de la lógica de registro
                    string mensaje = $"Datos de la Reserva:\n\n" +
                        $"Habitación\nNúmero: {habitacion.Numero}\nDetalles: {habitacion.Descripcion}\n" +
                        $"Categoría: {habitacion.IdTipo}\nPiso: {habitacion.IdPiso}\nPrecio: {habitacion.Precio}\n\n" +
                        $"Cliente\nNombre: {txtNombre.Text}\nApellido: {txtApellido.Text}\nEmail: {txtEmail.Text}\n\n" +
                        $"Reserva\nFecha Entrada: {fechaEntrada}\nFecha Salida: {fechaSalida}\nDuración Estadía: {duracionEstadia} días\nPrecio Total: {precioTotal}";
                    MessageBox.Show(mensaje, "Confirmación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (clienteReservaController.ObtenerSiTieneReserva((int)cliente.Dni) < 1)
                    {
                        int DNI = clienteController.ObtenerCliente((int)cliente.Dni);
                        clienteReservaController.GuardarDetallesReserva(DNI, habitacion.IdHabitacion, fechaEntrada, fechaSalida);
                    }
                    clienteReservaController.ActualizarEstadoReserva(cliente.IdCliente, fechaEntrada, fechaSalida);
                    // Lógica para registrar la reserva con los datos del cliente y el precio total
                    //int tipoHabitacion = this.habitacion.ConvertirTipoHabitacion(habitacion.IdTipo);
                    ReservaController reservaController = new ReservaController();
                    reservaController.RegistrarReserva(cliente.IdCliente, DatosUsuario.GlobalVariables.Usuarioid, 3, habitacion.IdHabitacion, fechaEntrada, fechaSalida, precioTotal);

                    // Después de la lógica, puedes mostrar un mensaje indicando que la reserva se ha registrado con éxito
                    MessageBox.Show("Reserva registrada exitosamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    //this.ShowInTaskbar = false;

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
                else
                {
                    // Manejar la situación donde el precio por día no es válido
                    MessageBox.Show("El precio por día no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Manejar la situación donde el precio no puede ser convertido a entero
                MessageBox.Show("El precio no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnCalcularTotal_Click(object sender, EventArgs e)
        {
            // Obtener las fechas de entrada y salida desde los DateTimePicker
            DateTime fechaEntrada = dtpFechaEntrada.Value;
            DateTime fechaSalida = dtpFechaSalida.Value;

            // Validar que la fecha de salida sea mayor o igual a la fecha de entrada
            if (fechaSalida < fechaEntrada)
            {
                MessageBox.Show("La fecha de salida no puede ser menor que la fecha de entrada, seleccione fecha de entrada y luego de salida en caso de ser iguales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblPrecioTotal.Text = "Precio Total:";
                return; // Salir del método si hay un error
            }

            // Calcular la duración de la estadía en días, incluyendo el día de salida
            int duracionEstadia = (int)(fechaSalida - fechaEntrada).TotalDays + 1;

            // Obtener el precio por día de la habitación
            HabitacionDTO habitacion = habitacionController.ObtenerHabitacionPorId(nroHabitacion);

            // Convertir el precio a tipo entero
            if (int.TryParse(habitacion.Precio, out int precioPorDia))
            {
                // Asegurarse de que el precio por día sea mayor que cero
                if (precioPorDia > 0)
                {
                    // Calcular el precio total de la estadía
                    int precioTotal = duracionEstadia > 0 ? duracionEstadia * precioPorDia : precioPorDia;

                    // Mostrar el precio total
                    lblPrecioTotal.Text = "Precio Total: " + precioTotal.ToString();
                }
                else
                {
                    // Manejar la situación donde el precio no es válido
                    lblPrecioTotal.Text = "Precio no válido";
                }
            }
            else
            {
                // Manejar la situación donde el precio no puede ser convertido a entero
                lblPrecioTotal.Text = "Precio no válido";
            }
        }

        private void txtNombre_MouseHover(object sender, EventArgs e)
        {
            toolTipNombre.SetToolTip(txtNombre, txtNombre.Text);
        }

        private void txtApellido_MouseHover(object sender, EventArgs e)
        {
            toolTipApellido.SetToolTip(txtApellido, txtApellido.Text);
        }

        private void txtEmail_MouseHover(object sender, EventArgs e)
        {
            toolTipEmail.SetToolTip(txtEmail, txtEmail.Text);
        }

        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            ClienteAgregar clienteAgregar = new ClienteAgregar();
            clienteAgregar.ShowDialog();
        }

        private void btnBuscarReserva_Click(object sender, EventArgs e)
        {
            using (SeleccionarReserva seleccionarReservaForm = new SeleccionarReserva())
            {
                // Abre el formulario SeleccionarReserva como un cuadro de diálogo
                if (seleccionarReservaForm.ShowDialog() == DialogResult.OK)
                {
                    // Obtiene el IdClienteReservaSeleccionado del formulario SeleccionarReserva
                    int idClienteReserva = seleccionarReservaForm.IdClienteReservaSeleccionado;
                    List<String> valor = clienteReservaController.ObtenerDetallesReservaPorId(idClienteReserva);
                    int tipo;
                    int.TryParse(valor[2], out tipo);
                    string dato = clienteReservaController.tipohabitacion(tipo);
                    if (dato == habitacion.IdTipo)
                    { 
                        string fechaInicioString = valor.Count > 3 ? valor[3] : null;
                        string fechaFinString = valor.Count > 4 ? valor[4] : null;

                        // Parsear las cadenas de fecha a objetos DateTime
                        if (DateTime.TryParse(fechaInicioString, out DateTime fechaInicio))
                        {
                            if (fechaInicio.Date == dtpFechaEntrada.Value.Date && fechaInicio.Month == dtpFechaEntrada.Value.Month && fechaInicio.Year == dtpFechaEntrada.Value.Year)
                            {
                                if (DateTime.TryParse(fechaFinString, out DateTime fechaFin))
                                {
                                    dtpFechaSalida.Value = fechaFin;
                                    dtpFechaSalida.Enabled=false;
                                }
                                txtDni.Text = valor[1];
                                btnBuscar_Click(this, EventArgs.Empty);
                                btnCalcularTotal_Click(this, EventArgs.Empty);
                                txtDni.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("La Fecha de la Reserva no es Acorde al Dia Actual");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione una Reserva Acorde a la Habitacion");
                    }
                }
            }
        }

        private void Dashboar_Click(object sender, EventArgs e)
        {
            // Ocultar el formulario actual en lugar de cerrarlo
            this.Close();
            //this.ShowInTaskbar = false;

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
                this.Close();
                //this.ShowInTaskbar = false;

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
                //this.ShowInTaskbar = false;

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
                //this.ShowInTaskbar = false;

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
                //this.ShowInTaskbar = false;

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
                //this.ShowInTaskbar = false;

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
                //this.ShowInTaskbar = false;

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
                //this.ShowInTaskbar = false;

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
                //this.ShowInTaskbar = false;

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
                //this.ShowInTaskbar = false;

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
