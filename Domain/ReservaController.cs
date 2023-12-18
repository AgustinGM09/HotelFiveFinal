using System;
using DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Domain
{
    public class ReservaController
    {
        public void RegistrarReserva(int idCliente, int idUsuario, int idEstado, int idHabitacion, DateTime fechaInicio, DateTime fechaFin, double total)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                // Crear una nueva instancia de la entidad Reservas
                var reserva = new DataAccess.Reservas
                {
                    IdCliente = idCliente,
                    IdUsuario = idUsuario,
                    IdEstado = idEstado,
                    IdHabitacion = idHabitacion,
                    FechaInicio = fechaInicio,
                    FechaFin = fechaFin,
                    Total = total
                };

                // Agregar la reserva al contexto y guardar los cambios en la base de datos
                hotelFive.Reservas.Add(reserva);
                hotelFive.SaveChanges();



                //Obtener la habitación por su ID:
                var habitacion = hotelFive.Habitaciones.FirstOrDefault(h => h.IdHabitacion == idHabitacion);

                // Actualiza el estado de la habitacion reservada
                if (habitacion != null)
                {
                    // Modifica el estado de la habitación según tus requisitos
                    habitacion.Estado = "Ocupado";

                    // Guarda los cambios en la base de datos
                    hotelFive.SaveChanges();
                }
            }
        }

        public List<string> ObtenerNyAClientePorReserva(int idReserva)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                // Buscar la reserva por idReserva
                var reserva = hotelFive.Reservas.FirstOrDefault(r => r.IdReserva == idReserva);

                if (reserva != null)
                {
                    // Obtener el cliente relacionado a la reserva
                    var cliente = hotelFive.Clientes.FirstOrDefault(c => c.IdCliente == reserva.IdCliente);

                    if (cliente != null)
                    {
                        // Construir y devolver la lista con el nombre y apellido del cliente
                        var nombreApellidoCliente = $"{cliente.Nombre} {cliente.Apellido}";
                        return new List<string> { nombreApellidoCliente };
                    }
                }

                // En caso de no encontrar la reserva o el cliente, devolver una lista vacía
                return new List<string>();
            }
        }

        public List<string> ObtenerDatosReserva(int idReserva)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var datosReserva = new List<string>();

                // Buscar la reserva por idReserva
                var reserva = hotelFive.Reservas.FirstOrDefault(r => r.IdReserva == idReserva);

                if (reserva != null)
                {
                    // Obtener el cliente relacionado a la reserva
                    var cliente = hotelFive.Clientes.FirstOrDefault(c => c.IdCliente == reserva.IdCliente);
                    var dnicliente = (cliente != null) ? cliente.Dni.ToString() : "DNI no encontrado";

                    // Obtener el usuario relacionado a la reserva
                    var usuario = hotelFive.Usuarios.FirstOrDefault(u => u.id_usuario == reserva.IdUsuario);
                    var dniusuario = (usuario != null) ? usuario.DNI.ToString() : "DNI no encontrado";

                    // Obtener el estado relacionado a la reserva
                    var estado = hotelFive.EstadoReserva.FirstOrDefault(e => e.idEstado == reserva.IdEstado);
                    var descripcionEstado = (estado != null) ? estado.Estado : "Estado no encontrado";

                    // Obtener la habitación relacionada a la reserva
                    var habitacion = hotelFive.Habitaciones.FirstOrDefault(h => h.IdHabitacion == reserva.IdHabitacion);
                    var numeroHabitacion = (habitacion != null) ? habitacion.Numero.ToString() : "Número de habitación no encontrado";
                    var diferencia = (reserva.FechaFin - reserva.FechaInicio);
                    var dia = diferencia.Value.Days + 1;
                    var descripcion = (habitacion != null) ? habitacion.Descripcion.ToString() : "Descripcion no encontrada";
                    // Construir la lista con los datos de la reserva
                    datosReserva.Add(reserva.IdReserva.ToString());
                    datosReserva.Add(reserva.IdCliente.ToString());
                    datosReserva.Add(dnicliente);
                    datosReserva.Add(reserva.IdUsuario.ToString());
                    datosReserva.Add(dniusuario);
                    datosReserva.Add(descripcionEstado);
                    datosReserva.Add(numeroHabitacion);
                    datosReserva.Add(reserva.FechaInicio.Value.ToString("dd/MM/yyyy"));
                    datosReserva.Add(reserva.FechaFin.Value.ToString("dd/MM/yyyy"));
                    datosReserva.Add(reserva.Total.ToString());
                    datosReserva.Add(dia.ToString());
                    datosReserva.Add(descripcion.ToString());
                }

                return datosReserva;
            }
        }

        public int detallespago(int habitacion, string estado)
        {
                int idReserva;

                using (HotelFiveEntities hotelFive = new HotelFiveEntities())
                {
                    // Buscar la habitación que cumple con las condiciones dadas
                    var habitacionEncontrada = hotelFive.Habitaciones.FirstOrDefault(h => h.Numero == habitacion && h.Estado == estado);

                    if (habitacionEncontrada != null)
                    {
                    // Si la habitación se encontró, obtener la reserva asociada
                    var reserva = hotelFive.Reservas
.Where(r => r.IdHabitacion == habitacionEncontrada.IdHabitacion)
.OrderByDescending(r => r.IdReserva)
.FirstOrDefault();
                        if (reserva != null)
                        {
                            idReserva = reserva.IdReserva;

                        return idReserva;
                    }
                    else
                    {
                        return 0;
                    }
                    }else{
                           return 0;
                     }
                }


        }

        public int ObtenerIdHabitacionPorReserva(int idReserva)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                // Buscar la reserva por su Id
                var reserva = hotelFive.Reservas.FirstOrDefault(r => r.IdReserva == idReserva);

                if (reserva != null)
                {
                    // Obtener el IdHabitacion asociado a la reserva
                    return reserva.IdHabitacion ?? 0;
                }

                return 0; // Devolver 0 si no se encuentra la reserva o no tiene una habitación asociada
            }
        }

        public List<ReservasPorMesDTO> ObtenerReservasPorMes()
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                int anioActual = DateTime.Now.Year;

                var reservasPorMes = hotelFive.Reservas
                    .Where(r => r.FechaInicio != null && r.FechaInicio.Value.Year == anioActual)
                    .GroupBy(r => new { r.FechaInicio.Value.Year, r.FechaInicio.Value.Month })
                    .Select(g => new ReservasPorMesDTO
                    {
                        Anio = g.Key.Year,
                        Mes = g.Key.Month,
                        CantidadReservas = g.Count()
                    })
                    .ToList();

                // Traducir los números de mes a nombres de mes
                foreach (var reservaPorMes in reservasPorMes)
                {
                    reservaPorMes.NombreMes = ObtenerNombreMes(reservaPorMes.Mes);
                }

                return reservasPorMes;
            }
        }

        public List<ReservasPorMesDTO> ObtenerReservasPorMes(int idUsuario)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                int anioActual = DateTime.Now.Year;

                var reservasPorMes = hotelFive.Reservas
                    .Where(r => r.FechaInicio != null && r.FechaInicio.Value.Year == anioActual && r.IdUsuario == idUsuario)
                    .GroupBy(r => new { r.FechaInicio.Value.Year, r.FechaInicio.Value.Month })
                    .Select(g => new ReservasPorMesDTO
                    {
                        Anio = g.Key.Year,
                        Mes = g.Key.Month,
                        CantidadReservas = g.Count()
                    })
                    .ToList();

                // Traducir los números de mes a nombres de mes
                foreach (var reservaPorMes in reservasPorMes)
                {
                    reservaPorMes.NombreMes = ObtenerNombreMes(reservaPorMes.Mes);
                }

                return reservasPorMes;
            }
        }

        //funcionando
        public List<ReservasPorPeriodoDTO> ObtenerReservasPorPeriodo(DateTime fechaInicio, DateTime fechaFin)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var reservasPorPeriodo = hotelFive.Reservas
                    .Where(r => r.FechaInicio != null && r.FechaInicio >= fechaInicio && r.FechaInicio <= fechaFin ) // Filtrar por el rango de fechas
                    .GroupBy(r => new { r.FechaInicio.Value.Year, r.FechaInicio.Value.Month })
                    .Select(g => new ReservasPorPeriodoDTO
                    {
                        Anio = g.Key.Year,
                        Mes = g.Key.Month,
                        CantidadReservas = g.Count()
                    })
                    .ToList();

                // Traducir los números de mes a nombres de mes
                foreach (var reservaPorPeriodo in reservasPorPeriodo)
                {
                    reservaPorPeriodo.NombreMes = ObtenerNombreMes(reservaPorPeriodo.Mes);
                }

                return reservasPorPeriodo;
            }
        }

        public List<ReservasPorMesDTO> ObtenerReservasPorPeriodo(int idUsuario, DateTime fechaInicio, DateTime fechaFin)
        {
            //.Where(r => r.FechaInicio != null && r.FechaInicio.Value.Year == anioActual && r.IdUsuario == idUsuario)
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var reservasPorMes = hotelFive.Reservas
                    .Where(r => r.FechaInicio != null && r.FechaInicio >= fechaInicio && r.FechaInicio <= fechaFin && r.IdUsuario == idUsuario)
                    .GroupBy(r => new { r.FechaInicio.Value.Year, r.FechaInicio.Value.Month })
                    .Select(g => new ReservasPorMesDTO
                    {
                        Anio = g.Key.Year,
                        Mes = g.Key.Month,
                        CantidadReservas = g.Count()
                    })
                    .ToList();

                // Traducir los números de mes a nombres de mes
                foreach (var reservaPorMes in reservasPorMes)
                {
                    reservaPorMes.NombreMes = ObtenerNombreMes(reservaPorMes.Mes);
                }

                return reservasPorMes;
            }
        }


        public string ObtenerNombreMes(int numeroMes)
        {
            CultureInfo cultureInfo = new CultureInfo("es-ES"); // Puedes ajustar la cultura según tus necesidades
            return cultureInfo.DateTimeFormat.GetMonthName(numeroMes);
        }


    }
}
