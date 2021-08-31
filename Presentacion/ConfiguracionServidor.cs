using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class ConfiguracionServidor : Form
    {
        public ConfiguracionServidor()
        {
            InitializeComponent();
        }

        private void btnCambiarConexion_Click(object sender, EventArgs e)
        {
            string conexion = $"Data Source=.;Initial Catalog=DB_SystemWebZero;User ID={txtUserID.Text};Password={txtPassword.Text};";
            CambiarConexionBD.cambiarConexion(conexion);
        }
    }
}
