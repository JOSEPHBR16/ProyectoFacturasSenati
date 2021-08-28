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
    public partial class Ventas : Form
    {
        N_Ventas objNegocio = new N_Ventas();

        public Ventas()
        {
            InitializeComponent();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            MostrarVentas();
        }

        public void MostrarVentas()
        {
            dgvVentas.DataSource = objNegocio.ListadoVentas();
        }

        private void AgPrd_UpdateEventHandlerI(object sender, RegistrarVentas.UpdateEventArgs args)
        {
            MostrarVentas();
            CountRowsData();
        }

        private void CountRowsData()
        {
            int numRows = dgvVentas.Rows.Count;

            lblCount.Text = "Registros: " + numRows.ToString();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            RegistrarVentas registrarVentas = new RegistrarVentas(this);
            AddOwnedForm(registrarVentas);
            registrarVentas.UpdateEventHandler += AgPrd_UpdateEventHandlerI;
            registrarVentas.ShowDialog();
        }
    }
}
