using Directorio_Datos;
using Directorio_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace Directorio_Logica
{
    public class CN_Semestre
    {
        private DAL_Semestre objetoCData = new DAL_Semestre();

        public DataTable MostrarSemestres()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCData.MostrarRegistros();
            return tabla;
        }
        
        #region CRUD Methods
        public bool CreateSemestreNegocio(string code, string year, string dateIni, string dateEnd, string numWeekC, string numWeekSem)
        {
            try
            {
                var dateI = DateTime.Parse(dateIni);
                var dateF = DateTime.Parse(dateEnd);

                ClsSemestre ObjSemestre = new ClsSemestre()
                {
                    CodigoSemestre = code,
                    AñoSemestre = Convert.ToInt32(year),
                    DiaInicio = DateOnly.FromDateTime(dateI),
                    DiaFin = DateOnly.FromDateTime(dateF),
                    NumeroSemanasClase = Convert.ToInt32(numWeekC),
                    NumeroSemanasSemestre = Convert.ToInt32(numWeekSem)
                };
                //objetoCData.CreateDepartamento(nameDepartament, email);
                objetoCData.CreateSemestre(ObjSemestre);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        public bool UpdateSemestreNegocio(string id, string code, string year, string dateIni, string dateEnd, string numWeekC, string numWeekSem)
        {
            try
            {
                var dateI = DateTime.Parse(dateIni);
                var dateF = DateTime.Parse(dateEnd);

                ClsSemestre ObjSemestre = new ClsSemestre()
                {
                    IdSemestre = Convert.ToInt32(id),
                    CodigoSemestre = code,
                    AñoSemestre = Convert.ToInt32(year),
                    DiaInicio = DateOnly.FromDateTime(dateI),
                    DiaFin = DateOnly.FromDateTime(dateF),
                    NumeroSemanasClase = Convert.ToInt32(numWeekC),
                    NumeroSemanasSemestre = Convert.ToInt32(numWeekSem)
                };
                
                objetoCData.UpdateSemestre(ObjSemestre);


                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        public bool DeleteSemestreNegocio(string id)
        {
            try
            {
                ClsSemestre ObjSemestre = new ClsSemestre()
                {
                    IdSemestre = Convert.ToInt32(id)
                };
                objetoCData.DeleteSemestre(ObjSemestre);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        #endregion

        #region SemestreDocente Section
        public bool CreateOrUpdateSemestreDocente_Negocio(string idSemestre, string idDocente,string idTpDocente,string numHorasTpDoc,string state)
        {
            try
            {

                ClsSemestre ObjSemestre = new ClsSemestre()
                {
                    IdSemestre = Convert.ToInt32(idSemestre),
                    Estado = Convert.ToBoolean(state)
                };
                ClsDocente ObjDocente = new ClsDocente()
                {
                    IdDocente = Convert.ToInt32(idDocente)
                };
                ClsTipoDocente ObjTpDocente = new ClsTipoDocente()
                {
                    IdTipoDocente = Convert.ToInt32(idTpDocente),
                    HorasExigibles = Convert.ToInt32(numHorasTpDoc),
                };
                objetoCData.CreateSemestreDocente(ObjSemestre, ObjDocente, ObjTpDocente);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        public bool CreateOrUpdateSemestreAsignatura_Negocio(string idSemestre, string idAsignatura, string state)
        {
            try
            {

                ClsSemestre ObjSemestre = new ClsSemestre()
                {
                    IdSemestre = Convert.ToInt32(idSemestre),
                    Estado = Convert.ToBoolean(state)
                };
                ClsAsignatura ObjAsignatura = new ClsAsignatura()
                {
                    IdAsignatura = Convert.ToInt32(idAsignatura)
                };
                objetoCData.CreateSemestreAsignatura(ObjSemestre, ObjAsignatura);

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
