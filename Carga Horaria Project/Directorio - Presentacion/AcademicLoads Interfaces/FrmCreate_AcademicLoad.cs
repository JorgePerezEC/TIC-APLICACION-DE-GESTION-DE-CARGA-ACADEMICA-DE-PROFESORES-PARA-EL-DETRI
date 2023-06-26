using Directorio___Presentacion.AcademicLoads_Interfaces.Error_Frms;
using Directorio___Presentacion.CRUD_Interfaces;
using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Datos;
using Directorio_Entidades;
using Directorio_Logica;
using Directorio_LogicaNegocio;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace Directorio___Presentacion.AcademicLoads_Interfaces
{
    public partial class FrmCreate_AcademicLoad : Form
    {
        #region Define Variables
        CN_Semestre objSemestre_N = new CN_Semestre();
        CN_Docente objDocente_N = new CN_Docente();
        CN_CargaHoraria objetoCNegocio = new CN_CargaHoraria();
        private ClsStyles clsStyles = new ClsStyles();

        public static int idCargaHoraria_FrmPrincipal = -1;

        private ClsSemestre objSemestre_Ent = new ClsSemestre();

        private int cmbValueSemestre;
        private static int cmbValueDocente;
        private int idCH;
        private int count = 0;
        private int countBtns = 0;
        private int checkCH = -1;

        private static int numSemanasClase;
        private static int numSemanasSemestre;

        private static int horasSemanalesClases;
        private static int horasSemanalesDocenciaD11;
        private static int horasSemanalesDocenciaF11;
        private static int horasSemanalesDocenciaT;
        private static int horasSemanalesGestion;
        private static int horasSemanalesInvestigacion;
        private static int horasSemanalesCargaHoraria;

        private static int horasTotalesClases;
        private static int horasTotalesDocenciaD11;
        private static int horasTotalesDocenciaF11;
        private static int horasTotalesDocenciaT;
        private static int horasTotalesGestion;
        private static int horasTotalesInvestigacion;
        private static int horasTotalesCargaHoraria;

        private static int horasExigibles;
        private static int horasExigiblesFaltantes;


        private CRUD_Docencia_Ac_Load frmDocenciaSon;
        private FrmCRUD_Asignaturas_Ac_Load frmAsigSon;
        private FrmCRUD_Gestion_Ac_Load frmGestionSon;
        private FrmCRUD_Investigacion_Ac_Load frmInvSon;
        private List<string> formNames = new List<string>() { "CRUD_Docencia_Ac_Load", "FrmCRUD_Asignaturas_Ac_Load", "FrmCRUD_Gestion_Ac_Load", "FrmCRUD_Investigacion_Ac_Load" };

        #endregion

        public FrmCreate_AcademicLoad()
        {
            InitializeComponent();
            
            
        }
        private void FrmCreate_AcademicLoad_Load(object sender, EventArgs e)
        {
            clsStyles.tableStyle(dgvCargasHorarias);
            ListarSemestres();
            ListarDocentes();
            cmbDocente.Enabled = false;
            btnCrearCargaAcademica.Enabled= false;
            btnNewCarga.Visible = false;
            panelHoras.Visible = false;
            cmbDocente.SelectedValue = -1;
            cmbDocente.SelectedIndex = -1;
            cmbSemestre.SelectedValue = -1;
            cmbSemestre.SelectedIndex = -1;
            this.KeyPreview = true;

        }
        #region Functions to load Data
        private void ListarSemestres()
        {
            cmbSemestre.DataSource = objSemestre_N.MostrarSemestres();
            cmbSemestre.DisplayMember = "Código";
            cmbSemestre.ValueMember = "ID";
        }
        private void ListarDocentes()
        {
            cmbDocente.DataSource = objDocente_N.MostrarDocentesAllNames();
            cmbDocente.DisplayMember = "NombreDocente";
            cmbDocente.ValueMember = "ID";
        }
        #endregion
        

        #region Método para abrir formularios hijos
        public Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelHijo.Controls.Add(childForm);
            panelHijo.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        #endregion

        private void btnAsignaturas_Click(object sender, EventArgs e)
        {
            frmAsigSon = new FrmCRUD_Asignaturas_Ac_Load(idCargaHoraria_FrmPrincipal);
            openChildForm(frmAsigSon);
            btnDocencia.BackColor = System.Drawing.Color.LightSalmon;
            btnAsignaturas.BackColor = System.Drawing.Color.LightSeaGreen;
            btnGestion.BackColor = System.Drawing.Color.LightSalmon;
            btnInvestigacion.BackColor = System.Drawing.Color.LightSalmon;
            btnAsignaturas.ForeColor = System.Drawing.Color.White;
        }

        private void btnDocencia_Click(object sender, EventArgs e)
        {
            frmDocenciaSon = new CRUD_Docencia_Ac_Load(idCargaHoraria_FrmPrincipal);
            openChildForm(frmDocenciaSon);
            btnDocencia.BackColor = System.Drawing.Color.LightSeaGreen;
            btnAsignaturas.BackColor = System.Drawing.Color.LightSalmon;
            btnGestion.BackColor = System.Drawing.Color.LightSalmon;
            btnInvestigacion.BackColor = System.Drawing.Color.LightSalmon;
            btnDocencia.ForeColor = System.Drawing.Color.White;
        }

        private void btnGestion_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmCRUD_Gestion_Ac_Load(idCargaHoraria_FrmPrincipal));
            btnDocencia.BackColor = System.Drawing.Color.LightSalmon;
            btnAsignaturas.BackColor = System.Drawing.Color.LightSalmon;
            btnGestion.BackColor = System.Drawing.Color.LightSeaGreen;
            btnInvestigacion.BackColor = System.Drawing.Color.LightSalmon;
            btnGestion.ForeColor = System.Drawing.Color.White;
        }

        private void btnInvestigacion_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmCRUD_Investigacion_Ac_Load(idCargaHoraria_FrmPrincipal));
            btnDocencia.BackColor = System.Drawing.Color.LightSalmon;
            btnAsignaturas.BackColor = System.Drawing.Color.LightSalmon;
            btnGestion.BackColor = System.Drawing.Color.LightSalmon;
            btnInvestigacion.BackColor = System.Drawing.Color.LightSeaGreen;
            btnInvestigacion.ForeColor = System.Drawing.Color.White;
        }


        private void btnCrearCargaAcademica_Click(object sender, EventArgs e)
        {
            try
            {
                cmbValueSemestre = Convert.ToInt32(cmbSemestre.SelectedValue);
                cmbValueDocente = Convert.ToInt32(cmbDocente.SelectedValue);
                numSemanasClase = objetoCNegocio.GetSemanasClase_Negocio(cmbValueSemestre.ToString());
                numSemanasSemestre = objetoCNegocio.GetSemanasSemestre_Negocio(cmbValueSemestre.ToString());
                horasExigibles = objetoCNegocio.CheckHorasExigiblesDocenteNegocio(cmbValueSemestre.ToString(), cmbValueDocente.ToString());
                if (horasExigibles > 0)
                {
                    
                    checkCH = objetoCNegocio.CheckCargaHorariaNegocio(cmbValueSemestre.ToString(), cmbValueDocente.ToString());

                    if (checkCH == 0)
                    {
                        objetoCNegocio.CreateCargaHorariaNeg(cmbValueSemestre.ToString(), cmbValueDocente.ToString());
                        btnNewCarga.Visible = true;
                        panelHoras.Visible = true;
                        btnCrearCargaAcademica.Visible = false;
                        idCH = objetoCNegocio.GetIDCargaHorariaNegocio(cmbValueSemestre.ToString(), cmbValueDocente.ToString());
                        MessageBox.Show("Carga Horaria creada correctamente");
                        frmAsigSon = new FrmCRUD_Asignaturas_Ac_Load(idCH);
                        openChildForm(frmAsigSon);
                        FrmCRUD_Asignaturas_Ac_Load frmCRUD = Application.OpenForms["FrmCRUD_Asignaturas_Ac_Load"] as FrmCRUD_Asignaturas_Ac_Load;
                        if (frmCRUD != null)
                        {
                            frmCRUD.UpdateContent();
                        }
                        btnAsignaturas.BackColor = System.Drawing.Color.LightSeaGreen;
                    }
                    else
                    {
                        btnNewCarga.Visible = true;
                        panelHoras.Visible = true;
                        btnCrearCargaAcademica.Visible = false;
                        btnAsignaturas.BackColor = System.Drawing.Color.LightSeaGreen;
                        idCH = objetoCNegocio.GetIDCargaHorariaNegocio(cmbValueSemestre.ToString(), cmbValueDocente.ToString());
                        MessageBox.Show("Carga Horaria creada previamente. Accediendo al modo edicion");
                        frmAsigSon = new FrmCRUD_Asignaturas_Ac_Load(idCH);
                        openChildForm(frmAsigSon);
                    }
                    idCH = objetoCNegocio.GetIDCargaHorariaNegocio(cmbValueSemestre.ToString(), cmbValueDocente.ToString());
                    CalcularHoras(idCH);
                    
                    idCargaHoraria_FrmPrincipal = idCH;

                    //Show Layouts
                    panelHorasExigibles.Visible = true;
                    btnAsignaturas.Visible = true;
                    btnDocencia.Visible = true;
                    btnGestion.Visible = true;
                    btnInvestigacion.Visible = true;
                    cmbSemestre.Enabled = false;
                    cmbDocente.Enabled = false;
                    

                    //ClearTxtBox();
                    dgvCargasHorarias.Visible = false;
                }
                else
                {
                    var frmError = new Frm_Err_HorasExigibles(cmbDocente.Text, cmbSemestre.Text);
                    frmError.ShowDialog();
                    //MessageBox.Show("El docente seleccionado no posee registradas Horas Exigibles en el semestre "+ cmbValueSemestre.ToString() +". Por favor dirijase a  '' Gestionar Datos > Gestión de Docentes > Asignar Horas Exigibles'' para agregar horas exigibles.");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo registrar la carga Academica. Motivo: " + ex.Message);
            }
        }

        
        #region Comboboxes Actions
        private void cmbSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            count++;
            if (cmbSemestre.SelectedIndex > -1 && count > 2)
            {
                cmbValueSemestre = Convert.ToInt32(cmbSemestre.SelectedValue);
                dgvCargasHorarias.Visible = true;
                MostrarRegistros(cmbValueSemestre.ToString());
                cmbDocente.Enabled = true;
            }
        }
        private void cmbDocente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDocente.SelectedIndex > -1)
            {
                btnCrearCargaAcademica.Enabled = true;
            }
        }
        #endregion
        private void MostrarRegistros(string semestre)
        {
            CN_CargaHoraria objetoCNegocio = new CN_CargaHoraria();
            dgvCargasHorarias.DataSource = objetoCNegocio.LoadCargasHorarias_Negocio(semestre);
            if (countBtns < 1)
            {
                countBtns++;
                AddBtnsIntoDataGridView();
                dgvCargasHorarias.AutoGenerateColumns = false;
            }
        }
        private void AddBtnsIntoDataGridView ()
        {
            //Image as button
            DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
            btnEdit.HeaderText = "Editar";
            btnEdit.Tag = true;
            btnEdit.Image = new Bitmap(Properties.Resources.boton_editar, new Size(40, 40));
            btnEdit.ToolTipText = "Editar registro";
            dgvCargasHorarias.Columns.Add(btnEdit);

            DataGridViewImageColumn btnConfirmDelete = new DataGridViewImageColumn();
            btnConfirmDelete.HeaderText = "Eliminar";
            btnConfirmDelete.Tag = true;
            btnConfirmDelete.Image = new Bitmap(Properties.Resources.delete, new Size(40, 40));
            btnConfirmDelete.ToolTipText = "Eliminar registro";
            dgvCargasHorarias.Columns.Add(btnConfirmDelete);
        }
        public void CalcularHoras(int idCarga)
        {
            //Cargamos valores de horas Totales en casillas
            //Obtencion de horas semanales
            horasSemanalesClases = numSemanasClase * objetoCNegocio.GetSemanalHoursClasesNegocio(idCarga.ToString());
            horasSemanalesDocenciaD11 = numSemanasClase * objetoCNegocio.GetSemanalHoursDocenciaD11Negocio(idCarga.ToString());
            horasSemanalesDocenciaF11 = numSemanasSemestre * objetoCNegocio.GetSemanalHoursDocenciaF11Negocio(idCarga.ToString());
            horasSemanalesGestion = numSemanasSemestre * objetoCNegocio.GetSemanalHoursGestionNegocio(idCarga.ToString());
            horasSemanalesInvestigacion = numSemanasSemestre * objetoCNegocio.GetSemanalHoursInvestigacionNegocio(idCarga.ToString());
            //Obtencion de horas totales de actividades
            horasTotalesGestion = objetoCNegocio.GetTotalHoursGestionNegocio(idCarga.ToString());
            horasTotalesDocenciaD11 = objetoCNegocio.GetTotalHoursDocenciaD11Negocio(idCarga.ToString());
            horasTotalesDocenciaF11 = objetoCNegocio.GetTotalHoursDocenciaF11Negocio(idCarga.ToString());
            horasTotalesInvestigacion = objetoCNegocio.GetTotalHoursInvestigacionNegocio(idCarga.ToString());
            int horasTotalesByActTotalHour = horasTotalesInvestigacion + horasTotalesGestion + horasTotalesDocenciaD11 + horasTotalesDocenciaF11;
            horasTotalesDocenciaT = horasSemanalesDocenciaD11 + horasSemanalesClases + horasSemanalesDocenciaF11;
            horasTotalesCargaHoraria = horasTotalesDocenciaT + horasSemanalesGestion +
                horasSemanalesInvestigacion + horasTotalesByActTotalHour;

            txtHorasDocenteMain.Text = horasTotalesDocenciaT.ToString();
            txtHorasGestionMain.Text = (horasSemanalesGestion + horasTotalesGestion).ToString();
            txtHorasInvestigacionMain.Text = (horasSemanalesInvestigacion + horasTotalesInvestigacion).ToString();
            txtHorasTotales.Text = horasTotalesCargaHoraria.ToString();
            txtClases.Text = horasSemanalesClases.ToString();

            cmbValueSemestre = Convert.ToInt32(cmbSemestre.SelectedValue);
            cmbValueDocente = Convert.ToInt32(cmbDocente.SelectedValue);
            numSemanasClase = objetoCNegocio.GetSemanasClase_Negocio(cmbValueSemestre.ToString());
            numSemanasSemestre = objetoCNegocio.GetSemanasSemestre_Negocio(cmbValueSemestre.ToString());
            horasExigibles = objetoCNegocio.CheckHorasExigiblesDocenteNegocio(cmbValueSemestre.ToString(), cmbValueDocente.ToString());
            lblHorasExigibles.Text = horasExigibles.ToString();
            horasExigiblesFaltantes = horasExigibles - horasTotalesCargaHoraria;
            lblHorasFaltantes.Text = horasExigiblesFaltantes.ToString();
            lblSemanasClases.Text = numSemanasClase.ToString();
            lblSemanasSemestre.Text = numSemanasSemestre.ToString();

            if (horasExigiblesFaltantes <= 0) lblHorasFaltantes.BackColor = System.Drawing.Color.Tomato;
            else lblHorasFaltantes.BackColor = System.Drawing.Color.LemonChiffon;


            SeriesCollection series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Horas de Docencia",
                    Values = new ChartValues<int> { horasTotalesDocenciaT },
                    DataLabels = true,
                    Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(218, 165, 32)), // rojo
                    PushOut = 1 // Configura la separación para el primer segmento
                },
                new PieSeries
                {
                    Title = "Horas de Gestión",
                    Values = new ChartValues<int> {(horasSemanalesGestion + horasTotalesGestion) },
                    DataLabels = true,
                    Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 182, 118)), // blue
                    PushOut = 1 // Configura la separación para el segundo segmento
                },
                new PieSeries
                {
                    Title = "Horas de Investigación",
                    Values = new ChartValues<int> { (horasSemanalesInvestigacion + horasTotalesInvestigacion) },
                    DataLabels = true,
                    Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 64, 64)), // green
                    PushOut = 1 // Configura la separación para el tercer segmento
                }
            };
            pieChart.Series = series;
            
           // pieChart.Background = new SolidColorBrush(Color.FromRgb(200, 200, 200));
        }

        private void dgvCargasHorarias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                // Obtener el ID del registro que se va a editar
                idCargaHoraria_FrmPrincipal = Convert.ToInt32(dgvCargasHorarias.Rows[e.RowIndex].Cells["ID"].Value);
                cmbDocente.Text = dgvCargasHorarias.Rows[e.RowIndex].Cells["Docente"].Value.ToString();


                CalcularHoras(idCargaHoraria_FrmPrincipal);
                //Show Btns
                panelHoras.Visible = true;
                btnAsignaturas.Visible = true;
                btnDocencia.Visible = true;
                btnGestion.Visible = true;
                btnInvestigacion.Visible = true;
                cmbSemestre.Enabled = false;
                cmbDocente.Enabled = false;
                cmbDocente.Text = dgvCargasHorarias.Rows[e.RowIndex].Cells[1].Value.ToString();

                //ClearTxtBox();
                dgvCargasHorarias.Visible = false;
                btnCrearCargaAcademica.Enabled = false;
                frmAsigSon = new FrmCRUD_Asignaturas_Ac_Load(idCargaHoraria_FrmPrincipal);
                openChildForm(frmAsigSon);
                btnNewCarga.Visible = true;
                btnCrearCargaAcademica.Visible = false;
                btnAsignaturas.BackColor = System.Drawing.Color.LightSeaGreen;
                cmbValueDocente = Convert.ToInt32(cmbDocente.SelectedValue);
                horasExigibles = objetoCNegocio.CheckHorasExigiblesDocenteNegocio(cmbValueSemestre.ToString(), cmbValueDocente.ToString());
                panelHorasExigibles.Visible = true;
                UpdateContent();
            }
            else if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Obtener el ID del registro que se va a eliminar
                    int id = Convert.ToInt32(dgvCargasHorarias.Rows[e.RowIndex].Cells["ID"].Value);

                    objetoCNegocio.DeleteCargaHorariaNeg(id.ToString());

                    // Eliminar la fila del DataGridView
                    dgvCargasHorarias.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void btnNewCarga_Click(object sender, EventArgs e)
        {
            cmbSemestre.SelectedIndex = -1;
            cmbDocente.SelectedIndex = -1;
            cmbDocente.Enabled = true;
            cmbSemestre.Enabled = true;
            txtHorasDocenteMain.Text = string.Empty;
            txtHorasGestionMain.Text = string.Empty;
            txtHorasInvestigacionMain.Text = string.Empty;
            txtHorasTotales.Text = string.Empty;
            btnCrearCargaAcademica.Enabled = true;
            btnAsignaturas.Visible = false;
            btnDocencia.Visible = false;
            btnInvestigacion.Visible = false;
            btnGestion.Visible = false;
            dgvCargasHorarias.Visible = false;
            btnCrearCargaAcademica.Visible = true;
            btnCrearCargaAcademica.Enabled = false;
            btnNewCarga.Visible = false;
            btnDocencia.BackColor = System.Drawing.Color.LightSalmon;
            btnAsignaturas.BackColor = System.Drawing.Color.LightSeaGreen;
            btnGestion.BackColor = System.Drawing.Color.LightSalmon;
            btnInvestigacion.BackColor = System.Drawing.Color.LightSalmon;
            btnAsignaturas.ForeColor = System.Drawing.Color.White;
            CloseForms(formNames);
            panelHoras.Visible= false;
            panelHorasExigibles.Visible= false;
            this.Refresh();
        }
        public void CloseForms(List<string> formNames)
        {
            List<Form> openFormsCopy = new List<Form>(Application.OpenForms.Count);
            openFormsCopy.AddRange(Application.OpenForms.Cast<Form>());

            foreach (Form form in openFormsCopy)
            {
                if (formNames.Contains(form.Name))
                {
                    form.Close();
                }
            }
        }

        public void UpdateContent()
        {
            int cmbValueDocente = Convert.ToInt32(cmbDocente.SelectedValue);
            idCH = objetoCNegocio.GetIDCargaHorariaNegocio(cmbValueSemestre.ToString(), cmbValueDocente.ToString());
            CalcularHoras(idCH);
        }

        private void panelHorasExigibles_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmCreate_AcademicLoad_KeyPress(object sender, KeyPressEventArgs e)
        {
            char tecla = char.ToLower(e.KeyChar);

            if (tecla == (char)Keys.Enter && btnCrearCargaAcademica.Visible)
            {
                btnCrearCargaAcademica.PerformClick();
                e.Handled = true;
            }
            if (tecla == 'a' && !btnCrearCargaAcademica.Visible)
            {
                btnAsignaturas.PerformClick();
                e.Handled = true;
            }
            if (tecla == 'd' && !btnCrearCargaAcademica.Visible)
            {
                btnDocencia.PerformClick();
                e.Handled = true;
            }
            if (tecla == 'g' && !btnCrearCargaAcademica.Visible)
            {
                btnGestion.PerformClick();
                e.Handled = true;
            }
            if (tecla == 'i' && !btnCrearCargaAcademica.Visible)
            {
                btnInvestigacion.PerformClick();
                e.Handled = true;
            }
            if (tecla == 'n' && !btnCrearCargaAcademica.Visible)
            {
                btnNewCarga.PerformClick();
                e.Handled = true;
            }
        }
    }


}
