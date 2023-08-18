namespace Directorio___Presentacion.CRUD_Interfaces
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
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dgLstTpActividades = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.panelNewTpActividad = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtNameTpAct = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNewTpActividad = new System.Windows.Forms.Button();
            this.btnCloseWin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLstTpActividades)).BeginInit();
            this.panelNewTpActividad.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnEliminar);
            this.panel2.Controls.Add(this.btnActualizar);
            this.panel2.Controls.Add(this.dgLstTpActividades);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 273);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1394, 498);
            this.panel2.TabIndex = 5;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.LightBlue;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.Font = new System.Drawing.Font("Roboto Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.Location = new System.Drawing.Point(579, 47);
            this.btnEliminar.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(125, 41);
            this.btnEliminar.TabIndex = 7;
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
            this.btnActualizar.Location = new System.Drawing.Point(421, 47);
            this.btnActualizar.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(125, 41);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
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
            this.label9.Location = new System.Drawing.Point(76, 53);
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
            this.panelNewTpActividad.Size = new System.Drawing.Size(1394, 178);
            this.panelNewTpActividad.TabIndex = 6;
            this.panelNewTpActividad.Visible = false;
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
            this.btnGuardar.Location = new System.Drawing.Point(794, 29);
            this.btnGuardar.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(125, 41);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
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
            this.panel1.Controls.Add(this.btnNewTpActividad);
            this.panel1.Controls.Add(this.btnCloseWin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1394, 95);
            this.panel1.TabIndex = 4;
            // 
            // btnNewTpActividad
            // 
            this.btnNewTpActividad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewTpActividad.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnNewTpActividad.FlatAppearance.BorderSize = 0;
            this.btnNewTpActividad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewTpActividad.Font = new System.Drawing.Font("Roboto Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNewTpActividad.Location = new System.Drawing.Point(598, 31);
            this.btnNewTpActividad.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnNewTpActividad.Name = "btnNewTpActividad";
            this.btnNewTpActividad.Size = new System.Drawing.Size(125, 36);
            this.btnNewTpActividad.TabIndex = 6;
            this.btnNewTpActividad.Text = "Nuevo";
            this.btnNewTpActividad.UseVisualStyleBackColor = false;
            this.btnNewTpActividad.Click += new System.EventHandler(this.btnNewTpActividad_Click);
            // 
            // btnCloseWin
            // 
            this.btnCloseWin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseWin.BackColor = System.Drawing.Color.LightCoral;
            this.btnCloseWin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCloseWin.Font = new System.Drawing.Font("Roboto Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCloseWin.Location = new System.Drawing.Point(1253, 14);
            this.btnCloseWin.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnCloseWin.Name = "btnCloseWin";
            this.btnCloseWin.Size = new System.Drawing.Size(125, 36);
            this.btnCloseWin.TabIndex = 5;
            this.btnCloseWin.Text = "Cerrar";
            this.btnCloseWin.UseVisualStyleBackColor = false;
            this.btnCloseWin.Click += new System.EventHandler(this.btnCloseWin_Click);
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
            // FrmCRUD_TipoActividad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1394, 771);
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
        private Button btnEliminar;
        private Button btnActualizar;
        private DataGridView dgLstTpActividades;
        private Label label9;
        private Panel panelNewTpActividad;
        private Button btnGuardar;
        private TextBox txtDescripcion;
        private TextBox txtNameTpAct;
        private Label label3;
        private Label label2;
        private Panel panel1;
        private Button btnNewTpActividad;
        private Button btnCloseWin;
        private Label label1;
    }
}