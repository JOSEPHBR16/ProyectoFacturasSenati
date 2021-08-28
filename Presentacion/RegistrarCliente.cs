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
    public partial class RegistrarCliente : Form
    {
        N_Clientes objNegocio = new N_Clientes();

        public RegistrarCliente(Clientes clientes)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text == "" || txtDireccion.Text == "" || txtCorreo.Text == "" || txtTelefono.Text == "")
                MessageBox.Show("Debe rellenar todos los campos.", "Campos Vacios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                Registrar();
                MessageBox.Show("Se inserto correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Agregar();
                this.Close();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registrar()
        {
            E_Clientes clientes = new E_Clientes();

            clientes.Nombre = txtNombre.Text;
            clientes.Direccion = txtDireccion.Text;
            clientes.Correo = txtCorreo.Text;
            clientes.Telefono = txtTelefono.Text;

            objNegocio.RegistrarCliente(clientes);
        }

        private void Limpiar()
        {
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
        }

        
    }
}
