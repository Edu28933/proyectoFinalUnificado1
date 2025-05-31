using CAPADATOS;
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
            LlenarComboEmpleados();
            cboxCodigoEmpleado.SelectedIndex = -1;
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
                // Manejo del código de usuario: Si el combo tiene un valor seleccionado, lo usa; de lo contrario, toma el del DataGridView
                int CodigoEmpleado;
                if (cboxCodigoEmpleado.SelectedIndex != -1 && cboxCodigoEmpleado.SelectedValue != null)
                {
                    CodigoEmpleado = Convert.ToInt32(cboxCodigoEmpleado.SelectedValue);
                }
                else if (dgvTransportes.SelectedCells.Count > 1) // Si hay datos seleccionados en la DataGridView
                {
                    CodigoEmpleado = int.Parse(dgvTransportes.SelectedCells[1].Value.ToString());
                }
                else
                {
                    MessageBox.Show("Seleccione un empleado válido para el transporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener el resto de los datos

                string Placa = txtPlaca.Text;
                string Marca = txtMarca.Text;
                string Modelo = txtModelo.Text;
                int Año = int.Parse(txtAño.Text);
                decimal Capacidad = decimal.Parse(txtCapacidad.Text);
                string TipoTransporte = txtTipoTransporte.Text;
                string Estado = cboxEstado.Text;
                // Llamada a la clase de datos

                cD_Transportes.MtdAgregarTransportes(CodigoEmpleado, Placa, Marca, Modelo, Año, Capacidad, TipoTransporte, Estado);
                MessageBox.Show("Transporte actualizado con éxito.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarTransportes();
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


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodigoTransporte.Text))
                {
                    MessageBox.Show("Seleccione un transporte para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el código de transporte
                int CodigoTransporte = int.Parse(txtCodigoTransporte.Text);

                // Manejo del código de usuario: Si el combo tiene un valor seleccionado, lo usa; de lo contrario, toma el del DataGridView
                int CodigoEmpleado;
                if (cboxCodigoEmpleado.SelectedIndex != -1 && cboxCodigoEmpleado.SelectedValue != null)
                {
                    CodigoEmpleado = Convert.ToInt32(cboxCodigoEmpleado.SelectedValue);
                }
                else
                {
                    CodigoEmpleado = int.Parse(dgvTransportes.SelectedCells[1].Value.ToString());
                }

                // Verificar que el código de transporte es válido
                if (CodigoEmpleado <= 0)
                {
                    MessageBox.Show("Código de empleado es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string Placa = txtPlaca.Text;
                string Marca = txtMarca.Text;
                string Modelo = txtModelo.Text;
                int Año = int.Parse(txtAño.Text);
                decimal Capacidad = decimal.Parse(txtCapacidad.Text);
                string TipoTransporte = txtTipoTransporte.Text;
                string Estado = cboxEstado.Text;
                // Llamada a la clase de datos

                cD_Transportes.MtdActualizarTransportes(CodigoTransporte, CodigoEmpleado, Placa, Marca, Modelo, Año, Capacidad, TipoTransporte, Estado);
                MessageBox.Show("Ruta actualizado con éxito.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarTransportes();
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
            MtdLimpiarTransportes();
        }

        public void MtdLimpiarTransportes()
        {
            txtCodigoTransporte.Text = "";
            cboxCodigoEmpleado.Text = "";
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
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void dgvTransportes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoTransporte.Text = dgvTransportes.SelectedCells[0].Value.ToString();
            cboxCodigoEmpleado.Text = dgvTransportes.SelectedCells[1].Value.ToString();
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
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                string buscarTransportes= txtBuscar.Text.Trim();


                if (string.IsNullOrEmpty(buscarTransportes))
                {
                    MessageBox.Show("Por favor ingrese un valor de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dtTransportes = cD_Transportes.MtdBuscarTransportes(buscarTransportes);


                if (dtTransportes.Rows.Count > 0)
                {
                    dgvTransportes.DataSource = dtTransportes;
                }
                else
                {
                    MessageBox.Show("No se encontraron Transportes con los datos ingresados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

        private void cboxCodigoEmpleado_DropDown(object sender, EventArgs e)
        {
            LlenarComboEmpleados();
        }

        private void LlenarComboEmpleados()
        {

            DataTable dt = cD_Transportes.ObtenerEmpleadosActivos();

            cboxCodigoEmpleado.DataSource = null; // Limpia
            cboxCodigoEmpleado.DisplayMember = "Display";       // Muestra: "1 - Usuario1"
            cboxCodigoEmpleado.ValueMember = "CodigoEmpleado";   // Internamente: 1
            cboxCodigoEmpleado.DataSource = dt;
            cboxCodigoEmpleado.SelectedIndex = -1; // Que inicie vacío
        }





        private void cboxEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxCodigoEmpleado.SelectedIndex != -1)
            {
                string codigo = cboxCodigoEmpleado.SelectedValue.ToString();
                cboxCodigoEmpleado.Text = codigo; // Muestra solo el código en el ComboBox
            }
        }

    }
}
