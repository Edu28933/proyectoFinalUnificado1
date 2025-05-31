using CAPA_DATOS;
using CAPA_LOGICA;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CAPA_PRESENTACION
{
    public partial class frm04Estadisticas : Form
    {
        public frm04Estadisticas()
        {
            InitializeComponent();
        }


        public void MtdMostrarEstadisticas()
        {

            cd_04Estadisticas cd_04Estadisticas = new cd_04Estadisticas();          

            DataTable dtMostrarEstadisticas = cd_04Estadisticas.MtMostrarEstadisticas();
            dgviewCrudEstdisticas.DataSource = dtMostrarEstadisticas;
        }

        private void frm04Estadisticas_Load(object sender, EventArgs e)
        {
            MtdMostrarEstadisticas();
            dtpFechaReporte.Leave += txtFechaReporte_Leave;

            dtpFechaReporte.ValueChanged += dtpFechaReporte_ValueChanged;
        }


       

        private void dgviewCrudEstdisticas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodEstadistica.Text = dgviewCrudEstdisticas.SelectedCells[0].Value.ToString();
            cboxCodTrans.Text = dgviewCrudEstdisticas.SelectedCells[1].Value.ToString();
            dtpFechaReporte.Text = dgviewCrudEstdisticas.SelectedCells[2].Value.ToString();
            txtIngresoTotal.Text = dgviewCrudEstdisticas.SelectedCells[3].Value.ToString();
            txtPasajerosTrans.Text = dgviewCrudEstdisticas.SelectedCells[4].Value.ToString();
            txtMoneda.Text = dgviewCrudEstdisticas.SelectedCells[5].Value.ToString();
            txtTotalIncidentes.Text = dgviewCrudEstdisticas.SelectedCells[6].Value.ToString();
            cboxEstado.Text = dgviewCrudEstdisticas.SelectedCells[7].Value.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodEstadistica.Clear();
            cboxCodTrans.Text = ""; ;
            dtpFechaReporte.Text = "";
            txtIngresoTotal.Clear();
            txtPasajerosTrans.Clear();
            txtMoneda.Clear();
            txtTotalIncidentes.Clear();
            cboxEstado.Text = "";
            MtdMostrarEstadisticas();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MtdActualizarEstadisticas()
        {
            if (!string.IsNullOrWhiteSpace(cboxCodTrans.Text))
            {
                if (!int.TryParse(cboxCodTrans.Text, out int codigoTransporte))
                {
                    MessageBox.Show("Código de transporte inválido.");
                    return;
                }

                DateTime fecha = dtpFechaReporte.Value;
                cl_04Estadisticas logica = new cl_04Estadisticas();

                DataTable dt = logica.MtdObtenerEstadisticas(codigoTransporte, fecha);

                if (dt.Rows.Count > 0)
                {
                    txtIngresoTotal.Text = dt.Rows[0]["TotalIngresos"].ToString();
                    txtTotalIncidentes.Text = dt.Rows[0]["TotalIncidentes"].ToString();
                    txtMoneda.Text = dt.Rows[0]["MonedaMasUsada"].ToString();
                    txtPasajerosTrans.Text = dt.Rows[0]["TotalPasajeros"].ToString();
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para el código y fecha ingresados.");
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar un código de transporte.");
            }
        }



        private void txtFechaReporte_Leave(object sender, EventArgs e)
        {
            MtdActualizarEstadisticas();
        }
        private void cboxCodigorans_SelectedIndexChanged(object sender, EventArgs e)
        {
            MtdActualizarEstadisticas();
        }

        private void dtpFechaReporte_ValueChanged(object sender, EventArgs e)
        {
            MtdActualizarEstadisticas();
        }
    }
}
