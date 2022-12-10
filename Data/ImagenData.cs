using ServicioApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ServicioApi.Data
{
    public class ImagenData
    {
        public static List<Imagen> ObtenerImagen(int idProfesionista)
        {
            List<Imagen> oListaImagen = new List<Imagen>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("img_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProfesionista", idProfesionista);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaImagen.Add(new Imagen()
                            {
                                _Imagen = Convert.ToBase64String((byte[])dr["imagen"]),
                                idProfesionista= Convert.ToInt32(dr["idProfesionista"]),
                                idImagen = Convert.ToInt32(dr["idImagen"]),
                            }) ;
                        }
                    }
                    return oListaImagen;
                }
                catch (Exception ex)
                {
                    return oListaImagen;
                }
            }
        }

        public static bool Registrar(Imagen imagen)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("img_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Imagen", Convert.FromBase64String(imagen._Imagen));
                cmd.Parameters.AddWithValue("@IdProfesionista", imagen.idProfesionista);

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

        public static bool Modificar(Imagen imagen)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("img_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProfesionista", imagen.idProfesionista);
                cmd.Parameters.AddWithValue("@Imagen", imagen._Imagen);

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

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("img_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdImagen", id);
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