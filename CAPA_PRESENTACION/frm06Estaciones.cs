using System;
using CAPADATOS; 
using CAPA_DATOS;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAPA_LOGICA;

namespace CAPA_PRESENTACION
{ 
   
    public partial class frm06Estaciones : Form
    {
        cd_06Estaciones cd_06Estaciones = new cd_06Estaciones();

        public frm06Estaciones()
        {
            InitializeComponent();
        }
        public void MtdMostrarEstaciones()
        {

           

            DataTable dtMostrarEstaciones = cd_06Estaciones.MtMostrarEstaciones();
            dgviewCrudEstaciones.DataSource = dtMostrarEstaciones ;
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frm06Estaciones_Load(object sender, EventArgs e)
        {
            MtdMostrarEstaciones();
            LlenarComboEstacion();
            cboxRuta.SelectedIndex = -1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                 cd_06Estaciones cd_06Estaciones = new cd_06Estaciones();

                string buscarEstaciones = txtBuscar.Text.Trim();


                if (string.IsNullOrEmpty(buscarEstaciones))
                {
                    MessageBox.Show("Por favor ingrese un valor de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dtEstaciones = cd_06Estaciones.MtdBuscarEstaciones(buscarEstaciones);


                if (dtEstaciones.Rows.Count > 0)
                {
                    dgviewCrudEstaciones.DataSource = dtEstaciones;
                }
                else
                {
                    MessageBox.Show("No se encontraron Estaciones con los datos ingresados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (string.IsNullOrEmpty(txtcodEstacion.Text))
                {
                    MessageBox.Show("Seleccione una estacion para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el código de empleado
                int codigoEstacion = int.Parse(txtcodEstacion.Text);

                // Manejo del código de usuario: Si el combo tiene un valor seleccionado, lo usa; de lo contrario, toma el del DataGridView
                int codigoRuta;
                if (cboxRuta.SelectedIndex != -1 && cboxRuta.SelectedValue != null)
                {
                    codigoRuta = Convert.ToInt32(cboxRuta.SelectedValue);
                }
                else
                {
                    codigoRuta = int.Parse(dgviewCrudEstaciones.SelectedCells[1].Value.ToString());
                }

                // Verificar que el código de usuario es válido
                if (codigoRuta <= 0)
                {
                    MessageBox.Show("Código de ruta inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string Nombre = txtNombre.Text;
                string Ubicacion = txtUbicacion.Text;
                string Secuencia = txtSecuencia.Text;
                TimeSpan TiempoEspera = DateTime.Parse(txtTiemEspera.Text).TimeOfDay;
                string Estado = cboxEstado.Text;
                // Llamada a la clase de datos

                cd_06Estaciones.MtdActualizarEstaciones(codigoEstacion, codigoRuta, Nombre, Ubicacion, Secuencia, TiempoEspera, Estado);
                MessageBox.Show("Ruta actualizado con éxito.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarEstaciones();
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

        private void dgviewCrudEstaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodEstacion.Text = dgviewCrudEstaciones.SelectedCells[0].Value.ToString();
            cboxRuta.Text = dgviewCrudEstaciones.SelectedCells[1].Value.ToString(); 
              txtNombre.Text = dgviewCrudEstaciones.SelectedCells[2].Value.ToString();
              txtUbicacion.Text = dgviewCrudEstaciones.SelectedCells[3].Value.ToString(); 
              txtSecuencia.Text = dgviewCrudEstaciones.SelectedCells[4].Value.ToString(); 
              txtTiemEspera.Text = dgviewCrudEstaciones.SelectedCells[5].Value.ToString();
              cboxEstado.Text = dgviewCrudEstaciones.SelectedCells[6].Value.ToString();



        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        public void MtdLimpiar()
        {
            txtcodEstacion.Clear();
            cboxRuta.Text = ""; 
            txtNombre.Clear(); 
            txtUbicacion.Clear();
            txtSecuencia.Clear();
            txtTiemEspera.Clear();
            cboxEstado.Text = ""; 


        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            MtdLimpiar(); 
            MtdMostrarEstaciones();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Manejo del código de usuario: Si el combo tiene un valor seleccionado, lo usa; de lo contrario, toma el del DataGridView
                int codigoRutas;
                if (cboxRuta.SelectedIndex != -1 && cboxRuta.SelectedValue != null)
                {
                    codigoRutas = Convert.ToInt32(cboxRuta.SelectedValue);
                }
                else if (dgviewCrudEstaciones.SelectedCells.Count > 1) // Si hay datos seleccionados en la DataGridView
                {
                    codigoRutas = int.Parse(dgviewCrudEstaciones.SelectedCells[1].Value.ToString());
                }
                else
                {
                    MessageBox.Show("Seleccione una ruta válida para la estacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener el resto de los datos
                 
                string nombre = txtNombre.Text;
                string Ubicacion = txtUbicacion.Text;
                string Secuencia= txtSecuencia.Text;
                TimeSpan TiempoEspera = DateTime.Parse(txtTiemEspera.Text).TimeOfDay;
                string estado = cboxEstado.Text;
               

                // Crear instancia de la clase y agregar el empleado
               
                cd_06Estaciones.MtdAgregarEstaciones(codigoRutas, nombre, Ubicacion, Secuencia, TiempoEspera,  estado);

                MessageBox.Show("Estacion agregada con éxito.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarEstaciones();
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
            
                cd_06Estaciones.MtdEliminarEstaciones(int.Parse(txtcodEstacion.Text));

                MessageBox.Show("Estacion eliminado con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarEstaciones();
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

        private void LlenarComboEstacion()
        {
            
            DataTable dt = cd_06Estaciones.ObtenerEstacionesActivos();

            cboxRuta.DataSource = null; // Limpia
            cboxRuta.DisplayMember = "Display";       // Muestra: "1 - Usuario1"
            cboxRuta.ValueMember = "CodigoTransporte";   // Internamente: 1
            cboxRuta.DataSource = dt;
                cboxRuta.SelectedIndex = -1; // Que inicie vacío
        }

        private void cboxRuta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxRuta.SelectedIndex != -1)
            {
                string codigo = cboxRuta.SelectedValue.ToString();
                cboxRuta.Text = codigo; // Muestra solo el código en el ComboBox
            }
        }

        private void cboxRuta_DropDown(object sender, EventArgs e)
        {
            LlenarComboEstacion(); 
        }
    }
}
