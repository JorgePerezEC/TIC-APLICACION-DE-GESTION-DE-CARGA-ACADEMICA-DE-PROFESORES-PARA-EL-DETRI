namespace Directorio___Presentacion.CRUD_Data_Interfaces
{
    partial class FrmCRUD_Proyecto
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dgLstRegistros = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.panelCreate = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPresupuesto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtNameProyecto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCloseWin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLstRegistros)).BeginInit();
            this.panelCreate.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtFiltro);
            this.panel2.Controls.Add(this.btnEliminar);
            this.panel2.Controls.Add(this.btnActualizar);
            this.panel2.Controls.Add(this.dgLstRegistros);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 419);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1604, 362);
            this.panel2.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(96, 101);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 28);
            this.label14.TabIndex = 18;
            this.label14.Text = "Filtrar:";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFiltro.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtFiltro.Location = new System.Drawing.Point(177, 99);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.PlaceholderText = "...";
            this.txtFiltro.Size = new System.Drawing.Size(510, 30);
            this.txtFiltro.TabIndex = 17;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            this.txtFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltro_KeyPress);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.LightBlue;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.Font = new System.Drawing.Font("Roboto Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.Location = new System.Drawing.Point(562, 34);
            this.btnEliminar.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(125, 41);
            this.btnEliminar.TabIndex = 31;
            this.btnEliminar.TabStop = false;
            this.btnEliminar.Text = "ELIMINAR";
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
            this.btnActualizar.Location = new System.Drawing.Point(364, 34);
            this.btnActualizar.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(125, 41);
            this.btnActualizar.TabIndex = 30;
            this.btnActualizar.TabStop = false;
            this.btnActualizar.Text = "ACTUALIZAR";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dgLstRegistros
            // 
            this.dgLstRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLstRegistros.Location = new System.Drawing.Point(95, 152);
            this.dgLstRegistros.Name = "dgLstRegistros";
            this.dgLstRegistros.RowHeadersWidth = 51;
            this.dgLstRegistros.RowTemplate.Height = 29;
            this.dgLstRegistros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLstRegistros.Size = new System.Drawing.Size(1405, 327);
            this.dgLstRegistros.TabIndex = 6;
            this.dgLstRegistros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLstRegistros_CellContentClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Roboto Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(95, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(178, 24);
            this.label9.TabIndex = 5;
            this.label9.Text = "Lista de Proyectos";
            // 
            // panelCreate
            // 
            this.panelCreate.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelCreate.Controls.Add(this.label10);
            this.panelCreate.Controls.Add(this.txtPresupuesto);
            this.panelCreate.Controls.Add(this.label8);
            this.panelCreate.Controls.Add(this.txtType);
            this.panelCreate.Controls.Add(this.txtURL);
            this.panelCreate.Controls.Add(this.label5);
            this.panelCreate.Controls.Add(this.label7);
            this.panelCreate.Controls.Add(this.dtFechaInicio);
            this.panelCreate.Controls.Add(this.dtFechaFin);
            this.panelCreate.Controls.Add(this.label6);
            this.panelCreate.Controls.Add(this.label4);
            this.panelCreate.Controls.Add(this.txtCode);
            this.panelCreate.Controls.Add(this.btnCancelar);
            this.panelCreate.Controls.Add(this.btnGuardar);
            this.panelCreate.Controls.Add(this.txtNameProyecto);
            this.panelCreate.Controls.Add(this.label3);
            this.panelCreate.Controls.Add(this.label2);
            this.panelCreate.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCreate.Location = new System.Drawing.Point(0, 95);
            this.panelCreate.Name = "panelCreate";
            this.panelCreate.Size = new System.Drawing.Size(1604, 324);
            this.panelCreate.TabIndex = 12;
            this.panelCreate.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(927, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 24);
            this.label10.TabIndex = 36;
            this.label10.Text = "Ejemplo: 1234,55";
            // 
            // txtPresupuesto
            // 
            this.txtPresupuesto.AllowDrop = true;
            this.txtPresupuesto.Location = new System.Drawing.Point(927, 145);
            this.txtPresupuesto.Name = "txtPresupuesto";
            this.txtPresupuesto.PlaceholderText = "XXX,XX";
            this.txtPresupuesto.Size = new System.Drawing.Size(251, 32);
            this.txtPresupuesto.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(754, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 24);
            this.label8.TabIndex = 34;
            this.label8.Text = "Presupuesto {$}: ";
            // 
            // txtType
            // 
            this.txtType.AllowDrop = true;
            this.txtType.Location = new System.Drawing.Point(201, 163);
            this.txtType.Name = "txtType";
            this.txtType.PlaceholderText = "Ingrese el tipo de proyecto";
            this.txtType.Size = new System.Drawing.Size(391, 32);
            this.txtType.TabIndex = 4;
            // 
            // txtURL
            // 
            this.txtURL.AllowDrop = true;
            this.txtURL.Location = new System.Drawing.Point(200, 214);
            this.txtURL.Multiline = true;
            this.txtURL.Name = "txtURL";
            this.txtURL.PlaceholderText = "Ingrese el URL del documento del aval";
            this.txtURL.Size = new System.Drawing.Size(977, 65);
            this.txtURL.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(28, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 24);
            this.label5.TabIndex = 31;
            this.label5.Text = "URL del AVAL:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(29, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 24);
            this.label7.TabIndex = 30;
            this.label7.Text = "Tipo: ";
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaInicio.Location = new System.Drawing.Point(927, 37);
            this.dtFechaInicio.MaxDate = new System.DateTime(8970, 1, 31, 0, 0, 0, 0);
            this.dtFechaInicio.MinDate = new System.DateTime(1753, 1, 11, 0, 0, 0, 0);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(251, 32);
            this.dtFechaInicio.TabIndex = 5;
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFin.Location = new System.Drawing.Point(927, 92);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(251, 32);
            this.dtFechaFin.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(754, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 24);
            this.label6.TabIndex = 27;
            this.label6.Text = "Fecha de Fin:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(754, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 24);
            this.label4.TabIndex = 26;
            this.label4.Text = "Fecha de Inicio:";
            // 
            // txtCode
            // 
            this.txtCode.AllowDrop = true;
            this.txtCode.Location = new System.Drawing.Point(202, 34);
            this.txtCode.Name = "txtCode";
            this.txtCode.PlaceholderText = "Ingrese el código del proyecto";
            this.txtCode.Size = new System.Drawing.Size(391, 32);
            this.txtCode.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Roboto Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(1257, 139);
            this.btnCancelar.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(125, 41);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            this.btnGuardar.Location = new System.Drawing.Point(1257, 58);
            this.btnGuardar.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(125, 41);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtNameProyecto
            // 
            this.txtNameProyecto.AllowDrop = true;
            this.txtNameProyecto.Location = new System.Drawing.Point(201, 85);
            this.txtNameProyecto.Multiline = true;
            this.txtNameProyecto.Name = "txtNameProyecto";
            this.txtNameProyecto.PlaceholderText = "Ingrese el nombre del proyecto";
            this.txtNameProyecto.Size = new System.Drawing.Size(392, 59);
            this.txtNameProyecto.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(29, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(29, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Código: ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnCloseWin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1604, 95);
            this.panel1.TabIndex = 10;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Roboto Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNew.Location = new System.Drawing.Point(433, 39);
            this.btnNew.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(125, 30);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "NUEVO";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCloseWin
            // 
            this.btnCloseWin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseWin.BackColor = System.Drawing.Color.LightCoral;
            this.btnCloseWin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCloseWin.Font = new System.Drawing.Font("Roboto Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCloseWin.Location = new System.Drawing.Point(1220, 39);
            this.btnCloseWin.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnCloseWin.Name = "btnCloseWin";
            this.btnCloseWin.Size = new System.Drawing.Size(125, 24);
            this.btnCloseWin.TabIndex = 5;
            this.btnCloseWin.Text = "CERRAR";
            this.btnCloseWin.UseVisualStyleBackColor = false;
            this.btnCloseWin.Click += new System.EventHandler(this.btnCloseWin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(29, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "ADMNISTRAR PROYECTOS";
            // 
            // FrmCRUD_Proyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1604, 781);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelCreate);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmCRUD_Proyecto";
            this.Text = "FrmCRUD_Proyecto";
            this.Load += new System.EventHandler(this.FrmCRUD_Proyecto_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLstRegistros)).EndInit();
            this.panelCreate.ResumeLayout(false);
            this.panelCreate.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel2;
        private Label label14;
        private TextBox txtFiltro;
        private Button btnEliminar;
        private Button btnActualizar;
        private DataGridView dgLstRegistros;
        private Label label9;
        private Panel panelCreate;
        private Button btnGuardar;
        private TextBox txtNameProyecto;
        private Label label3;
        private Label label2;
        private Panel panel1;
        private Button btnNew;
        private Button btnCloseWin;
        private Label label1;
        private Button btnCancelar;
        private TextBox txtCode;
        private TextBox txtType;
        private TextBox txtURL;
        private Label label5;
        private Label label7;
        private DateTimePicker dtFechaInicio;
        private DateTimePicker dtFechaFin;
        private Label label6;
        private Label label4;
        private Label label8;
        private Label label10;
        private TextBox txtPresupuesto;
    }
}