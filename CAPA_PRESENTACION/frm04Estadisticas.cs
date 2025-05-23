using CAPADATOS;
using CAPA_DATOS;
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
    public partial class frm04Estadisticas : Form
    {
        public frm04Estadisticas()
        {
            InitializeComponent();
        }


        public void MtdMostrarEstadisticas()
        {

            cd_04Estadisticas cd_04Estadisticas = new cd_04Estadisticas();          

            DataTable dtMostrarEstadisticas = cd_04Estadisticas.MtMostrarEstadisticas();
            dgviewCrudEstdisticas.DataSource = dtMostrarEstadisticas;
        }

        private void frm04Estadisticas_Load(object sender, EventArgs e)
        {
            MtdMostrarEstadisticas();
        }
    }
}
