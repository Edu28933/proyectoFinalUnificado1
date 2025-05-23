using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAPA_DATOS;
using CAPADATOS;

namespace CAPA_PRESENTACION
{
    public partial class FrmRutas : Form
    {

        CD_Rutas cD_Rutas = new CD_Rutas();

        public FrmRutas()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                cD_Rutas.MtdAgregarRutas(int.Parse(txtCodigoUsuario.Text), txtNombre.Text, txtOrigen.Text, txtDestino.Text, txtDistancia.Text, txtTipoRuta.Text, cboxEstado.Text);
                MessageBox.Show("La ruta se agregó con éxtio", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarRutas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmRutas_Load(object sender, EventArgs e)
        {
            MtdMostrarRutas();
        }

        public void MtdMostrarRutas()
        {
            CD_Rutas cd_rutas = new CD_Rutas();
            DataTable dtMostrarRutas = cd_rutas.MtdMostrarRutas();
            dgvRutas.DataSource = dtMostrarRutas;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                ///////////////
                cD_Rutas.MtdActualizarRutas(int.Parse(txtCodigoRuta.Text), int.Parse(txtCodigoUsuario.Text), txtNombre.Text, txtOrigen.Text, txtDestino.Text, txtDistancia.Text, txtTipoRuta.Text, cboxEstado.Text);
                MessageBox.Show("La ruta se actualizo con éxtio", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarRutas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MtdLimpiarRutas()
        {
            txtCodigoRuta.Text = "";
            txtCodigoUsuario.Text = "";
            txtNombre.Text = "";
            txtOrigen.Text = "";
            txtDestino.Text = "";
            txtDistancia.Text = "";
            txtTipoRuta.Text = "";
            cboxEstado.Text = "";

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            MtdLimpiarRutas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                cD_Rutas.MtdEliminarRutas(int.Parse(txtCodigoRuta.Text));
                MessageBox.Show("La ruta se eliminó con éxtio", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarRutas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRutas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoRuta.Text = dgvRutas.SelectedCells[0].Value.ToString();
            txtCodigoUsuario.Text = dgvRutas.SelectedCells[1].Value.ToString();
            txtNombre.Text = dgvRutas.SelectedCells[2].Value.ToString();
            txtOrigen.Text = dgvRutas.SelectedCells[3].Value.ToString();
            txtDestino.Text = dgvRutas.SelectedCells[4].Value.ToString();
            txtDistancia.Text = dgvRutas.SelectedCells[5].Value.ToString();
            txtTipoRuta.Text = dgvRutas.SelectedCells[6].Value.ToString();
            cboxEstado.Text = dgvRutas.SelectedCells[7].Value.ToString();
        }

        private void dgvRutas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
