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
    public partial class GenerarReporte : Form
    {
        public int IDVENTAS;

        public GenerarReporte(Ventas ventas)
        {
            InitializeComponent();
        }

        private void GenerarReportes(int idVentas)
        {
            N_GenerarReporte generarReporte = new N_GenerarReporte();
            generarReporte.GenerarReporte(idVentas);

            N_GenerarReporteBindingSource.DataSource = generarReporte.generarReportes;
            reportViewer1.RefreshReport();
        }

        private void GenerarReporte_Load(object sender, EventArgs e)
        {
            GenerarReportes(IDVENTAS);
        }
    }
}
