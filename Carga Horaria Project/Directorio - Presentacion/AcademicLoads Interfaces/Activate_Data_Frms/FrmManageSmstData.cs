using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Logica;
using MaterialSkin;
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

using MaterialSkin;
using MaterialSkin.Controls;

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
        private DataTable dtDocentes;
        private int idTipoDocente = 7;
        private int numHorasDocenteTiempoCompleto = 0;
        private int numHorasDeshabilitado = 0;
        private DataTable dtHorasExigibles = new DataTable();

        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

        // Establecer el esquema de color
        //materialSkinManager.ColorScheme = new ColorScheme(Primary.Teal400, Primary.Teal500, Primary.Teal500, Accent.Teal200, TextShade.WHITE);

        #endregion
        public FrmManageSmstData()
        {
            InitializeComponent();
            clsStyles.tableEditStyle(dgvAdminHorasTipoDocente);
        }

        private void FrmManageSmstData_Load(object sender, EventArgs e)
        {
            panelTpDocente.Visible = false;
            //panelAdminDocentes.Visible = false;
            ListarSemestres();
            
        }

        #region LOAD DATA
        private void LoadHorasTipoDocentes(string idSemestre)
        {
            if (cmbSemestre.SelectedValue != null)
            {
                CN_TipoDocente objTipoDocente_N = new CN_TipoDocente();
                
                dtHorasExigibles = objTipoDocente_N.GetTipoDocenteHorasAll_Negocio(idSemestre);
                if (dtHorasExigibles.Rows.Count > 0)
                {
                    dgvAdminHorasTipoDocente.DataSource = dtHorasExigibles;

                    dgvAdminHorasTipoDocente.Columns[0].Visible = false;
                    dgvAdminHorasTipoDocente.Columns[1].ReadOnly = true;
                    dgvAdminHorasTipoDocente.Columns[2].ReadOnly = true;

                    DataRow[] rows = dtHorasExigibles.Select("ID = 1"); // Filtrar las filas donde ID es igual a 1

                    if (rows.Length > 0)
                    {
                        object valorHorasTTC = rows[0]["# HORAS"];

                        if (valorHorasTTC != null)
                        {
                            numHorasDocenteTiempoCompleto = Convert.ToInt32(valorHorasTTC);
                        }
                    }

                    DataRow[] rows2 = dtHorasExigibles.Select("ID = 7"); // Filtrar las filas donde ID es igual a 7

                    if (rows2.Length > 0)
                    {
                        object valorHorasDeshabilitado = rows2[0]["# HORAS"];

                        if (valorHorasDeshabilitado != null)
                        {
                            numHorasDeshabilitado = Convert.ToInt32(valorHorasDeshabilitado);
                        }
                    }

                }
            }
        }

        private void MostrarDocentes()
        {
            if (cmbSemestre.SelectedValue != null)
            {
                CN_Docente objDocente_N = new CN_Docente();
                string idSemestre = cmbSemestre.SelectedValue.ToString();
                panelAdminDocentes.Visible = true;
                LimpiarTabla();

                // Cargar el contenido de la tabla
                panelTpDocente.Visible = true;
                panelTableContainer.Visible = true;
                LoadHorasTipoDocentes(idSemestre);
                dtDocentes = objDocente_N.MostrarRegistrosByIdSemestre_Negocio(idSemestre);
                dgvDocenteSemestre.DataSource = dtDocentes;
                dgvDocenteSemestre.Columns[1].HeaderText = "Docente";
                dgvDocenteSemestre.Columns[2].HeaderText = "Activo?";
                dgvDocenteSemestre.Columns[1].Frozen = true;
                dgvDocenteSemestre.Columns[2].Frozen = true;

                // Asignar los valores correspondientes a los ComboBox
                AgregarColumnasTipoDocentesDT();
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
                dgvDocenteSemestre.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }
        }


        private void LimpiarTabla()
        {
            dgvDocenteSemestre.DataSource = null;
            dgvDocenteSemestre.Rows.Clear();
            dgvDocenteSemestre.Columns.Clear();

            dgvAdminHorasTipoDocente.DataSource = null;
            dgvAdminHorasTipoDocente.Rows.Clear();
            dgvAdminHorasTipoDocente.Columns.Clear();
        }


        private void ListarSemestres()
        {
            cmbSemestre.SelectedIndexChanged -= cmbSemestre_SelectedIndexChanged;
            cmbSemestre.DisplayMember = "Código";
            cmbSemestre.ValueMember = "ID";
            cmbSemestre.DataSource = objSemestre_N.MostrarSemestres();
            cmbSemestre.SelectedIndex = -1;
            cmbSemestre.SelectedIndexChanged += cmbSemestre_SelectedIndexChanged;
            btnGuardar.Text = "Continuar";
        }
        
        #endregion

        private void cmbSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDocentes();
        }

        private void AgregarColumnasTipoDocentesDT()
        {
            foreach (DataRow row in dtHorasExigibles.Rows)
            {
                string nombreColumna = row["TIPO DE DOCENTE"].ToString();
                string nombreCorto = ObtenerNombreCorto(nombreColumna); // Función que obtiene el nombre corto según el tipo

                DataGridViewCheckBoxColumn columna = new DataGridViewCheckBoxColumn();
                columna.HeaderText = nombreColumna;
                columna.Name = nombreCorto;
                columna.TrueValue = true;
                columna.FalseValue = false;
                dgvDocenteSemestre.Columns.Add(columna);

                foreach (DataGridViewRow dgvRow in dgvDocenteSemestre.Rows)
                {
                    if (dgvRow.Cells[columna.Index] is DataGridViewCheckBoxCell cell)
                    {
                        cell.Style.BackColor = MaterialSkinManager.Instance.ColorScheme.PrimaryColor;
                        cell.Style.ForeColor = MaterialSkinManager.Instance.ColorScheme.TextColor;
                    }
                }
            }

        }
        private string ObtenerNombreCorto(string nombreCompleto)
        {
            string nombreCorto = new string(nombreCompleto.Where(c => !char.IsWhiteSpace(c)).ToArray()).ToUpper();
            return nombreCorto;
        }

        
        private void dgvDocenteSemestre_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int totalColumns = dgvDocenteSemestre.Columns.Count;
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
                        objSemestre_Neg.CreateOrUpdateSemestreDocente_Negocio(cmbSemestre.SelectedValue.ToString(), dgvDocenteSemestre.Rows[e.RowIndex].Cells[0].Value.ToString(), "1", numHorasDocenteTiempoCompleto.ToString(), (!habilitado).ToString());
                        MostrarDocentes();
                    }
                    else
                    {
                        objSemestre_Neg.CreateOrUpdateSemestreDocente_Negocio(cmbSemestre.SelectedValue.ToString(), dgvDocenteSemestre.Rows[e.RowIndex].Cells[0].Value.ToString(), "7", numHorasDeshabilitado.ToString(), (!habilitado).ToString());
                        MostrarDocentes();
                    }
                }
            }
            else if (e.ColumnIndex >= 4 && e.ColumnIndex <= totalColumns && e.RowIndex >= 0)
            {
                SetSingleCheckBoxValueDT(e.RowIndex, e.ColumnIndex);
            }
        }

        private void SetSingleCheckBoxValueDT(int rowIndex, int selectedColumnIndex)
        {
            int totalColumns = dgvDocenteSemestre.Columns.Count;
            
            for (int columnIndex = 4; columnIndex <= totalColumns -1 ; columnIndex++)
            {
                bool isChecked = columnIndex == selectedColumnIndex;
                dgvDocenteSemestre.Rows[rowIndex].Cells[columnIndex].Value = isChecked;

                if (isChecked)
                {
                    string columnName = dgvDocenteSemestre.Columns[columnIndex].HeaderText;
                    int idTipoDocente = -1; 
                    int numHoras = -1;

                    DataTable dtInfo = new DataTable();
                    dtInfo = objTpDocente.GetInfoTipoDocenteByName_Negocio(cmbSemestre.SelectedValue.ToString(), columnName);
                   
                    bool habilitado = Convert.ToBoolean(dgvDocenteSemestre.Rows[rowIndex].Cells[2].Value);

                    if (dtInfo.Rows.Count > 0)
                    {
                        numHoras = Convert.ToInt32(dtInfo.Rows[0][1]);
                        idTipoDocente = Convert.ToInt32(dtInfo.Rows[0][0]);
                        objSemestre_Neg = new CN_Semestre();
                        //MessageBox.Show(cmbSemestre.SelectedValue.ToString()+ " rowIndex"+ rowIndex.ToString()+" dgvDocenteSemestre" + dgvDocenteSemestre.Rows[rowIndex].Cells[0].Value.ToString() + " " + idTipoDocente.ToString() + " numHoras" + numHoras.ToString() + " habilitado" + habilitado.ToString());
                        objSemestre_Neg.CreateOrUpdateSemestreDocente_Negocio(cmbSemestre.SelectedValue.ToString(), dgvDocenteSemestre.Rows[rowIndex].Cells[0].Value.ToString(), idTipoDocente.ToString(), numHoras.ToString(), habilitado.ToString());

                    }
                    dtInfo.Clear();
                }
            }
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            dgvAdminHorasTipoDocente.ClearSelection();
            panelAdminDocentes.Visible = true;
            panelAdminDocentes.Enabled = true;
            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
            dgvAdminHorasTipoDocente.Enabled = false;
            

            if (Editar)
            {
                foreach (DataGridViewRow row in dgvAdminHorasTipoDocente.Rows)
                {
                    string idTipoDocente = row.Cells[0].Value.ToString();
                    string idSemestre = cmbSemestre.SelectedValue.ToString();
                    string horas = row.Cells[2].Value.ToString();

                    objTpDocente.AddOrUpdateTipoDocente_Semstre_Negocio(idTipoDocente, idSemestre, horas);
                }
                Editar = false;
            }
            LoadHorasTipoDocentes(cmbSemestre.SelectedValue.ToString());
            dgvAdminHorasTipoDocente.ClearSelection();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnGuardar.Text = "GUARDAR";
            Editar = true;
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
            panelAdminDocentes.Enabled = false;
            dgvAdminHorasTipoDocente.Enabled = true;

            HabilitarEdicionHorasExigibles(true);
        }

        private void HabilitarEdicionHorasExigibles(bool habilitar)
        {
            dgvAdminHorasTipoDocente.Columns[2].ReadOnly = !habilitar; 

            dgvAdminHorasTipoDocente.RefreshEdit();
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
            btnGuardar.Visible = false;
            dgvAdminHorasTipoDocente.Enabled = false;
            dgvAdminHorasTipoDocente.ClearSelection();
            panelAdminDocentes.Enabled = true;

        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            //string filtro = txtFiltro.Text.Trim(); 

            //DataTable dataTableFiltrado = FiltrarDataTable(dtDocentes, filtro);
            ////Quiero filtrar el contenido del datagridview dgvDocenteSemestre

            //// Asignar el DataTable filtrado al DataSource del DataGridView
            //dgvDocenteSemestre.DataSource = dataTableFiltrado;

            string filtro = txtFiltro.Text.Trim();

            foreach (DataGridViewRow row in dgvDocenteSemestre.Rows)
            {
                bool mostrarFila = false;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        mostrarFila = true;
                        break;
                    }
                }

                row.Visible = mostrarFila;
            }
        }
        private DataTable FiltrarDataTable(DataTable dataTable, string filtro)
        {
            // Crear un nuevo DataTable para almacenar los datos filtrados
            DataTable dataTableFiltrado = dataTable.Clone();

            // Filtrar los datos del DataTable en función del texto ingresado
            foreach (DataRow row in dataTable.Rows)
            {
                if (row.ItemArray.Any(field => field.ToString().IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    // Copiar la fila filtrada al nuevo DataTable
                    dataTableFiltrado.ImportRow(row);
                }
            }

            return dataTableFiltrado;
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            char tecla = char.ToUpper(e.KeyChar);

            e.KeyChar = tecla;
            e.Handled = false;
        }

        private void dgvAdminHorasTipoDocente_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2) // Validar solo la columna 2
            {
                string newValue = e.FormattedValue.ToString();

                if (string.IsNullOrWhiteSpace(newValue))
                {
                    e.Cancel = true;
                    dgvDocenteSemestre.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Debe ingresar un valor.";
                }
                else if (!int.TryParse(newValue, out int intValue))
                {
                    e.Cancel = true;
                    dgvDocenteSemestre.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Debe ingresar un valor entero válido.";
                }
                else
                {
                    dgvDocenteSemestre.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "";
                }
            }
        }

        private void dgvAdminHorasTipoDocente_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvDocenteSemestre.Rows[e.RowIndex].ErrorText = ""; // Limpia el mensaje de error
        }
    }
}
