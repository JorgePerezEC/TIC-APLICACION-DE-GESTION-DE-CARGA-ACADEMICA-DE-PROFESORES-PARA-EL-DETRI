using Directorio___Presentacion.AcademicLoads_Interfaces.Sub_Frms;
using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Entidades;
using Directorio_Logica;
using MaterialSkin;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Directorio___Presentacion.AcademicLoads_Interfaces
{
    public partial class FrmCUAsignatura_AL : Form
    {
        // Propiedades públicas para los formularios padres
        public FrmCreate_AcademicLoad FrmAcademicLoad { get; set; }
        public FrmCRUD_Asignaturas_Ac_Load FrmCRUD { get; set; }

        private bool isCruceHorario = false;
        private int idAcLoad;
        private int count = 0;
        private int idSemestreLocal;
        private string idAsigCarga;
        private int idGrAsignatura;
        private DataTable dtGrs;
        private DataTable LstAsignaturas;
        private DataTable LstAsignaturasFiltered;
        //Variables to edit
        private bool EditarL = false;
        private CN_CargaHoraria objetoNegocioCargaHoraria = new CN_CargaHoraria();
        private CN_GrAsignatura objNegocioGrAsig = new CN_GrAsignatura();
        MaterialSkinManager TManager = MaterialSkinManager.Instance;
        ClsStyles tableStyle = new ClsStyles();

        public FrmCUAsignatura_AL(int idCargaHoraria, bool Editar, int idSemestre)
        {
            InitializeComponent();

            TManager.Theme = MaterialSkinManager.Themes.LIGHT;
            TManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue700, TextShade.WHITE);

            cmbAsignatura.TextChanged += cmbAsignatura_TextChanged;
            this.KeyPreview = true;
            idAcLoad = idCargaHoraria;
            EditarL = Editar;
            idSemestreLocal = idSemestre;
            btnAgregar.Enabled = Editar;

            this.FormClosed += new FormClosedEventHandler(FrmCUAsignatura_AL_FormClosed);
        }

        private void FrmCUAsignatura_AL_Load(object sender, EventArgs e)
        {
            tableStyle.tableStyle(dgvHorario);
            dgvHorario.BackgroundColor= Color.LightBlue;
            ListarCarreras();
            rbTodo.Checked= true;
            if (EditarL)
            {
                ListarAsignaturasAll();
                FrmCRUD_Asignaturas_Ac_Load frmA = new FrmCRUD_Asignaturas_Ac_Load(idAcLoad, idSemestreLocal);
                List<string> list = frmA.GetArgumentosToEdit();
                idAsigCarga = list.ElementAt(2);
                lstBoxAsignaturas.SelectedValue= Convert.ToInt32(list.ElementAt(2));
                //cmbAsignatura.Text = list.ElementAt(0);
                cmbGR.Text = list.ElementAt(1);
                panelGR.Visible = true;
                btnAgregar.Text = "Actualizar";
            }
            else
            {
                ListarAsignaturas();
                cmbAsignatura.SelectedIndex = 0;
                cmbGR.SelectedIndex = -1;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EditarL)
                {
                    if (cmbAsignatura.SelectedIndex != -1 || cmbGR.SelectedIndex != -1)
                    {
                        int cmbValueAsig = Convert.ToInt32(cmbAsignatura.SelectedValue);
                        int validation = objetoNegocioCargaHoraria.AsignatureValidationNegocio(idAcLoad.ToString(), cmbAsignatura.Text, cmbGR.Text);
                        if (validation == 0)
                        {
                            idGrAsignatura = objNegocioGrAsig.GetIDGrAsignaturaNegocio(cmbValueAsig.ToString(), cmbGR.Text);
                            objetoNegocioCargaHoraria.Create_AsignaturaCargaHoraria_Negocio(idAcLoad.ToString(), idGrAsignatura.ToString());
                            //MessageBox.Show("Asignatura agregada correctamente a la carga académica. ");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pueden ingresar Asignaturas repetidas en una misma carga académica. ");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Por favor complete todos los campos antes de continuar. ");
                    }
                }
                else
                {
                    if (cmbAsignatura.SelectedIndex != -1 || cmbGR.SelectedIndex != -1)
                    {
                        int cmbValueAsig = Convert.ToInt32(cmbAsignatura.SelectedValue);
                        int validation = objetoNegocioCargaHoraria.AsignatureValidationNegocio(idAcLoad.ToString(), cmbAsignatura.Text, cmbGR.Text);
                        if (validation == 0)
                        {
                            idGrAsignatura = objNegocioGrAsig.GetIDGrAsignaturaNegocio(cmbValueAsig.ToString(), cmbGR.Text);
                            objetoNegocioCargaHoraria.UpdateAsignaturaCargaHNeg(idAsigCarga.ToString(), idAcLoad.ToString(), idGrAsignatura.ToString());
                            //MessageBox.Show("Asignatura actualizada correctamente a la carga académica. ");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pueden ingresar Asignaturas repetidas en una misma carga académica. ");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Por favor complete todos los campos antes de continuar. ");
                    }
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido ingresar la Asignatura a la Carga Horaria. Motivo: "+ ex.Message );
                throw;
            }
            
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Load Data
        private void ListarAsignaturas()
        {
            CN_Asignatura objetoCNegocio = new CN_Asignatura();
            LstAsignaturas = objetoCNegocio.MostrarAsignaturasWithGroups_CNegocio(idSemestreLocal.ToString());
            cmbAsignatura.DataSource = LstAsignaturas;
            cmbAsignatura.DisplayMember = "Asignatura";
            cmbAsignatura.ValueMember = "ID";

            lstBoxAsignaturas.DataSource = LstAsignaturas;
            lstBoxAsignaturas.DisplayMember = "Asignatura";
            lstBoxAsignaturas.ValueMember = "ID";
            lstBoxAsignaturas.Refresh();
        }
        private void ListarAsignaturasAll()
        {
            CN_Asignatura objetoCNegocio = new CN_Asignatura();
            DataTable LstAsignaturas = new DataTable();
            LstAsignaturas = objetoCNegocio.MostrarAllAsignaturasCmb_CNegocio();
            cmbAsignatura.DataSource = LstAsignaturas;
            cmbAsignatura.DisplayMember = "Asignatura";
            cmbAsignatura.ValueMember = "ID";
            cmbAsignatura.SelectedIndex = 0;

            lstBoxAsignaturas.DataSource = LstAsignaturas;
            lstBoxAsignaturas.DisplayMember = "Asignatura";
            lstBoxAsignaturas.ValueMember = "ID";
            lstBoxAsignaturas.Refresh();
        }
        public void ListarGruposAsignatura(bool NewGr)
        {
            if (cmbAsignatura.SelectedIndex > -1 && cmbAsignatura.SelectedValue != null)
            {
                if (int.TryParse(cmbAsignatura.SelectedValue.ToString(), out int selectedValueAsInt) && selectedValueAsInt > 0)
                {
                    panelGR.Visible = true;
                    cmbGR.Visible = true;

                    CN_GrAsignatura objetoGrNegocio = new CN_GrAsignatura();
                    dtGrs = objetoGrNegocio.MostrarGruposPorAsignaturaWHorario_Negocio(idSemestreLocal.ToString(),cmbAsignatura.SelectedValue.ToString());
                    cmbGR.DataSource = dtGrs;
                    cmbGR.DisplayMember = "Grupos";
                    cmbGR.ValueMember = "ID";

                    txtNivel.Text = objetoGrNegocio.GetLvlAsignatura_Negocio(cmbAsignatura.SelectedValue.ToString());
                    txtType.Text = objetoGrNegocio.GetTypeAsigByAsig_Negocio(cmbAsignatura.SelectedValue.ToString());
                    txtCode.Text = objetoGrNegocio.GetCodeAsigByAsig_Negocio(cmbAsignatura.SelectedValue.ToString());

                    btnAddGR.Enabled = true;
                    if (dtGrs.Rows.Count > 0)
                    {
                        lblNoHorario.Visible = false;
                        dgvHorario.Visible = true;
                    
                        if (NewGr)
                        {
                            cmbGR.SelectedIndex = cmbGR.Items.Count - 1;
                        }
                    }
                    else
                    {
                        //clearData();
                        panelHorario.Visible = false;
                        lblNoHorario.Visible = true;
                    }

                }

            }
        }
        private void clearData()
        {
            panelHorario.Visible = false;
            txtCode.Text = string.Empty;
            txtNivel.Text= string.Empty;
            txtType.Text = string.Empty;
            dgvHorario.Visible = false;
        }
        #endregion

        private void cmbGR_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedRow = cmbGR.SelectedItem as DataRowView;

            if (selectedRow == null)
            {
                return;
            }
            if (cmbAsignatura.SelectedIndex > -1 && cmbAsignatura.SelectedValue != null)
            {
                if (int.TryParse(cmbGR.SelectedValue.ToString(), out int selectedValueAsInt) && selectedValueAsInt > 0 && cmbGR.SelectedItem as DataRowView != null)
                {
                    if (dtGrs.Rows.Count > 0)
                    {
                        
                        panelHorario.Visible = true;
                        CN_HorarioAsignatura objetoCNegocio = new CN_HorarioAsignatura();
                        DataTable dtHorarios = objetoCNegocio.GetHorariosByAsignaturaGRView_Negocio(idSemestreLocal.ToString(), cmbGR.SelectedValue.ToString());
                        if (dtHorarios.Rows.Count ==  0)
                        {
                            return;
                        }
                        dgvHorario.DataSource = dtHorarios;
                        dgvHorario.Columns[3].Visible = false;
                        dgvHorario.Columns[4].Visible = false;
                        dgvHorario.Columns[5].Visible = false;
                        DataTable dtHorariosCarga = new DataTable();

                        CN_HorarioAsignatura objetoCNegocio2 = new CN_HorarioAsignatura();

                        FrmCreate_AcademicLoad frmAcademicLoad = Application.OpenForms["FrmCreate_AcademicLoad"] as FrmCreate_AcademicLoad;
                        FrmCRUD_Asignaturas_Ac_Load frmCRUD = Application.OpenForms["FrmCRUD_Asignaturas_Ac_Load"] as FrmCRUD_Asignaturas_Ac_Load;
                        if (frmCRUD != null)
                        {
                            dtHorariosCarga = frmCRUD.DtHorario;
                        }

                        //isCruceHorario = objetoCNegocio2.VerificarCruceHorario_Negocio(idAcLoad.ToString(),cmbGR.SelectedValue.ToString());
                        if (VerificarCruceHorarios(dtHorarios, dtHorariosCarga))
                        {
                            lblCruceHorario.Visible = true;
                            btnAgregar.Enabled = false;
                        }
                        else
                        {
                            lblCruceHorario.Visible = false;
                            btnAgregar.Enabled = true;
                        }
                    }
                    else
                    {
                        clearData();
                    }
                    //MessageBox.Show(isCruceHorario.ToString(), "VERIFICAR CRUCE HORARIO");
                    //spVerificarConflictoHorario
                }
            }
        }

        private bool VerificarCruceHorarios(DataTable dtHorarios, DataTable dtHorariosCarga)
        {
            foreach (DataRow rowHorariosCarga in dtHorariosCarga.Rows)
            {
                foreach (DataRow rowHorarios in dtHorarios.Rows)
                {
                    string diaHorariosCarga = rowHorariosCarga["dia"].ToString();
                    TimeSpan horaInicioHorariosCarga = TimeSpan.Parse(rowHorariosCarga["horaInicio"].ToString());
                    TimeSpan horaFinHorariosCarga = TimeSpan.Parse(rowHorariosCarga["horaFin"].ToString());

                    string diaHorarios = rowHorarios["dia"].ToString();
                    TimeSpan horaInicioHorarios = TimeSpan.Parse(rowHorarios["horaInicio"].ToString());
                    TimeSpan horaFinHorarios = TimeSpan.Parse(rowHorarios["horaFin"].ToString());

                    if (diaHorariosCarga == diaHorarios &&
                        ((horaInicioHorariosCarga >= horaInicioHorarios && horaInicioHorariosCarga < horaFinHorarios) ||
                         (horaFinHorariosCarga > horaInicioHorarios && horaFinHorariosCarga <= horaFinHorarios)))
                    {
                        // Hay un cruce de horarios
                        return true;
                    }
                }
            }

            // No hay cruces de horarios
            return false;
        }


        private void cmbAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAsignatura.SelectedIndex > -1 && cmbAsignatura.SelectedValue != null)
            {
                ListarGruposAsignatura(false);
            }
        }

        private void FrmCUAsignatura_AL_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmCreate_AcademicLoad frmAcademicLoad = Application.OpenForms["FrmCreate_AcademicLoad"] as FrmCreate_AcademicLoad;
            FrmCRUD_Asignaturas_Ac_Load frmCRUD = Application.OpenForms["FrmCRUD_Asignaturas_Ac_Load"] as FrmCRUD_Asignaturas_Ac_Load;
            if (frmAcademicLoad != null)
            {
                frmAcademicLoad.UpdateContent();
            }
            if (frmCRUD != null)
            {
                frmCRUD.UpdateContent();
            }
        }

        private void FrmCUAsignatura_AL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAgregar.PerformClick();
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
                e.Handled = true;
            }
        }

        private void btnAddGR_Click(object sender, EventArgs e)
        {
            if (cmbAsignatura.SelectedIndex > -1 && cmbAsignatura.SelectedValue != null)
            {
                Frm_CreateNewAsignatura_Modal frmCreateAsig = new Frm_CreateNewAsignatura_Modal(cmbAsignatura.SelectedValue.ToString(), idSemestreLocal);
                frmCreateAsig.ShowDialog();
            }
        }
        private void ListarCarreras()
        {
            CN_Carrera objetoCNegocio = new CN_Carrera();
            cmbCarreras.DataSource = objetoCNegocio.MostrarCarreras();
            cmbCarreras.DisplayMember = "Carrera";
            cmbCarreras.ValueMember = "ID";
            cmbCarreras.SelectedIndex = -1;
            cmbCarreras.SelectedValue = -1;
        }

        private void rbTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodo.Checked)
            {
                cmbCarreras.SelectedIndex = -1;
                txtCodeFilter.Text = string.Empty;
                cmbAsignatura.DataSource = LstAsignaturas;
                cmbAsignatura.DisplayMember = "Asignatura";
                cmbAsignatura.ValueMember = "ID";

                lstBoxAsignaturas.DataSource = LstAsignaturas;
                lstBoxAsignaturas.DisplayMember = "Asignatura";
                lstBoxAsignaturas.ValueMember = "ID";
                lstBoxAsignaturas.Refresh();
            }
        }

        private void cmbCarreras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCarreras.SelectedValue != null)
            {
                rbTodo.Checked = false;
                txtCodeFilter.Text = string.Empty;

                if (cmbCarreras.SelectedValue is int selectedValueInt)
                {
                    CN_Asignatura objetoCNegocio = new CN_Asignatura();
                    LstAsignaturasFiltered = objetoCNegocio.MostrarAsignaturasWithGroups_ByCarrera_CNegocio(idSemestreLocal.ToString(), selectedValueInt.ToString());
                    //VALIDACION REGISTROS
                    if (LstAsignaturasFiltered.Rows.Count > 0)
                    {
                        btnAddGR.Enabled = true;
                        lstBoxAsignaturas.DataSource = LstAsignaturasFiltered;
                        lstBoxAsignaturas.DisplayMember = "Asignatura";
                        lstBoxAsignaturas.ValueMember = "ID";
                        lstBoxAsignaturas.Refresh();
                        cmbAsignatura.Enabled = true;
                        cmbGR.Enabled = true;
                    }
                    else
                    {
                        btnAddGR.Enabled = false;
                        lstBoxAsignaturas.DataSource = new string[] { "NO SE ENCONTRARON REGISTROS" };
                        cmbAsignatura.Enabled = false;
                        txtCode.Text = string.Empty;
                        txtNivel.Text = string.Empty;
                        txtType.Text = string.Empty;
                        cmbGR.Text = string.Empty;
                        cmbGR.SelectedIndex = -1;
                        cmbGR.Enabled = false;
                    }
                    cmbAsignatura.DataSource = LstAsignaturasFiltered;
                    cmbAsignatura.DisplayMember = "Asignatura";
                    cmbAsignatura.ValueMember = "ID";
                    cmbAsignatura.SelectedIndex = -1;

                    //lstBoxAsignaturas.DataSource = LstAsignaturasFiltered;
                    //lstBoxAsignaturas.DisplayMember = "Asignatura";
                    //lstBoxAsignaturas.ValueMember = "ID";
                    //lstBoxAsignaturas.Refresh();
                }
            }
        }

        private void txtCodeFilter_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtCodeFilter.Text.Trim(); // Obtener el texto ingresado en el TextBox y eliminar los espacios en blanco

            // Realizar el filtrado del DataTable en función del texto ingresado
            DataTable dataTableFiltrado = FiltrarDataTable(LstAsignaturas, filtro);

            // Asignar el DataTable filtrado al DataSource del DataGridView
            lstBoxAsignaturas.DataSource = dataTableFiltrado;
            cmbAsignatura.DataSource = dataTableFiltrado;
        }
        private DataTable FiltrarDataTable(DataTable dataTable, string filtro)
        {
            DataTable dataTableFiltrado = dataTable.Clone();

            foreach (DataRow row in dataTable.Rows)
            {
                if (row.ItemArray.Any(field => field.ToString().IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    // Copiar la fila filtrada al nuevo DataTable
                    dataTableFiltrado.ImportRow(row);
                }
            }

            return dataTableFiltrado;
        }

        private void cmbAsignatura_TextChanged(object sender, EventArgs e)
        {
            //if (cmbCarreras.SelectedValue != null)
            //{
            //    string enteredText = cmbAsignatura.Text.ToLower();
            //    DataView dataView = new DataView(LstAsignaturas);
            //    dataView.RowFilter = $"Asignatura LIKE '%{enteredText}%'";
            //    cmbAsignatura.DataSource = dataView;
            //}
        }
    }
}