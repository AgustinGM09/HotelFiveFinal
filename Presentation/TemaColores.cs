using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Presentation
{
    internal class TemaColores
    {
        public static Color barraTitulo;
        public static Color MenuVertical;
        public static Color btnReserva;
        public static Color btnHabitaciones;
        public static Color btnUsuarios;
        public static Color btnReportes;
        public static Color btnAjustes;
        public static Color UsuarioListado;

        //Colores por defecto
        private static readonly Color barraTituloD = Color.FromArgb(34, 17, 29);
        private static readonly Color MenuVerticalD = Color.FromArgb(55, 28, 42);
        private static readonly Color btnReservaD = Color.FromArgb(55, 28, 42);
        private static readonly Color btnHabitacionesD = Color.FromArgb(55, 28, 42);
        private static readonly Color btnUsuariosD = Color.FromArgb(55, 28, 42);
        private static readonly Color btnReportesD = Color.FromArgb(55, 28, 42);
        private static readonly Color btnAjustesD = Color.FromArgb(55, 28, 42);
        private static readonly Color UsuarioListadoD = Color.FromArgb(68, 40, 49);

        //Color personalizado
        private static readonly Color barraTituloP = Color.FromArgb(0, 255, 127);
        private static readonly Color MenuVerticalP = Color.FromArgb(0, 255, 127);
        private static readonly Color btnReservaP = Color.FromArgb(0, 0, 0);
        private static readonly Color btnHabitacionesP = Color.FromArgb(0, 0, 0);
        private static readonly Color btnUsuariosP = Color.FromArgb(0, 0, 0);
        private static readonly Color btnReportesP = Color.FromArgb(0, 0, 0);
        private static readonly Color btnAjustesP = Color.FromArgb(0, 0, 0);
        private static readonly Color UsuarioListadoP = Color.FromArgb(0, 0, 0);

        //Seleccionar temas
        public static void ElegirTema(string Tema)
        {
            if (Tema == "Defecto")
            {
                barraTitulo = barraTituloD;
                MenuVertical = MenuVerticalD;
                btnReserva = btnReservaD;
                btnHabitaciones = btnHabitacionesD;
                btnUsuarios = btnUsuariosD;
                btnReportes = btnReportesD;
                btnAjustes = btnAjustesD;
                UsuarioListado = UsuarioListadoD;
            }
            if (Tema == "V2")
            {
                barraTitulo = barraTituloP;
                MenuVertical = MenuVerticalP;
                btnReserva = btnReservaP;
                btnHabitaciones = btnHabitacionesP;
                btnUsuarios = btnUsuariosP;
                btnReportes = btnReportesP;
                btnAjustes = btnAjustesP;
                UsuarioListado = UsuarioListadoP;
            }
        }
    }
}
