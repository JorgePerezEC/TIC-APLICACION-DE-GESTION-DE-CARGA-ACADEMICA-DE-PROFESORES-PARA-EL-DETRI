using Directorio___Presentacion.ElementsStyles_Configuration;
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

        private int count = 0;
        private int idDocente;
        private int idSemestreTpDocente;
        private int idTpDocente;
        private int idSemestre;
        private string numHorasExigibles;
        private int numHorasExigiblesQry;
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
            ListarTiposDocentes();
        }

        #region LOAD DATA
        private void MostrarDocentes()
        {
            if (cmbSemestre.SelectedValue != null)
            {
                panelTpDocente.Visible = true;
                panelAdminDocentes.Visible = true;
                string idSemestre = cmbSemestre.SelectedValue.ToString();
                DataTable dtDocentes = objDocente_N.MostrarRegistrosByIdSemestre_Negocio(idSemestre);
                dgvDocenteSemestre.DataSource = dtDocentes;
                dgvDocenteSemestre.Columns[1].HeaderText = "Docente";
                dgvDocenteSemestre.Columns[2].HeaderText = "Activo?";

                DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
                comboBoxColumn.DataPropertyName = "TipoDocente";
                comboBoxColumn.HeaderText = "Tipo de Docente";
                comboBoxColumn.DisplayMember = "Text";
                comboBoxColumn.ValueMember = "Value";

                // Agregar manualmente los valores al combobox
                comboBoxColumn.Items.Add(new { Text = "Profesor Titular a Tiempo Completo", Value = 1 });
                comboBoxColumn.Items.Add(new { Text = "Profesor Titular a Tiempo Parcial", Value = 2 });
                comboBoxColumn.Items.Add(new { Text = "Profesor Ocasional a Tiempo Completo", Value = 3 });
                comboBoxColumn.Items.Add(new { Text = "Profesor Ocasional a Tiempo Parcial", Value = 4 });
                comboBoxColumn.Items.Add(new { Text = "Tecnico Docente a Tiempo Completo", Value = 5 });
                comboBoxColumn.Items.Add(new { Text = "Tecnico Docente a Tiempo Parcial", Value = 6 });
                comboBoxColumn.Items.Add(new { Text = "No asignado", Value = 7 });

                //dgvDocenteSemestre.Columns.Add(comboBoxColumn);
                //// Suscribirse al evento EditingControlShowing
                //dgvDocenteSemestre.EditingControlShowing += dgvDocenteSemestre_EditingControlShowing;

                // Asignar los valores correspondientes a los ComboBox
                AgregarColumnasTipoDocentes();
                for (int i = 0; i < dgvDocenteSemestre.Rows.Count - 1; i++)
                {
                    // Obtener el valor de la columna 3
                    int valorColumna = Convert.ToInt32(dtDocentes.Rows[i][3]);

                    // Establecer los valores de las columnas CheckBox a false
                    for (int j = 4; j < dgvDocenteSemestre.Columns.Count; j++)
                    {
                        dgvDocenteSemestre.Rows[i].Cells[j].Value = false;
                    }

                    // Establecer el valor de la columna CheckBox correspondiente al valor de la columna 3
                    int columnaIndex = valorColumna + 3;
                    if (columnaIndex >= 4 && columnaIndex < dgvDocenteSemestre.Columns.Count)
                    {
                        dgvDocenteSemestre.Rows[i].Cells[columnaIndex].Value = true;
                    }
                }
                //for (int i = 0; i < dgvDocenteSemestre.Rows.Count - 1; i++)
                //{
                //    DataGridViewComboBoxCell comboBoxCell = dgvDocenteSemestre.Rows[i].Cells[4] as DataGridViewComboBoxCell;
                //    int valorColumna = Convert.ToInt32(dtDocentes.Rows[i][3]);

                //    // Obtener el índice del valor correspondiente en el combobox
                //    int index = -1;
                //    for (int j = 0; j < comboBoxCell.Items.Count; j++)
                //    {
                //        dynamic item = comboBoxCell.Items[j];
                //        if (item.Value == valorColumna)
                //        {
                //            index = j;
                //            break;
                //        }
                //    }

                //    // Asignar el valor si se encontró el índice correspondiente
                //    if (index != -1)
                //    {
                //        comboBoxCell.Value = comboBoxCell.Items[index];
                //    }
                //}
                dgvDocenteSemestre.Columns[0].Visible = false;
                dgvDocenteSemestre.Columns[3].Visible = false;
                clsStyles.tableStyle(dgvDocenteSemestre);
                dgvDocenteSemestre.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        //private void MostrarDocentes()
        //{
        //    if (cmbSemestre.SelectedValue != null)
        //    {
        //        panelTpDocente.Visible = true;
        //        panelAdminDocentes.Visible = true;
        //        string idSemestre = cmbSemestre.SelectedValue.ToString();
        //        DataTable dtDocentes = objDocente_N.MostrarRegistrosByIdSemestre_Negocio(idSemestre);
        //        dgvDocenteSemestre.DataSource = dtDocentes;
        //        dgvDocenteSemestre.Columns[1].HeaderText = "Docente";
        //        dgvDocenteSemestre.Columns[2].HeaderText = "Activo?";

        //        DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
        //        comboBoxColumn.DataPropertyName = "TipoDocente"; // Nombre de la columna en el origen de datos
        //        comboBoxColumn.HeaderText = "Tipo de Docente";
        //        comboBoxColumn.DisplayMember = "TipoDocente";
        //        comboBoxColumn.ValueMember = "ID";
        //        comboBoxColumn.DataSource = objTpDocente.MostrarTiposDocentesCmbLn();

        //        dgvDocenteSemestre.Columns.Add(comboBoxColumn);

        //        // Asignar los valores correspondientes a los ComboBox
        //        for (int i = 0; i < dgvDocenteSemestre.Rows.Count -1; i++)
        //        {
        //            DataGridViewComboBoxCell comboBoxCell = dgvDocenteSemestre.Rows[i].Cells[4] as DataGridViewComboBoxCell;
        //            int valorColumna = Convert.ToInt32(dtDocentes.Rows[i][3]);

        //            CN_TipoDocente objTpDocente2 = new CN_TipoDocente();
        //            comboBoxCell.DataSource = objTpDocente2.MostrarTiposDocentesCmbLn();
        //            comboBoxCell.DisplayMember = "TipoDocente";
        //            comboBoxCell.ValueMember = "ID";
        //            comboBoxCell.Value = valorColumna;
        //        }

        //        dgvDocenteSemestre.Columns[0].Visible = false;
        //        dgvDocenteSemestre.Columns[3].Visible = false;
        //        clsStyles.tableStyle(dgvDocenteSemestre);
        //        dgvDocenteSemestre.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        //    }
        //}



        private void ListarSemestres()
        {
            cmbSemestre.SelectedIndexChanged -= cmbSemestre_SelectedIndexChanged;
            cmbSemestre.DisplayMember = "Código";
            cmbSemestre.ValueMember = "ID";
            cmbSemestre.DataSource = objSemestre_N.MostrarSemestres();
            cmbSemestre.SelectedIndex = -1;
            cmbSemestre.SelectedIndexChanged += cmbSemestre_SelectedIndexChanged;
        }
        private void ListarTiposDocentes()
        {
            CN_TipoDocente objTpDocenteL = new CN_TipoDocente();
            DataTable dtTipoDocentes = objTpDocenteL.MostrarTiposDocentesLn();

            foreach (DataRow row in dtTipoDocentes.Rows)
            {
                if (row[1].ToString() == "Profesor Titular a Tiempo Completo")
                {
                    txtH_TTC.Text = row[2].ToString();
                }
                else if (row[1].ToString() == "Profesor Titular a Tiempo Parcial")
                {
                    txtH_TTP.Text = row[2].ToString();
                }
                else if (row[1].ToString() == "Profesor Ocasional a Tiempo Completo")
                {
                    txtH_OTC.Text = row[2].ToString();
                }
                else if (row[1].ToString() == "Profesor Ocasional a Tiempo Parcial")
                {
                    txtH_OTP.Text = row[2].ToString();
                }
                else if (row[1].ToString() == "Tecnico Docente a Tiempo Completo")
                {
                    txtH_TC.Text = row[2].ToString();
                }
                else if (row[1].ToString() == "Tecnico Docente a Tiempo Parcial")
                {
                    txtH_TP.Text = row[2].ToString();
                }
            }
            
        }
        #endregion

        private void cmbSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDocentes();
        }

        private void AgregarColumnasTipoDocentes()
        {
            DataGridViewCheckBoxColumn columnaTTC = new DataGridViewCheckBoxColumn();
            columnaTTC.HeaderText = "Titular a Tiempo Completo";
            columnaTTC.Name = "TTC";
            columnaTTC.TrueValue = true;
            columnaTTC.FalseValue = false;
            columnaTTC.Width = 10;
            dgvDocenteSemestre.Columns.Add(columnaTTC);

            DataGridViewCheckBoxColumn columnaTTP = new DataGridViewCheckBoxColumn();
            columnaTTP.HeaderText = "Titular a Tiempo Parcial";
            columnaTTP.Name = "TTP";
            columnaTTP.TrueValue = true;
            columnaTTP.FalseValue = false;
            dgvDocenteSemestre.Columns.Add(columnaTTP);

            DataGridViewCheckBoxColumn columnaOTC = new DataGridViewCheckBoxColumn();
            columnaOTC.HeaderText = "Ocasional a Tiempo Completo";
            columnaOTC.Name = "OTC";
            columnaOTC.TrueValue = true;
            columnaOTC.FalseValue = false;
            dgvDocenteSemestre.Columns.Add(columnaOTC);

            DataGridViewCheckBoxColumn columnaOTP = new DataGridViewCheckBoxColumn();
            columnaOTP.HeaderText = "Ocasional a Tiempo parcial";
            columnaOTP.Name = "OTP";
            columnaOTP.TrueValue = true;
            columnaOTP.FalseValue = false;
            dgvDocenteSemestre.Columns.Add(columnaOTP);

            DataGridViewCheckBoxColumn columnaTC = new DataGridViewCheckBoxColumn();
            columnaTC.HeaderText = "Tecnico Docente a Tiempo Completo";
            columnaTC.Name = "TC";
            columnaTC.TrueValue = true;
            columnaTC.FalseValue = false;
            dgvDocenteSemestre.Columns.Add(columnaTC);

            DataGridViewCheckBoxColumn columnaTP = new DataGridViewCheckBoxColumn();
            columnaTP.HeaderText = "Tecnico Docente a Tiempo Parcial";
            columnaTP.Name = "TP";
            columnaTP.TrueValue = true;
            columnaTP.FalseValue = false;
            //columnaTP.Width = 70;
            dgvDocenteSemestre.Columns.Add(columnaTP);

            DataGridViewCheckBoxColumn columnaNA = new DataGridViewCheckBoxColumn();
            columnaNA.HeaderText = "No Asignado";
            columnaNA.Name = "NA";
            columnaNA.TrueValue = true;
            columnaNA.FalseValue = false;
            //columnaTP.Width = 70;
            dgvDocenteSemestre.Columns.Add(columnaNA);
        }

        private void dgvDocenteSemestre_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //DataGridView dgv = sender as DataGridView;
            //if (dgv.CurrentCell is DataGridViewComboBoxCell)
            //{
            //    ComboBox comboBox = e.Control as ComboBox;
            //    if (comboBox != null)
            //    {
            //        comboBox.DropDown += ComboBox_DropDown;
            //    }
            //}
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DroppedDown = true;
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }

        }
        //private void ComboBox_DropDown(object sender, EventArgs e)
        //{
        //    ComboBox comboBox = sender as ComboBox;
        //    if (comboBox != null)
        //    {
        //        comboBox.DropDown -= ComboBox_DropDown;
        //        comboBox.DroppedDown = true;
        //    }
        //}

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
                    //MessageBox.Show(cmbSemestre.SelectedValue.ToString() + " " + dgvDocenteSemestre.Rows[e.RowIndex].Cells[0].Value.ToString() + " " + (!habilitado).ToString());
                    //objSemestre_Neg.CreateOrUpdateSemestreDocente_Negocio(cmbSemestre.SelectedValue.ToString(), dgvDocenteSemestre.Rows[e.RowIndex].Cells[0].Value.ToString(), (!habilitado).ToString());
                    if ((bool)checkBoxCell.EditedFormattedValue)
                    {
                        MessageBox.Show("Se ha habilitado el docente: " + nombreDocente);
                    }
                    else
                    {
                        MessageBox.Show("Se ha deshabilitado el docente: " + nombreDocente);
                    }
                }
            }
            else if (e.ColumnIndex >= 4 && e.ColumnIndex <= 10 && e.RowIndex >= 0)
            {
                SetSingleCheckBoxValue(e.RowIndex, e.ColumnIndex);
            }
        }

        private void dgvDocenteSemestre_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0 && e.ColumnIndex >= 4 && e.ColumnIndex <= 10)
            //{
            //    SetSingleCheckBoxValue(e.RowIndex, e.ColumnIndex);
            //}
        }

        private void SetSingleCheckBoxValue(int rowIndex, int selectedColumnIndex)
        {
            for (int columnIndex = 4; columnIndex < 10; columnIndex++)
            {
                if (columnIndex == selectedColumnIndex)
                {
                    dgvDocenteSemestre.Rows[rowIndex].Cells[columnIndex].Value = true;
                }
                else
                {
                    dgvDocenteSemestre.Rows[rowIndex].Cells[columnIndex].Value = false;
                }
            }
        }

    }
}
