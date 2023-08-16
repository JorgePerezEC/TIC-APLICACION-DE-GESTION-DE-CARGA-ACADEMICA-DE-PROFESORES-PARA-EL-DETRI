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
    public class DAL_HorarioAsignatura
    {
        ManejadorDB ObjDataBase = new ManejadorDB();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        #region CRUD METHODS
        // CREATE HORARIO ASIGNATURA
        public bool CreateHorarioAsig(ClsSemestre _semestre ,ClsHorarioGrAsignatura _grHorariosAsignaturas)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spAddHorarioAsig";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                bool resul;

                sqlCommand.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);
                sqlCommand.Parameters.AddWithValue("@idGrAsig", _grHorariosAsignaturas.IdGrAsig);
                sqlCommand.Parameters.AddWithValue("@horaInicio", _grHorariosAsignaturas.HoraInicio.ToString());
                sqlCommand.Parameters.AddWithValue("@horaFin", _grHorariosAsignaturas.HoraFin.ToString());
                sqlCommand.Parameters.AddWithValue("@dia", _grHorariosAsignaturas.IdDiaSemana);

                SqlParameter resultadoParam = new SqlParameter("@resultado", SqlDbType.Bit);
                resultadoParam.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(resultadoParam);


                ObjDataBase.AbrirConexion();
                sqlCommand.ExecuteNonQuery();

                bool resultado = (bool)resultadoParam.Value;

                return resultado;

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
        // UPDATE HORARIO ASIGNATURA
        public bool UpdateHorarioAsig(ClsHorarioGrAsignatura _grHorariosAsignaturas)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spUpdateHorarioAsig";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@id", _grHorariosAsignaturas.IdHorario);
                sqlCommand.Parameters.AddWithValue("@idGr", _grHorariosAsignaturas.IdGrupo);
                sqlCommand.Parameters.AddWithValue("@hIni", _grHorariosAsignaturas.HoraInicio);
                sqlCommand.Parameters.AddWithValue("@hFin", _grHorariosAsignaturas.HoraFin);
                sqlCommand.Parameters.AddWithValue("@day", _grHorariosAsignaturas.DiaSemana);

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
        // DELETE HORARIO ASIGNATURA
        public bool DeleteHorarioAsig(ClsHorarioGrAsignatura _grHorariosAsignaturas)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spDeleteHorarioAsig";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@id", _grHorariosAsignaturas.IdHorario);

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
        #endregion

        public bool VerificarCruceHorario_DAL(ClsCargaHoraria _cargaHoraria, ClsGrupoAsignatura _grAsignatura)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spVerificarConflictoHorario";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@idCargaHoraria", _cargaHoraria.IdCargaHoraria);
                sqlCommand.Parameters.AddWithValue("@idGrAsig", _grAsignatura.IdGrupoAsignatura);

                // Agregar el parámetro de salida
                SqlParameter outputParameter = new SqlParameter("@ConflictoHorario", SqlDbType.Bit);
                outputParameter.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(outputParameter);

                ObjDataBase.AbrirConexion();
                sqlCommand.ExecuteNonQuery();

                bool conflictoHorario = Convert.ToBoolean(outputParameter.Value);

                return conflictoHorario;

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

        public bool VerificarHorasSemanales_DAL(ClsAsignatura _asignatura, ClsGrupoAsignatura _grAsignatura)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spVerificarHorarioWithNumHorasAsignatura";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@idGrAsig", _grAsignatura.IdGrupoAsignatura);
                sqlCommand.Parameters.AddWithValue("@horasIngresadas", _asignatura.HorasAsignaturaSemanales);

                // Agregar el parámetro de salida
                SqlParameter outputParameter = new SqlParameter("@resultado", SqlDbType.Bit);
                outputParameter.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(outputParameter);

                ObjDataBase.AbrirConexion();
                sqlCommand.ExecuteNonQuery();

                bool conflictoHorario = Convert.ToBoolean(outputParameter.Value);

                return conflictoHorario;

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
        public DataTable MostrarAllRegistros()
        {
            //comando.Connection = manejador.AbrirConexion();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllHorariosAsignaturas";
            comando.CommandType = CommandType.StoredProcedure;
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }

        public DataTable GetHorariosByAsignaturaGR_DAL(ClsSemestre _semestre, ClsGrupoAsignatura _grAsignatura)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spGetAllHorariosByGRAsig";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);
            comando.Parameters.AddWithValue("@idGrAsig", _grAsignatura.IdGrupoAsignatura);

            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable GetHorariosByAsignaturaGRView_DAL(ClsSemestre _semestre, ClsGrupoAsignatura _grAsignatura)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spGetAllHorariosByGRAsigViewer";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);
            comando.Parameters.AddWithValue("@idGrAsig", _grAsignatura.IdGrupoAsignatura);

            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
    }
}
