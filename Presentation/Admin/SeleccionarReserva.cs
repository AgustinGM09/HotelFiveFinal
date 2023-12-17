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
    public partial class SeleccionarReserva : Form
    {
        public int IdClienteReservaSeleccionado { get; private set; }
        private ClienteReservaController clienteReservaController;
        private DateTime fecha = DateTime.Now;
        public SeleccionarReserva()
        {
            InitializeComponent();
            clienteReservaController = new ClienteReservaController();
            cargarDatagrid();
        }

        public void cargarDatagrid()
        {
            
            var reservas = clienteReservaController.ObtenerLasReservasdelDia(fecha);

            // Asigna la lista de reservas al DataSource del DataGridView
            dataGridClienteReserva.DataSource = reservas;

            dataGridClienteReserva.Columns["DniCliente"].HeaderText = "Dni de Cliente";
            dataGridClienteReserva.Columns["HabitacionID"].HeaderText = "Tipo de Habitacion";
            dataGridClienteReserva.Columns["FechaInicio"].HeaderText = "Fecha de Inicio";
            dataGridClienteReserva.Columns["FechaFin"].HeaderText = "Fecha de Fin";
            dataGridClienteReserva.CellFormatting += dataGridClienteReserva_CellFormatting;

            // Ocultar las columnas que no deseas mostrar
            dataGridClienteReserva.Columns["IdClienteReserva"].Visible = false;
            dataGridClienteReserva.Columns["ClienteID"].Visible = false;
        }

        private void dataGridClienteReserva_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verificar si la celda pertenece a la columna "HabitacionID"
            if (e.ColumnIndex == dataGridClienteReserva.Columns["HabitacionID"].Index && e.RowIndex >= 0)
            {
                // Obtener el valor de la celda
                int tipoHabitacion = Convert.ToInt32(e.Value);

                // Asignar el nuevo valor de texto en función del tipo de habitación
                switch (tipoHabitacion)
                {
                    case 1:
                        e.Value = "Individual";
                        break;
                    case 2:
                        e.Value = "Doble";
                        break;
                    case 3:
                        e.Value = "Familiar";
                        break;
                }

                // Indicar que el formato ha sido aplicado
                e.FormattingApplied = true;
            }
        }

        private void btnAeptar_Click(object sender, EventArgs e)
        {
            if (dataGridClienteReserva.SelectedRows.Count > 0)
            {
                // Obtener el valor de la celda que contiene la información que necesitas
                IdClienteReservaSeleccionado = (int)dataGridClienteReserva.SelectedRows[0].Cells["IdClienteReserva"].Value;

                // Cerrar el formulario con DialogResult.OK para indicar que se seleccionó algo
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                // Mostrar un mensaje indicando que no se ha seleccionado ninguna reserva
                MessageBox.Show("Por favor, seleccione una reserva antes de hacer clic en Aceptar.", "Selección No Válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarDNI_Click(object sender, EventArgs e)
        {
            int dni = 0;

            // Intentar convertir el valor ingresado en el TextBox "DNI" a un entero si no está en blanco
            if (!string.IsNullOrEmpty(txtDNI.Text))
            {
                if (!int.TryParse(txtDNI.Text, out int dniValue))
                {
                    // Manejar el caso en el que el valor no sea un número entero válido
                    MessageBox.Show("Por favor, ingrese un número de DNI válido.");
                    return;
                }
                dni = dniValue;

                var reservas = clienteReservaController.buscarreservapordni(dni,fecha);

                dataGridClienteReserva.DataSource = reservas;

                dataGridClienteReserva.Columns["DniCliente"].HeaderText = "Dni de Cliente";
                dataGridClienteReserva.Columns["HabitacionID"].HeaderText = "Tipo de Habitacion";
                dataGridClienteReserva.Columns["FechaInicio"].HeaderText = "Fecha de Inicio";
                dataGridClienteReserva.Columns["FechaFin"].HeaderText = "Fecha de Fin";
                

                // Ocultar las columnas que no deseas mostrar
                dataGridClienteReserva.Columns["IdClienteReserva"].Visible = false;
                dataGridClienteReserva.Columns["ClienteID"].Visible = false;
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
    }
}
