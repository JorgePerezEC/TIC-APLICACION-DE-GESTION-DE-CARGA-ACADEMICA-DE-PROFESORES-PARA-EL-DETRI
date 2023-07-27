using Directorio_Datos;
using Directorio_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directorio_Logica
{
    public class CN_CargaHoraria
    {
        private DAL_CargaHoraria objetoCData = new DAL_CargaHoraria();
        private bool state = false;


        #region CRUD Methods
        public bool CreateCargaHorariaNeg(string idSemestre, string idDocente)
        {
            try
            {
                ClsCargaHoraria ObjCargaHoraria = new ClsCargaHoraria()
                {
                    IdSemestre = Convert.ToInt32(idSemestre),
                    IdDocente = Convert.ToInt32(idDocente)
                };
                objetoCData.CreateCargaHoraria(ObjCargaHoraria);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }

        public bool UpdateCargaHorariaNeg(string idCargaHoraria, string idSemestre, string idDocente)
        {
            try
            {
                
                ClsCargaHoraria ObjCargaHoraria = new ClsCargaHoraria()
                {
                    IdCargaHoraria = Convert.ToInt32(idCargaHoraria),
                    IdSemestre = Convert.ToInt32(idSemestre),
                    IdDocente = Convert.ToInt32(idDocente)
                };
                objetoCData.UpdateCargaHoraria(ObjCargaHoraria);


                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        public bool UpdateAsignaturaCargaHNeg(string idAsigCarga, string idCargaH, string idGrAsignatura)
        {
            try
            {

                ClsCargaHoraria ObjCargaHoraria = new ClsCargaHoraria()
                {
                    IdAsignaturaCarga = Convert.ToInt32(idAsigCarga),
                    IdCargaHoraria = Convert.ToInt32(idCargaH)
                };
                ClsGrupoAsignatura ObjGrAsig = new ClsGrupoAsignatura()
                {
                    IdGrupoAsignatura = Convert.ToInt32(idGrAsignatura)
                };
                objetoCData.UpdateAsigCargaHDAL(ObjCargaHoraria, ObjGrAsig);


                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        public bool DeleteCargaHorariaNeg(string idCargaHoraria)
        {
            try
            {
                ClsCargaHoraria ObjCargaHoraria = new ClsCargaHoraria()
                {
                    IdCargaHoraria = Convert.ToInt32(idCargaHoraria)
                };
                objetoCData.DeleteCargaHoraria(ObjCargaHoraria);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;
            }
        }
        public bool DeleteAsignaturaCargaHNeg(string idAsigCargaH)
        {
            try
            {
                ClsCargaHoraria ObjCargaHoraria = new ClsCargaHoraria()
                {
                    IdAsignaturaCarga = Convert.ToInt32(idAsigCargaH)
                };
                objetoCData.DeleteAsignaturaCargaHorariaDAL(ObjCargaHoraria);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;
            }
        }

        public bool DeleteActividadCargaHNeg(string idActivCargaH)
        {
            try
            {
                ClsCargaHoraria ObjCargaHoraria = new ClsCargaHoraria()
                {
                    IdActividadCarga = Convert.ToInt32(idActivCargaH)
                };
                objetoCData.DeleteActividadCargaHorariaDAL(ObjCargaHoraria);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;
            }
        }
        #endregion

        #region CRUD Methods with intermed Tables
        // Create method for tblAsigCrgHoraria
        public bool Create_AsignaturaCargaHoraria_Negocio(string idCargaHoraria, string idGrAsignatura)
        {
            try
            {
                ClsCargaHoraria ObjCargaHoraria = new ClsCargaHoraria()
                {
                    IdCargaHoraria = Convert.ToInt32(idCargaHoraria),
                    IdGrAsignatura = Convert.ToInt32(idGrAsignatura)
                };
                objetoCData.Create_AsignaturaCargaHoraria(ObjCargaHoraria);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        // Create method for tblActividadCargas
        public bool Create_ActividadCargaHoraria_Negocio(string idCargaHoraria, string idActividad, string horasSemanalAct, string horasTotalesAct)
        {
            try
            {
                ClsCargaHoraria ObjCargaHoraria = new ClsCargaHoraria()
                {
                    IdCargaHoraria = Convert.ToInt32(idCargaHoraria),
                    IdActividad= Convert.ToInt32(idActividad),
                    HoraSemanalActividad = Convert.ToInt32(horasSemanalAct),
                    HoraTotalActividad = Convert.ToInt32(horasTotalesAct)
                };

                objetoCData.Create_ActividadCargaHoraria(ref ObjCargaHoraria);

                return true;

            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                string mensaje = string.Empty;
                switch (err.Number)
                {
                    case 109:
                        mensaje = "Problemas con insert"; break;
                    case 110:
                        mensaje = "Más problemas con insert"; break;
                    case 113:
                        mensaje = "Problemas con comentarios"; break;
                    case 156:
                        mensaje = "Error de sintaxis"; break;
                    default:
                        mensaje = err.ToString(); break;

                }
                return false;
            }

        }
        //Update Method form tblActividadCargas
        public bool Update_ActividadCargaHoraria_Negocio(string idActivCarga, string idCargaHoraria, string idActividad, string horasSemanalAct, string horasTotalAct)
        {
            try
            {
                ClsCargaHoraria ObjCargaHoraria = new ClsCargaHoraria()
                {
                    IdCargaHoraria = Convert.ToInt32(idCargaHoraria),
                    IdActividadCarga= Convert.ToInt32(idActivCarga)
                };
                ClsActividad ObjActividad = new ClsActividad()
                {
                    IdActividad = Convert.ToInt32(idActividad),
                    HorasSemana = Convert.ToInt32(horasSemanalAct),
                    HorasTotalesAct = Convert.ToInt32(horasTotalAct)
                };

                objetoCData.UpdateActivCargaHDAL(ObjCargaHoraria, ObjActividad);

                return true;

            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                string mensaje = string.Empty;
                switch (err.Number)
                {
                    case 109:
                        mensaje = "Problemas con insert"; break;
                    case 110:
                        mensaje = "Más problemas con insert"; break;
                    case 113:
                        mensaje = "Problemas con comentarios"; break;
                    case 156:
                        mensaje = "Error de sintaxis"; break;
                    default:
                        mensaje = err.ToString(); break;

                }
                return false;
            }

        }
        #endregion

        #region LOAD DATA METHODS
        public int GetIDCargaHorariaNegocio (string idSemestre, string idDocente)
        {
            ClsCargaHoraria ObjCargaHoraria = new ClsCargaHoraria()
            {
                IdSemestre = Convert.ToInt32(idSemestre),
                IdDocente = Convert.ToInt32(idDocente)
            };
            int idCargHoraria = objetoCData.GetIdCargaHorariaDAL(ObjCargaHoraria);
            return idCargHoraria;
        }
        public string GetDocenteNameByCrgHoraria_Negocio(string idCargaHoraria)
        {
            ClsCargaHoraria ObjCrgHoraria = new ClsCargaHoraria()
            {
                IdCargaHoraria = Convert.ToInt32(idCargaHoraria)
            };
            string docenteName = objetoCData.GetDocenteNameByCrgHoraria_DAL(ObjCrgHoraria);
            return docenteName;
        }
        public string GetDocenteNameTypeByCrgHoraria_Negocio(string idCargaHoraria, string idSemestre)
        {
            ClsCargaHoraria ObjCrgHoraria = new ClsCargaHoraria()
            {
                IdCargaHoraria  = Convert.ToInt32(idCargaHoraria),
                IdSemestre      = Convert.ToInt32(idSemestre)
            };
            string docenteName = objetoCData.GetDocenteNameTypeByCrgHoraria_DAL(ObjCrgHoraria);
            return docenteName;
        }
        public int CheckCargaHorariaNegocio(string idSemestre, string idDocente)
        {
            ClsCargaHoraria ObjCargaHoraria = new ClsCargaHoraria()
            {
                IdSemestre = Convert.ToInt32(idSemestre),
                IdDocente = Convert.ToInt32(idDocente)
            };
            int check = objetoCData.CheckCargaHorariaDAL(ObjCargaHoraria);
            return check;
        }
        public int CheckHorasExigiblesDocenteNegocio(string idSemestre, string idDocente)
        {
            ClsSemestre ObjSemestre = new ClsSemestre()
            {
                IdSemestre = Convert.ToInt32(idSemestre)
            };
            ClsDocente ObjDocente = new ClsDocente()
            {
                IdDocente = Convert.ToInt32(idDocente)
            };
            int horas = objetoCData.CheckHorasExigiblesDocenteDAL(ObjSemestre, ObjDocente);
            return horas;
        }
        public int CheckHorasExigiblesDocenteByIdCarga_Negocio(string idCarga)
        {
            ClsCargaHoraria ObjCarga = new ClsCargaHoraria()
            {
                IdCargaHoraria = Convert.ToInt32(idCarga)
            };
            int horas = objetoCData.CheckHorasExigiblesDocenteByIdCarga_DAL(ObjCarga);
            return horas;
        }

        public int GetSemanasClase_Negocio(string idSemestre)
        {
            ClsSemestre ObjSemestre = new ClsSemestre()
            {
                IdSemestre = Convert.ToInt32(idSemestre)
            };
            int horas = objetoCData.GetSemanasClase_DAL(ObjSemestre);
            return horas;
        }
        public int GetSemanasSemestre_Negocio(string idSemestre)
        {
            ClsSemestre ObjSemestre = new ClsSemestre()
            {
                IdSemestre = Convert.ToInt32(idSemestre)
            };
            int horas = objetoCData.GetSemanasSemestre_DAL(ObjSemestre);
            return horas;
        }

        public int GetIDActividadNegocio(string nameActividad)
        {
            ClsActividad ObjActividad = new ClsActividad()
            {
               NombreActividad = nameActividad
            };
            int idActividad = objetoCData.GetIdActividadCargaDAL(ObjActividad);
            return idActividad;
        }
        public DataTable LoadCargasHorarias_Negocio(string idSemestre)
        {
            DataTable tabla = new DataTable();
            ClsCargaHoraria objCargaHoraria = new ClsCargaHoraria()
            {
                IdSemestre = Convert.ToInt32(idSemestre)
            };
            tabla = objetoCData.MostrarCargasHorariasDAL(objCargaHoraria);
            return tabla;
        }
        public DataTable LoadAsignaturas_Review_Negocio(string idCargaHoraria)
        {
            DataTable tabla = new DataTable();
            ClsCargaHoraria objCargaHoraria = new ClsCargaHoraria()
            {
                IdCargaHoraria = Convert.ToInt32(idCargaHoraria)
            };
            tabla = objetoCData.MostrarAsignaturasCrgAcademica_Review_DAL(objCargaHoraria);
            return tabla;
        }
        public DataTable LoadAsignaturas_Negocio(string idCargaHoraria)
        {
            DataTable tabla = new DataTable();
            ClsCargaHoraria objCargaHoraria = new ClsCargaHoraria()
            {
                IdCargaHoraria = Convert.ToInt32(idCargaHoraria)
            };
            tabla = objetoCData.MostrarAsignaturasCrgAcademicaDAL(objCargaHoraria);
            return tabla;
        }
        public DataTable LoadActividadesD11_Negocio(string idCargaHoraria)
        {
            DataTable tabla = new DataTable();
            ClsCargaHoraria objCargaHoraria = new ClsCargaHoraria()
            {
                IdCargaHoraria = Convert.ToInt32(idCargaHoraria)
            };
            tabla = objetoCData.MostrarActividadesD11CrgAcademica(objCargaHoraria);
            return tabla;
        }
        public DataTable LoadActividadesF11_Negocio(string idCargaHoraria)
        {
            DataTable tabla = new DataTable();
            ClsCargaHoraria objCargaHoraria = new ClsCargaHoraria()
            {
                IdCargaHoraria = Convert.ToInt32(idCargaHoraria)
            };
            tabla = objetoCData.MostrarActividadesF11CrgAcademica(objCargaHoraria);
            return tabla;
        }
        public DataTable LoadActividadesG_Negocio(string idCargaHoraria)
        {
            DataTable tabla = new DataTable();
            ClsCargaHoraria objCargaHoraria = new ClsCargaHoraria()
            {
                IdCargaHoraria = Convert.ToInt32(idCargaHoraria)
            };
            tabla = objetoCData.MostrarActividadesGestionCrgAcademica(objCargaHoraria);
            return tabla;
        }
        public DataTable LoadActividadesI_Negocio(string idCargaHoraria)
        {
            DataTable tabla = new DataTable();
            ClsCargaHoraria objCargaHoraria = new ClsCargaHoraria()
            {
                IdCargaHoraria = Convert.ToInt32(idCargaHoraria)
            };
            tabla = objetoCData.MostrarActividadesInvestigacionCrgAcademicaDAL(objCargaHoraria);
            return tabla;
        }
        public DataTable LoadAllActividades_Negocio(string idCargaHoraria)
        {
            DataTable tabla = new DataTable();
            ClsCargaHoraria objCargaHoraria = new ClsCargaHoraria()
            {
                IdCargaHoraria = Convert.ToInt32(idCargaHoraria)
            };
            tabla = objetoCData.MostrarAllActividadesCrgAcademica(objCargaHoraria);
            return tabla;
        }
        //REPORTES ******************************
        public DataTable MostrarReporteDocentes_ByIdSemestre_Negocio(string idSemestre)
        {
            DataTable tabla = new DataTable();
            ClsSemestre objSemestre = new ClsSemestre()
            {
                IdSemestre = Convert.ToInt32(idSemestre)
            };
            tabla = objetoCData.MostrarReporteDocentes_ByIdSemestre_DAL(objSemestre);
            return tabla;
        }
        public DataTable MostrarReporteActividadesD11D_ByIdSemestre_Negocio(string idSemestre)
        {
            DataTable tabla = new DataTable();
            ClsSemestre objSemestre = new ClsSemestre()
            {
                IdSemestre = Convert.ToInt32(idSemestre)
            };
            tabla = objetoCData.MostrarReporteActividadesD11D_ByIdSemestre_DAL(objSemestre);
            return tabla;
        }
        public DataTable MostrarReporteActividadesComisiones_ByIdSemestre_Negocio(string idSemestre)
        {
            DataTable tabla = new DataTable();
            ClsSemestre objSemestre = new ClsSemestre()
            {
                IdSemestre = Convert.ToInt32(idSemestre)
            };
            tabla = objetoCData.MostrarReporteActividadesComisiones_ByIdSemestre_DAL(objSemestre);
            return tabla;
        }
        //**********************************

        public List<int> GetIdsCargaHorariaLst_ByIdSemestre_Negocio(string idSemestre)
        {
            List<int> idsCargaHorariaList = new List<int>();
            ClsSemestre objSemestre = new ClsSemestre()
            {
                IdSemestre = Convert.ToInt32(idSemestre)
            };
            idsCargaHorariaList = objetoCData.GetIdsCargaHorariaLst_ByIdSemestre_DAL(objSemestre);
            return idsCargaHorariaList;
        }
        #endregion

        #region  Methods to get total Hours to Academic Load

        public int GetSemanalHoursClasesNegocio(string idCargaHoraria)
        {
            ClsCargaHoraria ObjCargaHoraria = new ClsCargaHoraria()
            {
                IdCargaHoraria = Convert.ToInt32(idCargaHoraria)
            };
            int horasTClases = objetoCData.GetClasesSemanalHoursDAL(ObjCargaHoraria);
            return horasTClases;
        }
        //Sum By Semanal Hours
        public int GetSemanalHoursGestionNegocio(string idCargaHoraria)
        {
            ClsCargaHoraria ObjCargaHoraria = new ClsCargaHoraria()
            {
                IdCargaHoraria = Convert.ToInt32(idCargaHoraria)
            };
            int horasTGestion = objetoCData.GetGestionSemanalHoursDAL(ObjCargaHoraria);
            return horasTGestion;
        }
        public int GetSemanalHoursDocenciaD11Negocio(string idCargaHoraria)
        {
            ClsCargaHoraria ObjCargaHoraria = new ClsCargaHoraria()
            {
                IdCargaHoraria = Convert.ToInt32(idCargaHoraria)
            };
            int horasTDocenciaD = objetoCData.GetDocenciaD11SemanalHoursDAL(ObjCargaHoraria);
            return horasTDocenciaD;
        }
        public int GetSemanalHoursDocenciaF11Negocio(string idCargaHoraria)
        {
            ClsCargaHoraria ObjCargaHoraria = new ClsCargaHoraria()
            {
                IdCargaHoraria = Convert.ToInt32(idCargaHoraria)
            };
            int horasTDocenciaF = objetoCData.GetDocenciaF11SemanalHoursDAL(ObjCargaHoraria);
            return horasTDocenciaF;
        }
        public int GetSemanalHoursInvestigacionNegocio(string idCargaHoraria)
        {
            ClsCargaHoraria ObjCargaHoraria = new ClsCargaHoraria()
            {
                IdCargaHoraria = Convert.ToInt32(idCargaHoraria)
            };
            int horasTInvestigacion = objetoCData.GetInvestigcionSemanalHoursDAL(ObjCargaHoraria);
            return horasTInvestigacion;
        }
        //Sum By Total Hours
        public int GetTotalHoursGestionNegocio(string idCargaHoraria)
        {
            ClsCargaHoraria ObjCargaHoraria = new ClsCargaHoraria()
            {
                IdCargaHoraria = Convert.ToInt32(idCargaHoraria)
            };
            int horasTGestion = objetoCData.GetGestionTotalHoursDAL(ObjCargaHoraria);
            return horasTGestion;
        }
        public int GetTotalHoursDocenciaD11Negocio(string idCargaHoraria)
        {
            ClsCargaHoraria ObjCargaHoraria = new ClsCargaHoraria()
            {
                IdCargaHoraria = Convert.ToInt32(idCargaHoraria)
            };
            int horasTDocenciaD = objetoCData.GetDocenciaD11TotalHoursDAL(ObjCargaHoraria);
            return horasTDocenciaD;
        }
        public int GetTotalHoursDocenciaF11Negocio(string idCargaHoraria)
        {
            ClsCargaHoraria ObjCargaHoraria = new ClsCargaHoraria()
            {
                IdCargaHoraria = Convert.ToInt32(idCargaHoraria)
            };
            int horasTDocenciaF = objetoCData.GetDocenciaF11TotalHoursDAL(ObjCargaHoraria);
            return horasTDocenciaF;
        }
        public int GetTotalHoursInvestigacionNegocio(string idCargaHoraria)
        {
            ClsCargaHoraria ObjCargaHoraria = new ClsCargaHoraria()
            {
                IdCargaHoraria = Convert.ToInt32(idCargaHoraria)
            };
            int horasTInvestigacion = objetoCData.GetInvestigcionTotalHoursDAL(ObjCargaHoraria);
            return horasTInvestigacion;
        }
        #endregion

        #region Validation Methods CN
        public int ActivityValidationNegocio(string idCargaHoraria, string nameActivity)
        {
            ClsCargaHoraria ObjCargaHoraria = new ClsCargaHoraria()
            {
                IdCargaHoraria = Convert.ToInt32(idCargaHoraria)
            };
            ClsActividad ObjActividad = new ClsActividad()
            {
                NombreActividad = nameActivity
            };
            int val = objetoCData.ActivityValiadtionDAL(ObjCargaHoraria, ObjActividad);
            return val;
        }
        public int AsignatureValidationNegocio(string idCargaHoraria, string nameAsignature, string Gr)
        {
            ClsCargaHoraria ObjCargaHoraria = new ClsCargaHoraria()
            {
                IdCargaHoraria = Convert.ToInt32(idCargaHoraria)
            };
            ClsAsignatura ObjAsignature = new ClsAsignatura()
            {
                NombreAsignatura = nameAsignature,
            };
            ClsGrupoAsignatura ObjGr = new ClsGrupoAsignatura()
            {
                NombreGrupo = Gr
            };
            int val = objetoCData.AsignatureValiadtionDAL(ObjCargaHoraria, ObjAsignature, ObjGr);
            return val;
        }
        #endregion

    }
}
