using ServicioApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServicioApi.Data
{
    public class UsuarioData
    {
        public static bool Registrar(Usuario oUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("user_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@correo", oUsuario.correo);
                cmd.Parameters.AddWithValue("@contrasenia", oUsuario.contrasenia);
                cmd.Parameters.AddWithValue("@nombre", oUsuario.nombre);
                cmd.Parameters.AddWithValue("@apellidoPaterno", oUsuario.apellidoPaterno);
                cmd.Parameters.AddWithValue("@apellidoMaterno", oUsuario.apellidoMaterno);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }

        public static bool Modificar(Usuario oUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("user_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", oUsuario.idUsuario);
                cmd.Parameters.AddWithValue("@correo", oUsuario.correo);
                cmd.Parameters.AddWithValue("@contrasenia", oUsuario.contrasenia);
                cmd.Parameters.AddWithValue("@nombre", oUsuario.nombre);
                cmd.Parameters.AddWithValue("@apellidoPaterno", oUsuario.apellidoPaterno);
                cmd.Parameters.AddWithValue("@apellidoMaterno", oUsuario.apellidoMaterno);
                cmd.Parameters.AddWithValue("@estatus", oUsuario.estatus);
                cmd.Parameters.AddWithValue("@idRol", oUsuario.idRol);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Usuario> Listar()
        {
            List<Usuario> ListaUsuario = new List<Usuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("user_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            ListaUsuario.Add(new Usuario()
                            {
                                idUsuario = Convert.ToInt32(dr["idUsuario"]),
                                correo = dr["correo"].ToString(),
                                contrasenia = dr["contrasenia"].ToString(),
                                nombre = dr["nombre"].ToString(),
                                apellidoPaterno = dr["apellidoPaterno"].ToString(),
                                apellidoMaterno = dr["apellidoMaterno"].ToString(),
                                estatus = Convert.ToInt32(dr["estatus"]),
                                idRol = Convert.ToInt32(dr["idRol"]),
                            });
                        }

                    }
                    return ListaUsuario;
                }
                catch (Exception ex)
                {
                    return ListaUsuario;
                }
            }
        }
        public static List<Usuario> Obtener(int idUsuario)
        {
            List<Usuario> ListaUsuario = new List<Usuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("user_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            ListaUsuario.Add(new Usuario()
                            {
                                idUsuario = Convert.ToInt32(dr["idUsuario"]),
                                correo = dr["correo"].ToString(),
                                contrasenia = dr["contrasenia"].ToString(),
                                nombre = dr["nombre"].ToString(),
                                apellidoPaterno = dr["apellidoPaterno"].ToString(),
                                apellidoMaterno = dr["apellidoMaterno"].ToString(),
                                estatus = Convert.ToInt32(dr["estatus"]),
                                idRol = Convert.ToInt32(dr["idRol"]),
                            });
                        }

                    }
                    return ListaUsuario;
                }
                catch (Exception ex)
                {
                    return ListaUsuario;
                }
            }
        }

        public static bool Eliminar(int idUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("user_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Usuario> LoginUser(Usuario ousuario)
        {
            List<Usuario> ListaUsuario = new List<Usuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("loginUser", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@correo", ousuario.correo);
                cmd.Parameters.AddWithValue("@contrasenia", ousuario.contrasenia);


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            ListaUsuario.Add(new Usuario()
                            {
                                idUsuario = Convert.ToInt32(dr["idUsuario"]),
                                correo = dr["correo"].ToString(),
                                contrasenia = dr["contrasenia"].ToString(),
                                nombre = dr["nombre"].ToString(),
                                apellidoPaterno = dr["apellidoPaterno"].ToString(),
                                apellidoMaterno = dr["apellidoMaterno"].ToString(),
                                estatus = Convert.ToInt32(dr["estatus"]),
                                idRol = Convert.ToInt32(dr["idRol"]),
                            });
                        }

                    }
                    return ListaUsuario;
                }
                catch (Exception ex)
                {
                    return ListaUsuario;
                }
            }
        }


    }
    
}