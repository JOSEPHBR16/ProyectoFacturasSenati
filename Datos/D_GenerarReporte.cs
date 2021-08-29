using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class D_GenerarReporte
    {
        readonly SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());

        public DataTable GenerarComprobante(int idventa)
        {
            cnn.Open();
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = cnn;
                cmd.CommandText = "usp_GenerarReporte";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdVenta", idventa);

                var reader = cmd.ExecuteReader();
                var tabla = new DataTable();
                tabla.Load(reader);

                return tabla;
            }
        }
    }
}
