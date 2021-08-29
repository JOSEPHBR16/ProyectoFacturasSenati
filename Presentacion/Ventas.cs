using Entidades;
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
        E_Ventas entidad = new E_Ventas();

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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string estado = dgvVentas.CurrentRow.Cells[8].Value.ToString();

            if (estado == "ANULADO")
            {
                MessageBox.Show("No puedes imprimir ventas anuladas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                GenerarReporte generarReporte = new GenerarReporte(this);
                AddOwnedForm(generarReporte);
                generarReporte.IDVENTAS = Convert.ToInt32(dgvVentas.CurrentRow.Cells[0].Value.ToString());
                generarReporte.ShowDialog();
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            string estado = dgvVentas.CurrentRow.Cells[8].Value.ToString();
            
            if (estado == "ANULADO")
            {
                MessageBox.Show("Esta venta ha sido anulada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (dgvVentas.SelectedRows.Count > 0)
                {
                    DialogResult opcion;
                    opcion = MessageBox.Show("Desea anular el registro?", "Anular", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (opcion == DialogResult.OK)
                    {
                        entidad.IdVenta = Convert.ToInt32(dgvVentas.CurrentRow.Cells[0].Value.ToString());

                        objNegocio.AnularVenta(entidad);

                        MessageBox.Show("La venta ha sido anulada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MostrarVentas();
                    }
                }
                else
                {
                    MessageBox.Show("Debe de seleccionar un registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
