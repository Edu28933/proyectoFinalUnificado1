using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAPADATOS; 
namespace CAPA_PRESENTACION
{



    public partial class frm09Mantenimientos : Form

 
    { 

        cd_09Mantenimientos cd_09Mantenimientos = new cd_09Mantenimientos();


        private void MtdMostrarMantenimientos()
        {
            DataTable dtMostrarMatenimietos = cd_09Mantenimientos.MtdMostrarMantenimientos();
            dgviewCrudMantenimientos.DataSource = dtMostrarMatenimietos;



        }
        public frm09Mantenimientos()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }


        public void LlenarComboTransportes2()
        {
            DataTable dt = cd_09Mantenimientos.ObtenerTransportes();

            cboxCodigoTransporte.DataSource = dt;
            cboxCodigoTransporte.DisplayMember = "Display";
            cboxCodigoTransporte.ValueMember = "CodigoTransporte";
            cboxCodigoTransporte.SelectedIndex = -1;
        }

        private void frm09Mantenimientos_Load(object sender, EventArgs e)
        {
            MtdMostrarMantenimientos();
            LlenarComboTransportes2();
            cboxCodigoTransporte.SelectedIndex = -1;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigoTransporte;
                if (cboxCodigoTransporte.SelectedIndex != -1 && cboxCodigoTransporte.SelectedValue != null)
                {
                    codigoTransporte = Convert.ToInt32(cboxCodigoTransporte.SelectedValue);
                }
                else if (dgviewCrudMantenimientos.SelectedCells.Count > 1)
                {
                    codigoTransporte = int.Parse(dgviewCrudMantenimientos.SelectedCells[1].Value.ToString());
                }
                else
                {
                    MessageBox.Show("Seleccione un Transporte para un mantenimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

              
                DateTime FechaIngreso = DateTime.Parse(txtFechaIngreso.Text);
                DateTime FechaSalida = DateTime.Parse(txtFechaSalida.Text);
                decimal Costo = Convert.ToDecimal(txtCosto.Text); 
                string Moneda = txtMoneda.Text;
                string Estado = cboxEstado.Text; 
                string TipoServicio = cboxTipoServicio.Text; 

                cd_09Mantenimientos.MtdAgregarMantenimiento(codigoTransporte, FechaIngreso, FechaSalida, Costo, Moneda, Estado, TipoServicio);


                MessageBox.Show("Mantenimiento agregada con éxito.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarMantenimientos();
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

        private void cboxCodigoTransporte_SelectedIndexChanged(object sender, EventArgs e)   
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtcodMantenimiento.Clear();
            cboxCodigoTransporte.Text = ""; 
            txtFechaIngreso.Clear();
            txtFechaSalida.Clear();  
            txtCosto.Clear();
            txtMoneda.Clear();
            cboxEstado.Text = "";
            cboxTipoServicio.Text = "";

        }

        private void dgviewCrudMantenimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodMantenimiento.Text = dgviewCrudMantenimientos.SelectedCells[0].Value.ToString();
            cboxCodigoTransporte.Text = dgviewCrudMantenimientos.SelectedCells[1].Value.ToString();
            txtFechaIngreso.Text = dgviewCrudMantenimientos.SelectedCells[2].Value.ToString();
            txtFechaSalida.Text = dgviewCrudMantenimientos.SelectedCells[3].Value.ToString();
            txtCosto.Text = dgviewCrudMantenimientos.SelectedCells[4].Value.ToString();
            txtMoneda.Text = dgviewCrudMantenimientos.SelectedCells[5].Value.ToString();
            cboxTipoServicio.Text = dgviewCrudMantenimientos.SelectedCells[7].Value.ToString();
            cboxEstado.Text = dgviewCrudMantenimientos.SelectedCells[6].Value.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que se haya seleccionado un mantenimiento
                if (string.IsNullOrWhiteSpace(txtcodMantenimiento.Text))
                {
                    MessageBox.Show("Seleccione un mantenimiento para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Convertir el código de mantenimiento
                if (!int.TryParse(txtcodMantenimiento.Text, out int codigoMantenimiento))
                {
                    MessageBox.Show("Código de mantenimiento inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener el código de transporte desde el combo o desde el DataGridView
                int codigoTransporte;
                if (cboxCodigoTransporte.SelectedIndex != -1 && cboxCodigoTransporte.SelectedValue != null)
                {
                    codigoTransporte = Convert.ToInt32(cboxCodigoTransporte.SelectedValue);
                }
                else if (dgviewCrudMantenimientos.SelectedCells.Count > 1)
                {
                    if (!int.TryParse(dgviewCrudMantenimientos.SelectedCells[1].Value.ToString(), out codigoTransporte))
                    {
                        MessageBox.Show("Código de transporte inválido en la tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un transporte válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Parsear y validar los demás campos
                if (!DateTime.TryParse(txtFechaIngreso.Text, out DateTime fechaIngreso))
                {
                    MessageBox.Show("Fecha de ingreso inválida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!DateTime.TryParse(txtFechaSalida.Text, out DateTime fechaSalida))
                {
                    MessageBox.Show("Fecha de salida inválida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txtCosto.Text, out decimal costo))
                {
                    MessageBox.Show("Costo inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string moneda = txtMoneda.Text.Trim();
                string estado = cboxEstado.Text.Trim();
                string tipoServicio = cboxTipoServicio.Text.Trim();

                // Llamada al método de actualización
                cd_09Mantenimientos.MtdEditarMantenimiento(codigoMantenimiento, codigoTransporte, fechaIngreso, fechaSalida, costo, moneda, estado, tipoServicio);

                MessageBox.Show("Mantenimiento actualizado con éxito.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refrescar y limpiar
                MtdMostrarMantenimientos();
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

                cd_09Mantenimientos.MtdEliminarMantenimiento(int.Parse(txtcodMantenimiento.Text));

                MessageBox.Show("Mantenimiento eliminado con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarMantenimientos();
                btnLimpiar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                cd_09Mantenimientos cd_09Mantenimientos = new cd_09Mantenimientos();

                string buscarMatenimientos = txtBuscar.Text.Trim();


                if (string.IsNullOrEmpty(buscarMatenimientos))
                {
                    MessageBox.Show("Por favor ingrese un valor de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dtMantenimientos = cd_09Mantenimientos.MtdBuscarMantenimientos(buscarMatenimientos);


                if (dtMantenimientos.Rows.Count > 0)
                {
                    dgviewCrudMantenimientos.DataSource = dtMantenimientos;
                }
                else
                {
                    MessageBox.Show("No se encontraron Mantenimientos con los datos ingresados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
