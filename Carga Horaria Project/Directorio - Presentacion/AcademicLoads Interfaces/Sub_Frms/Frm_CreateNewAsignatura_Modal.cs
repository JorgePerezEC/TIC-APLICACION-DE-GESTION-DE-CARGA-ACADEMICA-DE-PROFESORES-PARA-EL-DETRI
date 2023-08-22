using Directorio_Entidades;
using Directorio_Logica;
using MaterialSkin;
using System.Data;
using System.Drawing;
using System.Globalization;

namespace Directorio___Presentacion.AcademicLoads_Interfaces.Sub_Frms
{

    public partial class Frm_CreateNewAsignatura_Modal : Form
    {
        MaterialSkinManager TManager = MaterialSkinManager.Instance;
        CN_GrAsignatura objetoCNegocio = new CN_GrAsignatura();
        CN_Asignatura objCNegocioAsignatura = new CN_Asignatura();
        private string IdAsignatura = "";
        private string idSemestreLocal;
        private int idGrCreated;
        private int horasSemanalesAsignatura = 0;
        private int horasSemanalesDB = 0;
        private bool GRisNew;

        public Frm_CreateNewAsignatura_Modal(string asignaturaId, int idSemestre)
        {
            InitializeComponent();
            idSemestreLocal = Convert.ToString(idSemestre);
            TManager.Theme = MaterialSkinManager.Themes.LIGHT;
            TManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.Purple400, Accent.LightBlue700, TextShade.WHITE);
            IdAsignatura = asignaturaId;
        }

