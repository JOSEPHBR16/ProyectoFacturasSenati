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
    public partial class RegistrarVentas : Form
    {
        private DataTable Detalle;
        private decimal montoBase;
        private decimal igv;
        private decimal montoTotal;

        readonly E_Ventas ObjEntidad = new E_Ventas();
        readonly E_Usuarios usuario = new E_Usuarios();
        readonly N_Ventas Objnegocio = new N_Ventas();


        public RegistrarVentas(Ventas ventas)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            CrearTabla();
            CountRowsData();
            BloquearProducto();
            BloquearCliente();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Producto pro = new Producto();
            AddOwnedForm(pro);
            pro.ShowDialog();
            txtCantidad.Focus();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (txtIdProducto.Text == "" || txtPrecio.Text == "" || txtProdcuto.Text == "")
            {
                MessageBox.Show("Debe buscar un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAñadir.Focus();
            }
            else
            {
                if (txtCantidad.Text == "")
                {
                    MessageBox.Show("Debe rellenar el campo Cantidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCantidad.Focus();
                }
                else
                {
                    DataRow row = Detalle.NewRow();
                    row["IdProducto"] = Convert.ToInt32(txtIdProducto.Text);
                    row["Nombre"] = txtProdcuto.Text;
                    row["Precio"] = Convert.ToDecimal(txtPrecio.Text);
                    row["Cantidad"] = Convert.ToInt32(txtCantidad.Text);

                    montoBase += (Convert.ToDecimal(row["Precio"]) * Convert.ToDecimal(txtCantidad.Text));
                    txtMontoBase.Text = montoBase.ToString("#0.0#");

                    igv = montoBase * Convert.ToDecimal(0.18);
                    txtIGV.Text = igv.ToString("#0.0#");

                    montoTotal = montoBase + igv;
                    txtMontoTotal.Text = montoTotal.ToString("#0.0#");

                    Detalle.Rows.Add(row);
                    CountRowsData();
                    Limpiar();
                }
            }
         }

        public void CrearTabla()
        {
            Detalle = new DataTable();
            Detalle.Columns.Add("IdProducto", Type.GetType("System.Int32"));
            Detalle.Columns.Add("Nombre", Type.GetType("System.String"));
            Detalle.Columns.Add("Precio", Type.GetType("System.Decimal"));
            Detalle.Columns.Add("Cantidad", Type.GetType("System.Int32"));

            dgvVentas.DataSource = Detalle;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvVentas.Rows.Count == 0)
                {
                    MessageBox.Show("No hay nada para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int indiceFila = dgvVentas.CurrentCell.RowIndex;
                    DataRow row = Detalle.Rows[indiceFila];

                    montoBase -= (Convert.ToDecimal(row["Precio"]) * Convert.ToDecimal(row["Cantidad"]));
                    txtMontoBase.Text = montoBase.ToString("#0.0#");

                    igv = montoBase * Convert.ToDecimal(0.18);
                    txtIGV.Text = igv.ToString("#0.0#");

                    montoTotal = montoBase + igv;
                    txtMontoTotal.Text = montoTotal.ToString("#0.0#");

                    Detalle.Rows.Remove(row);
                    MessageBox.Show("Se removio el producto.", "Producto Removido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CountRowsData();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void CountRowsData()
        {
            int numRows = dgvVentas.Rows.Count;

            lblCount.Text = "Registros: " + numRows.ToString();
        }

        private void Limpiar()
        {
            txtIdProducto.Text = "";
            txtProdcuto.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
        }

        private void BloquearProducto()
        {
            txtIdProducto.ReadOnly = true;
            txtProdcuto.ReadOnly = true;
            txtPrecio.ReadOnly = true;
        }

        private void BloquearCliente()
        {
            txtCliente.ReadOnly = true;
            txtDireccion.ReadOnly = true;
            txtTelefono.ReadOnly = true;
            txtCorreo.ReadOnly = true;
        }

        private void txtBuscarCliente_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            AddOwnedForm(cliente);
            cliente.ShowDialog();
        }

        private void btnGuardarRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCliente.Text == "" || txtDireccion.Text == "" || txtCorreo.Text == "" || txtTelefono.Text == "")
                {
                    MessageBox.Show("La informacion del cliente debe estar llena.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (dgvVentas.Rows.Count == 0)
                    {
                        MessageBox.Show("Debe añadir al menos un producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        ObjEntidad.IdCliente = Convert.ToInt32(lblIdCliente.Text);
                        ObjEntidad.IdUsuario = Login.Global.IdUsuario;
                        ObjEntidad.MontoBase = Convert.ToDecimal(txtMontoBase.Text/*, CultureInfo.InvariantCulture*/);
                        ObjEntidad.Igv = Convert.ToDecimal(txtIGV.Text/*, CultureInfo.InvariantCulture*/);
                        ObjEntidad.MontoTotal = Convert.ToDecimal(txtMontoTotal.Text/*, CultureInfo.InvariantCulture*/);

                        N_Ventas.InsertarVentas(ObjEntidad, Detalle);

                        MessageBox.Show("Se registro su venta", "Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarTodo();
                        Agregar();
                        Close();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        private void LimpiarTodo()
        {
            txtCliente.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtIdProducto.Text = "";
            txtPrecio.Text = "";
            txtProdcuto.Text = "";
            txtCantidad.Text = "";
            txtMontoBase.Text = "";
            txtIGV.Text = "";
            txtMontoTotal.Text = "";
            LimpiarDataGrid();
        }

        private void LimpiarDataGrid()
        {
            dgvVentas.DataSource = null;
            dgvVentas.Columns.Clear();
            CrearTabla();
            CountRowsData();
        }
    }
}
