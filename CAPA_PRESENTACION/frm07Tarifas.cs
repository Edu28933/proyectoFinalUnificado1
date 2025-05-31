using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAPADATOS; 

namespace CAPA_PRESENTACION
{
    public partial class frm07Tarifas : Form
    {

        cd_07Tarifas cd_07Tarifas = new cd_07Tarifas();
        public frm07Tarifas()
        {
            InitializeComponent();
        }

        public void LlenarComboTarifas()
        {

            DataTable dt = cd_07Tarifas.ObtenerTarifasActivas();

            cboxRuta.DataSource = null; // Limpia
            cboxRuta.DisplayMember = "Display";       // Muestra: "1 - Usuario1"
            cboxRuta.ValueMember = "CodigoUsuario";   // Internamente: 1
            cboxRuta.DataSource = dt;
            cboxRuta.SelectedIndex = -1; // Que inicie vacío
        }
        public void MtdLimpiar()
        {
            txtcodTarifa.Clear();
            cboxRuta.Text = "";
            txtMonto.Clear();
            txtMoneda.Clear();
            txtFechaVigen.Clear();
            txtFechaVencimiento.Clear();
            cboxEstado.Text = "";


        }
        private void MtdMostrarTarifas()
        {
            DataTable dtMostrarTarifas = cd_07Tarifas.MtdMostrarTarifas();
            dgviewCrudTarifas.DataSource = dtMostrarTarifas;


 
        }
        private void dgviewCrudTarifas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frm07Tarifas_Load(object sender, EventArgs e)
        {
            MtdMostrarTarifas();
            LlenarComboTarifas();
            cboxRuta.SelectedIndex = -1;
        }

      

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                cd_07Tarifas cd_07Tarifas = new cd_07Tarifas();

                string buscarTarifas = txtBuscar.Text.Trim();


                if (string.IsNullOrEmpty(buscarTarifas))
                {
                    MessageBox.Show("Por favor ingrese un valor de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dtTarifas = cd_07Tarifas.MtdBuscarTarifas(buscarTarifas);


                if (dtTarifas.Rows.Count > 0)
                {
                    dgviewCrudTarifas.DataSource = dtTarifas;
                }
                else
                {
                    MessageBox.Show("No se encontraron Tarifas con los datos ingresados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error de SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtcodTarifa.Text))
                {
                    MessageBox.Show("Seleccione una Tarifa para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el código de empleado
                int codigoTarifa = int.Parse(txtcodTarifa.Text);

                // Manejo del código de usuario: Si el combo tiene un valor seleccionado, lo usa; de lo contrario, toma el del DataGridView
                int codigoRuta;
                if (cboxRuta.SelectedIndex != -1 && cboxRuta.SelectedValue != null)
                {
                    codigoRuta = Convert.ToInt32(cboxRuta.SelectedValue);
                }
                else
                {
                    codigoRuta = int.Parse(dgviewCrudTarifas.SelectedCells[1].Value.ToString());
                }

                // Verificar que el código de usuario es válido
                if (codigoRuta <= 0)
                {
                    MessageBox.Show("Código de ruta inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal Monto = Convert.ToDecimal(txtMonto.Text);
                string Moneda = txtMoneda.Text;
                DateTime FechaVigencia = DateTime.Parse(txtFechaVigen.Text);
                DateTime FechaVencimiento = DateTime.Parse(txtFechaVencimiento.Text);
                string Estado = cboxEstado.Text;
                // Llamada a la clase de datos

                cd_07Tarifas.MtdActualizarTarifa(codigoTarifa, codigoRuta, Monto, Moneda, FechaVigencia, FechaVencimiento, Estado);
                MessageBox.Show("Tarifa actualizado con éxito.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarTarifas();
                btnLimpiar_Click(sender, e);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

   

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            MtdLimpiar();
            MtdMostrarTarifas(); 
        }

        private void dgviewCrudTarifas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodTarifa.Text = dgviewCrudTarifas.SelectedCells[0].Value.ToString();
            cboxRuta.Text = dgviewCrudTarifas.SelectedCells[1].Value.ToString();
            txtMonto.Text = dgviewCrudTarifas.SelectedCells[2].Value.ToString();
            txtMoneda.Text = dgviewCrudTarifas.SelectedCells[3].Value.ToString();
            txtFechaVigen.Text = dgviewCrudTarifas.SelectedCells[4].Value.ToString();
            txtFechaVencimiento.Text = dgviewCrudTarifas.SelectedCells[5].Value.ToString();
            cboxEstado.Text = dgviewCrudTarifas.SelectedCells[6].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigoRutas;
                if (cboxRuta.SelectedIndex != -1 && cboxRuta.SelectedValue != null)
                {
                    codigoRutas = Convert.ToInt32(cboxRuta.SelectedValue);
                }
                else if (dgviewCrudTarifas.SelectedCells.Count > 1)
                {
                    codigoRutas = int.Parse(dgviewCrudTarifas.SelectedCells[1].Value.ToString());
                }
                else
                {
                    MessageBox.Show("Seleccione una Tarifa válida para la estación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal Monto = Convert.ToDecimal(txtMonto.Text);
                string Moneda = txtMoneda.Text;
                DateTime FechaVigencia = DateTime.Parse(txtFechaVigen.Text);
                DateTime FechaVencimiento = DateTime.Parse(txtFechaVencimiento.Text);
                string Estado = cboxEstado.Text;

                cd_07Tarifas.MtdAgregarTarifa(codigoRutas, Monto, Moneda, FechaVigencia, FechaVencimiento, Estado);

                MessageBox.Show("Tarifa agregada con éxito.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarTarifas();
                btnLimpiar_Click(sender, e);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                cd_07Tarifas.MtdEliminarTarifa(int.Parse(txtcodTarifa.Text));

                MessageBox.Show("Tarifa eliminada con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarTarifas();
                btnLimpiar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboxRuta_SelectedIndexChanged(object sender, EventArgs e)
        {
            { 
            if (cboxRuta.SelectedIndex != -1)
            {
                string codigo = cboxRuta.SelectedValue.ToString();
                cboxRuta.Text = codigo; // Muestra solo el código en el ComboBox
            }
        }

    }
    }
}
