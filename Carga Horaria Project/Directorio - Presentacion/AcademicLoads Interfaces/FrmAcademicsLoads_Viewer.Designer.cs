namespace Directorio___Presentacion.AcademicLoads_Interfaces
{
    partial class FrmAcademicsLoads_Viewer
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbSemestre = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tvDocentesLst = new System.Windows.Forms.TreeView();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblHorasTotales = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotalGestion = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTotalInv = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotalDocencia = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtHorasT_Semestre = new System.Windows.Forms.TextBox();
            this.txtHorasT_Semana = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvAsignaturas = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvActividades = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.panelDocenteInfo = new System.Windows.Forms.Panel();
            this.lblHorasExigibles = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblSemestre = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblDocenteName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCloseWin = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panelContenedor.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignaturas)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividades)).BeginInit();
            this.panel6.SuspendLayout();
            this.panelSuperior.SuspendLayout();
            this.panelDocenteInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(40, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista de Docentes";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(46)))), ((int)(((byte)(160)))));
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.cmbSemestre);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tvDocentesLst);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 896);
            this.panel1.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(40, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(370, 99);
            this.label11.TabIndex = 15;
            this.label11.Text = "VISUALIZADOR DE CARGAS ACADÉMICAS";
            // 
            // cmbSemestre
            // 
            this.cmbSemestre.BackColor = System.Drawing.Color.LemonChiffon;
            this.cmbSemestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemestre.FormattingEnabled = true;
            this.cmbSemestre.Location = new System.Drawing.Point(169, 164);
            this.cmbSemestre.Name = "cmbSemestre";
            this.cmbSemestre.Size = new System.Drawing.Size(167, 28);
            this.cmbSemestre.TabIndex = 14;
            this.cmbSemestre.SelectedIndexChanged += new System.EventHandler(this.cmbSemestre_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(44, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 27);
            this.label7.TabIndex = 13;
            this.label7.Text = "Semestre";
            // 
            // tvDocentesLst
            // 
            this.tvDocentesLst.BackColor = System.Drawing.Color.RoyalBlue;
            this.tvDocentesLst.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tvDocentesLst.ForeColor = System.Drawing.Color.White;
            this.tvDocentesLst.Location = new System.Drawing.Point(40, 256);
            this.tvDocentesLst.Name = "tvDocentesLst";
            this.tvDocentesLst.Size = new System.Drawing.Size(370, 547);
            this.tvDocentesLst.TabIndex = 2;
            this.tvDocentesLst.Visible = false;
            this.tvDocentesLst.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDocentesLst_AfterSelect);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelMain.Controls.Add(this.panel4);
            this.panelMain.Controls.Add(this.panelSuperior);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(455, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1075, 896);
            this.panelMain.TabIndex = 1;
            this.panelMain.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panelContenedor);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 88);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1075, 808);
            this.panel4.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel7.Controls.Add(this.tableLayoutPanel1);
            this.panel7.Controls.Add(this.btnPrint);
            this.panel7.Controls.Add(this.textBox3);
            this.panel7.Controls.Add(this.textBox4);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 586);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1075, 222);
            this.panel7.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.79166F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.20833F));
            this.tableLayoutPanel1.Controls.Add(this.lblHorasTotales, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalGestion, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalInv, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalDocencia, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(42, 75);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.52113F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.47887F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(345, 125);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // lblHorasTotales
            // 
            this.lblHorasTotales.AutoSize = true;
            this.lblHorasTotales.BackColor = System.Drawing.Color.Khaki;
            this.lblHorasTotales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHorasTotales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHorasTotales.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHorasTotales.Location = new System.Drawing.Point(243, 95);
            this.lblHorasTotales.Name = "lblHorasTotales";
            this.lblHorasTotales.Size = new System.Drawing.Size(99, 30);
            this.lblHorasTotales.TabIndex = 7;
            this.lblHorasTotales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Khaki;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(3, 95);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(234, 30);
            this.label14.TabIndex = 6;
            this.label14.Text = "TOTAL";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalGestion
            // 
            this.lblTotalGestion.AutoSize = true;
            this.lblTotalGestion.BackColor = System.Drawing.Color.Honeydew;
            this.lblTotalGestion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalGestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalGestion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalGestion.Location = new System.Drawing.Point(243, 65);
            this.lblTotalGestion.Name = "lblTotalGestion";
            this.lblTotalGestion.Size = new System.Drawing.Size(99, 30);
            this.lblTotalGestion.TabIndex = 5;
            this.lblTotalGestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Honeydew;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(3, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(234, 30);
            this.label12.TabIndex = 4;
            this.label12.Text = "TOTAL GESTIÓN";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalInv
            // 
            this.lblTotalInv.AutoSize = true;
            this.lblTotalInv.BackColor = System.Drawing.Color.Honeydew;
            this.lblTotalInv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalInv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalInv.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalInv.Location = new System.Drawing.Point(243, 35);
            this.lblTotalInv.Name = "lblTotalInv";
            this.lblTotalInv.Size = new System.Drawing.Size(99, 30);
            this.lblTotalInv.TabIndex = 3;
            this.lblTotalInv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Honeydew;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(3, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(234, 30);
            this.label10.TabIndex = 2;
            this.label10.Text = "TOTAL INVESTIGACIÓN";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalDocencia
            // 
            this.lblTotalDocencia.AutoSize = true;
            this.lblTotalDocencia.BackColor = System.Drawing.Color.Honeydew;
            this.lblTotalDocencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalDocencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalDocencia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalDocencia.Location = new System.Drawing.Point(243, 0);
            this.lblTotalDocencia.Name = "lblTotalDocencia";
            this.lblTotalDocencia.Size = new System.Drawing.Size(99, 35);
            this.lblTotalDocencia.TabIndex = 1;
            this.lblTotalDocencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Honeydew;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(234, 35);
            this.label8.TabIndex = 0;
            this.label8.Text = "TOTAL DOCENCIA";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Orange;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(419, 90);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(158, 50);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "Exportar PDF";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(860, 251);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(76, 27);
            this.textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(766, 251);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(76, 27);
            this.textBox4.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(518, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total Dictado de Clases";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.SteelBlue;
            this.panel8.Controls.Add(this.label6);
            this.panel8.Location = new System.Drawing.Point(42, 36);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(344, 33);
            this.panel8.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(23, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 31);
            this.label6.TabIndex = 0;
            this.label6.Text = "Horas Totales";
            // 
            // panelContenedor
            // 
            this.panelContenedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContenedor.AutoScroll = true;
            this.panelContenedor.AutoScrollMinSize = new System.Drawing.Size(600, 800);
            this.panelContenedor.Controls.Add(this.panel2);
            this.panelContenedor.Controls.Add(this.panel5);
            this.panelContenedor.Location = new System.Drawing.Point(0, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1075, 594);
            this.panelContenedor.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel2.Controls.Add(this.txtHorasT_Semestre);
            this.panel2.Controls.Add(this.txtHorasT_Semana);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dgvAsignaturas);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(27, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(972, 297);
            this.panel2.TabIndex = 3;
            // 
            // txtHorasT_Semestre
            // 
            this.txtHorasT_Semestre.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtHorasT_Semestre.Enabled = false;
            this.txtHorasT_Semestre.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtHorasT_Semestre.ForeColor = System.Drawing.Color.Black;
            this.txtHorasT_Semestre.Location = new System.Drawing.Point(529, 255);
            this.txtHorasT_Semestre.Name = "txtHorasT_Semestre";
            this.txtHorasT_Semestre.Size = new System.Drawing.Size(132, 27);
            this.txtHorasT_Semestre.TabIndex = 6;
            // 
            // txtHorasT_Semana
            // 
            this.txtHorasT_Semana.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtHorasT_Semana.Enabled = false;
            this.txtHorasT_Semana.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtHorasT_Semana.ForeColor = System.Drawing.Color.Black;
            this.txtHorasT_Semana.Location = new System.Drawing.Point(360, 255);
            this.txtHorasT_Semana.Name = "txtHorasT_Semana";
            this.txtHorasT_Semana.Size = new System.Drawing.Size(131, 27);
            this.txtHorasT_Semana.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(167, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Total Dictado de Clases";
            // 
            // dgvAsignaturas
            // 
            this.dgvAsignaturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsignaturas.Location = new System.Drawing.Point(15, 53);
            this.dgvAsignaturas.Name = "dgvAsignaturas";
            this.dgvAsignaturas.RowHeadersWidth = 51;
            this.dgvAsignaturas.RowTemplate.Height = 29;
            this.dgvAsignaturas.Size = new System.Drawing.Size(650, 192);
            this.dgvAsignaturas.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(15, 14);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(361, 33);
            this.panel3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(23, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(261, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Gestión de Asignaturas";
            // 
            // panel5
            // 
            this.panel5.AutoScroll = true;
            this.panel5.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel5.Controls.Add(this.dgvActividades);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(27, 338);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(972, 419);
            this.panel5.TabIndex = 4;
            // 
            // dgvActividades
            // 
            this.dgvActividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActividades.Location = new System.Drawing.Point(15, 53);
            this.dgvActividades.Name = "dgvActividades";
            this.dgvActividades.RowHeadersWidth = 51;
            this.dgvActividades.RowTemplate.Height = 29;
            this.dgvActividades.Size = new System.Drawing.Size(791, 343);
            this.dgvActividades.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(15, 14);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(361, 33);
            this.panel6.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(23, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(258, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "Gestión de Actividades";
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelSuperior.Controls.Add(this.panelDocenteInfo);
            this.panelSuperior.Controls.Add(this.btnCloseWin);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1075, 88);
            this.panelSuperior.TabIndex = 0;
            // 
            // panelDocenteInfo
            // 
            this.panelDocenteInfo.Controls.Add(this.lblHorasExigibles);
            this.panelDocenteInfo.Controls.Add(this.label16);
            this.panelDocenteInfo.Controls.Add(this.lblSemestre);
            this.panelDocenteInfo.Controls.Add(this.label15);
            this.panelDocenteInfo.Controls.Add(this.lblDocenteName);
            this.panelDocenteInfo.Controls.Add(this.label9);
            this.panelDocenteInfo.Location = new System.Drawing.Point(27, 9);
            this.panelDocenteInfo.Name = "panelDocenteInfo";
            this.panelDocenteInfo.Size = new System.Drawing.Size(1027, 72);
            this.panelDocenteInfo.TabIndex = 8;
            this.panelDocenteInfo.Visible = false;
            // 
            // lblHorasExigibles
            // 
            this.lblHorasExigibles.AutoSize = true;
            this.lblHorasExigibles.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHorasExigibles.ForeColor = System.Drawing.Color.Gray;
            this.lblHorasExigibles.Location = new System.Drawing.Point(843, 0);
            this.lblHorasExigibles.Name = "lblHorasExigibles";
            this.lblHorasExigibles.Size = new System.Drawing.Size(90, 38);
            this.lblHorasExigibles.TabIndex = 11;
            this.lblHorasExigibles.Text = "name";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.ForeColor = System.Drawing.Color.DimGray;
            this.label16.Location = new System.Drawing.Point(618, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(224, 38);
            this.label16.TabIndex = 10;
            this.label16.Text = "Horas Exigibles:";
            // 
            // lblSemestre
            // 
            this.lblSemestre.AutoSize = true;
            this.lblSemestre.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSemestre.ForeColor = System.Drawing.Color.Gray;
            this.lblSemestre.Location = new System.Drawing.Point(150, 33);
            this.lblSemestre.Name = "lblSemestre";
            this.lblSemestre.Size = new System.Drawing.Size(90, 38);
            this.lblSemestre.TabIndex = 9;
            this.lblSemestre.Text = "name";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.Location = new System.Drawing.Point(3, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(146, 38);
            this.label15.TabIndex = 8;
            this.label15.Text = "Semestre:";
            // 
            // lblDocenteName
            // 
            this.lblDocenteName.AutoSize = true;
            this.lblDocenteName.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDocenteName.ForeColor = System.Drawing.Color.Gray;
            this.lblDocenteName.Location = new System.Drawing.Point(150, 0);
            this.lblDocenteName.Name = "lblDocenteName";
            this.lblDocenteName.Size = new System.Drawing.Size(90, 38);
            this.lblDocenteName.TabIndex = 7;
            this.lblDocenteName.Text = "name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 38);
            this.label9.TabIndex = 1;
            this.label9.Text = "Docente: ";
            // 
            // btnCloseWin
            // 
            this.btnCloseWin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseWin.BackColor = System.Drawing.Color.LightCoral;
            this.btnCloseWin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCloseWin.Font = new System.Drawing.Font("Roboto Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCloseWin.Location = new System.Drawing.Point(1163, 23);
            this.btnCloseWin.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnCloseWin.Name = "btnCloseWin";
            this.btnCloseWin.Size = new System.Drawing.Size(57, 41);
            this.btnCloseWin.TabIndex = 6;
            this.btnCloseWin.Text = "Cerrar";
            this.btnCloseWin.UseVisualStyleBackColor = false;
            this.btnCloseWin.Click += new System.EventHandler(this.btnCloseWin_Click);
            // 
            // FrmAcademicsLoads_Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1530, 896);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmAcademicsLoads_Viewer";
            this.Text = "Academic Load Manager";
            this.Load += new System.EventHandler(this.FrmAcademicsLoads_Manager_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panelContenedor.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignaturas)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividades)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panelSuperior.ResumeLayout(false);
            this.panelDocenteInfo.ResumeLayout(false);
            this.panelDocenteInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Label label1;
        private Panel panel1;
        private Panel panelMain;
        private Panel panel4;
        private Panel panel5;
        private DataGridView dgvActividades;
        private Panel panel6;
        private Label label3;
        private Panel panel2;
        private TextBox txtHorasT_Semestre;
        private TextBox txtHorasT_Semana;
        private Label label4;
        private Panel panel3;
        private Label label2;
        private Panel panelSuperior;
        private Button btnCloseWin;
        private Panel panel7;
        private Button btnPrint;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label5;
        private Panel panel8;
        private Label label6;
        private DataGridView dgvAsignaturas;
        private TreeView tvDocentesLst;
        private ComboBox cmbSemestre;
        private Label label7;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblHorasTotales;
        private Label label14;
        private Label lblTotalGestion;
        private Label label12;
        private Label lblTotalInv;
        private Label label10;
        private Label lblTotalDocencia;
        private Label label8;
        private Label label11;
        private Label label9;
        private Panel panelDocenteInfo;
        private Label lblDocenteName;
        private Label lblSemestre;
        private Label label15;
        private Label lblHorasExigibles;
        private Label label16;
        private Panel panelContenedor;
    }
}