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
    public partial class RegistroUsuario : Form
    {
        N_Usuarios negocio = new N_Usuarios();
        Login login = new Login();

        public RegistroUsuario()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Hide();
            login.Show();
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            LeaveText(txtNombre, "NOMBRES");
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            EnterText(txtNombre, "NOMBRES");
        }

        private void txtApellidos_Leave(object sender, EventArgs e)
        {
            LeaveText(txtApellidos, "APELLIDOS");
        }

        private void txtApellidos_Enter(object sender, EventArgs e)
        {
            EnterText(txtApellidos, "APELLIDOS");
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            LeaveText(txtUsuario, "USUARIO");
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            EnterText(txtUsuario, "USUARIO");
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "CONTRASEÑA";
                txtPassword.ForeColor = Color.DimGray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "CONTRASEÑA")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.LightGray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void txtRepite_Leave(object sender, EventArgs e)
        {
            if (txtRepite.Text == "")
            {
                txtRepite.Text = "REPITA CONTRASEÑA";
                txtRepite.ForeColor = Color.DimGray;
                txtRepite.UseSystemPasswordChar = false;
            }
        }

        private void txtRepite_Enter(object sender, EventArgs e)
        {
            if (txtRepite.Text == "REPITA CONTRASEÑA")
            {
                txtRepite.Text = "";
                txtRepite.ForeColor = Color.LightGray;
                txtRepite.UseSystemPasswordChar = false;
            }
        }

        private void LeaveText(TextBox textBox, string variable)
        {
            if (textBox.Text == "")
            {
                textBox.Text = variable;
                textBox.ForeColor = Color.DimGray;
            }
        }

        private void EnterText(TextBox textBox, string variable)
        {
            if (textBox.Text == variable)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.LightGray;
            }
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "NOMBRES" || txtApellidos.Text == "APELLIDOS" || txtUsuario.Text == "USUARIO" || txtPassword.Text == "CONTRASEÑA" || txtRepite.Text == "REPITA CONTRASEÑA")
                MessageBox.Show("Debe rellenar todos los campos.", "Campos Vacios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if(txtPassword.Text == txtRepite.Text)
                {
                    Registrar();
                    MessageBox.Show("Se usuario se registro correctamente.", "Registro Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Agregar();
                    Hide();
                    login.Show();

                }
                else
                {
                    MessageBox.Show("Las contreñas no coinciden.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Registrar()
        {
            E_Usuarios usuarios = new E_Usuarios();

            usuarios.Nombres = txtNombre.Text;
            usuarios.Apellidos = txtApellidos.Text;
            usuarios.Usuario = txtUsuario.Text;
            usuarios.Contrasenia = txtPassword.Text;

            negocio.RegistrarUsuarios(usuarios);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void txtRepite_TextChanged(object sender, EventArgs e)
        {
            txtRepite.UseSystemPasswordChar = true;
        }
    }
}
