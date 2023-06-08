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

namespace Directorio___Presentacion.AcademicLoads_Interfaces.Sub_Frms
{
    public partial class Frm_CreateNewAsignatura_Modal : Form
    {
        CN_GrAsignatura objetoCNegocio = new CN_GrAsignatura();
        private string asignatura = "";
        public Frm_CreateNewAsignatura_Modal(string asignaturaName)
        {
            InitializeComponent();
            asignatura= asignaturaName;
        }

        private void Frm_CreateNewAsignatura_Modal_Load(object sender, EventArgs e)
        {
            ListarAsignaturas();
            this.KeyPreview = true;
            int index = cmbAsignaturas.FindStringExact(asignatura);
            if (index != -1)
            {
                cmbAsignaturas.SelectedIndex = index;
                cmbAsignaturas.Enabled = false;
            }
        }
        private void ListarAsignaturas()
        {
            CN_Asignatura objetoCNegocio = new CN_Asignatura();
            cmbAsignaturas.DataSource = objetoCNegocio.MostrarAsignaturas();
            cmbAsignaturas.DisplayMember = "Nombre de la Asignatura";
            cmbAsignaturas.ValueMember = "ID";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbGR.Text == "")
            {
                MessageBox.Show("Debe ingresar un GR para completar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int cmbValue = Convert.ToInt32(cmbAsignaturas.SelectedValue);
            objetoCNegocio.CreateGruposNeg(cmbValue.ToString(), cmbGR.Text);
            MessageBox.Show("GR insertadado correctamente" + cmbGR.Text);
            FrmCUAsignatura_AL frmCuAsignatura = Application.OpenForms["FrmCUAsignatura_AL"] as FrmCUAsignatura_AL;
            if (frmCuAsignatura != null)
            {
                frmCuAsignatura.ListarGruposAsignatura();
            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_CreateNewAsignatura_Modal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.G)
            {
                btnGuardar.PerformClick();
                e.Handled = true;
            }
        }
    }
}
