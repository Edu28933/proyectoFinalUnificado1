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
    public partial class frm05Pagos : Form
    {
        public frm05Pagos()
        {
            InitializeComponent();
        }

        public void MtdMostrarPagos()
        {

            cd_05Pagos cd_05Pagos = new cd_05Pagos();

            DataTable dtMostrarPagos = cd_05Pagos.MtMostrarPagos();
            dgviewCrudPagos.DataSource = dtMostrarPagos;
        }

        private void frm05Pagos_Load(object sender, EventArgs e)
        {
            MtdMostrarPagos();
        }
    }
}