        private void Frm_CreateNewAsignatura_Modal_Load(object sender, EventArgs e)
        {
            FormatosDateTimePickersGral();
            ListarAsignaturas();
            cmbAsignaturas.SelectedValue = Convert.ToInt32(IdAsignatura);
            cmbAsignaturas.Enabled = false;
            //this.KeyPreview = true;
            //int index = cmbAsignaturas.FindStringExact(IdAsignatura);
            //if (index != -1)
            //{
            //}
        }
        private void ListarAsignaturas()
        {
            CN_Asignatura objetoCNegocio = new CN_Asignatura();
            cmbAsignaturas.DataSource = objetoCNegocio.MostrarAsignaturas();
            cmbAsignaturas.DisplayMember = "Nombre de la Asignatura";
            cmbAsignaturas.ValueMember = "ID";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbGR.Text == "")
            {
                MessageBox.Show("Debe ingresar un GR para completar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int cmbValue = Convert.ToInt32(cmbAsignaturas.SelectedValue);
            GRisNew = objetoCNegocio.VerificarGRexistente_Negoco(cmbValue.ToString(), cmbGR.Text);
            //if (!GRisNew)
            //{
            //    MessageBox.Show("GR creado. Agregue ahora un horario para el GR creado.", "GRUPO REGISTRADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show("GR existente, puede modificar el horario a continuación.", "GRUPO EXISTENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            idGrCreated = objetoCNegocio.CreateGruposOutNeg(cmbValue.ToString(), cmbGR.Text);
            if (idGrCreated != -1)
            {
                CN_Docente objDocente = new CN_Docente();
                string docenteName = objDocente.GetDocenteIfHaveAsignInCarga_Negocio(idSemestreLocal, idGrCreated.ToString());
                if (docenteName != "NONE")
                {
                    lblDocente.Text = "Este Grupo de asignatura se encuentra dentro de la Carga Horaria del docente " +docenteName;
                    MessageBox.Show("Este Grupo de asignatura se encuentra dentro de la Carga Horaria del docente " + docenteName+ ". Edite el horario con precaución.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    panelShowDocente.Visible = true;
                }
                else
                {
                    panelShowDocente.Height = 0;
                }
                cmbGR.Enabled = false;
                panelSaveGR.Visible = false;
                panelCreateHorario.Visible = true;
                horasSemanalesDB = objCNegocioAsignatura.GetHorasSemanlAsignatura_Negocio(IdAsignatura);
                lblHorasCorrespondientes.Text = horasSemanalesDB.ToString();
                CN_HorarioAsignatura objetoCNegocio = new CN_HorarioAsignatura();
                DataTable dtHorarios = objetoCNegocio.GetHorariosByAsignaturaGR_Negocio(idSemestreLocal,
                    idGrCreated.ToString());// cmbGR.SelectedValue.ToString());

                if (dtHorarios != null && dtHorarios.Rows.Count > 0)
                {
                    foreach (DataRow row in dtHorarios.Rows)
                    {
                        int idDiaSemana = Convert.ToInt32(row["idDiaSemana"]);
                        string horaInicio = Convert.ToString(row["horaInicio"]);
                        string horaFin = Convert.ToString(row["horaFin"]);

                        DateTime dtInicio = DateTime.ParseExact(horaInicio, "HH:mm:ss", CultureInfo.InvariantCulture);
                        DateTime dtFin = DateTime.ParseExact(horaFin, "HH:mm:ss", CultureInfo.InvariantCulture);



                        // Activa el checkbox correspondiente según el idDiaSemana
                        switch (idDiaSemana)
                        {
                            case 1: // Lunes
                                cbLun.Checked = true;
                                dtLunesI.Text = horaInicio;
                                dtLunesF.Text = horaFin;
                                if (dtInicio.TimeOfDay == dtFin.TimeOfDay)
                                {
                                    cbLun.Checked = false;
                                }
                                break;
                            case 2: // Martes
                                cbMar.Checked = true;
                                dtMartesI.Text = horaInicio;
                                dtMartesF.Text = horaFin;
                                if (dtInicio.TimeOfDay == dtFin.TimeOfDay)
                                {
                                    cbMar.Checked = false;
                                }
                                break;
                            case 3: // Miércoles
                                cbMie.Checked = true;
                                dtMieI.Text = horaInicio;
                                dtMieF.Text = horaFin;
                                if (dtInicio.TimeOfDay == dtFin.TimeOfDay)
                                {
                                    cbMie.Checked = false;
                                }
                                break;
                            case 4: // Jueves
                                cbJue.Checked = true;
                                dtJueI.Text = horaInicio;
                                dtJueF.Text = horaFin;
                                if (dtInicio.TimeOfDay == dtFin.TimeOfDay)
                                {
                                    cbJue.Checked = false;
                                }
                                break;
                            case 5: // Viernes
                                cbVie.Checked = true;
                                dtVieI.Text = horaInicio;
                                dtVieF.Text = horaFin;
                                if (dtInicio.TimeOfDay == dtFin.TimeOfDay)
                                {
                                    cbVie.Checked = false;
                                }
                                break;
                            case 6: // Sábado
                                cbSab.Checked = true;
                                dtSabI.Text = horaInicio;
                                dtSabF.Text = horaFin;
                                if (dtInicio.TimeOfDay == dtFin.TimeOfDay)
                                {
                                    cbSab.Checked = false;
                                }
                                break;
                            case 7: // Domingo
                                cbDom.Checked = true;
                                dtDomI.Text = horaInicio;
                                dtDomF.Text = horaFin;
                                if (dtInicio.TimeOfDay == dtFin.TimeOfDay)
                                {
                                    cbDom.Checked = false;
                                }
                                break;
                        }

                    }

                    dtHorarios.Clear();
                }
                else
                {
                    FormatosDateTimePickersGral();
                }
            }
            else { MessageBox.Show("Ocurrio un error al crear el Horario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_CreateNewAsignatura_Modal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.G)
            {
                btnGuardar.PerformClick();
                e.Handled = true;
            }
        }

        private void cmbGR_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool VerificarHorasSemanales()
        {
            horasSemanalesAsignatura = 0;
            bool horasCoherentes = true;
            // Calcular las horas semanales sumando las diferencias de tiempo para cada día seleccionado
            if (cbLun.Checked)
            {
                TimeSpan diffLunes = dtLunesF.Value - dtLunesI.Value;
                // Verificar si la hora final es mayor a la hora inicial y si son diferentes
                if (diffLunes.TotalHours > 0 && dtLunesF.Value != dtLunesI.Value)
                {
                    horasSemanalesAsignatura += (int)diffLunes.TotalHours;
                }
                else
                {
                    horasCoherentes = false;
                }
            }

            if (cbMar.Checked)
            {
                TimeSpan diffMartes = dtMartesF.Value - dtMartesI.Value;
                if (diffMartes.TotalHours > 0 && dtMartesF.Value != dtMartesI.Value)
                {
                    horasSemanalesAsignatura += (int)diffMartes.TotalHours;
                }
                else
                {
                    horasCoherentes = false;
                }
            }
            if (cbMie.Checked)
            {
                TimeSpan diffMiercoles = dtMieF.Value - dtMieI.Value;
                if (diffMiercoles.TotalHours > 0 && dtMieF.Value != dtMieI.Value)
                {
                    horasSemanalesAsignatura += (int)diffMiercoles.TotalHours;
                }
                else
                {
                    horasCoherentes = false;
                }
            }

            if (cbJue.Checked)
            {
                TimeSpan diffJueves = dtJueF.Value - dtJueI.Value;
                if (diffJueves.TotalHours > 0 && dtJueF.Value != dtJueI.Value)
                {
                    horasSemanalesAsignatura += (int)diffJueves.TotalHours;
                }
                else
                {
                    horasCoherentes = false;
                }
            }

            if (cbVie.Checked)
            {
                TimeSpan diffViernes = dtVieF.Value - dtVieI.Value;
                if (diffViernes.TotalHours > 0 && dtVieF.Value != dtVieI.Value)
                {
                    horasSemanalesAsignatura += (int)diffViernes.TotalHours;
                }
                else
                {
                    horasCoherentes = false;
                }
            }

            if (cbSab.Checked)
            {
                TimeSpan diffSabado = dtSabF.Value - dtSabI.Value;
                if (diffSabado.TotalHours > 0 && dtSabF.Value != dtSabI.Value)
                {
                    horasSemanalesAsignatura += (int)diffSabado.TotalHours;
                }
                else
                {
                    horasCoherentes = false;
                }
            }

            if (cbDom.Checked)
            {
                TimeSpan diffDomingo = dtDomF.Value - dtDomI.Value;
                if (diffDomingo.TotalHours > 0 && dtDomF.Value != dtDomI.Value)
                {
                    horasSemanalesAsignatura += (int)diffDomingo.TotalHours;
                }
                else
                {
                    horasCoherentes = false;
                }
            }
            lblHorasIngresadas.Text = horasSemanalesAsignatura.ToString();
            return horasCoherentes;
        }
        private void btnSaveHorario_Click(object sender, EventArgs e)
        {
            try
            {
                //int cmbValueAsig = Convert.ToInt32(cmbAsignaturas.SelectedValue);
                string cmbValueGrupo = Convert.ToString(idGrCreated);
                bool cumpleHorasSemanales = false;
                bool exito = false;
                bool exito2 = false;
                bool exito3 = false;
                bool exito4 = false;
                bool exito5 = false;
                bool exito6 = false;
                bool exito7 = false;

                bool horaCoherente = VerificarHorasSemanales();

                if (!horaCoherente)
                {
                    MessageBox.Show("Por favor, verifique que las horas que esta tratando de ingresar sean coherentes.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (horasSemanalesAsignatura > 0)
                {
                    CN_HorarioAsignatura objetoCNegocioV = new CN_HorarioAsignatura();
                    cumpleHorasSemanales = objetoCNegocioV.VerificarHorasSemanales_Negocio(cmbValueGrupo, horasSemanalesAsignatura.ToString());
                }


                if (cumpleHorasSemanales)
                {
                    string horaInicioNoMark = "00:00";
                    string horaFinNoMark = "00:00";

                    if (cbLun.Checked)
                    {
                        //MessageBox.Show(cmbSemestre.SelectedValue.ToString() + " " + cmbValueGrupo.ToString() + " " + dtLunesI.Text + " " + dtLunesF.Text + " " + cmbDay.Text);
                        CN_HorarioAsignatura objetoCNegocio = new CN_HorarioAsignatura();
                        exito = objetoCNegocio.CreateHorariosNegocio(idSemestreLocal, cmbValueGrupo, dtLunesI.Text, dtLunesF.Text, "1");
                    }
                    else
                    {
                        CN_HorarioAsignatura objetoCNegocio = new CN_HorarioAsignatura();
                        exito = objetoCNegocio.CreateHorariosNegocio(idSemestreLocal, cmbValueGrupo, horaInicioNoMark, horaFinNoMark, "1");
                    }
                    if (cbMar.Checked)
                    {
                        CN_HorarioAsignatura objetoCNegocio = new CN_HorarioAsignatura();
                        exito2 = objetoCNegocio.CreateHorariosNegocio(idSemestreLocal, cmbValueGrupo, dtMartesI.Text, dtMartesF.Text, "2");
                    }
                    else
                    {
                        CN_HorarioAsignatura objetoCNegocio = new CN_HorarioAsignatura();
                        exito = objetoCNegocio.CreateHorariosNegocio(idSemestreLocal, cmbValueGrupo, horaInicioNoMark, horaFinNoMark, "2");
                    }
                    if (cbMie.Checked)
                    {
                        CN_HorarioAsignatura objetoCNegocio = new CN_HorarioAsignatura();
                        exito3 = objetoCNegocio.CreateHorariosNegocio(idSemestreLocal, cmbValueGrupo, dtMieI.Text, dtMieF.Text, "3");
                    }
                    else
                    {
                        CN_HorarioAsignatura objetoCNegocio = new CN_HorarioAsignatura();
                        exito = objetoCNegocio.CreateHorariosNegocio(idSemestreLocal, cmbValueGrupo, horaInicioNoMark, horaFinNoMark, "3");
                    }
                    if (cbJue.Checked)
                    {
                        CN_HorarioAsignatura objetoCNegocio = new CN_HorarioAsignatura();
                        exito4 = objetoCNegocio.CreateHorariosNegocio(idSemestreLocal, cmbValueGrupo, dtJueI.Text, dtJueF.Text, "4");
                    }
                    else
                    {
                        CN_HorarioAsignatura objetoCNegocio = new CN_HorarioAsignatura();
                        exito = objetoCNegocio.CreateHorariosNegocio(idSemestreLocal, cmbValueGrupo, horaInicioNoMark, horaFinNoMark, "4");
                    }
                    if (cbVie.Checked)
                    {
                        CN_HorarioAsignatura objetoCNegocio = new CN_HorarioAsignatura();
                        exito5 = objetoCNegocio.CreateHorariosNegocio(idSemestreLocal, cmbValueGrupo, dtVieI.Text, dtVieF.Text, "5");
                    }
                    else
                    {
                        CN_HorarioAsignatura objetoCNegocio = new CN_HorarioAsignatura();
                        exito = objetoCNegocio.CreateHorariosNegocio(idSemestreLocal, cmbValueGrupo, horaInicioNoMark, horaFinNoMark, "5");
                    }
                    if (cbSab.Checked)
                    {
                        CN_HorarioAsignatura objetoCNegocio = new CN_HorarioAsignatura();
                        exito6 = objetoCNegocio.CreateHorariosNegocio(idSemestreLocal, cmbValueGrupo, dtSabI.Text, dtSabF.Text, "6");
                    }
                    else
                    {
                        CN_HorarioAsignatura objetoCNegocio = new CN_HorarioAsignatura();
                        exito = objetoCNegocio.CreateHorariosNegocio(idSemestreLocal, cmbValueGrupo, horaInicioNoMark, horaFinNoMark, "6");
                    }
                    if (cbDom.Checked)
                    {
                        CN_HorarioAsignatura objetoCNegocio = new CN_HorarioAsignatura();
                        exito7 = objetoCNegocio.CreateHorariosNegocio(idSemestreLocal, cmbValueGrupo, dtDomI.Text, dtDomF.Text, "7");
                    }
                    else
                    {
                        CN_HorarioAsignatura objetoCNegocio = new CN_HorarioAsignatura();
                        exito = objetoCNegocio.CreateHorariosNegocio(idSemestreLocal, cmbValueGrupo, horaInicioNoMark, horaFinNoMark, "7");
                    }

                    if (exito || exito2 || exito3 || exito4 || exito5 || exito6 || exito7)
                    {
                        //MessageBox.Show("Horario/s agregado correctamente");
                        //MostrarHorarios();
                    }
                    else
                    {
                        MessageBox.Show("El Horario/s ingresado posee un conflicto con el número de horas semanales posibles o existe un cruce de horario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    FrmCUAsignatura_AL frmCuAsignatura = Application.OpenForms["FrmCUAsignatura_AL"] as FrmCUAsignatura_AL;
                    if (frmCuAsignatura != null)
                    {
                        frmCuAsignatura.ListarGruposAsignatura(true);
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El horario no cumple con las horas semanales correspondientes a la asignatura seleccionada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo registrar el Horario. Motivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarH_Click(object sender, EventArgs e)
        {
            if (GRisNew)
            {
                objetoCNegocio.DeleteGruposNeg(idGrCreated.ToString());
            }
            this.Close();
        }

        #region Checkbox Methods

        private void FormatosDateTimePickersGral()
        {
            dtLunesI.CustomFormat = "HH:mm";
            dtLunesI.Text = "09:00";
            dtLunesI.ShowUpDown = true;
            dtLunesF.CustomFormat = "HH:mm";
            dtLunesF.Text = "11:00";
            dtLunesF.ShowUpDown = true;

            dtMartesI.CustomFormat = "HH:mm";
            dtMartesI.Text = "09:00";
            dtMartesI.ShowUpDown = true;
            dtMartesF.CustomFormat = "HH:mm";
            dtMartesF.Text = "11:00";
            dtMartesF.ShowUpDown = true;

            dtMieI.CustomFormat = "HH:mm";
            dtMieI.Text = "09:00";
            dtMieI.ShowUpDown = true;
            dtMieF.CustomFormat = "HH:mm";
            dtMieF.Text = "11:00";
            dtMieF.ShowUpDown = true;

            dtJueI.CustomFormat = "HH:mm";
            dtJueI.Text = "09:00";
            dtJueI.ShowUpDown = true;
            dtJueF.CustomFormat = "HH:mm";
            dtJueF.Text = "11:00";
            dtJueF.ShowUpDown = true;

            dtVieI.CustomFormat = "HH:mm";
            dtVieI.Text = "09:00";
            dtVieI.ShowUpDown = true;
            dtVieF.CustomFormat = "HH:mm";
            dtVieF.Text = "11:00";
            dtVieF.ShowUpDown = true;

            dtSabI.CustomFormat = "HH:mm";
            dtSabI.Text = "09:00";
            dtSabI.ShowUpDown = true;
            dtSabF.CustomFormat = "HH:mm";
            dtSabF.Text = "11:00";
            dtSabF.ShowUpDown = true;

            dtDomI.CustomFormat = "HH:mm";
            dtDomI.Text = "09:00";
            dtDomI.ShowUpDown = true;
            dtDomF.CustomFormat = "HH:mm";
            dtDomF.Text = "11:00";
            dtDomF.ShowUpDown = true;
        }

        private void FormatosDateTimePicker(DateTimePicker dtDayI, DateTimePicker dtDayF)
        {
            dtDayI.CustomFormat = "HH:mm";
            dtDayI.Text = "09:00";
            dtDayI.ShowUpDown = true;
            dtDayF.CustomFormat = "HH:mm";
            dtDayF.Text = "11:00";
            dtDayF.ShowUpDown = true;
        }

        private void cbLun_CheckedChanged(object sender, EventArgs e)
        {

            if (cbLun.Checked)
            {
                dtLunesI.Enabled = true;
                dtLunesF.Enabled = true;
            }
            else
            {
                dtLunesI.Enabled = false;
                dtLunesF.Enabled = false;
                FormatosDateTimePicker(dtLunesI, dtLunesF);
            }
            VerificarHorasSemanales();
        }

        private void cbMar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMar.Checked)
            {
                dtMartesI.Enabled = true;
                dtMartesF.Enabled = true;
            }
            else
            {
                dtMartesI.Enabled = false;
                dtMartesF.Enabled = false;
                FormatosDateTimePicker(dtMartesI, dtMartesF);
            }
            VerificarHorasSemanales();
        }

        private void cbMie_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMie.Checked)
            {
                dtMieI.Enabled = true;
                dtMieF.Enabled = true;
            }
            else
            {
                dtMieI.Enabled = false;
                dtMieF.Enabled = false;
                FormatosDateTimePicker(dtMieI, dtMieF);
            }
            VerificarHorasSemanales();
        }

        private void cbJue_CheckedChanged(object sender, EventArgs e)
        {
            if (cbJue.Checked)
            {
                dtJueI.Enabled = true;
                dtJueF.Enabled = true;
            }
            else
            {
                dtJueI.Enabled = false;
                dtJueF.Enabled = false;
                FormatosDateTimePicker(dtJueI, dtJueF);
            }
            VerificarHorasSemanales();
        }

        private void cbVie_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVie.Checked)
            {
                dtVieI.Enabled = true;
                dtVieF.Enabled = true;
            }
            else
            {
                dtVieI.Enabled = false;
                dtVieF.Enabled = false;
                FormatosDateTimePicker(dtVieI, dtVieF);
            }
            VerificarHorasSemanales();
        }

        private void cbSab_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSab.Checked)
            {
                dtSabF.Enabled = true;
                dtSabI.Enabled = true;
            }
            else
            {
                dtSabI.Enabled = false;
                dtSabF.Enabled = false;
                FormatosDateTimePicker(dtSabI, dtSabF);
            }
            VerificarHorasSemanales();
        }

        private void cbDom_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDom.Checked)
            {
                dtDomI.Enabled = true;
                dtDomF.Enabled = true;
            }
            else
            {
                dtDomI.Enabled = false;
                dtDomF.Enabled = false;
                FormatosDateTimePicker(dtDomI, dtDomF);
            }
            VerificarHorasSemanales();
        }

        #endregion

        #region DATETIME PICKERS METHODS
        private void dtLunesI_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(dtLunesI.Text, out DateTime selectedDate))
            {
                DateTime nuevaHoraFin = selectedDate.AddHours(2);

                dtLunesF.Value = nuevaHoraFin;
            }
        }

