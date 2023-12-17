using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class HabitacionDTO
    {
        public int IdHabitacion { get; set; }
        public String IdTipo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string Precio { get; set; }
        public string Numero { get; set; }
        public string IdPiso { get; set; }

        // Método para convertir el string en int
        public int ConvertirTipoHabitacion(string p_tipo)
        {
            switch (p_tipo.ToLower()) // Convierte a minúsculas para hacer la comparación insensible a mayúsculas/minúsculas
            {
                case "individual":
                    return 1;
                case "doble":
                    return 2;
                case "familiar":
                    return 3;
                default:
                    throw new InvalidOperationException($"Tipo de habitación no reconocido: {p_tipo}");
            }
        }
    }
}
