namespace Directorio___Presentacion.AcademicLoads_Interfaces.EditData_Frms
{
    partial class FrmEditServerConection
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
            this.txtServerName = new MaterialSkin.Controls.MaterialTextBox2();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new MaterialSkin.Controls.MaterialButton();
            this.btnTestConection = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // txtServerName
            // 
            this.txtServerName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerName.AnimateReadOnly = false;
            this.txtServerName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtServerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtServerName.Depth = 0;
            this.txtServerName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtServerName.HideSelection = true;
            this.txtServerName.LeadingIcon = null;
            this.txtServerName.Location = new System.Drawing.Point(429, 147);
            this.txtServerName.MaxLength = 32767;
            this.txtServerName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.PasswordChar = '\0';
            this.txtServerName.PrefixSuffixText = null;
            this.txtServerName.ReadOnly = false;
            this.txtServerName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtServerName.SelectedText = "";
            this.txtServerName.SelectionLength = 0;
            this.txtServerName.SelectionStart = 0;
            this.txtServerName.ShortcutsEnabled = true;
            this.txtServerName.Size = new System.Drawing.Size(689, 48);
            this.txtServerName.TabIndex = 13;
            this.txtServerName.TabStop = false;
            this.txtServerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtServerName.TrailingIcon = null;
            this.txtServerName.UseSystemPasswordChar = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(16, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 48);
            this.label1.TabIndex = 17;
            this.label1.Text = "INGRESE LA CADENA DE CONEXIÓN:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = false;
            this.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancelar.Depth = 0;
            this.btnCancelar.HighEmphasis = true;
            this.btnCancelar.Icon = null;
            this.btnCancelar.Location = new System.Drawing.Point(580, 244);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancelar.Size = new System.Drawing.Size(248, 54);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "cancelar";
            this.btnCancelar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancelar.UseAccentColor = false;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnTestConection
            // 
            this.btnTestConection.AutoSize = false;
            this.btnTestConection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTestConection.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnTestConection.Depth = 0;
            this.btnTestConection.HighEmphasis = true;
            this.btnTestConection.Icon = null;
            this.btnTestConection.Location = new System.Drawing.Point(288, 244);
            this.btnTestConection.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnTestConection.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTestConection.Name = "btnTestConection";
            this.btnTestConection.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnTestConection.Size = new System.Drawing.Size(248, 54);
            this.btnTestConection.TabIndex = 15;
            this.btnTestConection.Text = "EStablecer conexión";
            this.btnTestConection.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnTestConection.UseAccentColor = false;
            this.btnTestConection.UseVisualStyleBackColor = true;
            // 
            // FrmEditServerConection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 334);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnTestConection);
            this.Controls.Add(this.txtServerName);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditServerConection";
            this.Padding = new System.Windows.Forms.Padding(4, 76, 4, 4);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EDITAR CONEXIÓN CON LA BASE DE DATOS";
            this.Load += new System.EventHandler(this.FrmEditServerConection_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialTextBox2 txtServerName;
        private Label label1;
        private MaterialSkin.Controls.MaterialButton btnCancelar;
        private MaterialSkin.Controls.MaterialButton btnTestConection;
    }
}