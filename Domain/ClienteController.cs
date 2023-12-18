using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ClienteController
    {
        public ClienteController() { }

        public List<ClienteDTO> ListarClientes()
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var clientesDTO = hotelFive.Clientes
                    .Select(c => new ClienteDTO
                    {
                        IdCliente = c.IdCliente,
                        Dni = c.Dni,
                        Apellido = c.Apellido,
                        Nombre = c.Nombre,
                        FechaNacimiento = c.FechaNacimiento,
                        Email = c.Email,
                        Telefono = c.Telefono,
                    })
                    .ToList();
                return clientesDTO;
            }
        }
        public List<ClienteDTO> ListarNombresYApellidos()
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var nombresYApellidos = hotelFive.Clientes
                    .Select(c => new ClienteDTO
                    {
                        Nombre = c.Nombre,
                        Apellido = c.Apellido,
                    })
                    .ToList();
                return nombresYApellidos;
            }
        }

        public ClienteDTO BuscarClientePorDni(int dni)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var cliente = hotelFive.Clientes
                    .Where(c => c.Dni == dni)
                    .Select(c => new ClienteDTO
                    {
                        IdCliente = c.IdCliente,
                        Dni = c.Dni,
                        Apellido = c.Apellido,
                        Nombre = c.Nombre,
                        FechaNacimiento = c.FechaNacimiento,
                        Email = c.Email,
                        Telefono = c.Telefono
                    })
                    .FirstOrDefault();

                return cliente;
            }
        }

        public Clientes ObtenerClientePorId(int idCliente)
        {
            try
            {
                using (HotelFiveEntities hotelFive = new HotelFiveEntities())
                {
                    return hotelFive.Clientes.FirstOrDefault(c => c.IdCliente == idCliente);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public int ObtenerClientePorDNI(int dni)
        {
            try
            {
                using (HotelFiveEntities hotelFive = new HotelFiveEntities())
                {
                    var cliente = hotelFive.Clientes.FirstOrDefault(c => c.Dni == dni);

                    if(cliente != null) {

                        return 1;
                    }
                    else { 
                        return 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public int ObtenerCliente(int dni)
        {
            try
            {
                using (HotelFiveEntities hotelFive = new HotelFiveEntities())
                {
                    var cliente = hotelFive.Clientes.FirstOrDefault(c => c.Dni == dni);

                    if (cliente != null)
                    {

                        return cliente.IdCliente;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        public bool AgregarCliente(string nombre, string apellido, int telefono, string email, int dni, string fechanacimiento)
        {
            try
            {
                // Validar datos
                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || telefono <= 0 || string.IsNullOrWhiteSpace(email) || dni <= 0 || string.IsNullOrWhiteSpace(fechanacimiento))
                {
                    // Lanzar una excepción si algún dato es inválido
                    throw new ArgumentException("Todos los campos son obligatorios y deben tener valores válidos.");
                }

                // TODO Validaciones más específicas, por ejemplo, validar el formato del correo electrónico o la longitud del DNI O Telefono.

                // Crear una nueva instancia de Clientes
                Clientes nuevoCliente = new Clientes
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Telefono = telefono,
                    Email = email,
                    Dni = dni,
                    FechaNacimiento = fechanacimiento
                };

                // Agregar el nuevo usuario a la base de datos
                using (HotelFiveEntities hotelFive = new HotelFiveEntities())
                {
                    hotelFive.Clientes.Add(nuevoCliente);
                    hotelFive.SaveChanges();
                }

                Console.WriteLine("Cliente agregado correctamente.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public void ActualizarCliente(int idCliente, string nombre, string apellido, int telefono, string email, int dni, string fechanacimiento)
        {
            try
            {
                using (HotelFiveEntities hotelFive = new HotelFiveEntities())
                {
                    // Buscar el cliente a actualizar
                    var cliente = hotelFive.Clientes.FirstOrDefault(c => c.IdCliente  == idCliente);

                    if (cliente != null)
                    {
                        // Actualizar propiedades
                        cliente.Nombre = nombre;
                        cliente.Apellido = apellido;
                        cliente.Telefono = telefono;
                        cliente.Email = email;
                        cliente.Dni = dni;
                        cliente.FechaNacimiento = fechanacimiento;

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
        public List<dynamic> BuscarClientes(string nombre, string apellido, int? dni)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {

                var resultados = hotelFive.Clientes.Select(u => new {
                    u.IdCliente,
                    u.Dni,
                    u.Apellido,
                    u.Nombre,
                    u.Email,
                    u.Telefono,
                    u.FechaNacimiento
                });

                // Verificar si todos los campos de búsqueda están vacíos
                if (string.IsNullOrEmpty(nombre) && string.IsNullOrEmpty(apellido) && dni == null)
                {
                    // No se ha ingresado ningún criterio de búsqueda, mostrar todos los usuarios
                    return resultados.ToList<dynamic>();
                }

                // Aplicar filtros según los parámetros de búsqueda
                if (!string.IsNullOrEmpty(nombre))
                {
                    resultados = resultados.Where(u => u.Nombre.StartsWith(nombre));
                }
                if (!string.IsNullOrEmpty(apellido))
                {
                    resultados = resultados.Where(u => u.Apellido.StartsWith(apellido));
                }
                if (dni != null)
                {
                    resultados = resultados.Where(u => u.Dni == dni);
                }

                // Retorna la lista de usuarios encontrados
                return resultados.ToList<dynamic>();
            }
        }

        public List<ClienteReservasDTO> ObtenerTopClientesPorFechas(int cantidadTop, DateTime fechaInicio, DateTime fechaFin)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var topClientes = hotelFive.Clientes
                    .Select(cliente => new
                    {
                        Cliente = cliente,
                        CantidadReservas = hotelFive.Reservas
                            .Where(r => r.IdCliente == cliente.IdCliente && r.FechaInicio >= fechaInicio && r.FechaFin <= fechaFin)
                            .Count()
                    })
                    .Where(tc => tc.CantidadReservas > 0) // Agrega esta condición para incluir solo clientes con al menos 1 reserva
                    .OrderByDescending(tc => tc.CantidadReservas)
                    .Take(cantidadTop)
                    .Select(tc => new ClienteReservasDTO
                    {
                        IdCliente = tc.Cliente.IdCliente,
                        Dni = tc.Cliente.Dni,
                        Apellido = tc.Cliente.Apellido,
                        Nombre = tc.Cliente.Nombre,
                        FechaNacimiento = tc.Cliente.FechaNacimiento,
                        Email = tc.Cliente.Email,
                        Telefono = tc.Cliente.Telefono,
                        CantidadReservas = tc.CantidadReservas
                    })
                    .ToList();

                return topClientes;
            }
        }

        public List<ClienteReservasDTO> ObtenerTopClientesDelMes(int cantidadTop)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                DateTime fechaInicioMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime fechaFinMes = fechaInicioMes.AddMonths(1).AddSeconds(-1);

                var topClientes = hotelFive.Clientes
                    .Select(cliente => new
                    {
                        Cliente = cliente,
                        CantidadReservas = hotelFive.Reservas
                            .Where(r => r.IdCliente == cliente.IdCliente && r.FechaInicio >= fechaInicioMes && r.FechaFin <= fechaFinMes)
                            .Count()
                    })
                    .Where(tc => tc.CantidadReservas > 0)
                    .OrderByDescending(tc => tc.CantidadReservas)
                    .Take(cantidadTop)
                    .Select(tc => new ClienteReservasDTO
                    {
                        IdCliente = tc.Cliente.IdCliente,
                        Dni = tc.Cliente.Dni,
                        Apellido = tc.Cliente.Apellido,
                        Nombre = tc.Cliente.Nombre,
                        FechaNacimiento = tc.Cliente.FechaNacimiento,
                        Email = tc.Cliente.Email,
                        Telefono = tc.Cliente.Telefono,
                        CantidadReservas = tc.CantidadReservas
                    })
                    .ToList();

                return topClientes;
            }
        }




    }
}
