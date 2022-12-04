﻿using ServicioApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServicioApi.Data
{
    public class ClienteData
    {
        public static bool Registrar(Usuario oUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("rsn_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", oUsuario.nombre);
                cmd.Parameters.AddWithValue("@apePaterno", oUsuario.apePaterno);
                cmd.Parameters.AddWithValue("@apeMaterno", oUsuario.apeMaterno);
                cmd.Parameters.AddWithValue("@correo", oUsuario.correo);
                cmd.Parameters.AddWithValue("@contrasenia", oUsuario.contrasenia);
                cmd.Parameters.AddWithValue("@estatus", oUsuario.estatus);
                cmd.Parameters.AddWithValue("@idUsuario", oUsuario.idUsuario);

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

        public static bool Modificar(Usuario oUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("rsn_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", oUsuario.idUsuario);
                cmd.Parameters.AddWithValue("@nombre", oUsuario.nombre);
                cmd.Parameters.AddWithValue("@apePaterno", oUsuario.apePaterno);
                cmd.Parameters.AddWithValue("@apeMaterno", oUsuario.apeMaterno);
                cmd.Parameters.AddWithValue("@correo", oUsuario.correo);
                cmd.Parameters.AddWithValue("@contrasenia", oUsuario.contrasenia);
                cmd.Parameters.AddWithValue("@estatus", oUsuario.estatus);

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
            List<Usuario> oListaUsuario = new List<Usuario>();
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
                            oListaUsuario.Add(new Usuario()
                            {
                                idUsuario = Convert.ToInt32(dr["idUsuario"]),
                                nombre = dr["nombre"].ToString(),
                                apePaterno = dr["apellidoPaterno"].ToString(),
                                apeMaterno = dr["apellidoMaterno"].ToString(),
                                correo = dr["correo"].ToString(),
                                contrasenia = dr["contrasenia"].ToString(),
                                estatus = Convert.ToInt32(dr["estatus"])
                            });
                        }

                    }
                    return oListaUsuario;
                }
                catch (Exception ex)
                {
                    return oListaUsuario;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("rsn_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", id);

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