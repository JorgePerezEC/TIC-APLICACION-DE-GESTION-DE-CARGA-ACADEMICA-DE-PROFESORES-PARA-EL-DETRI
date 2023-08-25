namespace Directorio___Presentacion.MailSend
{
    partial class FrmSendMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSendMail));
            this.btnCancelar = new MaterialSkin.Controls.MaterialButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAsunto = new System.Windows.Forms.TextBox();
            this.lblPara = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCorreoDestino = new System.Windows.Forms.TextBox();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.btnSend = new MaterialSkin.Controls.MaterialButton();
            this.btnEditMail = new System.Windows.Forms.Button();
            this.lblNota = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = false;
            this.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancelar.Depth = 0;
            this.btnCancelar.HighEmphasis = true;
            this.btnCancelar.Icon = null;
            this.btnCancelar.Location = new System.Drawing.Point(337, 529);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancelar.Size = new System.Drawing.Size(187, 45);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "cancelar";
            this.btnCancelar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancelar.UseAccentColor = false;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(75, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(605, 35);
            this.label3.TabIndex = 9;
            this.label3.Text = "CONFIGURAR CAMPOS DEL CORREO ELECTRÓNICO";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtAsunto, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPara, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtCorreoDestino, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtBody, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(119, 104);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(545, 340);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 238);
            this.label4.TabIndex = 4;
            this.label4.Text = "\r\nMensaje:";
            // 
            // txtAsunto
            // 
            this.txtAsunto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAsunto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAsunto.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtAsunto.ForeColor = System.Drawing.Color.Black;
            this.txtAsunto.Location = new System.Drawing.Point(126, 60);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.PlaceholderText = "Asunto del mensaje ...";
            this.txtAsunto.Size = new System.Drawing.Size(401, 32);
            this.txtAsunto.TabIndex = 3;
            // 
            // lblPara
            // 
            this.lblPara.AutoSize = true;
            this.lblPara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPara.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPara.ForeColor = System.Drawing.Color.White;
            this.lblPara.Location = new System.Drawing.Point(3, 0);
            this.lblPara.Name = "lblPara";
            this.lblPara.Size = new System.Drawing.Size(103, 51);
            this.lblPara.TabIndex = 0;
            this.lblPara.Text = "Para:";
            this.lblPara.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 51);
            this.label2.TabIndex = 1;
            this.label2.Text = "Asunto:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCorreoDestino
            // 
            this.txtCorreoDestino.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCorreoDestino.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCorreoDestino.Enabled = false;
            this.txtCorreoDestino.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtCorreoDestino.ForeColor = System.Drawing.Color.Black;
            this.txtCorreoDestino.Location = new System.Drawing.Point(126, 9);
            this.txtCorreoDestino.Name = "txtCorreoDestino";
            this.txtCorreoDestino.PlaceholderText = "ejemplo@correo.com";
            this.txtCorreoDestino.Size = new System.Drawing.Size(401, 32);
            this.txtCorreoDestino.TabIndex = 2;
            // 
            // txtBody
            // 
            this.txtBody.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBody.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBody.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBody.ForeColor = System.Drawing.Color.Black;
            this.txtBody.Location = new System.Drawing.Point(128, 123);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.PlaceholderText = "Cuerpo del mensaje ...";
            this.txtBody.Size = new System.Drawing.Size(398, 195);
            this.txtBody.TabIndex = 11;
            // 
            // btnSend
            // 
            this.btnSend.AutoSize = false;
            this.btnSend.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSend.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSend.Depth = 0;
            this.btnSend.HighEmphasis = true;
            this.btnSend.Icon = null;
            this.btnSend.Location = new System.Drawing.Point(117, 529);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSend.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSend.Name = "btnSend";
            this.btnSend.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSend.Size = new System.Drawing.Size(187, 45);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "enviar";
            this.btnSend.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSend.UseAccentColor = false;
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnEditMail
            // 
            this.btnEditMail.BackColor = System.Drawing.Color.Transparent;
            this.btnEditMail.ForeColor = System.Drawing.Color.Turquoise;
            this.btnEditMail.Location = new System.Drawing.Point(670, 107);
            this.btnEditMail.Name = "btnEditMail";
            this.btnEditMail.Size = new System.Drawing.Size(45, 44);
            this.btnEditMail.TabIndex = 11;
            this.btnEditMail.UseVisualStyleBackColor = false;
            this.btnEditMail.Click += new System.EventHandler(this.btnEditMail_Click);
            // 
            // lblNota
            // 
            this.lblNota.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNota.ForeColor = System.Drawing.Color.White;
            this.lblNota.Location = new System.Drawing.Point(122, 444);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(565, 49);
            this.lblNota.TabIndex = 12;
            this.lblNota.Text = "NOTA: El asunto y cuerpo del mensaje será el mismo para todos los docentes. Los c" +
    "orreos serán enviados a las direcciones de correo registradas en el sistema.";
            this.lblNota.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNota.Visible = false;
            // 
            // FrmSendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(33)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(863, 605);
            this.Controls.Add(this.lblNota);
            this.Controls.Add(this.btnEditMail);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnSend);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSendMail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ENVIAR CORREO ELECTRÓNICO";
            this.Load += new System.EventHandler(this.FrmSendMail_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnCancelar;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label4;
        private TextBox txtAsunto;
        private Label lblPara;
        private Label label2;
        private TextBox txtCorreoDestino;
        private TextBox txtBody;
        private MaterialSkin.Controls.MaterialButton btnSend;
        private Button btnEditMail;
        private Label lblNota;
    }
}