using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Datos;
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

namespace Directorio___Presentacion.CRUD_Interfaces
{
    public partial class FrmCRUD_Semestre : Form
    {
        private CN_Semestre objetoCNegocio = new CN_Semestre();
        private ClsStyles clsStyles = new ClsStyles();

        private string? idSemestre = null;
        private bool Editar = false;
        //private string? nameDepartamento = null;
        //private string? emailDepartamento = null;
        public FrmCRUD_Semestre()
        {
            InitializeComponent();
            clsStyles.tableStyle(dgLstSemestres);
        }
        private void FrmCRUD_Semestre_Load(object sender, EventArgs e)
        {
            MostrarSemestres();
        }
        private void MostrarSemestres()
        {
            DAL_Semestre objetoCNegocio = new DAL_Semestre();
            dgLstSemestres.DataSource = objetoCNegocio.MostrarRegistros();
        }

        #region Clicks Events
        private void btnNewSemestre_Click_1(object sender, EventArgs e)
        {
            Editar = false;
            if (panelNewSemestre.Visible)
            {
                panelNewSemestre.Visible = false;
            }
            else
            {
                panelNewSemestre.Visible = true;
            }
        }

        private void btnCloseWin_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            if (Editar == false)
            {
                try
                {
                    objetoCNegocio.CreateSemestreNegocio(txtCodigo.Text, txtYear.Text, dtFechaInicio.Value.ToString("yyyy-MM-dd"),
                    dtFechaFin.Value.ToString("yyyy-MM-dd"), cboxSemanasClase.Text, cboxSemanasTotales.Text, ckboxEstado.Checked.ToString());
                    MessageBox.Show("Semestre insertado correctamente");
                    MostrarSemestres();
                    ClearTxtBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepción: No se pudo registrar el Departamento. Motivo: " + ex.Message);
                }

            }
            if (Editar == true)
            {
                try
                {
                    objetoCNegocio.UpdateSemestreNegocio(idSemestre, txtCodigo.Text, txtYear.Text, dtFechaInicio.Value.ToString("yyyy-MM-dd"),
                    dtFechaFin.Value.ToString("yyyy-MM-dd"), cboxSemanasClase.Text, cboxSemanasTotales.Text, ckboxEstado.Checked.ToString());
                    MessageBox.Show("Semestre actualizado correctamente");
                    panelNewSemestre.Visible = false;
                    MostrarSemestres();
                    Editar = false;
                    ClearTxtBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstSemestres.Rows.Count > 0)
                {
                    panelNewSemestre.Visible = true;
                    Editar = true;
                    idSemestre = dgLstSemestres.CurrentRow.Cells[0].Value.ToString()!;
                    txtCodigo.Text = dgLstSemestres.CurrentRow.Cells[1].Value.ToString()!;
                    txtYear.Text = dgLstSemestres.CurrentRow.Cells[2].Value.ToString()!;
                    dtFechaInicio.Text = dgLstSemestres.CurrentRow.Cells[3].Value.ToString()!;
                    dtFechaFin.Text = dgLstSemestres.CurrentRow.Cells[4].Value.ToString()!;
                    cboxSemanasClase.Text = dgLstSemestres.CurrentRow.Cells[5].Value.ToString()!;
                    cboxSemanasTotales.Text = dgLstSemestres.CurrentRow.Cells[6].Value.ToString()!;
                    ckboxEstado.Text = dgLstSemestres.CurrentRow.Cells[7].Value.ToString()!;
                }
                else 
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee editar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo actualizar el Departamento seleccionado. Motivo: " + ex.Message);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstSemestres.Rows.Count > 0)
                {
                    idSemestre = dgLstSemestres.CurrentRow.Cells[0].Value.ToString()!;
                    objetoCNegocio.DeleteSemestreNegocio(idSemestre);
                    MessageBox.Show("Semestre eliminado correctamente");
                    MostrarSemestres();
                    ClearTxtBox();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee eliminar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo eliminar el Departamento seleccionado. Motivo: " + ex.Message);
            }
        }

        #endregion

        #region Validation Methods
        private void ClearTxtBox()
        {
            txtCodigo.Text = string.Empty;
            txtYear.Text = string.Empty;
            ckboxEstado.Checked = false;
            cboxSemanasClase.Text = string.Empty;
            cboxSemanasTotales.Text = string.Empty;
            dtFechaFin.Text = string.Empty;
            dtFechaInicio.Text = string.Empty;
        }
        #endregion

    }
}
