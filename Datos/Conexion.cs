using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Conexion
    {
        public static SqlConnection getConexion()
        {
            SqlConnection cnn = null;

            try
            {
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
                sb.DataSource = "localhost";
                sb.InitialCatalog = "DB_SystemWebZero";
                sb.UserID = "sa";
                sb.Password = "123";
                sb.ApplicationName = "SistemaDeCotizacionYVentas";
                cnn = new SqlConnection(sb.ConnectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return cnn;
        }

        public static void getClose()
        {
            if (getConexion().State == ConnectionState.Open)
                getConexion().Close();
        }
    }
}
