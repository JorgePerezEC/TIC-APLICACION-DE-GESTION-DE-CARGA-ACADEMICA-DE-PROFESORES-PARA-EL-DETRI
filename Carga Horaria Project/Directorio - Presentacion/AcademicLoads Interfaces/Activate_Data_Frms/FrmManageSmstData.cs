﻿using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Directorio___Presentacion.AcademicLoads_Interfaces.Activate_Data_Frms
{
    public partial class FrmManageSmstData : Form
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
        public FrmManageSmstData()
        {
            InitializeComponent();
        }

        private void FrmManageSmstData_Load(object sender, EventArgs e)
        {
            panelTpDocente.Visible = false;
            panelAdminDocentes.Visible = false;
            ListarSemestres();
        }

        #region LOAD DATA
        private void LoadHorasTipoDocentes(string idSemestre)
        {
            if (cmbSemestre.SelectedValue != null)
            {
                txtH_TTC.Text = objTpDocente.GetTipoDocenteHoras_Negocio(idSemestre, "1").ToString();
                txtH_TTP.Text = objTpDocente.GetTipoDocenteHoras_Negocio(idSemestre, "2").ToString();
                txtH_OTC.Text = objTpDocente.GetTipoDocenteHoras_Negocio(idSemestre, "3").ToString();
                txtH_OTP.Text = objTpDocente.GetTipoDocenteHoras_Negocio(idSemestre, "4").ToString();
                txtH_TC.Text  = objTpDocente.GetTipoDocenteHoras_Negocio(idSemestre, "5").ToString();
                txtH_TP.Text  = objTpDocente.GetTipoDocenteHoras_Negocio(idSemestre, "6").ToString();
            }
        }
        //private void MostrarDocentes()
        //{
        //    if (cmbSemestre.SelectedValue != null)
        //    {
        //        panelTpDocente.Visible = true;
        //        panelTableContainer.Visible = true;
        //        string idSemestre = cmbSemestre.SelectedValue.ToString();
        //        LoadHorasTipoDocentes(idSemestre);
        //        DataTable dtDocentes = objDocente_N.MostrarRegistrosByIdSemestre_Negocio(idSemestre);
        //        dgvDocenteSemestre.DataSource = dtDocentes;
        //        dgvDocenteSemestre.Columns[1].HeaderText = "Docente";
        //        dgvDocenteSemestre.Columns[2].HeaderText = "Activo?";

        //        // Asignar los valores correspondientes a los ComboBox
        //        AgregarColumnasTipoDocentes();
        //        for (int i = 0; i < dgvDocenteSemestre.Rows.Count - 1; i++)
        //        {
        //            int valorColumna = Convert.ToInt32(dtDocentes.Rows[i][3]);

        //            for (int j = 4; j < dgvDocenteSemestre.Columns.Count; j++)
        //            {
        //                dgvDocenteSemestre.Rows[i].Cells[j].Value = false;
        //            }

        //            int columnaIndex = valorColumna + 3;
        //            if (columnaIndex >= 4 && columnaIndex < dgvDocenteSemestre.Columns.Count)
        //            {
        //                dgvDocenteSemestre.Rows[i].Cells[columnaIndex].Value = true;
        //            }
        //        }
        //        dgvDocenteSemestre.Columns[0].Visible = false;
        //        dgvDocenteSemestre.Columns[3].Visible = false;
        //        clsStyles.tableActivateDocentesStyle(dgvDocenteSemestre);
        //        //dgvDocenteSemestre.ColumnHeadersHeight = 80;
        //        dgvDocenteSemestre.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        //        dgvDocenteSemestre.CellPainting += dgvDocenteSemestre_CellPainting;
        //    }
        //}

        private void MostrarDocentes()
        {
            if (cmbSemestre.SelectedValue != null)
            {
                CN_Docente objDocente_N = new CN_Docente();
                string idSemestre = cmbSemestre.SelectedValue.ToString();
                LimpiarTabla();

                // Cargar el contenido de la tabla
                panelTpDocente.Visible = true;
                panelTableContainer.Visible = true;
                LoadHorasTipoDocentes(idSemestre);
                DataTable dtDocentes = objDocente_N.MostrarRegistrosByIdSemestre_Negocio(idSemestre);
                dgvDocenteSemestre.DataSource = dtDocentes;
                dgvDocenteSemestre.Columns[1].HeaderText = "Docente";
                dgvDocenteSemestre.Columns[2].HeaderText = "Activo?";

                // Asignar los valores correspondientes a los ComboBox
                AgregarColumnasTipoDocentes();
                for (int i = 0; i < dgvDocenteSemestre.Rows.Count - 1; i++)
                {
                    int valorColumna = Convert.ToInt32(dtDocentes.Rows[i][3]);

                    for (int j = 4; j < dgvDocenteSemestre.Columns.Count; j++)
                    {
                        dgvDocenteSemestre.Rows[i].Cells[j].Value = false;
                    }

                    int columnaIndex = valorColumna + 3;
                    if (columnaIndex >= 4 && columnaIndex < dgvDocenteSemestre.Columns.Count)
                    {
                        dgvDocenteSemestre.Rows[i].Cells[columnaIndex].Value = true;
                    }
                }
                dgvDocenteSemestre.Columns[0].Visible = false;
                dgvDocenteSemestre.Columns[3].Visible = false;
                clsStyles.tableActivateDocentesStyle(dgvDocenteSemestre);
                dgvDocenteSemestre.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvDocenteSemestre.CellPainting += dgvDocenteSemestre_CellPainting;

            }
        }

        private void LimpiarTabla()
        {
            dgvDocenteSemestre.DataSource = null;
            dgvDocenteSemestre.Rows.Clear();
            dgvDocenteSemestre.Columns.Clear();
        }


        private void ListarSemestres()
        {
            cmbSemestre.SelectedIndexChanged -= cmbSemestre_SelectedIndexChanged;
            cmbSemestre.DisplayMember = "Código";
            cmbSemestre.ValueMember = "ID";
            cmbSemestre.DataSource = objSemestre_N.MostrarSemestres();
            cmbSemestre.SelectedIndex = -1;
            cmbSemestre.SelectedIndexChanged += cmbSemestre_SelectedIndexChanged;
            txtH_OTC.Enabled = false;
            txtH_OTP.Enabled = false;
            txtH_TC.Enabled = false;
            txtH_TP.Enabled = false;
            txtH_TTC.Enabled = false;
            txtH_TTP.Enabled = false;
            btnGuardar.Text = "Continuar";
        }
        
        #endregion

        private void cmbSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDocentes();
        }

        private void AgregarColumnasTipoDocentes()
        {
            DataGridViewCheckBoxColumn columnaTTC = new DataGridViewCheckBoxColumn();
            columnaTTC.HeaderText = "Titular - Tiempo Completo";
            columnaTTC.Name = "TTC";
            columnaTTC.TrueValue = true;
            columnaTTC.FalseValue = false;
            columnaTTC.Width = 10;
            dgvDocenteSemestre.Columns.Add(columnaTTC);

            DataGridViewCheckBoxColumn columnaTTP = new DataGridViewCheckBoxColumn();
            columnaTTP.HeaderText = "Titular - Tiempo Parcial";
            columnaTTP.Name = "TTP";
            columnaTTP.TrueValue = true;
            columnaTTP.FalseValue = false;
            dgvDocenteSemestre.Columns.Add(columnaTTP);

            DataGridViewCheckBoxColumn columnaOTC = new DataGridViewCheckBoxColumn();
            columnaOTC.HeaderText = "Ocasional - Tiempo Completo";
            columnaOTC.Name = "OTC";
            columnaOTC.TrueValue = true;
            columnaOTC.FalseValue = false;
            columnaOTC.Width = 40;
            dgvDocenteSemestre.Columns.Add(columnaOTC);

            DataGridViewCheckBoxColumn columnaOTP = new DataGridViewCheckBoxColumn();
            columnaOTP.HeaderText = "Ocasional - Tiempo parcial";
            columnaOTP.Name = "OTP";
            columnaOTP.TrueValue = true;
            columnaOTP.FalseValue = false;
            dgvDocenteSemestre.Columns.Add(columnaOTP);

            DataGridViewCheckBoxColumn columnaTC = new DataGridViewCheckBoxColumn();
            columnaTC.HeaderText = "Tecnico Docente - Tiempo Completo";
            columnaTC.Name = "TC";
            columnaTC.TrueValue = true;
            columnaTC.FalseValue = false;
            dgvDocenteSemestre.Columns.Add(columnaTC);

            DataGridViewCheckBoxColumn columnaTP = new DataGridViewCheckBoxColumn();
            columnaTP.HeaderText = "Tecnico Docente - Tiempo Parcial";
            columnaTP.Name = "TP";
            columnaTP.TrueValue = true;
            columnaTP.FalseValue = false;
            columnaTP.Width = 40;
            dgvDocenteSemestre.Columns.Add(columnaTP);

            DataGridViewCheckBoxColumn columnaNA = new DataGridViewCheckBoxColumn();
            columnaNA.HeaderText = "No Asignado";
            columnaNA.Name = "NA";
            columnaNA.TrueValue = true;
            columnaNA.FalseValue = false;
            columnaNA.Width = 30;
            dgvDocenteSemestre.Columns.Add(columnaNA);

            dgvDocenteSemestre.CellPainting += dgvDocenteSemestre_CellPainting;
        }

        private void dgvDocenteSemestre_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDocenteSemestre.Columns[2].Index && e.RowIndex >= 0 && dgvDocenteSemestre.Rows[e.RowIndex].Cells[2] is DataGridViewCheckBoxCell checkBoxCell)
            {
                if (checkBoxCell != null)
                {

                    bool habilitado = (bool)checkBoxCell.EditedFormattedValue;
                    checkBoxCell.Value = !habilitado;

                    string nombreDocente = dgvDocenteSemestre.Rows[e.RowIndex].Cells[1].Value.ToString();

                    objSemestre_Neg = new CN_Semestre();
                    
                    if ((bool)checkBoxCell.EditedFormattedValue)
                    {
                        objSemestre_Neg.CreateOrUpdateSemestreDocente_Negocio(cmbSemestre.SelectedValue.ToString(), dgvDocenteSemestre.Rows[e.RowIndex].Cells[0].Value.ToString(), "1", txtH_TTC.Text, (!habilitado).ToString());
                        MostrarDocentes();
                    }
                    else
                    {
                        //MessageBox.Show("Se ha deshabilitado el docente: " + nombreDocente);
                        objSemestre_Neg.CreateOrUpdateSemestreDocente_Negocio(cmbSemestre.SelectedValue.ToString(), dgvDocenteSemestre.Rows[e.RowIndex].Cells[0].Value.ToString(), "7", "0", (!habilitado).ToString());
                        MostrarDocentes();
                    }
                }
            }
            else if (e.ColumnIndex >= 4 && e.ColumnIndex <= 10 && e.RowIndex >= 0)
            {
                SetSingleCheckBoxValue(e.RowIndex, e.ColumnIndex);
            }
        }

        private void SetSingleCheckBoxValue(int rowIndex, int selectedColumnIndex)
        {
            for (int columnIndex = 4; columnIndex <= 10; columnIndex++)
            {
                if (columnIndex == selectedColumnIndex)
                {
                    dgvDocenteSemestre.Rows[rowIndex].Cells[columnIndex].Value = true;
                    string columnName = dgvDocenteSemestre.Columns[columnIndex].Name;
                    if (columnName == "TTC") idTipoDocente = 1;
                    else if (columnName == "TTP") idTipoDocente = 2;
                    else if (columnName == "OTC") idTipoDocente = 3;
                    else if (columnName == "OTP") idTipoDocente = 4;
                    else if (columnName == "TC") idTipoDocente = 5;
                    else if (columnName == "TP") idTipoDocente = 6;
                    string controlName = "txtH_" + columnName;
                    bool habilitado = Convert.ToBoolean(dgvDocenteSemestre.Rows[rowIndex].Cells[2].Value);

                    Control[] foundControls = this.Controls.Find(controlName, true);

                    if (foundControls.Length > 0 && foundControls[0] is TextBox textBox)
                    {
                        string controlValue = textBox.Text;
                        //MessageBox.Show(controlValue);
                        //EDITA PARA OBTENER LOS MISMOS DATOS
                        objSemestre_Neg = new CN_Semestre();

                        //MessageBox.Show(dgvDocenteSemestre.Rows[rowIndex].Cells[0].Value.ToString() + " " + selectedColumnIndex.ToString() + " " + cmbSemestre.SelectedValue.ToString() + " " + habilitado.ToString());
                        objSemestre_Neg.CreateOrUpdateSemestreDocente_Negocio(cmbSemestre.SelectedValue.ToString(), dgvDocenteSemestre.Rows[rowIndex].Cells[0].Value.ToString(), idTipoDocente.ToString(), controlValue, (habilitado).ToString());
                    }

                }
                else
                {
                    dgvDocenteSemestre.Rows[rowIndex].Cells[columnIndex].Value = false;
                }
            }
        }

        private void dgvDocenteSemestre_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && dgvDocenteSemestre.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                e.PaintBackground(e.CellBounds, true);

                var checkboxSize = 20; // Tamaño deseado para el checkbox

                var checkboxBounds = new Rectangle(
                    e.CellBounds.X + (e.CellBounds.Width - checkboxSize) / 2,
                    e.CellBounds.Y + (e.CellBounds.Height - checkboxSize) / 2,
                    checkboxSize, checkboxSize);

                e.PaintContent(checkboxBounds);

                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            panelAdminDocentes.Visible = true;
            panelAdminDocentes.Enabled = true;
            txtH_OTC.Enabled = false;
            txtH_OTP.Enabled = false;
            txtH_TC.Enabled = false;
            txtH_TP.Enabled = false;
            txtH_TTC.Enabled = false;
            txtH_TTP.Enabled = false;
            btnGuardar.Visible = false;

            if (Editar)
            {
                objTpDocente.AddOrUpdateTipoDocente_Semstre_Negocio("1",cmbSemestre.SelectedValue.ToString(),txtH_TTC.Text);
                objTpDocente.AddOrUpdateTipoDocente_Semstre_Negocio("2", cmbSemestre.SelectedValue.ToString(), txtH_TTP.Text);
                objTpDocente.AddOrUpdateTipoDocente_Semstre_Negocio("3", cmbSemestre.SelectedValue.ToString(), txtH_OTC.Text);
                objTpDocente.AddOrUpdateTipoDocente_Semstre_Negocio("4", cmbSemestre.SelectedValue.ToString(), txtH_OTP.Text);
                objTpDocente.AddOrUpdateTipoDocente_Semstre_Negocio("5", cmbSemestre.SelectedValue.ToString(), txtH_TC.Text);
                objTpDocente.AddOrUpdateTipoDocente_Semstre_Negocio("6", cmbSemestre.SelectedValue.ToString(), txtH_TP.Text);
                Editar = false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnGuardar.Text = "GUARDAR";
            Editar = true;
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
            panelAdminDocentes.Enabled = false;
            txtH_OTC.Enabled= true;
            txtH_OTP.Enabled= true;
            txtH_TC.Enabled= true;
            txtH_TP.Enabled= true;
            txtH_TTC.Enabled= true;
            txtH_TTP.Enabled= true;
        }

        private void txtH_TTP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LoadHorasTipoDocentes(cmbSemestre.SelectedValue.ToString());
            btnCancelar.Visible = false;
            txtH_OTC.Enabled = true;
            txtH_OTP.Enabled = true;
            txtH_TC.Enabled = true;
            txtH_TP.Enabled = true;
            txtH_TTC.Enabled = true;
            txtH_TTP.Enabled = true;
            panelAdminDocentes.Enabled = true;

        }
    }
}
