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
            cboxCodUsuario.SelectedIndex = -1;
        }

        private void dgviewCrudEmpleados_Click(object sender, EventArgs e)
        {

        }

        private void LlenarComboUsuarios()
        {
            cl_03Empleados cl03 = new cl_03Empleados();
            DataTable dt = cl03.ObtenerUsuariosActivos();

            cboxCodUsuario.DisplayMember = "Display";
            cboxCodUsuario.ValueMember = "CodigoUsuario";
            cboxCodUsuario.DataSource = dt;

            cboxCodUsuario.SelectedIndex = -1; // Para que se muestre vacío
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
                // Forzar que muestre el código directamente en el combo
                cboxCodUsuario.Text = cboxCodUsuario.SelectedValue.ToString();
            }
        }

        private void cboxCodUsuario_DropDown(object sender, EventArgs e)
        {
            LlenarComboUsuarios();
        }
    }
}
