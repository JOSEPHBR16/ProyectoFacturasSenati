using Negocio;
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
    public partial class Reporte_Clientes : Form
    {
        public Reporte_Clientes()
        {
            InitializeComponent();
        }

        private void ReporteClientes()
        {
            N_Clientes clientes = new N_Clientes();
            clientes.ListadoClientes();

            E_ClientesBindingSource.DataSource = clientes.generarReportes;
            reportViewer1.RefreshReport();
        }

        private void Reporte_Clientes_Load(object sender, EventArgs e)
        {
            ReporteClientes();
        }
    }
}
