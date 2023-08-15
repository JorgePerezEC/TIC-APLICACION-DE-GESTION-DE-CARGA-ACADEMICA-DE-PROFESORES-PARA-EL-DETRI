using Directorio___Presentacion.AcademicLoads_Interfaces.Sub_Frms;
using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Logica;
using OxyPlot;
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
    public partial class CRUD_Docencia_Ac_Load : Form
    {
        private FrmCUActividad_AL childActFrm;
        private FrmCreate_AcademicLoad _frmAcademicLoad;
        private CRUD_Docencia_Ac_Load _frmCRUD_Docencia;

        private int idAcLoadLocal;
        private int countBtns = 0;
        private int countBtnsD = 0;
        private bool Editar = false;
        private static int idActividadCarga;
        private static string ActividadName;
        private static string HoraSemanalActividad;
        private static string HoraTotalActividad;
        public static string ActividadTypeD = "D11";
        public static string ActividadTypeF = "F11";
        private CN_CargaHoraria objetoCNegocio = new CN_CargaHoraria();
        ClsStyles tableStyle = new ClsStyles();
        public CRUD_Docencia_Ac_Load(int idAcLoad)
        {
            InitializeComponent();
            
            tableStyle.tableStyle(dgLstRegistrosD11);
            tableStyle.tableStyle(dgLstRegistrosF11);
            idAcLoadLocal = idAcLoad;
            
        }

        private void CRUD_Docencia_Ac_Load_Load(object sender, EventArgs e)
        {
           
            MostrarRegistrosD11();
            MostrarRegistrosF11();
        }
        private void MostrarRegistrosD11()
        {
            CN_CargaHoraria objetoCNegocio = new CN_CargaHoraria();
            dgLstRegistrosD11.DataSource = null;
            dgLstRegistrosD11.DataSource = objetoCNegocio.LoadActividadesD11_Negocio(idAcLoadLocal.ToString());
            dgLstRegistrosD11.Columns[0].Visible = false;
            //dgLstRegistrosD11.Columns[3].Visible = false;

            if (countBtnsD < 1)
            {
                countBtnsD++;
                AddBtnsIntoDataGridViewD11();
                dgLstRegistrosD11.AutoGenerateColumns = false;
            }
        }
        private void MostrarRegistrosF11()
        {
            CN_CargaHoraria objetoCNegocio = new CN_CargaHoraria();
            dgLstRegistrosF11.DataSource = objetoCNegocio.LoadActividadesF11_Negocio(idAcLoadLocal.ToString());
            dgLstRegistrosF11.Columns[0].Visible = false;
            dgLstRegistrosF11.Columns[2].Visible = false;
            if (countBtns < 1)
            {
                countBtns++;
                AddBtnsIntoDataGridViewF11();
                dgLstRegistrosF11.AutoGenerateColumns = false;
            }
        }

        private void btnAddActividadD11_Click(object sender, EventArgs e)
        {
            FrmCUActividad_AL frmD11 = new FrmCUActividad_AL(ActividadTypeD, idAcLoadLocal, Editar);
            frmD11.ShowDialog();
        }
        private void btnAddActividadF11_Click(object sender, EventArgs e)
        {
            FrmCUActividad_AL frmF11 = new FrmCUActividad_AL(ActividadTypeF, idAcLoadLocal, Editar);
            frmF11.ShowDialog();
        }

        public List<string> GetArgumentosToEdit()
        {
            List<string> list = new List<string>();
            list.Add(ActividadName);
            list.Add(HoraSemanalActividad);
            list.Add(idActividadCarga.ToString());
            list.Add(HoraTotalActividad);
            return list;
        }

        #region Buttons Actions in DataGrid
        private void AddBtnsIntoDataGridViewD11()
        {
            //Image as button
            DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
            btnEdit.HeaderText = "EDITAR";
            btnEdit.Tag = true;
            btnEdit.Image = new Bitmap(Properties.Resources.boton_editar, new Size(40, 40));
            btnEdit.ToolTipText = "Editar registro";
            dgLstRegistrosD11.Columns.Add(btnEdit);

            DataGridViewImageColumn btnConfirmDelete = new DataGridViewImageColumn();
            btnConfirmDelete.HeaderText = "ELIMINAR";
            btnConfirmDelete.Tag = true;
            btnConfirmDelete.Image = new Bitmap(Properties.Resources.delete, new Size(40, 40));
            btnConfirmDelete.ToolTipText = "Eliminar registro";
            dgLstRegistrosD11.Columns.Add(btnConfirmDelete);
        }
        private void AddBtnsIntoDataGridViewF11()
        {
            //Image as button
            DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
            btnEdit.HeaderText = "EDITAR";
            btnEdit.Tag = true;
            btnEdit.Image = new Bitmap(Properties.Resources.boton_editar, new Size(40, 40));
            btnEdit.ToolTipText = "Editar registro";
            dgLstRegistrosF11.Columns.Add(btnEdit);

            DataGridViewImageColumn btnConfirmDelete = new DataGridViewImageColumn();
            btnConfirmDelete.HeaderText = "ELIMINAR";
            btnConfirmDelete.Tag = true;
            btnConfirmDelete.Image = new Bitmap(Properties.Resources.delete, new Size(40, 40));
            btnConfirmDelete.ToolTipText = "Eliminar registro";
            dgLstRegistrosF11.Columns.Add(btnConfirmDelete);
        }
        

        private void dgLstRegistrosD11_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0) //Editar
            {
                Editar = true;
                idActividadCarga = Convert.ToInt32(dgLstRegistrosD11.Rows[e.RowIndex].Cells["ID"].Value);
                FrmCUActividad_AL frm = new FrmCUActividad_AL(ActividadTypeD, idAcLoadLocal, Editar);
                ActividadName = dgLstRegistrosD11.Rows[e.RowIndex].Cells[1].Value.ToString();
                HoraSemanalActividad = dgLstRegistrosD11.Rows[e.RowIndex].Cells[2].Value.ToString();
                HoraTotalActividad = dgLstRegistrosD11.Rows[e.RowIndex].Cells[3].Value.ToString();
                frm.ShowDialog();
                Editar = false;
            }
            else if (e.ColumnIndex == 5 && e.RowIndex >= 0) //Eliminar
            {
                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Obtener el ID del registro que se va a eliminar
                    int id = Convert.ToInt32(dgLstRegistrosD11.Rows[e.RowIndex].Cells["ID"].Value);
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
                    dgLstRegistrosD11.Rows.RemoveAt(e.RowIndex);
                    //MostrarRegistrosD11();
                    UpdateContent();
                    FrmCreate_AcademicLoad frmAcademicLoad = Application.OpenForms["FrmCreate_AcademicLoad"] as FrmCreate_AcademicLoad;
                    if (frmAcademicLoad != null)
                    {
                        frmAcademicLoad.UpdateContent();
                    }
                }
            }
        }

        private void dgLstRegistrosF11_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0) //Editar
            {
                Editar = true;
                idActividadCarga = Convert.ToInt32(dgLstRegistrosF11.Rows[e.RowIndex].Cells["ID"].Value);
                FrmCUActividad_AL frm = new FrmCUActividad_AL(ActividadTypeF, idAcLoadLocal, Editar);
                ActividadName = dgLstRegistrosF11.Rows[e.RowIndex].Cells[1].Value.ToString();
                HoraSemanalActividad = dgLstRegistrosF11.Rows[e.RowIndex].Cells[2].Value.ToString();
                HoraTotalActividad = dgLstRegistrosF11.Rows[e.RowIndex].Cells[3].Value.ToString();
                frm.ShowDialog();
                Editar = false;
            }
            else if (e.ColumnIndex == 5 && e.RowIndex >= 0) //Eliminar
            {
                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Obtener el ID del registro que se va a eliminar
                    int id = Convert.ToInt32(dgLstRegistrosF11.Rows[e.RowIndex].Cells["ID"].Value);
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
                    dgLstRegistrosF11.Rows.RemoveAt(e.RowIndex);
                    MostrarRegistrosF11();
                }
            }
        }
        #endregion

        //private void btnUpdateTbl_Click(object sender, EventArgs e)
        //{
        //    MostrarRegistrosD11();
        //    MostrarRegistrosF11();
        //}
        public void UpdateContent()
        {
            // Actualizar información en el formulario FrmCRUD_Asignaturas_Ac_Load
            MostrarRegistrosD11();
            MostrarRegistrosF11();
        }
    }
}
