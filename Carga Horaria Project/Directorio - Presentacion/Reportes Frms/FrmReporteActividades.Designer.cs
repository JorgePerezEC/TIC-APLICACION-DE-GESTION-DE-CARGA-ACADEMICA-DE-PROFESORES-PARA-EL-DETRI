namespace Directorio___Presentacion.Reportes_Frms
{
    partial class FrmReporteActividades
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
            this.panelDataShow = new System.Windows.Forms.Panel();
            this.btnExportPdf = new System.Windows.Forms.Button();
            this.panelLecturaDiv = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtB = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.rbD11 = new System.Windows.Forms.RadioButton();
            this.rbF11 = new System.Windows.Forms.RadioButton();
            this.rbNoFilter = new System.Windows.Forms.RadioButton();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNumNoDocente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNumSiDocente = new System.Windows.Forms.Label();
            this.cmbSemestre = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDataShow.SuspendLayout();
            this.panelLecturaDiv.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelFilters.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDataShow
            // 
            this.panelDataShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.panelDataShow.Controls.Add(this.btnExportPdf);
            this.panelDataShow.Controls.Add(this.panelLecturaDiv);
            this.panelDataShow.Controls.Add(this.label14);
            this.panelDataShow.Controls.Add(this.txtFiltro);
            this.panelDataShow.Controls.Add(this.dgvReporte);
            this.panelDataShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDataShow.Location = new System.Drawing.Point(0, 246);
            this.panelDataShow.Name = "panelDataShow";
            this.panelDataShow.Size = new System.Drawing.Size(1633, 719);
            this.panelDataShow.TabIndex = 6;
            // 
            // btnExportPdf
            // 
            this.btnExportPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnExportPdf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExportPdf.Location = new System.Drawing.Point(1374, 86);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new System.Drawing.Size(140, 70);
            this.btnExportPdf.TabIndex = 18;
            this.btnExportPdf.Text = "EXPORTAR  EN PDF";
            this.btnExportPdf.UseVisualStyleBackColor = false;
            this.btnExportPdf.Visible = false;
            this.btnExportPdf.Click += new System.EventHandler(this.btnExportPdf_Click);
            // 
            // panelLecturaDiv
            // 
            this.panelLecturaDiv.Controls.Add(this.tableLayoutPanel3);
            this.panelLecturaDiv.Location = new System.Drawing.Point(921, 6);
            this.panelLecturaDiv.Name = "panelLecturaDiv";
            this.panelLecturaDiv.Size = new System.Drawing.Size(422, 74);
            this.panelLecturaDiv.TabIndex = 15;
            this.panelLecturaDiv.Visible = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtB, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(21, 11);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(309, 49);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Gainsboro;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 49);
            this.label5.TabIndex = 0;
            this.label5.Text = "Lectura";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtB
            // 
            this.txtB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtB.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtB.Location = new System.Drawing.Point(157, 3);
            this.txtB.Multiline = true;
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(149, 43);
            this.txtB.TabIndex = 1;
            this.txtB.Text = "1";
            this.txtB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtB.TextChanged += new System.EventHandler(this.txtB_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(47, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 28);
            this.label14.TabIndex = 14;
            this.label14.Text = "Filtrar:";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFiltro.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtFiltro.Location = new System.Drawing.Point(139, 36);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.PlaceholderText = "...";
            this.txtFiltro.Size = new System.Drawing.Size(328, 30);
            this.txtFiltro.TabIndex = 13;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            this.txtFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltro_KeyPress);
            // 
            // dgvReporte
            // 
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Location = new System.Drawing.Point(47, 86);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.RowHeadersWidth = 51;
            this.dgvReporte.RowTemplate.Height = 29;
            this.dgvReporte.Size = new System.Drawing.Size(1296, 566);
            this.dgvReporte.TabIndex = 2;
            this.dgvReporte.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.panelFilters);
            this.panel1.Controls.Add(this.panelInfo);
            this.panel1.Controls.Add(this.cmbSemestre);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1633, 246);
            this.panel1.TabIndex = 5;
            // 
            // panelFilters
            // 
            this.panelFilters.Controls.Add(this.tableLayoutPanel2);
            this.panelFilters.Location = new System.Drawing.Point(51, 105);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(498, 125);
            this.panelFilters.TabIndex = 21;
            this.panelFilters.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.SlateGray;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label13, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbD11, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbF11, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.rbNoFilter, 1, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(348, 106);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(289, 36);
            this.label4.TabIndex = 23;
            this.label4.Text = "Mostrar todas las Actividades";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(3, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(289, 35);
            this.label13.TabIndex = 20;
            this.label13.Text = "Actividades Fuera del 1:1";
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
            this.label12.Size = new System.Drawing.Size(289, 35);
            this.label12.TabIndex = 0;
            this.label12.Text = "Actividades Dentro del 1:1";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbD11
            // 
            this.rbD11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbD11.AutoSize = true;
            this.rbD11.Location = new System.Drawing.Point(298, 3);
            this.rbD11.Name = "rbD11";
            this.rbD11.Size = new System.Drawing.Size(47, 29);
            this.rbD11.TabIndex = 21;
            this.rbD11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbD11.UseVisualStyleBackColor = true;
            this.rbD11.CheckedChanged += new System.EventHandler(this.rbD11_CheckedChanged);
            // 
            // rbF11
            // 
            this.rbF11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbF11.AutoSize = true;
            this.rbF11.Location = new System.Drawing.Point(298, 38);
            this.rbF11.Name = "rbF11";
            this.rbF11.Size = new System.Drawing.Size(47, 29);
            this.rbF11.TabIndex = 22;
            this.rbF11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbF11.UseVisualStyleBackColor = true;
            this.rbF11.CheckedChanged += new System.EventHandler(this.rbF11_CheckedChanged);
            // 
            // rbNoFilter
            // 
            this.rbNoFilter.AutoSize = true;
            this.rbNoFilter.Checked = true;
            this.rbNoFilter.Location = new System.Drawing.Point(298, 73);
            this.rbNoFilter.Name = "rbNoFilter";
            this.rbNoFilter.Size = new System.Drawing.Size(17, 16);
            this.rbNoFilter.TabIndex = 24;
            this.rbNoFilter.TabStop = true;
            this.rbNoFilter.UseVisualStyleBackColor = true;
            this.rbNoFilter.CheckedChanged += new System.EventHandler(this.rbNoFilter_CheckedChanged);
            // 
            // panelInfo
            // 
            this.panelInfo.Controls.Add(this.tableLayoutPanel1);
            this.panelInfo.Location = new System.Drawing.Point(996, 22);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(578, 173);
            this.panelInfo.TabIndex = 18;
            this.panelInfo.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.lblNumNoDocente, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNumSiDocente, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(40, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(481, 99);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // lblNumNoDocente
            // 
            this.lblNumNoDocente.AutoSize = true;
            this.lblNumNoDocente.BackColor = System.Drawing.Color.AliceBlue;
            this.lblNumNoDocente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNumNoDocente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumNoDocente.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNumNoDocente.ForeColor = System.Drawing.Color.Black;
            this.lblNumNoDocente.Location = new System.Drawing.Point(411, 49);
            this.lblNumNoDocente.Name = "lblNumNoDocente";
            this.lblNumNoDocente.Size = new System.Drawing.Size(67, 50);
            this.lblNumNoDocente.TabIndex = 5;
            this.lblNumNoDocente.Text = "#";
            this.lblNumNoDocente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(402, 49);
            this.label2.TabIndex = 0;
            this.label2.Text = "Asignaturas (GRs) con Docente asignado";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(402, 50);
            this.label3.TabIndex = 1;
            this.label3.Text = "Asignaturas (GRs) sin Docente asignado";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumSiDocente
            // 
            this.lblNumSiDocente.AutoSize = true;
            this.lblNumSiDocente.BackColor = System.Drawing.Color.White;
            this.lblNumSiDocente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNumSiDocente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumSiDocente.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNumSiDocente.ForeColor = System.Drawing.Color.Black;
            this.lblNumSiDocente.Location = new System.Drawing.Point(411, 0);
            this.lblNumSiDocente.Name = "lblNumSiDocente";
            this.lblNumSiDocente.Size = new System.Drawing.Size(67, 49);
            this.lblNumSiDocente.TabIndex = 3;
            this.lblNumSiDocente.Text = "#";
            this.lblNumSiDocente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbSemestre
            // 
            this.cmbSemestre.BackColor = System.Drawing.Color.LemonChiffon;
            this.cmbSemestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemestre.FormattingEnabled = true;
            this.cmbSemestre.Location = new System.Drawing.Point(176, 71);
            this.cmbSemestre.Name = "cmbSemestre";
            this.cmbSemestre.Size = new System.Drawing.Size(167, 28);
            this.cmbSemestre.TabIndex = 16;
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
            this.label1.Size = new System.Drawing.Size(928, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "REPORTE DE ACTIVIDADES ASIGNADAS EN CARGAS ACADÉMICAS";
            // 
            // FrmReporteActividades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1633, 965);
            this.Controls.Add(this.panelDataShow);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReporteActividades";
            this.Text = "FrmReporteActividades";
            this.Load += new System.EventHandler(this.FrmReporteActividades_Load);
            this.panelDataShow.ResumeLayout(false);
            this.panelDataShow.PerformLayout();
            this.panelLecturaDiv.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelFilters.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelDataShow;
        private Label label14;
        private TextBox txtFiltro;
        private DataGridView dgvReporte;
        private Panel panel1;
        private Panel panelFilters;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label13;
        private Label label12;
        private RadioButton rbD11;
        private RadioButton rbF11;
        private Panel panelInfo;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblNumNoDocente;
        private Label label2;
        private Label label3;
        private Label lblNumSiDocente;
        private ComboBox cmbSemestre;
        private Label label7;
        private Label label1;
        private Label label4;
        private RadioButton rbNoFilter;
        private Panel panelLecturaDiv;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label5;
        private TextBox txtB;
        private Button btnExportPdf;
    }
}