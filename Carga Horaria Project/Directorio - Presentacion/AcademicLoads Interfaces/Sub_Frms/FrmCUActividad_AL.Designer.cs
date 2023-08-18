namespace Directorio___Presentacion.AcademicLoads_Interfaces.Sub_Frms
{
    partial class FrmCUActividad_AL
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
            this.panelInfoActividad = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cboxHorasTotales = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxHorasSemanales = new System.Windows.Forms.CheckBox();
            this.panelHorasTotales = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHorasTotales = new System.Windows.Forms.TextBox();
            this.lblHorasAct = new System.Windows.Forms.Label();
            this.txtHorasActividad = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbActividad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCrearActividad = new System.Windows.Forms.Button();
            this.lblTitleActividad = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panelInfoActividad.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelHorasTotales.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightBlue;
            this.panel2.Controls.Add(this.panelInfoActividad);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.cmbActividad);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1175, 376);
            this.panel2.TabIndex = 3;
            // 
            // panelInfoActividad
            // 
            this.panelInfoActividad.Controls.Add(this.label4);
            this.panelInfoActividad.Controls.Add(this.tableLayoutPanel1);
            this.panelInfoActividad.Controls.Add(this.panelHorasTotales);
            this.panelInfoActividad.Controls.Add(this.lblHorasAct);
            this.panelInfoActividad.Controls.Add(this.txtHorasActividad);
            this.panelInfoActividad.Controls.Add(this.btnAgregar);
            this.panelInfoActividad.Location = new System.Drawing.Point(20, 102);
            this.panelInfoActividad.Name = "panelInfoActividad";
            this.panelInfoActividad.Size = new System.Drawing.Size(942, 262);
            this.panelInfoActividad.TabIndex = 8;
            this.panelInfoActividad.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(31, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(335, 28);
            this.label4.TabIndex = 11;
            this.label4.Text = "Estilo de horas para  la Actividad: ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.03825F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.96175F));
            this.tableLayoutPanel1.Controls.Add(this.cboxHorasTotales, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboxHorasSemanales, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(362, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.42529F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(126, 48);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // cboxHorasTotales
            // 
            this.cboxHorasTotales.AutoSize = true;
            this.cboxHorasTotales.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxHorasTotales.FlatAppearance.BorderSize = 2;
            this.cboxHorasTotales.Location = new System.Drawing.Point(92, 27);
            this.cboxHorasTotales.Name = "cboxHorasTotales";
            this.cboxHorasTotales.Size = new System.Drawing.Size(18, 17);
            this.cboxHorasTotales.TabIndex = 3;
            this.cboxHorasTotales.UseVisualStyleBackColor = true;
            this.cboxHorasTotales.CheckedChanged += new System.EventHandler(this.cboxHorasTotales_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(3, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 24);
            this.label5.TabIndex = 2;
            this.label5.Text = "Totales";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Semanales";
            // 
            // cboxHorasSemanales
            // 
            this.cboxHorasSemanales.AutoSize = true;
            this.cboxHorasSemanales.Checked = true;
            this.cboxHorasSemanales.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxHorasSemanales.FlatAppearance.BorderSize = 2;
            this.cboxHorasSemanales.Location = new System.Drawing.Point(92, 3);
            this.cboxHorasSemanales.Name = "cboxHorasSemanales";
            this.cboxHorasSemanales.Size = new System.Drawing.Size(18, 17);
            this.cboxHorasSemanales.TabIndex = 2;
            this.cboxHorasSemanales.UseVisualStyleBackColor = true;
            this.cboxHorasSemanales.CheckedChanged += new System.EventHandler(this.cboxHorasSemanales_CheckedChanged);
            // 
            // panelHorasTotales
            // 
            this.panelHorasTotales.Controls.Add(this.label1);
            this.panelHorasTotales.Controls.Add(this.txtHorasTotales);
            this.panelHorasTotales.Location = new System.Drawing.Point(3, 94);
            this.panelHorasTotales.Name = "panelHorasTotales";
            this.panelHorasTotales.Size = new System.Drawing.Size(649, 149);
            this.panelHorasTotales.TabIndex = 9;
            this.panelHorasTotales.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(19, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Horas Totales  de la Actividad: ";
            // 
            // txtHorasTotales
            // 
            this.txtHorasTotales.BackColor = System.Drawing.Color.Khaki;
            this.txtHorasTotales.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtHorasTotales.Location = new System.Drawing.Point(363, 15);
            this.txtHorasTotales.Name = "txtHorasTotales";
            this.txtHorasTotales.Size = new System.Drawing.Size(248, 34);
            this.txtHorasTotales.TabIndex = 4;
            this.txtHorasTotales.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorasTotales_KeyPress);
            // 
            // lblHorasAct
            // 
            this.lblHorasAct.AutoSize = true;
            this.lblHorasAct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHorasAct.Location = new System.Drawing.Point(28, 108);
            this.lblHorasAct.Name = "lblHorasAct";
            this.lblHorasAct.Size = new System.Drawing.Size(338, 28);
            this.lblHorasAct.TabIndex = 4;
            this.lblHorasAct.Text = "Horas Semanales  de la Actividad: ";
            // 
            // txtHorasActividad
            // 
            this.txtHorasActividad.BackColor = System.Drawing.Color.Khaki;
            this.txtHorasActividad.Enabled = false;
            this.txtHorasActividad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtHorasActividad.Location = new System.Drawing.Point(372, 105);
            this.txtHorasActividad.Name = "txtHorasActividad";
            this.txtHorasActividad.Size = new System.Drawing.Size(248, 34);
            this.txtHorasActividad.TabIndex = 5;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Beige;
            this.btnAgregar.Enabled = false;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAgregar.Location = new System.Drawing.Point(771, 108);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(156, 41);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Beige;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(984, 210);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(156, 41);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmbActividad
            // 
            this.cmbActividad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbActividad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbActividad.BackColor = System.Drawing.Color.Khaki;
            this.cmbActividad.DropDownHeight = 200;
            this.cmbActividad.DropDownWidth = 800;
            this.cmbActividad.FormattingEnabled = true;
            this.cmbActividad.IntegralHeight = false;
            this.cmbActividad.Location = new System.Drawing.Point(305, 30);
            this.cmbActividad.Name = "cmbActividad";
            this.cmbActividad.Size = new System.Drawing.Size(855, 28);
            this.cmbActividad.TabIndex = 1;
            this.cmbActividad.SelectedIndexChanged += new System.EventHandler(this.cmbActividad_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(38, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Seleccione la actividad:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnCrearActividad);
            this.panel1.Controls.Add(this.lblTitleActividad);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1175, 83);
            this.panel1.TabIndex = 2;
            // 
            // btnCrearActividad
            // 
            this.btnCrearActividad.BackColor = System.Drawing.Color.Beige;
            this.btnCrearActividad.FlatAppearance.BorderSize = 0;
            this.btnCrearActividad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearActividad.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCrearActividad.Location = new System.Drawing.Point(756, 26);
            this.btnCrearActividad.Name = "btnCrearActividad";
            this.btnCrearActividad.Size = new System.Drawing.Size(384, 41);
            this.btnCrearActividad.TabIndex = 15;
            this.btnCrearActividad.Text = "Crear actividad";
            this.btnCrearActividad.UseVisualStyleBackColor = false;
            this.btnCrearActividad.Click += new System.EventHandler(this.btnCrearActividad_Click);
            // 
            // lblTitleActividad
            // 
            this.lblTitleActividad.AutoSize = true;
            this.lblTitleActividad.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitleActividad.Location = new System.Drawing.Point(23, 25);
            this.lblTitleActividad.Name = "lblTitleActividad";
            this.lblTitleActividad.Size = new System.Drawing.Size(308, 38);
            this.lblTitleActividad.TabIndex = 0;
            this.lblTitleActividad.Text = "AGREGAR ACTIVIDAD";
            // 
            // FrmCUActividad_AL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(1175, 459);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCUActividad_AL";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador de Actividades";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCUActividad_AL_FormClosed);
            this.Load += new System.EventHandler(this.FrmCUActividad_AL_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmCUActividad_AL_KeyPress);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelInfoActividad.ResumeLayout(false);
            this.panelInfoActividad.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelHorasTotales.ResumeLayout(false);
            this.panelHorasTotales.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel2;
        private Panel panelInfoActividad;
        private Label lblHorasAct;
        private TextBox txtHorasActividad;
        private Button btnCancelar;
        private Button btnAgregar;
        private ComboBox cmbActividad;
        private Label label2;
        private Panel panel1;
        private Label lblTitleActividad;
        private TableLayoutPanel tableLayoutPanel1;
        private CheckBox cboxHorasTotales;
        private Label label5;
        private Label label3;
        private CheckBox cboxHorasSemanales;
        private Panel panelHorasTotales;
        private Label label1;
        private TextBox txtHorasTotales;
        private Label label4;
        public Button btnCrearActividad;
    }
}