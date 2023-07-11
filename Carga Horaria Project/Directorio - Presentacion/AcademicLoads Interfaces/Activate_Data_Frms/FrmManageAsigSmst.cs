using Directorio___Presentacion.ElementsStyles_Configuration;
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
    public partial class FrmManageAsigSmst : Form
    {
        #region Define Variables
        CN_Semestre objSemestre_N = new CN_Semestre();
        private CN_Semestre objSemestre_Neg;
        CN_Docente objDocente_N = new CN_Docente();
        CN_TipoDocente objTpDocente = new CN_TipoDocente();
        private ClsStyles clsStyles = new ClsStyles();

        private bool Editar = false;
        private int idTipoDocente = 7;
        #endregion

        public FrmManageAsigSmst()
        {
            InitializeComponent();
        }

        private void FrmManageAsigSmst_Load(object sender, EventArgs e)
        {
            panelContent.Visible = false;
            ListarSemestres();
        }

        private void LimpiarTabla()
        {
            dgvAsignaturasSemestre.DataSource = null;
            dgvAsignaturasSemestre.Rows.Clear();
            dgvAsignaturasSemestre.Columns.Clear();
        }


        private void ListarSemestres()
        {
            cmbSemestre.SelectedIndexChanged -= cmbSemestre_SelectedIndexChanged;
            cmbSemestre.DisplayMember = "Código";
            cmbSemestre.ValueMember = "ID";
            cmbSemestre.DataSource = objSemestre_N.MostrarSemestres();
            cmbSemestre.SelectedIndex = -1;
            cmbSemestre.SelectedIndexChanged += cmbSemestre_SelectedIndexChanged;
        }

        private void cmbSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarAsignaturas();
        }

        private void MostrarAsignaturas()
        {
            if (cmbSemestre.SelectedValue != null)
            {
                CN_Docente objDocente_N = new CN_Docente();
                CN_Asignatura objAsignatura = new CN_Asignatura();
                string idSemestre = cmbSemestre.SelectedValue.ToString();
                LimpiarTabla();

                // Cargar el contenido de la tabla
                panelContent.Visible = true;
                DataTable dtAsignaturas = objAsignatura.MostrarRegistrosByIdSemestre_Negocio(idSemestre);
                dgvAsignaturasSemestre.DataSource = dtAsignaturas;
                dgvAsignaturasSemestre.Columns[2].HeaderText = "Código";
                dgvAsignaturasSemestre.Columns[3].HeaderText = "Asignatura";
                dgvAsignaturasSemestre.Columns[4].HeaderText = "Activa?";

                // Asignar los valores correspondientes a los ComboBox
                //for (int i = 0; i < dgvAsignaturasSemestre.Rows.Count - 1; i++)
                //{
                //    int valorColumna = Convert.ToInt32(dtAsignaturas.Rows[i][3]);

                //    for (int j = 4; j < dgvAsignaturasSemestre.Columns.Count; j++)
                //    {
                //        dgvAsignaturasSemestre.Rows[i].Cells[j].Value = false;
                //    }

                //    int columnaIndex = valorColumna + 3;
                //    if (columnaIndex >= 4 && columnaIndex < dgvAsignaturasSemestre.Columns.Count)
                //    {
                //        dgvAsignaturasSemestre.Rows[i].Cells[columnaIndex].Value = true;
                //    }
                //}
                dgvAsignaturasSemestre.Columns[0].Visible = false;
                dgvAsignaturasSemestre.Columns[1].Visible = false;
                clsStyles.tableActivateDocentesStyle(dgvAsignaturasSemestre);
                dgvAsignaturasSemestre.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }
        }

        private void dgvAsignaturasSemestre_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvAsignaturasSemestre.Columns[4].Index && e.RowIndex >= 0 && dgvAsignaturasSemestre.Rows[e.RowIndex].Cells[4] is DataGridViewCheckBoxCell checkBoxCell)
            {
                if (checkBoxCell != null)
                {

                    bool habilitado = (bool)checkBoxCell.EditedFormattedValue;
                    checkBoxCell.Value = !habilitado;

                    objSemestre_Neg = new CN_Semestre();

                    if ((bool)checkBoxCell.EditedFormattedValue)
                    {
                        objSemestre_Neg.CreateOrUpdateSemestreAsignatura_Negocio(cmbSemestre.SelectedValue.ToString(), dgvAsignaturasSemestre.Rows[e.RowIndex].Cells[1].Value.ToString(), (!habilitado).ToString());
                        MostrarAsignaturas();
                    }
                    else
                    {
                        //MessageBox.Show("Se ha deshabilitado el docente: " + nombreDocente);
                        objSemestre_Neg.CreateOrUpdateSemestreAsignatura_Negocio(cmbSemestre.SelectedValue.ToString(), dgvAsignaturasSemestre.Rows[e.RowIndex].Cells[1].Value.ToString(), (!habilitado).ToString());
                        MostrarAsignaturas();
                    }
                }
            }
        }
    }
}
