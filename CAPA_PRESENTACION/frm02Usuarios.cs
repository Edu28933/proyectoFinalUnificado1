using CAPA_DATOS;
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

namespace CAPA_PRESENTACION
{
    public partial class frm02Usuarios : Form
    {
        public frm02Usuarios()
        {
            InitializeComponent();

            cd_02Usuarios cd_02Usuarios = new cd_02Usuarios();
        }

        public void MtdMostrarUsuarios()
        {
            cd_02Usuarios cd_02Usuarios = new cd_02Usuarios();
            DataTable dtMostrarUsuarios = cd_02Usuarios.MtMostrarUsuarios();
            dgviewCrudUsuarios.DataSource = dtMostrarUsuarios;
        }


        public void mtdLimpieza()
        {
            txtcodUsuario.Clear();
            txtUsuario.Clear();
            txtContraseña.Clear();
            cboxEstado.Text = "";
        }



        private void frm02Usuarios_Load(object sender, EventArgs e)
        {
            MtdMostrarUsuarios();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                cd_02Usuarios cd_02Usuarios = new cd_02Usuarios();
                cd_02Usuarios.MtdEliminarUsuario(int.Parse(txtcodUsuario.Text));
                MessageBox.Show("El usuario se eliminó con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtdLimpieza();
                MtdMostrarUsuarios();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        



        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            MtdMostrarUsuarios();
            mtdLimpieza();
        }



       

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            cd_02Usuarios cd_02Usuarios = new cd_02Usuarios();

            try
            {
                cd_02Usuarios.MtdAgregarUsuario(
                    txtUsuario.Text,
                    txtContraseña.Text,
                    cboxEstado.Text
                );

                MessageBox.Show("El usuario se agregó con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtdLimpieza();
                MtdMostrarUsuarios();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                cd_02Usuarios cd_02Usuarios = new cd_02Usuarios();

                cd_02Usuarios.MtdActualizarUsuario(
                    int.Parse(txtcodUsuario.Text),
                    txtUsuario.Text,
                    txtContraseña.Text,
                    cboxEstado.Text
                );

                MessageBox.Show("El usuario se actualizó con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtdLimpieza();
                MtdMostrarUsuarios();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgviewCrudUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodUsuario.Text = dgviewCrudUsuarios.SelectedCells[0].Value.ToString();
            txtUsuario.Text = dgviewCrudUsuarios.SelectedCells[1].Value.ToString();
            txtContraseña.Text = dgviewCrudUsuarios.SelectedCells[2].Value.ToString();
            cboxEstado.Text = dgviewCrudUsuarios.SelectedCells[3].Value.ToString();
        }

        private void dgviewCrudUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
