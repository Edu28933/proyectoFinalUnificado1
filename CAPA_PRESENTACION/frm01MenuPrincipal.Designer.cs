namespace CAPA_PRESENTACION
{
    partial class frm01MenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm01MenuPrincipal));
            this.panelContenedorForms = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelMenuLateral = new System.Windows.Forms.Panel();
            this.btnPagos = new System.Windows.Forms.Button();
            this.btnEstadisticas = new System.Windows.Forms.Button();
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LblNombreUsuario = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRutas = new System.Windows.Forms.Button();
            this.btnTransportes = new System.Windows.Forms.Button();
            this.btnTarjetas = new System.Windows.Forms.Button();
            this.btnPasajeros = new System.Windows.Forms.Button();
            this.panelContenedorForms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelMenuLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenedorForms
            // 
            this.panelContenedorForms.BackColor = System.Drawing.Color.Navy;
            this.panelContenedorForms.Controls.Add(this.pictureBox2);
            this.panelContenedorForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedorForms.Location = new System.Drawing.Point(333, 68);
            this.panelContenedorForms.Margin = new System.Windows.Forms.Padding(4);
            this.panelContenedorForms.Name = "panelContenedorForms";
            this.panelContenedorForms.Size = new System.Drawing.Size(1494, 805);
            this.panelContenedorForms.TabIndex = 3;
            this.panelContenedorForms.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContenedorForms_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(553, 150);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(449, 437);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // panelMenuLateral
            // 
            this.panelMenuLateral.AutoScroll = true;
            this.panelMenuLateral.BackColor = System.Drawing.Color.Black;
            this.panelMenuLateral.Controls.Add(this.btnPasajeros);
            this.panelMenuLateral.Controls.Add(this.btnTarjetas);
            this.panelMenuLateral.Controls.Add(this.btnTransportes);
            this.panelMenuLateral.Controls.Add(this.btnRutas);
            this.panelMenuLateral.Controls.Add(this.btnPagos);
            this.panelMenuLateral.Controls.Add(this.btnEstadisticas);
            this.panelMenuLateral.Controls.Add(this.btnEmpleados);
            this.panelMenuLateral.Controls.Add(this.btnUsuarios);
            this.panelMenuLateral.Controls.Add(this.pictureBox1);
            this.panelMenuLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenuLateral.Location = new System.Drawing.Point(0, 0);
            this.panelMenuLateral.Margin = new System.Windows.Forms.Padding(4);
            this.panelMenuLateral.Name = "panelMenuLateral";
            this.panelMenuLateral.Size = new System.Drawing.Size(333, 873);
            this.panelMenuLateral.TabIndex = 2;
            // 
            // btnPagos
            // 
            this.btnPagos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPagos.FlatAppearance.BorderSize = 0;
            this.btnPagos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnPagos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagos.ForeColor = System.Drawing.Color.White;
            this.btnPagos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPagos.Location = new System.Drawing.Point(0, 281);
            this.btnPagos.Margin = new System.Windows.Forms.Padding(4);
            this.btnPagos.Name = "btnPagos";
            this.btnPagos.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnPagos.Size = new System.Drawing.Size(333, 55);
            this.btnPagos.TabIndex = 4;
            this.btnPagos.Text = "PAGOS";
            this.btnPagos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagos.UseVisualStyleBackColor = true;
            this.btnPagos.Click += new System.EventHandler(this.btnPagos_Click);
            // 
            // btnEstadisticas
            // 
            this.btnEstadisticas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEstadisticas.FlatAppearance.BorderSize = 0;
            this.btnEstadisticas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnEstadisticas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnEstadisticas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstadisticas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstadisticas.ForeColor = System.Drawing.Color.White;
            this.btnEstadisticas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEstadisticas.Location = new System.Drawing.Point(0, 226);
            this.btnEstadisticas.Margin = new System.Windows.Forms.Padding(4);
            this.btnEstadisticas.Name = "btnEstadisticas";
            this.btnEstadisticas.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnEstadisticas.Size = new System.Drawing.Size(333, 55);
            this.btnEstadisticas.TabIndex = 3;
            this.btnEstadisticas.Text = "ESTADISTICAS";
            this.btnEstadisticas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEstadisticas.UseVisualStyleBackColor = true;
            this.btnEstadisticas.Click += new System.EventHandler(this.btnEstadisticas_Click);
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmpleados.FlatAppearance.BorderSize = 0;
            this.btnEmpleados.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnEmpleados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpleados.ForeColor = System.Drawing.Color.White;
            this.btnEmpleados.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEmpleados.Location = new System.Drawing.Point(0, 171);
            this.btnEmpleados.Margin = new System.Windows.Forms.Padding(4);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnEmpleados.Size = new System.Drawing.Size(333, 55);
            this.btnEmpleados.TabIndex = 2;
            this.btnEmpleados.Text = "EMPLEADOS";
            this.btnEmpleados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpleados.UseVisualStyleBackColor = true;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnUsuarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUsuarios.Location = new System.Drawing.Point(0, 116);
            this.btnUsuarios.Margin = new System.Windows.Forms.Padding(4);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnUsuarios.Size = new System.Drawing.Size(333, 55);
            this.btnUsuarios.TabIndex = 1;
            this.btnUsuarios.Text = "USUARIOS";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(333, 116);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LblNombreUsuario
            // 
            this.LblNombreUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblNombreUsuario.AutoSize = true;
            this.LblNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombreUsuario.ForeColor = System.Drawing.Color.White;
            this.LblNombreUsuario.Location = new System.Drawing.Point(705, 15);
            this.LblNombreUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblNombreUsuario.Name = "LblNombreUsuario";
            this.LblNombreUsuario.Size = new System.Drawing.Size(112, 32);
            this.LblNombreUsuario.TabIndex = 1;
            this.LblNombreUsuario.Text = "Usuario";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.LblNombreUsuario);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(333, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1494, 68);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnRutas
            // 
            this.btnRutas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRutas.FlatAppearance.BorderSize = 0;
            this.btnRutas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnRutas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnRutas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRutas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRutas.ForeColor = System.Drawing.Color.White;
            this.btnRutas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRutas.Location = new System.Drawing.Point(0, 336);
            this.btnRutas.Margin = new System.Windows.Forms.Padding(4);
            this.btnRutas.Name = "btnRutas";
            this.btnRutas.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnRutas.Size = new System.Drawing.Size(333, 55);
            this.btnRutas.TabIndex = 5;
            this.btnRutas.Text = "RUTAS";
            this.btnRutas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRutas.UseVisualStyleBackColor = true;
            this.btnRutas.Click += new System.EventHandler(this.btnRutas_Click);
            // 
            // btnTransportes
            // 
            this.btnTransportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTransportes.FlatAppearance.BorderSize = 0;
            this.btnTransportes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnTransportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnTransportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransportes.ForeColor = System.Drawing.Color.White;
            this.btnTransportes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTransportes.Location = new System.Drawing.Point(0, 391);
            this.btnTransportes.Margin = new System.Windows.Forms.Padding(4);
            this.btnTransportes.Name = "btnTransportes";
            this.btnTransportes.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnTransportes.Size = new System.Drawing.Size(333, 55);
            this.btnTransportes.TabIndex = 6;
            this.btnTransportes.Text = "TRANSPORTES";
            this.btnTransportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransportes.UseVisualStyleBackColor = true;
            this.btnTransportes.Click += new System.EventHandler(this.btnTransportes_Click);
            // 
            // btnTarjetas
            // 
            this.btnTarjetas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTarjetas.FlatAppearance.BorderSize = 0;
            this.btnTarjetas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnTarjetas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnTarjetas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTarjetas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTarjetas.ForeColor = System.Drawing.Color.White;
            this.btnTarjetas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTarjetas.Location = new System.Drawing.Point(0, 446);
            this.btnTarjetas.Margin = new System.Windows.Forms.Padding(4);
            this.btnTarjetas.Name = "btnTarjetas";
            this.btnTarjetas.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnTarjetas.Size = new System.Drawing.Size(333, 55);
            this.btnTarjetas.TabIndex = 7;
            this.btnTarjetas.Text = "TARJETAS TRANSPORTES";
            this.btnTarjetas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTarjetas.UseVisualStyleBackColor = true;
            this.btnTarjetas.Click += new System.EventHandler(this.btnTarjetas_Click);
            // 
            // btnPasajeros
            // 
            this.btnPasajeros.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPasajeros.FlatAppearance.BorderSize = 0;
            this.btnPasajeros.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnPasajeros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnPasajeros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPasajeros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPasajeros.ForeColor = System.Drawing.Color.White;
            this.btnPasajeros.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPasajeros.Location = new System.Drawing.Point(0, 501);
            this.btnPasajeros.Margin = new System.Windows.Forms.Padding(4);
            this.btnPasajeros.Name = "btnPasajeros";
            this.btnPasajeros.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnPasajeros.Size = new System.Drawing.Size(333, 55);
            this.btnPasajeros.TabIndex = 8;
            this.btnPasajeros.Text = "PASAJEROS";
            this.btnPasajeros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPasajeros.UseVisualStyleBackColor = true;
            this.btnPasajeros.Click += new System.EventHandler(this.btnPasajeros_Click);
            // 
            // frm01MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1827, 873);
            this.Controls.Add(this.panelContenedorForms);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelMenuLateral);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1813, 893);
            this.Name = "frm01MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EL INGE VELOZ";
            this.Load += new System.EventHandler(this.frm01MenuPrincipal_Load);
            this.panelContenedorForms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelMenuLateral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedorForms;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelMenuLateral;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LblNombreUsuario;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEmpleados;
        private System.Windows.Forms.Button btnPagos;
        private System.Windows.Forms.Button btnEstadisticas;
        private System.Windows.Forms.Button btnPasajeros;
        private System.Windows.Forms.Button btnTarjetas;
        private System.Windows.Forms.Button btnTransportes;
        private System.Windows.Forms.Button btnRutas;
    }
}

