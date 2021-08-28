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
    public class D_DetalleVentas
    {
        public string InsertarDetalleVenta(E_DetalleVentas detalleVentas, ref SqlConnection connection, ref SqlTransaction transaction)
        {
            string respuesta;
            try
            {
                SqlCommand cmd = new SqlCommand("usp_InsertarDetalleVenta", connection) 
                {
                    CommandType = CommandType.StoredProcedure,
                    Transaction = transaction
                };
                cmd.Parameters.AddWithValue("@IdVenta", detalleVentas.IdVenta);
                cmd.Parameters.AddWithValue("@IdProducto", detalleVentas.IdProducto);
                cmd.Parameters.AddWithValue("@Cantidad", detalleVentas.Cantidad);

                respuesta = cmd.ExecuteNonQuery() == 1 ? "OK" : "Error al insertar";
            }
            catch(Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }
    }
}
