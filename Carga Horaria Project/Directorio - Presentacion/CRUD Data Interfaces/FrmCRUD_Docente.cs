using Directorio___Presentacion.ElementsStyles_Configuration;
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
    public partial class FrmCRUD_Docente : Form
    {
        private CN_Docente objetoCNegocio = new CN_Docente();
        private ClsStyles clsStyles = new ClsStyles();

        private string? idDocente = null;
        private string? idDepartamento = null;
        private bool Editar = false;
        private string nameCarrera;
        private string codigoCarrera;
        private string pensum;
        private string estado;
        public FrmCRUD_Docente()
        {
            InitializeComponent();
        }

        private void FrmCRUD_Docente_Load(object sender, EventArgs e)
        {
            MostrarDocentes();
            ListarDepartamentos();
            clsStyles.tableStyle(dgLstRegistros);
        }
        private void MostrarDocentes()
        {
            CN_Docente objetoCNegocio = new CN_Docente();
            dgLstRegistros.DataSource = objetoCNegocio.MostrarDocentes();
        }
        private void ListarDepartamentos()
        {
            CN_Departamento objetoCNegDepa = new CN_Departamento();
            cmbDepartamentos.DataSource = objetoCNegDepa.MostrarDepartamentos();
            cmbDepartamentos.DisplayMember = "Nombre del Departamento";
            cmbDepartamentos.ValueMember = "ID";
        }
        #region Clicks events
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (panelCreate.Visible)
            {
                panelCreate.Visible = false;
            }
            else
            {
                panelCreate.Visible = true;
            }
        }

        private void btnCloseWin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    int cmbValue = Convert.ToInt32(cmbDepartamentos.SelectedValue);
                    objetoCNegocio.CreateDocenteNeg(cmbValue.ToString(), txtPNombre.Text, txtSNombre.Text, txtPApellido.Text, txtSApellido.Text, txtTitulo.Text);
                    MessageBox.Show("Docente agregado correctamente");
                    MostrarDocentes();
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
                    int cmbValue = Convert.ToInt32(cmbDepartamentos.SelectedValue);
                    objetoCNegocio.UpdateDocenteNeg(idDocente, cmbValue.ToString(), txtPNombre.Text, txtSNombre.Text, txtPApellido.Text, txtSApellido.Text, txtTitulo.Text);
                    MessageBox.Show("Docente actualizado correctamente");
                    MostrarDocentes();
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstRegistros.Rows.Count > 0)
                {
                    panelCreate.Visible = true;
                    Editar = true;
                    string[] names = dgLstRegistros.CurrentRow.Cells[2].Value.ToString().Split(' ');
                    string[] lastnames = dgLstRegistros.CurrentRow.Cells[3].Value.ToString().Split(' ');
                    idDocente = dgLstRegistros.CurrentRow.Cells[0].Value.ToString()!;
                    cmbDepartamentos.Text = dgLstRegistros.CurrentRow.Cells[1].Value.ToString()!;
                    txtPNombre.Text = names[0] ;
                    txtSNombre.Text = names[1];
                    txtPApellido.Text = lastnames[0];
                    txtSApellido.Text = lastnames[1];
                    txtTitulo.Text = dgLstRegistros.CurrentRow.Cells[4].Value.ToString();
                    
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee editar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo actualizar el Docente seleccionado. Motivo: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstRegistros.Rows.Count > 0)
                {
                    idDocente = dgLstRegistros.CurrentRow.Cells[0].Value.ToString()!;
                    objetoCNegocio.DeleteDocenteNeg(idDocente);
                    MessageBox.Show("Carrera eliminada correctamente");
                    MostrarDocentes();
                    //ClearTxtBox();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee eliminar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo eliminar el Docente seleccionado. Motivo: " + ex.Message);
            }
        }
        #endregion

        private void cmbDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
