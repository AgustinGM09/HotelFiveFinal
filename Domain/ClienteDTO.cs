using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public  class ClienteDTO
    {
        public int IdCliente { get; set; }
        public int? Dni { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string FechaNacimiento { get; set; }
        public string Email { get; set; }
        public int? Telefono { get; set; }
    }
}
