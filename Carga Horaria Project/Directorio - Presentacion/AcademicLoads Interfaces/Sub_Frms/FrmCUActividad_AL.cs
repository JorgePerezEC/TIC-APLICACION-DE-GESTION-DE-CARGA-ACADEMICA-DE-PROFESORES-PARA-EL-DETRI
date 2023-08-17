using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Entidades;
using Directorio_Logica;
using ScottPlot.Palettes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;


namespace Directorio___Presentacion.AcademicLoads_Interfaces.Sub_Frms
{
    public partial class FrmCUActividad_AL : Form
    {

        private int idAcLoad;
        private string idActividadCarga;
        private int idActividadCargaEdit;
        //private int idActividad;
        private string ActividadTipo;
        private List<string> DataEditLst;
        private CN_CargaHoraria objetoNegocioCargaHoraria = new CN_CargaHoraria();
        private CN_Actividad objNegocioActividad = new CN_Actividad();
        int count = 0;


        //Variables to edit
        private bool EditarL = false;
        public FrmCUActividad_AL(string TipoActividad, int idCargaHoraria, bool editar)
        {
            InitializeComponent();
            this.KeyPreview = true;
            ActividadTipo = TipoActividad;
            idAcLoad = idCargaHoraria;
            EditarL = editar;
        }
        private void FillContent(List<string> list)
        {
            cmbActividad.Text = list.ElementAt(0);
            txtHorasActividad.Text = list.ElementAt(1);
            idActividadCarga = list.ElementAt(2);
            txtHorasTotales.Text = list.ElementAt(3);
            panelInfoActividad.Visible = true;
        }

