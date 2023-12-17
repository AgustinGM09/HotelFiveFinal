using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Security.Cryptography;

namespace Domain
{
    public class UsuarioController
    {

        public UsuarioController() 
        {
 
        }

        public List<UsuarioDTO> ListarUsuarios()
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var usuariosDTO = hotelFive.Usuarios
                    .Select(u => new UsuarioDTO
                    {
                        TipoUsuario = u.Tipo_Usuario.nombre,
                        Nombre = u.nombre,
                        Apellido = u.apellido,
                        Dni = u.DNI.ToString(),
                        Telefono = u.telefono.ToString(),
                        Email = u.email,
                        Baja = u.baja.ToString(),
                    })
                    .ToList();
                return usuariosDTO;
            }
        }

        public List<TipoUsuarioDTO> ListarTipoUsuarios()
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var tipoUsuariosDTO = hotelFive.Tipo_Usuario
                    .Select(u => new TipoUsuarioDTO
                    {
                        Id = u.id_tipoUsuario,
                        Nombre = u.nombre,
                    })
                    .ToList();
                return tipoUsuariosDTO;
            }
        }

        public bool AgregarUsuario(string nombre, string apellido, int telefono, string email, int dni, int idTipoUsuario, string contraseña, int baja)
        {
            try
            {
                // Validar datos
                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || telefono <= 0 || string.IsNullOrWhiteSpace(email) || dni <= 0 || string.IsNullOrWhiteSpace(contraseña)  || idTipoUsuario <= 0 || baja <= 0)
                {
                    // Lanzar una excepción si algún dato es inválido
                    throw new ArgumentException("Todos los campos son obligatorios y deben tener valores válidos.");
                }
                string contrasena = HashPassword(contraseña);

                // TODO Validaciones más específicas, por ejemplo, validar el formato del correo electrónico o la longitud del DNI O Telefono.

                // Crear una nueva instancia de Usuarios
                Usuarios nuevoUsuario = new Usuarios
                {
                    nombre = nombre,
                    apellido = apellido,
                    telefono = telefono,
                    email = email,
                    DNI = dni,
                    id_tipoUsuario = idTipoUsuario,
                    contraseña = contrasena,
                    baja = baja,
                };

                // Agregar el nuevo usuario a la base de datos
                using (HotelFiveEntities hotelFive = new HotelFiveEntities())
                {
                    hotelFive.Usuarios.Add(nuevoUsuario);
                    hotelFive.SaveChanges();
                }

                Console.WriteLine("Usuario agregado correctamente.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                string hashedPassword = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                // Limita la longitud de la contraseña hasheada a 30 caracteres
                if (hashedPassword.Length > 30)
                {
                    hashedPassword = hashedPassword.Substring(0, 30);
                }

                return hashedPassword;
            }
        }

        public Usuarios ObtenerUsuarioPorId(int idUsuario)
        {
            try
            {
                using (HotelFiveEntities hotelFive = new HotelFiveEntities())
                {
                    return hotelFive.Usuarios.FirstOrDefault(u => u.DNI == idUsuario);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void ActualizarUsuario(int idUsuario,string nombre, string apellido, int telefono, string email, int dni, int idTipoUsuario, string baja)
        {
            try
            {
                using (HotelFiveEntities hotelFive = new HotelFiveEntities())
                {
                    // Buscar el usuario a actualizar
                    var usuario = hotelFive.Usuarios.FirstOrDefault(u => u.id_usuario == idUsuario);

                    if (usuario != null)
                    {
                        // Actualizar propiedades
                        usuario.nombre = nombre;
                        usuario.apellido = apellido;
                        usuario.telefono = telefono;
                        usuario.email = email;
                        usuario.DNI = dni;
                        usuario.id_tipoUsuario = idTipoUsuario;
                        usuario.baja = Convert.ToInt32(baja);

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

        public List<UsuarioDTO> BuscarUsuariosPorNombre(string nombreUsuario)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var usuarios = hotelFive.Usuarios
                    .Where(u => u.nombre == nombreUsuario)
                    .Select(u => new UsuarioDTO
                    {
                        TipoUsuario = u.Tipo_Usuario.nombre,
                        Nombre = u.nombre,
                        Apellido = u.apellido,
                        Dni = u.DNI.ToString(),
                        Telefono = u.telefono.ToString(),
                        Email = u.email,
                        Baja = u.baja.ToString(),
                    })
                    .ToList();

                return usuarios;
            }
        }

        public List<UsuarioDTO> BuscarUsuarios(string nombreUsuario, string apellido, int dni)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var usuarios = hotelFive.Usuarios
                    .Where(u => (u.nombre == nombreUsuario || u.apellido == apellido || u.DNI == dni))
                    .Select(u => new UsuarioDTO
                    {
                        TipoUsuario = u.Tipo_Usuario.nombre,
                        Nombre = u.nombre,
                        Apellido = u.apellido,
                        Dni = u.DNI.ToString(),
                        Telefono = u.telefono.ToString(),
                        Email = u.email,
                        Baja = u.baja.ToString(),
                    })
                    .ToList();

                return usuarios;
            }
        }

        public List<UsuarioDTO> BuscarUsuariosPorApellido(string apellidoUsuario)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var usuarios = hotelFive.Usuarios
                    .Where(u => u.apellido == apellidoUsuario)
                    .Select(u => new UsuarioDTO
                    {
                        TipoUsuario = u.Tipo_Usuario.nombre,
                        Nombre = u.nombre,
                        Apellido = u.apellido,
                        Dni = u.DNI.ToString(),
                        Telefono = u.telefono.ToString(),
                        Email = u.email,
                        Baja = u.baja.ToString(),
                    })
                    .ToList();

                return usuarios;
            }
        }

        public List<UsuarioDTO> BuscarUsuariosPorDni(int DniUsuario)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var usuarios = hotelFive.Usuarios
                    .Where(u => u.DNI == DniUsuario)
                    .Select(u => new UsuarioDTO
                    {
                        TipoUsuario = u.Tipo_Usuario.nombre,
                        Nombre = u.nombre,
                        Apellido = u.apellido,
                        Dni = u.DNI.ToString(),
                        Telefono = u.telefono.ToString(),
                        Email = u.email,
                        Baja = u.baja.ToString(),
                    })
                    .ToList();

                return usuarios;
            }
        }

        public List<dynamic> BuscarUsuarios(string nombre, string apellido, int? dni)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {

                var resultados = hotelFive.Usuarios.Select(u => new {
                    TipoUsuario = u.Tipo_Usuario.nombre,
                    u.DNI,
                    u.apellido,
                    u.nombre,
                    u.email,
                    u.telefono,
                    u.baja
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
                    resultados = resultados.Where(u => u.nombre.StartsWith(nombre));
                }
                if (!string.IsNullOrEmpty(apellido))
                {
                    resultados = resultados.Where(u => u.apellido.StartsWith(apellido));
                }
                if (dni != null)
                {
                    resultados = resultados.Where(u => u.DNI == dni);
                }

                // Retorna la lista de usuarios encontrados
                return resultados.ToList<dynamic>();
            }
        }
        public List<string> NYAusuario(int usuario)
        {
            using (HotelFiveEntities hotelFive = new HotelFiveEntities())
            {
                var usuarioDTO = hotelFive.Usuarios
                    .Where(u => u.id_usuario == usuario)
                    .Select(u => new
                    {
                        Nombre = u.nombre,
                        Apellido = u.apellido
                    })
                    .FirstOrDefault();

                if (usuarioDTO != null)
                {
                    // Devuelve una lista con el nombre y el apellido
                    return new List<string> { usuarioDTO.Nombre, usuarioDTO.Apellido };
                }
                else
                {
                    // Si no se encuentra el usuario, devuelve una lista vacía
                    return new List<string>();
                }
            }
        }
    }
}
