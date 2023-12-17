using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ClienteReservaController
    {
        public ClienteReservaController() { }


        public void GuardarDetallesReserva(int idCliente, int idHabitacion, DateTime fechaInicio, DateTime fechaFin)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var cliente = hotelFive.Clientes.FirstOrDefault(c => c.Dni ==  idCliente);
                var habitacion = hotelFive.Habitaciones.FirstOrDefault(h => h.TipoHabitacion.idTipoHabitacion == idHabitacion);
                try
                {
                    if (cliente != null && habitacion != null)
                    {
                        // Crear una nueva instancia de ClienteReserva
                        ClienteReserva nuevaReserva = new ClienteReserva
                        {
                            ClienteID = cliente.IdCliente,
                            HabitacionID = habitacion.TipoHabitacion.idTipoHabitacion,
                            FechaInicio = fechaInicio,
                            FechaFin = fechaFin,
                            Estado = "Pendiente"
                        };

                        // Agregar la nueva reserva al contexto y guardar cambios en la base de datos
                        hotelFive.ClienteReserva.Add(nuevaReserva);
                        hotelFive.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción que pueda ocurrir durante la operación de guardado
                    Console.WriteLine($"Error al guardar detalles de reserva: {ex.Message}");
                    throw;
                }
             
            }
        }
        public void ActualizarEstadoReserva(int idClienteReserva, DateTime fechainicio, DateTime fechasalida)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                try
                {
                    // Buscar la reserva por idClienteReserva
                    ClienteReserva reserva = hotelFive.ClienteReserva
                        .FirstOrDefault(r => r.ClienteID == idClienteReserva &&
                                              r.Estado == "Pendiente" &&
                                              DbFunctions.TruncateTime(r.FechaInicio) == DbFunctions.TruncateTime(fechainicio) &&
                                              DbFunctions.TruncateTime(r.FechaFin) == DbFunctions.TruncateTime(fechasalida));

                    if (reserva != null)
                    {
                        // Actualizar el campo Estado a "Activo"
                        reserva.Estado = "Activo";

                        // Guardar los cambios en la base de datos
                        hotelFive.SaveChanges();
                    }
                    else
                    {
                        // Manejar la situación donde no se encuentra la reserva
                        Console.WriteLine($"No se encontró la reserva del cliente: {idClienteReserva}");
                    }
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción que pueda ocurrir durante la operación de actualización
                    Console.WriteLine($"Error al actualizar estado de reserva: {ex.Message}");
                    throw;
                }
            }
        }
        public List<ClienteReservaDTO> buscarreservapordni(int dni, DateTime fecha)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var clienteReservasDTO = hotelFive.ClienteReserva
                    .Where(u => u.Estado == "Pendiente" &&
                                u.Clientes.Dni == dni &&
                                DbFunctions.TruncateTime(u.FechaInicio) == fecha.Date)
                    .Select(u => new ClienteReservaDTO
                    {
                        IdClienteReserva = u.IdClienteReserva,
                        ClienteID = (int)u.ClienteID,
                        DniCliente = (int)u.Clientes.Dni,
                        HabitacionID = u.Habitaciones.IdHabitacion,
                        FechaInicio = (DateTime)u.FechaInicio,
                        FechaFin = (DateTime)u.FechaFin,
                        Estado = u.Estado,
                    })
                    .ToList();
                return clienteReservasDTO;
            }
        }
        public List<ClienteReservaDTO> ObtenerLasReservasdelDia(DateTime fecha)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var clienteReservasDTO = hotelFive.ClienteReserva
                    .Where(u => u.Estado == "Pendiente" &&
                                DbFunctions.TruncateTime(u.FechaInicio) == fecha.Date)
                    .Select(u => new ClienteReservaDTO
                    {
                        IdClienteReserva = u.IdClienteReserva,
                        ClienteID = (int)u.ClienteID,
                        DniCliente = (int)u.Clientes.Dni,
                        HabitacionID = u.Habitaciones.IdHabitacion,
                        FechaInicio = (DateTime)u.FechaInicio,
                        FechaFin = (DateTime)u.FechaFin,
                        Estado = u.Estado,
                    })
                    .ToList();
                return clienteReservasDTO;
            }
        }



        public List<ClienteReservaDTO> ObtenerTodasLasReservas()
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var clienteReservasDTO = hotelFive.ClienteReserva
                    .Where(u => u.Estado == "Pendiente") // Filtrar por Estado diferente de "Cancelada"
                    .Select(u => new ClienteReservaDTO
                    {
                        IdClienteReserva = u.IdClienteReserva,
                        ClienteID = (int)u.ClienteID,
                        DniCliente = (int)u.Clientes.Dni,
                        HabitacionID = u.Habitaciones.IdHabitacion,
                        FechaInicio = (DateTime)u.FechaInicio,
                        FechaFin = (DateTime)u.FechaFin,
                        Estado = u.Estado,
                    })
                    .ToList();
                return clienteReservasDTO;
            }
        }


        public List<string> ObtenerDetallesReservaPorId(int id)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var datosReserva = new List<string>();

                // Buscar la reserva por IdClienteReserva
                var reservaCliente = hotelFive.ClienteReserva.FirstOrDefault(r => r.IdClienteReserva == id);

                if (reservaCliente != null)
                {
                    // Obtener el cliente relacionado a la reserva
                    var cliente = hotelFive.Clientes.FirstOrDefault(c => c.IdCliente == reservaCliente.ClienteID);

                    // Validar que el cliente no sea nulo antes de intentar acceder a sus propiedades
                    if (cliente != null)
                    {
                        datosReserva.Add(reservaCliente.IdClienteReserva.ToString());
                        datosReserva.Add(cliente.Dni.ToString());
                        datosReserva.Add(reservaCliente.HabitacionID.ToString() ?? "Tipo de Habitacion no encontrado") ;
                        datosReserva.Add(reservaCliente.FechaInicio?.ToString() ?? "Fecha Inicio no encontrado");
                        datosReserva.Add(reservaCliente.FechaFin?.ToString() ?? "Fecha Fin no encontrado");
                    }
                    else
                    {
                        // Manejar la situación donde no se encuentra el cliente asociado a la reserva
                        datosReserva.Add("Cliente no encontrado");
                    }
                }
                else
                {
                    // Manejar la situación donde no se encuentra la reserva
                    datosReserva.Add("Reserva no encontrada");
                }

                return datosReserva;
            }
        }

        public string tipohabitacion(int tipo)
        {
            switch (tipo) // Convierte a minúsculas para hacer la comparación insensible a mayúsculas/minúsculas
            {
                case 1:
                    return "Individual";
                case 2:
                    return "Doble";
                case 3:
                    return "Familiar";
                default:
                    throw new InvalidOperationException($"Tipo de habitación no reconocido: {tipo}");
            }
        }

        public int ObtenerSiTieneReserva(int id)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                // Buscar la reserva por IdClienteReserva
                var reserva = hotelFive.ClienteReserva.Where(r => r.ClienteID == id && r.Estado == "Pendiente");

                if (reserva != null)
                {
                    return 1;
                }
                else
                {
                    // Manejar la situación donde no se encuentra la reserva
                    return 0;
                }
            }
        }

        public ClienteReserva ObtenerClienteReservaPorId(int idReserva)
        {
            try
            {
                using (HotelFiveEntities hotelFive = new HotelFiveEntities())
                {
                    return hotelFive.ClienteReserva
    .Include(c => c.Habitaciones)
    .Include(c => c.Clientes)
    .FirstOrDefault(c => c.IdClienteReserva == idReserva);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void ActualizarDatos(int idreserva, int dni, int habitacion, DateTime fechainicio, DateTime fechafin)
        {
            try
            {
                using (HotelFiveEntities hotelFive = new HotelFiveEntities())
                {
                    // Buscar el cliente a actualizar
                    var reserva = hotelFive.ClienteReserva.FirstOrDefault(c => c.IdClienteReserva  == idreserva);

                    if (reserva != null)
                    {
                        // Actualizar propiedades
                        reserva.ClienteID = dni;
                        reserva.HabitacionID = habitacion;
                        reserva.FechaInicio= fechainicio;
                        reserva.FechaFin= fechafin;

                        // Guardar los cambios en la base de datos
                        hotelFive.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
        
        public List<dynamic> BuscarReserva(int? dni)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {

                var resultados = hotelFive.ClienteReserva.Select(u => new {
                    u.IdClienteReserva,u.ClienteID,u.Clientes.Dni,u.HabitacionID,u.FechaInicio,u.FechaFin,u.Estado
                });

                // Verificar si todos los campos de búsqueda están vacíos
                if (dni == 0)
                {
                    // No se ha ingresado ningún criterio de búsqueda, mostrar todos los usuarios
                    return resultados.ToList<dynamic>();
                }
                if (dni != null)
                {
                    resultados = resultados.Where(u => u.Dni == dni);
                }

                // Retorna la lista de usuarios encontrados
                return resultados.ToList<dynamic>();
            }
        }


    }
}
