using Directorio___Presentacion.AcademicLoads_Interfaces;
using Directorio___Presentacion.AcademicLoads_Interfaces.Activate_Data_Frms;
using Directorio___Presentacion.CRUD_Data_Interfaces;
using Directorio___Presentacion.CRUD_Interfaces;
using Directorio___Presentacion.Reportes_Frms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Directorio___Presentacion
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            CustomDesign();
        }
        #region Métodos para manipular paneles
        private void CustomDesign()
        {
            panelSubmenuAdminCargas.Visible= false;
            panelSubmenuGestionData.Visible= false;
            panelGestActividades.Visible = false;
            panelGestionAsig.Visible = false;
            panelGestionDocentes.Visible = false;

        }
        private void hideSubMenu()
        {
            if (panelSubmenuAdminCargas.Visible)
            {
                panelSubmenuReportes.Visible = false;
                panelSubmenuAdminCargas.Visible = false;
            }
            if (panelSubmenuGestionData.Visible)
            {
                panelSubmenuGestionData.Visible = false;
                panelGestActividades.Visible = false;
                panelGestionAsig.Visible = false;
                panelGestionDocentes.Visible = false;
                panelSubmenuReportes.Visible = false;
            }
            if (panelSubmenuReportes.Visible)
            {
                panelSubmenuAdminCargas.Visible = false;
                panelSubmenuGestionData.Visible = false;
                panelGestActividades.Visible = false;
                panelGestionAsig.Visible = false;
                panelGestionDocentes.Visible = false;
                panelSubmenuReportes.Visible = false;
            }
        }
        private void hideSubMenu2()
        {
            if (panelGestActividades.Visible)
                panelGestActividades.Visible = false;
            if (panelGestionAsig.Visible)
                panelGestionAsig.Visible = false;
            if (panelGestionDocentes.Visible)
                panelGestionDocentes.Visible = false;
        }
        private void ShowSubmenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
                hideSubMenu();
                hideSubMenu2();
            }
                
        }
        private void ShowSubmenu2(Panel subMenu2)
        {
            if (subMenu2.Visible == false)
            {
                hideSubMenu2();
                subMenu2.Visible = true;
            }
            else
            {
                subMenu2.Visible = false;
                hideSubMenu();
                hideSubMenu2();
            }
        }
        #endregion

        #region Método para abrir formularios hijos
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if(activeForm != null)
                activeForm.Close();
        
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock= DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        #endregion

        #region Click Events - Btns Principales Menu
        private void btnGestion_Click(object sender, EventArgs e)
        {
            ShowSubmenu(panelSubmenuGestionData);
        }

        private void btnGestionActividades_Click(object sender, EventArgs e)
        {
            ShowSubmenu2(panelGestActividades);
        }

        private void btnGestionAsignaturas_Click(object sender, EventArgs e)
        {
            ShowSubmenu2(panelGestionAsig);
        }

        private void btnGestionCarreras_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmCRUD_Carrera());
            hideSubMenu();
        }

        private void btnGestionDepartamentos_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmCRUD_Departamento());
            hideSubMenu();
        }

        private void btnGestionDocentes_Click(object sender, EventArgs e)
        {
            ShowSubmenu2(panelGestionDocentes);
        }

        private void btnGestionSemestres_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmCRUD_Semestre());
            hideSubMenu();
        }
        private void btnAdminCargas_Click(object sender, EventArgs e)
        {
            //openChildForm(new FrmCRUD_Semestre());
            ShowSubmenu(panelSubmenuAdminCargas);
            //hideSubMenu();
        }
        private void btnReportesMain_Click(object sender, EventArgs e)
        {
            ShowSubmenu(panelSubmenuReportes);
            //hideSubMenu();
        }
        #endregion

        #region Click Events - Btns Secundarios Submenu
        private void btnActividades_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmCRUD_Actividad());
            hideSubMenu();
            hideSubMenu2();
        }
        private void btnTpActividades_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmCRUD_TipoActividad());
            hideSubMenu();
            hideSubMenu2();
        }

        private void btnAsignaturas_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmCRUD_Asignatura());
            hideSubMenu();
            hideSubMenu2();
        }
        private void btnGrupoAsig_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmCRUD_GrupoAsignatura());
            hideSubMenu();
            hideSubMenu2();
        }
        private void btnHorarios_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmCRUD_HorarioAsignatura());
            hideSubMenu();
            hideSubMenu2();
        }
        private void btnDocentes_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmCRUD_Docente());
            hideSubMenu();
            hideSubMenu2();
        }
        private void btnTpDocentes_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmCRUD_TipoDocente());
            hideSubMenu();
            hideSubMenu2();
        }
        public void btnAsignarHoras_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmCRUD_HorasExigibles());
            hideSubMenu();
            hideSubMenu2();
        }


        #endregion

        private void btnCrearCargaAcademica_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmCreate_AcademicLoad());
            hideSubMenu();
            hideSubMenu2();
        }

        private void btnGestionarCargas_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmAcademicsLoads_Viewer());
            hideSubMenu();
            hideSubMenu2();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            pixtbxLogo.Image = Image.FromFile(@"Images\EPNLogo.png");
        }

        private void btnReporteDocentesCargas_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmReporteDocentesCargas());
            hideSubMenu();
            hideSubMenu2();
        }

        private void btnHabilitarDocentes_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmManageSmstData());
            hideSubMenu();
            hideSubMenu2();
        }

        private void btnHabilitarAsignaturas_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmManageAsigSmst());
            hideSubMenu();
            hideSubMenu2();
        }
    }
}
