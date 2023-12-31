﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string TipoUsuario { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Dni { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public string Contraseña { get; set; }

        public string Baja { get; set; }
    }
}
