using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Admin
{
    public partial class AgregarReservaCliente : Form
    {
        private HabitacionController habitacionController;
        private ClienteReservaController clienteReservaController;
        private ClienteController clienteController;
        public AgregarReservaCliente()
        {
            InitializeComponent();
            habitacionController = new HabitacionController();
            clienteReservaController = new ClienteReservaController();
            clienteController = new ClienteController();
            cargarcombobox();
        }

        private void cargarcombobox()
        {
            #region Asigna la lista de tipos de usuarios al combo box
            // Se obtiene el listado de los tipos de usuarios
            List<TipoHabitacionDTO> listaTipoHabitacionDTO = habitacionController.ListarTipoHabitacion();

            // Se asigna la lista como origen de datos para el ComboBox
            cboTipoHabitacion.DataSource = listaTipoHabitacionDTO;

            // Se define qué propiedad del DTO se mostrará en el ComboBox
            cboTipoHabitacion.DisplayMember = "Tipo";

            // Se define qué propiedad del DTO se utilizará como valor seleccionado
            cboTipoHabitacion.ValueMember = "IdTipoHabitacion";

            #endregion

            //Validar dtpFechaEntrada
            // Obtén la fecha actual
            DateTime fechaActual = DateTime.Now;

            // Establece la fecha mínima en el DateTimePicker para ser la fecha actual
            dateTimeFechaEntrada.MinDate = fechaActual;
            dateTimeFechaSalida.MinDate = fechaActual.AddDays(1);
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            //permitir solo la entrada de dígitos numéricos y teclas de control (como Retroceso o Eliminar)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada del carácter no válido
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que todos los campos estén completos
                if (string.IsNullOrWhiteSpace(txtDni.Text) ||
                    cboTipoHabitacion.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, complete todos los campos antes de agregar una reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sale del método si la validación falla
                }
                if (dateTimeFechaEntrada.Value > dateTimeFechaSalida.Value) {
                    MessageBox.Show("Por favor, complete seleccione una fecha acorde", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sale del método si la validación falla
                            // Recopila los datos del formulario
                }
                    int dni = int.Parse(txtDni.Text);
                if (clienteController.ObtenerClientePorDNI(dni) == 1)
                {
                    DateTime fechaInicio = dateTimeFechaEntrada.Value;
                    DateTime fechaSalida = dateTimeFechaSalida.Value;

                    // Obtener el día, mes y año por separado
                    int diafin = fechaSalida.Day;
                    int mesfin = fechaSalida.Month;
                    int añofin = fechaSalida.Year;
                    int diainicio = fechaInicio.Day;
                    int mesinicio = fechaInicio.Month;
                    int añoinicio = fechaInicio.Year;
                    // Crear un nuevo objeto DateTime solo con día, mes y año
                    DateTime fechafin = new DateTime(añofin, mesfin, diafin);
                    DateTime fechainicio = new DateTime(añoinicio, mesinicio, diainicio);
                    int habitacion = Convert.ToInt32(cboTipoHabitacion.SelectedValue);

                    // Llamar al controlador para agregar el usuario y le paso los datos
                    clienteReservaController.GuardarDetallesReserva(dni, habitacion, fechainicio, fechafin);

                    MessageBox.Show("Reserva agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cliente no Registrado");
                    return;
                }

                this.Close();
            }
            catch (DbEntityValidationException ex)
            {
                // La excepción contiene información sobre los errores de validación
                foreach (var entityValidationError in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationError.ValidationErrors)
                    {
                        // Accede a los detalles del error de validación
                        string propertyName = validationError.PropertyName;
                        string errorMessage = validationError.ErrorMessage;

                        // Muestra el mensaje de error al usuario o regístralo para diagnóstico
                        MessageBox.Show($"Error de validación en la propiedad '{propertyName}': {errorMessage}", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
