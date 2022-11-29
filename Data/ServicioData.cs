using ServicioApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServicioApi.Data
{
    public class ServicioData
    {
        public static bool Registrar(Servicio oServicio)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("ser_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@servicio", oServicio.servicio);
                cmd.Parameters.AddWithValue("@descripcion", oServicio.descripcion);
                cmd.Parameters.AddWithValue("@precio", oServicio.precio);
                cmd.Parameters.AddWithValue("@idProfesionista", oServicio.idProfesionista);


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

        public static bool Modificar(Servicio oServicio)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("ser_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idServicio", oServicio.idServicio);
                cmd.Parameters.AddWithValue("@servicio", oServicio.servicio);
                cmd.Parameters.AddWithValue("@descripcion", oServicio.descripcion);
                cmd.Parameters.AddWithValue("@precio", oServicio.precio);
                cmd.Parameters.AddWithValue("@idProfesionista", oServicio.idProfesionista);

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

        public static List<Servicio> Listar()
        {
            List<Servicio> ListaServicio = new List<Servicio>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("ser_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            ListaServicio.Add(new Servicio()
                            {
                                idServicio = Convert.ToInt32(dr["idServicio"]),
                                servicio = dr["servicio"].ToString(),
                                descripcion = dr["descripcion"].ToString(),
                                precio = Convert.ToInt32(dr["precio"]),
                                idProfesionista = Convert.ToInt32(dr["idProfesionista"]),
                            });
                        }

                    }
                    return ListaServicio;
                }
                catch (Exception ex)
                {
                    return ListaServicio;
                }
            }
        }
        public static List<Servicio> Obtener(int idServicio)
        {
            List<Servicio> ListaServicio = new List<Servicio>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("ser_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idServicio", idServicio);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            ListaServicio.Add(new Servicio()
                            {
                                idServicio = Convert.ToInt32(dr["idServicio"]),
                                servicio = dr["servicio"].ToString(),
                                descripcion = dr["descripcion"].ToString(),
                                precio = Convert.ToInt32(dr["precio"]),
                                idProfesionista = Convert.ToInt32(dr["idProfesionista"]),
                            });
                        }

                    }
                    return ListaServicio;
                }
                catch (Exception ex)
                {
                    return ListaServicio;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("ser_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idServicio", id);

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