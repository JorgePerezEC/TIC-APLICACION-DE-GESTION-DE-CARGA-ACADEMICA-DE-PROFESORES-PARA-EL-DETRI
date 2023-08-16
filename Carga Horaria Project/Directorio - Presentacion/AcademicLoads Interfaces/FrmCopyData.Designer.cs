namespace Directorio___Presentacion.AcademicLoads_Interfaces
{
    partial class FrmCopyData
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
            this.panelCreate = new System.Windows.Forms.Panel();
            this.lblNota = new System.Windows.Forms.Label();
            this.btnCopyInfo = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbSemestreACopiar = new System.Windows.Forms.ComboBox();
            this.cmbSemestreAPegar = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCloseWin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelCreate.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCreate
            // 
            this.panelCreate.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelCreate.Controls.Add(this.lblNota);
            this.panelCreate.Controls.Add(this.btnCopyInfo);
            this.panelCreate.Controls.Add(this.tableLayoutPanel1);
            this.panelCreate.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCreate.Location = new System.Drawing.Point(0, 95);
            this.panelCreate.Name = "panelCreate";
            this.panelCreate.Size = new System.Drawing.Size(1550, 347);
            this.panelCreate.TabIndex = 11;
            // 
            // lblNota
            // 
            this.lblNota.BackColor = System.Drawing.Color.Gold;
            this.lblNota.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNota.ForeColor = System.Drawing.Color.DimGray;
            this.lblNota.Location = new System.Drawing.Point(32, 163);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(305, 88);
            this.lblNota.TabIndex = 27;
            this.lblNota.Text = "Se recomienda realizar este proceso con el semestre completamente nuevo sin infor" +
    "mación previamente agregada.";
            this.lblNota.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCopyInfo
            // 
            this.btnCopyInfo.AutoSize = false;
            this.btnCopyInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCopyInfo.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCopyInfo.Depth = 0;
            this.btnCopyInfo.Enabled = false;
            this.btnCopyInfo.HighEmphasis = true;
            this.btnCopyInfo.Icon = null;
            this.btnCopyInfo.Location = new System.Drawing.Point(782, 26);
            this.btnCopyInfo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCopyInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCopyInfo.Name = "btnCopyInfo";
            this.btnCopyInfo.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCopyInfo.Size = new System.Drawing.Size(124, 45);
            this.btnCopyInfo.TabIndex = 26;
            this.btnCopyInfo.Text = "COPIAR INFORMACIÓN";
            this.btnCopyInfo.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCopyInfo.UseAccentColor = false;
            this.btnCopyInfo.UseVisualStyleBackColor = true;
            this.btnCopyInfo.Click += new System.EventHandler(this.btnCopyInfo_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.cmbSemestreACopiar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbSemestreAPegar, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(32, 29);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(680, 88);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // cmbSemestreACopiar
            // 
            this.cmbSemestreACopiar.BackColor = System.Drawing.Color.LemonChiffon;
            this.cmbSemestreACopiar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemestreACopiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSemestreACopiar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbSemestreACopiar.FormattingEnabled = true;
            this.cmbSemestreACopiar.Location = new System.Drawing.Point(343, 3);
            this.cmbSemestreACopiar.Name = "cmbSemestreACopiar";
            this.cmbSemestreACopiar.Size = new System.Drawing.Size(167, 32);
            this.cmbSemestreACopiar.TabIndex = 15;
            this.cmbSemestreACopiar.SelectedIndexChanged += new System.EventHandler(this.cmbSemestreACopiar_SelectedIndexChanged);
            // 
            // cmbSemestreAPegar
            // 
            this.cmbSemestreAPegar.BackColor = System.Drawing.Color.LemonChiffon;
            this.cmbSemestreAPegar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemestreAPegar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSemestreAPegar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbSemestreAPegar.FormattingEnabled = true;
            this.cmbSemestreAPegar.Location = new System.Drawing.Point(343, 47);
            this.cmbSemestreAPegar.Name = "cmbSemestreAPegar";
            this.cmbSemestreAPegar.Size = new System.Drawing.Size(167, 32);
            this.cmbSemestreAPegar.TabIndex = 14;
            this.cmbSemestreAPegar.SelectedIndexChanged += new System.EventHandler(this.cmbSemestreAPegar_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(334, 44);
            this.label4.TabIndex = 13;
            this.label4.Text = "SEMESTRE CON INFORMACIÓN:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(334, 44);
            this.label2.TabIndex = 14;
            this.label2.Text = "SEMESTRE OBJETIVO:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnCloseWin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1550, 95);
            this.panel1.TabIndex = 10;
            // 
            // btnCloseWin
            // 
            this.btnCloseWin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseWin.BackColor = System.Drawing.Color.LightCoral;
            this.btnCloseWin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCloseWin.Font = new System.Drawing.Font("Roboto Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCloseWin.Location = new System.Drawing.Point(1350, 30);
            this.btnCloseWin.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnCloseWin.Name = "btnCloseWin";
            this.btnCloseWin.Size = new System.Drawing.Size(125, 26);
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
            this.label1.Size = new System.Drawing.Size(461, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "TRANSFERIR INFORMACIÓN ENTRE SEMESTRES";
            // 
            // FrmCopyData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1550, 904);
            this.Controls.Add(this.panelCreate);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCopyData";
            this.ShowIcon = false;
            this.Text = "FrmCopyData";
            this.Load += new System.EventHandler(this.FrmCopyData_Load);
            this.panelCreate.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelCreate;
        private Panel panel1;
        private Button btnCloseWin;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox cmbSemestreACopiar;
        private ComboBox cmbSemestreAPegar;
        private Label label4;
        private Label label2;
        private Label lblNota;
        private MaterialSkin.Controls.MaterialButton btnCopyInfo;
    }
}