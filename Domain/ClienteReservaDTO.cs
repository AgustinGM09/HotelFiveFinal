using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ClienteReservaDTO
    {
        public int IdClienteReserva { get; set; }
        public int ClienteID { get; set; }
        public int DniCliente { get; set; }
        public int HabitacionID { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }

    }
}
