using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Clientes
    {
        public DataTable getAllClients()
        {
            DataTable dt = new DataTable();

            try
            {
                SqlConnection cnn = Conexion.getConexion();
                SqlCommand command = new SqlCommand("usp_ClientesGet", cnn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return dt;
        }

        public void RegistrarCliente(E_Clientes clientes)
        {
            try
            {
                SqlConnection cnn = Conexion.getConexion();
                SqlCommand cmd = new SqlCommand("usp_ClienteInsert", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", clientes.Nombre);
                cmd.Parameters.AddWithValue("@Direccion", clientes.Direccion);
                cmd.Parameters.AddWithValue("@Correo", clientes.Correo);
                cmd.Parameters.AddWithValue("@Telefono", clientes.Telefono);
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Conexion.getClose();
            }
        }

        public void ActualizarCliente(E_Clientes clientes)
        {
            try
            {
                SqlConnection cnn = Conexion.getConexion();
                SqlCommand cmd = new SqlCommand("usp_ClienteUpdate", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", clientes.IdCLiente);
                cmd.Parameters.AddWithValue("@Nombre", clientes.Nombre);
                cmd.Parameters.AddWithValue("@Direccion", clientes.Direccion);
                cmd.Parameters.AddWithValue("@Correo", clientes.Correo);
                cmd.Parameters.AddWithValue("@Telefono", clientes.Telefono);
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Conexion.getClose();
            }
        }

        public void EliminarCliente(E_Clientes clientes)
        {
            try
            {
                SqlConnection cnn = Conexion.getConexion();
                SqlCommand cmd = new SqlCommand("usp_ClienteDelete", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", clientes.IdCLiente);
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Conexion.getClose();
            }
        }
    }
}
