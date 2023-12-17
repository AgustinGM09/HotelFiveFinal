using DataAccess;
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
    public partial class Pisos : Form
    {
        private readonly HabitacionController habitacionController;
        private int nivelPermiso;

        public Pisos()
        {
            InitializeComponent();
            habitacionController = new HabitacionController();
            CargarGridPisos();
            lblUsuario.Text=DatosUsuario.GlobalVariables.NombreUsuario+" "+DatosUsuario.GlobalVariables.ApellidoUsuario;
            dataGridPisos.CellFormatting += dataGridPisos_CellFormatting;
            dataGridPisos.CellContentClick += DataGridPisos_CellContentClick;
            //habitacionController = new HabitacionController();

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

        private void CargarGridPisos()
        {
            try
            {
                // Obtener la lista de pisos
                var listaPisos = habitacionController.ListarPisos();

                // Asignar la lista como origen de datos para el DataGridView
                dataGridPisos.DataSource = listaPisos;

                dataGridPisos.AutoGenerateColumns = false; // Desactiva la generación automática de columnas

                // Configurar las columnas manualmente
                dataGridPisos.Columns.Clear(); // Limpiar columnas existentes

                // Agregar columnas visibles
                dataGridPisos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "NroPiso", // Asociar con la propiedad NroPiso del PisoDTO
                    HeaderText = "Nro de Piso"
                });

                dataGridPisos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Estado", // Asociar con la propiedad Estado del PisoDTO
                    HeaderText = "Estado"
                });

                // Agregar columna para IdPiso (oculta)
                dataGridPisos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "IdPiso", // Asegúrate de que este nombre coincida con la propiedad en PisoDTO
                    HeaderText = "Id",
                    Visible = false
                });

                // Agregar columna de botón para dar de baja o dar de alta
                DataGridViewButtonColumn btnBajaAlta = new DataGridViewButtonColumn
                {
                    UseColumnTextForButtonValue = true, // Mostrar el texto en lugar de un botón de comando
                    HeaderText = "Acciones",
                    Name = "btnBajaAlta"
                };

                // Agregar la columna de botón al DataGridView
                dataGridPisos.Columns.Add(btnBajaAlta);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridPisos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verificar si la columna es la de botones y la fila no es la fila de encabezado
            if (e.ColumnIndex >= 0 && dataGridPisos.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Obtener el estado actual de la celda
                string estado = dataGridPisos.Rows[e.RowIndex].Cells[1].Value.ToString();

                // Establecer el texto del botón según el estado actual
                e.Value = "Cambiar de Estado";
            }
        }

        private void DataGridPisos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se hizo clic en la columna del botón y la fila no es la cabecera
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridPisos.Columns[3].Index)
            {
                // Obtener el IdPiso de la fila seleccionada
                int idPiso = (int)dataGridPisos.Rows[e.RowIndex].Cells[2].Value;

                // Obtener el estado actual del piso
                string estadoActual = dataGridPisos.Rows[e.RowIndex].Cells[1].Value.ToString();

                // Mostrar un mensaje de confirmación
                DialogResult result = MessageBox.Show($"¿Estás seguro de que deseas cambiar el estado del piso a {(estadoActual == "Baja" ? "Alta" : "Baja")}? También se cambiará el estado de las habitaciones asociadas.", "Confirmar cambio de estado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Verificar la respuesta del usuario
                if (result == DialogResult.Yes)
                {
                    // Llamar al método para cambiar el estado del piso y sus habitaciones
                    CambiarEstadoPisoConHabitaciones(idPiso, estadoActual);

                    // Volver a cargar el grid de pisos
                    CargarGridPisos();
                }
            }
        }

        private void CambiarEstadoPisoConHabitaciones(int idPiso, string estadoActual)
        {
            try
            {
                using (HotelFiveEntities hotelFive = new HotelFiveEntities())
                {
                    // Obtener el piso y sus habitaciones asociadas
                    var piso = hotelFive.Piso.Include("Habitaciones").FirstOrDefault(p => p.idPiso == idPiso);

                    if (piso != null)
                    {
                        // Verificar si todas las habitaciones están en estado "Disponible" o "Baja"
                        bool todasDisponiblesOBaja = piso.Habitaciones.All(h => h.Estado == "Disponible");

                        // Verificar si alguna habitación está en estado "Ocupado"
                        bool algunaOcupada = piso.Habitaciones.Any(h => h.Estado == "Ocupado");

                        if (estadoActual == "Activo" && (!todasDisponiblesOBaja || algunaOcupada))
                        {
                            if (!todasDisponiblesOBaja)
                            {
                                MessageBox.Show("No todas las habitaciones están en estado 'Disponible' o 'Baja'.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else if (algunaOcupada)
                            {
                                MessageBox.Show("Hay habitaciones en estado 'Ocupado'.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            return; // Salir del método sin hacer cambios
                        }

                        // Cambiar el estado del piso
                        piso.Estado = (estadoActual == "Baja") ? "Activo" : "Baja";

                        // Cambiar el estado de todas las habitaciones asociadas al piso
                        foreach (var habitacion in piso.Habitaciones)
                        {
                            habitacion.Estado = (piso.Estado == "Baja") ? "Baja" : "Disponible";
                        }

                        // Guardar los cambios en la base de datos
                        hotelFive.SaveChanges();

                        // Mostrar un mensaje de éxito
                        MessageBox.Show($"El estado del piso y sus habitaciones han sido cambiados a {piso.Estado} correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error si la actualización falla
                MessageBox.Show($"Error al cambiar el estado del piso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void EliminarPisoConHabitaciones(int idPiso)
        {
            try
            {
                using (HotelFiveEntities hotelFive = new HotelFiveEntities())
                {
                    // Obtener el piso y sus habitaciones asociadas
                    var piso = hotelFive.Piso.Include("Habitaciones").FirstOrDefault(p => p.idPiso == idPiso);

                    if (piso != null)
                    {
                        // Cambiar el estado de las habitaciones asociadas al piso a "Baja"
                        foreach (var habitacion in piso.Habitaciones)
                        {
                            habitacion.Estado = "Baja";
                        }

                        // Cambiar el estado del piso a "Baja"
                        piso.Estado = "Baja";

                        // Guardar los cambios en la base de datos
                        hotelFive.SaveChanges();
                    }

                    // Mostrar un mensaje de éxito
                    MessageBox.Show("El piso y sus habitaciones han sido dados de baja correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error si la actualización falla
                MessageBox.Show($"Error al dar de baja el piso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCrearPiso_Click(object sender, EventArgs e)
        {
            try
            {
                // Muestra un cuadro de diálogo para que el usuario ingrese el número del piso
                string nroPiso = Microsoft.VisualBasic.Interaction.InputBox(
                    "Ingrese el número de piso: ",
                    "Nuevo Piso",
                    "");

                // Valida que el usuario no haya cancelado la operación
                if (!string.IsNullOrWhiteSpace(nroPiso))
                {
                    // Valida que el input sea un número positivo
                    if (int.TryParse(nroPiso, out int numeroPiso) && numeroPiso > 0)
                    {
                        // Valida que el número de piso sea único
                        if (EsNumeroPisoUnico(numeroPiso))
                        {
                            // Llama al método del controlador para agregar un nuevo piso
                            habitacionController.AgregarNuevoPiso(numeroPiso.ToString());

                            // Vuelve a cargar el grid de pisos
                            CargarGridPisos();
                        }
                        else
                        {
                            MessageBox.Show("El número de piso ingresado ya existe. Ingrese un número único.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un número de piso válido y positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error si la operación falla
                MessageBox.Show($"Error al agregar el nuevo piso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool EsNumeroPisoUnico(int numeroPiso)
        {
            // Implementa la lógica para verificar si el número de piso es único
            // Puedes consultar la base de datos u otra estructura de datos para verificar la unicidad
            // Devuelve true si es único, false si ya existe
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                return !hotelFive.Piso.Any(p => p.NumeroPiso == numeroPiso);
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
    }
}
