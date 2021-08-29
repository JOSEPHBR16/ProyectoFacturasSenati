using Datos;
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
    public partial class Producto : Form
    {
        D_Productos productos = new D_Productos();
        N_Productos objNegocio = new N_Productos();

        public Producto()
        {
            InitializeComponent();
        }

        private void Producto_Load(object sender, EventArgs e)
        {
            MostrarProducto();
            CountRowsData();
            //CargarComboBoxCategorias();
        }

        private void AgPrd_UpdateEventHandlerI(object sender, RegistrarProducto.UpdateEventArgs args)//Cambiar el registrar cliente
        {
            MostrarProducto();
            CountRowsData();
        }

        private void AgPrd_UpdateEventHandlerE(object sender, EditarProducto.UpdateEventArgs args)//Cambiar el editar cliente
        {
            MostrarProducto();
            CountRowsData();
        }

        public void MostrarProducto()
        {
            dgvProductos.DataSource = objNegocio.listadoProductos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            bool rpta = Roles();

            if (rpta == true)
                MessageBox.Show("No tiene permisos de administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                RegistrarProducto registrarProducto = new RegistrarProducto(this);
                AddOwnedForm(registrarProducto);
                registrarProducto.UpdateEventHandler += AgPrd_UpdateEventHandlerI;
                registrarProducto.ShowDialog();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            bool rpta = Roles();

            if (rpta == true)
                MessageBox.Show("No tiene permisos de administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                EditarProducto editarProducto = new EditarProducto(this);
                AddOwnedForm(editarProducto);
                editarProducto.UpdateEventHandler += AgPrd_UpdateEventHandlerE;
                editarProducto.lblIdProducto.Text = dgvProductos.CurrentRow.Cells[0].Value.ToString();
                editarProducto.txtNombre.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
                editarProducto.txtPrecioUnitario.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                editarProducto.txtStock.Text = dgvProductos.CurrentRow.Cells[3].Value.ToString();
                editarProducto.cboCategoria.SelectedItem = dgvProductos.CurrentRow.Cells[3].Value.ToString();
                editarProducto.ShowDialog();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool rpta = Roles();

            if (rpta == true)
                MessageBox.Show("No tiene permisos de administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DialogResult rs;
                rs = MessageBox.Show("Desea eliminar el registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    Eliminar();
                    MessageBox.Show("Registro eliminado con exito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarProducto();
                    CountRowsData();
                }
            }
        }

        private void Eliminar()
        {
            E_Productos producto = new E_Productos();

            var id = dgvProductos.CurrentRow.Cells[0].Value.ToString();

            producto.IdProducto = int.Parse(id);

            objNegocio.EliminarProducto(producto);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CountRowsData()
        {
            int numRows = dgvProductos.Rows.Count;

            lblCount.Text = "Registros: " + numRows.ToString();
        }

        private bool Roles()
        {
            bool rpta;
            if (Login.Global.IdRol == 2)
            {
                rpta = true;
            }
            else
            {
                rpta = false;
            }
            return rpta;
        }

        private void dgvProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RegistrarVentas ventas = Owner as RegistrarVentas;
            ventas.txtIdProducto.Text = dgvProductos.CurrentRow.Cells[0].Value.ToString();
            ventas.txtProdcuto.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
            ventas.txtPrecio.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
            Close();
        }
    }
}
