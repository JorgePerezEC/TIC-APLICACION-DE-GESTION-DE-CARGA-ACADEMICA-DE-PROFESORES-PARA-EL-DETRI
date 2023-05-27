using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Entidades;
using Directorio_Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Directorio___Presentacion.CRUD_Data_Interfaces
{
    public partial class FrmCRUD_HorasExigibles : Form
    {
        #region Define Variables
        CN_Semestre objSemestre_N = new CN_Semestre();
        CN_Docente objDocente_N = new CN_Docente();
        CN_TipoDocente objTpDocente = new CN_TipoDocente();
        private ClsStyles clsStyles = new ClsStyles();

        private bool Editar = false;

        private int count = 0;
        private int idDocente;
        private int idSemestreTpDocente;
        private int idTpDocente;
        private int idSemestre;
        private string numHorasExigibles;
        private int numHorasExigiblesQry;
        #endregion
        public FrmCRUD_HorasExigibles()
        {
            InitializeComponent();
        }

        private void FrmCRUD_HorasExigibles_Load(object sender, EventArgs e)
        {
            clsStyles.tableStyle(dgLstRegistros);
            FillComboboxes();
            MostrarRegistrosPorSemestre();
            txtHorasExigibles.Enabled= false;
        }
        #region LOAD DATA
        private void MostrarRegistrosPorSemestre()
        {
            CN_TipoDocente objetoTpDocenteCNegocio = new CN_TipoDocente();
            count++;
            if (cmbSemestreLst.SelectedIndex > -1 && count > 2)
            {
                int cmbValueSemestres = Convert.ToInt32(cmbSemestreLst.SelectedValue);
                dgLstRegistros.DataSource = objetoTpDocenteCNegocio.MostrarDocentesHExBySemestre_Negocio(cmbValueSemestres.ToString());
            }
        }
        //Load data into comboboxes
        private void FillComboboxes()
        {
            CN_Semestre objSemestre_Neg = new CN_Semestre();
            
            cmbSemestreAdd.DataSource = objSemestre_N.MostrarSemestres();
            cmbSemestreAdd.DisplayMember = "Código";
            cmbSemestreAdd.ValueMember = "ID";
            cmbSemestreLst.DataSource = objSemestre_Neg.MostrarSemestres();
            cmbSemestreLst.DisplayMember = "Código";
            cmbSemestreLst.ValueMember = "ID";
            cmbDocente.DataSource = objDocente_N.MostrarDocentesAllNames();
            cmbDocente.DisplayMember = "NombreDocente";
            cmbDocente.ValueMember = "ID";
            cmbTipoDocente.DataSource = objTpDocente.MostrarTiposDocentesLn();
            cmbTipoDocente.DisplayMember = "Tipo de Docente";
            cmbTipoDocente.ValueMember = "ID";
            cmbDocente.SelectedValue = -1;
            cmbDocente.SelectedIndex = -1;
            cmbSemestreAdd.SelectedValue = -1;
            cmbSemestreAdd.SelectedIndex = -1;
            cmbTipoDocente.SelectedValue = -1;
            cmbTipoDocente.SelectedIndex = -1;
            cmbSemestreLst.SelectedValue = -1;
            cmbSemestreLst.SelectedIndex = -1;
        }
        #endregion

        #region Buttons Actions
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (panelCreate.Visible)
            {
                panelCreate.Visible = false;
            }
            else
            {
                panelCreate.Visible = true;
            }
        }

        private void btnCopiarData_Click(object sender, EventArgs e)
        {

        }

        private void btnCloseWin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    idSemestre = Convert.ToInt32(cmbSemestreLst.SelectedValue);
                    idDocente = Convert.ToInt32(cmbDocente.SelectedValue);
                    idTpDocente = Convert.ToInt32(cmbTipoDocente.SelectedValue);
                    objTpDocente.CreateDocenteWHorasExigibles_Neg(idTpDocente.ToString(),idSemestre.ToString(),idDocente.ToString(), txtHorasExigibles.Text);
                    MessageBox.Show("Docente con horas exigibles insertado correctamente");
                    ClearFrom();
                    MostrarRegistrosPorSemestre();
                    panelHorasExigibles.Visible = false;
                    txtHorasExigibles.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepción: No se pudo registrar el Docente con horas exigibles. Motivo: " + ex.Message);
                }

            }
            if (Editar == true)
            {
               
                try
                {
                    
                    objTpDocente.UpdateDocenteWHorasExigibles_Neg(idSemestreTpDocente.ToString(),idTpDocente.ToString(), idSemestre.ToString(), idDocente.ToString(), txtHorasExigibles.Text);
                    MessageBox.Show("Docente con horas exigibles actualizado correctamente");
                    MostrarRegistrosPorSemestre();
                    ClearFrom();
                    Editar = false;
                    panelHorasExigibles.Visible = false;
                    txtHorasExigibles.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            panelCreate.Visible = false;
            btnCargarData.Visible = true;
        }

        private void btnCargarData_Click(object sender, EventArgs e)
        {

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstRegistros.Rows.Count > 0)
                {
                    idSemestreTpDocente = Convert.ToInt32(dgLstRegistros.CurrentRow.Cells[0].Value);
                    MessageBox.Show(idSemestreTpDocente.ToString());
                    objTpDocente.DeleteDocenteWithHorasExig_Neg(idSemestreTpDocente.ToString());
                    MessageBox.Show("Docente con horas exigibles eliminado correctamente");
                    MostrarRegistrosPorSemestre();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee eliminar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo eliminar el Docente seleccionado. Motivo: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstRegistros.Rows.Count > 0)
                {
                    btnGuardar.Text = "Actualizar";
                    btnCargarData.Visible= false;
                    panelCreate.Visible = true;
                    Editar = true;
                    cmbDocente.Text = dgLstRegistros.CurrentRow.Cells[1].Value.ToString();
                    cmbSemestreAdd.Text = dgLstRegistros.CurrentRow.Cells[4].Value.ToString();
                    cmbTipoDocente.Text = dgLstRegistros.CurrentRow.Cells[2].Value.ToString();
                    txtHorasExigibles.Text = dgLstRegistros.CurrentRow.Cells[3].Value.ToString();
                    idSemestre = Convert.ToInt32(cmbSemestreLst.SelectedValue);
                    idDocente = Convert.ToInt32(cmbDocente.SelectedValue);
                    idTpDocente = Convert.ToInt32(cmbTipoDocente.SelectedValue);
                    idSemestreTpDocente = Convert.ToInt32(dgLstRegistros.CurrentRow.Cells[0].Value);
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee editar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo actualizar el Tipo de Actividad seleccionado. Motivo: " + ex.Message);
            }
        }
        #endregion
        private void ClearFrom()
        {
            cmbDocente.SelectedValue = -1;
            cmbDocente.SelectedIndex = -1;
            cmbSemestreAdd.SelectedValue = -1;
            cmbSemestreAdd.SelectedIndex = -1;
            cmbTipoDocente.SelectedValue = -1;
            cmbTipoDocente.SelectedIndex = -1;
            txtHorasExigibles.Text = "";
        }

        #region Comboboxes Actions
        private void cmbDocente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbSemestreAdd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbTipoDocente_SelectedIndexChanged(object sender, EventArgs e)
        {
            count++;
            if (cmbTipoDocente.SelectedIndex > -1 && count > 3)
            {
                panelHorasExigibles.Visible = true;
                int TpDocenteValue = Convert.ToInt32(cmbTipoDocente.SelectedValue);
                numHorasExigiblesQry = objTpDocente.GetHorasExigiblesByTpDocenteNegocio(TpDocenteValue.ToString());
                txtHorasExigibles.Text = numHorasExigiblesQry.ToString();
            }
            
        }

        private void cmbSemestreLst_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarRegistrosPorSemestre();
        }
        #endregion

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtHorasExigibles.Enabled = true;
        }
    }
}