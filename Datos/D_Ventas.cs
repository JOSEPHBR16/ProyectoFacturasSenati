using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Ventas
    {
        readonly D_DetalleVentas e_detalleVenta = new D_DetalleVentas();

        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);

        public DataTable getAllVentas()
        {
            DataTable dt = new DataTable();

            try
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("usp_ListarVentas", cnn);
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

        public void AnularVenta(E_Ventas ventas)
        {
            SqlCommand cmd = new SqlCommand("usp_VentaAnulada", cnn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cnn.Open();

            cmd.Parameters.AddWithValue("@IdVenta", ventas.IdVenta);

            cmd.ExecuteNonQuery();

            cnn.Close();
        }

        public string InsertarVentas(E_Ventas ventas, List<E_DetalleVentas> detalleVentas)
        {
            string respuesta;

            try
            {
                cnn.Open(); 
                SqlTransaction transaction = cnn.BeginTransaction();

                SqlCommand cmd = new SqlCommand
                {
                    Connection = cnn,
                    Transaction = transaction,
                    CommandText = "usp_InsertarVenta",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter parIdVenta = new SqlParameter
                {
                    ParameterName = "@IdVenta",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(parIdVenta);

                cmd.Parameters.AddWithValue("@IdCliente", ventas.IdCliente);
                cmd.Parameters.AddWithValue("@IdUsuario", ventas.IdUsuario);
                cmd.Parameters.AddWithValue("@MontoBase", ventas.MontoBase);
                cmd.Parameters.AddWithValue("@IGV", ventas.Igv);
                cmd.Parameters.AddWithValue("@MontoTotal", ventas.MontoTotal);

                respuesta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo insertar";

                if (respuesta.Equals("OK"))
                {
                    ventas.IdVenta = Convert.ToInt32(cmd.Parameters["@IdVenta"].Value);
                    foreach (E_DetalleVentas det in detalleVentas)
                    {
                        det.IdVenta = ventas.IdVenta;

                        respuesta = e_detalleVenta.InsertarDetalleVenta(det, ref cnn, ref transaction);

                        if (!respuesta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }
                if (respuesta.Equals("OK"))
                {
                    transaction.Commit();
                }
                else
                {
                    transaction.Rollback();
                }
            }
            catch(Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if(cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return respuesta;
        }
    }
}
