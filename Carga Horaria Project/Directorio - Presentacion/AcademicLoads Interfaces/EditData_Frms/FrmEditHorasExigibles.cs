using Directorio_Logica;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Directorio___Presentacion.AcademicLoads_Interfaces.EditData_Frms
{
    public partial class FrmEditHorasExigibles : MaterialForm
    {

        CN_Semestre objSemestre_Negocio = new CN_Semestre();
        private int idSemestreL;
        private int idDocenteL;
        public FrmEditHorasExigibles(int idSemestre, int idDocente)
        {
            InitializeComponent();
            idSemestreL = idSemestre;
            idDocenteL = idDocente;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void FrmEditHorasExigibles_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (txtHorasExigibles.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un número de horas exigibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int horasExigibles = Convert.ToInt32(txtHorasExigibles.Text);
            if ( horasExigibles  == 0)
            {
                MessageBox.Show("Ingrese un número de horas exigibles mayor a cero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            if (objSemestre_Negocio.UpdateHorasExigiblesSemestreDocente_Negocio(idSemestreL.ToString(), idDocenteL.ToString(), txtHorasExigibles.Text))
            {
                FrmCreate_AcademicLoad frmAcademicLoad = Application.OpenForms["FrmCreate_AcademicLoad"] as FrmCreate_AcademicLoad;
                
                if (frmAcademicLoad != null)
                {
                    frmAcademicLoad.UpdateContent();
                }
                MessageBox.Show("Horas Exigibles actualizadas correctamente.", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtHorasExigibles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}
