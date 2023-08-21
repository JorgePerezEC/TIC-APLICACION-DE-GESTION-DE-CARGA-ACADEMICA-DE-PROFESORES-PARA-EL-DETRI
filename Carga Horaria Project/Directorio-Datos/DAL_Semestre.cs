using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Directorio_Datos.DataBase;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Directorio_Entidades;

namespace Directorio_Datos
{
    public class DAL_Semestre
    {
        ManejadorDB ObjDataBase = new ManejadorDB();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        // CRUD METHODS

        // CREATE SEMESTRE
        public bool CreateSemestre(ClsSemestre _semestre)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spAddSemestre";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@codSmstr", _semestre.CodigoSemestre);
                sqlCommand.Parameters.AddWithValue("@yrSmstr", _semestre.AñoSemestre);
                sqlCommand.Parameters.AddWithValue("@dIni", _semestre.DiaInicio.ToString("yyyy-MM-dd"));
                sqlCommand.Parameters.AddWithValue("@dFin", _semestre.DiaFin.ToString("yyyy-MM-dd"));
                sqlCommand.Parameters.AddWithValue("@nSemanaClase", _semestre.NumeroSemanasClase);
                sqlCommand.Parameters.AddWithValue("@nSemanaSemestre", _semestre.NumeroSemanasSemestre);

                ObjDataBase.AbrirConexion();
                sqlCommand.ExecuteNonQuery();

