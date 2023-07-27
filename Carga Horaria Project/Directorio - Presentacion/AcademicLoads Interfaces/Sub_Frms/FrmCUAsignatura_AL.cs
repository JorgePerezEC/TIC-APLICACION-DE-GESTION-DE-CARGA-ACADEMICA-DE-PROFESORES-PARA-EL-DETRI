﻿using Directorio___Presentacion.AcademicLoads_Interfaces.Sub_Frms;
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
        //Variables to edit
        private bool EditarL = false;
        private CN_CargaHoraria objetoNegocioCargaHoraria = new CN_CargaHoraria();
        private CN_GrAsignatura objNegocioGrAsig = new CN_GrAsignatura();
        int count = 0;
        public FrmCUAsignatura_AL(int idCargaHoraria, bool Editar, int idSemestre)
        {
            InitializeComponent();
            this.KeyPreview = true;
            idAcLoad = idCargaHoraria;
            EditarL = Editar;
            idSemestreLocal = idSemestre;
            btnAgregar.Enabled = Editar;

            this.FormClosed += new FormClosedEventHandler(FrmCUAsignatura_AL_FormClosed);
        }

        private void FrmCUAsignatura_AL_Load(object sender, EventArgs e)
        {
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
            cmbAsignatura.DataSource = objetoCNegocio.MostrarAsignaturasWithGroups_CNegocio(idSemestreLocal.ToString());
            cmbAsignatura.DisplayMember = "Asignatura";
            cmbAsignatura.ValueMember = "ID";
        }
        private void ListarAsignaturasAll()
        {
            CN_Asignatura objetoCNegocio = new CN_Asignatura();
            cmbAsignatura.DataSource = objetoCNegocio.MostrarAllAsignaturasCmb_CNegocio();
            cmbAsignatura.DisplayMember = "Asignatura";
            cmbAsignatura.ValueMember = "ID";
        }
        public void ListarGruposAsignatura(bool NewGr)
        {
            if (cmbAsignatura.SelectedIndex > -1)
            {
                panelGR.Visible = true;
                cmbGR.Visible = true;
                CN_GrAsignatura objetoGrNegocio = new CN_GrAsignatura();
                cmbGR.DataSource = objetoGrNegocio.MostrarGruposPorAsignatura_Negocio(cmbAsignatura.Text);
                cmbGR.DisplayMember = "Grupos";
                cmbGR.ValueMember = "ID";
                txtNivel.Text = objetoGrNegocio.GetLvlAsignatura_Negocio(cmbAsignatura.Text);
                txtType.Text = objetoGrNegocio.GetTypeAsigByAsig_Negocio(cmbAsignatura.Text);
                txtCode.Text = objetoGrNegocio.GetCodeAsigByAsig_Negocio(cmbAsignatura.Text);
                if (NewGr)
                {
                    cmbGR.SelectedIndex = cmbGR.Items.Count - 1;
                }
            }
        }
        #endregion

        private void cmbGR_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            count++;
            if (cmbAsignatura.SelectedIndex > -1 && count > 2)
            {
                ListarGruposAsignatura(false);
                btnAgregar.Enabled = true;
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
            Frm_CreateNewAsignatura_Modal frmCreateAsig = new Frm_CreateNewAsignatura_Modal(cmbAsignatura.Text);
            frmCreateAsig.ShowDialog();
        }
    }
}
