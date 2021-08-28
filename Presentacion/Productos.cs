using Datos;
using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Productos : Form
    {
        D_Productos productos = new D_Productos();
        N_Productos objNegocio = new N_Productos();

        public Productos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            MostrarProductos();
            CountRowsData();
            CargarComboBoxCategorias();
            Bloquear();
        }

        public void MostrarProductos()
        {
            dgvProductos.DataSource = objNegocio.listadoProductos();
        }

        private void CargarComboBoxCategorias()
        {
            cboCategoria.DataSource = objNegocio.ComboBoxCategorias();
            cboCategoria.DisplayMember = "NombreCat";
            cboCategoria.ValueMember = "IdCategoriaProducto";
        }

        

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text == "" || txtPrecioUnitario.Text == "" || txtStock.Text == "")
                MessageBox.Show("Debe rellenar todos los campos.", "Campos Vacios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                Registrar();
                MessageBox.Show("Se inserto correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarProductos();
                CountRowsData();
                Limpiar();
            }
        }

        private void dgvProductos_Click(object sender, EventArgs e)
        {
            lblID.Text = dgvProductos.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
            txtPrecioUnitario.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
            txtStock.Text = dgvProductos.CurrentRow.Cells[3].Value.ToString();
            cboCategoria.Text = dgvProductos.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtPrecioUnitario.Text == "" || txtStock.Text == "")
                MessageBox.Show("Debe rellenar todos los campos.", "Campos Vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Actualizar();
                MessageBox.Show("Se actualizo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarProductos();
                CountRowsData();
                Limpiar();
                Bloquear();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Desbloquear();
            Limpiar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Bloquear();
            btnNuevo.Enabled = true;
        }

        private void Registrar()
        {
            E_Productos producto = new E_Productos();

            producto.Nombre = txtNombre.Text;
            producto.PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text, CultureInfo.InvariantCulture);
            producto.Stock = int.Parse(txtStock.Text);
            producto.IdCategoria = int.Parse((cboCategoria.SelectedValue).ToString());

            objNegocio.RegistrarProducto(producto);
        }

        private void Actualizar()
        {
            E_Productos producto = new E_Productos();

            producto.IdProducto = int.Parse(lblID.Text);
            producto.Nombre = txtNombre.Text;
            producto.PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text, CultureInfo.InvariantCulture);
            producto.Stock = int.Parse(txtStock.Text);
            producto.IdCategoria = int.Parse((cboCategoria.SelectedValue).ToString());

            objNegocio.ActualizarProducto(producto);
        }

        private void Limpiar()
        {
            txtNombre.Text = "";
            txtPrecioUnitario.Text = "";
            txtStock.Text = "";
            cboCategoria.SelectedIndex = 0;
        }

        private void Bloquear()
        {
            //txtStock.Enabled = false;
            //txtPrecioUnitario.Enabled = false;
            //txtNombre.Enabled = false;
            //cboCategoria.Enabled = false;
            btnGuardar.Enabled = false;
            btnEditar.Enabled = true;
            btnLimpiar.Enabled = false;
        }

        private void Desbloquear()
        {
            txtStock.Enabled = true;
            txtPrecioUnitario.Enabled = true;
            txtNombre.Enabled = true;
            cboCategoria.Enabled = true;
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            btnLimpiar.Enabled = true;
            btnNuevo.Enabled = false;
        }

        private void dgvProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RegistrarVentas ventas = Owner as RegistrarVentas;
            ventas.txtIdProducto.Text = dgvProductos.CurrentRow.Cells[0].Value.ToString();
            ventas.txtProdcuto.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
            ventas.txtPrecio.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
            Close();
        }

        private void CountRowsData()
        {
            int numRows = dgvProductos.Rows.Count;

            lblCount.Text = "Registros: " + numRows.ToString();
        }
    }
}
