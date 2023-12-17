using DataAccess;
using Domain;
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
    public partial class ModificarReservaCliente : Form
    {
        private int idReservaCliente;
        private ClienteReservaController clienteReservaController;
        private ClienteReserva clienteReserva;
        private HabitacionController habitacionController;
        private ClienteController clienteController;
        public ModificarReservaCliente(int idReserva)
        {
            InitializeComponent();
            idReservaCliente = idReserva;
            clienteReservaController = new ClienteReservaController();
            habitacionController = new HabitacionController();
            clienteController = new ClienteController();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateTimeFechaEntrada.Value > dateTimeFechaSalida.Value)
                {
                    MessageBox.Show("Por favor, complete seleccione una fecha acorde", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sale del método si la validación falla
                            // Recopila los datos del formulario
                }
                // Obtener datos del formulario
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
                DateTime fechainicio= new DateTime(añoinicio, mesinicio, diainicio);
                // Ahora puedes usar fechaFin como desees

                int dni = int.Parse(txtDni.Text);
                int habitacion = Convert.ToInt32(cboTipoHabitacion.SelectedValue);

                int DNI= clienteController.ObtenerCliente(dni);
                clienteReservaController.ActualizarDatos(idReservaCliente,DNI,habitacion,fechainicio, fechafin);

                MessageBox.Show("Reserva actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch
            {
                // Manejar la excepción o mostrar un mensaje de error
                MessageBox.Show("Error al actualizar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void ReservaClienteModificar_Load(object sender, EventArgs e)
        {
            clienteReserva = clienteReservaController.ObtenerClienteReservaPorId(idReservaCliente); ;
            // Verificar si se obtuvieron detalles
            if (clienteReserva != null)
            {
                txtDni.Text = clienteReserva.Clientes.Dni.ToString();
                dateTimeFechaEntrada.Value = (DateTime)clienteReserva.FechaInicio;
                dateTimeFechaSalida.Value = (DateTime)clienteReserva.FechaFin;
                
                #region Asigna la lista de tipos de habitaciones al combo box
                // Se obtiene el listado de los tipos de usuarios
                List<TipoHabitacionDTO> listaTipoHabitacionDTO = habitacionController.ListarTipoHabitacion();

                // Se asigna la lista como origen de datos para el ComboBox
                cboTipoHabitacion.DataSource = listaTipoHabitacionDTO;

                // Se define qué propiedad del DTO se mostrará en el ComboBox
                cboTipoHabitacion.DisplayMember = "Tipo";

                // Se define qué propiedad del DTO se utilizará como valor seleccionado
                cboTipoHabitacion.ValueMember = "IdTipoHabitacion";

                cboTipoHabitacion.SelectedValue = clienteReserva.HabitacionID;
                #endregion
                //Validar dtpFechaEntrada
                // Obtén la fecha actual
                DateTime fechaActual = DateTime.Now;

                // Establece la fecha mínima en el DateTimePicker para ser la fecha actual
                dateTimeFechaEntrada.MinDate = fechaActual;
                dateTimeFechaSalida.MinDate = fechaActual.AddDays(1);
            }
            else
            {
                MessageBox.Show("No se pudo encontrar la reserva seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
