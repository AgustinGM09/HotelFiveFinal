using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Admin
{
    public partial class ClienteAgregar : Form
    {
        private ClienteController clienteController;
        public ClienteAgregar()
        {
            InitializeComponent();
            this.clienteController = new ClienteController();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que todos los campos estén completos
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtDni.Text) || 
                    string.IsNullOrWhiteSpace(txtFechaN.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos antes de agregar un cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sale del método si la validación falla
                }

                // Recopila los datos del formulario
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                int telefono = int.Parse(txtTelefono.Text);
                string email = txtEmail.Text;
                int dni = int.Parse(txtDni.Text);
                string fechanacimiento = txtFechaN.Text;

                // Llamar al controlador para agregar el usuario y le paso los datos
                if (this.clienteController.AgregarCliente(nombre, apellido, telefono, email, dni, fechanacimiento))
                {
                    MessageBox.Show("Cliente agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    MessageBox.Show("Error al Ingresar el Cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada del carácter no válido
            }
        }

        //Controlador del evento KeyPress para validar cada tecla que se presiona
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada del carácter no válido
            }
        }

        //Controlador del evento KeyPress para validar cada tecla que se presiona
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada del carácter no válido
            }
        }

        //  Cuando el usuario tabule fuera del campo email, se desencadenará este evento.
        private void txtEmail_Validated(object sender, EventArgs e)
        {
            string email = txtEmail.Text;

            if (IsValidEmail(email))
            {
                // El correo electrónico es válido, no es necesario hacer nada.
            }
            else
            {
                MessageBox.Show("El correo electrónico no es válido. Por favor, ingrese un correo electrónico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                txtEmail.SelectAll();
            }
        }

        // Verifica el formato del correo electrónico utilizando una expresión regular
        static bool IsValidEmail(string email)
        {
            string pattern = @"^(?:[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}|)$";
            return Regex.IsMatch(email, pattern);
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
