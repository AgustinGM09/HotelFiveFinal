using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Data.Entity.Validation;
using Domain;
using DataAccess;

namespace Presentation.Admin
{
    public partial class UsuarioAgregar : Form
    {
        private UsuarioController usuarioController; // Atributo para almacenar la instancia de UsuarioController

        public UsuarioAgregar()
        {
            InitializeComponent();
            this.usuarioController = new UsuarioController(); // Crear la instancia de UsuarioController
        }

        // Evento que se disparará después de agregar un nuevo usuario
        public event EventHandler UsuarioAgregado;

        // Método para disparar el evento
        protected virtual void OnUsuarioAgregado(EventArgs e)
        {
            UsuarioAgregado?.Invoke(this, e);
        }

        #region Codigo para arrastrar el formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam); 

        private void UsuarioAgregar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que todos los campos estén completos
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtDni.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                    cboTipoUsuario.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, complete todos los campos antes de agregar un usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sale del método si la validación falla
                }

                // Recopila los datos del formulario
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                int telefono = int.Parse(txtTelefono.Text);
                string email = txtEmail.Text;
                int dni = int.Parse(txtDni.Text);
                string contraseña = txtContraseña.Text;
                int idTipoUsuario = Convert.ToInt32(cboTipoUsuario.SelectedValue);
                int baja = 1;

                using (HotelFiveEntities hotelFive = new HotelFiveEntities())
                {
                    if (hotelFive.Usuarios.Any(p => p.DNI == dni))
                    {
                        MessageBox.Show("Error al ingresar el Usuario. DNI ya existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    };
                }

                using (HotelFiveEntities hotelFive = new HotelFiveEntities())
                {
                    if (hotelFive.Usuarios.Any(p => p.email == email))
                    {
                        MessageBox.Show("Error al ingresar el Usuario. DNI ya existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    };
                }

                // Llamar al controlador para agregar el usuario y le paso los datos
                if (this.usuarioController.AgregarUsuario(nombre, apellido, telefono, email, dni, idTipoUsuario, contraseña, baja))
                {
                    MessageBox.Show("Usuario agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    MessageBox.Show("Error al ingresar el Usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Dispara el evento después de agregar el usuario
                OnUsuarioAgregado(EventArgs.Empty);

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

        #region Validaciones
        //Controlador del evento KeyPress para validar cada tecla que se presiona
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
        #endregion

        private void UsuarioAgregar_Load(object sender, EventArgs e)
        {
            //carga datos en la tabla 'hotelFiveDataSet.Tipo_Usuario'.
            // Se obtiene el listado de los tipos de usuarios
            List<TipoUsuarioDTO> listaTipoUsuariosDTO = this.usuarioController.ListarTipoUsuarios();

            // Se asigna la lista como origen de datos para el ComboBox
            cboTipoUsuario.DataSource = listaTipoUsuariosDTO;

            // Se define qué propiedad del DTO se mostrará en el ComboBox
            cboTipoUsuario.DisplayMember = "Nombre";

            // Se define qué propiedad del DTO se utilizará como valor seleccionado
            cboTipoUsuario.ValueMember = "Id";
        }

        private void UsuarioAgregar_Load_1(object sender, EventArgs e)
        {
            #region Carga los datos al ComboBox al momento de cargar el formulario
            // Se obtiene el listado de los tipos de usuarios
            List<TipoUsuarioDTO> listaTipoUsuariosDTO = this.usuarioController.ListarTipoUsuarios();

            // Se asigna la lista como origen de datos para el ComboBox
            cboTipoUsuario.DataSource = listaTipoUsuariosDTO;

            // Se define qué propiedad del DTO se mostrará en el ComboBox
            cboTipoUsuario.DisplayMember = "Nombre";

            // Se define qué propiedad del DTO se utilizará como valor seleccionado
            cboTipoUsuario.ValueMember = "Id";
            #endregion
        }
    }
}
