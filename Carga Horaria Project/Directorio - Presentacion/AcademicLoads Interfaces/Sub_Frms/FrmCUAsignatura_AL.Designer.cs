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
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelGR = new System.Windows.Forms.Panel();
            this.btnAddGR = new System.Windows.Forms.Button();
            this.cmbGR = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNivel = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbAsignatura = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelGR.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(964, 83);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(20, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar Asignatura";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightBlue;
            this.panel2.Controls.Add(this.panelGR);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.cmbAsignatura);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(964, 371);
            this.panel2.TabIndex = 1;
            // 
            // panelGR
            // 
            this.panelGR.Controls.Add(this.label6);
            this.panelGR.Controls.Add(this.txtCode);
            this.panelGR.Controls.Add(this.btnAddGR);
            this.panelGR.Controls.Add(this.cmbGR);
            this.panelGR.Controls.Add(this.btnAgregar);
            this.panelGR.Controls.Add(this.label5);
            this.panelGR.Controls.Add(this.label3);
            this.panelGR.Controls.Add(this.txtNivel);
            this.panelGR.Controls.Add(this.txtType);
            this.panelGR.Controls.Add(this.label4);
            this.panelGR.Location = new System.Drawing.Point(20, 88);
            this.panelGR.Name = "panelGR";
            this.panelGR.Size = new System.Drawing.Size(781, 248);
            this.panelGR.TabIndex = 8;
            this.panelGR.Visible = false;
            // 
            // btnAddGR
            // 
            this.btnAddGR.BackColor = System.Drawing.Color.Beige;
            this.btnAddGR.FlatAppearance.BorderSize = 0;
            this.btnAddGR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGR.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddGR.Location = new System.Drawing.Point(571, 131);
            this.btnAddGR.Name = "btnAddGR";
            this.btnAddGR.Size = new System.Drawing.Size(140, 37);
            this.btnAddGR.TabIndex = 10;
            this.btnAddGR.Text = "Agregar GR";
            this.btnAddGR.UseVisualStyleBackColor = false;
            this.btnAddGR.Click += new System.EventHandler(this.btnAddGR_Click);
            // 
            // cmbGR
            // 
            this.cmbGR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGR.FormattingEnabled = true;
            this.cmbGR.Location = new System.Drawing.Point(284, 135);
            this.cmbGR.Name = "cmbGR";
            this.cmbGR.Size = new System.Drawing.Size(249, 28);
            this.cmbGR.TabIndex = 9;
            this.cmbGR.SelectedIndexChanged += new System.EventHandler(this.cmbGR_SelectedIndexChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Beige;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAgregar.Location = new System.Drawing.Point(614, 198);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(140, 37);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(18, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(246, 65);
            this.label5.TabIndex = 8;
            this.label5.Text = "Seleccione el grupo de asignatura:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(18, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo de asignatura:";
            // 
            // txtNivel
            // 
            this.txtNivel.Enabled = false;
            this.txtNivel.Location = new System.Drawing.Point(284, 93);
            this.txtNivel.Name = "txtNivel";
            this.txtNivel.Size = new System.Drawing.Size(248, 27);
            this.txtNivel.TabIndex = 7;
            // 
            // txtType
            // 
            this.txtType.Enabled = false;
            this.txtType.Location = new System.Drawing.Point(284, 51);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(248, 27);
            this.txtType.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(18, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nivel de asignatura:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Beige;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(807, 286);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 37);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmbAsignatura
            // 
            this.cmbAsignatura.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAsignatura.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAsignatura.FormattingEnabled = true;
            this.cmbAsignatura.Location = new System.Drawing.Point(304, 30);
            this.cmbAsignatura.Name = "cmbAsignatura";
            this.cmbAsignatura.Size = new System.Drawing.Size(570, 28);
            this.cmbAsignatura.TabIndex = 1;
            this.cmbAsignatura.SelectedIndexChanged += new System.EventHandler(this.cmbAsignatura_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(38, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Seleccione la asignatura:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(18, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(218, 28);
            this.label6.TabIndex = 11;
            this.label6.Text = "Código de asignatura:";
            // 
            // txtCode
            // 
            this.txtCode.Enabled = false;
            this.txtCode.Location = new System.Drawing.Point(284, 3);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(248, 27);
            this.txtCode.TabIndex = 12;
            // 
            // FrmCUAsignatura_AL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 454);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmCUAsignatura_AL";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar asignatura";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCUAsignatura_AL_FormClosed);
            this.Load += new System.EventHandler(this.FrmCUAsignatura_AL_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmCUAsignatura_AL_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelGR.ResumeLayout(false);
            this.panelGR.PerformLayout();
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
        private Button btnCancelar;
        private Button btnAgregar;
        private ComboBox cmbAsignatura;
        private Label label2;
        private Panel panelGR;
        private ComboBox cmbGR;
        private Label label5;
        private Button btnAddGR;
        private Label label6;
        private TextBox txtCode;
    }
}