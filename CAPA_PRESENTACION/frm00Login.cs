using CAPA_DATOS;
using CAPA_SEGURIDAD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CAPA_SEGURIDAD.cs_00Login;

namespace CAPA_PRESENTACION
{
    public partial class frm00Login : Form
    {
        private cd_00Login loginData;

        public frm00Login()
        {
            InitializeComponent();
            loginData = new cd_00Login();

            txtUsuario.KeyDown += new KeyEventHandler(txtUsuario_KeyDown);
            txtContraseña.KeyDown += new KeyEventHandler(txtContraseña_KeyDown);
        }
        private void frm00Login_Load(object sender, EventArgs e)
        {
        }


        private void btnIniciar_Click_1(object sender, EventArgs e)
        {
            string vUsuario = txtUsuario.Text;
            string vClave = txtContraseña.Text;

            // Autenticar usuario y obtener nombre
            string nombreUsuario = UsuarioAutenticacion.mtdValidacion(vUsuario, vClave);

            if (!string.IsNullOrEmpty(nombreUsuario))
            {
                

                
                MessageBox.Show("Bienvenido, " + nombreUsuario + "!");

                // Sirve para pasar el usuario y el nombre al menú principal
                frm01MenuPrincipal mainMenu = new frm01MenuPrincipal(nombreUsuario);
                mainMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña inválidos.");
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnIniciar.PerformClick();
                e.SuppressKeyPress = true; // Evitar el sonido de "ding" al presionar Enter
            }
        }

        private void txtContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnIniciar.PerformClick();
                e.SuppressKeyPress = true; // Evitar el sonido de "ding" al presionar Enter
            }
        }

        public string mtdlblUsuario()
        {
            return txtUsuario.Text;
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
