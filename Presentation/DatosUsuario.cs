using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    internal class DatosUsuario
    {
        public static class GlobalVariables
        {
            public static string NombreUsuario { get; set; }
            public static string ApellidoUsuario { get; set; }
            public static int Usuarioid { get; set; } = 0;
            public static int PermisoUsuarioActual { get; set; } = 0;
        }

        public const int PermisoAdmin = 1;
        public const int PermisoGerente = 2;
        public const int PermisoRecepcionista = 3;


        // Función para verificar permisos
        public static bool TienePermisoAdmin(int permiso)
        {
            return permiso == PermisoAdmin;
        }
        public static bool TienePermisoAdminGerente(int permiso)
        {
            return permiso == PermisoAdmin || permiso == PermisoGerente;
        }

        public static bool TienePermisoAdminRecepcionista(int permiso)
        {
            return permiso == PermisoAdmin || permiso == PermisoRecepcionista;
        }

        public static void Mensajeadmin()
        {
            MessageBox.Show("Acceso denegado. Se requieren permisos de Admin");
        }
        public static void Mensajeadmingerente()
        {
            MessageBox.Show("Acceso denegado. Se requieren permisos de Admin o Gerente");
        }
        public static void Mensajeadminrecepcionista()
        {
            MessageBox.Show("Acceso denegado. Se requieren permisos de Admin o Recepcionista");
        }

        public static bool TienePermisoGeneral()
        {
            return true;
        }
        public static void MensajeaLimpieza()
        {
            MessageBox.Show("Acceso denegado. Se requieren permisos de Limpieza");
        }

    }
}
