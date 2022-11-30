using ServicioApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServicioApi.Data
{
    public class ResenaData
    {
        public static bool Registrar(Resena oResena)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("rsn_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@calificacion", oResena.calificacion);
                cmd.Parameters.AddWithValue("@comentario", oResena.comentario);
                cmd.Parameters.AddWithValue("@idProfesionista", oResena.idProfesionista);
                cmd.Parameters.AddWithValue("@idCliente", oResena.idCliente);

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

        public static bool Modificar(Resena oResena)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("rsn_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idResena", oResena.idResena);
                cmd.Parameters.AddWithValue("@calificacion", oResena.calificacion);
                cmd.Parameters.AddWithValue("@comentario", oResena.comentario);
                cmd.Parameters.AddWithValue("@idProfesionista", oResena.idProfesionista);
                cmd.Parameters.AddWithValue("@idCliente", oResena.idCliente);

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

        public static List<Resena> Listar()
        {
            List<Resena> oListaResena = new List<Resena>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("rsn_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaResena.Add(new Resena()
                            {
                                idResena = Convert.ToInt32(dr["idResena"]),
                                calificacion = Convert.ToDouble(dr["calificacion"]),
                                comentario = dr["comentario"].ToString(),
                                idProfesionista = Convert.ToInt32(dr["idProfesionista"]),
                                idCliente = Convert.ToInt32(dr["idCliente"]),
                            });
                        }

                    }
                    return oListaResena;
                }
                catch (Exception ex)
                {
                    return oListaResena;
                }
            }
        }
        public static List<Resena> ObtenerProfesionista(int idProfesionista)
        {
            List<Resena> oListaResena = new List<Resena>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("rsn_obtenerResenaProfesionista", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProfesionista", idProfesionista);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaResena.Add(new Resena()
                            {
                                idResena = Convert.ToInt32(dr["idResena"]),
                                calificacion = Convert.ToDouble(dr["calificacion"]),
                                comentario = dr["comentario"].ToString(),
                                idProfesionista = Convert.ToInt32(dr["idProfesionista"]),
                                idCliente = Convert.ToInt32(dr["idCliente"]),
                            });
                        }

                    }
                    return oListaResena;
                }
                catch (Exception ex)
                {
                    return oListaResena;
                }
            }
        }

        public static List<Resena> ObtenerUsuario(int idCliente)
        {
            List<Resena> oResena = new List<Resena>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("rsn_obtenerResenaCliente", oConexion);
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
                            oResena.Add(new Resena()
                            {
                                idResena = Convert.ToInt32(dr["idResena"]),
                                calificacion = Convert.ToDouble(dr["calificacion"]),
                                comentario = dr["comentario"].ToString(),
                                idProfesionista = Convert.ToInt32(dr["idProfesionista"]),
                                idCliente = Convert.ToInt32(dr["idCliente"]),
                            });
                        }

                    }
                    return oResena;
                }
                catch (Exception ex)
                {
                    return oResena;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("rsn_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idResena", id);

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