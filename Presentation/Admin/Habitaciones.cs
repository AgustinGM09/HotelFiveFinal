using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using DataAccess;
using Presentation.Empleado;

namespace Presentation.Admin
{
    public partial class Habitaciones : Form
    {
        private string estadoSeleccionado = "";
        private readonly HabitacionController habitacionController;
        private bool filtroActivo = false;
        private int nivelPermiso;

        public Habitaciones()
        {
            InitializeComponent();
            habitacionController = new HabitacionController();
            CargarGridHabitaciones();
            lblUsuario.Text=DatosUsuario.GlobalVariables.NombreUsuario+" "+DatosUsuario.GlobalVariables.ApellidoUsuario;

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

        private void CargarGridHabitaciones1()
        {
            try
            {
                // Desuscribirse del evento para evitar múltiples suscripciones
                dataGridHabitaciones.CellContentClick -= DataGridHabitaciones_CellContentClick;

                // Obtener la lista de habitaciones
                var listaHabitaciones = habitacionController.ListarHabitaciones();

                // Asignar la lista como origen de datos para el DataGridView
                dataGridHabitaciones.DataSource = listaHabitaciones;
                dataGridHabitaciones.AutoGenerateColumns = false; // Desactiva la generación automática de columnas

                // Configurar las columnas manualmente
                dataGridHabitaciones.Columns.Clear(); // Limpiar columnas existentes

                // Agregar columna para IdHabitacion (oculta)
                dataGridHabitaciones.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "IdHabitacion",
                    Visible = false
                });

                // Agregar columnas visibles
                dataGridHabitaciones.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Numero",
                    HeaderText = "Número de Habitación"
                });

