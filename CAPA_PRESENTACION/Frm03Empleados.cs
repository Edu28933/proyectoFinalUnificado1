    using CAPA_DATOS;
    using CAPA_LOGICA;
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
                cboxLicencia.Text = dgviewCrudEmpleados.SelectedCells[3].Value.ToString();
                txtTelefono.Text = dgviewCrudEmpleados.SelectedCells[4].Value.ToString();
                txtFechaCon.Text = dgviewCrudEmpleados.SelectedCells[5].Value.ToString();
                txtDireccion.Text = dgviewCrudEmpleados.SelectedCells[6].Value.ToString();
                cboxEstado.Text = dgviewCrudEmpleados.SelectedCells[7].Value.ToString();
                cboxTipoEmpleo.Text = dgviewCrudEmpleados.SelectedCells[8].Value.ToString();
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
                cboxLicencia.Text = "";
                txtTelefono.Clear();
                txtFechaCon.Clear();
                txtDireccion.Clear();
                cboxEstado.Text = "";
                cboxTipoEmpleo.Text = "";
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
            try
            {
                // Manejo del código de usuario: Si el combo tiene un valor seleccionado, lo usa; de lo contrario, toma el del DataGridView
                int codigoUsuario;
                if (cboxCodUsuario.SelectedIndex != -1 && cboxCodUsuario.SelectedValue != null)
                {
                    codigoUsuario = Convert.ToInt32(cboxCodUsuario.SelectedValue);
                }
                else if (dgviewCrudEmpleados.SelectedCells.Count > 1) // Si hay datos seleccionados en la DataGridView
                {
                    codigoUsuario = int.Parse(dgviewCrudEmpleados.SelectedCells[1].Value.ToString());
                }
                else
                {
                    MessageBox.Show("Seleccione un usuario válido para el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener el resto de los datos
                string nombre = txtNombre.Text;
                string licencia = cboxLicencia.Text;
                int telefono = int.Parse(txtTelefono.Text);
                DateTime fechaContratacion = DateTime.Parse(txtFechaCon.Text);
                string direccion = txtDireccion.Text;
                string estado = cboxEstado.Text;
                string tipoEmpleado = cboxTipoEmpleo.Text;
                decimal salario = decimal.Parse(txtSalario.Text);

                // Crear instancia de la clase y agregar el empleado
                cd_03Empleados cd03 = new cd_03Empleados();
                cd03.MtdAgregarEmpleado(codigoUsuario, nombre, licencia, telefono, fechaContratacion, direccion, estado, tipoEmpleado, salario);

                MessageBox.Show("Empleado agregado con éxito.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarEmpleados();
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
                if (string.IsNullOrEmpty(txtCodEmpleado.Text))
                {
                    MessageBox.Show("Seleccione un empleado para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el código de empleado
                int codigoEmpleado = int.Parse(txtCodEmpleado.Text);

                // Manejo del código de usuario: Si el combo tiene un valor seleccionado, lo usa; de lo contrario, toma el del DataGridView
                int codigoUsuario;
                if (cboxCodUsuario.SelectedIndex != -1 && cboxCodUsuario.SelectedValue != null)
                {
                    codigoUsuario = Convert.ToInt32(cboxCodUsuario.SelectedValue);
                }
                else
                {
                    codigoUsuario = int.Parse(dgviewCrudEmpleados.SelectedCells[1].Value.ToString());
                }

                // Verificar que el código de usuario es válido
                if (codigoUsuario <= 0)
                {
                    MessageBox.Show("Código de usuario inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string nombre = txtNombre.Text;
                string licencia = cboxLicencia.Text;
                int telefono = int.Parse(txtTelefono.Text);
                DateTime fechaContratacion = DateTime.Parse(txtFechaCon.Text);
                string direccion = txtDireccion.Text;
                string estado = cboxEstado.Text;
                string tipoEmpleado = cboxTipoEmpleo.Text;
                decimal salario = decimal.Parse(txtSalario.Text);

                // Llamada a la clase de datos
                cd_03Empleados cd03 = new cd_03Empleados();
                cd03.MtdActualizarEmpleado(codigoEmpleado, codigoUsuario, nombre, licencia, telefono, fechaContratacion, direccion, estado, tipoEmpleado, salario);

                MessageBox.Show("Empleado actualizado con éxito.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cboxTipoEmpleo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxTipoEmpleo.SelectedIndex != -1)
            {
                string tipoEmpleado = cboxTipoEmpleo.SelectedItem.ToString();

                // Llamar al procedimiento almacenado para obtener el salario
                cd_03Empleados cd03 = new cd_03Empleados();
                decimal salario = cd03.MtdObtenerSalario(tipoEmpleado);

                // Mostrar el salario en txtSalario
                txtSalario.Text = salario.ToString("N2"); // Formato numérico con dos decimales
            }
        }
    }
    }
