﻿namespace Directorio___Presentacion.AcademicLoads_Interfaces.Activate_Data_Frms
{
    partial class FrmManageAsigSmst
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
            this.panelSelector = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSemestre = new System.Windows.Forms.ComboBox();
            this.lblSemestre = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.dgvAsignaturasSemestre = new System.Windows.Forms.DataGridView();
            this.panelSelector.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignaturasSemestre)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSelector
            // 
            this.panelSelector.BackColor = System.Drawing.Color.Khaki;
            this.panelSelector.Controls.Add(this.label1);
            this.panelSelector.Controls.Add(this.cmbSemestre);
            this.panelSelector.Controls.Add(this.lblSemestre);
            this.panelSelector.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSelector.Location = new System.Drawing.Point(0, 0);
            this.panelSelector.Name = "panelSelector";
            this.panelSelector.Size = new System.Drawing.Size(1412, 158);
            this.panelSelector.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Coral;
            this.label1.Font = new System.Drawing.Font("Roboto Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(39, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(641, 37);
            this.label1.TabIndex = 10;
            this.label1.Text = "Administrar Asignaturas Activas por Semestre";
            // 
            // cmbSemestre
            // 
            this.cmbSemestre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSemestre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSemestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemestre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSemestre.FormattingEnabled = true;
            this.cmbSemestre.Location = new System.Drawing.Point(39, 109);
            this.cmbSemestre.Name = "cmbSemestre";
            this.cmbSemestre.Size = new System.Drawing.Size(151, 28);
            this.cmbSemestre.TabIndex = 3;
            this.cmbSemestre.SelectedIndexChanged += new System.EventHandler(this.cmbSemestre_SelectedIndexChanged);
            // 
            // lblSemestre
            // 
            this.lblSemestre.AutoSize = true;
            this.lblSemestre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSemestre.Location = new System.Drawing.Point(39, 67);
            this.lblSemestre.Name = "lblSemestre";
            this.lblSemestre.Size = new System.Drawing.Size(233, 28);
            this.lblSemestre.TabIndex = 2;
            this.lblSemestre.Text = "Seleccione el Semestre:";
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.dgvAsignaturasSemestre);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 158);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1412, 587);
            this.panelContent.TabIndex = 1;
            // 
            // dgvAsignaturasSemestre
            // 
            this.dgvAsignaturasSemestre.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.dgvAsignaturasSemestre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAsignaturasSemestre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsignaturasSemestre.Location = new System.Drawing.Point(39, 31);
            this.dgvAsignaturasSemestre.Name = "dgvAsignaturasSemestre";
            this.dgvAsignaturasSemestre.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvAsignaturasSemestre.RowTemplate.Height = 29;
            this.dgvAsignaturasSemestre.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsignaturasSemestre.Size = new System.Drawing.Size(917, 533);
            this.dgvAsignaturasSemestre.TabIndex = 10;
            this.dgvAsignaturasSemestre.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAsignaturasSemestre_CellContentClick);
            // 
            // FrmManageAsigSmst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1412, 745);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelSelector);
            this.Name = "FrmManageAsigSmst";
            this.Text = "FrmManageAsigSmst";
            this.Load += new System.EventHandler(this.FrmManageAsigSmst_Load);
            this.panelSelector.ResumeLayout(false);
            this.panelSelector.PerformLayout();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignaturasSemestre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelSelector;
        private ComboBox cmbSemestre;
        private Label lblSemestre;
        private Panel panelContent;
        private Label label1;
        private DataGridView dgvAsignaturasSemestre;
    }
}