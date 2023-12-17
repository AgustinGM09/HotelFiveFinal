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
using Domain;
using DataAccess;
using System.Text.RegularExpressions;

namespace Presentation.Admin
{
    public partial class UsuarioModificar : Form
    {
        private int dniUsuario; //ID del usuario que se va actualizar
        private UsuarioController usuarioController; // Atributo para almacenar la instancia de UsuarioController
        private Usuarios usuario;

        public UsuarioModificar(int idUsuario)
        {
            InitializeComponent();
            this.dniUsuario = idUsuario;
            this.usuarioController = new UsuarioController();
            cboBaja.Items.Add("Si");
            cboBaja.Items.Add("No");
        }

        public event EventHandler UsuarioModificado;

        protected virtual void OnUsuarioModificado(EventArgs e)
        {
            UsuarioModificado?.Invoke(this, e);
        }

        #region Codigo para arrastrar formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam); 

        private void UsuarioModificar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

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
                int idTipoUsuario = Convert.ToInt32(cboTipoUsuario.SelectedValue);
                string baja1 = cboBaja.Text;

                // Llamar al controlador para actualizar el usuario
                UsuarioController usuarioController = new UsuarioController();
                var id=usuarioController.ObtenerUsuarioPorId(dniUsuario);
                int idusuario = id.id_usuario;
                int baja;
                if (baja1 == "Si") {
                    
                    baja= 0;
                        }
                else { 
                    baja = 1;
                 }
                usuarioController.ActualizarUsuario(idusuario,nombre, apellido, telefono, email, dni, idTipoUsuario, baja.ToString());

                MessageBox.Show("Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Dispara el evento después de modificar los datos del usuario
                OnUsuarioModificado(EventArgs.Empty);

                this.Close();
            }
            catch
            {
                // Manejar la excepción o mostrar un mensaje de error
                MessageBox.Show("Error al actualizar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UsuarioModificar_Load(object sender, EventArgs e)
        {
            //this.tipo_UsuarioTableAdapter.Fill(this.hotelFiveDataSet.Tipo_Usuario);// NO BORRAR
            usuario = this.usuarioController.ObtenerUsuarioPorId(this.dniUsuario);
            // Verificar si se obtuvieron detalles
            if (usuario != null)
            {
                txtNombre.Text = usuario.nombre;
                txtApellido.Text = usuario.apellido;
                txtTelefono.Text = usuario.telefono.ToString(); // Convertir a string si es necesario
                txtEmail.Text = usuario.email;
                txtDni.Text = usuario.DNI.ToString(); // Convertir a string si es necesario
                string valor =usuario.baja.ToString();

                if (valor == "1")
                {
                    cboBaja.Text = "No";
                }
                else
                {
                    cboBaja.Text = "Si";
                }

                #region Asigna la lista de tipos de usuarios al combo box
                // Se obtiene el listado de los tipos de usuarios
                List<TipoUsuarioDTO> listaTipoUsuariosDTO = this.usuarioController.ListarTipoUsuarios();

                // Se asigna la lista como origen de datos para el ComboBox
                cboTipoUsuario.DataSource = listaTipoUsuariosDTO;

                // Se define qué propiedad del DTO se mostrará en el ComboBox
                cboTipoUsuario.DisplayMember = "Nombre";

                // Se define qué propiedad del DTO se utilizará como valor seleccionado
                cboTipoUsuario.ValueMember = "Id";

                cboTipoUsuario.SelectedValue = usuario.id_tipoUsuario;
                #endregion
            }
            else
            {
                MessageBox.Show("No se pudo encontrar el usuario seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
