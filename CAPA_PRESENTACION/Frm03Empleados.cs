using CAPA_DATOS;
using CAPADATOS;
using CAPA_LOGICA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAPA_PRESENTACION
{
    public partial class Frm03Empleados : Form
    {
        public Frm03Empleados()
        {
            InitializeComponent();
        }

        
        

        public void MtdMostrarEmpleados()
        {

            cd_03Empleados cd_03Empleados = new cd_03Empleados();

            DataTable dtMostrarEmpleados = cd_03Empleados.MtMostrarEmpleados();
            dgviewCrudEmpleados.DataSource = dtMostrarEmpleados;
        }

        private void dgviewCrudEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Frm03Empleados_Load(object sender, EventArgs e)
        {

            MtdMostrarEmpleados();
            LlenarComboUsuarios();
            cboxCodUsuario.SelectedIndex = -1;

        }

        private void dgviewCrudEmpleados_Click(object sender, EventArgs e)
        {

        }

        private void LlenarComboUsuarios()
        {
            cl_03Empleados cl03 = new cl_03Empleados();
            DataTable dt = cl03.ObtenerUsuariosActivos();

            cboxCodUsuario.DataSource = null; // Limpia
            cboxCodUsuario.DisplayMember = "Display";       // Muestra: "1 - Usuario1"
            cboxCodUsuario.ValueMember = "CodigoUsuario";   // Internamente: 1
            cboxCodUsuario.DataSource = dt;

            cboxCodUsuario.SelectedIndex = -1; // Que inicie vacío
        }





        private void dgviewCrudEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodEmpleado.Text = dgviewCrudEmpleados.SelectedCells[0].Value.ToString();
            cboxCodUsuario.Text = dgviewCrudEmpleados.SelectedCells[1].Value.ToString();
            txtNombre.Text = dgviewCrudEmpleados.SelectedCells[2].Value.ToString();
            txtLicencia.Text = dgviewCrudEmpleados.SelectedCells[3].Value.ToString();
            txtTelefono.Text = dgviewCrudEmpleados.SelectedCells[4].Value.ToString();
            txtFechaCon.Text = dgviewCrudEmpleados.SelectedCells[5].Value.ToString();
            txtDireccion.Text = dgviewCrudEmpleados.SelectedCells[6].Value.ToString();
            cboxEstado.Text = dgviewCrudEmpleados.SelectedCells[7].Value.ToString();
            txtTipoEmpleo.Text = dgviewCrudEmpleados.SelectedCells[8].Value.ToString();
            txtSalario.Text = dgviewCrudEmpleados.SelectedCells[9].Value.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodEmpleado.Clear();
            cboxCodUsuario.Text = "";
            txtNombre.Clear();
            txtLicencia.Clear();
            txtTelefono.Clear();
            txtFechaCon.Clear();
            txtDireccion.Clear();
            cboxEstado.Text = "";
            txtTipoEmpleo.Clear();
            txtSalario.Clear();
        }



        private void cboxCodUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxCodUsuario.SelectedIndex != -1)
            {
                string codigo = cboxCodUsuario.SelectedValue.ToString();
                cboxCodUsuario.Text = codigo; // Muestra solo el código en el ComboBox
            }
        }




        private void cboxCodUsuario_DropDown(object sender, EventArgs e)
        {
            LlenarComboUsuarios();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            

                int codigoUsuario = Convert.ToInt32(cboxCodUsuario.SelectedValue);
                string nombre = txtNombre.Text;
                string licencia = txtLicencia.Text;
                int telefono = int.Parse(txtTelefono.Text);
                DateTime fechaContratacion = DateTime.Parse(txtFechaCon.Text);
                string direccion = txtDireccion.Text;
                string estado = cboxEstado.Text;
                string tipoEmpleado = txtTipoEmpleo.Text;
                decimal salario = decimal.Parse(txtSalario.Text);

                cd_03Empleados cd03 = new cd_03Empleados();
                cd03.MtdAgregarEmpleado(codigoUsuario, nombre, licencia, telefono, fechaContratacion, direccion, estado, tipoEmpleado, salario);

                MessageBox.Show("Empleado agregado con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarEmpleados();
                btnLimpiar_Click(sender, e);
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodEmpleado.Text))
                {
                    MessageBox.Show("Seleccione un empleado para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int codigoEmpleado = int.Parse(txtCodEmpleado.Text); // Asegurar que el código empleado se envíe
                int codigoUsuario = Convert.ToInt32(cboxCodUsuario.SelectedValue);
                string nombre = txtNombre.Text;
                string licencia = txtLicencia.Text;
                int telefono = int.Parse(txtTelefono.Text);
                DateTime fechaContratacion = DateTime.Parse(txtFechaCon.Text);
                string direccion = txtDireccion.Text;
                string estado = cboxEstado.Text;
                string tipoEmpleado = txtTipoEmpleo.Text;
                decimal salario = decimal.Parse(txtSalario.Text);

                cd_03Empleados cd03 = new cd_03Empleados();
                cd03.MtdActualizarEmpleado(codigoEmpleado, codigoUsuario, nombre, licencia, telefono, fechaContratacion, direccion, estado, tipoEmpleado, salario);

                MessageBox.Show("Empleado actualizado con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarEmpleados();
                btnLimpiar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                cd_03Empleados cd_03Empleados = new cd_03Empleados();
                cd_03Empleados.MtdEliminarEmpleado(int.Parse(txtCodEmpleado.Text));

                MessageBox.Show("Empleado eliminado con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarEmpleados();
                btnLimpiar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                cd_03Empleados cd_03Empleados = new cd_03Empleados();
                string buscarEmpleado = txtBuscar.Text.Trim();

                if (string.IsNullOrEmpty(buscarEmpleado))
                {
                    MessageBox.Show("Por favor ingrese un valor de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dtEmpleados = cd_03Empleados.MtdBuscarEmpleado(buscarEmpleado);

                if (dtEmpleados.Rows.Count > 0)
                {
                    dgviewCrudEmpleados.DataSource = dtEmpleados;
                }
                else
                {
                    MessageBox.Show("No se encontraron empleados con los datos ingresados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
