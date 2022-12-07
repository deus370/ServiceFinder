using ServicioApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServicioApi.Data
{
    public class LogsData
    {
        public static bool Registrar(Logs oLogs)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("logs_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fecha", oLogs.fecha);
                cmd.Parameters.AddWithValue("@descripcion", oLogs.descripcion);
                cmd.Parameters.AddWithValue("@idUsuario", oLogs.idUsuario);
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

        
        public static List<Logs> Listar()
        {
            List<Logs> ListaLogs = new List<Logs>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("logs_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            ListaLogs.Add(new Logs()
                            {
                                idLog = Convert.ToInt32(dr["idLog"]),
                                fecha = Convert.ToDateTime(dr["fecha"]),
                                descripcion = dr["descripcion"].ToString(),
                                idUsuario = Convert.ToInt32(dr["idUsuario"])
                            });
                        }

                    }
                    return ListaLogs;
                }
                catch (Exception ex)
                {
                    return ListaLogs;
                }
            }
        }
        public static List<Logs> Obtener(int idUsuario)
        {
            List<Logs> ListaLogs = new List<Logs>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("logs_obtener", oConexion);
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
                            ListaLogs.Add(new Logs()
                            {
                                idLog = Convert.ToInt32(dr["idLog"]),
                                fecha = Convert.ToDateTime(dr["fecha"]),
                                descripcion = dr["descripcion"].ToString(),
                                idUsuario = Convert.ToInt32(dr["idUsuario"])
                            });
                        }

                    }
                    return ListaLogs;
                }
                catch (Exception ex)
                {
                    return ListaLogs;
                }
            }
        }
    }
}