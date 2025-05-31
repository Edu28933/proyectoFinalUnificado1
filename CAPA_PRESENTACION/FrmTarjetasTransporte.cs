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
using System.Data.SqlClient;
using CAPA_DATOS;


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
            LlenarComboTransportes();
            cboxCodigoPasajero.SelectedIndex = -1;
        }

        public void MtdMostrarTarjetasTransporte()
        {
            CD_TarjetasTransporte cd_tarjetastransporte = new CD_TarjetasTransporte();
            DataTable dtMostrarTarjetasTransporte = cd_tarjetastransporte.MtdMostrarTarjetasTransporte();
            dgvTarjetasTransporte.DataSource = dtMostrarTarjetasTransporte;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            /*try
            {
                // Manejo del código de usuario: Si el combo tiene un valor seleccionado, lo usa; de lo contrario, toma el del DataGridView
                int CodigoPasajero;
                if (cboxCodigoPasajero.SelectedIndex != -1 && cboxCodigoPasajero.SelectedValue != null)
                {
                    CodigoPasajero = Convert.ToInt32(cboxCodigoPasajero.SelectedValue);
                }
                else if (dgvTarjetasTransporte.SelectedCells.Count > 1) // Si hay datos seleccionados en la DataGridView
                {
                    CodigoPasajero = int.Parse(dgvTarjetasTransporte.SelectedCells[1].Value.ToString());
                }
                else
                {
                    MessageBox.Show("Seleccione un pasajero válido para la tarjeta de transporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener el resto de los datos

                //DateTime FechaEmision = DateTime.Parse(txtFechaEmision.Text);
                TimeSpan FechaEmision = DateTime.Parse(txtFechaEmision.Text).TimeOfDay;
                Decimal Saldo = Decimal.Parse(txtSaldo.Text);
                string Moneda = txtMoneda.Text;
                string TipoTarjeta = cboxTipoTarjeta.Text;
                string Estado = cboxEstado.Text;
                // Llamada a la clase de datos

                cD_TarjetasTransporte.MtdAgregarTarjetasTransporte(CodigoPasajero, FechaEmision, Saldo, Moneda, TipoTarjeta, Estado);
                MessageBox.Show("Tarjeta de transporte agregada con éxito.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarTarjetasTransporte();
                btnLimpiar_Click(sender, e);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

            try
            {
                // Manejo del código de usuario: Si el combo tiene un valor seleccionado, lo usa; de lo contrario, toma el del DataGridView
                int CodigoPasajero;
                if (cboxCodigoPasajero.SelectedIndex != -1 && cboxCodigoPasajero.SelectedValue != null)
                {
                    CodigoPasajero = Convert.ToInt32(cboxCodigoPasajero.SelectedValue);
                }
                else if (dgvTarjetasTransporte.SelectedCells.Count > 1) // Si hay datos seleccionados en la DataGridView
                {
                    CodigoPasajero = int.Parse(dgvTarjetasTransporte.SelectedCells[1].Value.ToString());
                }
                else
                {
                    MessageBox.Show("Seleccione un transporte válido para la ruta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener el resto de los datos

                DateTime FechaEmision = DateTime.Parse(txtFechaEmision.Text);
                if (!decimal.TryParse(txtSaldo.Text, out decimal Saldo))
                {
                    MessageBox.Show("El saldo debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string Moneda = txtMoneda.Text;
                string TipoTarjeta = cboxTipoTarjeta.Text;
                string Estado = cboxEstado.Text;
                // Llamada a la clase de datos

                cD_TarjetasTransporte.MtdAgregarTarjetasTransporte(CodigoPasajero, FechaEmision, Saldo, Moneda, TipoTarjeta, Estado);
                MessageBox.Show("Tarjetas transporte agregadas con éxito.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarTarjetasTransporte();
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

                if (string.IsNullOrEmpty(txtCodigoTarjeta.Text))
                {
                    MessageBox.Show("Seleccione una tarjeta de transporte para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el código de ruta
                int CodigoTarjeta = int.Parse(txtCodigoTarjeta.Text);

                // Manejo del código de usuario: Si el combo tiene un valor seleccionado, lo usa; de lo contrario, toma el del DataGridView
                int CodigoPasajero;
                if (cboxCodigoPasajero.SelectedIndex != -1 && cboxCodigoPasajero.SelectedValue != null)
                {
                    CodigoPasajero = Convert.ToInt32(cboxCodigoPasajero.SelectedValue);
                }
                else
                {
                    CodigoPasajero = int.Parse(dgvTarjetasTransporte.SelectedCells[1].Value.ToString());
                }

                // Verificar que el código de transporte es válido
                if (CodigoPasajero <= 0)
                {
                    MessageBox.Show("Código de transporte inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!DateTime.TryParse(txtFechaEmision.Text, out DateTime FechaEmision))
                {
                    MessageBox.Show("Fecha de emisión inválida. Debe tener un formato de fecha válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar el saldo
                if (!decimal.TryParse(txtSaldo.Text, out decimal Saldo))
                {
                    MessageBox.Show("Saldo inválido. Debe ser un número decimal válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar que el campo de moneda no esté vacío
                string Moneda = txtMoneda.Text;
                if (string.IsNullOrWhiteSpace(Moneda))
                {
                    MessageBox.Show("La moneda no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar que el campo tipo de tarjeta no esté vacío
                string TipoTarjeta = cboxTipoTarjeta.Text;
                if (string.IsNullOrWhiteSpace(TipoTarjeta))
                {
                    MessageBox.Show("El tipo de tarjeta no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar que el campo estado no esté vacío
                string Estado = cboxEstado.Text;
                if (string.IsNullOrWhiteSpace(Estado))
                {
                    MessageBox.Show("El estado no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Llamar al método para actualizar
                cD_TarjetasTransporte.MtdActualizarTarjetasTransporte(
                    CodigoTarjeta, CodigoPasajero, FechaEmision, Saldo, Moneda, TipoTarjeta, Estado);

                // Notificar éxito y refrescar la interfaz
                MessageBox.Show("Tarjeta de transporte actualizada con éxito.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarTarjetasTransporte();
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
            MtdLimpiarTarjetasTransporte();
        }

        public void MtdLimpiarTarjetasTransporte()
        {
            txtCodigoTarjeta.Text = "";
            cboxCodigoPasajero.Text = "";
            txtFechaEmision.Text = "";
            txtSaldo.Text = "";
            txtMoneda.Text = "";
            cboxTipoTarjeta.Text = "";
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
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTarjetasTransporte_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoTarjeta.Text = dgvTarjetasTransporte.SelectedCells[0].Value.ToString();
            cboxCodigoPasajero.Text = dgvTarjetasTransporte.SelectedCells[1].Value.ToString();
            txtFechaEmision.Text = dgvTarjetasTransporte.SelectedCells[2].Value.ToString();
            txtSaldo.Text = dgvTarjetasTransporte.SelectedCells[3].Value.ToString();
            txtMoneda.Text = dgvTarjetasTransporte.SelectedCells[4].Value.ToString();
            cboxTipoTarjeta.Text = dgvTarjetasTransporte.SelectedCells[5].Value.ToString();
            cboxEstado.Text = dgvTarjetasTransporte.SelectedCells[6].Value.ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {

                string buscarTarjetastransporte = txtBuscar.Text.Trim();


                if (string.IsNullOrEmpty(buscarTarjetastransporte))
                {
                    MessageBox.Show("Por favor ingrese un valor de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dtTarjetastransporte = cD_TarjetasTransporte.MtdBuscarTarjetastransporte(buscarTarjetastransporte);


                if (dtTarjetastransporte.Rows.Count > 0)
                {
                    dgvTarjetasTransporte.DataSource = dtTarjetastransporte;
                }
                else
                {
                    MessageBox.Show("No se encontraron Tarjetas de transporte con los datos ingresados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cboxCodigoPasajero_DropDown(object sender, EventArgs e)
        {

        }

        private void LlenarComboTransportes()
        {

            DataTable dt = cD_TarjetasTransporte.ObtenerPasajerosActivos();

            cboxCodigoPasajero.DataSource = null; // Limpia
            cboxCodigoPasajero.DisplayMember = "Display";       // Muestra: "1 - Usuario1"
            cboxCodigoPasajero.ValueMember = "CodigoPasajero";   // Internamente: 1
            cboxCodigoPasajero.DataSource = dt;
            cboxCodigoPasajero.SelectedIndex = -1; // Que inicie vacío
        }

        private void cboxTransporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxCodigoPasajero.SelectedIndex != -1)
            {
                string codigo = cboxCodigoPasajero.SelectedValue.ToString();
                cboxCodigoPasajero.Text = codigo; // Muestra solo el código en el ComboBox
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
