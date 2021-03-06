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
    public class D_Productos
    {
        readonly SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());

        public DataTable getAllProducts()
        {
            DataTable dt = new DataTable();

            try
            {
                cnn.Open();
                //SqlConnection cnn = Conexion.getConexion();
                SqlCommand command = new SqlCommand("usp_ProductosGet", cnn);
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

        public DataTable cargarCategoriasProductos()
        {
            DataTable dt = new DataTable();
            //string query = "SELECT IdPropietario, Nombres FROM Propietario ORDER BY Nombres ASC";
            //SqlConnection cnn = Conexion.getConexion();

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_GetCategoriaProductos", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
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

        public void RegistrarProducto(E_Productos productos)
        {
            //int estado = 0;
            try
            {
                cnn.Open();
                //SqlConnection cnn = Conexion.getConexion();
                SqlCommand cmd = new SqlCommand("usp_ProductosInsert", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", productos.Nombre);
                cmd.Parameters.AddWithValue("@PrecioUnitario", productos.PrecioUnitario);
                cmd.Parameters.AddWithValue("@Stock", productos.Stock);
                cmd.Parameters.AddWithValue("@IdCategoria", productos.IdCategoria);
                //cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.ExecuteNonQuery();
                //estado = 1;
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

        public void ActualizarProducto(E_Productos productos)
        {
            //int estado = 0;
            try
            {
                //SqlConnection cnn = Conexion.getConexion();
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_ProductosUpdate", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", productos.IdProducto);
                cmd.Parameters.AddWithValue("@Nombre", productos.Nombre);
                cmd.Parameters.AddWithValue("@PrecioUnitario", productos.PrecioUnitario);
                cmd.Parameters.AddWithValue("@Stock", productos.Stock);
                cmd.Parameters.AddWithValue("@IdCategoria", productos.IdCategoria);
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

        public void EliminarProducto(E_Productos productos)
        {
            try
            {
                //SqlConnection cnn = Conexion.getConexion();
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_ProductoDelete", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", productos.IdProducto);
                
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
