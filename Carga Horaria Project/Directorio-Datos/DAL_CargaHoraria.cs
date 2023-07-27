using Directorio_Datos.DataBase;
using Directorio_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directorio_Datos
{
    public class DAL_CargaHoraria
    {
        ManejadorDB ObjDataBase = new ManejadorDB();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        ClsCargaHoraria objCargaH = new ClsCargaHoraria();


        #region CRUD METHODS
        // CRUD METHODS
        // CREATE ASIGNATURA
        public bool CreateCargaHoraria(ClsCargaHoraria _cargaHoraria)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spAddCargaHoraria";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@idDocent", _cargaHoraria.IdDocente);
                sqlCommand.Parameters.AddWithValue("@idSemestr", _cargaHoraria.IdSemestre);

                ObjDataBase.AbrirConexion();
                sqlCommand.ExecuteNonQuery();

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
            finally
            {
                ObjDataBase.CerrarConexion();
            }

        }
        // UPDATE ASIGNATURA
        public bool UpdateCargaHoraria(ClsCargaHoraria _cargaHoraria)
        {
            try
            {
                comando.Connection = ObjDataBase.sqlConexion;
                comando.CommandText = "spUpdateCargaHoraria";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", _cargaHoraria.IdCargaHoraria);
                comando.Parameters.AddWithValue("@idDocent", _cargaHoraria.IdDocente);
                comando.Parameters.AddWithValue("@idSemestr", _cargaHoraria.IdSemestre);

                ObjDataBase.AbrirConexion();
                comando.ExecuteNonQuery();

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
            finally
            {
                ObjDataBase.CerrarConexion();
            }
        }
        public bool UpdateAsigCargaHDAL(ClsCargaHoraria _cargaHoraria, ClsGrupoAsignatura _grAsig)
        {
            try
            {
                int GR = _grAsig.IdGrupoAsignatura;
                comando.Connection = ObjDataBase.sqlConexion;
                comando.CommandText = "spUpdateAsigCrgHoraria";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", _cargaHoraria.IdAsignaturaCarga);
                comando.Parameters.AddWithValue("@idCrgH", _cargaHoraria.IdCargaHoraria);
                comando.Parameters.AddWithValue("@idGrAsig", GR);

                ObjDataBase.AbrirConexion();
                comando.ExecuteNonQuery();

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
            finally
            {
                ObjDataBase.CerrarConexion();
            }
        }
        public bool UpdateActivCargaHDAL(ClsCargaHoraria _cargaHoraria, ClsActividad _activ)
        {
            try
            {
                int idActiv = _activ.IdActividad;
                int idCarga = _cargaHoraria.IdCargaHoraria;
                int idActividadCarga = _cargaHoraria.IdActividadCarga;
                int horasAct = _activ.HorasSemana;
                int horasTotAct = _activ.HorasTotalesAct;
                
                comando.Connection = ObjDataBase.sqlConexion;
                comando.CommandText = "spUpdateActivCrgHoraria";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", idActividadCarga);
                comando.Parameters.AddWithValue("@idCrgH", idCarga);
                comando.Parameters.AddWithValue("@idAct", idActiv);
                comando.Parameters.AddWithValue("@hSemana", horasAct);
                comando.Parameters.AddWithValue("@hTotal", horasTotAct);

                ObjDataBase.AbrirConexion();
                comando.ExecuteNonQuery();
                

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
            finally
            {
                ObjDataBase.CerrarConexion();
            }
        }
        // DELETE ASIGNATURA
        public bool DeleteCargaHoraria(ClsCargaHoraria _cargaHoraria)
        {
            try
            {
                comando.Connection = ObjDataBase.sqlConexion;
                comando.CommandText = "spDeleteCargaHoraria";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", _cargaHoraria.IdCargaHoraria);

                ObjDataBase.AbrirConexion();
                comando.ExecuteNonQuery();

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }
            finally
            {
                ObjDataBase.CerrarConexion();
            }

        }
        public bool DeleteAsignaturaCargaHorariaDAL(ClsCargaHoraria _cargaHoraria)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = ObjDataBase.sqlConexion;
                comando.CommandText = "spDeleteAsigCrgHoraria";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", _cargaHoraria.IdAsignaturaCarga);

                ObjDataBase.AbrirConexion();
                comando.ExecuteNonQuery();

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }
            finally
            {
                ObjDataBase.CerrarConexion();
            }

        }
        public bool DeleteActividadCargaHorariaDAL(ClsCargaHoraria _cargaHoraria)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = ObjDataBase.sqlConexion;
                comando.CommandText = "spDeleteActivCrgHoraria";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", _cargaHoraria.IdActividadCarga);

                ObjDataBase.AbrirConexion();
                comando.ExecuteNonQuery();

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
            finally
            {
                ObjDataBase.CerrarConexion();
            }

        }
        #endregion

        #region CRUD Methods with intermed Tables
        // Create method for tblAsigCrgHoraria
        public bool Create_AsignaturaCargaHoraria(ClsCargaHoraria _cargaHoraria)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spAddAsigCrgHoraria";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@idCrgH", _cargaHoraria.IdCargaHoraria);
                sqlCommand.Parameters.AddWithValue("@idGrAsig", _cargaHoraria.IdGrAsignatura);

                ObjDataBase.AbrirConexion();
                sqlCommand.ExecuteNonQuery();

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
            finally
            {
                ObjDataBase.CerrarConexion();
            }
        }
        // Create method for tblActivCrgHoraria
        public bool Create_ActividadCargaHoraria(ref ClsCargaHoraria _cargaHoraria)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spAddActCrgHoraria";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@idCrgH", _cargaHoraria.IdCargaHoraria);
                sqlCommand.Parameters.AddWithValue("@idAct", _cargaHoraria.IdActividad);
                sqlCommand.Parameters.AddWithValue("@hSemana", _cargaHoraria.HoraSemanalActividad);
                sqlCommand.Parameters.AddWithValue("@hTotal", _cargaHoraria.HoraTotalActividad);

                ObjDataBase.AbrirConexion();
                sqlCommand.ExecuteNonQuery();

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
            finally
            {
                ObjDataBase.CerrarConexion();
            }

        }
        #endregion

        #region METHODS TO SHOW DATA
        /// <summary>
        /// 
        public DataTable MostrarReporteDocentes_ByIdSemestre_DAL(ClsSemestre _semestre)
        {
            //comando.Connection = manejador.AbrirConexion();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = ObjDataBase.sqlConexion;
            sqlCommand.CommandText = "spGetDocentesLst_CargaAcademica_BySemestre";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);
            ObjDataBase.AbrirConexion();
            leer = sqlCommand.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarReporteActividadesD11D_ByIdSemestre_DAL(ClsSemestre _semestre)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = ObjDataBase.sqlConexion;
            sqlCommand.CommandText = "spGetActividadesD11D_BySemestre_Reporte";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);
            ObjDataBase.AbrirConexion();
            leer = sqlCommand.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarReporteActividadesComisiones_ByIdSemestre_DAL(ClsSemestre _semestre)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = ObjDataBase.sqlConexion;
            sqlCommand.CommandText = "spGetActividadesComisiones_BySemestre_Reporte";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);
            ObjDataBase.AbrirConexion();
            leer = sqlCommand.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public List<int> GetIdsCargaHorariaLst_ByIdSemestre_DAL(ClsSemestre _semestre)
        {
            List<int> idsCargaHorariaList = new List<int>();

            //comando.Connection = manejador.AbrirConexion();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = ObjDataBase.sqlConexion;
            sqlCommand.CommandText = "spGetIdCargaHorariaLst_BySemestre";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);
            ObjDataBase.AbrirConexion();
            leer = sqlCommand.ExecuteReader();
            while (leer.Read())
            {
                int idCargaHoraria = Convert.ToInt32(leer[0]);
                idsCargaHorariaList.Add(idCargaHoraria);
            }

            leer.Close();
            ObjDataBase.CerrarConexion();

            return idsCargaHorariaList;
        }
        public int GetIdCargaHorariaDAL(ClsCargaHoraria _cargaHoraria)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spGetIdCargaHoraria";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idDocente", _cargaHoraria.IdDocente);
                sqlCommand.Parameters.AddWithValue("@idSemestre", _cargaHoraria.IdSemestre);

                ObjDataBaseL.AbrirConexion();
                int cargaHorariaId = (int)sqlCommand.ExecuteScalar();
                
                return cargaHorariaId;
                
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
                return -1;
            }
            finally
            {
                ObjDataBaseL.CerrarConexion();
            }
        }
        public int CheckCargaHorariaDAL(ClsCargaHoraria _cargaHoraria)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spCheckExCargaHoraria";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idDocente", _cargaHoraria.IdDocente);
                sqlCommand.Parameters.AddWithValue("@idSemestre", _cargaHoraria.IdSemestre);

                ObjDataBaseL.AbrirConexion();
                int check = (int)sqlCommand.ExecuteScalar();

                return check;

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
                return -1;
            }
            finally
            {
                ObjDataBaseL.CerrarConexion();
            }
        }
        public string GetDocenteNameByCrgHoraria_DAL(ClsCargaHoraria _crgHoraria)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spGetDocenteNameByCrgHoraria";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idCrgHoraria", _crgHoraria.IdCargaHoraria);

                ObjDataBaseL.AbrirConexion();
                string docenteName = sqlCommand.ExecuteScalar().ToString();

                return docenteName;

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
                return "";
            }
            finally
            {
                ObjDataBaseL.CerrarConexion();
            }
        }
        public string GetDocenteNameTypeByCrgHoraria_DAL(ClsCargaHoraria _crgHoraria)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spGetDocenteNameTypeByCrgHoraria";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idCrgHoraria", _crgHoraria.IdCargaHoraria);
                sqlCommand.Parameters.AddWithValue("@idSemestre",  _crgHoraria.IdSemestre);

                ObjDataBaseL.AbrirConexion();
                string docenteTypeName = sqlCommand.ExecuteScalar().ToString();

                return docenteTypeName;

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
                return "";
            }
            finally
            {
                ObjDataBaseL.CerrarConexion();
            }
        }
        public int CheckHorasExigiblesDocenteDAL(ClsSemestre _semestre, ClsDocente _docente)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spCheckHorasExDocente";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idDocente", _docente.IdDocente);
                sqlCommand.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);

                ObjDataBaseL.AbrirConexion();
                int check = (int)sqlCommand.ExecuteScalar();

                return check;

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
                return -1;
            }
            finally
            {
                ObjDataBaseL.CerrarConexion();
            }
        }
        public int CheckHorasExigiblesDocenteByIdCarga_DAL(ClsCargaHoraria _carga)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spCheckHorasExDocenteByIdCrgH";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idCarga", _carga.IdCargaHoraria);

                ObjDataBaseL.AbrirConexion();
                int horas = (int)sqlCommand.ExecuteScalar();

                return horas;

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
                return -1;
            }
            finally
            {
                ObjDataBaseL.CerrarConexion();
            }
        }
        public int GetSemanasClase_DAL(ClsSemestre _semestre)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spGetSemanasClaseBySemestre";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);

                ObjDataBaseL.AbrirConexion();
                int check = (int)sqlCommand.ExecuteScalar();

                return check;

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
                return -1;
            }
            finally
            {
                ObjDataBaseL.CerrarConexion();
            }
        }
        public int GetSemanasSemestre_DAL(ClsSemestre _semestre)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spGetSemanasSemestreBySemestre";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);

                ObjDataBaseL.AbrirConexion();
                int check = (int)sqlCommand.ExecuteScalar();

                return check;

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
                return -1;
            }
            finally
            {
                ObjDataBaseL.CerrarConexion();
            }
        }
        public int GetIdActividadCargaDAL(ClsActividad _actividad)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spGetIdActividad";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ActividadName", _actividad.NombreActividad);

                ObjDataBaseL.AbrirConexion();
                int actividadId = (int)sqlCommand.ExecuteScalar();

                return actividadId;

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
                return -1;
            }
            finally
            {
                ObjDataBaseL.CerrarConexion();
            }
        }


        // Metodo para cargar todos los registros de la tabla tblActividades
        public DataTable MostrarCargasHorariasDAL(ClsCargaHoraria _cargaHoraria)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spReadAllCargas";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idSemestre", _cargaHoraria.IdSemestre);
                ObjDataBase.AbrirConexion();
                leer = sqlCommand.ExecuteReader();
                tabla.Load(leer);
                ObjDataBase.CerrarConexion();
                return tabla;
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
                return null;
            }

        }
        public DataTable MostrarAsignaturasCrgAcademicaDAL(ClsCargaHoraria _cargaHoraria)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spReadAllCargaAsignaturas";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idCrgHoraria", _cargaHoraria.IdCargaHoraria);
                ObjDataBase.AbrirConexion();
                leer = sqlCommand.ExecuteReader();
                tabla.Load(leer);
                ObjDataBase.CerrarConexion();
                return tabla;
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
                return null;
            }

        }
        public DataTable MostrarAsignaturasCrgAcademica_Review_DAL(ClsCargaHoraria _cargaHoraria)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spReadAllCargaAsignaturas_Review";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idCrgHoraria", _cargaHoraria.IdCargaHoraria);
                ObjDataBase.AbrirConexion();
                leer = sqlCommand.ExecuteReader();
                tabla.Load(leer);
                ObjDataBase.CerrarConexion();
                return tabla;
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
                return null;
            }

        }
        public DataTable MostrarActividadesD11CrgAcademica(ClsCargaHoraria _cargaHoraria)
        {
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllCargaActividadesD11";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idCrgHoraria", _cargaHoraria.IdCargaHoraria);
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarActividadesF11CrgAcademica(ClsCargaHoraria _cargaHoraria)
        {
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllCargaActividadesF11";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idCrgHoraria", _cargaHoraria.IdCargaHoraria);
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarActividadesGestionCrgAcademica(ClsCargaHoraria _cargaHoraria)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllCargaActividadesG";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idCrgHoraria", _cargaHoraria.IdCargaHoraria);
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarActividadesInvestigacionCrgAcademicaDAL(ClsCargaHoraria _cargaHoraria)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllCargaActividadesI";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idCrgHoraria", _cargaHoraria.IdCargaHoraria);
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarAllActividadesCrgAcademica(ClsCargaHoraria _cargaHoraria)
        {
            try
            {

                SqlCommand comando = new SqlCommand();
                comando.Connection = ObjDataBase.sqlConexion;
                comando.CommandText = "spReadAllCargaActividades";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idCrgHoraria", _cargaHoraria.IdCargaHoraria);
                ObjDataBase.AbrirConexion();
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                ObjDataBase.CerrarConexion();
                return tabla;
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
                return null;
            }
        }
        #endregion

        #region Methods to get Hours from an specific Academic Load

        public int GetClasesSemanalHoursDAL(ClsCargaHoraria _cargaHoraria)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spSumCargaClasesSemestral";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idCrgHoraria", _cargaHoraria.IdCargaHoraria);

                ObjDataBaseL.AbrirConexion();
                object scalarValue = sqlCommand.ExecuteScalar();
                if (Convert.IsDBNull(scalarValue))
                {
                    return 0;
                }
                else
                {
                    int horasGestion = (int)sqlCommand.ExecuteScalar();
                    return horasGestion;
                }



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
                return -1;
            }
            finally
            {
                ObjDataBaseL.CerrarConexion();
            }
        }
        public int GetGestionSemanalHoursDAL(ClsCargaHoraria _cargaHoraria)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spSumCargaActividadesG_Semanal";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idCrgHoraria", _cargaHoraria.IdCargaHoraria);

                ObjDataBaseL.AbrirConexion();
                object scalarValue = sqlCommand.ExecuteScalar();
                if (Convert.IsDBNull(scalarValue))
                {
                    return 0;
                }
                else
                {
                    int horasGestion = (int)sqlCommand.ExecuteScalar();
                    return horasGestion;
                }

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
                return -1;
            }
            finally
            {
                ObjDataBaseL.CerrarConexion();
            }
        }
        public int GetDocenciaD11SemanalHoursDAL(ClsCargaHoraria _cargaHoraria)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spSumCargaActividadesD11_Semanal";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idCrgHoraria", _cargaHoraria.IdCargaHoraria);

                ObjDataBaseL.AbrirConexion();
                object scalarValue = sqlCommand.ExecuteScalar();
                if (Convert.IsDBNull(scalarValue))
                {
                    return 0;
                }
                else
                {
                    int horasGestion = (int)sqlCommand.ExecuteScalar();
                    return horasGestion;
                }
                
                

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
                return -1;
            }
            finally
            {
                ObjDataBaseL.CerrarConexion();
            }
        }
        public int GetDocenciaF11SemanalHoursDAL(ClsCargaHoraria _cargaHoraria)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spSumCargaActividadesF11_Semanal";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idCrgHoraria", _cargaHoraria.IdCargaHoraria);

                ObjDataBaseL.AbrirConexion();
                object scalarValue = sqlCommand.ExecuteScalar();
                if (Convert.IsDBNull(scalarValue))
                {
                    return 0;
                }
                else
                {
                    int horasGestion = (int)sqlCommand.ExecuteScalar();
                    return horasGestion;
                }



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
                return -1;
            }
            finally
            {
                ObjDataBaseL.CerrarConexion();
            }
        }
        public int GetInvestigcionSemanalHoursDAL(ClsCargaHoraria _cargaHoraria)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spSumCargaActividadesI_Semanal";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idCrgHoraria", _cargaHoraria.IdCargaHoraria);

                ObjDataBaseL.AbrirConexion();
                object scalarValue = sqlCommand.ExecuteScalar();
                if (Convert.IsDBNull(scalarValue))
                {
                    return 0;
                }
                else
                {
                    int horasGestion = (int)sqlCommand.ExecuteScalar();
                    return horasGestion;
                }

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
                return -1;
            }
            finally
            {
                ObjDataBaseL.CerrarConexion();
            }
        }
        //Sum By Total Hours
        public int GetGestionTotalHoursDAL(ClsCargaHoraria _cargaHoraria)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spSumCargaActividadesG_ByTotalHoursAct";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idCrgHoraria", _cargaHoraria.IdCargaHoraria);

                ObjDataBaseL.AbrirConexion();
                object scalarValue = sqlCommand.ExecuteScalar();
                if (Convert.IsDBNull(scalarValue))
                {
                    return 0;
                }
                else
                {
                    int horasGestion = (int)sqlCommand.ExecuteScalar();
                    return horasGestion;
                }

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
                return -1;
            }
            finally
            {
                ObjDataBaseL.CerrarConexion();
            }
        }
        public int GetDocenciaD11TotalHoursDAL(ClsCargaHoraria _cargaHoraria)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spSumCargaActividadesD11_ByTotalHoursAct";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idCrgHoraria", _cargaHoraria.IdCargaHoraria);

                ObjDataBaseL.AbrirConexion();
                object scalarValue = sqlCommand.ExecuteScalar();
                if (Convert.IsDBNull(scalarValue))
                {
                    return 0;
                }
                else
                {
                    int horasGestion = (int)sqlCommand.ExecuteScalar();
                    return horasGestion;
                }



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
                return -1;
            }
            finally
            {
                ObjDataBaseL.CerrarConexion();
            }
        }
        public int GetDocenciaF11TotalHoursDAL(ClsCargaHoraria _cargaHoraria)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spSumCargaActividadesF11_ByTotalHoursAct";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idCrgHoraria", _cargaHoraria.IdCargaHoraria);

                ObjDataBaseL.AbrirConexion();
                object scalarValue = sqlCommand.ExecuteScalar();
                if (Convert.IsDBNull(scalarValue))
                {
                    return 0;
                }
                else
                {
                    int horasGestion = (int)sqlCommand.ExecuteScalar();
                    return horasGestion;
                }



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
                return -1;
            }
            finally
            {
                ObjDataBaseL.CerrarConexion();
            }
        }
        public int GetInvestigcionTotalHoursDAL(ClsCargaHoraria _cargaHoraria)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spSumCargaActividadesI_ByTotalHoursAct";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idCrgHoraria", _cargaHoraria.IdCargaHoraria);

                ObjDataBaseL.AbrirConexion();
                object scalarValue = sqlCommand.ExecuteScalar();
                if (Convert.IsDBNull(scalarValue))
                {
                    return 0;
                }
                else
                {
                    int horasGestion = (int)sqlCommand.ExecuteScalar();
                    return horasGestion;
                }

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
                return -1;
            }
            finally
            {
                ObjDataBaseL.CerrarConexion();
            }
        }

        #endregion

        #region Validation Methods
        public int ActivityValiadtionDAL(ClsCargaHoraria _cargaHoraria, ClsActividad _actividad)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                int idCarg = _cargaHoraria.IdCargaHoraria;
                string nameActiv = _actividad.NombreActividad;

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spActivityValidation";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idCrgHoraria", idCarg);
                sqlCommand.Parameters.AddWithValue("@actividadName", nameActiv);


                ObjDataBaseL.AbrirConexion();
                int val = (int)sqlCommand.ExecuteScalar();

                return val;

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
                return -1;
            }
            finally
            {
                ObjDataBaseL.CerrarConexion();
            }
        }
        public int AsignatureValiadtionDAL(ClsCargaHoraria _cargaHoraria, ClsAsignatura _asignature, ClsGrupoAsignatura _gr)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                int idCarg = _cargaHoraria.IdCargaHoraria;
                string nameAsig = _asignature.NombreAsignatura;

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spAsignatureValidation";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idCrgHoraria", idCarg);
                sqlCommand.Parameters.AddWithValue("@asignatureName", nameAsig);
                sqlCommand.Parameters.AddWithValue("@Gr", _gr.NombreGrupo);


                ObjDataBaseL.AbrirConexion();
                int val = (int)sqlCommand.ExecuteScalar();

                return val;

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
                return -10;
            }
            finally
            {
                ObjDataBaseL.CerrarConexion();
            }
        }
        #endregion
    }
}
