using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Usuario
    {
        readonly SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());

        public DataTable LoginUser(E_Usuarios usuarios)
        {
            DataTable dt = new DataTable();

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

        public void RegistrarUsuario(E_Usuarios usuarios)
        {
            try
            {
                //SqlConnection cnn = Conexion.getConexion();
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_CrearUsuario", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", usuarios.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", usuarios.Apellidos);
                cmd.Parameters.AddWithValue("@Usuario", usuarios.Usuario);
                cmd.Parameters.AddWithValue("@Contrasenia", usuarios.Contrasenia);
                //cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}
