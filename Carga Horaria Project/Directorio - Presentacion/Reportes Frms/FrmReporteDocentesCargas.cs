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

namespace Directorio___Presentacion.Reportes_Frms
{
    public partial class FrmReporteDocentesCargas : Form
    {
        private int count;
        private int cmbValueSemestre;

        CN_Semestre objSemestre_N = new CN_Semestre();
        CN_CargaHoraria objCarga_N = new CN_CargaHoraria();

        public FrmReporteDocentesCargas()
        {
            InitializeComponent();
            ClsStyles tableStyle = new ClsStyles();
            tableStyle.tableStyle(dgvReporteCargasDocentes);
        }

        private void FrmReporteDocentesCargas_Load(object sender, EventArgs e)
        {
            ListarSemestres();
        }

        #region GET DATA METHODS
        private void ListarSemestres()
        {
            cmbSemestre.DataSource = objSemestre_N.MostrarSemestres();
            cmbSemestre.DisplayMember = "Código";
            cmbSemestre.ValueMember = "ID";
            cmbSemestre.SelectedValue = -1;
            cmbSemestre.SelectedIndex = -1;
        }
        #endregion

        private void cmbSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            count++;
            if (cmbSemestre.SelectedIndex > -1 && count > 2)
            {
                cmbValueSemestre = Convert.ToInt32(cmbSemestre.SelectedValue);
                dgvReporteCargasDocentes.DataSource = objCarga_N.MostrarReporteDocentes_ByIdSemestre_Negocio(cmbValueSemestre.ToString());
                dgvReporteCargasDocentes.Columns[3].Visible = false;
            }
        }
    }
}
