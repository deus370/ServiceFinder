using ServicioApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServicioApi.Data
{
    public class ProfesionistaData
    {
        public static bool Registrar(Profesionista oProf)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("prof_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", oProf.descripcion);
                cmd.Parameters.AddWithValue("@idProfesion", oProf.idProfesion);

                cmd.Parameters.AddWithValue("@correo", oProf.correo);
                cmd.Parameters.AddWithValue("@contrasenia", oProf.contrasenia);
                cmd.Parameters.AddWithValue("@nombre", oProf.nombre);
                cmd.Parameters.AddWithValue("@apellidoPaterno", oProf.apellidoPaterno);
                cmd.Parameters.AddWithValue("@apellidoMaterno", oProf.apellidoMaterno);
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

        public static bool Modificar(Profesionista oProf)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("prof_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProfesionista", oProf.idProfesionista);
                cmd.Parameters.AddWithValue("@descripcion", oProf.descripcion);
                cmd.Parameters.AddWithValue("@idProfesion", oProf.idProfesion);
                cmd.Parameters.AddWithValue("@idUsuario", oProf.idUsuario);

                cmd.Parameters.AddWithValue("@correo", oProf.correo);
                cmd.Parameters.AddWithValue("@contrasenia", oProf.contrasenia);
                cmd.Parameters.AddWithValue("@nombre", oProf.nombre);
                cmd.Parameters.AddWithValue("@apellidoPaterno", oProf.apellidoPaterno);
                cmd.Parameters.AddWithValue("@apellidoMaterno", oProf.apellidoMaterno);

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

        public static List<Profesionista> Listar()
        {
            List<Profesionista> ListaProf = new List<Profesionista>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("prof_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            ListaProf.Add(new Profesionista()
                            {
                                idProfesionista = Convert.ToInt32(dr["idProfesionista"]),
                                descripcion = dr["descripcion"].ToString(),
                                idProfesion = Convert.ToInt32(dr["idProfesion"]),
                                estatus = Convert.ToInt32(dr["estatus"]),
                                idUsuario = Convert.ToInt32(dr["idUsuario"]),

                                correo = dr["correo"].ToString(),
                                contrasenia = dr["contrasenia"].ToString(),
                                nombre = dr["nombre"].ToString(),
                                apellidoPaterno = dr["apellidoPaterno"].ToString(),
                                apellidoMaterno = dr["apellidoMaterno"].ToString(),
                                idRol = Convert.ToInt32(dr["idRol"]),
                            });
                        }

                    }
                    return ListaProf;
                }
                catch (Exception ex)
                {
                    return ListaProf;
                }
            }
        }
        public static List<Profesionista> Obtener(int idUsuario)
        {
            List<Profesionista> ListaProf = new List<Profesionista>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("prof_obtenerPorUsuario", oConexion);
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
                            ListaProf.Add(new Profesionista()
                            {
                                idProfesionista = Convert.ToInt32(dr["idProfesionista"]),
                                descripcion = dr["descripcion"].ToString(),
                                idProfesion = Convert.ToInt32(dr["idProfesion"]),
                                estatus = Convert.ToInt32(dr["estatus"]),
                                idUsuario = Convert.ToInt32(dr["idUsuario"]),

                                correo = dr["correo"].ToString(),
                                contrasenia = dr["contrasenia"].ToString(),
                                nombre = dr["nombre"].ToString(),
                                apellidoPaterno = dr["apellidoPaterno"].ToString(),
                                apellidoMaterno = dr["apellidoMaterno"].ToString(),
                                idRol = Convert.ToInt32(dr["idRol"]),
                            });
                        }

                    }
                    return ListaProf;
                }
                catch (Exception ex)
                {
                    return ListaProf;
                }
            }
        }

        public static bool Eliminar(int idProfesionista, int idUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("prof_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProfesionista", idProfesionista);
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