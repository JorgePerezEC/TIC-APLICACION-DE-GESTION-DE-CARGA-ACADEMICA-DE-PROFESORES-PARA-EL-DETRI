using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Directorio_Datos.DataBase;
using Directorio_Entidades;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Directorio_Datos
{
    public class DAL_GrupoAsignatura
    {
        ManejadorDB ObjDataBase = new ManejadorDB();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        #region CRUD METHODS
        // CREATE GRUPO ASIGNATURA
        public bool CreateGrAsignatura(ClsGrupoAsignatura _grAsignatura)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spAddGrAsignatura";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@idAsig", _grAsignatura.IdAsignatura);
                sqlCommand.Parameters.AddWithValue("@Gr", _grAsignatura.NombreGrupo);

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
        public int CreateGrAsignaturaOut_DAL(ClsGrupoAsignatura _grAsignatura)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spAddGrAsignaturaOut";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@idAsig", _grAsignatura.IdAsignatura);
                sqlCommand.Parameters.AddWithValue("@Gr", _grAsignatura.NombreGrupo);

                SqlParameter insertedIdParam = sqlCommand.Parameters.Add("@InsertedID", SqlDbType.Int);
                insertedIdParam.Direction = ParameterDirection.Output;

                ObjDataBase.AbrirConexion();
                sqlCommand.ExecuteNonQuery();

                int insertedID = (int)insertedIdParam.Value;

                return insertedID;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return 0;

            }
            finally
            {
                ObjDataBase.CerrarConexion();
            }

        }
        // UPDATE GRUPO ASIGNATURA
        public bool UpdateGrAsignatura(ClsGrupoAsignatura _grAsignatura)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spUpdateGrAsignatura";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@id", _grAsignatura.IdGrupoAsignatura);
                sqlCommand.Parameters.AddWithValue("@idAsig", _grAsignatura.IdAsignatura);
                sqlCommand.Parameters.AddWithValue("@Gr", _grAsignatura.NombreGrupo);

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
        // DELETE GRUPO ASIGNATURA
        public bool DeleteGrAsignatura(ClsGrupoAsignatura _grAsignatura)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spDeleteGrAsignatura";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@id", _grAsignatura.IdGrupoAsignatura);

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
        #region LOAD DATA METHODS
        public DataTable MostrarAllRegistros()
        {
            //comando.Connection = manejador.AbrirConexion();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllGrAsignaturas";
            comando.CommandType = CommandType.StoredProcedure;
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarGruposPorAsignatura(ClsAsignatura _objAsignatura)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllGroupsByAsig";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idAsignatura", _objAsignatura.IdAsignatura);

            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarGruposPorAsignaturaCmb_DAL(ClsAsignatura _objAsignatura)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllGroupsByAsigCmb";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idAsignatura", _objAsignatura.IdAsignatura);

            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarGruposPorAsignaturaWHorario_DAL(ClsAsignatura _objAsignatura, ClsSemestre _objSemestre)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllGroupsByAsigWithHorario";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idAsignatura", _objAsignatura.IdAsignatura);
            comando.Parameters.AddWithValue("@idSemestre", _objSemestre.IdSemestre);

            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarAllGruposPorAsignaturaBySemestre_DAL(ClsAsignatura _objAsignatura, ClsSemestre _objSemestre)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllGroupsByAsigBySemestreCmb";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idAsignatura", _objAsignatura.IdAsignatura);
            comando.Parameters.AddWithValue("@idSemestre", _objSemestre.IdSemestre);

            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public int GetIdGrAsignaturaDAL(ClsGrupoAsignatura _grAsignatura)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spGetIdGrAsignatura";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idAsignatura", _grAsignatura.IdAsignatura);
                sqlCommand.Parameters.AddWithValue("@Grupo", _grAsignatura.NombreGrupo);

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
        public string GetAsigLevelByAsigDAL(ClsAsignatura _asignatura)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spGetLevelAsignatura";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idAsignatura", _asignatura.IdAsignatura);

                ObjDataBaseL.AbrirConexion();
                string level = sqlCommand.ExecuteScalar().ToString();

                return level;

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

        public bool VerificarGRexistente_DAL(ClsGrupoAsignatura _grAsignatura)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spVerificarGRexistente";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@idAsig", _grAsignatura.IdAsignatura);
                sqlCommand.Parameters.AddWithValue("@Gr", _grAsignatura.NombreGrupo);

                SqlParameter insertedIdParam = sqlCommand.Parameters.Add("@existeGR", SqlDbType.Int);
                insertedIdParam.Direction = ParameterDirection.Output;

                ObjDataBase.AbrirConexion();
                sqlCommand.ExecuteNonQuery();

                bool resul = (bool)insertedIdParam.Value;

                return resul;

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
        public string GetTypeAsigByAsig_DAL(ClsAsignatura _asignatura)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spGetTypeAsignatura";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idAsignatura", _asignatura.IdAsignatura);

                ObjDataBaseL.AbrirConexion();
                string level = sqlCommand.ExecuteScalar().ToString();

                return level;

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
        public string GetCodeAsigByAsig_DAL(ClsAsignatura _asignatura)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spGetCodeAsignatura";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idAsignatura", _asignatura.IdAsignatura);

                ObjDataBaseL.AbrirConexion();
                string code = sqlCommand.ExecuteScalar().ToString();

                return code;

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

        #endregion
    }
}