        private void FrmCUActividad_AL_Load(object sender, EventArgs e)
        {
            if (EditarL)
            {
                btnAgregar.Text = "Actualizar";
                btnAgregar.Enabled = true;
                txtHorasActividad.Enabled = true;
                panelInfoActividad.Visible = true;
                cmbActividad.Enabled = false;

                if (ActividadTipo == "Investigacion")
                {
                    btnCrearActividad.Text = "Crear Actividad de Investigación";
                    lblTitleActividad.Text = "Editar Actividad de Investigación";
                    ListarActividadesInvestigacion();
                    FrmCRUD_Investigacion_Ac_Load frmInv = new FrmCRUD_Investigacion_Ac_Load(idAcLoad);
                    DataEditLst = frmInv.GetArgumentosToEdit();
                    cmbActividad.Text = DataEditLst.ElementAt(0);
                    //txtHorasActividad.Text = DataEditLst.ElementAt(1);
                    idActividadCarga = DataEditLst.ElementAt(2);
                    //txtHorasTotales.Text = DataEditLst.ElementAt(3);
                    if (DataEditLst.ElementAt(1) == "NA")
                    {
                        txtHorasActividad.Text = "0";
                        cboxHorasTotales.Checked = true;
                    }
                    else
                    {
                        txtHorasActividad.Text = DataEditLst.ElementAt(1);
                    }
                    if (DataEditLst.ElementAt(3) == "NA")
                    {
                        txtHorasTotales.Text = "0";
                        cboxHorasSemanales.Checked = true;
                    }
                    else
                    {
                        txtHorasTotales.Text = DataEditLst.ElementAt(3);
                    }

                }
                else if (ActividadTipo == "Gestion")
                {
                    lblTitleActividad.Text = "Editar Actividad de Gestión";
                    btnCrearActividad.Text = "Crear Actividad de Gestión";
                    ListarActividadesGestion();
                    FrmCRUD_Gestion_Ac_Load frmGestion = new FrmCRUD_Gestion_Ac_Load(idAcLoad);
                    DataEditLst = frmGestion.GetArgumentosToEdit();
                    cmbActividad.Text = DataEditLst.ElementAt(0);
                    //txtHorasActividad.Text = DataEditLst.ElementAt(1);
                    idActividadCarga = DataEditLst.ElementAt(2);
                    // txtHorasTotales.Text = DataEditLst.ElementAt(3);
                    if (DataEditLst.ElementAt(1) == "NA")
                    {
                        txtHorasActividad.Text = "0";
                        cboxHorasTotales.Checked = true;
                    }
                    else
                    {
                        txtHorasActividad.Text = DataEditLst.ElementAt(1);
                    }
                    if (DataEditLst.ElementAt(3) == "NA")
                    {
                        txtHorasTotales.Text = "0";
                        cboxHorasSemanales.Checked = true;
                    }
                    else
                    {
                        txtHorasTotales.Text = DataEditLst.ElementAt(3);
                    }
                }
                else if (ActividadTipo == "D11")
                {
                    cboxHorasTotales.Enabled= false;
                    cboxHorasSemanales.Checked = true;
                    lblTitleActividad.Text = "Editar Actividad de Docencia dentro del 1:1";
                    btnCrearActividad.Text = "Crear Actividad de Docencia 1:1";
                    ListarActividadesDocencia11();
                    CRUD_Docencia_Ac_Load frmDocencia = new CRUD_Docencia_Ac_Load(idAcLoad);
                    DataEditLst = frmDocencia.GetArgumentosToEdit();
                    cmbActividad.Text = DataEditLst.ElementAt(0);
                    if (DataEditLst.ElementAt(1)=="NA")
                    {
                        txtHorasActividad.Text = "0";
                        cboxHorasTotales.Checked = true;
                    }
                    else
                    {
                        txtHorasActividad.Text = DataEditLst.ElementAt(1);
                    }
                    if (DataEditLst.ElementAt(3) == "NA")
                    {
                        txtHorasTotales.Text = "0";
                        cboxHorasSemanales.Checked = true;
                    }
                    else
                    {
                        txtHorasTotales.Text = DataEditLst.ElementAt(3);
                    }
                    idActividadCarga = DataEditLst.ElementAt(2);
                }
                else if (ActividadTipo == "F11")
                {
                    cboxHorasSemanales.Enabled= false;
                    cboxHorasTotales.Checked = true;
                    lblTitleActividad.Text = "Editar Actividad de Docencia fuera del 1:1";
                    btnCrearActividad.Text = "Crear Actividad de Docencia";
                    ListarActividadesDocenciaF11();
                    CRUD_Docencia_Ac_Load frmDocencia = new CRUD_Docencia_Ac_Load(idAcLoad);
                    DataEditLst = frmDocencia.GetArgumentosToEdit();
                    cmbActividad.Text = DataEditLst.ElementAt(0);
                    //txtHorasActividad.Text = DataEditLst.ElementAt(1);
                    idActividadCarga = DataEditLst.ElementAt(2);
                    //txtHorasTotales.Text = DataEditLst.ElementAt(3);
                    if (DataEditLst.ElementAt(1) == "NA")
                    {
                        txtHorasActividad.Text = "0";
                        cboxHorasTotales.Checked = true;
                    }
                    else
                    {
                        txtHorasActividad.Text = DataEditLst.ElementAt(1);
                    }
                    if (DataEditLst.ElementAt(3) == "NA")
                    {
                        txtHorasTotales.Text = "0";
                        cboxHorasSemanales.Checked = true;
                    }
                    else
                    {
                        txtHorasTotales.Text = DataEditLst.ElementAt(3);
                    }
                }
            }
            else
            {
                if (ActividadTipo == "Investigacion") btnCrearActividad.Text = "Crear Actividad de Investigación";
                else if(ActividadTipo == "Gestion") btnCrearActividad.Text = "Crear Actividad de Gestión";
                else if (ActividadTipo == "D11") btnCrearActividad.Text = "Crear Actividad de Docencia 1:1";
                else if (ActividadTipo == "F11") btnCrearActividad.Text = "Crear Actividad de Docencia";
                ListarActividadesGral();
                cmbActividad.SelectedIndex = -1;


            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EditarL)
                {
                    if (cmbActividad.SelectedIndex != -1)
                    {
                        int cmbValueActiv = Convert.ToInt32(cmbActividad.SelectedValue);
                        int validation = objetoNegocioCargaHoraria.ActivityValidationNegocio(idAcLoad.ToString(), cmbActividad.Text);
                        if (validation == 0)
                        {
                            if (cboxHorasTotales.Checked)
                            {
                                if (string.IsNullOrWhiteSpace(txtHorasTotales.Text))
                                {
                                    MessageBox.Show("El campo horas de actividad no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                objetoNegocioCargaHoraria.Create_ActividadCargaHoraria_Negocio(idAcLoad.ToString(), cmbValueActiv.ToString(), "0", txtHorasTotales.Text);
                                //MessageBox.Show("Actividad agregada correctamente a la carga académica. ");
                                this.Close();
                                RefreshMainForm();
                            }
                            else
                            {
                                if (string.IsNullOrWhiteSpace(txtHorasActividad.Text))
                                {
                                    MessageBox.Show("El campo horas de actividad no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                objetoNegocioCargaHoraria.Create_ActividadCargaHoraria_Negocio(idAcLoad.ToString(), cmbValueActiv.ToString(), txtHorasActividad.Text, "0");
                                //MessageBox.Show("Actividad agregada correctamente a la carga académica. ");
                                this.Close();
                                RefreshMainForm();
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("No se pueden ingresar actividades duplicadas a una misma Carga Horaria. ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor complete todos los campos antes de continuar. ");
                    }
                }
                else
                {
                    if (cmbActividad.SelectedIndex != -1)
                    {
                        idActividadCargaEdit = objetoNegocioCargaHoraria.GetIDActividadNegocio(cmbActividad.Text);
                        objetoNegocioCargaHoraria.Update_ActividadCargaHoraria_Negocio(idActividadCarga, idAcLoad.ToString(), idActividadCargaEdit.ToString(), txtHorasActividad.Text, txtHorasTotales.Text);
                        MessageBox.Show("Actividad actualizada correctamente a la carga académica. ");
                        this.Close();
                        RefreshMainForm();
                    }
                    else
                    {
                        MessageBox.Show("Por favor complete todos los campos antes de continuar. ");
                    }
                }
                

            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            RefreshMainForm();
        }
        private void RefreshMainForm()
        {
            FrmCRUD_Gestion_Ac_Load frmGestion = new FrmCRUD_Gestion_Ac_Load(idAcLoad);
            frmGestion.MostrarRegistros();
            frmGestion.Refresh();
            FrmCreate_AcademicLoad frmMain = new FrmCreate_AcademicLoad();
            //frmMain.CalcularHoras(idAcLoad);
        }
        #region LOAD DATA METHODS
        private void ListarActividadesGestion()
        {
            CN_Actividad objetoCNegocio = new CN_Actividad();
            cmbActividad.DataSource = objetoCNegocio.GetGestionActivities_Negocio();
            cmbActividad.DisplayMember = "Actividad";
            cmbActividad.ValueMember = "ID";
        }
        private void ListarActividadesDocencia11()
        {
            CN_Actividad objetoCNegocio = new CN_Actividad();
            cmbActividad.DataSource = objetoCNegocio.GetDocenciaD11Activities_Negocio();
            cmbActividad.DisplayMember = "Actividad";
            cmbActividad.ValueMember = "ID";
        }
        private void ListarActividadesDocenciaF11()
        {
            CN_Actividad objetoCNegocio = new CN_Actividad();
            cmbActividad.DataSource = objetoCNegocio.GetDocenciaF11Activities_Negocio();
            cmbActividad.DisplayMember = "Actividad";
            cmbActividad.ValueMember = "ID";
        }
        private void ListarActividadesInvestigacion()
        {
            //CN_Actividad objetoCNegocio = new CN_Actividad();
            cmbActividad.DataSource = objNegocioActividad.GetInvestigacionActivities_Negocio();
            cmbActividad.DisplayMember = "Actividad";
            cmbActividad.ValueMember = "ID";
        }
        public void ListarAllActividadesCmb(string type, bool newActivity)
        {
            if (type == "D11") ListarActividadesDocencia11();
            else if (type == "D") ListarActividadesDocenciaF11();
            else if (type == "G") ListarActividadesGestion();
            else if (type == "I") ListarActividadesInvestigacion();

            if (newActivity) cmbActividad.SelectedIndex = cmbActividad.Items.Count - 1;
        }
        private void ListarActividadesGral()
        {
            //CN_Actividad objetoCNegocio = new CN_Actividad();
            if (ActividadTipo == "Investigacion")
            {
                lblTitleActividad.Text = "Agregar Actividad de Investigación";
                ActividadTipo = "I";

            }
            else if (ActividadTipo == "Gestion")
            {
                lblTitleActividad.Text = "Agregar Actividad de Gestión";
                ActividadTipo = "G";
            }
            else if (ActividadTipo == "D11")
            {
                lblTitleActividad.Text = "Agregar Actividad de Docencia dentro del 1:1";
                cboxHorasTotales.Enabled = false;
                cboxHorasSemanales.Checked = true;
            }
            else if (ActividadTipo == "F11")
            {
                lblTitleActividad.Text = "Agregar Actividad de Docencia fuera del 1:1";
                ActividadTipo = "D";
                cboxHorasSemanales.Enabled = false;
                cboxHorasTotales.Checked = true;
            }
            cmbActividad.DataSource = objNegocioActividad.GetAllActivities_Negocio(idAcLoad.ToString(), ActividadTipo);
            cmbActividad.DisplayMember = "Actividad";
            cmbActividad.ValueMember = "ID";
        }

        #endregion

        private void cmbActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            count++;
            //MessageBox.Show(cmbActividad.SelectedValue.ToString());
            if (cmbActividad.SelectedIndex > -1 && count > 2)
            {
                btnAgregar.Enabled = true;
                panelInfoActividad.Visible = true;
                int cmbValueActiv = Convert.ToInt32(cmbActividad.SelectedValue);
                txtHorasActividad.Text = objNegocioActividad.GetHorasActividadNegocio(cmbValueActiv.ToString()).ToString();
                txtHorasTotales.Text = objNegocioActividad.GetHorasTotalesActividadNegocio(cmbValueActiv.ToString()).ToString();
                txtHorasActividad.Enabled = true;
            }
            else
            {
                
            }
        }

        public void FrmCUActividad_AL_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmCreate_AcademicLoad frmAcademicLoad = Application.OpenForms["FrmCreate_AcademicLoad"] as FrmCreate_AcademicLoad;
            if (frmAcademicLoad != null)
            {
                frmAcademicLoad.UpdateContent();
            }
            CRUD_Docencia_Ac_Load frmCRUD_Docencia = Application.OpenForms["CRUD_Docencia_Ac_Load"] as CRUD_Docencia_Ac_Load;
            if (frmCRUD_Docencia != null)
            {
                frmCRUD_Docencia.UpdateContent();
            }
            FrmCRUD_Gestion_Ac_Load frmCRUD_Gestion = Application.OpenForms["FrmCRUD_Gestion_Ac_Load"] as FrmCRUD_Gestion_Ac_Load;
            if (frmCRUD_Gestion != null)
            {
                frmCRUD_Gestion.UpdateContent();
            }
            FrmCRUD_Investigacion_Ac_Load frmCRUD_Investigacion = Application.OpenForms["FrmCRUD_Investigacion_Ac_Load"] as FrmCRUD_Investigacion_Ac_Load;
            if (frmCRUD_Investigacion != null)
            {
                frmCRUD_Investigacion.UpdateContent();
            }
        }

        private void cboxHorasSemanales_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxHorasSemanales.Checked)
            {
                panelHorasTotales.Visible = false;
                cboxHorasTotales.Checked = false;
            }
        }

        private void cboxHorasTotales_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxHorasTotales.Checked)
            {
                panelHorasTotales.Visible = true;
                cboxHorasSemanales.Checked = false;
            }
        }

        private void btnAddwHoraTotal_Click(object sender, EventArgs e)
        {

        }

        private void btnCrearActividad_Click(object sender, EventArgs e)
        {
            Frm_CreateNewActivity_Modal frmCreateAct = new Frm_CreateNewActivity_Modal(ActividadTipo);
            frmCreateAct.ShowDialog();
        }

        private void FrmCUActividad_AL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAgregar.PerformClick();
                e.Handled = true;
            }
        }

        private void txtHorasTotales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}
