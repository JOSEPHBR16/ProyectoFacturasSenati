using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Login : Form
    {
        N_Usuarios n_Usuarios = new N_Usuarios();
        E_Usuarios entidad = new E_Usuarios();

        public static class Global
        {
            public static int IdUsuario;
            public static string Usuario;
            public static int IdRol;
            public static string Rol;
        }

        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        #region Dlls para poder hacer el movimiento del Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion

        #region Esquinas ovaladas
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        #endregion

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
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

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "CONTRASEÑA";
                txtPassword.ForeColor = Color.DimGray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            entidad.Usuario = txtUsuario.Text;
            entidad.Contrasenia = txtPassword.Text;

            dt = n_Usuarios.LoginUser(entidad);

            if(dt.Rows.Count > 0)
            {
                var usuarioLogin = dt.Rows[0][1].ToString() + " " + dt.Rows[0][2].ToString();
                var rol = dt.Rows[0][6].ToString();
                var idrol = int.Parse(dt.Rows[0][5].ToString());
                Global.Usuario = usuarioLogin;
                Global.Rol = rol;
                Global.IdRol = idrol;

                Global.IdUsuario = entidad.IdUsuario = int.Parse(dt.Rows[0][0].ToString());
                entidad.Nombres = dt.Rows[0][1].ToString();
                entidad.Apellidos = dt.Rows[0][2].ToString();
                entidad.Usuario = dt.Rows[0][3].ToString();
                entidad.Contrasenia = dt.Rows[0][4].ToString();
                entidad.IdRol = int.Parse(dt.Rows[0][5].ToString());
                entidad.Rol = dt.Rows[0][6].ToString();

                MessageBox.Show($"Bienevido al sistema.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Principal principal = new Principal();
                Hide();
                principal.WindowState = FormWindowState.Maximized;
                principal.Show();
            }
            else
            {
                MessageBox.Show("Usuario / Contraseña incorrectos.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
