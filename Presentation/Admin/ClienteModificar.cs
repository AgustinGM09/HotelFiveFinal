using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Admin
{
    public partial class ClienteModificar : Form
    {
        private int idcliente; //ID del usuario que se va actualizar
        private ClienteController clienteController; // Atributo para almacenar la instancia de UsuarioController
        private Clientes cliente;
        public ClienteModificar(int idCliente)
        {
            InitializeComponent();
            this.idcliente = idCliente;
            this.clienteController = new ClienteController();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener datos del formulario
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                int telefono = int.Parse(txtTelefono.Text);
                string email = txtEmail.Text;
                int dni = int.Parse(txtDni.Text);
                string fechanacimiento = txtFechaN.Text;

                
                clienteController.ActualizarCliente(idcliente, nombre, apellido, telefono, email, dni,fechanacimiento);

                MessageBox.Show("Cliente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            {
                // Manejar la excepción o mostrar un mensaje de error
                MessageBox.Show("Error al actualizar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClienteModificar_Load(object sender, EventArgs e)
        {
            //this.tipo_UsuarioTableAdapter.Fill(this.hotelFiveDataSet.Tipo_Usuario);// NO BORRAR
            cliente = this.clienteController.ObtenerClientePorId(this.idcliente);
            // Verificar si se obtuvieron detalles
            if (cliente != null)
            {
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtTelefono.Text = cliente.Telefono.ToString(); // Convertir a string si es necesario
                txtEmail.Text = cliente.Email;
                txtFechaN.Text= cliente.FechaNacimiento;
                txtDni.Text = cliente.Dni.ToString(); // Convertir a string si es necesario
            }
            else
            {
                MessageBox.Show("No se pudo encontrar el cliente seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region Validaciones
        //Controlador del evento KeyPress para validar cada tecla que se presiona
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada del carácter no válido
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada del carácter no válido
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada del carácter no válido
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
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
        #endregion
    }
}
