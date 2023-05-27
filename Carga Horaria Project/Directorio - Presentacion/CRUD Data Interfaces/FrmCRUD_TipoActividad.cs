using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Logica;
using Directorio_LogicaNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace Directorio___Presentacion.CRUD_Interfaces
{
    public partial class FrmCRUD_TipoActividad : Form
    {
        private CN_TipoActividad objetoCNegocio = new CN_TipoActividad();
        private ClsStyles clsStyles = new ClsStyles();

        private string? idTpActiv = null;
        private bool Editar = false;
        private string nameTpActiv;
        private string descripcionTpActiv;
        public FrmCRUD_TipoActividad()
        {
            InitializeComponent();
            clsStyles.tableStyle(dgLstTpActividades);
        }

        private void FrmCRUD_TipoActividad_Load(object sender, EventArgs e)
        {
            MostrarTiposActividades();
        }
        private void MostrarTiposActividades()
        {
            CN_TipoActividad objetoCNegocio = new CN_TipoActividad();
            dgLstTpActividades.DataSource = objetoCNegocio.MostrarTiposActividadesLn();
        }
        #region Clicks Events
        private void btnCloseWin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewTpActividad_Click(object sender, EventArgs e)
        {
            panelNewTpActividad.Visible = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    objetoCNegocio.CreateTiposActividadN(txtNameTpAct.Text, txtDescripcion.Text);
                    MessageBox.Show("Tipo de actividad insertado correctamente");
                    MostrarTiposActividades();
                    //ClearTxtBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepción: No se pudo registrar el Tipo de Actividad. Motivo: " + ex.Message);
                }

            }
            if (Editar == true)
            {
                try
                {
                    objetoCNegocio.UpdateDepartamentoN(idTpActiv, txtNameTpAct.Text, txtDescripcion.Text);
                    MessageBox.Show("Tipo de Actividad actualizado correctamente");
                    MostrarTiposActividades();
                    Editar = false;
                    //ClearTxtBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            panelNewTpActividad.Visible = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstTpActividades.Rows.Count > 0)
                {
                    panelNewTpActividad.Visible = true;
                    Editar = true;
                    txtNameTpAct.Text = dgLstTpActividades.CurrentRow.Cells[1].Value.ToString();
                    txtDescripcion.Text = dgLstTpActividades.CurrentRow.Cells[2].Value.ToString();
                    idTpActiv = dgLstTpActividades.CurrentRow.Cells[0].Value.ToString()!;
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee editar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo actualizar el Tipo de Actividad seleccionado. Motivo: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstTpActividades.Rows.Count > 0)
                {
                    nameTpActiv = dgLstTpActividades.CurrentRow.Cells[1].Value.ToString()!;
                    descripcionTpActiv = dgLstTpActividades.CurrentRow.Cells[2].Value.ToString()!;
                    idTpActiv = dgLstTpActividades.CurrentRow.Cells[0].Value.ToString()!;
                    objetoCNegocio.DeleteDepartamentoN(idTpActiv, nameTpActiv, descripcionTpActiv);
                    MessageBox.Show("Tipo de Actividad eliminado correctamente");
                    MostrarTiposActividades();
                    //ClearTxtBox();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee eliminar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo eliminar el Tipo de Actividad seleccionado. Motivo: " + ex.Message);
            }
        }
        #endregion
    }
}
