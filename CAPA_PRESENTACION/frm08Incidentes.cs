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
using CAPADATOS;
namespace CAPA_PRESENTACION
{
    public partial class frm08Incidentes : Form
    {

        cd_08Insidentes cd_08Insidentes = new cd_08Insidentes();
        public frm08Incidentes()
        {
            InitializeComponent();
        }

        private void MtdMostrarIncidentes()
        {
            DataTable dtMostrarIncidentes = cd_08Insidentes.MtdMostrarIncidentes();
            dgviewCrudIncidentes.DataSource = dtMostrarIncidentes;



        }


        public void LlenarComboTransportes()
        {
            DataTable dt = cd_08Insidentes.ObtenerTransportes();

            cboxTransporte.DataSource = dt;
            cboxTransporte.DisplayMember = "Display";
            cboxTransporte.ValueMember = "CodigoTransporte";
            cboxTransporte.SelectedIndex = -1;
        }
        public void LlenarComboEmpleados()
        {
            DataTable dt = cd_08Insidentes.ObtenerEmpleados();

            cboxEmpleado.DataSource = dt;
            cboxEmpleado.DisplayMember = "Display";
            cboxEmpleado.ValueMember = "CodigoEmpleado";
            cboxEmpleado.SelectedIndex = -1;
        }


        public void MtdLimpiar()
        {
            txtcodIncidente.Clear();
            cboxTransporte.Text = "";
            cboxEmpleado.Text = "";
            txtDescripcion.Clear();
            txtFecha.Clear();
            txtHora.Clear();
            cboxEstado.Text = "";


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                cd_08Insidentes.MtdEliminarIncidente(int.Parse(txtcodIncidente.Text));

                MessageBox.Show("Incidente eliminada con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarIncidentes();
                btnLimpiar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frm08Incidentes_Load(object sender, EventArgs e)
        {
            MtdMostrarIncidentes();
            LlenarComboTransportes();
            LlenarComboEmpleados();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                cd_08Insidentes cd_08Insidentes = new cd_08Insidentes();

                string buscarInsidentes = txtBuscar.Text.Trim();


                if (string.IsNullOrEmpty(buscarInsidentes))
                {
                    MessageBox.Show("Por favor ingrese un valor de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dtInsidentes = cd_08Insidentes.MtdBuscarIncidentes(buscarInsidentes);


                if (dtInsidentes.Rows.Count > 0)
                {
                    dgviewCrudIncidentes.DataSource = dtInsidentes;
                }
                else
                {
                    MessageBox.Show("No se encontraron Incidentes con los datos ingresados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Validar que se haya seleccionado un incidente
                if (string.IsNullOrWhiteSpace(txtcodIncidente.Text))
                {
                    MessageBox.Show("Seleccione un incidente para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar transporte
                if (cboxTransporte.SelectedIndex == -1 || cboxTransporte.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un transporte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar empleado
                if (cboxEmpleado.SelectedIndex == -1 || cboxEmpleado.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un empleado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Captura de datos desde los controles
                int codigoIncidente = int.Parse(txtcodIncidente.Text);
                int codigoTransporte = Convert.ToInt32(cboxTransporte.SelectedValue);
                int codigoEmpleado = Convert.ToInt32(cboxEmpleado.SelectedValue);
                string descripcion = txtDescripcion.Text.Trim();
                DateTime fecha = DateTime.Parse(txtFecha.Text);
                TimeSpan hora = TimeSpan.Parse(txtHora.Text);
                string estado = cboxEstado.Text;

                // Llamar al método de la capa de datos
                cd_08Insidentes datos = new cd_08Insidentes();
                datos.MtdEditarIncidente(codigoIncidente, codigoTransporte, codigoEmpleado, descripcion, fecha, hora, estado);

                MessageBox.Show("Incidente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refrescar la grilla y limpiar campos
                MtdMostrarIncidentes(); // Asegúrate de tener este método definido
                btnLimpiar_Click(sender, e); // O puedes usar MtdLimpiar() si ya lo tienes
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error de base de datos al actualizar el incidente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Verifique que los campos de fecha y hora estén en el formato correcto.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            MtdLimpiar();
            MtdMostrarIncidentes(); 
        }

        private void dgviewCrudIncidentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodIncidente.Text = dgviewCrudIncidentes.SelectedCells[0].Value.ToString();
            cboxTransporte.Text = dgviewCrudIncidentes.SelectedCells[1].Value.ToString();
            cboxEmpleado.Text = dgviewCrudIncidentes.SelectedCells[1].Value.ToString();
            txtDescripcion.Text = dgviewCrudIncidentes.SelectedCells[3].Value.ToString();
            txtFecha.Text = dgviewCrudIncidentes.SelectedCells[4].Value.ToString();
            txtHora.Text = dgviewCrudIncidentes.SelectedCells[5].Value.ToString();
            cboxEstado.Text = dgviewCrudIncidentes.SelectedCells[6].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación de transporte
                if (cboxTransporte.SelectedIndex == -1 || cboxTransporte.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un transporte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validación de empleado
                if (cboxEmpleado.SelectedIndex == -1 || cboxEmpleado.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un empleado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener valores
                int codigoTransporte = Convert.ToInt32(cboxTransporte.SelectedValue);
                int codigoEmpleado = Convert.ToInt32(cboxEmpleado.SelectedValue);
                string descripcion = txtDescripcion.Text.Trim();
                DateTime fecha = DateTime.Parse(txtFecha.Text);
                TimeSpan hora = TimeSpan.Parse(txtHora.Text);
                string estado = cboxEstado.Text;

                // Llamar al método en la capa de datos
                cd_08Insidentes.MtdAgregarIncidente(codigoTransporte, codigoEmpleado, descripcion, fecha, hora, estado);

                MessageBox.Show("Incidente agregado con éxito.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarIncidentes(); // Actualizar la vista
                btnLimpiar_Click(sender, e); // Limpiar formulario
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
                this.Close();
        }
    }
}
