using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public class CambiarConexionBD
    {
        public static void cambiarConexion(string cadenaConexion)
        {
            String cadenaNueva = cadenaConexion;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["Conexion"].ConnectionString = cadenaNueva;
            config.Save(ConfigurationSaveMode.Modified, true);
            Properties.Settings.Default.Save();
            MessageBox.Show("LA CADENA DE CONEXION SE ACTUALIZO CORRECTAMENTE", "INFORMACION DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }
    }
}
