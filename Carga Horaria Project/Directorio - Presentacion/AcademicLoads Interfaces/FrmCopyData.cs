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
                btnCopiarInfo.Enabled = true;

            }            
        }

        

        private void btnCopiarInfo_Click(object sender, EventArgs e)
        {
            CN_Semestre objetoSemestreCNegocio = new CN_Semestre();

            if (cmbSemestreAPegar.SelectedIndex > -1 && cmbSemestreAPegar.SelectedValue != null && cmbSemestreACopiar.SelectedIndex > -1 && cmbSemestreACopiar.SelectedValue != null)
            {
                if (int.TryParse(cmbSemestreACopiar.SelectedValue.ToString(), out int selectedValueAsInt) && selectedValueAsInt > 0 && int.TryParse(cmbSemestreAPegar.SelectedValue.ToString(), out int selectedValuePAsInt) && selectedValueAsInt > 0)
                {
                    if (cmbSemestreACopiar.SelectedIndex == cmbSemestreAPegar.SelectedIndex)
                    {
                        MessageBox.Show("Seleccione semestres diferentes para continuar.");
                        return;
                    }

                    if (cbCopiarHorarios.Checked)
                    {
                        bool resul = objetoSemestreCNegocio.CopyHorariosEntreSemestres_Negocio(cmbSemestreACopiar.SelectedValue.ToString(), cmbSemestreAPegar.SelectedValue.ToString());

                        if (resul)
                        {
                            btnCopiarInfo.Enabled = false;
                            MessageBox.Show("Horarios copiados de forma exitosa.");
                            lblResulHorarios.Text = "EXITO";
                            lblResulHorarios.BackColor= Color.Green;
                            if (cbCopiarCargasHorarias.Checked)
                            {
                                bool resulCargas = objetoSemestreCNegocio.CopyCargasEntreSemestres_Negocio(cmbSemestreACopiar.SelectedValue.ToString(), cmbSemestreAPegar.SelectedValue.ToString());

                                if (resulCargas)
                                {
                                    btnCopiarInfo.Enabled = false;
                                    MessageBox.Show("Cargas Académicas copiadas de forma exitosa.");
                                    cmbSemestreACopiar.Enabled= false;
                                    cmbSemestreAPegar.Enabled= false;
                                    lblResulCargas.Text = "EXITO";
                                    lblResulCargas.BackColor = Color.LightGreen;
                                    //clearData();
                                }
                                else
                                {
                                    MessageBox.Show("No se puedo copiar la información.");
                                    btnCopiarInfo.Enabled = true;
                                    lblResulCargas.Text = "ERROR";
                                    lblResulCargas.BackColor = Color.Red;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se puedo copiar la información.");
                            btnCopiarInfo.Enabled = true;
                            lblResulHorarios.Text = "ERROR";
                            lblResulHorarios.BackColor = Color.Red;
                            return;
                        }
                    }

                    if (cbCopiarCargasHorarias.Checked && !cbCopiarHorarios.Checked)
                    {
                        bool resulCargas = objetoSemestreCNegocio.CopyCargasEntreSemestres_Negocio(cmbSemestreACopiar.SelectedValue.ToString(), cmbSemestreAPegar.SelectedValue.ToString());

                        if (resulCargas)
                        {
                            btnCopiarInfo.Enabled = false;
                            MessageBox.Show("Cargas Académicas copiadas de forma exitosa.");
                            cmbSemestreACopiar.Enabled = false;
                            cmbSemestreAPegar.Enabled = false;
                            lblResulCargas.Text = "EXITO";
                            lblResulCargas.BackColor = Color.LightGreen;
                            //clearData();
                        }
                        else
                        {
                            MessageBox.Show("No se puedo copiar la información.");
                            btnCopiarInfo.Enabled = true;
                            lblResulCargas.Text = "ERROR";
                            lblResulCargas.BackColor = Color.Red;
                            return;
                        }
                    }
                }
            }
        }

    }
    }
