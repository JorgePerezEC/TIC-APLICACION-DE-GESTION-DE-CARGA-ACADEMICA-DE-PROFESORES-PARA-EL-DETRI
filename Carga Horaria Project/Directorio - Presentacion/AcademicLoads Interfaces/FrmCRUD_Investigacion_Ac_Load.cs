using Directorio___Presentacion.AcademicLoads_Interfaces.Sub_Frms;
using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Directorio___Presentacion.AcademicLoads_Interfaces
{
    public partial class FrmCRUD_Investigacion_Ac_Load : Form
    {
        //Variables to update parent form
        private FrmCUActividad_AL childActFrm;
        private FrmCreate_AcademicLoad _frmAcademicLoad;
        private FrmCRUD_Investigacion_Ac_Load _frmCRUD_Investigacion;

        private int idAcLoadLocal;
        private int countBtns = 0;
        private bool Editar = false;
        private static string ActividadName;
        private static string HoraSemanalActividad;
        private static string HoraTotalActividad;
        private static int idActividadCarga;
        public static string ActividadType = "Investigacion";
        private CN_CargaHoraria objetoCNegocio = new CN_CargaHoraria();
        public FrmCRUD_Investigacion_Ac_Load(int idAcLoad)
        {
            InitializeComponent();
            ClsStyles tableStyle = new ClsStyles();
            tableStyle.tableStyle(dgLstRegistros);
            idAcLoadLocal = idAcLoad;
        }

        private void FrmCRUD_Investigacion_Ac_Load_Load(object sender, EventArgs e)
        {
            MostrarRegistros();
        }
        private void MostrarRegistros()
        {
            CN_CargaHoraria objetoCNegocio = new CN_CargaHoraria();
            dgLstRegistros.DataSource = objetoCNegocio.LoadActividadesI_Negocio(idAcLoadLocal.ToString());
            dgLstRegistros.Columns[0].Visible = false;
            if (countBtns < 1)
            {
                countBtns++;
                AddBtnsIntoDataGridView();
                dgLstRegistros.AutoGenerateColumns = false;
            }
        }

        private void btnAddActividad_Click(object sender, EventArgs e)
        {
            Editar = false;
            FrmCUActividad_AL frmAct = new FrmCUActividad_AL(ActividadType, idAcLoadLocal, Editar);
            //frmAct.FrmAcademicLoad = _frmAcademicLoad;
            //frmAct.FrmCRUD_Investigacion = _frmCRUD_Investigacion;
            //frmAct.FormClosed += ChildForm_FormClosed;
            frmAct.ShowDialog();
        }
        public void ChildForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Actualizar información en el formulario FrmCRUD_Asignaturas_Ac_Load
            MostrarRegistros();
        }

        #region Buttons Actions in DataGrid
        private void AddBtnsIntoDataGridView()
        {
            //Image as button
            DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
            btnEdit.HeaderText = "EDITAR";
            btnEdit.Tag = true;
            btnEdit.Image = new Bitmap(Properties.Resources.boton_editar, new Size(40, 40));
            btnEdit.ToolTipText = "Editar registro";
            dgLstRegistros.Columns.Add(btnEdit);

            DataGridViewImageColumn btnConfirmDelete = new DataGridViewImageColumn();
            btnConfirmDelete.HeaderText = "ELIMINAR";
            btnConfirmDelete.Tag = true;
            btnConfirmDelete.Image = new Bitmap(Properties.Resources.delete, new Size(40, 40));
            btnConfirmDelete.ToolTipText = "Eliminar registro";
            dgLstRegistros.Columns.Add(btnConfirmDelete);
        }
        #endregion
        public List<string> GetArgumentosToEdit()
        {
            List<string> list = new List<string>();
            list.Add(ActividadName);
            list.Add(HoraSemanalActividad);
            list.Add(idActividadCarga.ToString());
            list.Add(HoraTotalActividad);
            return list;
        }

        private void dgLstRegistros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0) //Editar
            {
                Editar = true;
                idActividadCarga = Convert.ToInt32(dgLstRegistros.Rows[e.RowIndex].Cells["ID"].Value);
                FrmCUActividad_AL frm = new FrmCUActividad_AL(ActividadType,idAcLoadLocal, Editar);
                ActividadName = dgLstRegistros.Rows[e.RowIndex].Cells[1].Value.ToString();
                HoraSemanalActividad = dgLstRegistros.Rows[e.RowIndex].Cells[2].Value.ToString();
                HoraTotalActividad = dgLstRegistros.Rows[e.RowIndex].Cells[3].Value.ToString();
                frm.ShowDialog();
                Editar = false;
            }
            else if (e.ColumnIndex == 5 && e.RowIndex >= 0) //Eliminar
            {
                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Obtener el ID del registro que se va a eliminar
                    int id = Convert.ToInt32(dgLstRegistros.Rows[e.RowIndex].Cells["ID"].Value);
                    try
                    {
                        objetoCNegocio.DeleteActividadCargaHNeg(id.ToString());
                    }
                    catch (SqlException ex)
                    {
                        SqlError err = ex.Errors[0];
                        string mensaje = string.Empty;
                        switch (err.Number)
                        {
                            case 109:
                                mensaje = "Problemas con insert"; break;
                            case 110:
                                mensaje = "Más problemas con insert"; break;
                            case 113:
                                mensaje = "Problemas con comentarios"; break;
                            case 156:
                                mensaje = "Error de sintaxis"; break;
                            default:
                                mensaje = err.ToString(); break;

                        }
                       
                    }
                    

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

        private void btnUpdateTbl_Click(object sender, EventArgs e)
        {
            MostrarRegistros();
        }
        public void UpdateContent()
        {
            // Actualizar información en el formulario FrmCRUD_Asignaturas_Ac_Load
            MostrarRegistros();
        }
    }
}
