using CAPA_DATOS;
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
        }
    }
}
