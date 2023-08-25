namespace Directorio___Presentacion
{
    partial class FrmCRUD_Actividad
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panelProyectos = new System.Windows.Forms.Panel();
            this.txtCodeProyecto = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.pictBoxAval = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPresupuesto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbProyectos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ckboxTotal = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ckboxSemanal = new System.Windows.Forms.CheckBox();
            this.txtHorasTotales = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHorasSemanales = new System.Windows.Forms.TextBox();
            this.cmbTpActiv = new System.Windows.Forms.ComboBox();
            this.panelCheckProyecto = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.cbProyecto = new MaterialSkin.Controls.MaterialCheckbox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtNameActividad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCloseWin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLstRegistros)).BeginInit();
            this.panelCreate.SuspendLayout();
            this.panelProyectos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxAval)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelCheckProyecto.SuspendLayout();
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
            this.panel2.Location = new System.Drawing.Point(0, 435);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1604, 540);
            this.panel2.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(96, 87);
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
            this.txtFiltro.Location = new System.Drawing.Point(177, 85);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.PlaceholderText = "...";
            this.txtFiltro.Size = new System.Drawing.Size(535, 30);
            this.txtFiltro.TabIndex = 30;
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
            this.btnEliminar.Location = new System.Drawing.Point(576, 20);
            this.btnEliminar.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(125, 41);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.TabStop = false;
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
            this.btnActualizar.Location = new System.Drawing.Point(378, 20);
            this.btnActualizar.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(125, 41);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.TabStop = false;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dgLstRegistros
            // 
            this.dgLstRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLstRegistros.Location = new System.Drawing.Point(95, 138);
            this.dgLstRegistros.Name = "dgLstRegistros";
            this.dgLstRegistros.RowHeadersWidth = 51;
            this.dgLstRegistros.RowTemplate.Height = 29;
            this.dgLstRegistros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLstRegistros.Size = new System.Drawing.Size(1405, 312);
            this.dgLstRegistros.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Roboto Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(95, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(194, 24);
            this.label9.TabIndex = 5;
            this.label9.Text = "Lista de Actividades";
            // 
            // panelCreate
            // 
            this.panelCreate.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelCreate.Controls.Add(this.btnCancelar);
            this.panelCreate.Controls.Add(this.panelProyectos);
            this.panelCreate.Controls.Add(this.label11);
            this.panelCreate.Controls.Add(this.tableLayoutPanel2);
            this.panelCreate.Controls.Add(this.txtHorasTotales);
            this.panelCreate.Controls.Add(this.label5);
            this.panelCreate.Controls.Add(this.txtHorasSemanales);
            this.panelCreate.Controls.Add(this.cmbTpActiv);
            this.panelCreate.Controls.Add(this.panelCheckProyecto);
            this.panelCreate.Controls.Add(this.btnGuardar);
            this.panelCreate.Controls.Add(this.txtNameActividad);
            this.panelCreate.Controls.Add(this.label7);
            this.panelCreate.Controls.Add(this.label3);
            this.panelCreate.Controls.Add(this.label2);
            this.panelCreate.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCreate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.panelCreate.Location = new System.Drawing.Point(0, 95);
            this.panelCreate.Name = "panelCreate";
            this.panelCreate.Size = new System.Drawing.Size(1604, 340);
            this.panelCreate.TabIndex = 9;
            this.panelCreate.Visible = false;
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
            this.btnCancelar.Location = new System.Drawing.Point(1431, 108);
            this.btnCancelar.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(125, 41);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panelProyectos
            // 
            this.panelProyectos.Controls.Add(this.txtCodeProyecto);
            this.panelProyectos.Controls.Add(this.label17);
            this.panelProyectos.Controls.Add(this.pictBoxAval);
            this.panelProyectos.Controls.Add(this.label16);
            this.panelProyectos.Controls.Add(this.txtPresupuesto);
            this.panelProyectos.Controls.Add(this.label8);
            this.panelProyectos.Controls.Add(this.dtFechaInicio);
            this.panelProyectos.Controls.Add(this.dtFechaFin);
            this.panelProyectos.Controls.Add(this.label10);
            this.panelProyectos.Controls.Add(this.label15);
            this.panelProyectos.Controls.Add(this.cmbProyectos);
            this.panelProyectos.Controls.Add(this.label4);
            this.panelProyectos.Location = new System.Drawing.Point(29, 187);
            this.panelProyectos.Name = "panelProyectos";
            this.panelProyectos.Size = new System.Drawing.Size(1342, 147);
            this.panelProyectos.TabIndex = 24;
            this.panelProyectos.Visible = false;
            // 
            // txtCodeProyecto
            // 
            this.txtCodeProyecto.AllowDrop = true;
            this.txtCodeProyecto.Enabled = false;
            this.txtCodeProyecto.Location = new System.Drawing.Point(104, 97);
            this.txtCodeProyecto.Name = "txtCodeProyecto";
            this.txtCodeProyecto.Size = new System.Drawing.Size(317, 32);
            this.txtCodeProyecto.TabIndex = 45;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(3, 100);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 24);
            this.label17.TabIndex = 44;
            this.label17.Text = "Código: ";
            // 
            // pictBoxAval
            // 
            this.pictBoxAval.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictBoxAval.Location = new System.Drawing.Point(1217, 41);
            this.pictBoxAval.Name = "pictBoxAval";
            this.pictBoxAval.Size = new System.Drawing.Size(77, 62);
            this.pictBoxAval.TabIndex = 43;
            this.pictBoxAval.TabStop = false;
            this.pictBoxAval.Visible = false;
            this.pictBoxAval.Click += new System.EventHandler(this.pictBoxAval_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(1153, 58);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 24);
            this.label16.TabIndex = 42;
            this.label16.Text = "AVAL:";
            // 
            // txtPresupuesto
            // 
            this.txtPresupuesto.AllowDrop = true;
            this.txtPresupuesto.Enabled = false;
            this.txtPresupuesto.Location = new System.Drawing.Point(879, 111);
            this.txtPresupuesto.Name = "txtPresupuesto";
            this.txtPresupuesto.PlaceholderText = "XXX,XX";
            this.txtPresupuesto.Size = new System.Drawing.Size(251, 32);
            this.txtPresupuesto.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(706, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 24);
            this.label8.TabIndex = 40;
            this.label8.Text = "Presupuesto {$}: ";
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.Enabled = false;
            this.dtFechaInicio.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaInicio.Location = new System.Drawing.Point(879, 3);
            this.dtFechaInicio.MaxDate = new System.DateTime(8970, 1, 31, 0, 0, 0, 0);
            this.dtFechaInicio.MinDate = new System.DateTime(1753, 1, 11, 0, 0, 0, 0);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(251, 32);
            this.dtFechaInicio.TabIndex = 36;
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Enabled = false;
            this.dtFechaFin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFin.Location = new System.Drawing.Point(879, 58);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(251, 32);
            this.dtFechaFin.TabIndex = 37;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(706, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 24);
            this.label10.TabIndex = 39;
            this.label10.Text = "Fecha de Fin:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(706, 4);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(140, 24);
            this.label15.TabIndex = 38;
            this.label15.Text = "Fecha de Inicio:";
            // 
            // cmbProyectos
            // 
            this.cmbProyectos.Enabled = false;
            this.cmbProyectos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProyectos.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbProyectos.FormattingEnabled = true;
            this.cmbProyectos.Items.AddRange(new object[] {
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
            this.cmbProyectos.Location = new System.Drawing.Point(104, 24);
            this.cmbProyectos.Name = "cmbProyectos";
            this.cmbProyectos.Size = new System.Drawing.Size(579, 32);
            this.cmbProyectos.TabIndex = 20;
            this.cmbProyectos.SelectedIndexChanged += new System.EventHandler(this.cbProyectos_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(3, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 24);
            this.label4.TabIndex = 19;
            this.label4.Text = "Proyecto: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(735, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(296, 24);
            this.label11.TabIndex = 23;
            this.label11.Text = "Estilo de horas para  la Actividad: ";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.03825F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.96175F));
            this.tableLayoutPanel2.Controls.Add(this.ckboxTotal, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ckboxSemanal, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1033, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.42529F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(126, 48);
            this.tableLayoutPanel2.TabIndex = 22;
            // 
            // ckboxTotal
            // 
            this.ckboxTotal.AutoSize = true;
            this.ckboxTotal.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckboxTotal.FlatAppearance.BorderSize = 2;
            this.ckboxTotal.Location = new System.Drawing.Point(92, 27);
            this.ckboxTotal.Name = "ckboxTotal";
            this.ckboxTotal.Size = new System.Drawing.Size(18, 17);
            this.ckboxTotal.TabIndex = 5;
            this.ckboxTotal.UseVisualStyleBackColor = true;
            this.ckboxTotal.CheckedChanged += new System.EventHandler(this.ckboxTotal_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(3, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 24);
            this.label12.TabIndex = 2;
            this.label12.Text = "Totales";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(3, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 24);
            this.label13.TabIndex = 0;
            this.label13.Text = "Semanales";
            // 
            // ckboxSemanal
            // 
            this.ckboxSemanal.AutoSize = true;
            this.ckboxSemanal.Checked = true;
            this.ckboxSemanal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckboxSemanal.FlatAppearance.BorderSize = 2;
            this.ckboxSemanal.Location = new System.Drawing.Point(92, 3);
            this.ckboxSemanal.Name = "ckboxSemanal";
            this.ckboxSemanal.Size = new System.Drawing.Size(18, 17);
            this.ckboxSemanal.TabIndex = 4;
            this.ckboxSemanal.UseVisualStyleBackColor = true;
            this.ckboxSemanal.CheckedChanged += new System.EventHandler(this.ckboxSemanal_CheckedChanged);
            // 
            // txtHorasTotales
            // 
            this.txtHorasTotales.AllowDrop = true;
            this.txtHorasTotales.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtHorasTotales.Location = new System.Drawing.Point(1033, 125);
            this.txtHorasTotales.Name = "txtHorasTotales";
            this.txtHorasTotales.PlaceholderText = "Ingrese la duración total de la actvidad";
            this.txtHorasTotales.Size = new System.Drawing.Size(338, 32);
            this.txtHorasTotales.TabIndex = 7;
            this.txtHorasTotales.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorasSemanales_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(735, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(256, 24);
            this.label5.TabIndex = 20;
            this.label5.Text = "Horas Totales de la actividad:";
            // 
            // txtHorasSemanales
            // 
            this.txtHorasSemanales.AllowDrop = true;
            this.txtHorasSemanales.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtHorasSemanales.Location = new System.Drawing.Point(1033, 70);
            this.txtHorasSemanales.Name = "txtHorasSemanales";
            this.txtHorasSemanales.PlaceholderText = "Ingrese la duración de la actvidad";
            this.txtHorasSemanales.Size = new System.Drawing.Size(338, 32);
            this.txtHorasSemanales.TabIndex = 6;
            this.txtHorasSemanales.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorasSemanales_KeyPress);
            // 
            // cmbTpActiv
            // 
            this.cmbTpActiv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTpActiv.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbTpActiv.FormattingEnabled = true;
            this.cmbTpActiv.Items.AddRange(new object[] {
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
            this.cmbTpActiv.Location = new System.Drawing.Point(199, 17);
            this.cmbTpActiv.Name = "cmbTpActiv";
            this.cmbTpActiv.Size = new System.Drawing.Size(513, 32);
            this.cmbTpActiv.TabIndex = 2;
            this.cmbTpActiv.SelectedIndexChanged += new System.EventHandler(this.cmbTpActiv_SelectedIndexChanged);
            // 
            // panelCheckProyecto
            // 
            this.panelCheckProyecto.ColumnCount = 2;
            this.panelCheckProyecto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.2F));
            this.panelCheckProyecto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.8F));
            this.panelCheckProyecto.Controls.Add(this.label6, 1, 0);
            this.panelCheckProyecto.Controls.Add(this.cbProyecto, 0, 0);
            this.panelCheckProyecto.Location = new System.Drawing.Point(32, 142);
            this.panelCheckProyecto.Name = "panelCheckProyecto";
            this.panelCheckProyecto.RowCount = 1;
            this.panelCheckProyecto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelCheckProyecto.Size = new System.Drawing.Size(250, 36);
            this.panelCheckProyecto.TabIndex = 22;
            this.panelCheckProyecto.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(46, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 36);
            this.label6.TabIndex = 23;
            this.label6.Text = "Proyecto";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbProyecto
            // 
            this.cbProyecto.AutoSize = true;
            this.cbProyecto.Depth = 0;
            this.cbProyecto.Location = new System.Drawing.Point(0, 0);
            this.cbProyecto.Margin = new System.Windows.Forms.Padding(0);
            this.cbProyecto.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbProyecto.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbProyecto.Name = "cbProyecto";
            this.cbProyecto.ReadOnly = false;
            this.cbProyecto.Ripple = true;
            this.cbProyecto.Size = new System.Drawing.Size(35, 36);
            this.cbProyecto.TabIndex = 21;
            this.cbProyecto.UseVisualStyleBackColor = true;
            this.cbProyecto.CheckedChanged += new System.EventHandler(this.cbProyecto_CheckedChanged);
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
            this.btnGuardar.Location = new System.Drawing.Point(1431, 23);
            this.btnGuardar.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(125, 41);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtNameActividad
            // 
            this.txtNameActividad.AllowDrop = true;
            this.txtNameActividad.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNameActividad.Location = new System.Drawing.Point(199, 68);
            this.txtNameActividad.Multiline = true;
            this.txtNameActividad.Name = "txtNameActividad";
            this.txtNameActividad.PlaceholderText = "Ingrese el nombre de la actividad";
            this.txtNameActividad.Size = new System.Drawing.Size(513, 68);
            this.txtNameActividad.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(735, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(286, 24);
            this.label7.TabIndex = 5;
            this.label7.Text = "Horas Semanales de la actividad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(29, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(29, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo de Actividad: ";
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
            this.panel1.TabIndex = 7;
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
            this.btnNew.Size = new System.Drawing.Size(125, 35);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "Nuevo";
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
            this.btnCloseWin.Location = new System.Drawing.Point(1431, 33);
            this.btnCloseWin.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnCloseWin.Name = "btnCloseWin";
            this.btnCloseWin.Size = new System.Drawing.Size(125, 41);
            this.btnCloseWin.TabIndex = 5;
            this.btnCloseWin.TabStop = false;
            this.btnCloseWin.Text = "Cerrar";
            this.btnCloseWin.UseVisualStyleBackColor = false;
            this.btnCloseWin.Click += new System.EventHandler(this.btnCloseWin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(29, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "ADMNISTRAR ACTIVIDADES";
            // 
            // FrmCRUD_Actividad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1604, 975);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelCreate);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCRUD_Actividad";
            this.Text = "CRUD_Actividad";
            this.Load += new System.EventHandler(this.FrmCRUD_Actividad_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLstRegistros)).EndInit();
            this.panelCreate.ResumeLayout(false);
            this.panelCreate.PerformLayout();
            this.panelProyectos.ResumeLayout(false);
            this.panelProyectos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxAval)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panelCheckProyecto.ResumeLayout(false);
            this.panelCheckProyecto.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel2;
        private Button btnActualizar;
        private DataGridView dgLstRegistros;
        private Label label9;
        private Panel panelCreate;
        private TextBox txtHorasSemanales;
        private ComboBox cmbTpActiv;
        private Button btnGuardar;
        private TextBox txtNameActividad;
        private Label label7;
        private Label label3;
        private Label label2;
        private Panel panel1;
        private Button btnNew;
        private Button btnCloseWin;
        private Label label1;
        private TextBox txtHorasTotales;
        private Label label5;
        private Button btnEliminar;
        private Label label11;
        private TableLayoutPanel tableLayoutPanel2;
        private CheckBox ckboxTotal;
        private Label label12;
        private Label label13;
        private CheckBox ckboxSemanal;
        private Label label14;
        private TextBox txtFiltro;
        private Panel panelProyectos;
        private ComboBox cmbProyectos;
        private Label label4;
        private TableLayoutPanel panelCheckProyecto;
        private Label label6;
        private MaterialSkin.Controls.MaterialCheckbox cbProyecto;
        private TextBox txtPresupuesto;
        private Label label8;
        private DateTimePicker dtFechaInicio;
        private DateTimePicker dtFechaFin;
        private Label label10;
        private Label label15;
        private Button btnCancelar;
        private PictureBox pictBoxAval;
        private Label label16;
        private TextBox txtCodeProyecto;
        private Label label17;
    }
}