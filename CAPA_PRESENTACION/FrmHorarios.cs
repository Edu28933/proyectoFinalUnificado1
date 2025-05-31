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
    public partial class FrmHorarios : Form
    {

        CD_Horarios cD_Horarios = new CD_Horarios();
        public FrmHorarios()
        {
            InitializeComponent();
        }

        private void FrmHorarios_Load(object sender, EventArgs e)
        {
            MtdMostrarHorarios();
            LlenarComboEstaciones();
            cboxCodigoEstacion.SelectedIndex = -1;
        }

        public void MtdMostrarHorarios()
        {
            CD_Horarios cd_horarios = new CD_Horarios();
            DataTable dtMostrarHorarios = cd_horarios.MtdMostrarHorarios();
            dgvHorarios.DataSource = dtMostrarHorarios;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Manejo del código de usuario: Si el combo tiene un valor seleccionado, lo usa; de lo contrario, toma el del DataGridView
                int CodigoEstacion;
                if (cboxCodigoEstacion.SelectedIndex != -1 && cboxCodigoEstacion.SelectedValue != null)
                {
                    CodigoEstacion = Convert.ToInt32(cboxCodigoEstacion.SelectedValue);
                }
                /*else if (dgvHorarios.SelectedCells.Count > 1) // Si hay datos seleccionados en la DataGridView
                {
                    CodigoEstacion = int.Parse(dgvHorarios.SelectedCells[1].Value.ToString());
                }
                else
                {
                    MessageBox.Show("Seleccione una estación válida para el horario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int CodigoEstacion;
                if (cboxCodigoEstacion.SelectedIndex != -1 && cboxCodigoEstacion.SelectedValue != null)
                {
                    CodigoEstacion = Convert.ToInt32(cboxCodigoEstacion.SelectedValue);
                }*/
                else if (dgvHorarios.SelectedCells.Count > 1)
                {
                    CodigoEstacion = int.Parse(dgvHorarios.SelectedCells[1].Value.ToString());
                }
                else
                {
                    MessageBox.Show("Seleccione una estación válida para el horario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar y convertir HoraSalida
                if (!TimeSpan.TryParse(txtHoraSalida.Text, out TimeSpan HoraSalida))
                {
                    MessageBox.Show("Ingrese una hora de salida válida (formato HH:mm:ss).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar y convertir HoraLlegada
                if (!TimeSpan.TryParse(txtHoraLlegada.Text, out TimeSpan HoraLlegada))
                {
                    MessageBox.Show("Ingrese una hora de llegada válida (formato HH:mm:ss).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar y convertir FechaInicio
                if (!DateTime.TryParse(txtFechaInicio.Text, out DateTime FechaInicio))
                {
                    MessageBox.Show("Ingrese una fecha de inicio válida (formato YYYY-MM-DD).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar y convertir FechaFin
                if (!DateTime.TryParse(txtFechaFin.Text, out DateTime FechaFin))
                {
                    MessageBox.Show("Ingrese una fecha de fin válida (formato YYYY-MM-DD).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                // Obtener el resto de los datos

                /*TimeSpan HoraSalida = TimeSpan.Parse(txtHoraSalida.Text);
                TimeSpan HoraLlegada = TimeSpan.Parse(txtHoraLlegada.Text);
                DateTime FechaInicio = DateTime.Parse(txtFechaInicio.Text);
                DateTime FechaFin = DateTime.Parse(txtFechaFin.Text);*/
                string Estado = cboxEstado.Text;
                // Llamada a la clase de datos

                cD_Horarios.MtdAgregarHorarios(CodigoEstacion, HoraSalida, HoraLlegada, FechaInicio, FechaFin, Estado);
                MessageBox.Show("Horario agregado con éxito.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarHorarios();
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

                if (string.IsNullOrEmpty(txtCodigoHorario.Text))
                {
                    MessageBox.Show("Seleccione un horario para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el código de ruta
                int CodigoHorario = int.Parse(txtCodigoHorario.Text);

                // Manejo del código de usuario: Si el combo tiene un valor seleccionado, lo usa; de lo contrario, toma el del DataGridView
                int CodigoEstacion;
                if (cboxCodigoEstacion.SelectedIndex != -1 && cboxCodigoEstacion.SelectedValue != null)
                {
                    CodigoEstacion = Convert.ToInt32(cboxCodigoEstacion.SelectedValue);
                }
                else
                {
                    CodigoEstacion = int.Parse(dgvHorarios.SelectedCells[1].Value.ToString());
                }

                // Verificar que el código de transporte es válido
                if (CodigoEstacion <= 0)
                {
                    MessageBox.Show("Código de estacion inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                TimeSpan HoraSalida = TimeSpan.Parse(txtHoraSalida.Text);
                TimeSpan HoraLlegada = TimeSpan.Parse(txtHoraLlegada.Text);
                DateTime FechaInicio = DateTime.Parse(txtFechaInicio.Text);
                DateTime FechaFin = DateTime.Parse(txtFechaFin.Text);
                string Estado = cboxEstado.Text;

                // Llamada a la clase de datos

                cD_Horarios.MtdActualizarHorarios(CodigoHorario, CodigoEstacion, HoraSalida, HoraLlegada, FechaInicio, FechaFin, Estado);
                MessageBox.Show("Horario actualizado con éxito.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarHorarios();
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
                cD_Horarios.MtdEliminarHorarios(int.Parse(txtCodigoHorario.Text));
                MessageBox.Show("El horario se eliminó con éxtio", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarHorarios();
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
            MtdLimpiarHorarios();
        }

        public void MtdLimpiarHorarios()
        {
            txtCodigoHorario.Text = "";
            cboxCodigoEstacion.Text = "";
            txtHoraSalida.Text = "";
            txtHoraLlegada.Text = "";
            txtFechaInicio.Text = "";
            txtFechaFin.Text = "";
            cboxEstado.Text = "";

        }

        private void dgvHorarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoHorario.Text = dgvHorarios.SelectedCells[0].Value.ToString();
            cboxCodigoEstacion.Text = dgvHorarios.SelectedCells[1].Value.ToString();
            txtHoraSalida.Text = dgvHorarios.SelectedCells[2].Value.ToString();
            txtHoraLlegada.Text = dgvHorarios.SelectedCells[3].Value.ToString();
            txtFechaInicio.Text = dgvHorarios.SelectedCells[4].Value.ToString();
            txtFechaFin.Text = dgvHorarios.SelectedCells[5].Value.ToString();
            cboxEstado.Text = dgvHorarios.SelectedCells[6].Value.ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                string buscarHorarios = txtBuscar.Text.Trim();


                if (string.IsNullOrEmpty(buscarHorarios))
                {
                    MessageBox.Show("Por favor ingrese un valor de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dtHorarios = cD_Horarios.MtdBuscarHorarios(buscarHorarios);


                if (dtHorarios.Rows.Count > 0)
                {
                    dgvHorarios.DataSource = dtHorarios;
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

        private void cboxCodigoEstacion_DropDown(object sender, EventArgs e)
        {
            LlenarComboEstaciones();
        }

        private void LlenarComboEstaciones()
        {

            DataTable dt = cD_Horarios.ObtenerEstacionesActivas();

            cboxCodigoEstacion.DataSource = null; // Limpia
            cboxCodigoEstacion.DisplayMember = "Display";       // Muestra: "1 - Usuario1"
            cboxCodigoEstacion.ValueMember = "CodigoEstacion";   // Internamente: 1
            cboxCodigoEstacion.DataSource = dt;
            cboxCodigoEstacion.SelectedIndex = -1; // Que inicie vacío
        }

        private void cboxEstaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxCodigoEstacion.SelectedIndex != -1)
            {
                string codigo = cboxCodigoEstacion.SelectedValue.ToString();
                cboxCodigoEstacion.Text = codigo; // Muestra solo el código en el ComboBox
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboxCodigoEstacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
