﻿namespace Directorio___Presentacion.CRUD_Interfaces
{
    partial class FrmCRUD_TipoActividad
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
            this.dgLstTpActividades = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.panelNewTpActividad = new System.Windows.Forms.Panel();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtNameTpAct = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCloseWin = new System.Windows.Forms.Button();
            this.btnNewTpActividad = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLstTpActividades)).BeginInit();
            this.panelNewTpActividad.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.dgLstTpActividades);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 273);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1472, 498);
            this.panel2.TabIndex = 5;
            // 
            // dgLstTpActividades
            // 
            this.dgLstTpActividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLstTpActividades.Location = new System.Drawing.Point(76, 104);
            this.dgLstTpActividades.Name = "dgLstTpActividades";
            this.dgLstTpActividades.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgLstTpActividades.RowTemplate.Height = 29;
            this.dgLstTpActividades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLstTpActividades.Size = new System.Drawing.Size(603, 365);
            this.dgLstTpActividades.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Roboto Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(76, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(276, 24);
            this.label9.TabIndex = 5;
            this.label9.Text = "Lista de Tipos de Actividades";
            // 
            // panelNewTpActividad
            // 
            this.panelNewTpActividad.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelNewTpActividad.Controls.Add(this.btnGuardar);
            this.panelNewTpActividad.Controls.Add(this.txtDescripcion);
            this.panelNewTpActividad.Controls.Add(this.txtNameTpAct);
            this.panelNewTpActividad.Controls.Add(this.label3);
            this.panelNewTpActividad.Controls.Add(this.label2);
            this.panelNewTpActividad.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNewTpActividad.Location = new System.Drawing.Point(0, 95);
            this.panelNewTpActividad.Name = "panelNewTpActividad";
            this.panelNewTpActividad.Size = new System.Drawing.Size(1472, 178);
            this.panelNewTpActividad.TabIndex = 6;
            this.panelNewTpActividad.Visible = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.AllowDrop = true;
            this.txtDescripcion.Location = new System.Drawing.Point(295, 70);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.PlaceholderText = "Ingrese una descripción del tipo de actividad";
            this.txtDescripcion.Size = new System.Drawing.Size(452, 85);
            this.txtDescripcion.TabIndex = 10;
            this.txtDescripcion.Text = "\r\n";
            // 
            // txtNameTpAct
            // 
            this.txtNameTpAct.AllowDrop = true;
            this.txtNameTpAct.Location = new System.Drawing.Point(295, 29);
            this.txtNameTpAct.Name = "txtNameTpAct";
            this.txtNameTpAct.PlaceholderText = "Ingrese el nombre del tipo de actividad";
            this.txtNameTpAct.Size = new System.Drawing.Size(452, 27);
            this.txtNameTpAct.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(23, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Descripción:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(23, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre de la Actividad:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnCloseWin);
            this.panel1.Controls.Add(this.btnNewTpActividad);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1472, 95);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(456, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "ADMINISTRAR TIPOS DE ACTIVIDADES";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(116)))), ((int)(((byte)(91)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Image = global::Directorio___Presentacion.Properties.Resources.DEL2white;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(658, 31);
            this.button1.MaximumSize = new System.Drawing.Size(162, 46);
            this.button1.MinimumSize = new System.Drawing.Size(162, 46);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.button1.Size = new System.Drawing.Size(162, 46);
            this.button1.TabIndex = 50;
            this.button1.Text = "ELIMINAR";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(116)))), ((int)(((byte)(91)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Image = global::Directorio___Presentacion.Properties.Resources.EDIT1white;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(447, 31);
            this.button2.MaximumSize = new System.Drawing.Size(162, 46);
            this.button2.MinimumSize = new System.Drawing.Size(162, 46);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.button2.Size = new System.Drawing.Size(162, 46);
            this.button2.TabIndex = 49;
            this.button2.Text = "EDITAR";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnCloseWin
            // 
            this.btnCloseWin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCloseWin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(58)))), ((int)(((byte)(97)))));
            this.btnCloseWin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseWin.FlatAppearance.BorderSize = 0;
            this.btnCloseWin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseWin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCloseWin.ForeColor = System.Drawing.Color.Transparent;
            this.btnCloseWin.Image = global::Directorio___Presentacion.Properties.Resources.cerrar1white;
            this.btnCloseWin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseWin.Location = new System.Drawing.Point(1152, 31);
            this.btnCloseWin.MaximumSize = new System.Drawing.Size(162, 46);
            this.btnCloseWin.MinimumSize = new System.Drawing.Size(162, 46);
            this.btnCloseWin.Name = "btnCloseWin";
            this.btnCloseWin.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnCloseWin.Size = new System.Drawing.Size(162, 46);
            this.btnCloseWin.TabIndex = 38;
            this.btnCloseWin.Text = "CERRAR";
            this.btnCloseWin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCloseWin.UseVisualStyleBackColor = false;
            this.btnCloseWin.Click += new System.EventHandler(this.btnCloseWin_Click);
            // 
            // btnNewTpActividad
            // 
            this.btnNewTpActividad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNewTpActividad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(58)))), ((int)(((byte)(97)))));
            this.btnNewTpActividad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewTpActividad.FlatAppearance.BorderSize = 0;
            this.btnNewTpActividad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewTpActividad.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNewTpActividad.ForeColor = System.Drawing.Color.Transparent;
            this.btnNewTpActividad.Image = global::Directorio___Presentacion.Properties.Resources.add1white;
            this.btnNewTpActividad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewTpActividad.Location = new System.Drawing.Point(520, 31);
            this.btnNewTpActividad.MaximumSize = new System.Drawing.Size(162, 46);
            this.btnNewTpActividad.MinimumSize = new System.Drawing.Size(162, 46);
            this.btnNewTpActividad.Name = "btnNewTpActividad";
            this.btnNewTpActividad.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnNewTpActividad.Size = new System.Drawing.Size(162, 46);
            this.btnNewTpActividad.TabIndex = 37;
            this.btnNewTpActividad.Text = "NUEVO";
            this.btnNewTpActividad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewTpActividad.UseVisualStyleBackColor = false;
            this.btnNewTpActividad.Click += new System.EventHandler(this.btnNewTpActividad_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(58)))), ((int)(((byte)(97)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGuardar.ForeColor = System.Drawing.Color.Transparent;
            this.btnGuardar.Image = global::Directorio___Presentacion.Properties.Resources.SAVE1white;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(1152, 70);
            this.btnGuardar.MaximumSize = new System.Drawing.Size(162, 46);
            this.btnGuardar.MinimumSize = new System.Drawing.Size(162, 46);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnGuardar.Size = new System.Drawing.Size(162, 46);
            this.btnGuardar.TabIndex = 47;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmCRUD_TipoActividad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1472, 771);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelNewTpActividad);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCRUD_TipoActividad";
            this.Text = "FrmCRUD_TipoActividad";
            this.Load += new System.EventHandler(this.FrmCRUD_TipoActividad_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLstTpActividades)).EndInit();
            this.panelNewTpActividad.ResumeLayout(false);
            this.panelNewTpActividad.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel2;
        private DataGridView dgLstTpActividades;
        private Label label9;
        private Panel panelNewTpActividad;
        private TextBox txtDescripcion;
        private TextBox txtNameTpAct;
        private Label label3;
        private Label label2;
        private Panel panel1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button btnCloseWin;
        private Button btnNewTpActividad;
        private Button btnGuardar;
    }
}