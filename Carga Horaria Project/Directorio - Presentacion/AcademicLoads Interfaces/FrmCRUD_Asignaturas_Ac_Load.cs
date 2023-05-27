using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Entidades;
using Directorio_Logica;
using Directorio_LogicaNegocio;
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
    public partial class FrmCRUD_Asignaturas_Ac_Load : Form
    {

        private int idAcLoadLocal;
        private int countBtns = 0;
        private bool Editar = false;
        ClsStyles tableStyle = new ClsStyles();
        private CN_CargaHoraria objetoCNegocio = new CN_CargaHoraria();

        private static string AsignaturaName;
        private static string GrName;
        private static int idAsigCarga;

        private FrmCUAsignatura_AL childAsigFrm;
        private FrmCreate_AcademicLoad _frmAcademicLoad;
        private FrmCRUD_Asignaturas_Ac_Load _frmCRUD;

        public FrmCRUD_Asignaturas_Ac_Load(int idAcLoad)
        {
            InitializeComponent();
            idAcLoadLocal = idAcLoad;
            tableStyle.tableStyle(dgLstRegistros);
        }

        private void FrmCRUD_Asignaturas_Ac_Load_Load(object sender, EventArgs e)
        {
            MostrarRegistros();
        }
        private void MostrarRegistros()
        {
            CN_CargaHoraria objetoCNegocio = new CN_CargaHoraria();
            dgLstRegistros.DataSource = objetoCNegocio.LoadAsignaturas_Negocio(idAcLoadLocal.ToString());
            dgLstRegistros.Columns[0].Visible = false;
            if (countBtns < 1)
            {
                countBtns++;
                AddBtnsIntoDataGridView();
                dgLstRegistros.AutoGenerateColumns = false;
            }
        }

        private void btnAddAsignatura_Click(object sender, EventArgs e)
        {
            Editar = false;
            FrmCUAsignatura_AL frmCUAsignatura = new FrmCUAsignatura_AL(idAcLoadLocal, Editar);
            frmCUAsignatura.FrmAcademicLoad = _frmAcademicLoad;
            frmCUAsignatura.FrmCRUD = _frmCRUD;
            frmCUAsignatura.FormClosed += ChildForm_FormClosed;
            frmCUAsignatura.ShowDialog();
        }
        public void ChildForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Actualizar información en el formulario FrmCRUD_Asignaturas_Ac_Load
            MostrarRegistros();
        }
        public void UpdateContent()
        {
            // Actualizar información en el formulario FrmCRUD_Asignaturas_Ac_Load
            MostrarRegistros();
        }
        private void btnUpdateTbl_Click(object sender, EventArgs e)
        {
            MostrarRegistros();
        }

        #region Actions Buttons in DataGrid
        private void AddBtnsIntoDataGridView()
        {
            //Image as button
            DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
            btnEdit.HeaderText = "Editar";
            btnEdit.Tag = true;
            btnEdit.Image = new Bitmap(Properties.Resources.boton_editar, new Size(40, 40));
            btnEdit.ToolTipText = "Editar registro";
            dgLstRegistros.Columns.Add(btnEdit);

            DataGridViewImageColumn btnConfirmDelete = new DataGridViewImageColumn();
            btnConfirmDelete.HeaderText = "Eliminar";
            btnConfirmDelete.Tag = true;
            btnConfirmDelete.Image = new Bitmap(Properties.Resources.delete, new Size(40, 40));
            btnConfirmDelete.ToolTipText = "Eliminar registro";
            dgLstRegistros.Columns.Add(btnConfirmDelete);
        }
        #endregion

        private void dgLstRegistros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                Editar = true;
                idAsigCarga = Convert.ToInt32(dgLstRegistros.Rows[e.RowIndex].Cells["ID"].Value);
                FrmCUAsignatura_AL frm = new FrmCUAsignatura_AL(idAcLoadLocal, Editar);
                AsignaturaName = dgLstRegistros.Rows[e.RowIndex].Cells[2].Value.ToString();
                GrName = dgLstRegistros.Rows[e.RowIndex].Cells[1].Value.ToString();
                frm.ShowDialog();
                Editar = false;
            }
            else if (e.ColumnIndex == 6 && e.RowIndex >= 0)
            {
                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Obtener el ID del registro que se va a eliminar
                    int id = Convert.ToInt32(dgLstRegistros.Rows[e.RowIndex].Cells["ID"].Value);

                    objetoCNegocio.DeleteAsignaturaCargaHNeg(id.ToString());

                    // Eliminar la fila del DataGridView
                    dgLstRegistros.Rows.RemoveAt(e.RowIndex);
                    MostrarRegistros();
                    FrmCreate_AcademicLoad frmAcademicLoad = Application.OpenForms["FrmCreate_AcademicLoad"] as FrmCreate_AcademicLoad;
                    if (frmAcademicLoad != null)
                    {
                        frmAcademicLoad.UpdateContent();
                    }
                }
            }
        }

        public List<string> GetArgumentosToEdit()
        {
            // hacer algo con los argumentos recibidos
            List <string> list = new List<string>();
            list.Add(AsignaturaName);
            list.Add(GrName);
            list.Add(idAsigCarga.ToString());
            return list;
        }

        private void FrmCRUD_Asignaturas_Ac_Load_Activated(object sender, EventArgs e)
        {
            this.Owner.Controls["btnAsignaturas"].BackColor = Color.Red;
        }
    }
}
