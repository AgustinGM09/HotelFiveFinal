//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Habitaciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Habitaciones()
        {
            this.Reservas = new HashSet<Reservas>();
            this.ClienteReserva = new HashSet<ClienteReserva>();
        }
    
        public int IdHabitacion { get; set; }
        public Nullable<int> IdPiso { get; set; }
        public Nullable<int> Numero { get; set; }
        public Nullable<int> IdTipo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public Nullable<double> Precio { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservas> Reservas { get; set; }
        public virtual Piso Piso { get; set; }
        public virtual TipoHabitacion TipoHabitacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClienteReserva> ClienteReserva { get; set; }
    }
}
