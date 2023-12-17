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

namespace Presentation.Admin
{
    public partial class HabitacionAgregar : Form
    {
        private string piso;
        private string numero;
        private string precio;
        private int idHabitacion;
        private string descripcion;
        private readonly HabitacionController habitacionController;
        public HabitacionAgregar()
        {
            InitializeComponent();
            habitacionController = new HabitacionController();
        }

        public HabitacionAgregar( string piso, string numero, string precio, int idHabitacion, string descripcion)
        {
            InitializeComponent();
            habitacionController = new HabitacionController();
            this.piso = piso;
            this.numero = numero;
            this.precio = precio;
            this.idHabitacion = idHabitacion;
            this.descripcion = descripcion;
        }

        private void convertirStringAarray()
        {

            // Dividir la cadena usando el carácter '+'
            string[] arrayResultante = this.descripcion.Split('+').Select(s => s.Trim()).ToArray();
            
            MarcarCheckBoxesSegunArray(arrayResultante);
        }

        private void MarcarCheckBoxesSegunArray(string[] elementos)
        {
            // Recorrer cada elemento del array
            foreach (string elemento in elementos)
            {
                // Construir el nombre del CheckBox basado en el elemento
                string nombreCheckBox = "cbx" + elemento;

                // Buscar el control en el formulario por su nombre
                Control[] controles = this.Controls.Find(nombreCheckBox, true);

                // Verificar si se encontró el CheckBox
                if (controles.Length > 0 && controles[0] is CheckBox checkBox)
                {
                    // Marcar el CheckBox si se encontró
                    checkBox.Checked = true;
                }
            }
        }

        private void HabitacionAgregar_Load(object sender, EventArgs e)
        {
            if (this.piso != null)
            {
                convertirStringAarray();
            }
            
            CargaComboBoxPisos();
            CargaComboBoxCategorias();

            if (this.numero != null)
            {
                txtNro.Text = this.numero;
            }
            if (this.precio != null)
            {
                txtPrecio.Text = this.precio;
            }
        }

        private void CargaComboBoxPisos()
        {
            if (this.piso == null)
            {
                List<PisoDTO> pisosDTO = this.habitacionController.ListarPisos();
                cbxPisos.DataSource = pisosDTO;
                cbxPisos.DisplayMember = "Nro de Piso";
                cbxPisos.ValueMember = "IdPiso";
                cbxPisos.SelectedIndex = 0;
            }
            else
            {
                List<PisoDTO> pisosDTO = this.habitacionController.ListarPisos();
                cbxPisos.DataSource = pisosDTO;
                cbxPisos.DisplayMember = "Nro de Piso";
                cbxPisos.ValueMember = "IdPiso";
                cbxPisos.SelectedIndex = int.Parse(this.piso)-1;
            }
            
        }
        private void CargaComboBoxCategorias()
        {
            
                List<TipoHabitacionDTO> tipoHabitacionDTO = this.habitacionController.ListarTipoHabitacion();
                cbxTipo.DataSource = tipoHabitacionDTO;
                cbxTipo.DisplayMember = "Tipo";
                cbxTipo.ValueMember = "IdTipoHabitacion";
                cbxTipo.SelectedIndex = 0;
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada del carácter no válido
            }
        }

        private bool EsNumeroHabitacionUnico(int numero)
        {
            // Implementa la lógica para verificar si el número de habitación es único
            // Puedes consultar la base de datos u otra estructura de datos para verificar la unicidad
            // Devuelve true si es único, false si ya existe
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                return !hotelFive.Habitaciones.Any(p => p.Numero == numero);
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada del carácter no válido
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validar que el piso no tenga más de 16 habitaciones
            if (habitacionController.ContarHabitacionesEnPiso((int)cbxPisos.SelectedValue) >= 16)
            {
                MessageBox.Show("No se pueden agregar más habitaciones a este piso. Se ha alcanzado el límite de 16 habitaciones.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.numero == null)
            {
                // Valida que el número de piso sea único
                if (EsNumeroHabitacionUnico(int.Parse(txtNro.Text)))
                {
                    StringBuilder valoresConcatenados = new StringBuilder();
                    foreach (Control control in Controls)
                    {
                        if (control is CheckBox checkBox && checkBox.Checked)
                        {
                            // Aquí, reemplaza "ObtenerValor" con la lógica para obtener el valor del CheckBox
                            string valorCheckBox = ObtenerValor(checkBox);

                            if (!string.IsNullOrEmpty(valorCheckBox))
                            {
                                if (valoresConcatenados.Length > 0)
                                {
                                    valoresConcatenados.Append(" + ");
                                }

                                valoresConcatenados.Append(valorCheckBox);
                            }
                        }
                    }
                    string resultadoFinal = valoresConcatenados.ToString();

                    // Llama al método del controlador para agregar una nueva habitación
                    if (habitacionController.AgregarNuevaHabitacion(int.Parse(txtNro.Text),
                                                                resultadoFinal, int.Parse(txtPrecio.Text),
                                                                Convert.ToInt32(cbxTipo.SelectedValue),
                                                                (int)cbxPisos.SelectedValue))
                    {
                        // Muestra un MessageBox informando que la habitación se agregó con éxito
                        MessageBox.Show("Habitación agregada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        // Muestra un MessageBox informando el error si algo sale mal
                        MessageBox.Show($"Error al agregar la habitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("El número de habitación ingresado ya existe. Ingrese un número único.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                StringBuilder valoresConcatenados = new StringBuilder();
                foreach (Control control in Controls)
                {
                    if (control is CheckBox checkBox && checkBox.Checked)
                    {
                        // Aquí, reemplaza "ObtenerValor" con la lógica para obtener el valor del CheckBox
                        string valorCheckBox = ObtenerValor(checkBox);

                        if (!string.IsNullOrEmpty(valorCheckBox))
                        {
                            if (valoresConcatenados.Length > 0)
                            {
                                valoresConcatenados.Append(" + ");
                            }

                            valoresConcatenados.Append(valorCheckBox);
                        }
                    }
                }
                string resultadoFinal = valoresConcatenados.ToString();
                // Aquí puedes llamar a un método en el controlador para actualizar la habitación existente
                if (habitacionController.ActualizarHabitacionExistente(this.numero,int.Parse(this.piso), resultadoFinal,int.Parse(this.precio), Convert.ToInt32(cbxTipo.SelectedValue), this.idHabitacion))
                {
                    // Muestra un MessageBox informando que la habitación se actualizó con éxito
                    MessageBox.Show("Habitación actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    // Muestra un MessageBox informando el error si algo sale mal
                    MessageBox.Show($"Error al actualizar la habitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string ObtenerValor(CheckBox checkBox)
        {
            // Aquí asumo que has configurado los valores usando la propiedad Tag
            // Si usas otra propiedad para almacenar los valores, ajústalo según sea necesario
            return checkBox.Tag?.ToString() ?? string.Empty;
        }
    }
}