                return true;

            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Windows.Forms.MessageBox.Show(sqlException.Message); ;
                return false;

            }
            finally
            {
                ObjDataBase.CerrarConexion();
            }

        }
        // UPDATE SEMESTRE
        public bool UpdateSemestre(ClsSemestre _semestre)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spUpdateSemestre";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@id", _semestre.IdSemestre);
                sqlCommand.Parameters.AddWithValue("@codSmstr", _semestre.CodigoSemestre);
                sqlCommand.Parameters.AddWithValue("@yrSmstr", _semestre.AñoSemestre);
                sqlCommand.Parameters.AddWithValue("@dIni", _semestre.DiaInicio.ToString("yyyy-MM-dd"));
                sqlCommand.Parameters.AddWithValue("@dFin", _semestre.DiaFin.ToString("yyyy-MM-dd"));
                sqlCommand.Parameters.AddWithValue("@nSemanaClase", _semestre.NumeroSemanasClase);
                sqlCommand.Parameters.AddWithValue("@nSemanaSemestre", _semestre.NumeroSemanasSemestre);

                ObjDataBase.AbrirConexion();
                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Windows.Forms.MessageBox.Show(sqlException.Message); ;
                return false;

            }
            finally
            {
                ObjDataBase.CerrarConexion();
            }
        }
        // DELETE SEMESTRE
        public bool DeleteSemestre(ClsSemestre _semestre)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spDeleteSemestre";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@id", _semestre.IdSemestre);

                ObjDataBase.AbrirConexion();
                sqlCommand.ExecuteNonQuery();

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
        // Metodo para cargar todos los registros de la tabla tblSemestre
        public DataTable MostrarRegistros()
        {
            //comando.Connection = manejador.AbrirConexion();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllSemestres";
            comando.CommandType = CommandType.StoredProcedure;
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        

        #region Methods for tblSemestreDocente
        // CREATE OR UPDATE SEMESTRE TIPO DOCENTE
        public bool CreateSemestreDocente(ClsSemestre _semestre, ClsDocente _docente, ClsTipoDocente _tpDocente)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spAddOrUpdateSemestreTpDocente";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);
                sqlCommand.Parameters.AddWithValue("@idDocente", _docente.IdDocente);
                sqlCommand.Parameters.AddWithValue("@idTpDocente", _tpDocente.IdTipoDocente);
                sqlCommand.Parameters.AddWithValue("@numHoras", _tpDocente.HorasExigibles);
                sqlCommand.Parameters.AddWithValue("@state", _semestre.Estado);

                ObjDataBase.AbrirConexion();
                sqlCommand.ExecuteNonQuery();

                return true;

            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Windows.Forms.MessageBox.Show(sqlException.Message); ;
                return false;

            }
            finally
            {
                ObjDataBase.CerrarConexion();
            }

        }

        public bool UpdateHorasExSemestreDocente_DAL(ClsSemestre _semestre, ClsDocente _docente, ClsTipoDocente _tpDocente)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spUpdateHorasExigiblesSemestreTpDocente";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);
                sqlCommand.Parameters.AddWithValue("@idDocente", _docente.IdDocente);
                sqlCommand.Parameters.AddWithValue("@numHoras", _tpDocente.HorasExigibles);

                // Agregar el parámetro de salida
                SqlParameter outputParameter = new SqlParameter("@result", SqlDbType.Bit);
                outputParameter.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(outputParameter);

                ObjDataBase.AbrirConexion();
                sqlCommand.ExecuteNonQuery();

                bool result = Convert.ToBoolean(outputParameter.Value);

                return result;

            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Windows.Forms.MessageBox.Show(sqlException.Message); ;
                return false;

            }
            finally
            {
                ObjDataBase.CerrarConexion();
            }

        }
        public bool CreateSemestreAsignatura(ClsSemestre _semestre, ClsAsignatura _asignatura)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spAddOrUpdateSemestreAsignatura";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);
                sqlCommand.Parameters.AddWithValue("@idAsignatura", _asignatura.IdAsignatura);
                sqlCommand.Parameters.AddWithValue("@state", _semestre.Estado);

                ObjDataBase.AbrirConexion();
                sqlCommand.ExecuteNonQuery();

                return true;

            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Windows.Forms.MessageBox.Show(sqlException.Message); ;
                return false;

            }
            finally
            {
                ObjDataBase.CerrarConexion();
            }

        }
        #endregion

        public bool CopyAllDataSemestres_DAL(ClsSemestre _semestre1, ClsSemestre _semestre2)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spCopyAllDataBetweenSemestres";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@idSemestreExistente", _semestre1.IdSemestre);
                sqlCommand.Parameters.AddWithValue("@idSemestreNuevo", _semestre2.IdSemestre);

                // Agregar el parámetro de salida
                SqlParameter outputParameter = new SqlParameter("@CopiaExitosa", SqlDbType.Bit);
                outputParameter.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(outputParameter);

                ObjDataBase.AbrirConexion();
                sqlCommand.ExecuteNonQuery();

                bool copiaExitosa = Convert.ToBoolean(outputParameter.Value);

                return copiaExitosa;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return true;

            }
            finally
            {
                ObjDataBase.CerrarConexion();
            }
        }

        public bool CopyHorariosEntreSemestres_DAL(ClsSemestre _semestre1, ClsSemestre _semestre2)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spCopySemestreHorarios";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@idSemestreExistente", _semestre1.IdSemestre);
                sqlCommand.Parameters.AddWithValue("@idSemestreNuevo", _semestre2.IdSemestre);

                // Agregar el parámetro de salida
                SqlParameter outputParameter = new SqlParameter("@CopiaExitosa", SqlDbType.Bit);
                outputParameter.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(outputParameter);

                ObjDataBase.AbrirConexion();
                sqlCommand.ExecuteNonQuery();

                bool copiaExitosa = Convert.ToBoolean(outputParameter.Value);

                return copiaExitosa;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return true;

            }
            finally
            {
                ObjDataBase.CerrarConexion();
            }
        }
        public bool CopyCargasEntreSemestres_DAL(ClsSemestre _semestre1, ClsSemestre _semestre2)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spCopySemestreCargas";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@idSemestreExistente", _semestre1.IdSemestre);
                sqlCommand.Parameters.AddWithValue("@idSemestreNuevo", _semestre2.IdSemestre);

                // Agregar el parámetro de salida
                SqlParameter outputParameter = new SqlParameter("@CopiaExitosa", SqlDbType.Bit);
                outputParameter.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(outputParameter);

                ObjDataBase.AbrirConexion();
                sqlCommand.ExecuteNonQuery();

                bool copiaExitosa = Convert.ToBoolean(outputParameter.Value);

                return copiaExitosa;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return true;

            }
            finally
            {
                ObjDataBase.CerrarConexion();
            }
        }
    }
}