        private void dtMartesI_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(dtMartesI.Text, out DateTime selectedDate))
            {
                DateTime nuevaHoraFin = selectedDate.AddHours(2);

                dtMartesF.Value = nuevaHoraFin;
            }
        }

        private void dtMieI_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(dtMieI.Text, out DateTime selectedDate))
            {
                DateTime nuevaHoraFin = selectedDate.AddHours(2);

                dtMieF.Value = nuevaHoraFin;
            }
        }

        private void dtJueI_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(dtJueI.Text, out DateTime selectedDate))
            {
                DateTime nuevaHoraFin = selectedDate.AddHours(2);

                dtJueF.Value = nuevaHoraFin;
            }
        }

        private void dtVieI_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(dtVieI.Text, out DateTime selectedDate))
            {
                DateTime nuevaHoraFin = selectedDate.AddHours(2);

                dtVieF.Value = nuevaHoraFin;
            }
        }

        private void dtSabI_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(dtSabI.Text, out DateTime selectedDate))
            {
                DateTime nuevaHoraFin = selectedDate.AddHours(2);

                dtSabF.Value = nuevaHoraFin;
            }
        }

        private void dtDomI_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(dtDomI.Text, out DateTime selectedDate))
            {
                DateTime nuevaHoraFin = selectedDate.AddHours(2);

                dtDomF.Value = nuevaHoraFin;
            }
        }
        #endregion

        private void cmbAsignaturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarGruposAsignatura();
        }

        public void ListarGruposAsignatura()
        {
            if (cmbAsignaturas.SelectedIndex > -1)
            {
                CN_GrAsignatura objetoGrNegocio2 = new CN_GrAsignatura();
                DataTable dtGrsCmb = objetoGrNegocio2.MostrarAllGruposPorAsignaturaBySemestre_Negocio(idSemestreLocal.ToString(), IdAsignatura);
                cmbGR.DataSource = dtGrsCmb;
                cmbGR.DisplayMember = "Grupos";
                cmbGR.ValueMember = "ID";
            }
        }

        private void dtLunesF_ValueChanged(object sender, EventArgs e)
        {
            VerificarHorasSemanales();
        }
    }
}
