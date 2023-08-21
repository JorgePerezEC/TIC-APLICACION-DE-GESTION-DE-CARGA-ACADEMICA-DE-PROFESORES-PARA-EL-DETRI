namespace Directorio___Presentacion.Reportes_Frms
{
    partial class FrmReporteDocentesCargas
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
            this.panelFilters = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rbNoFilter = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.rbSiCumple = new System.Windows.Forms.RadioButton();
            this.rbNoCumple = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.panelInfoDocentes = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSemestre = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvReporteCargasDocentes = new System.Windows.Forms.DataGridView();
            this.btnExportAll = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panelFilters.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelInfoDocentes.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteCargasDocentes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.panelFilters);
            this.panel1.Controls.Add(this.panelInfoDocentes);
            this.panel1.Controls.Add(this.cmbSemestre);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1528, 246);
            this.panel1.TabIndex = 0;
            // 
            // panelFilters
            // 
            this.panelFilters.Controls.Add(this.tableLayoutPanel2);
            this.panelFilters.Controls.Add(this.label15);
            this.panelFilters.Location = new System.Drawing.Point(51, 105);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(310, 125);
            this.panelFilters.TabIndex = 2;
            this.panelFilters.TabStop = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.SlateGray;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.86339F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.13661F));
            this.tableLayoutPanel2.Controls.Add(this.rbNoFilter, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label14, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label13, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbSiCumple, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbNoCumple, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(124, 28);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(183, 97);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // rbNoFilter
            // 
            this.rbNoFilter.AutoSize = true;
            this.rbNoFilter.Checked = true;
            this.rbNoFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbNoFilter.Location = new System.Drawing.Point(140, 67);
            this.rbNoFilter.Name = "rbNoFilter";
            this.rbNoFilter.Size = new System.Drawing.Size(40, 27);
            this.rbNoFilter.TabIndex = 23;
            this.rbNoFilter.TabStop = true;
            this.rbNoFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbNoFilter.UseVisualStyleBackColor = true;
            this.rbNoFilter.CheckedChanged += new System.EventHandler(this.rbNoFilter_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(3, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(131, 33);
            this.label14.TabIndex = 21;
            this.label14.Text = "TODOS";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(3, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(131, 32);
            this.label13.TabIndex = 20;
            this.label13.Text = "NO CUMPLE";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(131, 32);
            this.label12.TabIndex = 0;
            this.label12.Text = "SÍ CUMPLE";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbSiCumple
            // 
            this.rbSiCumple.AutoSize = true;
            this.rbSiCumple.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbSiCumple.Location = new System.Drawing.Point(140, 3);
            this.rbSiCumple.Name = "rbSiCumple";
            this.rbSiCumple.Size = new System.Drawing.Size(40, 26);
            this.rbSiCumple.TabIndex = 21;
            this.rbSiCumple.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbSiCumple.UseVisualStyleBackColor = true;
            this.rbSiCumple.CheckedChanged += new System.EventHandler(this.rbSiCumple_CheckedChanged);
            // 
            // rbNoCumple
            // 
            this.rbNoCumple.AutoSize = true;
            this.rbNoCumple.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbNoCumple.Location = new System.Drawing.Point(140, 35);
            this.rbNoCumple.Name = "rbNoCumple";
            this.rbNoCumple.Size = new System.Drawing.Size(40, 26);
            this.rbNoCumple.TabIndex = 22;
            this.rbNoCumple.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbNoCumple.UseVisualStyleBackColor = true;
            this.rbNoCumple.CheckedChanged += new System.EventHandler(this.rbNoCumple_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(3, 29);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 27);
            this.label15.TabIndex = 20;
            this.label15.Text = "Filtro";
            // 
            // panelInfoDocentes
            // 
            this.panelInfoDocentes.Controls.Add(this.tableLayoutPanel1);
            this.panelInfoDocentes.Location = new System.Drawing.Point(794, 12);
            this.panelInfoDocentes.Name = "panelInfoDocentes";
            this.panelInfoDocentes.Size = new System.Drawing.Size(578, 218);
            this.panelInfoDocentes.TabIndex = 18;
            this.panelInfoDocentes.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.53846F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.46154F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(25, 9);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(481, 190);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.AliceBlue;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(328, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 65);
            this.label11.TabIndex = 8;
            this.label11.Text = "#";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.AliceBlue;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(216, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 65);
            this.label10.TabIndex = 7;
            this.label10.Text = "#";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.AliceBlue;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(328, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 60);
            this.label9.TabIndex = 6;
            this.label9.Text = "#";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.AliceBlue;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(216, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 60);
            this.label8.TabIndex = 5;
            this.label8.Text = "#";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.IndianRed;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(328, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 65);
            this.label6.TabIndex = 4;
            this.label6.Text = "#";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 65);
            this.label2.TabIndex = 0;
            this.label2.Text = "Docentes registrados en el semestre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 60);
            this.label3.TabIndex = 1;
            this.label3.Text = "Docentes que cumplen con horas exigibles";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 65);
            this.label4.TabIndex = 2;
            this.label4.Text = "Docentes que no cumplen con horas exigibles";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.PaleGreen;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(216, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 65);
            this.label5.TabIndex = 3;
            this.label5.Text = "#";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbSemestre
            // 
            this.cmbSemestre.BackColor = System.Drawing.Color.LemonChiffon;
            this.cmbSemestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemestre.FormattingEnabled = true;
            this.cmbSemestre.Location = new System.Drawing.Point(176, 71);
            this.cmbSemestre.Name = "cmbSemestre";
            this.cmbSemestre.Size = new System.Drawing.Size(182, 28);
            this.cmbSemestre.TabIndex = 1;
            this.cmbSemestre.SelectedIndexChanged += new System.EventHandler(this.cmbSemestre_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(51, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 27);
            this.label7.TabIndex = 15;
            this.label7.Text = "Semestre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(47, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(705, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "REPORTE DE CARGAS ACADÉMICAS DE DOCENTES";
            // 
            // dgvReporteCargasDocentes
            // 
            this.dgvReporteCargasDocentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporteCargasDocentes.Location = new System.Drawing.Point(47, 349);
            this.dgvReporteCargasDocentes.Name = "dgvReporteCargasDocentes";
            this.dgvReporteCargasDocentes.RowHeadersWidth = 51;
            this.dgvReporteCargasDocentes.RowTemplate.Height = 29;
            this.dgvReporteCargasDocentes.Size = new System.Drawing.Size(1296, 597);
            this.dgvReporteCargasDocentes.TabIndex = 1;
            this.dgvReporteCargasDocentes.TabStop = false;
            this.dgvReporteCargasDocentes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvReporteCargasDocentes_CellFormatting);
            // 
            // btnExportAll
            // 
            this.btnExportAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnExportAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExportAll.Location = new System.Drawing.Point(1365, 292);
            this.btnExportAll.Name = "btnExportAll";
            this.btnExportAll.Size = new System.Drawing.Size(140, 70);
            this.btnExportAll.TabIndex = 3;
            this.btnExportAll.Text = "EXPORTAR TODOS EN PDF";
            this.btnExportAll.UseVisualStyleBackColor = false;
            this.btnExportAll.Visible = false;
            this.btnExportAll.Click += new System.EventHandler(this.btnExportAll_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            this.lblSearch.Location = new System.Drawing.Point(54, 281);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(203, 28);
            this.lblSearch.TabIndex = 16;
            this.lblSearch.Text = "Buscar por Docente:";
            this.lblSearch.Visible = false;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFiltro.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtFiltro.Location = new System.Drawing.Point(272, 279);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.PlaceholderText = "Docente ...";
            this.txtFiltro.Size = new System.Drawing.Size(493, 30);
            this.txtFiltro.TabIndex = 15;
            this.txtFiltro.Visible = false;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            this.txtFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltro_KeyPress);
            // 
            // FrmReporteDocentesCargas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1528, 958);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.btnExportAll);
            this.Controls.Add(this.dgvReporteCargasDocentes);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReporteDocentesCargas";
            this.Text = "Reporte de Cargas de Docentes";
            this.Load += new System.EventHandler(this.FrmReporteDocentesCargas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panelInfoDocentes.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteCargasDocentes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private ComboBox cmbSemestre;
        private Label label7;
        private Panel panelInfoDocentes;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dgvReporteCargasDocentes;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label6;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label13;
        private Label label12;
        private RadioButton rbSiCumple;
        private RadioButton rbNoCumple;
        private RadioButton rbNoFilter;
        private Label label14;
        private Label label15;
        private Panel panelFilters;
        private Button btnExportAll;
        private Label lblSearch;
        private TextBox txtFiltro;
    }
}