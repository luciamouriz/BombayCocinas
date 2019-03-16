namespace AplicacionCocinas.Presupuesto
{
    partial class IUPresupuesto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IUPresupuesto));
            this.dgvPresupuesto = new System.Windows.Forms.DataGridView();
            this.btnAnadir = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnInforme = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbCentro = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbLocalidad = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpfechaentradaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpfechaentradaDesde = new System.Windows.Forms.DateTimePicker();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuesto)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPresupuesto
            // 
            this.dgvPresupuesto.BackgroundColor = System.Drawing.Color.SkyBlue;
            this.dgvPresupuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPresupuesto.Location = new System.Drawing.Point(71, 338);
            this.dgvPresupuesto.Name = "dgvPresupuesto";
            this.dgvPresupuesto.Size = new System.Drawing.Size(931, 376);
            this.dgvPresupuesto.TabIndex = 0;
            // 
            // btnAnadir
            // 
            this.btnAnadir.BackColor = System.Drawing.Color.White;
            this.btnAnadir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnadir.Image = ((System.Drawing.Image)(resources.GetObject("btnAnadir.Image")));
            this.btnAnadir.Location = new System.Drawing.Point(71, 273);
            this.btnAnadir.Name = "btnAnadir";
            this.btnAnadir.Size = new System.Drawing.Size(119, 45);
            this.btnAnadir.TabIndex = 1;
            this.btnAnadir.Text = "Añadir Presupuesto";
            this.btnAnadir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnadir.UseVisualStyleBackColor = false;
            this.btnAnadir.Click += new System.EventHandler(this.btnAnadir_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.White;
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.Location = new System.Drawing.Point(207, 273);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(119, 45);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "Modificar Presupuesto";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnInforme
            // 
            this.btnInforme.BackColor = System.Drawing.Color.White;
            this.btnInforme.Image = ((System.Drawing.Image)(resources.GetObject("btnInforme.Image")));
            this.btnInforme.Location = new System.Drawing.Point(344, 273);
            this.btnInforme.Name = "btnInforme";
            this.btnInforme.Size = new System.Drawing.Size(119, 45);
            this.btnInforme.TabIndex = 3;
            this.btnInforme.Text = "Imprimir";
            this.btnInforme.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInforme.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInforme.UseVisualStyleBackColor = false;
            this.btnInforme.Click += new System.EventHandler(this.btnInforme_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cmbCentro);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbLocalidad);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnLimpiarFiltros);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpfechaentradaHasta);
            this.groupBox1.Controls.Add(this.dtpfechaentradaDesde);
            this.groupBox1.Controls.Add(this.txtDni);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtApellidos);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(71, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(931, 142);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros..";
            // 
            // cmbCentro
            // 
            this.cmbCentro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCentro.FormattingEnabled = true;
            this.cmbCentro.Items.AddRange(new object[] {
            "Puertollano",
            "Ciudad Real",
            "Valdepeñas",
            "Tomelloso",
            "Miguelturra"});
            this.cmbCentro.Location = new System.Drawing.Point(89, 96);
            this.cmbCentro.Name = "cmbCentro";
            this.cmbCentro.Size = new System.Drawing.Size(166, 22);
            this.cmbCentro.TabIndex = 15;
            this.cmbCentro.SelectedIndexChanged += new System.EventHandler(this.cmbCentro_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 14);
            this.label8.TabIndex = 14;
            this.label8.Text = "Centro:";
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Location = new System.Drawing.Point(336, 61);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(166, 22);
            this.cmbLocalidad.TabIndex = 13;
            this.cmbLocalidad.SelectedValueChanged += new System.EventHandler(this.cmbLocalidad_SelectedValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(270, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "Localidad:";
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.BackColor = System.Drawing.Color.White;
            this.btnLimpiarFiltros.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiarFiltros.Image")));
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(383, 89);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(119, 38);
            this.btnLimpiarFiltros.TabIndex = 5;
            this.btnLimpiarFiltros.Text = "Limpiar Filtros";
            this.btnLimpiarFiltros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiarFiltros.UseVisualStyleBackColor = false;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(607, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "Desde:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(610, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "Hasta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(591, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "Fecha Presupuesto:";
            // 
            // dtpfechaentradaHasta
            // 
            this.dtpfechaentradaHasta.Location = new System.Drawing.Point(655, 64);
            this.dtpfechaentradaHasta.Name = "dtpfechaentradaHasta";
            this.dtpfechaentradaHasta.Size = new System.Drawing.Size(230, 21);
            this.dtpfechaentradaHasta.TabIndex = 8;
            this.dtpfechaentradaHasta.ValueChanged += new System.EventHandler(this.dtpfechaentradaHasta_ValueChanged);
            // 
            // dtpfechaentradaDesde
            // 
            this.dtpfechaentradaDesde.Location = new System.Drawing.Point(655, 31);
            this.dtpfechaentradaDesde.Name = "dtpfechaentradaDesde";
            this.dtpfechaentradaDesde.Size = new System.Drawing.Size(230, 21);
            this.dtpfechaentradaDesde.TabIndex = 7;
            this.dtpfechaentradaDesde.ValueChanged += new System.EventHandler(this.dtpfechaentradaDesde_ValueChanged);
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(336, 31);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(166, 21);
            this.txtDni.TabIndex = 6;
            this.txtDni.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDni_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dni:";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(89, 64);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(166, 21);
            this.txtApellidos.TabIndex = 3;
            this.txtApellidos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtApellidos_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellidos:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(89, 31);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(166, 21);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.Location = new System.Drawing.Point(883, 273);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(119, 45);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft JhengHei UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(63, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(254, 47);
            this.label9.TabIndex = 16;
            this.label9.Text = "Presupuestos";
            // 
            // IUPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1284, 782);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnInforme);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAnadir);
            this.Controls.Add(this.dgvPresupuesto);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IUPresupuesto";
            this.Text = "Presupuestos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuesto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPresupuesto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLocalidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpfechaentradaHasta;
        private System.Windows.Forms.DateTimePicker dtpfechaentradaDesde;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ComboBox cmbCentro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Button btnAnadir;
        public System.Windows.Forms.Button btnModificar;
        public System.Windows.Forms.Button btnInforme;
    }
}