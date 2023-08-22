namespace Directorio___Presentacion.AcademicLoads_Interfaces
{
    partial class FrmCUAsignatura_AL
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
            this.btnCancelar = new MaterialSkin.Controls.MaterialButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstBoxAsignaturas = new System.Windows.Forms.ListBox();
            this.tblPanelFiltros = new System.Windows.Forms.TableLayoutPanel();
            this.rbTodo = new MaterialSkin.Controls.MaterialRadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbCarreras = new System.Windows.Forms.ComboBox();
            this.txtCodeFilter = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbAsignatura = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelGR = new System.Windows.Forms.Panel();
            this.lblNoHorario = new System.Windows.Forms.Label();
            this.btnAddGR = new MaterialSkin.Controls.MaterialButton();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbGR = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNivel = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCruceHorario = new System.Windows.Forms.Label();
            this.btnAgregar = new MaterialSkin.Controls.MaterialButton();
            this.panelHorario = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvHorario = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tblPanelFiltros.SuspendLayout();
            this.panelGR.SuspendLayout();
            this.panelHorario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorario)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(956, 83);
            this.panel1.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = false;
            this.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancelar.Depth = 0;
            this.btnCancelar.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.HighEmphasis = true;
            this.btnCancelar.Icon = null;
            this.btnCancelar.Location = new System.Drawing.Point(800, 25);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancelar.Size = new System.Drawing.Size(128, 45);
            this.btnCancelar.TabIndex = 34;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancelar.UseAccentColor = false;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(30, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "AGREGAR ASIGNATURA";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightBlue;
            this.panel2.Controls.Add(this.lstBoxAsignaturas);
            this.panel2.Controls.Add(this.tblPanelFiltros);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cmbAsignatura);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(956, 309);
            this.panel2.TabIndex = 1;
            // 
            // lstBoxAsignaturas
            // 
            this.lstBoxAsignaturas.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lstBoxAsignaturas.FormattingEnabled = true;
            this.lstBoxAsignaturas.ItemHeight = 20;
            this.lstBoxAsignaturas.Location = new System.Drawing.Point(304, 158);
            this.lstBoxAsignaturas.Name = "lstBoxAsignaturas";
            this.lstBoxAsignaturas.Size = new System.Drawing.Size(624, 144);
            this.lstBoxAsignaturas.TabIndex = 5;
            // 
            // tblPanelFiltros
            // 
            this.tblPanelFiltros.BackColor = System.Drawing.Color.LightCyan;
            this.tblPanelFiltros.ColumnCount = 2;
            this.tblPanelFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblPanelFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tblPanelFiltros.Controls.Add(this.rbTodo, 1, 0);
            this.tblPanelFiltros.Controls.Add(this.label8, 0, 0);
            this.tblPanelFiltros.Controls.Add(this.label9, 0, 1);
            this.tblPanelFiltros.Controls.Add(this.label10, 0, 2);
            this.tblPanelFiltros.Controls.Add(this.cmbCarreras, 1, 1);
            this.tblPanelFiltros.Controls.Add(this.txtCodeFilter, 1, 2);
            this.tblPanelFiltros.Location = new System.Drawing.Point(304, 6);
            this.tblPanelFiltros.Name = "tblPanelFiltros";
            this.tblPanelFiltros.RowCount = 3;
            this.tblPanelFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblPanelFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblPanelFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblPanelFiltros.Size = new System.Drawing.Size(455, 104);
            this.tblPanelFiltros.TabIndex = 10;
            // 
            // rbTodo
            // 
            this.rbTodo.AutoSize = true;
            this.rbTodo.Checked = true;
            this.rbTodo.Depth = 0;
            this.rbTodo.Location = new System.Drawing.Point(136, 0);
            this.rbTodo.Margin = new System.Windows.Forms.Padding(0);
            this.rbTodo.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbTodo.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbTodo.Name = "rbTodo";
            this.rbTodo.Ripple = true;
            this.rbTodo.Size = new System.Drawing.Size(34, 34);
            this.rbTodo.TabIndex = 35;
            this.rbTodo.TabStop = true;
            this.rbTodo.UseVisualStyleBackColor = true;
            this.rbTodo.CheckedChanged += new System.EventHandler(this.rbTodo_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 34);
            this.label8.TabIndex = 1;
            this.label8.Text = "Mostrar todas";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(3, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 34);
            this.label9.TabIndex = 2;
            this.label9.Text = "Por Carrera";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(3, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 36);
            this.label10.TabIndex = 3;
            this.label10.Text = "Por código";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCarreras
            // 
            this.cmbCarreras.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCarreras.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCarreras.FormattingEnabled = true;
            this.cmbCarreras.Location = new System.Drawing.Point(139, 37);
            this.cmbCarreras.Name = "cmbCarreras";
            this.cmbCarreras.Size = new System.Drawing.Size(313, 28);
            this.cmbCarreras.TabIndex = 2;
            this.cmbCarreras.SelectedIndexChanged += new System.EventHandler(this.cmbCarreras_SelectedIndexChanged);
            // 
            // txtCodeFilter
            // 
            this.txtCodeFilter.Location = new System.Drawing.Point(139, 71);
            this.txtCodeFilter.Name = "txtCodeFilter";
            this.txtCodeFilter.Size = new System.Drawing.Size(313, 27);
            this.txtCodeFilter.TabIndex = 3;
            this.txtCodeFilter.TextChanged += new System.EventHandler(this.txtCodeFilter_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(30, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(210, 28);
            this.label7.TabIndex = 9;
            this.label7.Text = "Filtro de asignaturas:";
            // 
            // cmbAsignatura
            // 
            this.cmbAsignatura.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAsignatura.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAsignatura.FormattingEnabled = true;
            this.cmbAsignatura.Location = new System.Drawing.Point(304, 124);
            this.cmbAsignatura.Name = "cmbAsignatura";
            this.cmbAsignatura.Size = new System.Drawing.Size(624, 28);
            this.cmbAsignatura.TabIndex = 0;
            this.cmbAsignatura.SelectedIndexChanged += new System.EventHandler(this.cmbAsignatura_SelectedIndexChanged);
            this.cmbAsignatura.TextChanged += new System.EventHandler(this.cmbAsignatura_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(30, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Seleccione la asignatura:";
            // 
            // panelGR
            // 
            this.panelGR.BackColor = System.Drawing.Color.LightBlue;
            this.panelGR.Controls.Add(this.lblNoHorario);
            this.panelGR.Controls.Add(this.btnAddGR);
            this.panelGR.Controls.Add(this.txtCode);
            this.panelGR.Controls.Add(this.label6);
            this.panelGR.Controls.Add(this.cmbGR);
            this.panelGR.Controls.Add(this.label5);
            this.panelGR.Controls.Add(this.label3);
            this.panelGR.Controls.Add(this.txtNivel);
            this.panelGR.Controls.Add(this.txtType);
            this.panelGR.Controls.Add(this.label4);
            this.panelGR.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGR.Location = new System.Drawing.Point(0, 392);
            this.panelGR.Name = "panelGR";
            this.panelGR.Size = new System.Drawing.Size(956, 191);
            this.panelGR.TabIndex = 8;
            this.panelGR.Visible = false;
            // 
            // lblNoHorario
            // 
            this.lblNoHorario.AutoSize = true;
            this.lblNoHorario.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNoHorario.ForeColor = System.Drawing.Color.Red;
            this.lblNoHorario.Location = new System.Drawing.Point(255, 165);
            this.lblNoHorario.Name = "lblNoHorario";
            this.lblNoHorario.Size = new System.Drawing.Size(241, 21);
            this.lblNoHorario.TabIndex = 14;
            this.lblNoHorario.Text = "No hay GRs con horario asignado";
            this.lblNoHorario.Visible = false;
            // 
            // btnAddGR
            // 
            this.btnAddGR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddGR.AutoSize = false;
            this.btnAddGR.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddGR.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAddGR.Depth = 0;
            this.btnAddGR.Enabled = false;
            this.btnAddGR.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddGR.HighEmphasis = true;
            this.btnAddGR.Icon = null;
            this.btnAddGR.Location = new System.Drawing.Point(521, 128);
            this.btnAddGR.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddGR.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddGR.Name = "btnAddGR";
            this.btnAddGR.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAddGR.Size = new System.Drawing.Size(125, 38);
            this.btnAddGR.TabIndex = 13;
            this.btnAddGR.Text = "Agregar GR";
            this.btnAddGR.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddGR.UseAccentColor = false;
            this.btnAddGR.UseVisualStyleBackColor = true;
            this.btnAddGR.Click += new System.EventHandler(this.btnAddGR_Click);
            // 
            // txtCode
            // 
            this.txtCode.Enabled = false;
            this.txtCode.Location = new System.Drawing.Point(255, 6);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(248, 27);
            this.txtCode.TabIndex = 12;
            this.txtCode.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(18, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(215, 28);
            this.label6.TabIndex = 11;
            this.label6.Text = "Código de asignatura:";
            // 
            // cmbGR
            // 
            this.cmbGR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGR.FormattingEnabled = true;
            this.cmbGR.Location = new System.Drawing.Point(255, 134);
            this.cmbGR.Name = "cmbGR";
            this.cmbGR.Size = new System.Drawing.Size(249, 28);
            this.cmbGR.TabIndex = 7;
            this.cmbGR.SelectedIndexChanged += new System.EventHandler(this.cmbGR_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(18, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(230, 65);
            this.label5.TabIndex = 8;
            this.label5.Text = "Seleccione el grupo de asignatura:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(18, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo de asignatura:";
            // 
            // txtNivel
            // 
            this.txtNivel.Enabled = false;
            this.txtNivel.Location = new System.Drawing.Point(255, 92);
            this.txtNivel.Name = "txtNivel";
            this.txtNivel.Size = new System.Drawing.Size(248, 27);
            this.txtNivel.TabIndex = 7;
            this.txtNivel.TabStop = false;
            // 
            // txtType
            // 
            this.txtType.Enabled = false;
            this.txtType.Location = new System.Drawing.Point(255, 50);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(248, 27);
            this.txtType.TabIndex = 5;
            this.txtType.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(18, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nivel de asignatura:";
            // 
            // lblCruceHorario
            // 
            this.lblCruceHorario.BackColor = System.Drawing.Color.Tomato;
            this.lblCruceHorario.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCruceHorario.ForeColor = System.Drawing.Color.White;
            this.lblCruceHorario.Location = new System.Drawing.Point(693, 96);
            this.lblCruceHorario.Name = "lblCruceHorario";
            this.lblCruceHorario.Size = new System.Drawing.Size(235, 122);
            this.lblCruceHorario.TabIndex = 36;
            this.lblCruceHorario.Text = "¡ATENCIÓN! EXISTE UN CONFLICTO DE CRUCE DE HORARIO ENTRE LAS ASIGNATURAS DE LA CA" +
    "RGA HORARIA. ";
            this.lblCruceHorario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCruceHorario.Visible = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.AutoSize = false;
            this.btnAgregar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAgregar.Depth = 0;
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAgregar.HighEmphasis = true;
            this.btnAgregar.Icon = null;
            this.btnAgregar.Location = new System.Drawing.Point(746, 13);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAgregar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAgregar.Size = new System.Drawing.Size(128, 77);
            this.btnAgregar.TabIndex = 35;
            this.btnAgregar.Text = "agregar asignatura";
            this.btnAgregar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAgregar.UseAccentColor = false;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // panelHorario
            // 
            this.panelHorario.BackColor = System.Drawing.Color.LightBlue;
            this.panelHorario.Controls.Add(this.lblCruceHorario);
            this.panelHorario.Controls.Add(this.btnAgregar);
            this.panelHorario.Controls.Add(this.label11);
            this.panelHorario.Controls.Add(this.dgvHorario);
            this.panelHorario.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelHorario.Location = new System.Drawing.Point(0, 583);
            this.panelHorario.Name = "panelHorario";
            this.panelHorario.Size = new System.Drawing.Size(956, 235);
            this.panelHorario.TabIndex = 37;
            this.panelHorario.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.SkyBlue;
            this.label11.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(18, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 35);
            this.label11.TabIndex = 1;
            this.label11.Text = "HORARIO";
            // 
            // dgvHorario
            // 
            this.dgvHorario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHorario.Location = new System.Drawing.Point(188, 13);
            this.dgvHorario.Name = "dgvHorario";
            this.dgvHorario.RowHeadersWidth = 51;
            this.dgvHorario.RowTemplate.Height = 29;
            this.dgvHorario.Size = new System.Drawing.Size(485, 205);
            this.dgvHorario.TabIndex = 0;
            // 
            // FrmCUAsignatura_AL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(956, 818);
            this.ControlBox = false;
            this.Controls.Add(this.panelHorario);
            this.Controls.Add(this.panelGR);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmCUAsignatura_AL";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  AGREGAR ASIGNATURA";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCUAsignatura_AL_FormClosed);
            this.Load += new System.EventHandler(this.FrmCUAsignatura_AL_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmCUAsignatura_AL_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tblPanelFiltros.ResumeLayout(false);
            this.tblPanelFiltros.PerformLayout();
            this.panelGR.ResumeLayout(false);
            this.panelGR.PerformLayout();
            this.panelHorario.ResumeLayout(false);
            this.panelHorario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private TextBox txtNivel;
        private Label label4;
        private TextBox txtType;
        private Label label3;
        private ComboBox cmbAsignatura;
        private Label label2;
        private Panel panelGR;
        private ComboBox cmbGR;
        private Label label5;
        private Label label6;
        private TableLayoutPanel tblPanelFiltros;
        private Label label8;
        private Label label7;
        private TextBox txtCode;
        private Label label9;
        private Label label10;
        private ComboBox cmbCarreras;
        private TextBox txtCodeFilter;
        private ListBox lstBoxAsignaturas;
        private MaterialSkin.Controls.MaterialButton btnAddGR;
        private MaterialSkin.Controls.MaterialButton btnCancelar;
        private MaterialSkin.Controls.MaterialButton btnAgregar;
        private MaterialSkin.Controls.MaterialRadioButton rbTodo;
        private Panel panelHorario;
        private DataGridView dgvHorario;
        private Label label11;
        private Label lblCruceHorario;
        private Label lblNoHorario;
    }
}