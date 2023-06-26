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

namespace Directorio___Presentacion.AcademicLoads_Interfaces.Activate_Data_Frms
{
    public partial class Frm_Activate_Docente : Form
    {
        #region Define Variables
        CN_Semestre objSemestre_N = new CN_Semestre();
        private CN_Semestre objSemestre_Neg;
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
        public Frm_Activate_Docente()
        {
            InitializeComponent();
        }
        private void Frm_Activate_Docente_Load(object sender, EventArgs e)
        {
            ListarSemestres();
            //SuscribirEventoClick();
        }

        private void MostrarDocentes()
        {
            dgvDocenteSemestre.DataSource = objDocente_N.MostrarDocentesAllNames();
            dgvDocenteSemestre.Columns[1].HeaderText = "Docente";
            dgvDocenteSemestre.Columns[0].Visible = false;
            clsStyles.tableStyle(dgvDocenteSemestre);
            dgvDocenteSemestre.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void ListarSemestres()
        {
            cmbSemestre.DataSource = objSemestre_N.MostrarSemestres();
            cmbSemestre.DisplayMember = "Código";
            cmbSemestre.ValueMember = "ID";
            cmbSemestre.SelectedIndex = -1;
        }
        #region Buttons Section
        private void btnCloseWin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void cmbSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            count++;
            if (cmbSemestre.SelectedIndex > -1 && count > 3)
            {
                MostrarDocentes();
                AgregarColumnaHabilitar();
                
            }
        }

        private void AgregarColumnaHabilitar()
        {
            DataGridViewCheckBoxColumn columnaHabilitar = new DataGridViewCheckBoxColumn();
            columnaHabilitar.HeaderText = "Habilitar";
            columnaHabilitar.Name = "Habilitar";
            columnaHabilitar.TrueValue = true;
            columnaHabilitar.FalseValue = false;
            columnaHabilitar.Width = 70;

            dgvDocenteSemestre.Columns.Add(columnaHabilitar);
        }
        //private void SuscribirEventoClick()
        //{
        //    dgvDocenteSemestre.CellContentClick += dgvDocenteSemestre_CellContentClick;
        //}
        private void dgvDocenteSemestre_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.ColumnIndex.ToString());
            if (e.ColumnIndex == dgvDocenteSemestre.Columns["Habilitar"].Index && e.RowIndex >= 0 && dgvDocenteSemestre.Rows[e.RowIndex].Cells["Habilitar"] is DataGridViewCheckBoxCell checkBoxCell)
            {
                if (checkBoxCell != null)
                {

                    bool habilitado = (bool)checkBoxCell.EditedFormattedValue;
                    checkBoxCell.Value = !habilitado;

                    string nombreDocente = dgvDocenteSemestre.Rows[e.RowIndex].Cells[1].Value.ToString();

                    objSemestre_Neg = new CN_Semestre();
                    MessageBox.Show(cmbSemestre.SelectedValue.ToString()+" "+ dgvDocenteSemestre.Rows[e.RowIndex].Cells[0].Value.ToString() + " " + (!habilitado).ToString());
                    objSemestre_Neg.CreateOrUpdateSemestreDocente_Negocio(cmbSemestre.SelectedValue.ToString(), dgvDocenteSemestre.Rows[e.RowIndex].Cells[0].Value.ToString(), (!habilitado).ToString());
                    if ((bool)checkBoxCell.EditedFormattedValue)
                    {
                        MessageBox.Show("Se ha habilitado el docente: " + nombreDocente);
                    }
                    else
                    {
                        MessageBox.Show("Se ha deshabilitado el docente: " + nombreDocente);
                    }
                }
            }
        }
    }
}
