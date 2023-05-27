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
        public bool CreateHorarioAsig(ClsHorarioGrAsignatura _grHorariosAsignaturas)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spAddHorarioAsig";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@idGr", _grHorariosAsignaturas.IdGrupo);
                sqlCommand.Parameters.AddWithValue("@hIni", _grHorariosAsignaturas.HoraInicio.ToString());
                sqlCommand.Parameters.AddWithValue("@hFin", _grHorariosAsignaturas.HoraFin.ToString());
                sqlCommand.Parameters.AddWithValue("@day", _grHorariosAsignaturas.DiaSemana);

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
    }
}
