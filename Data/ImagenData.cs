using ServicioApi.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace ServicioApi.Data
{
    public class ImagenData
    {
        public static byte[] ObtenerImagen(int idProfesionista)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("img_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProfesionista", idProfesionista);
                byte[] imagen = null;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            imagen = (byte[])dr["imagen"];
                        }
                    }
                    return imagen;
                }
                catch (Exception ex)
                {
                    return imagen;
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
                cmd.Parameters.AddWithValue("@IdProfesionista", id);
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