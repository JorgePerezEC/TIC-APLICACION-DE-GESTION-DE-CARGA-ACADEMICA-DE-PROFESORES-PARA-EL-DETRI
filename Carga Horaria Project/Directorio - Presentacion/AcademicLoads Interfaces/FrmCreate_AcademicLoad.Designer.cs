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
            this.txtClases = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHorasTotales = new System.Windows.Forms.TextBox();
            this.txtHorasInvestigacionMain = new System.Windows.Forms.TextBox();
            this.txtHorasGestionMain = new System.Windows.Forms.TextBox();
            this.txtHorasDocenteMain = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pieChart = new LiveCharts.WinForms.PieChart();
            this.label6 = new System.Windows.Forms.Label();
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
            this.panel1.Size = new System.Drawing.Size(1627, 227);
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
            this.panelHoras.Controls.Add(this.txtClases);
            this.panelHoras.Controls.Add(this.label8);
            this.panelHoras.Controls.Add(this.txtHorasTotales);
            this.panelHoras.Controls.Add(this.txtHorasInvestigacionMain);
            this.panelHoras.Controls.Add(this.txtHorasGestionMain);
            this.panelHoras.Controls.Add(this.txtHorasDocenteMain);
            this.panelHoras.Controls.Add(this.label7);
            this.panelHoras.Controls.Add(this.label5);
            this.panelHoras.Controls.Add(this.label4);
            this.panelHoras.Controls.Add(this.label3);
            this.panelHoras.Controls.Add(this.pieChart);
            this.panelHoras.Controls.Add(this.label6);
            this.panelHoras.Location = new System.Drawing.Point(917, 9);
            this.panelHoras.Name = "panelHoras";
            this.panelHoras.Size = new System.Drawing.Size(698, 212);
            this.panelHoras.TabIndex = 22;
            // 
            // txtClases
            // 
            this.txtClases.BackColor = System.Drawing.Color.LightCoral;
            this.txtClases.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClases.Enabled = false;
            this.txtClases.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtClases.Location = new System.Drawing.Point(302, 33);
            this.txtClases.Name = "txtClases";
            this.txtClases.Size = new System.Drawing.Size(143, 23);
            this.txtClases.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(63, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(235, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Total de Dictado de Clases:";
            // 
            // txtHorasTotales
            // 
            this.txtHorasTotales.BackColor = System.Drawing.Color.SandyBrown;
            this.txtHorasTotales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHorasTotales.Enabled = false;
            this.txtHorasTotales.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtHorasTotales.Location = new System.Drawing.Point(302, 183);
            this.txtHorasTotales.Name = "txtHorasTotales";
            this.txtHorasTotales.Size = new System.Drawing.Size(143, 23);
            this.txtHorasTotales.TabIndex = 11;
            // 
            // txtHorasInvestigacionMain
            // 
            this.txtHorasInvestigacionMain.BackColor = System.Drawing.SystemColors.Info;
            this.txtHorasInvestigacionMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHorasInvestigacionMain.Enabled = false;
            this.txtHorasInvestigacionMain.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtHorasInvestigacionMain.Location = new System.Drawing.Point(302, 150);
            this.txtHorasInvestigacionMain.Name = "txtHorasInvestigacionMain";
            this.txtHorasInvestigacionMain.Size = new System.Drawing.Size(143, 23);
            this.txtHorasInvestigacionMain.TabIndex = 10;
            // 
            // txtHorasGestionMain
            // 
            this.txtHorasGestionMain.BackColor = System.Drawing.SystemColors.Info;
            this.txtHorasGestionMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHorasGestionMain.Enabled = false;
            this.txtHorasGestionMain.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtHorasGestionMain.Location = new System.Drawing.Point(302, 117);
            this.txtHorasGestionMain.Name = "txtHorasGestionMain";
            this.txtHorasGestionMain.Size = new System.Drawing.Size(143, 23);
            this.txtHorasGestionMain.TabIndex = 9;
            // 
            // txtHorasDocenteMain
            // 
            this.txtHorasDocenteMain.BackColor = System.Drawing.SystemColors.Info;
            this.txtHorasDocenteMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHorasDocenteMain.Enabled = false;
            this.txtHorasDocenteMain.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtHorasDocenteMain.Location = new System.Drawing.Point(302, 84);
            this.txtHorasDocenteMain.Name = "txtHorasDocenteMain";
            this.txtHorasDocenteMain.Size = new System.Drawing.Size(143, 23);
            this.txtHorasDocenteMain.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(333, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 27);
            this.label7.TabIndex = 7;
            this.label7.Text = "Horas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(110, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Componente Gestión:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(104, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Componente Docente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(38, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(258, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Horas Totales (Componentes):";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(63, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(233, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Componente Investigación:";
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
            this.cmbDocente.BackColor = System.Drawing.Color.LemonChiffon;
            this.cmbDocente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.panelHijo.Size = new System.Drawing.Size(1627, 764);
            this.panelHijo.TabIndex = 1;
            // 
            // dgvCargasHorarias
            // 
            this.dgvCargasHorarias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargasHorarias.Location = new System.Drawing.Point(148, 45);
            this.dgvCargasHorarias.Name = "dgvCargasHorarias";
            this.dgvCargasHorarias.RowHeadersWidth = 51;
            this.dgvCargasHorarias.RowTemplate.Height = 29;
            this.dgvCargasHorarias.Size = new System.Drawing.Size(749, 518);
            this.dgvCargasHorarias.TabIndex = 0;
            this.dgvCargasHorarias.Visible = false;
            this.dgvCargasHorarias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCargasHorarias_CellContentClick);
            // 
            // FrmCreate_AcademicLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1627, 991);
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
            this.panelHoras.PerformLayout();
            this.panelHijo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargasHorarias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button btnCrearCargaAcademica;
        private ComboBox cmbSemestre;
        private TextBox txtHorasTotales;
        private TextBox txtHorasInvestigacionMain;
        private TextBox txtHorasGestionMain;
        private TextBox txtHorasDocenteMain;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private LiveCharts.WinForms.PieChart pieChart;
        private Panel panelHijo;
        private Button btnNewCarga;
        private DataGridView dgvCargasHorarias;
        private Panel panelHoras;
        public Button btnAsignaturas;
        private TextBox txtClases;
        private Label label8;
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
    }
}