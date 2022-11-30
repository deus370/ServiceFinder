using ServicioApi.Data;
using ServicioApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServicioApi.Data
{
    public class SolicitudData
    {
        public static bool Registrar(Solicitud oSolicitud)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sol_InsertarSolicitud", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fechaSolicitud", oSolicitud.fechaSolicitud);
                cmd.Parameters.AddWithValue("@descripcion", oSolicitud.descripcion);
                cmd.Parameters.AddWithValue("@telefono", oSolicitud.telefono);
                cmd.Parameters.AddWithValue("@idCliente", oSolicitud.idCliente);
                cmd.Parameters.AddWithValue("@idProfesionista", oSolicitud.idProfesionista);
                cmd.Parameters.AddWithValue("@idEstatus", oSolicitud.idEstatus);

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
        public static bool Modificar(Solicitud oSolicitud)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sol_ModificarSolicitud", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idSolicitud", oSolicitud.idSolicitud);
                cmd.Parameters.AddWithValue("@fechaSolicitud", oSolicitud.fechaSolicitud);
                cmd.Parameters.AddWithValue("@descripcion", oSolicitud.descripcion);
                cmd.Parameters.AddWithValue("@telefono", oSolicitud.telefono);
                cmd.Parameters.AddWithValue("@idCliente", oSolicitud.idCliente);
                cmd.Parameters.AddWithValue("@idProfesionista", oSolicitud.idProfesionista);
                cmd.Parameters.AddWithValue("@idEstatus", oSolicitud.idEstatus);

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
        public static List<Solicitud> Listar()
        {
            List<Solicitud> oListarSolicitudes = new List<Solicitud>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sol_ListaTodasSolicitudes", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListarSolicitudes.Add(new Solicitud()
                            {
                                idSolicitud = Convert.ToInt32(dr["idSolicitud"]),
                                fechaSolicitud = Convert.ToDateTime(dr["fechaSolicitud"]),
                                descripcion = Convert.ToString(dr["descripcion"]),
                                telefono = Convert.ToString(dr["telefono"]),
                                idCliente = Convert.ToInt32(dr["idCliente"]),
                                idProfesionista = Convert.ToInt32(dr["idProfesionista"]),
                                idEstatus = Convert.ToInt32(dr["idEstatus"])
                            });
                        }
                    }
                    return oListarSolicitudes;
                }
                catch (Exception ex)
                {
                    return oListarSolicitudes;
                }
            }
        }
        public static List<Solicitud> ObtenerSolicitudXId(int idSolicitud)
        {
            List<Solicitud> oListarSolicitud = new List<Solicitud>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sol_ObtenerSolicitudXId", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idSolicitud", idSolicitud);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListarSolicitud.Add(new Solicitud()
                            {
                                idSolicitud = Convert.ToInt32(dr["idSolicitud"]),
                                fechaSolicitud = Convert.ToDateTime(dr["fechaSolicitud"]),
                                descripcion = Convert.ToString(dr["descripcion"]),
                                telefono = Convert.ToString(dr["telefono"]),
                                idCliente = Convert.ToInt32(dr["idCliente"]),
                                idProfesionista = Convert.ToInt32(dr["idProfesionista"]),
                                idEstatus = Convert.ToInt32(dr["idEstatus"])
                            });
                        }

                    }
                    return oListarSolicitud;
                }
                catch (Exception ex)
                {
                    return oListarSolicitud;
                }
            }
        }
        public static List<Solicitud> ObtenerSolicitudXIdCliente(int idCliente)
        {
            List<Solicitud> oListarSolicitud = new List<Solicitud>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sol_ObtenerSolicitudXCliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", idCliente);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListarSolicitud.Add(new Solicitud()
                            {
                                idSolicitud = Convert.ToInt32(dr["idSolicitud"]),
                                fechaSolicitud = Convert.ToDateTime(dr["fechaSolicitud"]),
                                descripcion = Convert.ToString(dr["descripcion"]),
                                telefono = Convert.ToString(dr["telefono"]),
                                idCliente = Convert.ToInt32(dr["idCliente"]),
                                idProfesionista = Convert.ToInt32(dr["idProfesionista"]),
                                idEstatus = Convert.ToInt32(dr["idEstatus"])
                            });
                        }

                    }
                    return oListarSolicitud;
                }
                catch (Exception ex)
                {
                    return oListarSolicitud;
                }
            }
        }
        public static List<Solicitud> ObtenerSolicitudXIdProfesionista(int idProfesion)
        {
            List<Solicitud> oListarSolicitud = new List<Solicitud>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sol_ObtenerSolicitudXProfesionista", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProfesionista", idProfesion);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListarSolicitud.Add(new Solicitud()
                            {
                                idSolicitud = Convert.ToInt32(dr["idSolicitud"]),
                                fechaSolicitud = Convert.ToDateTime(dr["fechaSolicitud"]),
                                descripcion = Convert.ToString(dr["descripcion"]),
                                telefono = Convert.ToString(dr["telefono"]),
                                idCliente = Convert.ToInt32(dr["idCliente"]),
                                idProfesionista = Convert.ToInt32(dr["idProfesionista"]),
                                idEstatus = Convert.ToInt32(dr["idEstatus"])
                            });
                        }

                    }
                    return oListarSolicitud;
                }
                catch (Exception ex)
                {
                    return oListarSolicitud;
                }
            }
        }
        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sol_EliminarSolicitud", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idSolicitud", id);

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