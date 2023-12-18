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
using Presentation.Empleado;

namespace Presentation.Admin
{
    public partial class Reportes : Form
    {

        private readonly HabitacionController habitacionController;
        private readonly ClienteController clienteController;
        private readonly ReservaController reservaController;
        private int nivelPermiso;
        private int filtro;

        public Reportes()
        {
            InitializeComponent();
            habitacionController = new HabitacionController();
            clienteController = new ClienteController();
            reservaController = new ReservaController();
            lblUsuario.Text=DatosUsuario.GlobalVariables.NombreUsuario+" "+DatosUsuario.GlobalVariables.ApellidoUsuario;

            nivelPermiso = DatosUsuario.GlobalVariables.PermisoUsuarioActual;
            #region Visibiliza solo los botones disponibles para cada perfil
            if (nivelPermiso == 2) //gerente
            {
                // Accedo a los elementos del menu para cambiar su visibilidad segùn cada perfil
                

                ToolStripMenuItem gestion = (ToolStripMenuItem)menuStrip1.Items[2];
                gestion.Visible = false;

                ToolStripMenuItem reportes = (ToolStripMenuItem)menuStrip1.Items[4];
                reportes.Visible = false;

                ToolStripMenuItem clientes = (ToolStripMenuItem)menuStrip1.Items[6];
                clientes.Visible = false;
            }
            else if (nivelPermiso == 1) //admin
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

                btnTopTipoHabitacionesMasReservadas.Visible = false;
                btnTopClientes.Visible = false;
                btnReservasPorMes.Location = new Point(600, 129);
                //filtro = 3;
            }
            #endregion
        }



        private void btnTopTipoHabitacionesMasReservadas_Click(object sender, EventArgs e)
        {
            filtro = 1;
            CargarDatosReporteTopTipoHabitacionesMasReservadasPorMes();
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            //CargarDatosReporteTopTipoHabitacionesMasReservadas();
        }

