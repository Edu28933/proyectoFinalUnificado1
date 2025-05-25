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
                // Manejo del código de usuario: Si el combo tiene un valor seleccionado, lo usa; de lo contrario, toma el del DataGridView
                int CodigoTransporte;
                if (cboxCodigoTransporte.SelectedIndex != -1 && cboxCodigoTransporte.SelectedValue != null)
                {
                    CodigoTransporte = Convert.ToInt32(cboxCodigoTransporte.SelectedValue);
                }
                else if (dgvRutas.SelectedCells.Count > 1) // Si hay datos seleccionados en la DataGridView
                {
                    CodigoTransporte = int.Parse(dgvRutas.SelectedCells[1].Value.ToString());
                }
                else
                {
                    MessageBox.Show("Seleccione un transporte válido para la ruta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener el resto de los datos

                string Nombre = txtNombre.Text;
                string Origen = txtOrigen.Text;
                string Destino = txtDestino.Text;
                string Distancia = txtDistancia.Text;
                string TipoRuta = txtTipoRuta.Text;
                string Estado = cboxEstado.Text;
                // Llamada a la clase de datos

                cD_Rutas.MtdAgregarRutas(CodigoTransporte, Nombre, Origen, Destino, Distancia, TipoRuta, Estado);
                MessageBox.Show("Ruta actualizado con éxito.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarRutas();
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


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmRutas_Load(object sender, EventArgs e)
        {
            MtdMostrarRutas();
            LlenarComboTransportes();
            cboxCodigoTransporte.SelectedIndex = -1;
        }

        public void MtdMostrarRutas()
        {
            CD_Rutas cd_rutas = new CD_Rutas();
            DataTable dtMostrarRutas = cd_rutas.MtdMostrarRutas();
            dgvRutas.DataSource = dtMostrarRutas;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            
                if (string.IsNullOrEmpty(txtCodigoRuta.Text))
                {
                    MessageBox.Show("Seleccione una ruta para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el código de ruta
                int CodigoRuta = int.Parse(txtCodigoRuta.Text);

                // Manejo del código de usuario: Si el combo tiene un valor seleccionado, lo usa; de lo contrario, toma el del DataGridView
                int CodigoTransporte;
                if (cboxCodigoTransporte.SelectedIndex != -1 && cboxCodigoTransporte.SelectedValue != null)
                {
                    CodigoTransporte = Convert.ToInt32(cboxCodigoTransporte.SelectedValue);
                }
                else
                {
                    CodigoTransporte = int.Parse(dgvRutas.SelectedCells[1].Value.ToString());
                }

                // Verificar que el código de transporte es válido
                if (CodigoTransporte <= 0)
                {
                    MessageBox.Show("Código de transporte inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string Nombre = txtNombre.Text;
                string Origen = txtOrigen.Text;
                string Destino = txtDestino.Text;
                string Distancia = txtDistancia.Text;
                string TipoRuta = txtTipoRuta.Text;
                string Estado = cboxEstado.Text;
                // Llamada a la clase de datos

                cD_Rutas.MtdActualizarRutas(CodigoRuta, CodigoTransporte, Nombre, Origen, Destino, Distancia, TipoRuta, Estado);
                MessageBox.Show("Ruta actualizado con éxito.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarRutas();
                btnLimpiar_Click(sender, e);
            
            

        }

        public void MtdLimpiarRutas()
        {
            txtCodigoRuta.Text = "";
            cboxCodigoTransporte.Text = "";
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
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRutas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoRuta.Text = dgvRutas.SelectedCells[0].Value.ToString();
            cboxCodigoTransporte.Text = dgvRutas.SelectedCells[1].Value.ToString();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                string buscarRutas = txtBuscar.Text.Trim();


                if (string.IsNullOrEmpty(buscarRutas))
                {
                    MessageBox.Show("Por favor ingrese un valor de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dtRutas = cD_Rutas.MtdBuscarRutas(buscarRutas);


                if (dtRutas.Rows.Count > 0)
                {
                    dgvRutas.DataSource = dtRutas;
                }
                else
                {
                    MessageBox.Show("No se encontraron Rutas con los datos ingresados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cboxCodigoTransporte_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboxCodigoTransporte_DropDown(object sender, EventArgs e)
        {
            LlenarComboTransportes();
        }

        private void LlenarComboTransportes()
        {

            DataTable dt = cD_Rutas.ObtenerTransportesActivos();

            cboxCodigoTransporte.DataSource = null; // Limpia
            cboxCodigoTransporte.DisplayMember = "Display";       // Muestra: "1 - Usuario1"
            cboxCodigoTransporte.ValueMember = "CodigoTransporte";   // Internamente: 1
            cboxCodigoTransporte.DataSource = dt;
            cboxCodigoTransporte.SelectedIndex = -1; // Que inicie vacío
        }

      



        private void cboxTransporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxCodigoTransporte.SelectedIndex != -1)
            {
                string codigo = cboxCodigoTransporte.SelectedValue.ToString();
                cboxCodigoTransporte.Text = codigo; // Muestra solo el código en el ComboBox
            }
        }

    }
}
