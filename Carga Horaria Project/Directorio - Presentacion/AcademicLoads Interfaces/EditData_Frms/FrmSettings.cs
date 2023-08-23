using Directorio___Presentacion.AcademicLoads_Interfaces.EditData_Frms.Settings_Frms;
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
    public partial class FrmSettings : Form
    {
        private FrmEditMail frmMailSon;
        public FrmSettings()
        {
            InitializeComponent();
        }

        private void btnConfigurarCorreo_Click(object sender, EventArgs e)
        {
            frmMailSon = new FrmEditMail();
            openChildForm(frmMailSon);
        }

        #region Método para abrir formularios hijos
        public Form activeForm = null;



        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChild.Controls.Add(childForm);
            panelChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        #endregion
    }
}
