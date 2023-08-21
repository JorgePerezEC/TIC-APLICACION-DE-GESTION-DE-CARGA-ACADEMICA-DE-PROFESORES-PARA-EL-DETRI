using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Directorio_Datos.DataBase;
using Directorio_Entidades;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;

namespace Directorio_Datos
{
    public class DAL_TipoDocente
    {
        ManejadorDB ObjDataBase = new ManejadorDB();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        // CRUD METHODS
        #region Public Methods
        // CREATE TIPO DOCENTE
        public bool CreateTipoDocente(ClsTipoDocente _tipoDocente)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spAddTipoDocente";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@nameTP", _tipoDocente.NombreTipoDocente);
                sqlCommand.Parameters.AddWithValue("@numHorasSem", _tipoDocente.HorasExigibles);

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
        
        public bool CreateDocenteWHorasExigibles_DAL(ClsTipoDocente _tipoDocente, ClsSemestre _semestre, ClsDocente _docente)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spAddSemestreTpDocente";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@idTpDocente", _tipoDocente.IdTipoDocente);
                sqlCommand.Parameters.AddWithValue("@idSmstr", _semestre.IdSemestre);
                sqlCommand.Parameters.AddWithValue("@idDocente", _docente.IdDocente);
                sqlCommand.Parameters.AddWithValue("@numHSemstre", _tipoDocente.HorasExigibles);


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
        // UPDATE TIPO DOCENTE
        public bool UpdateTipoDocente(ClsTipoDocente _tipoDocente)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spUpdateTipoDocente";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@id", _tipoDocente.IdTipoDocente);
                sqlCommand.Parameters.AddWithValue("@nameTP", _tipoDocente.NombreTipoDocente);
                sqlCommand.Parameters.AddWithValue("@numHorasSem", _tipoDocente.HorasExigibles);

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
        public bool UpdateDocenteWHorasExigibles_DAL(ClsTipoDocente _tipoDocente, ClsSemestre _semestre, ClsDocente _docente)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spUpdateSemestreTpDocente";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@id", _tipoDocente.IdSemestreTipoDocente);
                sqlCommand.Parameters.AddWithValue("@idTpDocente", _tipoDocente.IdTipoDocente);
                sqlCommand.Parameters.AddWithValue("@idSmstr", _semestre.IdSemestre);
                sqlCommand.Parameters.AddWithValue("@idDocente", _docente.IdDocente);
                sqlCommand.Parameters.AddWithValue("@numHSemstre", _tipoDocente.HorasExigibles);


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
        // DELETE TIPO DOCENTE
        public bool DeleteTipoDocente(ClsTipoDocente _tipoDocente)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spDeleteTipoDocente";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@id", _tipoDocente.IdTipoDocente);

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
        public bool DeleteDocenteWithHorasExig_DAL(ClsTipoDocente _tipoDocente)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spDeleteSemestreTpDocente";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@id", _tipoDocente.IdSemestreTipoDocente);

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

        // Metodo para cargar todos los registros de la tabla tblTipoDocente
        public DataTable MostrarRegistros()
        {
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllTipoDocentes";
            comando.CommandType = CommandType.StoredProcedure;
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarRegistrosCmb()
        {
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadTipoDocentesCmb";
            comando.CommandType = CommandType.StoredProcedure;
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarRegistrosHorasExBySemestre(ClsSemestre _semestre)
        {
            try
            {
                comando.Connection = ObjDataBase.sqlConexion;
                comando.CommandText = "spReadAllDocentesWithHorasExigiblesBySemestre";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);
                ObjDataBase.AbrirConexion();
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                //ObjDataBase.CerrarConexion();
                return tabla;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return null;

            }
            finally
            {
                ObjDataBase.CerrarConexion();
            }
        }
        public int GetHorasExigiblesByTpDocente_DAL(ClsTipoDocente _tpDocente)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spGetHorasExByTpDocente";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idTpDocente", _tpDocente.IdTipoDocente);

                ObjDataBaseL.AbrirConexion();
                int numHoras = (int)sqlCommand.ExecuteScalar();

                return numHoras;

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

        public int GetTipoDocenteHoras_DAL(ClsSemestre _semestre, ClsTipoDocente _tpDocente)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spGetHorasSemestrales";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idTipoDocente", _tpDocente.IdTipoDocente);
                sqlCommand.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);

                ObjDataBase.AbrirConexion();
                int numHoras = (int)sqlCommand.ExecuteScalar();

                return numHoras;

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
                ObjDataBase.CerrarConexion();
            }
        }
        public DataTable GetTipoDocenteHorasAll_DAL(ClsSemestre _semestre)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spGetHorasExigiblesDocentesBySemestre";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);

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
            finally
            {
                ObjDataBase.CerrarConexion();
            }
        }
        public DataTable GetInfoTipoDocenteByName_DAL(ClsSemestre _semestre, ClsTipoDocente _tpDocente)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spGetDataHorasExigiblesDocentesBySemestreAndName";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);
                sqlCommand.Parameters.AddWithValue("@nombreTipoDocente", _tpDocente.NombreTipoDocente);

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
            finally
            {
                ObjDataBase.CerrarConexion();
            }
        }
        public bool AddOrUpdateTipoDocente_Semstre_DAL(ClsTipoDocente _tipoDocente, ClsSemestre _semestre)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spAddTipoDocenteSemestre";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@idTipoDocente", _tipoDocente.IdTipoDocente);
                sqlCommand.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);
                sqlCommand.Parameters.AddWithValue("@numHorasSemestrales", _tipoDocente.HorasExigibles);


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
    }
}
