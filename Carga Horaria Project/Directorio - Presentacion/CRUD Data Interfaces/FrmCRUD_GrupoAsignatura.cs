using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Logica;
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
    public partial class FrmCRUD_GrupoAsignatura : Form
    {
        private ClsStyles clsStyles = new ClsStyles();

        private string? idAsignatura = null;
        private string? idGrupo = null;
        private string? NombreGR = null;
        private bool Editar = false;
        CN_GrAsignatura objetoCNegocio = new CN_GrAsignatura();
        public FrmCRUD_GrupoAsignatura()
        {
            InitializeComponent();
        }

        private void FrmCRUD_GrupoAsignatura_Load(object sender, EventArgs e)
        {
            ListarAsignaturas();
            MostrarAllGrs();
            clsStyles.tableStyle(dgLstRegistros);
        }
        #region Load Data
        private void ListarAsignaturas()
        {
            CN_Asignatura objetoCNegocio = new CN_Asignatura();
            cmbAsignaturas.DataSource = objetoCNegocio.MostrarAsignaturas();
            cmbAsignaturas.DisplayMember = "Nombre de la Asignatura";
            cmbAsignaturas.ValueMember = "ID";
        }
        private void MostrarAllGrs()
        {
            CN_GrAsignatura objetoCNegocio = new CN_GrAsignatura();
            dgLstRegistros.DataSource = objetoCNegocio.MostrarGrAsignatura();
        }
        #endregion

        #region Clic Events

        private void btnCloseWin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            panelCreate.Visible = true;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstRegistros.Rows.Count > 0)
                {
                    panelCreate.Visible = true;
                    Editar = true;
                    idGrupo = dgLstRegistros.CurrentRow.Cells[0].Value.ToString()!;
                    cmbAsignaturas.Text = dgLstRegistros.CurrentRow.Cells[1].Value.ToString()!;
                    cmbGR.Text = dgLstRegistros.CurrentRow.Cells[2].Value.ToString()!;
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee editar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo actualizar el GR seleccionado. Motivo: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstRegistros.Rows.Count > 0)
                {
                    idGrupo = dgLstRegistros.CurrentRow.Cells[0].Value.ToString()!;
                    MessageBox.Show(idGrupo);
                    objetoCNegocio.DeleteGruposNeg(idGrupo);
                    MessageBox.Show("Grupo de asignatura eliminado correctamente");
                    MostrarAllGrs();
                    //ClearTxtBox();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee eliminar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo eliminar la Carrera seleccionada. Motivo: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    int cmbValue = Convert.ToInt32(cmbAsignaturas.SelectedValue);
                    objetoCNegocio.CreateGruposNeg(cmbValue.ToString(), cmbGR.Text);
                    MessageBox.Show("GR insertadado correctamente"+cmbGR.Text);
                    MostrarAllGrs();
                    //ClearTxtBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepción: No se pudo registrar el Docente. Motivo: " + ex.Message);
                }

            }
            if (Editar == true)
            {
                try
                {
                    int cmbValue = Convert.ToInt32(cmbAsignaturas.SelectedValue);
                    objetoCNegocio.UpdateGruposNeg(idGrupo, cmbValue.ToString(), cmbGR.Text);
                    MessageBox.Show("GR actualizado correctamente");
                    MostrarAllGrs();
                    Editar = false;
                    //ClearTxtBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            panelCreate.Visible = false;
        }

        #endregion
    }
}
