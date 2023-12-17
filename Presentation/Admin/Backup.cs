using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Presentation.Properties;
using System.IO;
using System.Linq;
using DataAccess;
using Presentation.Empleado;
using System.Configuration;
using System.Data.Entity;

namespace Presentation.Admin
{
    public partial class Backup : Form
    {
        private int nivelPermiso;
        public Backup()
        {
            InitializeComponent();
            lblUsuario.Text=DatosUsuario.GlobalVariables.NombreUsuario+" "+DatosUsuario.GlobalVariables.ApellidoUsuario;
            nivelPermiso = DatosUsuario.GlobalVariables.PermisoUsuarioActual;
            #region Visibiliza solo los botones disponibles para cada perfil
            if (nivelPermiso == 2)
            {
                // Accedo a los elementos del menu para cambiar su visibilidad segùn cada perfil
                //ToolStripMenuItem dashboard = (ToolStripMenuItem)menuStrip1.Items[1];
                //dashboard.Visible = false;

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




        private void btnCopia_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtén la cadena de conexión desde el archivo de configuración
                string connectionString = "Data Source=LAPTOP-B48U3RS8\\MSSQLSERVER03;Initial Catalog=HotelFive;Integrated Security=True"; ;

                // Obtén la ubicación para guardar la copia de seguridad
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivo de Copia de Seguridad (*.bak)|*.bak";
                    saveFileDialog.Title = "Guardar Copia de Seguridad";
                    saveFileDialog.FileName = $"Backup_{DateTime.Now.ToString("yyyyMMddHHmmss")}.bak";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string rutaDeCopiaDeSeguridad = saveFileDialog.FileName;

                        using (var connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Comando SQL para realizar el backup
                            string backupCommand = $"BACKUP DATABASE [HotelFive] TO DISK = '{rutaDeCopiaDeSeguridad}' WITH FORMAT";

                            using (var command = new SqlCommand(backupCommand, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Copia de seguridad creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la copia de seguridad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que se haya seleccionado un archivo
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Por favor, seleccione un archivo de copia de seguridad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener la ruta del archivo de copia de seguridad desde el TextBox
                string rutaArchivoCopiaSeguridad = textBox1.Text;

                // Restaurar la base de datos cambiando el contexto a 'master'
                using (HotelFiveEntities hotelFive = new HotelFiveEntities())
                {
                    hotelFive.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, $"USE master RESTORE DATABASE HotelFive FROM DISK = '{rutaArchivoCopiaSeguridad}' WITH REPLACE");
                }

                MessageBox.Show("Restauración completada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error durante la restauración: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de Copia de Seguridad (*.bak)|*.bak|Todos los archivos (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                // Mostrar el cuadro de diálogo y esperar que el usuario seleccione un archivo
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Mostrar la ruta del archivo seleccionado en el TextBox
                    textBox1.Text = openFileDialog.FileName;
                }
            }
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

        private void habitacionesToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void toolStripMenuReportes_Click(object sender, EventArgs e)
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
            }
            else
            {
                // Si ya está abierto, simplemente muéstralo
                reportes.Show();
                reportes.ShowInTaskbar = true;
            }
        }

        private void Usuarios_Click(object sender, EventArgs e)
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
            }
            else
            {
                // Si ya está abierto, simplemente muéstralo
                usuarioListado.Show();
                usuarioListado.ShowInTaskbar = true;
            }
        }

        private void Clientes_Click(object sender, EventArgs e)
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
            }
            else
            {
                // Si ya está abierto, simplemente muéstralo
                clienteListado.Show();
                clienteListado.ShowInTaskbar = true;
            }
        }

        private void pisosToolStripMenuItem1_Click(object sender, EventArgs e)
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
            }
            else
            {
                // Si ya está abierto, simplemente muéstralo
                pisos.Show();
                pisos.ShowInTaskbar = true;
            }
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
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
            }
            else
            {
                // Si ya está abierto, simplemente muéstralo
                reportes.Show();
                reportes.ShowInTaskbar = true;
            }
        }

        private void listadoDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.ShowInTaskbar = false;

            // Buscar el formulario Habitaciones entre los formularios abiertos
            ListadoPagos reportes = Application.OpenForms.OfType<ListadoPagos>().FirstOrDefault();

            // Si el formulario Habitaciones no está abierto, créalo y ábrelo
            if (reportes == null)
            {
                reportes = new ListadoPagos();
                reportes.Show();
            }
            else
            {
                // Si ya está abierto, simplemente muéstralo
                reportes.Show();
                reportes.ShowInTaskbar = true;
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
                }
                else
                {
                    // Si ya está abierto, simplemente muéstralo
                    reservadeCliente.Show();
                    reservadeCliente.ShowInTaskbar = true;
                }
            }
            //else
            {
                //DatosUsuario.Mensajeadminrecepcionista();
            }
        }
    }
}