using Directorio___Presentacion.AcademicLoads_Interfaces;
using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Datos;
using Directorio_Logica;
using ScottPlot.Palettes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Directorio___Presentacion.CRUD_Data_Interfaces
{
    public partial class FrmCRUD_Proyecto : Form
    {
        #region VARIABLES SECTION
        private DataTable dtData;
        private bool openPanelCreate = false;
        private bool Editar = false;
        private string idProyecto;
        private string codigoProy;
        private string nombreProyecto;
        private string tipoProyecto;
        private string urlProyecto;
        private string pesupuesto;
        private int countBtns = 0;

        private ClsStyles clsStyles = new ClsStyles();
        CN_Proyecto objetoCNegocio = new CN_Proyecto();

        #endregion
        public FrmCRUD_Proyecto()
        {
            InitializeComponent();
            clsStyles.tableStyle(dgLstRegistros);
        }

        private void FrmCRUD_Proyecto_Load(object sender, EventArgs e)
        {
            MostrarData();
        }

        private void MostrarData()
        {
            CN_Proyecto objetoCNegocio = new CN_Proyecto();
            dtData = objetoCNegocio.MostrarRegistros();
            dgLstRegistros.DataSource = dtData;
            dgLstRegistros.Columns[0].Visible = false;
            dgLstRegistros.Columns[7].Visible = false;
            if (countBtns < 1)
            {
                countBtns++;
                AddBtnsIntoDataGridView();
                dgLstRegistros.AutoGenerateColumns = false;
            }
            dgLstRegistros.ClearSelection();

        }

        private void AddBtnsIntoDataGridView()
        {
            //Image as button
            DataGridViewImageColumn btnViewPdf = new DataGridViewImageColumn();
            btnViewPdf.HeaderText = "AVAL FILE";
            btnViewPdf.Tag = true;
            btnViewPdf.Image = new Bitmap(Properties.Resources.archivo_pdf, new Size(40, 40));
            btnViewPdf.ToolTipText = "Visualizar AVAL";
            dgLstRegistros.Columns.Add(btnViewPdf);
        }


        #region BUTTONS SECTION
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = string.Empty;
            btnGuardar.Text = "ACTUALIZAR";
            try
            {
                if (dgLstRegistros.Rows.Count > 0)
                {
                    panelCreate.Visible = true;
                    Editar = true;
                    idProyecto = dgLstRegistros.CurrentRow.Cells[0].Value.ToString()!;
                    txtCode.Text = dgLstRegistros.CurrentRow.Cells[1].Value.ToString()!;
                    txtNameProyecto.Text = dgLstRegistros.CurrentRow.Cells[2].Value.ToString()!;
                    dtFechaInicio.Text = dgLstRegistros.CurrentRow.Cells[3].Value.ToString()!;
                    dtFechaFin.Text = dgLstRegistros.CurrentRow.Cells[4].Value.ToString()!;
                    txtPresupuesto.Text = dgLstRegistros.CurrentRow.Cells[5].Value.ToString()!;
                    txtType.Text = dgLstRegistros.CurrentRow.Cells[6].Value.ToString()!;
                    txtURL.Text = dgLstRegistros.CurrentRow.Cells[7].Value.ToString()!;
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee editar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo actualizar el Docente seleccionado. Motivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool datosCorrectos = validarCampos();
            txtFiltro.Text = string.Empty;
            if (!datosCorrectos) { return; }
            if (!Editar)
            {
                try
                {
                    decimal presupuesto;

                    if (decimal.TryParse(txtPresupuesto.Text, out presupuesto))
                    {
                        objetoCNegocio.CreateProyecto_Negocio(txtCode.Text, txtNameProyecto.Text,
                            dtFechaInicio.Value.ToString("yyyy-MM-dd"), dtFechaFin.Value.ToString("yyyy-MM-dd"),
                            presupuesto, txtType.Text, txtURL.Text);
                    }
                    MessageBox.Show("Proyecto insertadado correctamente", "PROYECTO REGISTRADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarData();
                    clearInfoFrm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: No se pudo registrar el Proyecto. Motivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }else
            {
                try
                {
                    decimal presupuesto;
                    if (decimal.TryParse(txtPresupuesto.Text, out presupuesto))
                    {
                        objetoCNegocio.UpdateProyecto_Negocio(idProyecto,txtCode.Text, txtNameProyecto.Text,
                            dtFechaInicio.Value.ToString("yyyy-MM-dd"), dtFechaFin.Value.ToString("yyyy-MM-dd"),
                            presupuesto, txtType.Text, txtURL.Text);
                    }
                    MessageBox.Show("Proyecto actualizado correctamente", "PROYECTO ACTUALIZADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarData();
                    clearInfoFrm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            openPanelCreate = false;
            panelCreate.Visible = openPanelCreate;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = string.Empty;
            try
            {
                if (dgLstRegistros.Rows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string idProyecto = dgLstRegistros.CurrentRow.Cells[0].Value.ToString()!;
                        objetoCNegocio.DeleteProyecto_Negocio(idProyecto);
                        MostrarData();
                        MessageBox.Show("Proyecto eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo eliminar el Docente seleccionado. Motivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCloseWin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnGuardar.Text = "Guardar";
            openPanelCreate = !openPanelCreate;
            panelCreate.Visible = openPanelCreate;
            clearInfoFrm();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelCreate.Visible = false;
            openPanelCreate = false;
            clearInfoFrm();
        }
        #endregion

        private void clearInfoFrm()
        {
            txtCode.Text = string.Empty;
            txtType.Text = string.Empty;
            txtURL.Text = string.Empty;
            txtNameProyecto.Text = string.Empty;
            DateTime fechaPorDefecto = new DateTime(2023, 9, 1);
            dtFechaInicio.Value = fechaPorDefecto;
            dtFechaFin.Value = fechaPorDefecto;
            txtPresupuesto.Text = string.Empty;
        }

        private bool validarCampos()
        {
            bool resul = false;
            if (txtCode.Text == string.Empty || txtNameProyecto.Text == string.Empty || txtType.Text == string.Empty || txtURL.Text == string.Empty )
            {
                MessageBox.Show("Debe completar todos los campos de texto para completar el registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else resul = true;

            // Validar la URL
            if (!Uri.TryCreate(txtURL.Text, UriKind.Absolute, out Uri resultUri) || !(resultUri.Scheme == Uri.UriSchemeHttp || resultUri.Scheme == Uri.UriSchemeHttps))
            {
                MessageBox.Show("La URL ingresada no es válida. Por favor, ingrese una URL válida (ejemplo: http://www.ejemplo.com).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resul = false;
            }
            else resul = true;

            //Validar money
            if (!decimal.TryParse(txtPresupuesto.Text, out decimal valorDolar) || decimal.Round(valorDolar, 2) != valorDolar)
            {
                MessageBox.Show("Ingrese un valor de dinero válido en dólares.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resul = false;
            }
            else resul = true;

            return resul;
        }

        #region FILTER DATA
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.Trim();
            DataTable dataTableFiltrado = FiltrarDataTable(dtData, filtro);
            dgLstRegistros.DataSource = dataTableFiltrado;
        }
        private DataTable FiltrarDataTable(DataTable dataTable, string filtro)
        {
            DataTable dataTableFiltrado = dataTable.Clone();
            foreach (DataRow row in dataTable.Rows)
            {
                if (row.ItemArray.Any(field => field.ToString().IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0))
                {
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

        #endregion

        private void dgLstRegistros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int lastColumnIndex = dgLstRegistros.Columns.Count - 1;

            if (e.ColumnIndex == lastColumnIndex  && e.RowIndex >= 0)
            {
                urlProyecto = dgLstRegistros.Rows[e.RowIndex].Cells[7].Value.ToString();
                // Abrir la URL en el navegador predeterminado
                Process.Start(new ProcessStartInfo
                {
                    FileName = urlProyecto,
                    UseShellExecute = true
                });
            }
        }
    }
}
