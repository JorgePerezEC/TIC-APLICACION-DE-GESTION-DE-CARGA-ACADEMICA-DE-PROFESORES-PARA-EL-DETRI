using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Entidades;
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
    public partial class FrmCRUD_Carrera : Form
    {
        private CN_Carrera objetoCNegocio = new CN_Carrera();
        private ClsStyles clsStyles = new ClsStyles();

        private string? idCarrera = null;
        private string? idDepartamento = null;
        private bool Editar = false;
        private string nameCarrera;
        private string codigoCarrera;
        private string pensum;
        private string estado;
        public FrmCRUD_Carrera()
        {
            InitializeComponent();
        }

        private void FrmCRUD_Carrera_Load(object sender, EventArgs e)
        {
            MostrarCarreras();
            ListarDepartamentos();
            clsStyles.tableStyle(dgLstRegistros);
        }
        private void MostrarCarreras()
        {
            CN_Carrera objetoCNegocio = new CN_Carrera();
            dgLstRegistros.DataSource = objetoCNegocio.MostrarCarreras();
        }
        private void ListarDepartamentos()
        {
            CN_Carrera objetoCNegocio = new CN_Carrera();
            cmbDepartamentos.DataSource = objetoCNegocio.MostrarDepartamentosNeg();
            cmbDepartamentos.DisplayMember = "Name";
            cmbDepartamentos.ValueMember= "ID";
        }
        
        #region Clicks Events
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    int cmbValue = Convert.ToInt32(cmbDepartamentos.SelectedValue);
                    objetoCNegocio.CreateCarreraNeg(cmbValue.ToString(), txtNameCarreer.Text, txtCodigo.Text, txtPensum.Text, ckboxEstado.Checked.ToString());
                    MessageBox.Show("Carrera insertadada correctamente");
                    MostrarCarreras();
                    //ClearTxtBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepción: No se pudo registrar la Carrera. Motivo: " + ex.Message);
                }

            }
            if (Editar == true)
            {
                try
                {
                    int cmbValue = Convert.ToInt32(cmbDepartamentos.SelectedValue);
                    objetoCNegocio.UpdateCarreraNeg(idCarrera, cmbValue.ToString(), txtNameCarreer.Text, txtCodigo.Text, txtPensum.Text, ckboxEstado.Checked.ToString());
                    MessageBox.Show("Carrera actualizada correctamente");
                    MostrarCarreras();
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
                    idCarrera = dgLstRegistros.CurrentRow.Cells[0].Value.ToString()!;
                    cmbDepartamentos.Text = dgLstRegistros.CurrentRow.Cells[1].Value.ToString()!;
                    txtNameCarreer.Text = dgLstRegistros.CurrentRow.Cells[2].Value.ToString();
                    txtCodigo.Text = dgLstRegistros.CurrentRow.Cells[3].Value.ToString();
                    txtPensum.Text = dgLstRegistros.CurrentRow.Cells[4].Value.ToString();
                    ckboxEstado.Text = dgLstRegistros.CurrentRow.Cells[5].Value.ToString();
                    //cmbValue = dgLstRegistros.CurrentRow.Cells[5].Value.ToString() ;
                    
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
                if (dgLstRegistros.Rows.Count > 0)
                {
                    idCarrera = dgLstRegistros.CurrentRow.Cells[0].Value.ToString()!;
                    objetoCNegocio.DeleteCarreraNeg(idCarrera);
                    MessageBox.Show("Carrera eliminada correctamente");
                    MostrarCarreras();
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

        private void btnCloseWin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
