using Directorio_Datos;
using Directorio_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Directorio_Logica
{
    public class CN_HorarioAsignatura
    {
        private DAL_HorarioAsignatura objetoCData = new DAL_HorarioAsignatura();

        public DataTable MostrarGrAsignatura()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCData.MostrarAllRegistros();
            return tabla;
        }

        public DataTable GetHorariosByAsignaturaGR_Negocio(string idSemestre, string idGrAsig)
        {
            DataTable tabla = new DataTable();
            ClsSemestre ObjSemestre = new ClsSemestre()
            {
                IdSemestre = Convert.ToInt32(idSemestre),
            };
            ClsGrupoAsignatura ObjGrAsig = new ClsGrupoAsignatura()
            {
                IdGrupoAsignatura = Convert.ToInt32(idGrAsig),
            };
            tabla = objetoCData.GetHorariosByAsignaturaGR_DAL(ObjSemestre, ObjGrAsig);
            return tabla;
        }
        public DataTable GetHorariosByAsignaturaGRView_Negocio(string idSemestre, string idGrAsig)
        {
            DataTable tabla = new DataTable();
            ClsSemestre ObjSemestre = new ClsSemestre()
            {
                IdSemestre = Convert.ToInt32(idSemestre),
            };
            ClsGrupoAsignatura ObjGrAsig = new ClsGrupoAsignatura()
            {
                IdGrupoAsignatura = Convert.ToInt32(idGrAsig),
            };
            tabla = objetoCData.GetHorariosByAsignaturaGRView_DAL(ObjSemestre, ObjGrAsig);
            return tabla;
        }

        #region CRUD Methods
        public bool CreateHorariosNegocio(string idSemestre, string idGrAsig, string hInicio, string hFin, string day)
        {
            try
            {
                var dateTimeI = DateTime.Parse(hInicio);
                var dateTimeF = DateTime.Parse(hFin);
                var timeOnlyInicio = TimeOnly.FromDateTime(dateTimeI);
                var timeOnlyFin = TimeOnly.FromDateTime(dateTimeF);

                ClsHorarioGrAsignatura ObjHorarioAsig = new ClsHorarioGrAsignatura()
                {
                    IdGrAsig = Convert.ToInt32(idGrAsig),
                    HoraInicio = timeOnlyInicio,
                    HoraFin = timeOnlyFin,
                    IdDiaSemana = Convert.ToInt32(day),
                };
                ClsSemestre ObjSemestre = new ClsSemestre()
                {
                    IdSemestre = Convert.ToInt32(idSemestre),
                };
                bool resul = objetoCData.CreateHorarioAsig(ObjSemestre, ObjHorarioAsig);

                return resul;

            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Windows.Forms.MessageBox.Show(sqlException.Message); ;
                return false;

            }
        }

        public bool UpdateHorariosNegocio(string idHorario, string idAsig, string nameGr, string hInicio, string hFin, string day)
        {
            try
            {
                ClsHorarioGrAsignatura ObjHorarioAsig = new ClsHorarioGrAsignatura()
                {
                    IdHorario = Convert.ToInt32(idHorario),
                    IdGrAsig = Convert.ToInt32(idAsig),
                    Grupo = nameGr,
                    HoraInicio = TimeOnly.Parse(hInicio),
                    HoraFin = TimeOnly.Parse(hFin),
                    DiaSemana = day
                };
                objetoCData.UpdateHorarioAsig(ObjHorarioAsig);


                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        public bool DeleteHorariosNegocio(string idHorario)
        {
            try
            {
                ClsHorarioGrAsignatura ObjHorarioAsig = new ClsHorarioGrAsignatura()
                {
                    IdHorario = Convert.ToInt32(idHorario)
                };
                objetoCData.DeleteHorarioAsig(ObjHorarioAsig);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        #endregion

    }
}
