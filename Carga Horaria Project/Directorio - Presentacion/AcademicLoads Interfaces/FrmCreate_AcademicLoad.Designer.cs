namespace Directorio___Presentacion.AcademicLoads_Interfaces
{
    partial class FrmCreate_AcademicLoad
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
            this.panelHorasExigibles = new System.Windows.Forms.TableLayoutPanel();
            this.lblSemanasClases = new System.Windows.Forms.Label();
            this.lblHorasExigibles = new System.Windows.Forms.Label();
            this.lblHorasFaltantes = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblSemanasSemestre = new System.Windows.Forms.Label();
            this.panelHoras = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtHorasInvestigacionMain = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtHorasGestionMain = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtHorasDocenteF11Main = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtHorasDocenteMain = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtClases = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtHorasTotales = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pieChart = new LiveCharts.WinForms.PieChart();
            this.btnNewCarga = new System.Windows.Forms.Button();
            this.btnInvestigacion = new System.Windows.Forms.Button();
            this.btnGestion = new System.Windows.Forms.Button();
            this.btnDocencia = new System.Windows.Forms.Button();
            this.btnAsignaturas = new System.Windows.Forms.Button();
            this.btnCrearCargaAcademica = new System.Windows.Forms.Button();
            this.cmbDocente = new System.Windows.Forms.ComboBox();
            this.cmbSemestre = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelHijo = new System.Windows.Forms.Panel();
            this.dgvCargasHorarias = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panelHorasExigibles.SuspendLayout();
            this.panelHoras.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelHijo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargasHorarias)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.panelHorasExigibles);
            this.panel1.Controls.Add(this.panelHoras);
            this.panel1.Controls.Add(this.btnNewCarga);
            this.panel1.Controls.Add(this.btnInvestigacion);
            this.panel1.Controls.Add(this.btnGestion);
            this.panel1.Controls.Add(this.btnDocencia);
            this.panel1.Controls.Add(this.btnAsignaturas);
            this.panel1.Controls.Add(this.btnCrearCargaAcademica);
            this.panel1.Controls.Add(this.cmbDocente);
            this.panel1.Controls.Add(this.cmbSemestre);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1653, 227);
            this.panel1.TabIndex = 0;
            // 
            // panelHorasExigibles
            // 
            this.panelHorasExigibles.ColumnCount = 4;
            this.panelHorasExigibles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelHorasExigibles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelHorasExigibles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelHorasExigibles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelHorasExigibles.Controls.Add(this.lblSemanasClases, 0, 1);
            this.panelHorasExigibles.Controls.Add(this.lblHorasExigibles, 0, 1);
            this.panelHorasExigibles.Controls.Add(this.lblHorasFaltantes, 0, 1);
            this.panelHorasExigibles.Controls.Add(this.label10, 1, 0);
            this.panelHorasExigibles.Controls.Add(this.label9, 0, 0);
            this.panelHorasExigibles.Controls.Add(this.label12, 2, 0);
            this.panelHorasExigibles.Controls.Add(this.label11, 3, 0);
            this.panelHorasExigibles.Controls.Add(this.lblSemanasSemestre, 3, 1);
            this.panelHorasExigibles.Location = new System.Drawing.Point(508, 20);
            this.panelHorasExigibles.Name = "panelHorasExigibles";
            this.panelHorasExigibles.RowCount = 2;
            this.panelHorasExigibles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.06202F));
            this.panelHorasExigibles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.93798F));
            this.panelHorasExigibles.Size = new System.Drawing.Size(389, 129);
            this.panelHorasExigibles.TabIndex = 24;
            this.panelHorasExigibles.Visible = false;
            this.panelHorasExigibles.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHorasExigibles_Paint);
            // 
            // lblSemanasClases
            // 
            this.lblSemanasClases.AutoSize = true;
            this.lblSemanasClases.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblSemanasClases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSemanasClases.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSemanasClases.Location = new System.Drawing.Point(197, 62);
            this.lblSemanasClases.Name = "lblSemanasClases";
            this.lblSemanasClases.Size = new System.Drawing.Size(91, 67);
            this.lblSemanasClases.TabIndex = 4;
            this.lblSemanasClases.Text = "0";
            this.lblSemanasClases.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHorasExigibles
            // 
            this.lblHorasExigibles.AutoSize = true;
            this.lblHorasExigibles.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblHorasExigibles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHorasExigibles.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHorasExigibles.Location = new System.Drawing.Point(3, 62);
            this.lblHorasExigibles.Name = "lblHorasExigibles";
            this.lblHorasExigibles.Size = new System.Drawing.Size(91, 67);
            this.lblHorasExigibles.TabIndex = 3;
            this.lblHorasExigibles.Text = "0";
            this.lblHorasExigibles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHorasFaltantes
            // 
            this.lblHorasFaltantes.AutoSize = true;
            this.lblHorasFaltantes.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblHorasFaltantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHorasFaltantes.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHorasFaltantes.Location = new System.Drawing.Point(100, 62);
            this.lblHorasFaltantes.Name = "lblHorasFaltantes";
            this.lblHorasFaltantes.Size = new System.Drawing.Size(91, 67);
            this.lblHorasFaltantes.TabIndex = 2;
            this.lblHorasFaltantes.Text = "0";
            this.lblHorasFaltantes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.LightSalmon;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(100, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 62);
            this.label10.TabIndex = 1;
            this.label10.Text = "Horas Faltantes";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.LightSalmon;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 62);
            this.label9.TabIndex = 0;
            this.label9.Text = "Horas Exigibles";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.LightSalmon;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(197, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 62);
            this.label12.TabIndex = 5;
            this.label12.Text = "Semanas de Clase";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.LightSalmon;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(294, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 62);
            this.label11.TabIndex = 6;
            this.label11.Text = "Semanas del Semestre";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSemanasSemestre
            // 
            this.lblSemanasSemestre.AutoSize = true;
            this.lblSemanasSemestre.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblSemanasSemestre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSemanasSemestre.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSemanasSemestre.Location = new System.Drawing.Point(294, 62);
            this.lblSemanasSemestre.Name = "lblSemanasSemestre";
            this.lblSemanasSemestre.Size = new System.Drawing.Size(92, 67);
            this.lblSemanasSemestre.TabIndex = 7;
            this.lblSemanasSemestre.Text = "0";
            this.lblSemanasSemestre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelHoras
            // 
            this.panelHoras.Controls.Add(this.tableLayoutPanel1);
            this.panelHoras.Controls.Add(this.label7);
            this.panelHoras.Controls.Add(this.pieChart);
            this.panelHoras.Location = new System.Drawing.Point(917, 9);
            this.panelHoras.Name = "panelHoras";
            this.panelHoras.Size = new System.Drawing.Size(698, 212);
            this.panelHoras.TabIndex = 22;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.txtHorasInvestigacionMain, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label23, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtHorasGestionMain, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label21, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtHorasDocenteF11Main, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label19, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtHorasDocenteMain, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label17, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtClases, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtHorasTotales, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.83317F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.001F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.83317F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.83317F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.83317F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.83317F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.83317F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(412, 164);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // txtHorasInvestigacionMain
            // 
            this.txtHorasInvestigacionMain.AutoSize = true;
            this.txtHorasInvestigacionMain.BackColor = System.Drawing.Color.SteelBlue;
            this.txtHorasInvestigacionMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHorasInvestigacionMain.Font = new System.Drawing.Font("Segoe UI Semibold", 11.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtHorasInvestigacionMain.ForeColor = System.Drawing.Color.White;
            this.txtHorasInvestigacionMain.Location = new System.Drawing.Point(312, 108);
            this.txtHorasInvestigacionMain.Name = "txtHorasInvestigacionMain";
            this.txtHorasInvestigacionMain.Size = new System.Drawing.Size(97, 25);
            this.txtHorasInvestigacionMain.TabIndex = 11;
            this.txtHorasInvestigacionMain.Text = "Total Dictado de Clases:";
            this.txtHorasInvestigacionMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.SteelBlue;
            this.label23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label23.Font = new System.Drawing.Font("Segoe UI Semibold", 11.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(3, 108);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(303, 25);
            this.label23.TabIndex = 10;
            this.label23.Text = "Componente Investigación:";
            // 
            // txtHorasGestionMain
            // 
            this.txtHorasGestionMain.AutoSize = true;
            this.txtHorasGestionMain.BackColor = System.Drawing.Color.SteelBlue;
            this.txtHorasGestionMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHorasGestionMain.Font = new System.Drawing.Font("Segoe UI Semibold", 11.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtHorasGestionMain.ForeColor = System.Drawing.Color.White;
            this.txtHorasGestionMain.Location = new System.Drawing.Point(312, 83);
            this.txtHorasGestionMain.Name = "txtHorasGestionMain";
            this.txtHorasGestionMain.Size = new System.Drawing.Size(97, 25);
            this.txtHorasGestionMain.TabIndex = 9;
            this.txtHorasGestionMain.Text = "Total Dictado de Clases:";
            this.txtHorasGestionMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.SteelBlue;
            this.label21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label21.Font = new System.Drawing.Font("Segoe UI Semibold", 11.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(3, 83);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(303, 25);
            this.label21.TabIndex = 8;
            this.label21.Text = "Componente Gestión:";
            // 
            // txtHorasDocenteF11Main
            // 
            this.txtHorasDocenteF11Main.AutoSize = true;
            this.txtHorasDocenteF11Main.BackColor = System.Drawing.Color.SteelBlue;
            this.txtHorasDocenteF11Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHorasDocenteF11Main.Font = new System.Drawing.Font("Segoe UI Semibold", 11.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtHorasDocenteF11Main.ForeColor = System.Drawing.Color.White;
            this.txtHorasDocenteF11Main.Location = new System.Drawing.Point(312, 58);
            this.txtHorasDocenteF11Main.Name = "txtHorasDocenteF11Main";
            this.txtHorasDocenteF11Main.Size = new System.Drawing.Size(97, 25);
            this.txtHorasDocenteF11Main.TabIndex = 7;
            this.txtHorasDocenteF11Main.Text = "Total Dictado de Clases:";
            this.txtHorasDocenteF11Main.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.SteelBlue;
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Font = new System.Drawing.Font("Segoe UI Semibold", 11.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(3, 58);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(303, 25);
            this.label19.TabIndex = 6;
            this.label19.Text = "Componente Docente F 1:1:";
            // 
            // txtHorasDocenteMain
            // 
            this.txtHorasDocenteMain.AutoSize = true;
            this.txtHorasDocenteMain.BackColor = System.Drawing.Color.SteelBlue;
            this.txtHorasDocenteMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHorasDocenteMain.Font = new System.Drawing.Font("Segoe UI Semibold", 11.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtHorasDocenteMain.ForeColor = System.Drawing.Color.White;
            this.txtHorasDocenteMain.Location = new System.Drawing.Point(312, 33);
            this.txtHorasDocenteMain.Name = "txtHorasDocenteMain";
            this.txtHorasDocenteMain.Size = new System.Drawing.Size(97, 25);
            this.txtHorasDocenteMain.TabIndex = 5;
            this.txtHorasDocenteMain.Text = "Total Dictado de Clases:";
            this.txtHorasDocenteMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.SteelBlue;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("Segoe UI Semibold", 11.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(3, 33);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(303, 25);
            this.label17.TabIndex = 4;
            this.label17.Text = "Componente Docente 1:1:";
            // 
            // txtClases
            // 
            this.txtClases.AutoSize = true;
            this.txtClases.BackColor = System.Drawing.Color.BurlyWood;
            this.txtClases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtClases.Font = new System.Drawing.Font("Segoe UI Semibold", 11.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtClases.ForeColor = System.Drawing.Color.DimGray;
            this.txtClases.Location = new System.Drawing.Point(312, 0);
            this.txtClases.Name = "txtClases";
            this.txtClases.Size = new System.Drawing.Size(97, 25);
            this.txtClases.TabIndex = 1;
            this.txtClases.Text = "Total Dictado de Clases:";
            this.txtClases.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Orange;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 11.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(3, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(303, 25);
            this.label13.TabIndex = 0;
            this.label13.Text = "Total Dictado de Clases:";
            // 
            // txtHorasTotales
            // 
            this.txtHorasTotales.AutoSize = true;
            this.txtHorasTotales.BackColor = System.Drawing.Color.Khaki;
            this.txtHorasTotales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHorasTotales.Font = new System.Drawing.Font("Segoe UI Semibold", 11.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtHorasTotales.ForeColor = System.Drawing.Color.DimGray;
            this.txtHorasTotales.Location = new System.Drawing.Point(312, 133);
            this.txtHorasTotales.Name = "txtHorasTotales";
            this.txtHorasTotales.Size = new System.Drawing.Size(97, 31);
            this.txtHorasTotales.TabIndex = 3;
            this.txtHorasTotales.Text = "Total Dictado de Clases:";
            this.txtHorasTotales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Gold;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("Segoe UI Semibold", 11.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.Location = new System.Drawing.Point(3, 133);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(303, 31);
            this.label15.TabIndex = 2;
            this.label15.Text = "Horas Totales (Componentes):";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Gold;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(325, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 27);
            this.label7.TabIndex = 7;
            this.label7.Text = "Horas";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pieChart
            // 
            this.pieChart.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pieChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pieChart.Location = new System.Drawing.Point(460, 3);
            this.pieChart.Name = "pieChart";
            this.pieChart.Size = new System.Drawing.Size(225, 209);
            this.pieChart.TabIndex = 0;
            this.pieChart.Text = "pieChart1";
            // 
            // btnNewCarga
            // 
            this.btnNewCarga.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnNewCarga.Location = new System.Drawing.Point(23, 129);
            this.btnNewCarga.Name = "btnNewCarga";
            this.btnNewCarga.Size = new System.Drawing.Size(136, 43);
            this.btnNewCarga.TabIndex = 20;
            this.btnNewCarga.Text = "Nueva Carga";
            this.btnNewCarga.UseVisualStyleBackColor = false;
            this.btnNewCarga.Click += new System.EventHandler(this.btnNewCarga_Click);
            // 
            // btnInvestigacion
            // 
            this.btnInvestigacion.BackColor = System.Drawing.Color.LightSalmon;
            this.btnInvestigacion.FlatAppearance.BorderSize = 0;
            this.btnInvestigacion.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.btnInvestigacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvestigacion.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnInvestigacion.ForeColor = System.Drawing.Color.Transparent;
            this.btnInvestigacion.Location = new System.Drawing.Point(425, 192);
            this.btnInvestigacion.Name = "btnInvestigacion";
            this.btnInvestigacion.Size = new System.Drawing.Size(145, 35);
            this.btnInvestigacion.TabIndex = 19;
            this.btnInvestigacion.TabStop = false;
            this.btnInvestigacion.Text = "Investigación";
            this.btnInvestigacion.UseVisualStyleBackColor = false;
            this.btnInvestigacion.Visible = false;
            this.btnInvestigacion.Click += new System.EventHandler(this.btnInvestigacion_Click);
            // 
            // btnGestion
            // 
            this.btnGestion.BackColor = System.Drawing.Color.LightSalmon;
            this.btnGestion.FlatAppearance.BorderSize = 0;
            this.btnGestion.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.btnGestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestion.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGestion.ForeColor = System.Drawing.Color.Transparent;
            this.btnGestion.Location = new System.Drawing.Point(284, 192);
            this.btnGestion.Name = "btnGestion";
            this.btnGestion.Size = new System.Drawing.Size(145, 35);
            this.btnGestion.TabIndex = 18;
            this.btnGestion.TabStop = false;
            this.btnGestion.Text = "Gestión";
            this.btnGestion.UseVisualStyleBackColor = false;
            this.btnGestion.Visible = false;
            this.btnGestion.Click += new System.EventHandler(this.btnGestion_Click);
            // 
            // btnDocencia
            // 
            this.btnDocencia.BackColor = System.Drawing.Color.LightSalmon;
            this.btnDocencia.FlatAppearance.BorderSize = 0;
            this.btnDocencia.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.btnDocencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDocencia.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDocencia.ForeColor = System.Drawing.Color.Transparent;
            this.btnDocencia.Location = new System.Drawing.Point(144, 192);
            this.btnDocencia.Name = "btnDocencia";
            this.btnDocencia.Size = new System.Drawing.Size(145, 35);
            this.btnDocencia.TabIndex = 17;
            this.btnDocencia.TabStop = false;
            this.btnDocencia.Text = "Docencia";
            this.btnDocencia.UseVisualStyleBackColor = false;
            this.btnDocencia.Visible = false;
            this.btnDocencia.Click += new System.EventHandler(this.btnDocencia_Click);
            // 
            // btnAsignaturas
            // 
            this.btnAsignaturas.BackColor = System.Drawing.Color.LightSalmon;
            this.btnAsignaturas.FlatAppearance.BorderSize = 0;
            this.btnAsignaturas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignaturas.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAsignaturas.ForeColor = System.Drawing.Color.Transparent;
            this.btnAsignaturas.Location = new System.Drawing.Point(3, 192);
            this.btnAsignaturas.Name = "btnAsignaturas";
            this.btnAsignaturas.Size = new System.Drawing.Size(145, 35);
            this.btnAsignaturas.TabIndex = 16;
            this.btnAsignaturas.TabStop = false;
            this.btnAsignaturas.Text = "Asignaturas";
            this.btnAsignaturas.UseVisualStyleBackColor = false;
            this.btnAsignaturas.Visible = false;
            this.btnAsignaturas.Click += new System.EventHandler(this.btnAsignaturas_Click);
            // 
            // btnCrearCargaAcademica
            // 
            this.btnCrearCargaAcademica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(136)))), ((int)(((byte)(139)))));
            this.btnCrearCargaAcademica.FlatAppearance.BorderSize = 2;
            this.btnCrearCargaAcademica.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCrearCargaAcademica.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCrearCargaAcademica.ForeColor = System.Drawing.Color.White;
            this.btnCrearCargaAcademica.Location = new System.Drawing.Point(330, 124);
            this.btnCrearCargaAcademica.Name = "btnCrearCargaAcademica";
            this.btnCrearCargaAcademica.Size = new System.Drawing.Size(158, 58);
            this.btnCrearCargaAcademica.TabIndex = 15;
            this.btnCrearCargaAcademica.Text = "Crear Carga Académica";
            this.btnCrearCargaAcademica.UseVisualStyleBackColor = false;
            this.btnCrearCargaAcademica.Click += new System.EventHandler(this.btnCrearCargaAcademica_Click);
            // 
            // cmbDocente
            // 
            this.cmbDocente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDocente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDocente.BackColor = System.Drawing.Color.LemonChiffon;
            this.cmbDocente.FormattingEnabled = true;
            this.cmbDocente.Location = new System.Drawing.Point(148, 88);
            this.cmbDocente.Name = "cmbDocente";
            this.cmbDocente.Size = new System.Drawing.Size(309, 28);
            this.cmbDocente.TabIndex = 13;
            this.cmbDocente.SelectedIndexChanged += new System.EventHandler(this.cmbDocente_SelectedIndexChanged);
            // 
            // cmbSemestre
            // 
            this.cmbSemestre.BackColor = System.Drawing.Color.LemonChiffon;
            this.cmbSemestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemestre.FormattingEnabled = true;
            this.cmbSemestre.Location = new System.Drawing.Point(148, 44);
            this.cmbSemestre.Name = "cmbSemestre";
            this.cmbSemestre.Size = new System.Drawing.Size(167, 28);
            this.cmbSemestre.TabIndex = 12;
            this.cmbSemestre.SelectedIndexChanged += new System.EventHandler(this.cmbSemestre_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(23, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Docente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(23, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Semestre";
            // 
            // panelHijo
            // 
            this.panelHijo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(146)))));
            this.panelHijo.Controls.Add(this.dgvCargasHorarias);
            this.panelHijo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHijo.Location = new System.Drawing.Point(0, 227);
            this.panelHijo.Name = "panelHijo";
            this.panelHijo.Size = new System.Drawing.Size(1653, 764);
            this.panelHijo.TabIndex = 1;
            // 
            // dgvCargasHorarias
            // 
            this.dgvCargasHorarias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargasHorarias.Location = new System.Drawing.Point(148, 45);
            this.dgvCargasHorarias.Name = "dgvCargasHorarias";
            this.dgvCargasHorarias.RowHeadersWidth = 51;
            this.dgvCargasHorarias.RowTemplate.Height = 29;
            this.dgvCargasHorarias.Size = new System.Drawing.Size(422, 645);
            this.dgvCargasHorarias.TabIndex = 0;
            this.dgvCargasHorarias.Visible = false;
            this.dgvCargasHorarias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCargasHorarias_CellContentClick);
            // 
            // FrmCreate_AcademicLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1653, 991);
            this.Controls.Add(this.panelHijo);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCreate_AcademicLoad";
            this.Text = "Carga Académica";
            this.Load += new System.EventHandler(this.FrmCreate_AcademicLoad_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmCreate_AcademicLoad_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelHorasExigibles.ResumeLayout(false);
            this.panelHorasExigibles.PerformLayout();
            this.panelHoras.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelHijo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargasHorarias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button btnCrearCargaAcademica;
        private ComboBox cmbSemestre;
        private Label label7;
        private Label label2;
        private Label label1;
        private LiveCharts.WinForms.PieChart pieChart;
        private Panel panelHijo;
        private Button btnNewCarga;
        private DataGridView dgvCargasHorarias;
        private Panel panelHoras;
        public Button btnAsignaturas;
        public ComboBox cmbDocente;
        private TableLayoutPanel panelHorasExigibles;
        private Label lblHorasFaltantes;
        private Label lblSemanasClases;
        private Label label10;
        private Label label9;
        private Label lblHorasExigibles;
        private Label label12;
        private Label label11;
        private Label lblSemanasSemestre;
        public Button btnInvestigacion;
        public Button btnGestion;
        public Button btnDocencia;
        private TableLayoutPanel tableLayoutPanel1;
        private Label txtHorasInvestigacionMain;
        private Label label23;
        private Label txtHorasGestionMain;
        private Label label21;
        private Label txtHorasDocenteF11Main;
        private Label label19;
        private Label txtHorasDocenteMain;
        private Label label17;
        private Label txtClases;
        private Label label13;
        private Label txtHorasTotales;
        private Label label15;
    }
}