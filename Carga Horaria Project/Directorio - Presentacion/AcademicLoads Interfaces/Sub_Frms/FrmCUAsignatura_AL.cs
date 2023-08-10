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
using System.Windows.Forms;

namespace Directorio___Presentacion.AcademicLoads_Interfaces
{
    public partial class FrmCUAsignatura_AL : Form
    {
        // Propiedades públicas para los formularios padres
        public FrmCreate_AcademicLoad FrmAcademicLoad { get; set; }
        public FrmCRUD_Asignaturas_Ac_Load FrmCRUD { get; set; }

        private int idAcLoad;
        private int idSemestreLocal;
        private string idAsigCarga;
        private int idGrAsignatura;
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
            cmbCarreras.Focus();
            ListarCarreras();
            rbTodo.Checked= true;
            if (EditarL)
            {
                ListarAsignaturasAll();
                FrmCRUD_Asignaturas_Ac_Load frmA = new FrmCRUD_Asignaturas_Ac_Load(idAcLoad, idSemestreLocal);
                List<string> list = frmA.GetArgumentosToEdit();
                cmbAsignatura.Text = list.ElementAt(0);
                cmbGR.Text = list.ElementAt(1);
                idAsigCarga = list.ElementAt(2);
                panelGR.Visible = true;
                btnAgregar.Text = "Actualizar";
            }
            else
            {
                ListarAsignaturas();
                cmbAsignatura.SelectedIndex = -1;
                cmbGR.SelectedIndex = -1;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (EditarL == false)
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
                else if (EditarL)
                {
                    if (cmbAsignatura.SelectedIndex != -1 || cmbGR.SelectedIndex != -1)
                    {
                        int cmbValueAsig = Convert.ToInt32(cmbAsignatura.SelectedValue);
                        int validation = objetoNegocioCargaHoraria.AsignatureValidationNegocio(idAcLoad.ToString(), cmbAsignatura.Text, cmbGR.Text);
                        if (validation == 0)
                        {
                            idGrAsignatura = objNegocioGrAsig.GetIDGrAsignaturaNegocio(cmbValueAsig.ToString(), cmbGR.Text);
                            objetoNegocioCargaHoraria.UpdateAsignaturaCargaHNeg(idAsigCarga.ToString(), idAcLoad.ToString(), idGrAsignatura.ToString());
                            //MessageBox.Show(idAcLoad.ToString() + " " + idGrAsignatura.ToString());
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

            lstBoxAsignaturas.DataSource = LstAsignaturas;
            lstBoxAsignaturas.DisplayMember = "Asignatura";
            lstBoxAsignaturas.ValueMember = "ID";
            lstBoxAsignaturas.Refresh();
        }
        public void ListarGruposAsignatura(bool NewGr)
        {
            if (cmbAsignatura.SelectedIndex > -1)
            {
                panelGR.Visible = true;
                cmbGR.Visible = true;

                CN_GrAsignatura objetoGrNegocio = new CN_GrAsignatura();
                cmbGR.DataSource = objetoGrNegocio.MostrarGruposPorAsignatura_Negocio(cmbAsignatura.SelectedValue.ToString());
                cmbGR.DisplayMember = "Grupos";
                cmbGR.ValueMember = "ID";

                txtNivel.Text = objetoGrNegocio.GetLvlAsignatura_Negocio(cmbAsignatura.SelectedValue.ToString());
                txtType.Text = objetoGrNegocio.GetTypeAsigByAsig_Negocio(cmbAsignatura.SelectedValue.ToString());
                txtCode.Text = objetoGrNegocio.GetCodeAsigByAsig_Negocio(cmbAsignatura.SelectedValue.ToString());
                if (NewGr)
                {
                    cmbGR.SelectedIndex = cmbGR.Items.Count - 1;
                }
            }
        }
        #endregion

        private void cmbGR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAsignatura.SelectedIndex > -1 && cmbAsignatura.SelectedValue != null)
            {
                if (int.TryParse(cmbGR.SelectedValue.ToString(), out int selectedValueAsInt) && selectedValueAsInt > 0)
                { 
                    panelHorario.Visible = true;
                    CN_HorarioAsignatura objetoCNegocio = new CN_HorarioAsignatura();
                    DataTable dtHorarios = objetoCNegocio.GetHorariosByAsignaturaGRView_Negocio(idSemestreLocal.ToString(), cmbGR.SelectedValue.ToString());
                    dgvHorario.DataSource = dtHorarios;

                }
            }
        }

        private void cmbAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAsignatura.SelectedIndex > -1 && cmbAsignatura.SelectedValue != null)
            {
                ListarGruposAsignatura(false);
                btnAgregar.Enabled = true;
                btnAddGR.Enabled = true;
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
            Frm_CreateNewAsignatura_Modal frmCreateAsig = new Frm_CreateNewAsignatura_Modal(cmbAsignatura.Text, idSemestreLocal);
            frmCreateAsig.ShowDialog();
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