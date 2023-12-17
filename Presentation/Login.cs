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
using Presentation.Admin;
using System.Data.Entity;
using DataAccess;
using System.Runtime.CompilerServices;
using Presentation.Gerente;
using Presentation.Empleado;
using System.Security.Cryptography;
using Domain;
//using Principal;
//using AgregarU;
//using Recepcionista;

namespace Presentation
{
    public partial class Login : Form
    {
        UsuarioController usuarioController;
        private Usuarios usuario;
        public Login()
        {
            InitializeComponent();
            this.usuario = new Usuarios();
            usuarioController = new UsuarioController();
        }

        public Usuarios GetUsuarios()
        {
            return this.usuario;
        }

        private void setUsuarios(Usuarios p_usuario)
        {
            this.usuario = p_usuario;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "USUARIO")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.DimGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            if (txtPass.Text != "CONTRASEÑA")
            {
                if (txtPass.UseSystemPasswordChar)
                {
                    txtPass.UseSystemPasswordChar = false;
                }
                else
                {
                    txtPass.UseSystemPasswordChar = true;
                }
            }
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Obtiene el nombre de usuario proporcionado por el usuario
            string user = txtUser.Text;
            // Obtiene la contraseña proporcionada por el usuario
            string pass = txtPass.Text;

            // Verifica si el nombre de usuario o la contraseña están en sus valores predeterminados = vacios.
            if (user == "USUARIO" || pass == "CONTRASEÑA")
            {
                // Muestra un mensaje de error y sale del método
                msgError("Ingrese EMAIL y CONTRASEÑA.");
                return;
            }

            // Inicia una conexión a la base de datos utilizando la clase HotelFiveEntities
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                // Busca en la base de datos un usuario con el mismo correo electrónico
                var usuarios = hotelFive.Usuarios.FirstOrDefault(u => u.email == user);

                // Verifica si se encontró un usuario en la base de datos
                if (usuarios != null)
                {
                    // Autentica al usuario verificando la contraseña proporcionada
                    if (AutenticarUsuario(user, pass))
                    {
                        // Obtiene información adicional del usuario desde el controlador de usuarios
                        var datos = usuarioController.NYAusuario(usuarios.id_usuario);

                        // Verifica si se obtuvieron datos adicionales del usuario
                        if (datos.Count > 0)
                        {
                            // Asigna el nombre y apellido del usuario a variables globales
                            DatosUsuario.GlobalVariables.NombreUsuario = datos[0];
                            DatosUsuario.GlobalVariables.ApellidoUsuario = datos[1];
                        }

                        // Asigna el tipo de permiso y el ID del usuario a variables globales
                        DatosUsuario.GlobalVariables.PermisoUsuarioActual = usuarios.id_tipoUsuario;
                        DatosUsuario.GlobalVariables.Usuarioid = usuarios.id_usuario;

                        // Verifica si el usuario está dado de baja
                        var baja = usuarios.baja;
                        if (baja == 1)
                        {
                            // Obtiene el tipo de usuario
                            var tipo = usuarios.id_tipoUsuario;

                            // Oculta el formulario de inicio de sesión
                            this.Hide();
                            this.ShowInTaskbar = false;

                            // Crea una instancia del formulario Dashboard y lo muestra
                            Dashboard dashboard = new Dashboard();
                            dashboard.ShowDialog();

                        }
                        else
                        {
                            // Muestra un mensaje de error indicando que el usuario está dado de baja y sale del método
                            msgError("Usuario dado de Baja.");
                            return;
                        }
                    }
                    else
                    {
                        // Muestra un mensaje de error indicando que el usuario o la contraseña no con correctos
                        msgError("Email o contraseña incorrecto.");
                        return;
                    }
                }
                else
                {
                    // Muestra un mensaje de error indicando que el usuario o la contraseña no se encontraron y realiza algunas operaciones adicionales
                    msgError("Email o contraseña no encontrado.");
                    return;
                }
            }
        }

        public bool AutenticarUsuario(string email, string contrasenaProporcionada)
        {
            try
            {
                // Recupera el usuario de la base de datos por su correo electrónico (email)
                using (HotelFiveEntities hotelFive = new HotelFiveEntities())
                {
                    Usuarios usuario = hotelFive.Usuarios.FirstOrDefault(u => u.email == email);

                    if (usuario != null)
                    {
                        // Hashea la contraseña proporcionada por el usuario utilizando el mismo algoritmo
                        string hashedPasswordProvided = HashPassword(contrasenaProporcionada);

                        // Limita la longitud de la contraseña hasheada proporcionada a 30 caracteres
                        if (hashedPasswordProvided.Length > 30)
                        {
                            hashedPasswordProvided = hashedPasswordProvided.Substring(0, 30);
                        }

                        // Compara el valor hasheado generado a partir de la contraseña proporcionada con la contraseña almacenada
                        if (usuario.contraseña == hashedPasswordProvided)
                        {
                            return true; // Las contraseñas coinciden
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false; // Si ocurre un error o no se encuentra el usuario
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        private void msgError(string msg)
        {
            lblErrorMessagge.Text = msg;
            lblErrorMessagge.Visible = true;
        }
    }
}

