using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PagoController
    {

        public PagoController() { }


        public List<PagoDTO> ListarPagos()
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var pagosDTO = hotelFive.Pago
                    .Select(u => new PagoDTO
                    {
                        IdPago = u.IdPago,
                        IdReserva = (int)u.IdReserva,
                        dniCliente= (int)u.Reservas.Clientes.Dni,
                        idUsuario= (int)u.Reservas.IdUsuario,
                        Tipohabitacion= u.Reservas.Habitaciones.TipoHabitacion.Tipo,
                        FechaFactura = (DateTime)u.FechaFactura,
                        TipodePago = u.TipodePago,
                        Total= (double)u.Reservas.Total,
                        Estado = u.Estado,
                    })
                    .ToList();
                return pagosDTO;
            }
        }
        public List<PagoDTO> FiltrarPagosPorFecha(DateTime fecha)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var todosLosPagos = hotelFive.Pago
                    .Select(u => new PagoDTO
                    {
                        IdPago = u.IdPago,
                        IdReserva = (int)u.IdReserva,
                        dniCliente = (int)u.Reservas.Clientes.Dni,
                        idUsuario = (int)u.Reservas.IdUsuario,
                        Tipohabitacion = u.Reservas.Habitaciones.TipoHabitacion.Tipo,
                        FechaFactura = (DateTime)u.FechaFactura,
                        TipodePago = u.TipodePago,
                        Total = (double)u.Reservas.Total,
                        Estado = u.Estado,
                    })
                    .ToList();

                var pagosFiltrados = todosLosPagos
                    .Where(u => u.FechaFactura.Year == fecha.Year && u.FechaFactura.Month == fecha.Month && u.FechaFactura.Day == fecha.Day)
                    .ToList();

                return pagosFiltrados;
            }
        }

        public List<PagoDTO> FiltrarPagosPorRangoDeFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                fechaInicio = fechaInicio.Date;
                fechaFin = fechaFin.Date.AddDays(1).AddSeconds(-1);

                var pagosFiltrados = hotelFive.Pago
                    .Where(u => u.FechaFactura >= fechaInicio && u.FechaFactura <= fechaFin)
                    .Select(u => new PagoDTO
                    {
                        IdPago = u.IdPago,
                        IdReserva = (int)u.IdReserva,
                        dniCliente = (int)u.Reservas.Clientes.Dni,
                        idUsuario = (int)u.Reservas.IdUsuario,
                        Tipohabitacion = u.Reservas.Habitaciones.TipoHabitacion.Tipo,
                        FechaFactura = (DateTime)u.FechaFactura,
                        TipodePago = u.TipodePago,
                        Total = (double)u.Reservas.Total,
                        Estado = u.Estado,
                    })
                    .ToList();

                return pagosFiltrados;
            }
        }

        public List<PagoDTO> FiltrarPagosDni(int dni)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var pagosFiltrados = hotelFive.Pago
                    .Where(u => u.Reservas.Clientes.Dni == dni)
                    .Select(u => new PagoDTO
                    {
                        IdPago = u.IdPago,
                        IdReserva = (int)u.IdReserva,
                        dniCliente = (int)u.Reservas.Clientes.Dni,
                        idUsuario = (int)u.Reservas.IdUsuario,
                        Tipohabitacion = u.Reservas.Habitaciones.TipoHabitacion.Tipo,
                        FechaFactura = (DateTime)u.FechaFactura,
                        TipodePago = u.TipodePago,
                        Total = (double)u.Reservas.Total,
                        Estado = u.Estado,
                    })
                    .ToList();

                return pagosFiltrados;
            }
        }

        public void RegistrarPago(int idreserva, DateTime fecha, string tipopago, string estado)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                // Crear una nueva instancia de la entidad Pago
                var pago = new DataAccess.Pago
                {
                    IdReserva = idreserva,
                    FechaFactura= fecha,
                    TipodePago = tipopago,
                    Estado = estado
                };

                // Agregar la reserva al contexto y guardar los cambios en la base de datos
                hotelFive.Pago.Add(pago);
                hotelFive.SaveChanges();
            }
        }
        public List<string> ObtenerDetallesPagoPorId(int id)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var datosPago = new List<string>();

                // Buscar el pago por idPago
                var pago = hotelFive.Pago.Where(p => p.IdReserva == id)
            .OrderByDescending(p => p.IdPago)
            .FirstOrDefault();

                if (pago != null)
                {
                    // Obtener la reserva relacionada al pago
                    var reserva = hotelFive.Reservas.FirstOrDefault(r => r.IdReserva == pago.IdReserva);
                    var dnicliente = (reserva != null && reserva.Clientes != null) ? reserva.Clientes.Dni.ToString() : "DNI no encontrado";
                    var nombrecliente = (reserva != null && reserva.Clientes != null) ? reserva.Clientes.Nombre.ToString() : "nombre no encontrado";
                    var apellidocliente = (reserva != null && reserva.Clientes != null) ? reserva.Clientes.Apellido.ToString() : "apellido no encontrado";
                    var descripcionEstado = (reserva != null && reserva.IdHabitacion != null) ? reserva.Habitaciones.Descripcion : "Descripcion no encontrado";
                    var tipodeHabitacion = (reserva != null && reserva.IdHabitacion != null) ? reserva.Habitaciones.TipoHabitacion.Tipo : "Tipo de Habitacion no encontrado";
                    var numeroHabitacion = (reserva != null && reserva.IdHabitacion != null) ? reserva.Habitaciones.Numero.ToString() : "Número de habitación no encontrado";
                    var fechaInicioFormateada = $"{reserva.FechaInicio.Value.Day:00}/{reserva.FechaInicio.Value.Month:00}/{reserva.FechaInicio.Value.Year}";
                    var fechaFinFormateada = $"{reserva.FechaFin.Value.Day:00}/{reserva.FechaFin.Value.Month:00}/{reserva.FechaFin.Value.Year}";
                    // Construir la lista con los datos del pago y la reserva asociada
                    datosPago.Add(pago.IdPago.ToString());
                    datosPago.Add(pago.IdReserva.ToString());
                    datosPago.Add(dnicliente);
                    datosPago.Add(pago.FechaFactura.ToString());
                    datosPago.Add(pago.Estado);
                    datosPago.Add(descripcionEstado);
                    datosPago.Add(numeroHabitacion);
                    datosPago.Add(fechaInicioFormateada.ToString());
                    datosPago.Add(fechaFinFormateada.ToString());
                    datosPago.Add(reserva.Total.ToString());
                    datosPago.Add(nombrecliente);
                    datosPago.Add(apellidocliente);
                    datosPago.Add(pago.TipodePago);
                    datosPago.Add(tipodeHabitacion);
                }

                return datosPago;
            }

        }
        public List<string> datosdelPago(int idpago)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var datosPago = new List<string>();

                // Buscar el pago por idPago
                var pago = hotelFive.Pago.Where(p => p.IdPago == idpago)
            .FirstOrDefault();

                if (pago != null)
                {
                    var reserva = hotelFive.Reservas.FirstOrDefault(r => r.IdReserva == pago.IdReserva);
                    var dnicliente = (reserva != null && reserva.Clientes != null) ? reserva.Clientes.Dni.ToString() : "DNI no encontrado";
                    var nombrecliente = (reserva != null && reserva.Clientes != null) ? reserva.Clientes.Nombre.ToString() : "nombre no encontrado";
                    var apellidocliente = (reserva != null && reserva.Clientes != null) ? reserva.Clientes.Apellido.ToString() : "apellido no encontrado";
                    var descripcionEstado = (reserva != null && reserva.IdHabitacion != null) ? reserva.Habitaciones.Descripcion : "Descripcion no encontrado";
                    var tipodeHabitacion = (reserva != null && reserva.IdHabitacion != null) ? reserva.Habitaciones.TipoHabitacion.Tipo : "Tipo de Habitacion no encontrado";
                    var numeroHabitacion = (reserva != null && reserva.IdHabitacion != null) ? reserva.Habitaciones.Numero.ToString() : "Número de habitación no encontrado";
                    var nombreyapellido = (reserva != null && reserva.Usuarios != null) ? reserva.Usuarios.nombre.ToString() + " " +reserva.Usuarios.apellido.ToString() : "Nombre y Apellido no encontrados";
                    // Construir la lista con los datos del pago y la reserva asociada
                    datosPago.Add(pago.IdPago.ToString());
                    datosPago.Add(pago.IdReserva.ToString());
                    datosPago.Add(dnicliente);
                    datosPago.Add(pago.FechaFactura.ToString());
                    datosPago.Add(pago.Estado);
                    datosPago.Add(descripcionEstado);
                    datosPago.Add(numeroHabitacion);
                    datosPago.Add(reserva.FechaInicio.Value.ToString("dd/MM/yyyy"));
                    datosPago.Add(reserva.FechaFin.Value.ToString("dd/MM/yyyy"));
                    datosPago.Add(reserva.Total.ToString());
                    datosPago.Add(nombrecliente);
                    datosPago.Add(apellidocliente);
                    datosPago.Add(pago.TipodePago);
                    datosPago.Add(tipodeHabitacion);
                    var diferencia = (reserva.FechaFin - reserva.FechaInicio);
                    var dia = diferencia.Value.Days + 1;
                    datosPago.Add(dia.ToString());
                    datosPago.Add(nombreyapellido);
                    datosPago.Add(reserva.Total.ToString());
                }
                return datosPago;
            }
        }
    }
}