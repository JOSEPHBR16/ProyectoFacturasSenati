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
    public class D_Clientes
    {
        readonly SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        public DataTable getAllClients()
        {
            DataTable dt = new DataTable();

            try
            {
                cnn.Open();
                //SqlConnection cnn = Conexion.getConexion();
                SqlCommand command = new SqlCommand("usp_ClientesGet", cnn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
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

        public void RegistrarCliente(E_Clientes clientes)
        {
            try
            {
                cnn.Open();
                //SqlConnection cnn = Conexion.getConexion();
                SqlCommand cmd = new SqlCommand("usp_ClienteInsert", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", clientes.Nombre);
                cmd.Parameters.AddWithValue("@Direccion", clientes.Direccion);
                cmd.Parameters.AddWithValue("@Correo", clientes.Correo);
                cmd.Parameters.AddWithValue("@Telefono", clientes.Telefono);
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

        public void ActualizarCliente(E_Clientes clientes)
        {
            try
            {
                cnn.Open();
                //SqlConnection cnn = Conexion.getConexion();
                SqlCommand cmd = new SqlCommand("usp_ClienteUpdate", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", clientes.IdCLiente);
                cmd.Parameters.AddWithValue("@Nombre", clientes.Nombre);
                cmd.Parameters.AddWithValue("@Direccion", clientes.Direccion);
                cmd.Parameters.AddWithValue("@Correo", clientes.Correo);
                cmd.Parameters.AddWithValue("@Telefono", clientes.Telefono);
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

        public void EliminarCliente(E_Clientes clientes)
        {
            try
            {
                cnn.Open();
                //SqlConnection cnn = Conexion.getConexion();
                SqlCommand cmd = new SqlCommand("usp_ClienteDelete", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", clientes.IdCLiente);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
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
