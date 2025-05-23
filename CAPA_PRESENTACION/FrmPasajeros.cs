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
    public partial class FrmPasajeros : Form
    {
        CD_Pasajeros cD_Pasajeros = new CD_Pasajeros();

        public FrmPasajeros()
        {
            InitializeComponent();
        }
        ////
        private void FrmPasajeros_Load(object sender, EventArgs e)
        {
            MtdMostrarPasajeros();
        }

        public void MtdMostrarPasajeros()
        {
            CD_Pasajeros cd_pasajeros = new CD_Pasajeros();
            DataTable dtMostrarPasajeros = cd_pasajeros.MtdMostrarPasajeros();
            dgvPasajeros.DataSource = dtMostrarPasajeros;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                cD_Pasajeros.MtdAgregarPasajeros(txtNombre.Text, int.Parse(txtDpi.Text), int.Parse(txtNit.Text), int.Parse(txtTelefono.Text), cboxEstado.Text);
                MessageBox.Show("El pasajero se agregó con éxtio", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarPasajeros();
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
                cD_Pasajeros.MtdActualizarPasajeros(int.Parse(txtCodigoPasajero.Text), txtNombre.Text, int.Parse(txtDpi.Text), int.Parse(txtNit.Text), int.Parse(txtTelefono.Text), cboxEstado.Text);
                MessageBox.Show("El pasajero se actualizo con éxtio", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarPasajeros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            MtdLimpiarPasajeros();
        }

        public void MtdLimpiarPasajeros()
        {
            txtCodigoPasajero.Text = "";
            txtNombre.Text = "";
            txtDpi.Text = "";
            txtNit.Text = "";
            txtTelefono.Text = "";
            cboxEstado.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                cD_Pasajeros.MtdEliminarPasajeros(int.Parse(txtCodigoPasajero.Text));
                MessageBox.Show("El pasajero se eliminó con éxtio", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarPasajeros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPasajeros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoPasajero.Text = dgvPasajeros.SelectedCells[0].Value.ToString();
            txtNombre.Text = dgvPasajeros.SelectedCells[1].Value.ToString();
            txtDpi.Text = dgvPasajeros.SelectedCells[2].Value.ToString();
            txtNit.Text = dgvPasajeros.SelectedCells[3].Value.ToString();
            txtTelefono.Text = dgvPasajeros.SelectedCells[4].Value.ToString();
            cboxEstado.Text = dgvPasajeros.SelectedCells[5].Value.ToString();
        }
    }
}
