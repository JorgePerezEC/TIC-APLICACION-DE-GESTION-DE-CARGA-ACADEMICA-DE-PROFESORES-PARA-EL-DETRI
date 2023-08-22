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
            this.panelTipoDocente = new System.Windows.Forms.Panel();
            this.panelTableContainer = new System.Windows.Forms.Panel();
            this.dgvAdminHorasTipoDocente = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbSemestre = new System.Windows.Forms.ComboBox();
            this.lblSemestre = new System.Windows.Forms.Label();
            this.panelTpDocente = new System.Windows.Forms.Panel();
            this.btnGuardar = new MaterialSkin.Controls.MaterialButton();
            this.btnCancelar = new MaterialSkin.Controls.MaterialButton();
            this.btnEditar = new MaterialSkin.Controls.MaterialButton();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panelAdminDocentes = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.dgvDocenteSemestre = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panelAdminDocentes2 = new System.Windows.Forms.Panel();
            this.panelTipoDocente.SuspendLayout();
            this.panelTableContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdminHorasTipoDocente)).BeginInit();
            this.panel3.SuspendLayout();
            this.panelTpDocente.SuspendLayout();
            this.panelAdminDocentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocenteSemestre)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelAdminDocentes2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTipoDocente
            // 
            this.panelTipoDocente.BackColor = System.Drawing.Color.SteelBlue;
            this.panelTipoDocente.Controls.Add(this.panelTableContainer);
            this.panelTipoDocente.Controls.Add(this.panel3);
            this.panelTipoDocente.Controls.Add(this.panelTpDocente);
            this.panelTipoDocente.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTipoDocente.Location = new System.Drawing.Point(0, 0);
            this.panelTipoDocente.Name = "panelTipoDocente";
            this.panelTipoDocente.Size = new System.Drawing.Size(356, 955);
            this.panelTipoDocente.TabIndex = 0;
            // 
            // panelTableContainer
            // 
            this.panelTableContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(213)))), ((int)(((byte)(197)))));
            this.panelTableContainer.Controls.Add(this.dgvAdminHorasTipoDocente);
            this.panelTableContainer.Controls.Add(this.label1);
            this.panelTableContainer.Location = new System.Drawing.Point(12, 141);
            this.panelTableContainer.Name = "panelTableContainer";
            this.panelTableContainer.Size = new System.Drawing.Size(335, 668);
            this.panelTableContainer.TabIndex = 3;
            this.panelTableContainer.Visible = false;
            // 
            // dgvAdminHorasTipoDocente
            // 
            this.dgvAdminHorasTipoDocente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdminHorasTipoDocente.Enabled = false;
            this.dgvAdminHorasTipoDocente.Location = new System.Drawing.Point(3, 98);
            this.dgvAdminHorasTipoDocente.Name = "dgvAdminHorasTipoDocente";
            this.dgvAdminHorasTipoDocente.RowHeadersWidth = 51;
            this.dgvAdminHorasTipoDocente.RowTemplate.Height = 29;
            this.dgvAdminHorasTipoDocente.Size = new System.Drawing.Size(329, 552);
            this.dgvAdminHorasTipoDocente.TabIndex = 15;
            this.dgvAdminHorasTipoDocente.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdminHorasTipoDocente_CellEndEdit);
            this.dgvAdminHorasTipoDocente.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvAdminHorasTipoDocente_CellValidating);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkRed;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "ADMINISTRAR TIPO DE DOCENTE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.PowderBlue;
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
            this.panelTpDocente.Controls.Add(this.btnGuardar);
            this.panelTpDocente.Controls.Add(this.btnCancelar);
            this.panelTpDocente.Controls.Add(this.btnEditar);
            this.panelTpDocente.Location = new System.Drawing.Point(3, 141);
            this.panelTpDocente.Name = "panelTpDocente";
            this.panelTpDocente.Size = new System.Drawing.Size(347, 775);
            this.panelTpDocente.TabIndex = 6;
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSize = false;
            this.btnGuardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGuardar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnGuardar.Depth = 0;
            this.btnGuardar.HighEmphasis = true;
            this.btnGuardar.Icon = null;
            this.btnGuardar.Location = new System.Drawing.Point(28, 677);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnGuardar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnGuardar.Size = new System.Drawing.Size(94, 30);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnGuardar.UseAccentColor = false;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = false;
            this.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancelar.Depth = 0;
            this.btnCancelar.HighEmphasis = true;
            this.btnCancelar.Icon = null;
            this.btnCancelar.Location = new System.Drawing.Point(232, 677);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancelar.Size = new System.Drawing.Size(94, 30);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancelar.UseAccentColor = false;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.AutoSize = false;
            this.btnEditar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEditar.Depth = 0;
            this.btnEditar.HighEmphasis = true;
            this.btnEditar.Icon = null;
            this.btnEditar.Location = new System.Drawing.Point(130, 677);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEditar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEditar.Size = new System.Drawing.Size(94, 30);
            this.btnEditar.TabIndex = 15;
            this.btnEditar.Text = "EDITAR";
            this.btnEditar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEditar.UseAccentColor = false;
            this.btnEditar.UseVisualStyleBackColor = true;
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
            // panelAdminDocentes
            // 
            this.panelAdminDocentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.panelAdminDocentes.Controls.Add(this.label10);
            this.panelAdminDocentes.Controls.Add(this.txtFiltro);
            this.panelAdminDocentes.Controls.Add(this.dgvDocenteSemestre);
            this.panelAdminDocentes.Location = new System.Drawing.Point(0, 131);
            this.panelAdminDocentes.Name = "panelAdminDocentes";
            this.panelAdminDocentes.Size = new System.Drawing.Size(1568, 824);
            this.panelAdminDocentes.TabIndex = 10;
            this.panelAdminDocentes.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(20, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(203, 28);
            this.label10.TabIndex = 14;
            this.label10.Text = "Buscar por Docente:";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFiltro.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtFiltro.Location = new System.Drawing.Point(238, 26);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.PlaceholderText = "Docente ...";
            this.txtFiltro.Size = new System.Drawing.Size(293, 30);
            this.txtFiltro.TabIndex = 7;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            this.txtFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltro_KeyPress);
            // 
            // dgvDocenteSemestre
            // 
            this.dgvDocenteSemestre.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.dgvDocenteSemestre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDocenteSemestre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocenteSemestre.Location = new System.Drawing.Point(20, 84);
            this.dgvDocenteSemestre.Name = "dgvDocenteSemestre";
            this.dgvDocenteSemestre.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvDocenteSemestre.RowTemplate.Height = 29;
            this.dgvDocenteSemestre.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocenteSemestre.Size = new System.Drawing.Size(1249, 701);
            this.dgvDocenteSemestre.TabIndex = 8;
            this.dgvDocenteSemestre.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocenteSemestre_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PowderBlue;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1568, 125);
            this.panel1.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Roboto Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(43, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(743, 37);
            this.label7.TabIndex = 8;
            this.label7.Text = "ADMINISTRAR DOCENTES ACTIVOS POR SEMESTRE";
            // 
            // panelAdminDocentes2
            // 
            this.panelAdminDocentes2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.panelAdminDocentes2.Controls.Add(this.panel1);
            this.panelAdminDocentes2.Controls.Add(this.panelAdminDocentes);
            this.panelAdminDocentes2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAdminDocentes2.Location = new System.Drawing.Point(356, 0);
            this.panelAdminDocentes2.Name = "panelAdminDocentes2";
            this.panelAdminDocentes2.Size = new System.Drawing.Size(1568, 955);
            this.panelAdminDocentes2.TabIndex = 1;
            // 
            // FrmManageSmstData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1924, 955);
            this.Controls.Add(this.panelAdminDocentes2);
            this.Controls.Add(this.panelTipoDocente);
            this.Name = "FrmManageSmstData";
            this.Text = "Frm_Manage_Docente_DataBySemestre";
            this.Load += new System.EventHandler(this.FrmManageSmstData_Load);
            this.panelTipoDocente.ResumeLayout(false);
            this.panelTableContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdminHorasTipoDocente)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelTpDocente.ResumeLayout(false);
            this.panelAdminDocentes.ResumeLayout(false);
            this.panelAdminDocentes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocenteSemestre)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelAdminDocentes2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panelTipoDocente;
        private Panel panel3;
        private ComboBox cmbSemestre;
        private Label lblSemestre;
        private Label label1;
        private Panel panelTableContainer;
        private PrintPreviewDialog printPreviewDialog1;
        private Panel panelTpDocente;
        private Panel panelAdminDocentes;
        private DataGridView dgvDocenteSemestre;
        private Panel panel1;
        private Label label7;
        private Panel panelAdminDocentes2;
        private Label label10;
        private TextBox txtFiltro;
        private DataGridView dgvAdminHorasTipoDocente;
        private MaterialSkin.Controls.MaterialButton btnGuardar;
        private MaterialSkin.Controls.MaterialButton btnCancelar;
        private MaterialSkin.Controls.MaterialButton btnEditar;
    }
}