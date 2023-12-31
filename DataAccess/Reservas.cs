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
    
    public partial class Reservas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reservas()
        {
            this.Pago = new HashSet<Pago>();
        }
    
        public int IdReserva { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<int> IdEstado { get; set; }
        public Nullable<int> IdHabitacion { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public Nullable<double> Total { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        public virtual EstadoReserva EstadoReserva { get; set; }
        public virtual Habitaciones Habitaciones { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pago> Pago { get; set; }
    }
}
