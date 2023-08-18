using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Directorio___Presentacion.AcademicLoads_Interfaces.Error_Frms
{
    public partial class Frm_Err_HorasExigibles : Form
    {
        private string docente = "";
        private string semestre = "";
        public Frm_Err_HorasExigibles(string docenteName, string semestreName)
        {
            InitializeComponent();
            docente = docenteName;
            semestre= semestreName;
        }

        private void Frm_Err_HorasExigibles_Load(object sender, EventArgs e)
        {
            lblInfo.Text = "El Docente <" + docente + "> no posee registradas Horas Exigibles en el semestre " + semestre + ".";
            int anchoDeseado = pixtbxWarning.Width;
            int altoDeseado = pixtbxWarning.Height;
            Image imagenWarning = Image.FromFile(@"Images\warning.png");
            Image imagenRedimensionada = imagenWarning.GetThumbnailImage(anchoDeseado, altoDeseado, null, IntPtr.Zero);
            pixtbxWarning.Image = imagenRedimensionada;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close(); ;
        }

        private void btnOpenHorasExigibles_Click(object sender, EventArgs e)
        {
            FrmCreate_AcademicLoad frmAcademicLoad = Application.OpenForms["FrmCreate_AcademicLoad"] as FrmCreate_AcademicLoad;
            Main frmMain = Application.OpenForms["Main"] as Main;
            if (frmAcademicLoad != null)
            {
                frmAcademicLoad.Close();
            }
            this.Close() ;
        }
    }
}