                dataGridHabitaciones.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "IdPiso",
                    HeaderText = "Piso"
                });

                dataGridHabitaciones.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Descripcion",
                    HeaderText = "Descripción"
                });

                dataGridHabitaciones.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Precio",
                    HeaderText = "Precio"
                });

                dataGridHabitaciones.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "IdTipo",
                    HeaderText = "Tipo"
                });

                dataGridHabitaciones.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Estado",
                    HeaderText = "Estado"
                });

                // Agregar columna de botón para dar de baja
                DataGridViewButtonColumn btnBaja = new DataGridViewButtonColumn
                {
                    Text = "Cambiar Estado",
                    UseColumnTextForButtonValue = true,
                    HeaderText = "Acciones",
                    Name = "btnBaja"
                };
                dataGridHabitaciones.Columns.Add(btnBaja);

                // Manejar el evento CellContentClick para detectar clics en los botones
                dataGridHabitaciones.CellContentClick += DataGridHabitaciones_CellContentClick;

                // Agregar columna de botón para editar
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn
                {
                    Text = "Editar",
                    UseColumnTextForButtonValue = true,
                    HeaderText = "Acciones",
                    Name = "btnEditar"
                };
                dataGridHabitaciones.Columns.Add(btnEditar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarGridHabitaciones()
        {
            try
            {
                // Desuscribirse del evento para evitar múltiples suscripciones
                dataGridHabitaciones.CellContentClick -= DataGridHabitaciones_CellContentClick;

                // Obtener la lista de habitaciones
                var listaHabitaciones = new List<HabitacionDTO>();

                if (filtroActivo)
                {
                    // Obtener el estado seleccionado en el ComboBox
                    estadoSeleccionado = cbxEstados.SelectedValue.ToString();

                    if(estadoSeleccionado == "5")
                    {
                        filtroActivo = false;
                        CargarGridHabitaciones();
                        return;
                    }

                    // Obtener la lista de habitaciones filtradas por estado
                    listaHabitaciones = habitacionController.ListarHabitacionesPorEstado(int.Parse(estadoSeleccionado));
                }
                else
                {
                    // Si no se debe aplicar el filtro, cargar todas las habitaciones
                    listaHabitaciones = habitacionController.ListarHabitaciones();
                }

                // Asignar la lista como origen de datos para el DataGridView
                dataGridHabitaciones.DataSource = listaHabitaciones;
                dataGridHabitaciones.AutoGenerateColumns = false; // Desactiva la generación automática de columnas

                // Configurar las columnas manualmente
                dataGridHabitaciones.Columns.Clear(); // Limpiar columnas existentes

                // Agregar columna para IdHabitacion (oculta)
                dataGridHabitaciones.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "IdHabitacion",
                    Visible = false
                });

                // Agregar columnas visibles
                dataGridHabitaciones.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Numero",
                    HeaderText = "Número de Habitación"
                });

                dataGridHabitaciones.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "IdPiso",
                    HeaderText = "Piso"
                });

                dataGridHabitaciones.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Descripcion",
                    HeaderText = "Descripción"
                });

                dataGridHabitaciones.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Precio",
                    HeaderText = "Precio"
                });

                dataGridHabitaciones.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "IdTipo",
                    HeaderText = "Tipo"
                });

                dataGridHabitaciones.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Estado",
                    HeaderText = "Estado"
                });

                // Agregar columna de botón para dar de baja
                DataGridViewButtonColumn btnBaja = new DataGridViewButtonColumn
                {
                    Text = "Cambiar Estado",
                    UseColumnTextForButtonValue = true,
                    HeaderText = "Acciones",
                    Name = "btnBaja"
                };
                dataGridHabitaciones.Columns.Add(btnBaja);

                // Manejar el evento CellContentClick para detectar clics en los botones
                dataGridHabitaciones.CellContentClick += DataGridHabitaciones_CellContentClick;

                // Agregar columna de botón para editar
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn
                {
                    Text = "Editar",
                    UseColumnTextForButtonValue = true,
                    HeaderText = "Acciones",
                    Name = "btnEditar"
                };
                dataGridHabitaciones.Columns.Add(btnEditar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void cbxEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Establecer filtroActivo en true para aplicar el filtro por estado
            filtroActivo = true;

            // Volver a cargar el DataGridView con el nuevo filtro y ordenación
            CargarGridHabitaciones();
        }

        private void DataGridHabitaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridHabitaciones.Rows.Count)
            {
                int idHabitacion = (int)dataGridHabitaciones.Rows[e.RowIndex].Cells[0].Value;
                string estadoActual = dataGridHabitaciones.Rows[e.RowIndex].Cells[6].Value.ToString();

                // Verificar si se hizo clic en el botón de editar
                if (e.ColumnIndex == dataGridHabitaciones.Columns["btnEditar"].Index)
                {
              
                    ModificarHabitacion(idHabitacion);
                }

                // Verificar si se hizo clic en el botón de baja
                if (e.ColumnIndex == dataGridHabitaciones.Columns["btnBaja"].Index)
                {
                    if (estadoActual == "Baja")
                    {
                        DialogResult result = MessageBox.Show("¿Estás seguro de que deseas cambiar el estado a Disponible?", "Confirmar cambio de estado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            // Lógica para cambiar el estado a Disponible
                            if (habitacionController.CambiarEstadoHabitacion(idHabitacion, "Disponible"))
                            {
                                CargarGridHabitaciones();
                            }
                            else
                            {
                                MessageBox.Show("Error al cambiar el estado de la habitación.");
                            }
                        }
                    }
                    else if (estadoActual == "Disponible")
                    {
                        DialogResult result = MessageBox.Show("¿Estás seguro de que deseas cambiar el estado a Baja?", "Confirmar cambio de estado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            // Lógica para cambiar el estado a Baja
                            if (habitacionController.CambiarEstadoHabitacion(idHabitacion, "Baja"))
                            {
                                CargarGridHabitaciones();
                            }
                            else
                            {
                                MessageBox.Show("Error al cambiar el estado de la habitación.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("La habitación debe estar en estado Baja o Disponible para cambiar el estado.");
                    }
                }
            }
        }

        private void ModificarHabitacion(int idHabitacion)
        {
            HabitacionDTO habitacion = habitacionController.ObtenerHabitacionPorIdd(idHabitacion);

            // Lógica para abrir un MessageBox y editar la habitación
            string mensaje = "Editar habitación NRO: " + habitacion.Numero + " ?";
            DialogResult result = MessageBox.Show(mensaje, "Editar Habitación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                HabitacionAgregar habitacionAgregar = new HabitacionAgregar(habitacion.IdPiso, habitacion.Numero, habitacion.Precio, habitacion.IdHabitacion, habitacion.Descripcion);
                habitacionAgregar.ShowDialog();
                CargarGridHabitaciones();
            }
            // Si el usuario elige "No", no se hace nada y el flujo continúa
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

        private void btnCrearHabitacion_Click(object sender, EventArgs e)
        {
            // Lógica para abrir un formulario de creación de habitación
            HabitacionAgregar habitacionAgregar = new HabitacionAgregar();

            // Manejar el evento Closed para recargar el grid después de cerrar el formulario de creación
            habitacionAgregar.Closed += (s, args) => CargarGridHabitaciones();

            habitacionAgregar.ShowDialog();
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
            }
            else
            {
                // Si ya está abierto, simplemente muéstralo
                dashboard.Show();
                dashboard.ShowInTaskbar = true;
            }
        }

        private void recepciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //recepcion.FormClosed += (s, args) => MostrarDashboard();
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
            }
            else
            {
                // Si ya está abierto, simplemente muéstralo
                recepcion.Show();
                recepcion.ShowInTaskbar = true;
            }
        }

        private void HabitacionToolStripMenuItem_Click(object sender, EventArgs e)
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
            }
            else
            {
                // Si ya está abierto, simplemente muéstralo
                habitaciones.Show();
                habitaciones.ShowInTaskbar = true;
                this.Close();
            }
        }

        private void PisosToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void Dashboar_Click_1(object sender, EventArgs e)
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
        private void recepciónToolStripMenuItem_Click_1(object sender, EventArgs e)
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
                ListadoPagos listadoPagos= Application.OpenForms.OfType<ListadoPagos>().FirstOrDefault();

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
                    reservadeCliente.Show(); this.Close();

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

        private void Habitaciones_Load(object sender, EventArgs e)
        {
            CargaComboBoxEstados();
        }

        private void CargaComboBoxEstados()
        {
            // Obtiene el diccionario de estados
            Dictionary<string, int> estados = this.habitacionController.ObtenerEstadosDeLasHabitaciones();

            // Agrega las opciones al ComboBox
            cbxEstados.DataSource = new BindingSource(estados, null);
            cbxEstados.DisplayMember = "Key";
            cbxEstados.ValueMember = "Value";

            // Selecciona la primera opción por defecto
            if (cbxEstados.Items.Count > 0)
            {
                cbxEstados.SelectedIndex = 0;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Establecer filtroActivo en true para aplicar el filtro por estado
            filtroActivo = true;

            // Volver a cargar el DataGridView con el nuevo filtro y ordenación
            CargarGridHabitaciones();
        }
    }
}