        private void CargarDatosReporteTopTipoHabitacionesMasReservadas()
        {
            try
            {
                lblTitulo.Text = "Habitaciones Más Reservadas";
                lblTitulo.Visible = true;

                DateTime fechaInicio = dateTimePicker1.Value;
                DateTime fechaFin = dateTimePicker2.Value ;
                fechaFin = fechaFin.AddSeconds(1);

                // Validar que la fecha de inicio sea mayor o igual a la fecha de fin
                if (fechaInicio > fechaFin)
                {
                    MessageBox.Show("La fecha de fin no puede ser menor que la fecha de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
     
                    return; // Salir del método si hay un error
                }

                // Obtener los tipos de habitaciones más reservados desde el controlador
                List<TipoHabitacionReservadaDTO> tiposHabitaciones = habitacionController.ObtenerTiposHabitacionesMasReservados(fechaInicio,fechaFin);

                // Asignar la lista al origen de datos del DataGridView
                dataGridReportes.DataSource = tiposHabitaciones;

                // Opcional: Ajustar el formato de las columnas si es necesario
                // Por ejemplo, puedes cambiar el nombre de las columnas
                dataGridReportes.Columns["TipoHabitacion"].HeaderText = "Tipo de Habitación";
                dataGridReportes.Columns["CantidadReservas"].HeaderText = "Cantidad de Reservas";

                MostrarGraficoTopTipoHabitacionesMasReservada();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       private void CargarDatosReporteTopTipoHabitacionesMasReservadasPorMes()
        {
            try
            {
                lblTitulo.Text = "Habitaciones Más Reservadas";
                lblTitulo.Visible = true;

                DateTime fechaInicio = dateTimePicker1.Value;
                DateTime fechaFin = dateTimePicker2.Value;
                fechaFin = fechaFin.AddSeconds(1);

                // Validar que la fecha de inicio sea mayor o igual a la fecha de fin
                if (fechaInicio > fechaFin)
                {
                    MessageBox.Show("La fecha de fin no puede ser menor que la fecha de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return; // Salir del método si hay un error
                }

                // Obtener los tipos de habitaciones más reservados desde el controlador
                List<TipoHabitacionReservadaDTO> tiposHabitaciones = habitacionController.ObtenerTiposHabitacionesMasReservadosDelMes();
                lblTitulo.Text = "Habitaciones Más Reservadas del Mes Actual";

                // Asignar la lista al origen de datos del DataGridView
                dataGridReportes.DataSource = tiposHabitaciones;

                // Opcional: Ajustar el formato de las columnas si es necesario
                // Por ejemplo, puedes cambiar el nombre de las columnas
                dataGridReportes.Columns["TipoHabitacion"].HeaderText = "Tipo de Habitación";
                dataGridReportes.Columns["CantidadReservas"].HeaderText = "Cantidad de Reservas";

                MostrarGraficoTopTipoHabitacionesMasReservada();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarGraficoTopTipoHabitacionesMasReservada()
        {
            // Limpiar el gráfico antes de agregar nuevos datos
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Title = "Tipo de Habitación";
            chart1.ChartAreas[0].AxisY.Title = "Cantidad de Reservas";

            // Crear una nueva serie para el gráfico
            chart1.Series.Add("Reservas por Tipo de Habitación");
            chart1.Series["Reservas por Tipo de Habitación"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;

            // Recorrer todas las filas del DataGridView
            foreach (DataGridViewRow row in dataGridReportes.Rows)
            {
                // Obtener los datos de la fila
                string tipoHabitacion = row.Cells["TipoHabitacion"].Value.ToString();
                int cantidadReservas = int.Parse(row.Cells["CantidadReservas"].Value.ToString());

                // Agregar un punto al gráfico para cada tipo de habitación
                chart1.Series["Reservas por Tipo de Habitación"].Points.AddXY(tipoHabitacion, cantidadReservas);
            }
        }

        private void btnTopClientes_Click(object sender, EventArgs e)
        {
            // Limpiar el DataGridView antes de cargar nuevos datos
            dataGridReportes.DataSource = null;
            dataGridReportes.Rows.Clear();
            dataGridReportes.Columns.Clear();

            try
            {
                lblTitulo.Text = "Top Clientes Del Mes Actual";
                lblTitulo.Visible = true;

                // Obtener los top clientes desde el controlador
                List<ClienteReservasDTO> topClientes = clienteController.ObtenerTopClientesDelMes(10);

                // Asignar la lista al origen de datos del DataGridView
                dataGridReportes.DataSource = topClientes;

                // Opcional: Ajustar el formato de las columnas si es necesario
                // Por ejemplo, puedes cambiar el nombre de las columnas
                dataGridReportes.Columns["IdCliente"].Visible = false;  // Si quieres ocultar la columna IdCliente
                dataGridReportes.Columns["Dni"].HeaderText = "DNI";
                dataGridReportes.Columns["CantidadReservas"].HeaderText = "Cantidad de Reservas";
                dataGridReportes.Columns["Telefono"].HeaderText = "Teléfono";
                dataGridReportes.Columns["CantidadReservas"].HeaderCell.Style.Font = new Font("Century Gothic", 8);
                dataGridReportes.Columns["FechaNacimiento"].HeaderText = "Fecha de Nacimiento";
                // Cambiar el tamaño de la letra del título de la columna "FechaNacimiento"
                dataGridReportes.Columns["FechaNacimiento"].HeaderCell.Style.Font = new Font("Century Gothic", 8);

                MostrarGraficoTopClientes();
                filtro = 2;
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void MostrarGraficoTopClientes()
        {
            // Limpiar el gráfico antes de agregar nuevos datos
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Title = "Clientes";
            chart1.ChartAreas[0].AxisY.Title = "Número de Reservas";

            // Crear una nueva serie para el gráfico
            chart1.Series.Add("Reservas por Cliente");
            chart1.Series["Reservas por Cliente"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;

            // Recorrer todas las filas del DataGridView
            foreach (DataGridViewRow row in dataGridReportes.Rows)
            {
                // Obtener los datos de la fila
                string nombreCliente = $"{row.Cells["Nombre"].Value} {row.Cells["Apellido"].Value}";
                int numeroReservas = int.Parse(row.Cells["CantidadReservas"].Value.ToString());

                // Agregar un punto al gráfico para cada cliente
                chart1.Series["Reservas por Cliente"].Points.AddXY(nombreCliente, numeroReservas);
            }
        }

        private void btnReservasPorMes_Click(object sender, EventArgs e)
        {
            lblTitulo.Text = "Reservas por Mes del Año Actualo";
            lblTitulo.Visible = true;
            filtro = 3;
            CargarDatosReporteReservasPorMes();
        }

        private void CargarDatosReporteReservasPorMes()
        {
            try
            {

                if (nivelPermiso == 1)
                {
                    // Obtener las reservas por mes desde el controlador
                    List<ReservasPorMesDTO> reservasPorMes = reservaController.ObtenerReservasPorMes();
                    // Asignar la lista al origen de datos del DataGridView
                    dataGridReportes.DataSource = reservasPorMes;

                    dataGridReportes.Columns["NombreMes"].HeaderText = "Nombre del Mes";
                    dataGridReportes.Columns["Anio"].HeaderText = "Año";
                    dataGridReportes.Columns["CantidadReservas"].HeaderText = "Cantidad de Reservas";
                    dataGridReportes.Columns["CantidadReservas"].HeaderCell.Style.Font = new Font("Century Gothic", 8);
                    dataGridReportes.Columns["IdUsuario"].Visible = false;

                    // Opcional: Mostrar el gráfico relacionado si es necesario
                    MostrarGraficoReservasPorMes(reservasPorMes);
                    return;
                }
                else
                {
                    //MessageBox.Show(DatosUsuario.GlobalVariables.Usuarioid.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    List<ReservasPorMesDTO> reservasPorMes = reservaController.ObtenerReservasPorMes(DatosUsuario.GlobalVariables.Usuarioid);

                    // Asignar la lista al origen de datos del DataGridView
                    dataGridReportes.DataSource = reservasPorMes;

                    dataGridReportes.Columns["NombreMes"].HeaderText = "Nombre del Mes";
                    dataGridReportes.Columns["Anio"].HeaderText = "Año";
                    dataGridReportes.Columns["CantidadReservas"].HeaderText = "Cantidad de Reservas";
                    dataGridReportes.Columns["CantidadReservas"].HeaderCell.Style.Font = new Font("Century Gothic", 8);
                    dataGridReportes.Columns["IdUsuario"].Visible = false;
                    // Opcional: Mostrar el gráfico relacionado si es necesario
                    MostrarGraficoReservasPorMes(reservasPorMes);
                }
                    

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosReporteReservasPorPeriodo(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
               
                if (nivelPermiso == 1)
                {
                    // Obtener las reservas por periodo desde el controlador
                    List<ReservasPorPeriodoDTO> reservasPorPeriodo1 = reservaController.ObtenerReservasPorPeriodo(fechaInicio, fechaFin);

                    // Asignar la lista al origen de datos del DataGridView
                    dataGridReportes.DataSource = reservasPorPeriodo1;

                    // Opcional: Mostrar el gráfico relacionado si es necesario
                    MostrarGraficoReservasPorPeriodo(reservasPorPeriodo1);
                }
                else
                {
                    //MessageBox.Show(DatosUsuario.GlobalVariables.Usuarioid.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Obtener las reservas por periodo desde el controlador
                    List<ReservasPorMesDTO> reservasPorPeriodo = reservaController.ObtenerReservasPorPeriodo(DatosUsuario.GlobalVariables.Usuarioid, fechaInicio, fechaFin);

                    // Asignar la lista al origen de datos del DataGridView
                    dataGridReportes.DataSource = reservasPorPeriodo;

                    //aca
                    dataGridReportes.Columns["NombreMes"].HeaderText = "Nombre del Mes";
                    dataGridReportes.Columns["Anio"].HeaderText = "Año";
                    dataGridReportes.Columns["CantidadReservas"].HeaderText = "Cantidad de Reservas";
                    dataGridReportes.Columns["CantidadReservas"].HeaderCell.Style.Font = new Font("Century Gothic", 8);
                    dataGridReportes.Columns["IdUsuario"].Visible = false;
                    // Opcional: Mostrar el gráfico relacionado si es necesario
                    MostrarGraficoReservasPorPeriodo(reservasPorPeriodo);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarGraficoReservasPorPeriodo(List<ReservasPorPeriodoDTO> reservasPorPeriodo)
        {
            // Limpiar el gráfico antes de agregar nuevos datos
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Title = "Periodo";
            chart1.ChartAreas[0].AxisY.Title = "Cantidad de Reservas";

            // Crear una nueva serie para el gráfico
            chart1.Series.Add("Reservas por Periodo");
            chart1.Series["Reservas por Periodo"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            // Recorrer todas las filas del DataGridView
            foreach (var reservaPorPeriodo in reservasPorPeriodo)
            {
                // Agregar un punto al gráfico para cada periodo
                chart1.Series["Reservas por Periodo"].Points.AddXY($"{reservaPorPeriodo.Anio}-{reservaPorPeriodo.Mes}", reservaPorPeriodo.CantidadReservas);
            }
        }

        private void MostrarGraficoReservasPorPeriodo(List<ReservasPorMesDTO> reservasPorPeriodo)
        {
            // Limpiar el gráfico antes de agregar nuevos datos
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Title = "Periodo";
            chart1.ChartAreas[0].AxisY.Title = "Cantidad de Reservas";

            // Crear una nueva serie para el gráfico
            chart1.Series.Add("Reservas por Periodo");
            chart1.Series["Reservas por Periodo"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            // Recorrer todas las filas del DataGridView
            foreach (var reservaPorPeriodo in reservasPorPeriodo)
            {
                // Agregar un punto al gráfico para cada periodo
                chart1.Series["Reservas por Periodo"].Points.AddXY($"{reservaPorPeriodo.Anio}-{reservaPorPeriodo.Mes}", reservaPorPeriodo.CantidadReservas);
            }
        }


        private void MostrarGraficoReservasPorMes(List<ReservasPorMesDTO> reservasPorMes)
        {
            // Limpiar el gráfico antes de agregar nuevos datos
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Title = "Mes";
            chart1.ChartAreas[0].AxisY.Title = "Cantidad de Reservas";

            // Crear una nueva serie para el gráfico
            chart1.Series.Add("Reservas por Mes");
            chart1.Series["Reservas por Mes"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            // Recorrer todas las filas del DataGridView
            foreach (var reservaPorMes in reservasPorMes)
            {
                // Agregar un punto al gráfico para cada mes
                chart1.Series["Reservas por Mes"].Points.AddXY(reservaPorMes.Mes, reservaPorMes.CantidadReservas);
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

        private void recepciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (DatosUsuario.TienePermisoAdminRecepcionista(DatosUsuario.GlobalVariables.PermisoUsuarioActual))
            {
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
            //else
            {
                //DatosUsuario.Mensajeadminrecepcionista();
            }
        }

        private void habitacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (DatosUsuario.TienePermisoAdminGerente(DatosUsuario.GlobalVariables.PermisoUsuarioActual))
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
            //else
            {
                //DatosUsuario.Mensajeadmingerente();
            }
        }

        private void toolStripMenuReportes_Click(object sender, EventArgs e)
        {

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
     

            if (filtro == 1)
            {
                CargarDatosReporteTopTipoHabitacionesMasReservadas();
                return;
            }
            else if (filtro == 2)
            {

                // Limpiar el DataGridView antes de cargar nuevos datos
                dataGridReportes.DataSource = null;
                dataGridReportes.Rows.Clear();
                dataGridReportes.Columns.Clear();

                try
                {
                    lblTitulo.Text = "Top Clientes";
                    lblTitulo.Visible = true;

                    DateTime fechaInicio = dateTimePicker1.Value;
                    DateTime fechaFin = dateTimePicker2.Value;
                    fechaFin = fechaFin.AddSeconds(1);

                    // Validar que la fecha de inicio sea mayor o igual a la fecha de fin
                    if (fechaInicio > fechaFin)
                    {
                        MessageBox.Show("La fecha de fin no puede ser menor que la fecha de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return; // Salir del método si hay un error
                    }

                    // Obtener los top clientes desde el controlador
                    List<ClienteReservasDTO> topClientes = clienteController.ObtenerTopClientesPorFechas(5, fechaInicio, fechaFin);

                    // Asignar la lista al origen de datos del DataGridView
                    dataGridReportes.DataSource = topClientes;

                    // Opcional: Ajustar el formato de las columnas si es necesario
                    // Por ejemplo, puedes cambiar el nombre de las columnas
                    dataGridReportes.Columns["IdCliente"].Visible = false;  // Si quieres ocultar la columna IdCliente
                    dataGridReportes.Columns["Dni"].HeaderText = "DNI";
                    dataGridReportes.Columns["CantidadReservas"].HeaderText = "Cantidad de Reservas";
                    dataGridReportes.Columns["Telefono"].HeaderText = "Teléfono";
                    dataGridReportes.Columns["CantidadReservas"].HeaderCell.Style.Font = new Font("Century Gothic", 8);
                    dataGridReportes.Columns["FechaNacimiento"].HeaderText = "Fecha de Nacimiento";
                    // Cambiar el tamaño de la letra del título de la columna "FechaNacimiento"
                    dataGridReportes.Columns["FechaNacimiento"].HeaderCell.Style.Font = new Font("Century Gothic", 8);

                    MostrarGraficoTopClientes();
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los datos del reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (filtro == 3)
            {
                //MessageBox.Show(DatosUsuario.GlobalVariables.Usuarioid.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTitulo.Text = "Reservas por Período";
                lblTitulo.Visible = true;
                if (filtro == 3) 
                {
                    DateTime fechaInicio = dateTimePicker1.Value;
                    DateTime fechaFin = dateTimePicker2.Value;
                    fechaFin = fechaFin.AddSeconds(1);
                    // Validar que la fecha de inicio sea mayor o igual a la fecha de fin
                    if (fechaInicio > fechaFin)
                    {
                        MessageBox.Show("La fecha de fin no puede ser menor que la fecha de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return; // Salir del método si hay un error
                    }
                    CargarDatosReporteReservasPorPeriodo(fechaInicio, fechaFin);
                    return;
                }
                else
                {
                    lblTitulo.Text = "Reservas por Mes del Año Actual";
                    lblTitulo.Visible = true;
                    CargarDatosReporteReservasPorMes();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un tipo de reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return; // Salir del método si hay un error
            }
            
        }
    }
}
