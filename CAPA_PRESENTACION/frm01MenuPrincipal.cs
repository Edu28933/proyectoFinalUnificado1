using System;
using System.Windows.Forms;

namespace CAPA_PRESENTACION
{
    public partial class frm01MenuPrincipal : Form
    {
        private string usuario;

        public frm01MenuPrincipal(string usuario)
        {
            InitializeComponent();

            //sirve para cerrar los otros forms y que no se sature el programa
            this.FormClosed += new FormClosedEventHandler(MenuPrincipal_FormClosed);
            this.usuario = usuario;
        }


        //para cerrar el programa al cerrar el menu principal porque el login queda abierto al cerrar este
        private void MenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void frm01MenuPrincipal_Load(object sender, EventArgs e)
        {
            //sirvee par mostrar el nombre del usuario
            if (!string.IsNullOrEmpty(usuario))
            {
                LblNombreUsuario.Text = usuario;
            }
        }








        //abrir los forms y que se cierren para que no sature el programa
        private Form activeform = null;
        private void mtdAbrirFormularios(Form AbrirForm)
        {
            if (activeform != null)
                activeform.Close();
            activeform = AbrirForm;
            AbrirForm.TopLevel = false;
            AbrirForm.FormBorderStyle = FormBorderStyle.None;
            AbrirForm.Dock = DockStyle.Fill;
            panelContenedorForms.Controls.Add(AbrirForm);
            AbrirForm.BringToFront();
            AbrirForm.Show();

        }




        private void btnUsuarios_Click_1(object sender, EventArgs e)
        {
            mtdAbrirFormularios(new frm02Usuarios());
        }


        private void panelContenedorForms_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            mtdAbrirFormularios(new Frm03Empleados());
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            mtdAbrirFormularios(new frm04Estadisticas());
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            mtdAbrirFormularios(new frm05Pagos());
        }

        private void btnRutas_Click(object sender, EventArgs e)
        {
            mtdAbrirFormularios(new FrmRutas());
        }

        private void btnTransportes_Click(object sender, EventArgs e)
        {
            mtdAbrirFormularios(new FrmTransportes());
        }

        private void btnTarjetas_Click(object sender, EventArgs e)
        {
            mtdAbrirFormularios(new FrmTarjetasTransporte());
        }

        private void btnPasajeros_Click(object sender, EventArgs e)
        {
            mtdAbrirFormularios(new FrmPasajeros());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mtdAbrirFormularios(new FrmHorarios());

        }

        private void btnEstaciones_Click(object sender, EventArgs e)
        {
            mtdAbrirFormularios(new frm06Estaciones());
        }

        private void btnTarifas_Click(object sender, EventArgs e)
        {
            mtdAbrirFormularios(new frm07Tarifas());

        }

        private void btnIncidentes_Click(object sender, EventArgs e)
        {
            mtdAbrirFormularios(new frm08Incidentes());

        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            mtdAbrirFormularios(new frm09Mantenimientos());

        }
    }
}
