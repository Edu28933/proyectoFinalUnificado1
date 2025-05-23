using CAPADATOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAPA_PRESENTACION
{
    public partial class FrmTransportes : Form
    {
        CD_Transportes cD_Transportes = new CD_Transportes();

        public FrmTransportes()
        {
            InitializeComponent();
        }

        private void FrmTransportes_Load(object sender, EventArgs e)
        {
            MtdMostrarTransportes();
        }

        public void MtdMostrarTransportes()
        {
            CD_Transportes cd_transportes = new CD_Transportes();
            DataTable dtMostrarTransportes = cd_transportes.MtdMostrarTransportes();
            dgvTransportes.DataSource = dtMostrarTransportes;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                cD_Transportes.MtdAgregarTransportes(int.Parse(txtCodigoEmpleado.Text), txtPlaca.Text, txtMarca.Text, txtModelo.Text, DateTime.Parse(txtAño.Text), int.Parse(txtCapacidad.Text), txtCodigoTransporte.Text, cboxEstado.Text);
                MessageBox.Show("El transporte se agregó con éxtio", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarTransportes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                ///////////////
                cD_Transportes.MtdActualizarTransportes(int.Parse(txtCodigoTransporte.Text), int.Parse(txtCodigoEmpleado.Text), txtPlaca.Text, txtMarca.Text, txtModelo.Text, DateTime.Parse(txtAño.Text), int.Parse(txtCapacidad.Text), txtCodigoTransporte.Text, cboxEstado.Text);
                MessageBox.Show("La ruta se actualizo con éxtio", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarTransportes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            MtdLimpiarTransportes();
        }

        public void MtdLimpiarTransportes()
        {
            txtCodigoTransporte.Text = "";
            txtCodigoEmpleado.Text = "";
            txtPlaca.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtAño.Text = "";
            txtCapacidad.Text = "";
            txtTipoTransporte.Text = "";
            cboxEstado.Text = "";

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                cD_Transportes.MtdEliminarTransportes(int.Parse(txtCodigoTransporte.Text));
                MessageBox.Show("El transporte se eliminó con éxtio", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarTransportes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTransportes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoTransporte.Text = dgvTransportes.SelectedCells[0].Value.ToString();
            txtCodigoEmpleado.Text = dgvTransportes.SelectedCells[1].Value.ToString();
            txtPlaca.Text = dgvTransportes.SelectedCells[2].Value.ToString();
            txtMarca.Text = dgvTransportes.SelectedCells[3].Value.ToString();
            txtModelo.Text = dgvTransportes.SelectedCells[4].Value.ToString();
            txtAño.Text = dgvTransportes.SelectedCells[5].Value.ToString();
            txtCapacidad.Text = dgvTransportes.SelectedCells[6].Value.ToString();
            txtTipoTransporte.Text = dgvTransportes.SelectedCells[7].Value.ToString();
            cboxEstado.Text = dgvTransportes.SelectedCells[8].Value.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }
    }
}
