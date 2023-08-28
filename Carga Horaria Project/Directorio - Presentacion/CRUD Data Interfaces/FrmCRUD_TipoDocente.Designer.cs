namespace Directorio___Presentacion.CRUD_Interfaces
{
    partial class FrmCRUD_TipoDocente
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
            this.label1 = new System.Windows.Forms.Label();
            this.panelNewTpActividad = new System.Windows.Forms.Panel();
            this.txtHorasExigibles = new System.Windows.Forms.TextBox();
            this.txtNameTpDoc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgLstTpDocentes = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnCloseWin = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelNewTpActividad.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLstTpDocentes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnCloseWin);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1394, 95);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(33, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(425, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "ADMINISTRAR TIPOS DE DOCENTES";
            // 
            // panelNewTpActividad
            // 
            this.panelNewTpActividad.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelNewTpActividad.Controls.Add(this.btnGuardar);
            this.panelNewTpActividad.Controls.Add(this.txtHorasExigibles);
            this.panelNewTpActividad.Controls.Add(this.txtNameTpDoc);
            this.panelNewTpActividad.Controls.Add(this.label3);
            this.panelNewTpActividad.Controls.Add(this.label2);
            this.panelNewTpActividad.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNewTpActividad.Location = new System.Drawing.Point(0, 95);
            this.panelNewTpActividad.Name = "panelNewTpActividad";
            this.panelNewTpActividad.Size = new System.Drawing.Size(1394, 178);
            this.panelNewTpActividad.TabIndex = 7;
            this.panelNewTpActividad.Visible = false;
            // 
            // txtHorasExigibles
            // 
            this.txtHorasExigibles.AllowDrop = true;
            this.txtHorasExigibles.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtHorasExigibles.Location = new System.Drawing.Point(191, 70);
            this.txtHorasExigibles.Name = "txtHorasExigibles";
            this.txtHorasExigibles.PlaceholderText = "Ingrese el numero de horas exigibles";
            this.txtHorasExigibles.Size = new System.Drawing.Size(458, 32);
            this.txtHorasExigibles.TabIndex = 10;
            this.txtHorasExigibles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorasExigibles_KeyPress);
            // 
            // txtNameTpDoc
            // 
            this.txtNameTpDoc.AllowDrop = true;
            this.txtNameTpDoc.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNameTpDoc.Location = new System.Drawing.Point(191, 29);
            this.txtNameTpDoc.Name = "txtNameTpDoc";
            this.txtNameTpDoc.PlaceholderText = "Ingrese el nombre del tipo de docente";
            this.txtNameTpDoc.Size = new System.Drawing.Size(458, 32);
            this.txtNameTpDoc.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(23, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Horas Exigibles:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(23, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo de docente:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnEliminar);
            this.panel2.Controls.Add(this.btnActualizar);
            this.panel2.Controls.Add(this.dgLstTpDocentes);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 273);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1394, 498);
            this.panel2.TabIndex = 8;
            // 
            // dgLstTpDocentes
            // 
            this.dgLstTpDocentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLstTpDocentes.Location = new System.Drawing.Point(78, 105);
            this.dgLstTpDocentes.Name = "dgLstTpDocentes";
            this.dgLstTpDocentes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgLstTpDocentes.RowTemplate.Height = 29;
            this.dgLstTpDocentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLstTpDocentes.Size = new System.Drawing.Size(744, 381);
            this.dgLstTpDocentes.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Roboto Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(76, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(253, 24);
            this.label9.TabIndex = 5;
            this.label9.Text = "Lista de Tipos de Docentes";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnEliminar.AutoSize = true;
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(116)))), ((int)(((byte)(91)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.ForeColor = System.Drawing.Color.Transparent;
            this.btnEliminar.Image = global::Directorio___Presentacion.Properties.Resources.DEL2white;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(657, 31);
            this.btnEliminar.MaximumSize = new System.Drawing.Size(162, 46);
            this.btnEliminar.MinimumSize = new System.Drawing.Size(162, 46);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnEliminar.Size = new System.Drawing.Size(162, 46);
            this.btnEliminar.TabIndex = 52;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnActualizar.AutoSize = true;
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(116)))), ((int)(((byte)(91)))));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnActualizar.ForeColor = System.Drawing.Color.Transparent;
            this.btnActualizar.Image = global::Directorio___Presentacion.Properties.Resources.EDIT1white;
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.Location = new System.Drawing.Point(446, 31);
            this.btnActualizar.MaximumSize = new System.Drawing.Size(162, 46);
            this.btnActualizar.MinimumSize = new System.Drawing.Size(162, 46);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnActualizar.Size = new System.Drawing.Size(162, 46);
            this.btnActualizar.TabIndex = 51;
            this.btnActualizar.Text = "EDITAR";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
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
            this.btnCloseWin.Location = new System.Drawing.Point(1204, 32);
            this.btnCloseWin.MaximumSize = new System.Drawing.Size(162, 46);
            this.btnCloseWin.MinimumSize = new System.Drawing.Size(162, 46);
            this.btnCloseWin.Name = "btnCloseWin";
            this.btnCloseWin.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnCloseWin.Size = new System.Drawing.Size(162, 46);
            this.btnCloseWin.TabIndex = 40;
            this.btnCloseWin.Text = "CERRAR";
            this.btnCloseWin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCloseWin.UseVisualStyleBackColor = false;
            this.btnCloseWin.Click += new System.EventHandler(this.btnCloseWin_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(58)))), ((int)(((byte)(97)))));
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNew.ForeColor = System.Drawing.Color.Transparent;
            this.btnNew.Image = global::Directorio___Presentacion.Properties.Resources.add1white;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(572, 32);
            this.btnNew.MaximumSize = new System.Drawing.Size(162, 46);
            this.btnNew.MinimumSize = new System.Drawing.Size(162, 46);
            this.btnNew.Name = "btnNew";
            this.btnNew.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnNew.Size = new System.Drawing.Size(162, 46);
            this.btnNew.TabIndex = 39;
            this.btnNew.Text = "NUEVO";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
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
            this.btnGuardar.Location = new System.Drawing.Point(1204, 62);
            this.btnGuardar.MaximumSize = new System.Drawing.Size(162, 46);
            this.btnGuardar.MinimumSize = new System.Drawing.Size(162, 46);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnGuardar.Size = new System.Drawing.Size(162, 46);
            this.btnGuardar.TabIndex = 48;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmCRUD_TipoDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1394, 771);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelNewTpActividad);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCRUD_TipoDocente";
            this.Text = "FrmTipoDocente";
            this.Load += new System.EventHandler(this.FrmTipoDocente_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelNewTpActividad.ResumeLayout(false);
            this.panelNewTpActividad.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLstTpDocentes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panelNewTpActividad;
        private TextBox txtNameTpDoc;
        private Label label3;
        private Label label2;
        private Panel panel2;
        private DataGridView dgLstTpDocentes;
        private Label label9;
        private TextBox txtHorasExigibles;
        private Button btnEliminar;
        private Button btnActualizar;
        private Button btnCloseWin;
        private Button btnNew;
        private Button btnGuardar;
    }
}