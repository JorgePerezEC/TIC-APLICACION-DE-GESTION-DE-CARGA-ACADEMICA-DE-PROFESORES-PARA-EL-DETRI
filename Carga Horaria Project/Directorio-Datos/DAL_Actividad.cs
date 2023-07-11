using System;
using System.Data;
using System.Data.SqlClient;
using Directorio_Datos.DataBase;
using Directorio_Entidades;

namespace Directorio_Datos
{
    public class DAL_Actividad
    {
        ManejadorDB ObjDataBase = new ManejadorDB();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        // CRUD METHODS

        // CREATE ACTIVIDAD
        public bool CreateActividad(ClsActividad _actividad)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spAddActividad";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@idTpAct", _actividad.IdTpActividad);
                sqlCommand.Parameters.AddWithValue("@nameAct", _actividad.NombreActividad);
                sqlCommand.Parameters.AddWithValue("@horasAct", _actividad.HorasSemana);
                sqlCommand.Parameters.AddWithValue("@horasTAct", _actividad.HorasTotalesAct);

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
        // UPDATE ACTIVIDAD
        public bool UpdateActividad(ClsActividad _actividad)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spUpdateActividad";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@id", _actividad.IdActividad);
                sqlCommand.Parameters.AddWithValue("@idTpAct", _actividad.IdTpActividad);
                sqlCommand.Parameters.AddWithValue("@nameAct", _actividad.NombreActividad);
                sqlCommand.Parameters.AddWithValue("@horasAct", _actividad.HorasSemana);
                sqlCommand.Parameters.AddWithValue("@horasTAct", _actividad.HorasTotalesAct);

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
        // DELETE ACTIVIDAD
        public bool DeleteActividad(ClsActividad _actividad)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spDeleteActividad";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@id", _actividad.IdActividad);

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
        #region METHODS TO SHOW DATA
        // Metodo para cargar todos los registros de la tabla tblActividades
        public DataTable MostrarRegistros()
        {
            //comando.Connection = manejador.AbrirConexion();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllActividades";
            comando.CommandType = CommandType.StoredProcedure;
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarTpActividades()
        {
            //comando.Connection = manejador.AbrirConexion();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllTipoActividades";
            comando.CommandType = CommandType.StoredProcedure;
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        //Listas Actividades en Cmb no existentes en CargaHoraria especifica
        public DataTable GetAllActividadesGralDAL(ClsCargaHoraria _crgH, ClsTipoActividad _actividadTp)
        {
            //comando.Connection = manejador.AbrirConexion();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllActividadesNotInCargaHoraria";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idCargaHoraria", _crgH.IdCargaHoraria);
            comando.Parameters.AddWithValue("@tipo", _actividadTp.NombreTpActividad);

            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable GetActividadesDocenciaD11DAL()
        {
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllDocenciaD11Actividades";
            comando.CommandType = CommandType.StoredProcedure;
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable GetActividadesDocenciaF11DAL()
        {
            //comando.Connection = manejador.AbrirConexion();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllDocenciaF11Actividades";
            comando.CommandType = CommandType.StoredProcedure;
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable GetActividadesGestionDAL()
        {
            //comando.Connection = manejador.AbrirConexion();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllGestionActividades";
            comando.CommandType = CommandType.StoredProcedure;
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable GetActividadesInvestigacionDAL()
        {
            //comando.Connection = manejador.AbrirConexion();
            //SqlCommand comando = new SqlCommand();
            SqlCommand comando = new SqlCommand();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllInvestigationActividades";
            comando.CommandType = CommandType.StoredProcedure;
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        //Metodo para obtener el valor de las horas de las actividades
        public int GetHorasActividadDAL(ClsActividad _actividad)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spGetHoraActividad";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idActividad", _actividad.IdActividad);

                ObjDataBaseL.AbrirConexion();
                int horaSemanal = (int)sqlCommand.ExecuteScalar();

                return horaSemanal;

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
        public int GetHorasTotalesActividadDAL(ClsActividad _actividad)
        {
            ManejadorDB ObjDataBaseL = new ManejadorDB();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBaseL.sqlConexion;
                sqlCommand.CommandText = "spGetHorasTotalesActividad";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idActividad", _actividad.IdActividad);

                ObjDataBaseL.AbrirConexion();
                int horasTotales = (int)sqlCommand.ExecuteScalar();

                return horasTotales;

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

    }
}
