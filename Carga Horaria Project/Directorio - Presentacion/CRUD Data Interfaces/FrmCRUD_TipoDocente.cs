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
    public partial class FrmCRUD_TipoDocente : Form
    {
        private CN_TipoDocente objetoCNegocio = new CN_TipoDocente();
        private ClsStyles clsStyles = new ClsStyles();

        private string? idTpDocente = null;
        private bool Editar = false;
        private string nameTpDocente;
        private string estadoTpDocente;
        public FrmCRUD_TipoDocente()
        {
            InitializeComponent();
            clsStyles.tableStyle(dgLstTpDocentes);
        }

        private void FrmTipoDocente_Load(object sender, EventArgs e)
        {
            MostrarTiposDocentes();

        }
        private void MostrarTiposDocentes()
        {
            CN_TipoDocente objetoCNegocio = new CN_TipoDocente();
            dgLstTpDocentes.DataSource = objetoCNegocio.MostrarTiposDocentesLn();
        }
        #region Clicks Events
        private void btnNew_Click(object sender, EventArgs e)
        {
            panelNewTpActividad.Visible = true;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (Editar == false)
            {
                try
                {
                    objetoCNegocio.CreateTiposDocentesNeg(txtNameTpDoc.Text, txtHorasExigibles.Text);
                    MessageBox.Show("Tipo de docente insertado correctamente");
                    MostrarTiposDocentes();
                    panelNewTpActividad.Visible = false;
                    //ClearTxtBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepción: No se pudo registrar el Tipo de docente. Motivo: " + ex.Message);
                }

            }
            if (Editar == true)
            {
                try
                {
                    objetoCNegocio.UpdateTiposDocentesNeg(idTpDocente, txtNameTpDoc.Text, txtHorasExigibles.Text);
                    MessageBox.Show("Tipo de docente actualizado correctamente");
                    MostrarTiposDocentes();
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
                if (dgLstTpDocentes.Rows.Count > 0)
                {
                    panelNewTpActividad.Visible = true;
                    Editar = true;
                    txtNameTpDoc.Text = dgLstTpDocentes.CurrentRow.Cells[1].Value.ToString();
                    idTpDocente = dgLstTpDocentes.CurrentRow.Cells[0].Value.ToString()!;
                    txtHorasExigibles.Text = dgLstTpDocentes.CurrentRow.Cells[2].Value.ToString()!;
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
                if (dgLstTpDocentes.Rows.Count > 0)
                {
                    idTpDocente = dgLstTpDocentes.CurrentRow.Cells[0].Value.ToString()!;
                    objetoCNegocio.DeleteTiposDocentesNeg(idTpDocente);
                    MessageBox.Show("Tipo de Actividad eliminado correctamente");
                    MostrarTiposDocentes();
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

        private void btnCloseWin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


    }
}
