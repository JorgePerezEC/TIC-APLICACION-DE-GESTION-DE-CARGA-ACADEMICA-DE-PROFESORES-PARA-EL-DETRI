﻿using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Logica;
using ScottPlot.Palettes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Directorio___Presentacion.AcademicLoads_Interfaces.Sub_Frms
{
    
    public partial class Frm_CreateNewActivity_Modal : Form
    {
        private string tipoAc = "";
        private CN_Actividad objetoCNegocio = new CN_Actividad();
        public Frm_CreateNewActivity_Modal(string tipoActividad)
        {
            InitializeComponent();
            this.KeyPreview = true;
            tipoAc = tipoActividad;
        }   

        private void Frm_CreateNewActivity_Modal_Load(object sender, EventArgs e)
        {
            ListarTiposActividades();
            btnGuardar.Text = "&Guardar";
            this.KeyPreview = true;
            txtHorasSemanales.Enabled = false;
            txtHorasTotales.Enabled = false;
            ckboxSemanal.Checked = false;
            ckboxTotal.Checked = false;
            int index = cmbTpActiv.FindStringExact(tipoAc);
            if (index != -1)
            {
                cmbTpActiv.SelectedIndex = index;
                cmbTpActiv.Enabled = false;
            }
        }

        private void ListarTiposActividades()
        {
            CN_Actividad objetoCNegocio = new CN_Actividad();
            cmbTpActiv.DataSource = objetoCNegocio.MostrarTpActividadesNeg();
            cmbTpActiv.DisplayMember = "Tipo de Actividad";
            cmbTpActiv.ValueMember = "ID";
            cmbTpActiv.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTpActiv.SelectedIndex = -1;
        }

        private void ckboxSemanal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckboxSemanal.Checked)
            {
                ckboxTotal.Checked = false;
                txtHorasTotales.Text = "0";
                txtHorasSemanales.Text = "";
                txtHorasTotales.Enabled = false;
                txtHorasSemanales.Enabled = true;
            }
        }

        private void ckboxTotal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckboxTotal.Checked)
            {
                txtHorasTotales.Text = "";
                ckboxSemanal.Checked = false;
                txtHorasSemanales.Text = "0";
                txtHorasSemanales.Enabled = false;
                txtHorasTotales.Enabled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNameActividad.Text == "")
                {
                    MessageBox.Show("Debe ingresar el nombre de la actividad para completar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int cmbValue = Convert.ToInt32(cmbTpActiv.SelectedValue);

                objetoCNegocio.CreateActividadNeg(cmbValue.ToString(), txtNameActividad.Text, txtHorasSemanales.Text, txtHorasTotales.Text);
                MessageBox.Show("Actividad insertadada correctamente");
                this.Close();

                FrmCUActividad_AL frmCuActividad = Application.OpenForms["FrmCUActividad_AL"] as FrmCUActividad_AL;
                if (frmCuActividad != null)
                {
                    frmCuActividad.ListarAllActividadesCmb(cmbTpActiv.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo registrar la Actividad. Motivo: " + ex.Message);
            }
        }

        private void cmbTpActiv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Frm_CreateNewActivity_Modal_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_CreateNewActivity_Modal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnGuardar.PerformClick();
                e.Handled = true;
            }
        }

        private void Frm_CreateNewActivity_Modal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.G)
            {
                btnGuardar.PerformClick();
                e.Handled = true;
            }
        }
    }
}