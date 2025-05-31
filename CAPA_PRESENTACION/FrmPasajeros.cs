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
            dgvPasajeros.Columns["FechaAlta"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el resto de los datos

                string Nombre = txtNombre.Text;
                /*int Dpi = int.Parse(txtDpi.Text);
                int Nit = int.Parse(txtNit.Text);
                DateTime FechaAlta = DateTime.Parse(txtFechaAlta.Text);
                int Telefono = int.Parse(txtTelefono.Text);
                string Estado = cboxEstado.Text;*/

                if (!int.TryParse(txtDpi.Text, out int Dpi))
                {
                    MessageBox.Show("El DPI debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtNit.Text, out int Nit))
                {
                    MessageBox.Show("El NIT debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!DateTime.TryParse(txtFechaAlta.Text, out DateTime FechaAlta))
                {
                    MessageBox.Show("La Fecha de Alta no tiene un formato válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtTelefono.Text, out int Telefono))
                {
                    MessageBox.Show("El teléfono debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string Estado = cboxEstado.Text;
                if (Estado != "Activo" && Estado != "Inactivo")
                {
                    MessageBox.Show("El estado debe ser 'Activo' o 'Inactivo'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Llamada a la clase de datos

                cD_Pasajeros.MtdAgregarPasajeros(Nombre, Dpi, Nit, FechaAlta, Telefono, Estado);
                MessageBox.Show("Pasajero agregado con éxito.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarPasajeros();
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
                // Obtener el código de ruta
                int CodigoPasajero = int.Parse(txtCodigoPasajero.Text);

                string Nombre = txtNombre.Text;
                int Dpi = int.Parse(txtDpi.Text);
                int Nit = int.Parse(txtNit.Text);
                DateTime FechaAlta = DateTime.Parse(txtFechaAlta.Text);
                int Telefono = int.Parse(txtTelefono.Text);
                string Estado = cboxEstado.Text;
                // Llamada a la clase de datos

                cD_Pasajeros.MtdActualizarPasajeros(CodigoPasajero, Nombre, Dpi, Nit, FechaAlta, Telefono, Estado);
                MessageBox.Show("Pasajero actualizado con éxito.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarPasajeros();
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
            MtdLimpiarPasajeros();
        }

        public void MtdLimpiarPasajeros()
        {
            txtCodigoPasajero.Text = "";
            txtNombre.Text = "";
            txtDpi.Text = "";
            txtNit.Text = "";
            txtFechaAlta.Text = "";
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
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPasajeros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoPasajero.Text = dgvPasajeros.SelectedCells[0].Value.ToString();
            txtNombre.Text = dgvPasajeros.SelectedCells[1].Value.ToString();
            txtDpi.Text = dgvPasajeros.SelectedCells[2].Value.ToString();
            txtNit.Text = dgvPasajeros.SelectedCells[3].Value.ToString();
            txtFechaAlta.Text = dgvPasajeros.SelectedCells[4].Value.ToString();
            txtTelefono.Text = dgvPasajeros.SelectedCells[5].Value.ToString();
            cboxEstado.Text = dgvPasajeros.SelectedCells[6].Value.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                string buscarPasajeros = txtBuscar.Text.Trim();


                if (string.IsNullOrEmpty(buscarPasajeros))
                {
                    MessageBox.Show("Por favor ingrese un valor de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dtPasajeros = cD_Pasajeros.MtdBuscarPasajeros(buscarPasajeros);


                if (dtPasajeros.Rows.Count > 0)
                {
                    dgvPasajeros.DataSource = dtPasajeros;
                }
                else
                {
                    MessageBox.Show("No se encontraron Pasajeros con los datos ingresados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
