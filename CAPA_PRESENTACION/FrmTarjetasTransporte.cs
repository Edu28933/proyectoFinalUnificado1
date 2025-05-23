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
    public partial class FrmTarjetasTransporte : Form
    {

        CD_TarjetasTransporte cD_TarjetasTransporte = new CD_TarjetasTransporte();

        public FrmTarjetasTransporte()
        {
            InitializeComponent();
        }

        private void FrmTarjetasTransporte_Load(object sender, EventArgs e)
        {
            MtdMostrarTarjetasTransporte();
        }

        public void MtdMostrarTarjetasTransporte()
        {
            CD_TarjetasTransporte cd_tarjetastransporte = new CD_TarjetasTransporte();
            DataTable dtMostrarTarjetasTransporte = cd_tarjetastransporte.MtdMostrarTarjetasTransporte();
            dgvTarjetasTransporte.DataSource = dtMostrarTarjetasTransporte;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                cD_TarjetasTransporte.MtdAgregarTarjetasTransporte(int.Parse(txtCodigoPasajero.Text), DateTime.Parse(txtFechaEmision.Text), decimal.Parse(txtSaldo.Text), txtMoneda.Text, txtTipoTarjeta.Text, cboxEstado.Text);
                MessageBox.Show("La tarjeta de transporte se agregó con éxtio", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarTarjetasTransporte();
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
                cD_TarjetasTransporte.MtdActualizarTarjetasTransporte(int.Parse(txtCodigoTarjeta.Text), int.Parse(txtCodigoPasajero.Text), DateTime.Parse(txtFechaEmision.Text), decimal.Parse(txtSaldo.Text), txtMoneda.Text, txtTipoTarjeta.Text, cboxEstado.Text);
                MessageBox.Show("La tarjeta de transporte se actualizo con éxtio", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarTarjetasTransporte();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            MtdLimpiarTarjetasTransporte();
        }

        public void MtdLimpiarTarjetasTransporte()
        {
            txtCodigoTarjeta.Text = "";
            txtCodigoPasajero.Text = "";
            txtFechaEmision.Text = "";
            txtSaldo.Text = "";
            txtMoneda.Text = "";
            txtTipoTarjeta.Text = "";
            cboxEstado.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                cD_TarjetasTransporte.MtdEliminarTarjetasTransporte(int.Parse(txtCodigoTarjeta.Text));
                MessageBox.Show("La tarjeta de transporte se eliminó con éxtio", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarTarjetasTransporte();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTarjetasTransporte_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoTarjeta.Text = dgvTarjetasTransporte.SelectedCells[0].Value.ToString();
            txtCodigoPasajero.Text = dgvTarjetasTransporte.SelectedCells[1].Value.ToString();
            txtFechaEmision.Text = dgvTarjetasTransporte.SelectedCells[2].Value.ToString();
            txtSaldo.Text = dgvTarjetasTransporte.SelectedCells[3].Value.ToString();
            txtMoneda.Text = dgvTarjetasTransporte.SelectedCells[4].Value.ToString();
            txtTipoTarjeta.Text = dgvTarjetasTransporte.SelectedCells[5].Value.ToString();
            cboxEstado.Text = dgvTarjetasTransporte.SelectedCells[6].Value.ToString();
        }
    }
}
