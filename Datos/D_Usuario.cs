﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Usuario
    {
        public DataTable LoginUser(E_Usuarios usuarios)
        {
            DataTable dt = new DataTable();
            //string query = "SELECT IdMascota, IdPropietario, NomMascota FROM Mascota WHERE IdPropietario = @id_prop";
            SqlConnection cnn = Conexion.getConexion();

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_LoginUser", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User", usuarios.Usuario);
                cmd.Parameters.AddWithValue("@Pass", usuarios.Contrasenia);
                SqlDataAdapter data = new SqlDataAdapter(cmd);

                data.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                cnn.Close();
            }
            return dt;
        }
    }
}