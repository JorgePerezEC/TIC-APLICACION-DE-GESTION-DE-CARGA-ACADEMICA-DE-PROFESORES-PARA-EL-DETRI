namespace Directorio___Presentacion.AcademicLoads_Interfaces
{
    partial class FrmCRUD_Asignaturas_Ac_Load
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddAsignatura = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvHorario = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgLstRegistros = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLstRegistros)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnAddAsignatura);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1660, 82);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(443, 81);
            this.panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestión de Asignaturas";
            // 
            // btnAddAsignatura
            // 
            this.btnAddAsignatura.BackColor = System.Drawing.Color.Khaki;
            this.btnAddAsignatura.FlatAppearance.BorderSize = 0;
            this.btnAddAsignatura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAsignatura.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddAsignatura.ForeColor = System.Drawing.Color.DimGray;
            this.btnAddAsignatura.Location = new System.Drawing.Point(469, 25);
            this.btnAddAsignatura.Name = "btnAddAsignatura";
            this.btnAddAsignatura.Size = new System.Drawing.Size(182, 31);
            this.btnAddAsignatura.TabIndex = 0;
            this.btnAddAsignatura.Text = "Agregar Asignatura";
            this.btnAddAsignatura.UseVisualStyleBackColor = false;
            this.btnAddAsignatura.Click += new System.EventHandler(this.btnAddAsignatura_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dgLstRegistros);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 82);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1660, 838);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.panel4.Controls.Add(this.dgvHorario);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(1097, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(563, 623);
            this.panel4.TabIndex = 3;
            // 
            // dgvHorario
            // 
            this.dgvHorario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHorario.Location = new System.Drawing.Point(12, 61);
            this.dgvHorario.Name = "dgvHorario";
            this.dgvHorario.RowHeadersWidth = 51;
            this.dgvHorario.RowTemplate.Height = 29;
            this.dgvHorario.Size = new System.Drawing.Size(493, 559);
            this.dgvHorario.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "Horario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(27, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lista de Asignaturas";
            // 
            // dgLstRegistros
            // 
            this.dgLstRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLstRegistros.Location = new System.Drawing.Point(27, 67);
            this.dgLstRegistros.Name = "dgLstRegistros";
            this.dgLstRegistros.RowHeadersWidth = 51;
            this.dgLstRegistros.RowTemplate.Height = 29;
            this.dgLstRegistros.Size = new System.Drawing.Size(1064, 559);
            this.dgLstRegistros.TabIndex = 0;
            this.dgLstRegistros.TabStop = false;
            this.dgLstRegistros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLstRegistros_CellContentClick);
            // 
            // FrmCRUD_Asignaturas_Ac_Load
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1660, 920);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCRUD_Asignaturas_Ac_Load";
            this.Text = "CRUD_Asignaturas_Ac_Load";
            this.Activated += new System.EventHandler(this.FrmCRUD_Asignaturas_Ac_Load_Activated);
            this.Load += new System.EventHandler(this.FrmCRUD_Asignaturas_Ac_Load_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLstRegistros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button btnAddAsignatura;
        private Panel panel2;
        private DataGridView dgLstRegistros;
        private Panel panel3;
        private Label label1;
        private Label label2;
        private Panel panel4;
        private DataGridView dgvHorario;
        private Label label3;
    }
}