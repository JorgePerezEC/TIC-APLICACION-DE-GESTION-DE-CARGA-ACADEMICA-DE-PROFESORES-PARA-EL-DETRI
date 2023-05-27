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
    public partial class FrmCRUD_HorarioAsignatura : Form
    {
        private CN_HorarioAsignatura objetoCNegocio = new CN_HorarioAsignatura();
        private ClsStyles clsStyles = new ClsStyles();

        private string? idAsignatura = null;
        private string? idHorario = null;
        private bool Editar = false;
        public FrmCRUD_HorarioAsignatura()
        {
            InitializeComponent();
            FormatosDateTimePickers();
            clsStyles.tableStyle(dgLstRegistros);

        }

        private void FrmCRUD_HorarioAsignatura_Load(object sender, EventArgs e)
        {
            ListarAsignaturas();
            MostrarHorarios();
        }

        private void FormatosDateTimePickers()
        {
            dtHoraInicio.CustomFormat = "HH:mm";
            dtHoraInicio.Text = "09:00";
            dtHoraInicio.ShowUpDown = true;
            dtHoraFin.CustomFormat = "HH:mm";
            dtHoraFin.Text = "11:00";
            dtHoraFin.ShowUpDown = true;
        }

        #region Methods to load data
        private void MostrarHorarios()
        {
            CN_HorarioAsignatura objetoCNegocio = new CN_HorarioAsignatura();
            dgLstRegistros.DataSource = objetoCNegocio.MostrarGrAsignatura();
        }
        private void ListarAsignaturas()
        {
            CN_Asignatura objetoCNegocioAsignatura = new CN_Asignatura();
            cmbAsignaturas.DataSource = objetoCNegocioAsignatura.MostrarAsignaturasWithGroups_CNegocio();
            cmbAsignaturas.DisplayMember = "Asignatura";
            cmbAsignaturas.ValueMember = "ID";
        }
        private void ListarGruposAsignatura()
        {
            if (cmbAsignaturas.SelectedIndex > -1)
            {
                lblGrupos.Visible = true;
                cmbGR.Visible = true;
                CN_GrAsignatura objetoGrNegocio= new CN_GrAsignatura();
                cmbGR.DataSource = objetoGrNegocio.MostrarGruposPorAsignatura_Negocio(cmbAsignaturas.Text);
                cmbGR.DisplayMember = "Grupos";
                cmbGR.ValueMember = "ID";
            }
        }
        #endregion

        #region Clics Events
        private void btnCloseWin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            panelCreate.Visible = true;
            lblGrupos.Visible = false;
            cmbGR.Visible = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstRegistros.Rows.Count > 0)
                {
                    panelCreate.Visible = true;
                    Editar = true;
                    idHorario = dgLstRegistros.CurrentRow.Cells[0].Value.ToString()!;
                    cmbAsignaturas.Text = dgLstRegistros.CurrentRow.Cells[1].Value.ToString()!;
                    cmbGR.Text = dgLstRegistros.CurrentRow.Cells[2].Value.ToString();
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
                    idHorario = dgLstRegistros.CurrentRow.Cells[0].Value.ToString()!;
                    objetoCNegocio.DeleteHorariosNegocio(idHorario);
                    MessageBox.Show("Horario eliminada correctamente");
                    MostrarHorarios();
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
                    int cmbValueAsig = Convert.ToInt32(cmbAsignaturas.SelectedValue);
                    int cmbValueGrupo = Convert.ToInt32(cmbGR.SelectedValue);
                    objetoCNegocio.CreateHorariosNegocio(cmbValueAsig.ToString(), cmbValueGrupo.ToString(),dtHoraInicio.Text, dtHoraFin.Text, cmbDay.Text);
                    MessageBox.Show("Valor Asign: "+ cmbValueAsig.ToString()+"ValorGrupo: "+ cmbValueGrupo.ToString());
                    MessageBox.Show("Horario agregado correctamente");
                    MostrarHorarios();
                    //ClearTxtBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepción: No se pudo registrar el Horario. Motivo: " + ex.Message);
                }

            }
            if (Editar == true)
            {
                try
                {
                    int cmbValueAsig = Convert.ToInt32(cmbAsignaturas.SelectedValue);
                    int cmbValueGrupo = Convert.ToInt32(cmbGR.SelectedValue);
                    objetoCNegocio.UpdateHorariosNegocio(idHorario, cmbValueAsig.ToString(), cmbValueGrupo.ToString(), dtHoraInicio.Text, dtHoraFin.Text, cmbDay.Text);
                    MessageBox.Show("Carrera actualizada correctamente");
                    MostrarHorarios();
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

        private void cmbAsignaturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarGruposAsignatura();
        }

        private void dtHoraInicio_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
