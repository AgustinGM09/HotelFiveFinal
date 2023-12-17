using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PagoDTO
    {
        public int IdPago { get; set; }
        public int IdReserva { get; set; }

        public int dniCliente { get; set; }

        public int idUsuario { get; set; }

        public string Tipohabitacion {  get; set; }

        public DateTime FechaFactura { get; set; }

        public string TipodePago { get; set; }

        public double Total {  get; set; }
        public string Estado { get; set; }
    }
}
