using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ReservasPorPeriodoDTO
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public string NombreMes { get; set; }
        public int CantidadReservas { get; set; }

        public int IdUsuario { get; set; }
    }
}
