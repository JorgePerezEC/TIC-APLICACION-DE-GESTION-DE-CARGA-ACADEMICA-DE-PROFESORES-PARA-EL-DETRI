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
            this.panelInfoDocentes = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbSemestre = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvReporteCargasDocentes = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panelInfoDocentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteCargasDocentes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.panelInfoDocentes);
            this.panel1.Controls.Add(this.cmbSemestre);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1423, 187);
            this.panel1.TabIndex = 0;
            // 
            // panelInfoDocentes
            // 
            this.panelInfoDocentes.Controls.Add(this.tableLayoutPanel1);
            this.panelInfoDocentes.Location = new System.Drawing.Point(794, 12);
            this.panelInfoDocentes.Name = "panelInfoDocentes";
            this.panelInfoDocentes.Size = new System.Drawing.Size(578, 160);
            this.panelInfoDocentes.TabIndex = 18;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.38462F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.61538F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(25, 9);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.80952F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.19048F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(481, 129);
            this.tableLayoutPanel1.TabIndex = 17;
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
            this.label1.Size = new System.Drawing.Size(705, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "REPORTE DE CARGAS ACADÉMICAS DE DOCENTES";
            // 
            // dgvReporteCargasDocentes
            // 
            this.dgvReporteCargasDocentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporteCargasDocentes.Location = new System.Drawing.Point(51, 223);
            this.dgvReporteCargasDocentes.Name = "dgvReporteCargasDocentes";
            this.dgvReporteCargasDocentes.RowHeadersWidth = 51;
            this.dgvReporteCargasDocentes.RowTemplate.Height = 29;
            this.dgvReporteCargasDocentes.Size = new System.Drawing.Size(1296, 467);
            this.dgvReporteCargasDocentes.TabIndex = 1;
            // 
            // FrmReporteDocentesCargas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1423, 809);
            this.Controls.Add(this.dgvReporteCargasDocentes);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReporteDocentesCargas";
            this.Text = "Reporte de Cargas de Docentes";
            this.Load += new System.EventHandler(this.FrmReporteDocentesCargas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelInfoDocentes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteCargasDocentes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private ComboBox cmbSemestre;
        private Label label7;
        private Panel panelInfoDocentes;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dgvReporteCargasDocentes;
    }
}