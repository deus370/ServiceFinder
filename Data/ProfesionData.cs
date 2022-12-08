using ServicioApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServicioApi.Data
{
    public class ProfesionData
    {
        public static bool Registrar(Profesion oProfesion)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("profesion_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@profesion", oProfesion.profesion);
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

        public static bool Modificar(Profesion oProfesion)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("profesion_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProfesion", oProfesion.idProfesion);
                cmd.Parameters.AddWithValue("@profesion", oProfesion.profesion);

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

        public static List<Profesion> Listar()
        {
            List<Profesion> ListaProfesion = new List<Profesion>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("profesion_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            ListaProfesion.Add(new Profesion()
                            {
                                idProfesion = Convert.ToInt32(dr["idProfesion"]),
                                profesion = dr["profesion"].ToString(),
                                estatus = Convert.ToInt32(dr["estatus"])
                            });
                        }

                    }
                    return ListaProfesion;
                }
                catch (Exception ex)
                {
                    return ListaProfesion;
                }
            }
        }
        public static List<Profesion> Obtener(int idUsuario)
        {
            List<Profesion> ListaProfesion = new List<Profesion>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("profesion_obtener", oConexion);
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
                            ListaProfesion.Add(new Profesion()
                            {
                                idProfesion = Convert.ToInt32(dr["idProfesion"]),
                                profesion = dr["profesion"].ToString(),
                                estatus = Convert.ToInt32(dr["estatus"])
                            });
                        }

                    }
                    return ListaProfesion;
                }
                catch (Exception ex)
                {
                    return ListaProfesion;
                }
            }
        }

        public static bool Eliminar(int idProfesion)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("profesion_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProfesion", idProfesion);

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

    }
}