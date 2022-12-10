using ServicioApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServicioApi.Data
{
    public class EstatusData
    {
        public static bool Registrar(Estatus oEstatus)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("est_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@estatus", oEstatus.estatus);
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

        public static bool Modificar(Estatus oEstatus)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("user_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEstatus", oEstatus.idEstatus);
                cmd.Parameters.AddWithValue("@estatus", oEstatus.estatus);

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

        public static List<Estatus> Listar()
        {
            List<Estatus> ListaEstatus = new List<Estatus>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("est_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ListaEstatus.Add(new Estatus()
                            {
                                idEstatus = Convert.ToInt32(dr["idEstatus"]),
                                estatus = dr["estatus"].ToString()
                            });
                        }

                    }
                    return ListaEstatus;
                }
                catch (Exception ex)
                {
                    return ListaEstatus;
                }
            }
        }
        public static List<Estatus> Obtener(int idEstatus)
        {
            List<Estatus> ListaEstatus = new List<Estatus>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("est_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEstatus", idEstatus);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            ListaEstatus.Add(new Estatus()
                            {
                                idEstatus = Convert.ToInt32(dr["idEstatus"]),
                                estatus = dr["estatus"].ToString()
                            });
                        }

                    }
                    return ListaEstatus;
                }
                catch (Exception ex)
                {
                    return ListaEstatus;
                }
            }
        }

        public static bool Eliminar(int idEstatus)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("est_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEstatus", idEstatus);

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