using Directorio_Entidades;
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

namespace Directorio___Presentacion.AcademicLoads_Interfaces
{
    public partial class FrmCopyData : Form
    {
        CN_Semestre objSemestre_N = new CN_Semestre();
        private DataTable dtSemestres;
        private DataTable dtSemestres2;

        public FrmCopyData()
        {
            InitializeComponent();
        }

        private void btnCloseWin_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void cmbSemestreACopiar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmCopyData_Load(object sender, EventArgs e)
        {
            ListarSemestres();
        }

        private void ListarSemestres()
        {
            dtSemestres = objSemestre_N.MostrarSemestres();
            cmbSemestreACopiar.DataSource = dtSemestres;
            cmbSemestreACopiar.DisplayMember = "Código";
            cmbSemestreACopiar.ValueMember = "ID";

            dtSemestres2 = dtSemestres.Copy();
            cmbSemestreAPegar.DataSource = dtSemestres2;
            cmbSemestreAPegar.DisplayMember = "Código";
            cmbSemestreAPegar.ValueMember = "ID";
        }
        private void clearData()
        {
            cmbSemestreAPegar.SelectedIndex = -1;
            cmbSemestreACopiar.SelectedIndex = -1;
        }

        private void cmbSemestreAPegar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSemestreAPegar.SelectedIndex > -1 && cmbSemestreAPegar.SelectedValue != null && cmbSemestreACopiar.SelectedIndex > -1 && cmbSemestreACopiar.SelectedValue != null)
            {
                btnCopyInfo.Enabled = true;

            }            
        }

        private void btnCopyInfo_Click(object sender, EventArgs e)
        {
            CN_Semestre objetoSemestreCNegocio = new CN_Semestre();

            if (cmbSemestreAPegar.SelectedIndex > -1 && cmbSemestreAPegar.SelectedValue != null && cmbSemestreACopiar.SelectedIndex > -1 && cmbSemestreACopiar.SelectedValue != null)
            {
                if (int.TryParse(cmbSemestreACopiar.SelectedValue.ToString(), out int selectedValueAsInt) && selectedValueAsInt > 0 && int.TryParse(cmbSemestreAPegar.SelectedValue.ToString(), out int selectedValuePAsInt) && selectedValueAsInt > 0)
                {
                    if (cmbSemestreACopiar.SelectedValue == cmbSemestreAPegar.SelectedValue)
                    {
                        MessageBox.Show("Seleccione semestres diferentes para continuar.");
                        return;
                    }
                    bool resul = objetoSemestreCNegocio.CopyAllDataSemestres_Negocio(cmbSemestreACopiar.SelectedValue.ToString(), cmbSemestreAPegar.SelectedValue.ToString());

                    if (resul)
                    {
                        btnCopyInfo.Enabled = false;
                        MessageBox.Show("Información copiada exitosamente.");
                        clearData();
                    }
                    else
                    {
                        MessageBox.Show("No se puedo copiar la información.");
                        btnCopyInfo.Enabled = true;
                    }
                }
            }
            
        }

    }
    }
