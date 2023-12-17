using DataAccess;
using Domain;
using Presentation.Empleado;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Presentation.Admin
{

    public partial class Recepcion : Form
    {
        private readonly HabitacionController habitacionController;
        private ReservaController reservaController;
        private string estado;
        private int idPiso;
        private int idCategoria;
        private int nivelPermiso;

        public Recepcion()
        {
            InitializeComponent();
            habitacionController = new HabitacionController();
            reservaController = new ReservaController();
            lblUsuario.Text=DatosUsuario.GlobalVariables.NombreUsuario+" "+DatosUsuario.GlobalVariables.ApellidoUsuario;
            nivelPermiso = DatosUsuario.GlobalVariables.PermisoUsuarioActual; nivelPermiso = DatosUsuario.GlobalVariables.PermisoUsuarioActual;
        }



        // Se carga la primera vez al abrir el forumlario
        private void Recepcion_Load(object sender, EventArgs e)
        {
            // Carga los combobox del formulario
            CargaComboBoxPisos();
            CargaComboBoxCategorias();
            //CargaComboBoxEstados();
            CargarGrillaHabitaciones(1, "piso"); // Al cargar el formulario por primera vez, se carga con el piso nro 1
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

        #region Carga de comboboxes para los filtros
        private void CargaComboBoxPisos()
        {
            List<PisoDTO> pisosDTO = this.habitacionController.ListarPisosActivos();
            cbxPisos.DataSource = pisosDTO;
            cbxPisos.DisplayMember = "Nro de Piso";
            cbxPisos.ValueMember = "IdPiso";
            cbxPisos.SelectedIndex = 0;
        }

        private void CargaComboBoxCategorias()
        {
            List<TipoHabitacionDTO> tipoHabitacionDTO = this.habitacionController.ListarTipoHabitacion();
            cbxCategorias.DataSource = tipoHabitacionDTO;
            cbxCategorias.DisplayMember = "Tipo";
            cbxCategorias.ValueMember = "IdTipoHabitacion";
            cbxCategorias.SelectedIndex = 0;
        }

        
        #endregion

        private void CargarGrillaHabitaciones(int valor, string filtro)
        {
            //limpiarGrilla();// Invisibiliza los paneles que representa las habitaciones y quita las acciones asociadas a los botones
            int cont = 1;
            List<HabitacionDTO> habitacionesFiltradas;

            if (filtro == "piso")
            {
                habitacionesFiltradas = habitacionController.ListarHabitacionesPorPiso(valor);

            }
            else if (filtro == "categoria")
            {
                habitacionesFiltradas = habitacionController.ListarHabitacionesPorTipo(valor);

            }
            else
            {
                //habitacionesFiltradas = habitacionController.ListarHabitacionesPorEstado(valor);
                habitacionesFiltradas = habitacionController.ListarHabitacionesCombinado(this.idPiso, this.idCategoria);
            }

            // Asiga la accion a los botones
            limpiarGrilla();
            //ConfigurarBotones(habitacionesFiltradas.Count());

            foreach (var habitacion in habitacionesFiltradas)
            {
                string nombreBotonHabitacion = "btnHabitacion" + cont.ToString();
                string nombreLabelNroHabitacion = "lblNroHabitacion" + cont.ToString();
                string nombreLabelCategoriaHabitacion = "lblCategoria" + cont.ToString();
                string nombreBtnHabitacionBotonInterno = "btnHabitacionBotonInterno" + cont.ToString();
                string nombreLabelDetalleHabitacion = "lblDetalle" + cont.ToString();
                // Encuentra el control (botón) en el formulario con el nombre especificado
                Control[] botonHabitacion = this.Controls.Find(nombreBotonHabitacion, true);
                Control[] lblNroHabitacion = this.Controls.Find(nombreLabelNroHabitacion, true);
                Control[] lblCategoriaHabitacion = this.Controls.Find(nombreLabelCategoriaHabitacion, true);
                Control[] lblDetalleHabitacion = this.Controls.Find(nombreLabelDetalleHabitacion, true);
                //if(this.Controls.Find(nombreLabelDetalleHabitacion, true))
                //MessageBox.Show(nombreLabelDetalleHabitacion, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (botonHabitacion.Length == 1 && botonHabitacion[0] is Panel)
                {
                    // Hace visible el botón correspondiente a la habitación, junto con sus componentes internos
                    ((Panel)botonHabitacion[0]).Visible = true;
                    ((Label)lblNroHabitacion[0]).Text = "Habitacion: " + habitacion.Numero;
                    ((Label)lblCategoriaHabitacion[0]).Text = "CATEGORIA: " + (habitacion.IdTipo).ToString();
                    ((Label)lblDetalleHabitacion[0]).Text = habitacion.Descripcion;
                    ((Label)lblDetalleHabitacion[0]).Visible = true;

                    // Cambio de colores de botones segun estado de la habitacion
                    Control[] btnHabitacionBotonInterno = this.Controls.Find(nombreBtnHabitacionBotonInterno, true);
                    ((Button)btnHabitacionBotonInterno[0]).Text = habitacion.Estado.ToUpper();
                    ((Button)btnHabitacionBotonInterno[0]).Tag = habitacion;
                    if (habitacion.Estado.ToUpper() == "DISPONIBLE")
                    {
                        ((Button)btnHabitacionBotonInterno[0]).BackColor = Color.FromArgb(14, 173, 133);
                        // Asiga la accion que se desencadena a la habitacion cuando se encuentra disponible
                        ((Button)btnHabitacionBotonInterno[0]).Click += MostrarDetallesDeHabitacion;
                    }
                    if (habitacion.Estado.ToUpper() == "OCUPADO")
                    {
                        ((Button)btnHabitacionBotonInterno[0]).BackColor = Color.FromArgb(218, 107, 91);
                        ((Button)btnHabitacionBotonInterno[0]).Click += MostrarDetallesDePago;
                        estado="Ocupado";

                    }
                    if (habitacion.Estado.ToUpper() == "TIEMPO REBASADO")
                    {
                        ((Button)btnHabitacionBotonInterno[0]).BackColor = Color.FromArgb(250, 90, 99);
                    }
                    if (habitacion.Estado.ToUpper() == "NECESITA LIMPIEZA")
                    {
                        ((Button)btnHabitacionBotonInterno[0]).BackColor = Color.FromArgb(90, 99, 118);
                        ((Button)btnHabitacionBotonInterno[0]).Click += CambiarEstado;
                    }
                }
                cont++;
            }
        }

        private void limpiarGrilla()
        {
            for (int i = 1; i < 17; i++)
            {
                string nombreBotonHabitacion = "btnHabitacion" + i.ToString();
                string nombreBotonInternoHabitacion = "btnHabitacionBotonInterno" + i.ToString();
                // Encuentra el control (botón) en el formulario con el nombre especificado
                Control[] botonHabitacion = this.Controls.Find(nombreBotonHabitacion, true);
                Control btonInternoHabitacion = this.Controls.Find(nombreBotonInternoHabitacion,true).First();
                if (botonHabitacion.Length == 1 && botonHabitacion[0] is Panel)
                {
                    // Hace invisible el botón correspondiente a la habitación, junto con sus componentes internos
                    ((Panel)botonHabitacion[0]).Visible = false;
                    // Elimina todos los manejadores de eventos de clic asociados al botón
                    ((Button)btonInternoHabitacion).Click -= MostrarDetallesDeHabitacion;
                    ((Button)btonInternoHabitacion).Click -= MostrarDetallesDePago;
                }
            }
        }

        #region Control de ventana del formulario (minimizar, maximizar, cerrar)
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
        #endregion

        #region Eventos que se desencadenan al cambiar de valor los comboboxes
        private void cbxPisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPisos.SelectedItem != null)
            {
                // Se obtiene el objeto PisoDTO seleccionado
                PisoDTO pisoSeleccionado = (PisoDTO)cbxPisos.SelectedItem;

                // Se accede a las propiedades del objeto PisoDTO
                int idPisoSeleccionado = pisoSeleccionado.IdPiso;

                CargarGrillaHabitaciones(idPisoSeleccionado, "piso");

            }
        }

        private void cbxCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCategorias.SelectedIndex != null)
            {
                // Se obtiene el valor seleccionado
                TipoHabitacionDTO categoriaSeleccionado = (TipoHabitacionDTO)cbxCategorias.SelectedItem;

                // Se accede a las propiedades del objeto PisoDTO
                int idCategoriaSeleccionado = categoriaSeleccionado.IdTipoHabitacion;

                CargarGrillaHabitaciones(idCategoriaSeleccionado, "categoria");

            }
        }

        private void cbxEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        #endregion


        private void CambiarEstado(object sender, EventArgs e)
        {
            Button boton = sender as Button;

            // Asegúrate de que el botón no sea nulo
            if (boton != null)
            {
                // Obtén la información de la habitación desde el Tag
                HabitacionDTO habitacion = (HabitacionDTO)boton.Tag;
                int numeroHabitacion;
                int.TryParse(habitacion.Numero, out numeroHabitacion);

                int id=habitacionController.Obtenernumero(numeroHabitacion);
                habitacionController.ActualizarEstadoHabitacion(id,"Disponible");
                CargarGrillaHabitaciones(1, "piso");
            }
            
        }
        // Accion que se desencadena al seleccionar una habitacion de la grilla
        private void MostrarDetallesDeHabitacion(object sender, EventArgs e)
        {
            // Obtén el botón que desencadenó el evento
            Button boton = sender as Button;

            // Asegúrate de que el botón no sea nulo
            if (boton != null)
            {
                // Obtén el número de botón
                int numeroBoton = ObtenerNumeroBoton(boton);

                // Asegúrate de que se pudo obtener el número del botón
                if (numeroBoton != -1)
                {
                    // Construye el nombre del control Label asociado al botón
                    string nombreLabel = $"lblNroHabitacion{numeroBoton}";

                    // Busca el lbl correspondiente en el formulario
                    Label lblNumeroHabitacion = this.Controls.Find(nombreLabel, true).FirstOrDefault() as Label;

                    // Asegúrate de que el lbl no sea nulo
                    if (lblNumeroHabitacion != null)
                    {
                        // Obtén el número de habitación del texto del lbl
                        string textoCompleto = lblNumeroHabitacion.Text;
                        int indiceInicioNumero = textoCompleto.IndexOf(':') + 1;
                        string numeroComoTexto = textoCompleto.Substring(indiceInicioNumero).Trim();
                        // Convierte la cadena a un número entero
                        int.TryParse(numeroComoTexto, out int numeroHabitacion);
                        //this.WindowState = FormWindowState.Minimized;
                        this.Hide();
                        this.ShowInTaskbar = false;
                        // Buscar el formulario Dashboard entre los formularios abiertos
                        RecepcionRegistro recepcionRegistro = Application.OpenForms.OfType<RecepcionRegistro>().FirstOrDefault();

                        // Si el formulario esta abierto hay que cerrarlo
                        if(recepcionRegistro != null)
                        {
                            // Se cierra el existente para actualizar datos
                            recepcionRegistro.Close();
                            recepcionRegistro = new RecepcionRegistro(numeroHabitacion);
                            recepcionRegistro.Show();
                            // Manejar el evento Closed para recargar el grid después de cerrar el formulario de creación
                            recepcionRegistro.Closed += (s, args) => CargarGrillaHabitaciones(1, "piso");
                            this.Hide();
                            this.ShowInTaskbar = false;
                        }
                        else if(recepcionRegistro == null)
                        {
                            recepcionRegistro = new RecepcionRegistro(numeroHabitacion);
                            recepcionRegistro.Show();
                            // Manejar el evento Closed para recargar el grid después de cerrar el formulario de creación
                            recepcionRegistro.Closed += (s, args) => CargarGrillaHabitaciones(1, "piso");
                            this.Hide();
                            this.ShowInTaskbar = false;
                        }
                    }
                }
            }
        }

        // Función para obtener el número del botón a partir de su nombre
        private int ObtenerNumeroBoton(Button boton)
        {
            // Asumiendo que el nombre del botón tiene el formato "btnHabitacionBotonInternoX"
            string nombreBoton = boton.Name;
            int numeroBoton;

            if (int.TryParse(nombreBoton.Substring(nombreBoton.Length - 1), out numeroBoton))
            {
                return numeroBoton;
            }

            // Si no se puede obtener el número del botón, devuelve -1
            return -1;
        }
        private void MensajedeLimpieza(object sender, EventArgs e)
        {
            MessageBox.Show("Limpieza en Habitacion");
        }
        // Accion que se desencadena cuando la habitacion se encuentra ocupada
        private void MostrarDetallesDePago(object sender, EventArgs e)
        {
            // Obtén el botón que desencadenó el evento
            Button boton = sender as Button;

            // Asegúrate de que el botón no sea nulo
            if (boton != null)
            {
                // Obtén la información de la habitación desde el Tag
                HabitacionDTO habitacion = (HabitacionDTO)boton.Tag;
                int numeroHabitacion;
                int.TryParse(habitacion.Numero, out numeroHabitacion);

                // Asegúrate de que se pudo obtener el número del botón
                    int id = reservaController.detallespago(numeroHabitacion, estado);
                if (id>0)
                    {
                        Pagos pagos = new Pagos(id);
                    pagos.Closed += (s, args) => CargarGrillaHabitaciones(1, "piso");
                    pagos.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se Pudo Obtener el Id de la Reserva");
                }
            }
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

        private void HabitacionesToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Obtén los valores seleccionados de los ComboBox
            PisoDTO pisoSeleccionado = (PisoDTO)cbxPisos.SelectedItem;
            TipoHabitacionDTO categoriaSeleccionada = (TipoHabitacionDTO)cbxCategorias.SelectedItem;

            this.idCategoria = categoriaSeleccionada.IdTipoHabitacion;
            this.idPiso = pisoSeleccionado.IdPiso;

            CargarGrillaHabitaciones(1,"combinada");
        }

        private void CargarGrillaHabitacionesCombinada(int idPiso, int idCategoria)
        {
            // Realiza la búsqueda combinada con ambos criterios
            List<HabitacionDTO> habitacionesFiltradas = habitacionController.ListarHabitacionesCombinado(idPiso, idCategoria);

            CargarGrillaHabitaciones(1,"combinada");
        }
    }
}
