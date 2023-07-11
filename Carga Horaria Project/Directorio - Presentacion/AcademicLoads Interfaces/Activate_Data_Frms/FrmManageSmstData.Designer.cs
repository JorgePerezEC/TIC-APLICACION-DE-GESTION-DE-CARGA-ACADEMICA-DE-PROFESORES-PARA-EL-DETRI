namespace Directorio___Presentacion.AcademicLoads_Interfaces.Activate_Data_Frms
{
    partial class FrmManageSmstData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManageSmstData));
            this.panelAdminDocentes = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvDocenteSemestre = new System.Windows.Forms.DataGridView();
            this.panelTipoDocente = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbSemestre = new System.Windows.Forms.ComboBox();
            this.lblSemestre = new System.Windows.Forms.Label();
            this.panelTpDocente = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panelTableContainer = new System.Windows.Forms.Panel();
            this.tblPanelHorasExigibles = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTiempoCompleto = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtH_TTP = new System.Windows.Forms.TextBox();
            this.txtH_OTC = new System.Windows.Forms.TextBox();
            this.txtH_OTP = new System.Windows.Forms.TextBox();
            this.txtH_TC = new System.Windows.Forms.TextBox();
            this.txtH_TP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtH_TTC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panelAdminDocentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocenteSemestre)).BeginInit();
            this.panelTipoDocente.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelTpDocente.SuspendLayout();
            this.panelTableContainer.SuspendLayout();
            this.tblPanelHorasExigibles.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAdminDocentes
            // 
            this.panelAdminDocentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.panelAdminDocentes.Controls.Add(this.label7);
            this.panelAdminDocentes.Controls.Add(this.dgvDocenteSemestre);
            this.panelAdminDocentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAdminDocentes.Location = new System.Drawing.Point(356, 0);
            this.panelAdminDocentes.Name = "panelAdminDocentes";
            this.panelAdminDocentes.Size = new System.Drawing.Size(1568, 955);
            this.panelAdminDocentes.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Coral;
            this.label7.Font = new System.Drawing.Font("Roboto Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(43, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(606, 37);
            this.label7.TabIndex = 8;
            this.label7.Text = "Administrar Docentes Activos por Semestre";
            // 
            // dgvDocenteSemestre
            // 
            this.dgvDocenteSemestre.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.dgvDocenteSemestre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDocenteSemestre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocenteSemestre.Location = new System.Drawing.Point(43, 118);
            this.dgvDocenteSemestre.Name = "dgvDocenteSemestre";
            this.dgvDocenteSemestre.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvDocenteSemestre.RowTemplate.Height = 29;
            this.dgvDocenteSemestre.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocenteSemestre.Size = new System.Drawing.Size(1249, 784);
            this.dgvDocenteSemestre.TabIndex = 7;
            this.dgvDocenteSemestre.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocenteSemestre_CellContentClick);
            this.dgvDocenteSemestre.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDocenteSemestre_CellPainting);
            // 
            // panelTipoDocente
            // 
            this.panelTipoDocente.BackColor = System.Drawing.Color.SteelBlue;
            this.panelTipoDocente.Controls.Add(this.panel3);
            this.panelTipoDocente.Controls.Add(this.panelTpDocente);
            this.panelTipoDocente.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTipoDocente.Location = new System.Drawing.Point(0, 0);
            this.panelTipoDocente.Name = "panelTipoDocente";
            this.panelTipoDocente.Size = new System.Drawing.Size(356, 955);
            this.panelTipoDocente.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Khaki;
            this.panel3.Controls.Add(this.cmbSemestre);
            this.panel3.Controls.Add(this.lblSemestre);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(356, 125);
            this.panel3.TabIndex = 1;
            // 
            // cmbSemestre
            // 
            this.cmbSemestre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSemestre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSemestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemestre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSemestre.FormattingEnabled = true;
            this.cmbSemestre.Location = new System.Drawing.Point(12, 66);
            this.cmbSemestre.Name = "cmbSemestre";
            this.cmbSemestre.Size = new System.Drawing.Size(151, 28);
            this.cmbSemestre.TabIndex = 1;
            this.cmbSemestre.SelectedIndexChanged += new System.EventHandler(this.cmbSemestre_SelectedIndexChanged);
            // 
            // lblSemestre
            // 
            this.lblSemestre.AutoSize = true;
            this.lblSemestre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSemestre.Location = new System.Drawing.Point(12, 24);
            this.lblSemestre.Name = "lblSemestre";
            this.lblSemestre.Size = new System.Drawing.Size(233, 28);
            this.lblSemestre.TabIndex = 0;
            this.lblSemestre.Text = "Seleccione el Semestre:";
            // 
            // panelTpDocente
            // 
            this.panelTpDocente.Controls.Add(this.btnCancelar);
            this.panelTpDocente.Controls.Add(this.panelTableContainer);
            this.panelTpDocente.Controls.Add(this.btnGuardar);
            this.panelTpDocente.Controls.Add(this.btnEditar);
            this.panelTpDocente.Location = new System.Drawing.Point(3, 141);
            this.panelTpDocente.Name = "panelTpDocente";
            this.panelTpDocente.Size = new System.Drawing.Size(326, 775);
            this.panelTpDocente.TabIndex = 6;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(120, 677);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(94, 29);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panelTableContainer
            // 
            this.panelTableContainer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelTableContainer.Controls.Add(this.tblPanelHorasExigibles);
            this.panelTableContainer.Controls.Add(this.label1);
            this.panelTableContainer.Location = new System.Drawing.Point(16, 3);
            this.panelTableContainer.Name = "panelTableContainer";
            this.panelTableContainer.Size = new System.Drawing.Size(307, 668);
            this.panelTableContainer.TabIndex = 3;
            this.panelTableContainer.Visible = false;
            // 
            // tblPanelHorasExigibles
            // 
            this.tblPanelHorasExigibles.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tblPanelHorasExigibles.ColumnCount = 2;
            this.tblPanelHorasExigibles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.56156F));
            this.tblPanelHorasExigibles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.43844F));
            this.tblPanelHorasExigibles.Controls.Add(this.label6, 0, 6);
            this.tblPanelHorasExigibles.Controls.Add(this.lblTiempoCompleto, 0, 1);
            this.tblPanelHorasExigibles.Controls.Add(this.label2, 0, 2);
            this.tblPanelHorasExigibles.Controls.Add(this.label3, 0, 3);
            this.tblPanelHorasExigibles.Controls.Add(this.label5, 0, 5);
            this.tblPanelHorasExigibles.Controls.Add(this.txtH_TTP, 1, 2);
            this.tblPanelHorasExigibles.Controls.Add(this.txtH_OTC, 1, 3);
            this.tblPanelHorasExigibles.Controls.Add(this.txtH_OTP, 1, 4);
            this.tblPanelHorasExigibles.Controls.Add(this.txtH_TC, 1, 5);
            this.tblPanelHorasExigibles.Controls.Add(this.txtH_TP, 1, 6);
            this.tblPanelHorasExigibles.Controls.Add(this.label4, 0, 4);
            this.tblPanelHorasExigibles.Controls.Add(this.label9, 0, 0);
            this.tblPanelHorasExigibles.Controls.Add(this.label8, 1, 0);
            this.tblPanelHorasExigibles.Controls.Add(this.txtH_TTC, 1, 1);
            this.tblPanelHorasExigibles.Location = new System.Drawing.Point(14, 98);
            this.tblPanelHorasExigibles.Name = "tblPanelHorasExigibles";
            this.tblPanelHorasExigibles.RowCount = 7;
            this.tblPanelHorasExigibles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.03753F));
            this.tblPanelHorasExigibles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.21854F));
            this.tblPanelHorasExigibles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28504F));
            this.tblPanelHorasExigibles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28504F));
            this.tblPanelHorasExigibles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28504F));
            this.tblPanelHorasExigibles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.86555F));
            this.tblPanelHorasExigibles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.70588F));
            this.tblPanelHorasExigibles.Size = new System.Drawing.Size(273, 550);
            this.tblPanelHorasExigibles.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.DimGray;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(3, 465);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 85);
            this.label6.TabIndex = 6;
            this.label6.Text = "Tecnico Docente a Tiempo Parcial";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTiempoCompleto
            // 
            this.lblTiempoCompleto.AutoSize = true;
            this.lblTiempoCompleto.BackColor = System.Drawing.Color.DimGray;
            this.lblTiempoCompleto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTiempoCompleto.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTiempoCompleto.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTiempoCompleto.Location = new System.Drawing.Point(3, 60);
            this.lblTiempoCompleto.Name = "lblTiempoCompleto";
            this.lblTiempoCompleto.Size = new System.Drawing.Size(162, 95);
            this.lblTiempoCompleto.TabIndex = 0;
            this.lblTiempoCompleto.Text = "Profesor Titular a Tiempo Completo";
            this.lblTiempoCompleto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(3, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 78);
            this.label2.TabIndex = 2;
            this.label2.Text = "Profesor Titular a Tiempo Parcial";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DimGray;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(3, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 78);
            this.label3.TabIndex = 3;
            this.label3.Text = "Profesor Ocasional a Tiempo Completo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(3, 389);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 76);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tecnico Docente a Tiempo Completo";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtH_TTP
            // 
            this.txtH_TTP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtH_TTP.Location = new System.Drawing.Point(174, 180);
            this.txtH_TTP.Name = "txtH_TTP";
            this.txtH_TTP.Size = new System.Drawing.Size(92, 27);
            this.txtH_TTP.TabIndex = 7;
            this.txtH_TTP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtH_TTP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtH_TTP_KeyPress);
            // 
            // txtH_OTC
            // 
            this.txtH_OTC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtH_OTC.Location = new System.Drawing.Point(174, 258);
            this.txtH_OTC.Name = "txtH_OTC";
            this.txtH_OTC.Size = new System.Drawing.Size(92, 27);
            this.txtH_OTC.TabIndex = 8;
            this.txtH_OTC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtH_OTC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtH_TTP_KeyPress);
            // 
            // txtH_OTP
            // 
            this.txtH_OTP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtH_OTP.Location = new System.Drawing.Point(174, 336);
            this.txtH_OTP.Name = "txtH_OTP";
            this.txtH_OTP.Size = new System.Drawing.Size(92, 27);
            this.txtH_OTP.TabIndex = 9;
            this.txtH_OTP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtH_OTP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtH_TTP_KeyPress);
            // 
            // txtH_TC
            // 
            this.txtH_TC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtH_TC.Location = new System.Drawing.Point(174, 413);
            this.txtH_TC.Name = "txtH_TC";
            this.txtH_TC.Size = new System.Drawing.Size(92, 27);
            this.txtH_TC.TabIndex = 10;
            this.txtH_TC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtH_TC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtH_TTP_KeyPress);
            // 
            // txtH_TP
            // 
            this.txtH_TP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtH_TP.Location = new System.Drawing.Point(174, 494);
            this.txtH_TP.Name = "txtH_TP";
            this.txtH_TP.Size = new System.Drawing.Size(92, 27);
            this.txtH_TP.TabIndex = 11;
            this.txtH_TP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtH_TP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtH_TTP_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DimGray;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(3, 311);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 78);
            this.label4.TabIndex = 4;
            this.label4.Text = "Profesor Ocasional a Tiempo Parcial";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Maroon;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(162, 60);
            this.label9.TabIndex = 13;
            this.label9.Text = "TIPO DE DOCENTE";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Maroon;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(171, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 60);
            this.label8.TabIndex = 14;
            this.label8.Text = "# HORAS EXIGIBLES";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtH_TTC
            // 
            this.txtH_TTC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtH_TTC.Location = new System.Drawing.Point(173, 94);
            this.txtH_TTC.Name = "txtH_TTC";
            this.txtH_TTC.Size = new System.Drawing.Size(94, 27);
            this.txtH_TTC.TabIndex = 1;
            this.txtH_TTC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtH_TTC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtH_TTP_KeyPress);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkRed;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "Administrar Tipo de Docente";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGuardar.Location = new System.Drawing.Point(220, 677);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(94, 29);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditar.Location = new System.Drawing.Point(20, 677);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(94, 29);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "EDITAR";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // FrmManageSmstData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1924, 955);
            this.Controls.Add(this.panelAdminDocentes);
            this.Controls.Add(this.panelTipoDocente);
            this.Name = "FrmManageSmstData";
            this.Text = "Frm_Manage_Docente_DataBySemestre";
            this.Load += new System.EventHandler(this.FrmManageSmstData_Load);
            this.panelAdminDocentes.ResumeLayout(false);
            this.panelAdminDocentes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocenteSemestre)).EndInit();
            this.panelTipoDocente.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelTpDocente.ResumeLayout(false);
            this.panelTableContainer.ResumeLayout(false);
            this.tblPanelHorasExigibles.ResumeLayout(false);
            this.tblPanelHorasExigibles.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelAdminDocentes;
        private Panel panelTipoDocente;
        private TableLayoutPanel tblPanelHorasExigibles;
        private Label lblTiempoCompleto;
        private Panel panel3;
        private ComboBox cmbSemestre;
        private Label lblSemestre;
        private Label label1;
        private Label label6;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtH_TTP;
        private TextBox txtH_OTC;
        private TextBox txtH_OTP;
        private TextBox txtH_TC;
        private TextBox txtH_TP;
        private Button btnGuardar;
        private Button btnEditar;
        private Panel panelTableContainer;
        private DataGridView dgvDocenteSemestre;
        private Label label7;
        private Label label9;
        private Label label8;
        private PrintPreviewDialog printPreviewDialog1;
        private Panel panelTpDocente;
        protected TextBox txtH_TTC;
        private Button btnCancelar;
    }
}