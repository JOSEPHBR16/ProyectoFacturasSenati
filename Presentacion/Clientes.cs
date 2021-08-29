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
using static Presentacion.Login;

namespace Presentacion
{
    public partial class Clientes : Form
    {
        N_Clientes objNegocio = new N_Clientes();

        public Clientes()
        {
            InitializeComponent();
        }
        private void Clientes_Load(object sender, EventArgs e)
        {
            //Roles();
            MostrarClientes();
            CountRowsData();
        }

        public void MostrarClientes()
        {
            dgvClientes.DataSource = objNegocio.ListadoClientes();
        }

        private void dgvClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RegistrarVentas ventas = Owner as RegistrarVentas;
            ventas.lblIdCliente.Text = dgvClientes.CurrentRow.Cells[0].Value.ToString();
            ventas.txtCliente.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
            ventas.txtDireccion.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
            ventas.txtCorreo.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
            ventas.txtTelefono.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();
            Close();
        }

        private void CountRowsData()
        {
            int numRows = dgvClientes.Rows.Count;

            lblCount.Text = "Registros: " + numRows.ToString();
        }

        private void AgPrd_UpdateEventHandlerI(object sender, RegistrarCliente.UpdateEventArgs args)
        {
            MostrarClientes();
            CountRowsData();
        }

        private void AgPrd_UpdateEventHandlerE(object sender, EditarCliente.UpdateEventArgs args)
        {
            MostrarClientes();
            CountRowsData();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            bool rpta = Roles();

            if (rpta == true)
                MessageBox.Show("No tiene permisos de administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                RegistrarCliente registrarCliente = new RegistrarCliente(this);
                AddOwnedForm(registrarCliente);
                registrarCliente.UpdateEventHandler += AgPrd_UpdateEventHandlerI;
                registrarCliente.ShowDialog();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            bool rpta = Roles();

            if (rpta == true)
                MessageBox.Show("No tiene permisos de administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                EditarCliente editarCliente = new EditarCliente(this);
                AddOwnedForm(editarCliente);
                editarCliente.UpdateEventHandler += AgPrd_UpdateEventHandlerE;
                editarCliente.lblIdCliente.Text = dgvClientes.CurrentRow.Cells[0].Value.ToString();
                editarCliente.txtNombre.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                editarCliente.txtDireccion.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                editarCliente.txtCorreo.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
                editarCliente.txtTelefono.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();
                editarCliente.ShowDialog();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool rpta = Roles();

            if(rpta == true)
                MessageBox.Show("No tiene permisos de administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DialogResult rs;
                rs = MessageBox.Show("Desea eliminar el registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    Eliminar();
                    MessageBox.Show("Registro eliminado con exito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarClientes();
                    CountRowsData();
                }
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Eliminar()
        {
            E_Clientes clientes = new E_Clientes();

            var id = dgvClientes.CurrentRow.Cells[0].Value.ToString();

            clientes.IdCLiente = int.Parse(id);

            objNegocio.EliminarCliente(clientes);
        }

        private bool Roles()
        {
            bool rpta;
            if (Global.IdRol == 2)
            {
                rpta = true;
                
                //btnNuevo.Enabled = false;
                //btnEditar.Enabled = false;
                //btnEliminar.Enabled = false;
            }
            else
            {
                rpta = false;
            }
            return rpta;
        }
    }
}
