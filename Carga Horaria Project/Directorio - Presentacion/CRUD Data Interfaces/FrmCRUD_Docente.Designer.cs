﻿namespace Directorio___Presentacion.CRUD_Interfaces
{
    partial class FrmCRUD_Docente
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
            this.dgLstRegistros = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.panelCreate = new System.Windows.Forms.Panel();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSApellido = new System.Windows.Forms.TextBox();
            this.txtPApellido = new System.Windows.Forms.TextBox();
            this.cmbDepartamentos = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtPNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCloseWin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLstRegistros)).BeginInit();
            this.panelCreate.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtFiltro);
            this.panel2.Controls.Add(this.btnEliminar);
            this.panel2.Controls.Add(this.btnActualizar);
            this.panel2.Controls.Add(this.dgLstRegistros);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 273);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1394, 557);
            this.panel2.TabIndex = 8;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.LightBlue;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.Font = new System.Drawing.Font("Roboto Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.Location = new System.Drawing.Point(465, 47);
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
            this.btnActualizar.Location = new System.Drawing.Point(307, 47);
            this.btnActualizar.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(125, 41);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dgLstRegistros
            // 
            this.dgLstRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLstRegistros.Location = new System.Drawing.Point(76, 164);
            this.dgLstRegistros.Name = "dgLstRegistros";
            this.dgLstRegistros.RowHeadersWidth = 51;
            this.dgLstRegistros.RowTemplate.Height = 29;
            this.dgLstRegistros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLstRegistros.Size = new System.Drawing.Size(716, 381);
            this.dgLstRegistros.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Roboto Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(76, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(171, 24);
            this.label9.TabIndex = 5;
            this.label9.Text = "Lista de Docentes";
            // 
            // panelCreate
            // 
            this.panelCreate.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelCreate.Controls.Add(this.txtTitulo);
            this.panelCreate.Controls.Add(this.label4);
            this.panelCreate.Controls.Add(this.txtSNombre);
            this.panelCreate.Controls.Add(this.label5);
            this.panelCreate.Controls.Add(this.txtSApellido);
            this.panelCreate.Controls.Add(this.txtPApellido);
            this.panelCreate.Controls.Add(this.cmbDepartamentos);
            this.panelCreate.Controls.Add(this.btnGuardar);
            this.panelCreate.Controls.Add(this.txtPNombre);
            this.panelCreate.Controls.Add(this.label6);
            this.panelCreate.Controls.Add(this.label7);
            this.panelCreate.Controls.Add(this.label3);
            this.panelCreate.Controls.Add(this.label2);
            this.panelCreate.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCreate.Location = new System.Drawing.Point(0, 95);
            this.panelCreate.Name = "panelCreate";
            this.panelCreate.Size = new System.Drawing.Size(1394, 178);
            this.panelCreate.TabIndex = 9;
            this.panelCreate.Visible = false;
            // 
            // txtTitulo
            // 
            this.txtTitulo.AllowDrop = true;
            this.txtTitulo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTitulo.Location = new System.Drawing.Point(186, 77);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(246, 32);
            this.txtTitulo.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(22, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 24);
            this.label4.TabIndex = 23;
            this.label4.Text = "Título:";
            // 
            // txtSNombre
            // 
            this.txtSNombre.AllowDrop = true;
            this.txtSNombre.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSNombre.Location = new System.Drawing.Point(610, 77);
            this.txtSNombre.Name = "txtSNombre";
            this.txtSNombre.Size = new System.Drawing.Size(207, 32);
            this.txtSNombre.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(446, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 24);
            this.label5.TabIndex = 21;
            this.label5.Text = "Segundo Nombre:";
            // 
            // txtSApellido
            // 
            this.txtSApellido.AllowDrop = true;
            this.txtSApellido.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSApellido.Location = new System.Drawing.Point(1023, 72);
            this.txtSApellido.Name = "txtSApellido";
            this.txtSApellido.Size = new System.Drawing.Size(207, 32);
            this.txtSApellido.TabIndex = 20;
            // 
            // txtPApellido
            // 
            this.txtPApellido.AllowDrop = true;
            this.txtPApellido.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPApellido.Location = new System.Drawing.Point(1023, 30);
            this.txtPApellido.Name = "txtPApellido";
            this.txtPApellido.Size = new System.Drawing.Size(207, 32);
            this.txtPApellido.TabIndex = 19;
            // 
            // cmbDepartamentos
            // 
            this.cmbDepartamentos.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbDepartamentos.FormattingEnabled = true;
            this.cmbDepartamentos.Items.AddRange(new object[] {
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
            this.cmbDepartamentos.Location = new System.Drawing.Point(186, 29);
            this.cmbDepartamentos.Name = "cmbDepartamentos";
            this.cmbDepartamentos.Size = new System.Drawing.Size(246, 32);
            this.cmbDepartamentos.TabIndex = 18;
            this.cmbDepartamentos.SelectedIndexChanged += new System.EventHandler(this.cmbDepartamentos_SelectedIndexChanged);
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
            this.btnGuardar.Location = new System.Drawing.Point(1252, 52);
            this.btnGuardar.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(125, 41);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtPNombre
            // 
            this.txtPNombre.AllowDrop = true;
            this.txtPNombre.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPNombre.Location = new System.Drawing.Point(610, 30);
            this.txtPNombre.Name = "txtPNombre";
            this.txtPNombre.Size = new System.Drawing.Size(207, 32);
            this.txtPNombre.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(829, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 24);
            this.label6.TabIndex = 6;
            this.label6.Text = "Segundo Apellido:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(829, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 24);
            this.label7.TabIndex = 5;
            this.label7.Text = "Primer Apellido:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(446, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Primer Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(23, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Departamento: ";
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
            this.panel1.Size = new System.Drawing.Size(1394, 95);
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
            this.btnNew.Location = new System.Drawing.Point(465, 33);
            this.btnNew.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(125, 31);
            this.btnNew.TabIndex = 6;
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
            this.btnCloseWin.Location = new System.Drawing.Point(1253, 14);
            this.btnCloseWin.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnCloseWin.Name = "btnCloseWin";
            this.btnCloseWin.Size = new System.Drawing.Size(125, 31);
            this.btnCloseWin.TabIndex = 5;
            this.btnCloseWin.Text = "Cerrar";
            this.btnCloseWin.UseVisualStyleBackColor = false;
            this.btnCloseWin.Click += new System.EventHandler(this.btnCloseWin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "ADMINISTRAR DOCENTES";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(71, 110);
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
            this.txtFiltro.Location = new System.Drawing.Point(152, 108);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.PlaceholderText = "...";
            this.txtFiltro.Size = new System.Drawing.Size(535, 30);
            this.txtFiltro.TabIndex = 17;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            this.txtFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltro_KeyPress);
            // 
            // FrmCRUD_Docente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1394, 830);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelCreate);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCRUD_Docente";
            this.Text = "FrmCRUD_Docente";
            this.Load += new System.EventHandler(this.FrmCRUD_Docente_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLstRegistros)).EndInit();
            this.panelCreate.ResumeLayout(false);
            this.panelCreate.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel2;
        private Button btnEliminar;
        private Button btnActualizar;
        private DataGridView dgLstRegistros;
        private Label label9;
        private Panel panelCreate;
        private TextBox txtTitulo;
        private Label label4;
        private TextBox txtSNombre;
        private Label label5;
        private TextBox txtSApellido;
        private TextBox txtPApellido;
        private ComboBox cmbDepartamentos;
        private Button btnGuardar;
        private TextBox txtPNombre;
        private Label label6;
        private Label label7;
        private Label label3;
        private Label label2;
        private Panel panel1;
        private Button btnNew;
        private Button btnCloseWin;
        private Label label1;
        private Label label14;
        private TextBox txtFiltro;
    }
}