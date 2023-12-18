using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class HabitacionController
    {

        public HabitacionController() { }

        public List<PisoDTO> ListarPisos()
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var pisoDTO = hotelFive.Piso
                    .Select(u => new PisoDTO
                    {
                        IdPiso = u.idPiso,
                        NroPiso = u.NumeroPiso.ToString(),
                        Estado = u.Estado,
                    })
                    .ToList();
                return pisoDTO;
            }
        }

        public List<HabitacionDTO> ListarHabitacionesCombinado(int idPiso, int idCategoria)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var habitacionesDTO = hotelFive.Habitaciones
                .Where(h => h.Piso.NumeroPiso == idPiso && h.Estado != "Baja" && h.IdTipo == idCategoria)
                .Select(h => new HabitacionDTO
                {
                    IdHabitacion = h.IdHabitacion,
                    IdTipo = h.TipoHabitacion.Tipo,
                    Descripcion = h.Descripcion,
                    Estado = h.Estado,
                    Precio = h.Precio.ToString(),
                    Numero = h.Numero.ToString(),
                    IdPiso = h.Piso.NumeroPiso.ToString()
                })
                .ToList();
                return habitacionesDTO;
            }
        }

        public List<PisoDTO> ListarPisosActivos()
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var pisoDTO = hotelFive.Piso
                    .Where(u => u.Estado == "Activo")
                    .Select(u => new PisoDTO
                    {
                        IdPiso = u.idPiso,
                        NroPiso = u.NumeroPiso.ToString(),
                        Estado = u.Estado,
                    })
                    .ToList();
                return pisoDTO;
            }
        }

        public List<TipoHabitacionDTO> ListarTipoHabitacion()
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var tipoHabitacionDTO = hotelFive.TipoHabitacion
                    .Select(u => new TipoHabitacionDTO
                    {
                        IdTipoHabitacion = u.idTipoHabitacion,
                        Tipo = u.Tipo,
                    })
                    .ToList();
                return tipoHabitacionDTO;
            }
        }

        /*public List<string> ObtenerEstadosDeLasHabitaciones()
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var estados = hotelFive.Habitaciones
                    .Select(h => h.Estado)
                    .Distinct()
                    .ToList();

                return estados;
            }
            List<string> miLista = new List<string>();
        }*/

        public Dictionary<string, int> ObtenerEstadosDeLasHabitaciones()
        {
            Dictionary<string, int> estados = new Dictionary<string, int>
            {
                {"Disponible", 0},
                {"Ocupado", 1},
                {"Tiempo Rebasado", 2},
                {"Necesita Limpieza", 3},
                {"Baja", 4},
                {"Todos", 5},
            };
            return estados;
        }

        public List<HabitacionDTO> ListarHabitaciones()
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var habitacionesDTO = hotelFive.Habitaciones
                    .Select(h => new HabitacionDTO
                    {
                        IdHabitacion = h.IdHabitacion,
                        IdTipo = h.TipoHabitacion.Tipo,
                        Descripcion = h.Descripcion,
                        Estado = h.Estado,
                        Precio = h.Precio.ToString(),
                        Numero = h.Numero.ToString(),
                        IdPiso = h.Piso.NumeroPiso.ToString()
                    })
                    .ToList();
                
                return habitacionesDTO;
            }

            // Datos de prueba
            /*List<HabitacionDTO> habitacionesDTO = new List<HabitacionDTO>();
            for (int i = 1; i <= 7; i++)
            {
                HabitacionDTO habitacion = new HabitacionDTO
                {
                    IdHabitacion = i,
                    TipoHabitacion = $"INDIVIDUAL",
                    Descripcion = $"00{i}",
                    Estado = $"Estado{i}",
                    Precio = (i * 100).ToString(),
                    Numero = i,
                    Piso = i % 5 + 1  // Asigna valores de piso del 1 al 5 de manera cíclica
                };

                habitacionesDTO.Add(habitacion);
            }*/
            //return habitacionesDTO;
        }

        public List<HabitacionDTO> ListarHabitacionesPorPiso(int p_piso)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var habitacionesDTO = hotelFive.Habitaciones
                .Where(h => h.Piso.NumeroPiso == p_piso && h.Estado != "Baja")
                .Select(h => new HabitacionDTO
                {
                    IdHabitacion = h.IdHabitacion,
                    IdTipo = h.TipoHabitacion.Tipo,
                    Descripcion = h.Descripcion,
                    Estado = h.Estado,
                    Precio = h.Precio.ToString(),
                    Numero = h.Numero.ToString(),
                    IdPiso = h.Piso.NumeroPiso.ToString()
                })
                .ToList();
                return habitacionesDTO;
            }
        }

        public List<HabitacionDTO> ListarHabitacionesPorTipo(int tipo)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var habitacionesDTO = hotelFive.Habitaciones
                    .Where(h => h.TipoHabitacion.idTipoHabitacion == tipo && h.Estado != "Baja")
                    .Select(h => new HabitacionDTO
                    {
                        IdHabitacion = h.IdHabitacion,
                        IdTipo = h.TipoHabitacion.Tipo,
                        Descripcion = h.Descripcion,
                        Estado = h.Estado,
                        Precio = h.Precio.ToString(),
                        Numero = h.Numero.ToString(),
                        IdPiso = h.Piso.NumeroPiso.ToString()
                    })
                    .ToList();

                return habitacionesDTO;
            }
        }

        public List<HabitacionDTO> ListarHabitacionesPorEstado(int estado)
        {

            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                string estadoString = ObtenerNombreEstado(estado);
                Console.WriteLine("El programa se está ejecutando..." + estadoString);
                var habitacionesDTO = hotelFive.Habitaciones
                .Where(h => h.Estado == estadoString)
                .Select(h => new HabitacionDTO
                {
                    IdHabitacion = h.IdHabitacion,
                    IdTipo = h.TipoHabitacion.Tipo,
                    Descripcion = h.Descripcion,
                    Estado = h.Estado,
                    Precio = h.Precio.ToString(),
                    Numero = h.Numero.ToString(),
                    IdPiso = h.Piso.NumeroPiso.ToString()
                })
                .ToList();
                return habitacionesDTO;
            }
        }

        private string ObtenerNombreEstado(int valorEstado)
        {
            switch (valorEstado)
            {
                case 0:
                    return "Disponible";
                case 1:
                    return "Ocupado";
                case 2:
                    return "Tiempo Rebasado";
                case 3:
                    return "Necesita Limpieza";
                case 4:
                    return "Baja";
                default:
                    return string.Empty; // O un valor predeterminado adecuado
            }
        }

        public int ObtenerIdHabitacion(int habitacion)
        {
            using(HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var id = hotelFive.Habitaciones.FirstOrDefault(h => h.IdTipo == habitacion);

                if(id != null)
                {
                    return id.TipoHabitacion.idTipoHabitacion;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int Obtenernumero(int numero)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var id = hotelFive.Habitaciones.FirstOrDefault(h => h.Numero == numero);

                if (id != null)
                {
                    return id.IdHabitacion;
                }
                else
                {
                    return 0;
                }
            }
        }

        public HabitacionDTO ObtenerHabitacionPorId(int p_numero)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var habitacion = hotelFive.Habitaciones
                    .Where(h => h.Numero == p_numero)
                    .Select(h => new HabitacionDTO
                    {
                        IdHabitacion = h.IdHabitacion,
                        IdTipo = h.TipoHabitacion.Tipo,
                        Descripcion = h.Descripcion,
                        Estado = h.Estado,
                        Precio = h.Precio.ToString(),
                        Numero = h.Numero.ToString(),
                        IdPiso = h.Piso.NumeroPiso.ToString()
                    })
                    .FirstOrDefault();

                return habitacion;
            }
        }

        public bool ActualizarHabitacionExistente(string numeroHabitacion, int idPiso, string descripcion, int precio, int Tipo, int idHabitacion)
        {
            try
            {
                using (HotelFiveEntities hotelFive = new HotelFiveEntities())
                {
                    // Busca la habitación existente por el número
                    var habitacionExistente = hotelFive.Habitaciones.FirstOrDefault(h => h.IdHabitacion == idHabitacion);

                    if (habitacionExistente != null)
                    {
                        // Actualiza los campos con los nuevos valores
                        habitacionExistente.IdPiso = idPiso;
                        habitacionExistente.Descripcion = descripcion;
                        habitacionExistente.Precio = precio;
                        habitacionExistente.IdTipo = Tipo;
                        // Actualiza otros campos según sea necesario

                        // Guarda los cambios en la base de datos
                        hotelFive.SaveChanges();
                        return true;
                    }

                    return false; // La habitación no fue encontrada
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción según tus necesidades
                Console.WriteLine($"Error al actualizar la habitación: {ex.Message}");
                return false;
            }
        }


        public HabitacionDTO ObtenerHabitacionPorIdd(int id)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var habitacion = hotelFive.Habitaciones
                    .Where(h => h.IdHabitacion == id)
                    .Select(h => new HabitacionDTO
                    {
                        IdHabitacion = h.IdHabitacion,
                        IdTipo = h.TipoHabitacion.Tipo,
                        Descripcion = h.Descripcion,
                        Estado = h.Estado,
                        Precio = h.Precio.ToString(),
                        Numero = h.Numero.ToString(),
                        IdPiso = h.Piso.NumeroPiso.ToString()
                    })
                    .FirstOrDefault();

                return habitacion;
            }
        }

        public void EliminarPisoConHabitaciones(int idPiso)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                // Obtener el piso y sus habitaciones asociadas
                var piso = hotelFive.Piso.Include("Habitaciones").FirstOrDefault(p => p.idPiso == idPiso);

                if (piso != null)
                {
                    // Eliminar las habitaciones asociadas al piso
                    hotelFive.Habitaciones.RemoveRange(piso.Habitaciones);

                    // Eliminar el piso
                    hotelFive.Piso.Remove(piso);

                    // Guardar los cambios en la base de datos
                    hotelFive.SaveChanges();
                }
            }
        }

        public void AgregarNuevoPiso(string numeroPiso)
        {
            try
            {
                // Crea una nueva instancia de Piso
                Piso nuevoPiso = new Piso
                {
                    NumeroPiso = int.Parse(numeroPiso),
                    Estado = "Activo"
                };

                // Agrega el nuevo piso a la base de datos
                using (HotelFiveEntities hotelFive = new HotelFiveEntities())
                {
                    // Agregar el nuevo piso a la base de datos
                    hotelFive.Piso.Add(nuevoPiso);

                    // Guardar los cambios en la base de datos
                    hotelFive.SaveChanges();
                }
                Console.WriteLine("Piso agregado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public bool CambiarEstadoHabitacion(int idHabitacion)
        {
            try
            {
                using (HotelFiveEntities hotelFive = new HotelFiveEntities())
                {
                    var habitacion = hotelFive.Habitaciones.FirstOrDefault(h => h.IdHabitacion == idHabitacion);

                    if (habitacion != null && habitacion.Estado == "Disponible")
                    {
                        habitacion.Estado = "Baja";
                        hotelFive.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción según tus necesidades
                throw new Exception($"Error al cambiar el estado de la habitación: {ex.Message}", ex);
            }
        }

        public bool AgregarNuevaHabitacion(int numero, string descripcion, int precio, int idTipo, int idPiso)
        {
            try
            {

                // Validar que el piso no tenga más de 16 habitaciones
                if (ContarHabitacionesEnPiso(idPiso) >= 16)
                {
                    return false;
                }
                using (HotelFiveEntities hotelFive = new HotelFiveEntities())
                {
            
                        // Crear una nueva instancia de Habitacion
                        Habitaciones nuevaHabitacion = new Habitaciones
                        {
                            Numero = numero,
                            Descripcion = descripcion,
                            Precio = precio, // Ajusta el tipo de datos según tu modelo
                            IdTipo = idTipo,
                            Estado = "Disponible", // Puedes establecer el estado inicial según tus necesidades
                            IdPiso = idPiso
                        };

                        // Agregar la nueva habitación a la base de datos
                        hotelFive.Habitaciones.Add(nuevaHabitacion);

                        // Guardar los cambios en la base de datos
                        hotelFive.SaveChanges();

                        Console.WriteLine("Habitación agregada correctamente.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción según tus necesidades
                Console.WriteLine($"Error al agregar la habitación: {ex.Message}");
                return false;
            }
        }

        // Nuevo método para contar habitaciones en un piso
        public int ContarHabitacionesEnPiso(int idPiso)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                return hotelFive.Habitaciones.Count(h => h.IdPiso == idPiso);
            }
        }

        public bool CambiarEstadoHabitacion(int idHabitacion, string nuevoEstado)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                // Buscar la habitación por su Id
                var habitacion = hotelFive.Habitaciones.FirstOrDefault(h => h.IdHabitacion == idHabitacion);

                if (habitacion != null)
                {
                    // Actualizar el estado de la habitación
                    habitacion.Estado = nuevoEstado;

                    // Guardar los cambios en la base de datos
                    hotelFive.Entry(habitacion).State = EntityState.Modified;
                    hotelFive.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void ActualizarEstadoHabitacion(int idHabitacion, string nuevoEstado)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var habitacion = hotelFive.Habitaciones.FirstOrDefault(h => h.IdHabitacion == idHabitacion);

                if (habitacion != null)
                {
                    habitacion.Estado = nuevoEstado;
                    hotelFive.SaveChanges();
                }
            }
        }

        public int TotalHabitaciones()
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                int totalHabitaciones = hotelFive.Habitaciones.Count();
                return totalHabitaciones;
            }
        }

        public int TotalHabitacionesDisponibles()
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                int habitacionesDisponibles = hotelFive.Habitaciones.Count(h => h.Estado == "Disponible");
                return habitacionesDisponibles;
            }
        }

        public int TotalHabitacionesOcupadas()
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                int habitacionesOcupadas = hotelFive.Habitaciones.Count(h => h.Estado == "Ocupado");
                return habitacionesOcupadas;
            }
        }

        public int TotalHabitacionesEnLimpieza()
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                int habitacionesEnLimpieza = hotelFive.Habitaciones.Count(h => h.Estado == "Necesita Limpieza");
                return habitacionesEnLimpieza;
            }
        }

        public List<HabitacionDTO> ObtenerListaHabitacionesTotales()
        {
            HabitacionController habitacionController = new HabitacionController();
            List<HabitacionDTO> habitaciones = habitacionController.ListarHabitaciones();
            return habitaciones;
        }

        public List<HabitacionDTO> ObtenerHabitacionesDisponibles()
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var habitacionesDTO = hotelFive.Habitaciones
                    .Where(h => h.Estado == "Disponible")
                    .Select(h => new HabitacionDTO
                    {
                        IdHabitacion = h.IdHabitacion,
                        IdTipo = h.TipoHabitacion.Tipo,
                        Descripcion = h.Descripcion,
                        Estado = h.Estado,
                        Precio = h.Precio.ToString(),
                        Numero = h.Numero.ToString(),
                        IdPiso = h.Piso.NumeroPiso.ToString()
                    })
                    .ToList();

                return habitacionesDTO;
            }
        }

        public List<HabitacionDTO> ObtenerHabitacionesOcupadas()
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var habitacionesDTO = hotelFive.Habitaciones
                    .Where(h => h.Estado == "Ocupado")
                    .Select(h => new HabitacionDTO
                    {
                        IdHabitacion = h.IdHabitacion,
                        IdTipo = h.TipoHabitacion.Tipo,
                        Descripcion = h.Descripcion,
                        Estado = h.Estado,
                        Precio = h.Precio.ToString(),
                        Numero = h.Numero.ToString(),
                        IdPiso = h.Piso.NumeroPiso.ToString()
                    })
                    .ToList();

                return habitacionesDTO;
            }
        }

        public List<HabitacionDTO> ObtenerHabitacionesNecesitanLimpieza()
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var habitacionesDTO = hotelFive.Habitaciones
                    .Where(h => h.Estado == "Necesita Limpieza")
                    .Select(h => new HabitacionDTO
                    {
                        IdHabitacion = h.IdHabitacion,
                        IdTipo = h.TipoHabitacion.Tipo,
                        Descripcion = h.Descripcion,
                        Estado = h.Estado,
                        Precio = h.Precio.ToString(),
                        Numero = h.Numero.ToString(),
                        IdPiso = h.Piso.NumeroPiso.ToString()
                    })
                    .ToList();

                return habitacionesDTO;
            }
        }

        public List<TipoHabitacionReservadaDTO> ObtenerTiposHabitacionesMasReservados(DateTime fechaInicio, DateTime fechaFin)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var tiposHabitacionReservados = hotelFive.Reservas
                    .Where(r => r.FechaInicio >= fechaInicio && r.FechaFin <= fechaFin)  // Corrección en la condición de fecha
                    .Join(hotelFive.Habitaciones, r => r.IdHabitacion, h => h.IdHabitacion, (r, h) => new { r, h })
                    .Join(hotelFive.TipoHabitacion, x => x.h.IdTipo, th => th.idTipoHabitacion, (x, th) => new { x, th })
                    .GroupBy(g => g.th.Tipo)
                    .Select(g => new TipoHabitacionReservadaDTO
                    {
                        TipoHabitacion = g.Key,
                        CantidadReservas = g.Count()
                    })
                    .OrderByDescending(x => x.CantidadReservas)
                    .ToList();

                return tiposHabitacionReservados;
            }
        }

        public List<TipoHabitacionReservadaDTO> ObtenerTiposHabitacionesMasReservadosDelMes()
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                DateTime fechaInicioMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime fechaFinMes = fechaInicioMes.AddMonths(1).AddSeconds(-1);

                var tiposHabitacionReservados = hotelFive.Reservas
                    .Where(r => r.FechaInicio >= fechaInicioMes && r.FechaFin <= fechaFinMes)
                    .Join(hotelFive.Habitaciones, r => r.IdHabitacion, h => h.IdHabitacion, (r, h) => new { r, h })
                    .Join(hotelFive.TipoHabitacion, x => x.h.IdTipo, th => th.idTipoHabitacion, (x, th) => new { x, th })
                    .GroupBy(g => g.th.Tipo)
                    .Select(g => new TipoHabitacionReservadaDTO
                    {
                        TipoHabitacion = g.Key,
                        CantidadReservas = g.Count()
                    })
                    .OrderByDescending(x => x.CantidadReservas)
                    .ToList();

                return tiposHabitacionReservados;
            }
        }



    }
}
