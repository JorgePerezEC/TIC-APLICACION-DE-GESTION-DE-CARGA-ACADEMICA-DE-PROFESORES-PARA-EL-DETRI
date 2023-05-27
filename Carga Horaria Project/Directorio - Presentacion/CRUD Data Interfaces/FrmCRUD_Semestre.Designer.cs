namespace Directorio___Presentacion.CRUD_Interfaces
{
    partial class FrmCRUD_Semestre
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNewSemestre = new System.Windows.Forms.Button();
            this.btnCloseWin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelNewSemestre = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.cboxSemanasClase = new System.Windows.Forms.ComboBox();
            this.cboxSemanasTotales = new System.Windows.Forms.ComboBox();
            this.dtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.ckboxEstado = new System.Windows.Forms.CheckBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dgLstSemestres = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelNewSemestre.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLstSemestres)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnNewSemestre);
            this.panel1.Controls.Add(this.btnCloseWin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1394, 95);
            this.panel1.TabIndex = 0;
            // 
            // btnNewSemestre
            // 
            this.btnNewSemestre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewSemestre.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnNewSemestre.FlatAppearance.BorderSize = 0;
            this.btnNewSemestre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewSemestre.Font = new System.Drawing.Font("Roboto Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNewSemestre.Location = new System.Drawing.Point(497, 25);
            this.btnNewSemestre.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnNewSemestre.Name = "btnNewSemestre";
            this.btnNewSemestre.Size = new System.Drawing.Size(125, 41);
            this.btnNewSemestre.TabIndex = 6;
            this.btnNewSemestre.Text = "Nuevo";
            this.btnNewSemestre.UseVisualStyleBackColor = false;
            this.btnNewSemestre.Click += new System.EventHandler(this.btnNewSemestre_Click_1);
            // 
            // btnCloseWin
            // 
            this.btnCloseWin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseWin.BackColor = System.Drawing.Color.LightCoral;
            this.btnCloseWin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCloseWin.Font = new System.Drawing.Font("Roboto Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCloseWin.Location = new System.Drawing.Point(1253, 14);
            this.btnCloseWin.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnCloseWin.Name = "btnCloseWin";
            this.btnCloseWin.Size = new System.Drawing.Size(125, 41);
            this.btnCloseWin.TabIndex = 5;
            this.btnCloseWin.Text = "Cerrar";
            this.btnCloseWin.UseVisualStyleBackColor = false;
            this.btnCloseWin.Click += new System.EventHandler(this.btnCloseWin_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(82, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Administrar Semestres";
            // 
            // panelNewSemestre
            // 
            this.panelNewSemestre.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelNewSemestre.Controls.Add(this.btnGuardar);
            this.panelNewSemestre.Controls.Add(this.dtFechaInicio);
            this.panelNewSemestre.Controls.Add(this.cboxSemanasClase);
            this.panelNewSemestre.Controls.Add(this.cboxSemanasTotales);
            this.panelNewSemestre.Controls.Add(this.dtFechaFin);
            this.panelNewSemestre.Controls.Add(this.ckboxEstado);
            this.panelNewSemestre.Controls.Add(this.txtYear);
            this.panelNewSemestre.Controls.Add(this.txtCodigo);
            this.panelNewSemestre.Controls.Add(this.label8);
            this.panelNewSemestre.Controls.Add(this.label5);
            this.panelNewSemestre.Controls.Add(this.label6);
            this.panelNewSemestre.Controls.Add(this.label7);
            this.panelNewSemestre.Controls.Add(this.label4);
            this.panelNewSemestre.Controls.Add(this.label3);
            this.panelNewSemestre.Controls.Add(this.label2);
            this.panelNewSemestre.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNewSemestre.Location = new System.Drawing.Point(0, 95);
            this.panelNewSemestre.Name = "panelNewSemestre";
            this.panelNewSemestre.Size = new System.Drawing.Size(1394, 178);
            this.panelNewSemestre.TabIndex = 3;
            this.panelNewSemestre.Visible = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Roboto Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGuardar.Location = new System.Drawing.Point(1235, 52);
            this.btnGuardar.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(125, 41);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaInicio.Location = new System.Drawing.Point(506, 22);
            this.dtFechaInicio.MaxDate = new System.DateTime(8970, 1, 31, 0, 0, 0, 0);
            this.dtFechaInicio.MinDate = new System.DateTime(1753, 1, 11, 0, 0, 0, 0);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(279, 27);
            this.dtFechaInicio.TabIndex = 17;
            // 
            // cboxSemanasClase
            // 
            this.cboxSemanasClase.FormattingEnabled = true;
            this.cboxSemanasClase.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cboxSemanasClase.Location = new System.Drawing.Point(1082, 29);
            this.cboxSemanasClase.Name = "cboxSemanasClase";
            this.cboxSemanasClase.Size = new System.Drawing.Size(86, 28);
            this.cboxSemanasClase.TabIndex = 16;
            // 
            // cboxSemanasTotales
            // 
            this.cboxSemanasTotales.FormattingEnabled = true;
            this.cboxSemanasTotales.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cboxSemanasTotales.Location = new System.Drawing.Point(1082, 71);
            this.cboxSemanasTotales.Name = "cboxSemanasTotales";
            this.cboxSemanasTotales.Size = new System.Drawing.Size(86, 28);
            this.cboxSemanasTotales.TabIndex = 15;
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFin.Location = new System.Drawing.Point(506, 70);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(279, 27);
            this.dtFechaFin.TabIndex = 13;
            // 
            // ckboxEstado
            // 
            this.ckboxEstado.AutoSize = true;
            this.ckboxEstado.Checked = true;
            this.ckboxEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckboxEstado.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ckboxEstado.Location = new System.Drawing.Point(125, 119);
            this.ckboxEstado.Name = "ckboxEstado";
            this.ckboxEstado.Size = new System.Drawing.Size(71, 22);
            this.ckboxEstado.TabIndex = 11;
            this.ckboxEstado.Text = "activo";
            this.ckboxEstado.UseVisualStyleBackColor = true;
            // 
            // txtYear
            // 
            this.txtYear.AllowDrop = true;
            this.txtYear.Location = new System.Drawing.Point(111, 70);
            this.txtYear.Name = "txtYear";
            this.txtYear.PlaceholderText = "Ingrese el año del semestre";
            this.txtYear.Size = new System.Drawing.Size(226, 27);
            this.txtYear.TabIndex = 10;
            // 
            // txtCodigo
            // 
            this.txtCodigo.AllowDrop = true;
            this.txtCodigo.Location = new System.Drawing.Point(111, 29);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.PlaceholderText = "Ingrese el código del semestre";
            this.txtCodigo.Size = new System.Drawing.Size(226, 27);
            this.txtCodigo.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(821, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(262, 23);
            this.label8.TabIndex = 8;
            this.label8.Text = "Semanas Totales del Semestre:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(821, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "Semanas de Clase:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(357, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Fecha de Fin:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(357, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 23);
            this.label7.TabIndex = 5;
            this.label7.Text = "Fecha de Inicio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(23, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Estado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(23, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Año:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(23, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Código:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.panel2.Controls.Add(this.btnEliminar);
            this.panel2.Controls.Add(this.btnActualizar);
            this.panel2.Controls.Add(this.dgLstSemestres);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 273);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1394, 498);
            this.panel2.TabIndex = 1;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.LightBlue;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.Font = new System.Drawing.Font("Roboto Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.Location = new System.Drawing.Point(465, 47);
            this.btnEliminar.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(125, 41);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.LightBlue;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnActualizar.Font = new System.Drawing.Font("Roboto Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnActualizar.Location = new System.Drawing.Point(307, 47);
            this.btnActualizar.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(125, 41);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dgLstSemestres
            // 
            this.dgLstSemestres.AllowDrop = true;
            this.dgLstSemestres.AllowUserToAddRows = false;
            this.dgLstSemestres.AllowUserToDeleteRows = false;
            this.dgLstSemestres.AllowUserToResizeColumns = false;
            this.dgLstSemestres.AllowUserToResizeRows = false;
            this.dgLstSemestres.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgLstSemestres.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgLstSemestres.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.dgLstSemestres.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgLstSemestres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLstSemestres.Location = new System.Drawing.Point(78, 105);
            this.dgLstSemestres.Name = "dgLstSemestres";
            this.dgLstSemestres.ReadOnly = true;
            this.dgLstSemestres.RowHeadersWidth = 51;
            this.dgLstSemestres.RowTemplate.Height = 29;
            this.dgLstSemestres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLstSemestres.Size = new System.Drawing.Size(1090, 228);
            this.dgLstSemestres.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Roboto Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(76, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(185, 24);
            this.label9.TabIndex = 5;
            this.label9.Text = "Lista de Semestres";
            // 
            // FrmCRUD_Semestre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 771);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelNewSemestre);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCRUD_Semestre";
            this.Text = "FrmCRUD_Semestre";
            this.Load += new System.EventHandler(this.FrmCRUD_Semestre_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelNewSemestre.ResumeLayout(false);
            this.panelNewSemestre.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLstSemestres)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panelNewSemestre;
        private TextBox txtCodigo;
        private Label label8;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker dtFechaFin;
        private CheckBox ckboxEstado;
        private TextBox txtYear;
        private ComboBox cboxSemanasTotales;
        private DateTimePicker dtFechaInicio;
        private ComboBox cboxSemanasClase;
        private Button btnEliminar;
        private Button btnActualizar;
        private DataGridView dgLstSemestres;
        private Label label9;
        private Button btnNewSemestre;
        private Button btnCloseWin;
        private Button btnGuardar;
    }
}