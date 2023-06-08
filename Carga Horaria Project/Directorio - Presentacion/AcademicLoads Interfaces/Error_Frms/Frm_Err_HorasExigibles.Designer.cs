namespace Directorio___Presentacion.AcademicLoads_Interfaces.Error_Frms
{
    partial class Frm_Err_HorasExigibles
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
            this.pixtbxWarning = new System.Windows.Forms.PictureBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnOpenHorasExigibles = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pixtbxWarning)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.pixtbxWarning);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.btnOpenHorasExigibles);
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 253);
            this.panel1.TabIndex = 0;
            // 
            // pixtbxWarning
            // 
            this.pixtbxWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pixtbxWarning.Location = new System.Drawing.Point(3, 0);
            this.pixtbxWarning.Name = "pixtbxWarning";
            this.pixtbxWarning.Size = new System.Drawing.Size(89, 89);
            this.pixtbxWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pixtbxWarning.TabIndex = 3;
            this.pixtbxWarning.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.SteelBlue;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(248, 176);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(127, 55);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Aceptar";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnOpenHorasExigibles
            // 
            this.btnOpenHorasExigibles.BackColor = System.Drawing.Color.SteelBlue;
            this.btnOpenHorasExigibles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenHorasExigibles.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnOpenHorasExigibles.ForeColor = System.Drawing.Color.White;
            this.btnOpenHorasExigibles.Location = new System.Drawing.Point(413, 176);
            this.btnOpenHorasExigibles.Name = "btnOpenHorasExigibles";
            this.btnOpenHorasExigibles.Size = new System.Drawing.Size(127, 55);
            this.btnOpenHorasExigibles.TabIndex = 1;
            this.btnOpenHorasExigibles.Text = "Asignar horas exigibles";
            this.btnOpenHorasExigibles.UseVisualStyleBackColor = false;
            this.btnOpenHorasExigibles.Click += new System.EventHandler(this.btnOpenHorasExigibles_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInfo.Location = new System.Drawing.Point(92, 101);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(616, 56);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "El docente seleccionado no posee horas exigibles asignadas para el semestre ___. " +
    "";
            // 
            // Frm_Err_HorasExigibles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 253);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MdiChildrenMinimizedAnchorBottom = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Err_HorasExigibles";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advertencia";
            this.Load += new System.EventHandler(this.Frm_Err_HorasExigibles_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pixtbxWarning)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label lblInfo;
        private Button btnOk;
        private Button btnOpenHorasExigibles;
        private PictureBox pixtbxWarning;
    }
}