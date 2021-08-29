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
    public partial class EditarProducto : Form
    {
        N_Productos objNegocio = new N_Productos();

        public EditarProducto(Producto producto)
        {
            InitializeComponent();
        }

        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;

        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }

        protected void Agregar()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }

        private void CargarComboBoxCategorias()
        {
            cboCategoria.DataSource = objNegocio.ComboBoxCategorias();
            cboCategoria.DisplayMember = "NombreCat";
            cboCategoria.ValueMember = "IdCategoriaProducto";
        }

        private void EditarProducto_Load(object sender, EventArgs e)
        {
            CargarComboBoxCategorias();
        }

        private void Limpiar()
        {
            txtNombre.Text = "";
            txtStock.Text = "";
            txtPrecioUnitario.Text = "";
            cboCategoria.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtStock.Text == "" || txtPrecioUnitario.Text == "" || cboCategoria.Text == "")
                MessageBox.Show("Debe rellenar todos los campos.", "Campos Vacios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                Actualizar();
                MessageBox.Show("Se inserto correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Agregar();
                this.Close();
            }
        }

        private void Actualizar()
        {
            E_Productos producto = new E_Productos();

            producto.IdProducto = int.Parse(lblIdProducto.Text);
            producto.Nombre = txtNombre.Text;
            producto.PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text);
            producto.Stock = int.Parse(txtStock.Text);
            producto.IdCategoria = int.Parse((cboCategoria.SelectedValue).ToString());

            objNegocio.ActualizarProducto(producto);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
