namespace Directorio___Presentacion.AcademicLoads_Interfaces
{
    partial class FrmCRUD_Investigacion_Ac_Load
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
            this.dgLstRegistros = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddActividad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgLstRegistros)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgLstRegistros
            // 
            this.dgLstRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLstRegistros.Location = new System.Drawing.Point(96, 64);
            this.dgLstRegistros.Name = "dgLstRegistros";
            this.dgLstRegistros.RowHeadersWidth = 51;
            this.dgLstRegistros.RowTemplate.Height = 29;
            this.dgLstRegistros.Size = new System.Drawing.Size(1328, 529);
            this.dgLstRegistros.TabIndex = 0;
            this.dgLstRegistros.TabStop = false;
            this.dgLstRegistros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLstRegistros_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(96, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(407, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lista de Actividades de Investigación";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dgLstRegistros);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 82);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1609, 630);
            this.panel2.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnAddActividad);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1609, 82);
            this.panel1.TabIndex = 6;
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
            this.label1.Size = new System.Drawing.Size(422, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestión de Carga Investigación";
            // 
            // btnAddActividad
            // 
            this.btnAddActividad.BackColor = System.Drawing.Color.Khaki;
            this.btnAddActividad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddActividad.ForeColor = System.Drawing.Color.DimGray;
            this.btnAddActividad.Location = new System.Drawing.Point(469, 25);
            this.btnAddActividad.Name = "btnAddActividad";
            this.btnAddActividad.Size = new System.Drawing.Size(182, 31);
            this.btnAddActividad.TabIndex = 0;
            this.btnAddActividad.Text = "Agregar Actividad";
            this.btnAddActividad.UseVisualStyleBackColor = false;
            this.btnAddActividad.Click += new System.EventHandler(this.btnAddActividad_Click);
            // 
            // FrmCRUD_Investigacion_Ac_Load
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1609, 712);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCRUD_Investigacion_Ac_Load";
            this.Text = "CRUD_Investigacion_Ac_Load";
            this.Load += new System.EventHandler(this.FrmCRUD_Investigacion_Ac_Load_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLstRegistros)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgLstRegistros;
        private Label label2;
        private Panel panel2;
        private Panel panel1;
        private Panel panel3;
        private Label label1;
        private Button btnAddActividad;
    }
}