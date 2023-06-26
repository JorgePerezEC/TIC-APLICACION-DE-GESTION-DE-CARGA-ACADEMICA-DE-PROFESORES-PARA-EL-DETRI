namespace Directorio___Presentacion.CRUD_Data_Interfaces
{
    partial class FrmCRUD_HorasExigibles
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
            this.label9 = new System.Windows.Forms.Label();
            this.dgLstRegistros = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.cmbSemestreLst = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelCreate = new System.Windows.Forms.Panel();
            this.panelHorasExigibles = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHorasExigibles = new System.Windows.Forms.TextBox();
            this.btnCargarData = new System.Windows.Forms.Button();
            this.cmbTipoDocente = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSemestreAdd = new System.Windows.Forms.ComboBox();
            this.cmbDocente = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCopiarData = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCloseWin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgLstRegistros)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelCreate.SuspendLayout();
            this.panelHorasExigibles.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Roboto Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(76, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(575, 24);
            this.label9.TabIndex = 5;
            this.label9.Text = "Lista de Docentes con horas exigibles asignadas por semestre";
            // 
            // dgLstRegistros
            // 
            this.dgLstRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLstRegistros.Location = new System.Drawing.Point(78, 117);
            this.dgLstRegistros.Name = "dgLstRegistros";
            this.dgLstRegistros.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgLstRegistros.RowTemplate.Height = 29;
            this.dgLstRegistros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLstRegistros.Size = new System.Drawing.Size(729, 443);
            this.dgLstRegistros.TabIndex = 6;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.LightBlue;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnActualizar.Font = new System.Drawing.Font("Roboto Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnActualizar.Location = new System.Drawing.Point(854, 274);
            this.btnActualizar.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(125, 41);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.LightBlue;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.Font = new System.Drawing.Font("Roboto Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.Location = new System.Drawing.Point(854, 345);
            this.btnEliminar.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(125, 41);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // cmbSemestreLst
            // 
            this.cmbSemestreLst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemestreLst.FormattingEnabled = true;
            this.cmbSemestreLst.Location = new System.Drawing.Point(677, 49);
            this.cmbSemestreLst.Name = "cmbSemestreLst";
            this.cmbSemestreLst.Size = new System.Drawing.Size(150, 28);
            this.cmbSemestreLst.TabIndex = 12;
            this.cmbSemestreLst.SelectedIndexChanged += new System.EventHandler(this.cmbSemestreLst_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbSemestreLst);
            this.panel2.Controls.Add(this.btnEliminar);
            this.panel2.Controls.Add(this.btnActualizar);
            this.panel2.Controls.Add(this.dgLstRegistros);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 273);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1394, 572);
            this.panel2.TabIndex = 8;
            // 
            // panelCreate
            // 
            this.panelCreate.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelCreate.Controls.Add(this.panelHorasExigibles);
            this.panelCreate.Controls.Add(this.btnCargarData);
            this.panelCreate.Controls.Add(this.cmbTipoDocente);
            this.panelCreate.Controls.Add(this.label4);
            this.panelCreate.Controls.Add(this.cmbSemestreAdd);
            this.panelCreate.Controls.Add(this.cmbDocente);
            this.panelCreate.Controls.Add(this.btnGuardar);
            this.panelCreate.Controls.Add(this.label3);
            this.panelCreate.Controls.Add(this.label2);
            this.panelCreate.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCreate.Location = new System.Drawing.Point(0, 95);
            this.panelCreate.Name = "panelCreate";
            this.panelCreate.Size = new System.Drawing.Size(1394, 178);
            this.panelCreate.TabIndex = 9;
            this.panelCreate.Visible = false;
            // 
            // panelHorasExigibles
            // 
            this.panelHorasExigibles.Controls.Add(this.btnEdit);
            this.panelHorasExigibles.Controls.Add(this.label5);
            this.panelHorasExigibles.Controls.Add(this.txtHorasExigibles);
            this.panelHorasExigibles.Location = new System.Drawing.Point(557, 6);
            this.panelHorasExigibles.Name = "panelHorasExigibles";
            this.panelHorasExigibles.Size = new System.Drawing.Size(499, 101);
            this.panelHorasExigibles.TabIndex = 17;
            this.panelHorasExigibles.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Roboto Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEdit.Location = new System.Drawing.Point(410, 12);
            this.btnEdit.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(57, 41);
            this.btnEdit.TabIndex = 16;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(7, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Horas Exigibles:";
            // 
            // txtHorasExigibles
            // 
            this.txtHorasExigibles.AllowDrop = true;
            this.txtHorasExigibles.Location = new System.Drawing.Point(168, 18);
            this.txtHorasExigibles.Name = "txtHorasExigibles";
            this.txtHorasExigibles.PlaceholderText = "Ingrese el número de horas";
            this.txtHorasExigibles.Size = new System.Drawing.Size(223, 27);
            this.txtHorasExigibles.TabIndex = 9;
            // 
            // btnCargarData
            // 
            this.btnCargarData.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnCargarData.FlatAppearance.BorderSize = 0;
            this.btnCargarData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarData.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCargarData.Location = new System.Drawing.Point(1210, 94);
            this.btnCargarData.Name = "btnCargarData";
            this.btnCargarData.Size = new System.Drawing.Size(123, 61);
            this.btnCargarData.TabIndex = 15;
            this.btnCargarData.Text = "Cargar Masivamente";
            this.btnCargarData.UseVisualStyleBackColor = false;
            this.btnCargarData.Click += new System.EventHandler(this.btnCargarData_Click);
            // 
            // cmbTipoDocente
            // 
            this.cmbTipoDocente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipoDocente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipoDocente.FormattingEnabled = true;
            this.cmbTipoDocente.Location = new System.Drawing.Point(209, 96);
            this.cmbTipoDocente.Name = "cmbTipoDocente";
            this.cmbTipoDocente.Size = new System.Drawing.Size(333, 28);
            this.cmbTipoDocente.TabIndex = 13;
            this.cmbTipoDocente.SelectedIndexChanged += new System.EventHandler(this.cmbTipoDocente_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(23, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tipo de Docente:";
            // 
            // cmbSemestreAdd
            // 
            this.cmbSemestreAdd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSemestreAdd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSemestreAdd.FormattingEnabled = true;
            this.cmbSemestreAdd.Location = new System.Drawing.Point(209, 58);
            this.cmbSemestreAdd.Name = "cmbSemestreAdd";
            this.cmbSemestreAdd.Size = new System.Drawing.Size(150, 28);
            this.cmbSemestreAdd.TabIndex = 11;
            this.cmbSemestreAdd.SelectedIndexChanged += new System.EventHandler(this.cmbSemestreAdd_SelectedIndexChanged);
            // 
            // cmbDocente
            // 
            this.cmbDocente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDocente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDocente.FormattingEnabled = true;
            this.cmbDocente.Location = new System.Drawing.Point(209, 24);
            this.cmbDocente.Name = "cmbDocente";
            this.cmbDocente.Size = new System.Drawing.Size(333, 28);
            this.cmbDocente.TabIndex = 10;
            this.cmbDocente.SelectedIndexChanged += new System.EventHandler(this.cmbDocente_SelectedIndexChanged);
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
            this.btnGuardar.Location = new System.Drawing.Point(1208, 29);
            this.btnGuardar.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(125, 41);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(23, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Semestre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(23, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre del Docente:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnCopiarData);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnCloseWin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1394, 95);
            this.panel1.TabIndex = 7;
            // 
            // btnCopiarData
            // 
            this.btnCopiarData.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnCopiarData.FlatAppearance.BorderSize = 0;
            this.btnCopiarData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopiarData.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCopiarData.Location = new System.Drawing.Point(677, 16);
            this.btnCopiarData.Name = "btnCopiarData";
            this.btnCopiarData.Size = new System.Drawing.Size(177, 61);
            this.btnCopiarData.TabIndex = 16;
            this.btnCopiarData.Text = "Copiar Horas Exigibles por Semestre";
            this.btnCopiarData.UseVisualStyleBackColor = false;
            this.btnCopiarData.Click += new System.EventHandler(this.btnCopiarData_Click);
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
            this.btnNew.Location = new System.Drawing.Point(502, 32);
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
            this.label1.Font = new System.Drawing.Font("Roboto Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(78, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Administrar Horas Exigibles por Docente";
            // 
            // FrmCRUD_HorasExigibles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1394, 845);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelCreate);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCRUD_HorasExigibles";
            this.Text = "FrmCRUD_HorasExigibles";
            this.Load += new System.EventHandler(this.FrmCRUD_HorasExigibles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLstRegistros)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelCreate.ResumeLayout(false);
            this.panelCreate.PerformLayout();
            this.panelHorasExigibles.ResumeLayout(false);
            this.panelHorasExigibles.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label9;
        private DataGridView dgLstRegistros;
        private Button btnActualizar;
        private Button btnEliminar;
        private ComboBox cmbSemestreLst;
        private Panel panel2;
        private Panel panelCreate;
        private Button btnCargarData;
        private Label label5;
        private ComboBox cmbTipoDocente;
        private Label label4;
        private ComboBox cmbSemestreAdd;
        private ComboBox cmbDocente;
        private Button btnGuardar;
        private TextBox txtHorasExigibles;
        private Label label3;
        private Label label2;
        private Panel panel1;
        private Button btnCopiarData;
        private Button btnNew;
        private Button btnCloseWin;
        private Label label1;
        private Panel panelHorasExigibles;
        private Button btnEdit;
    }
}