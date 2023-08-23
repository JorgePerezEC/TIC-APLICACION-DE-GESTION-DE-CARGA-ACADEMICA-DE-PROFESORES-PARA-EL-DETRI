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
    public class DAL_Proyecto
    {
        ManejadorDB ObjDataBase = new ManejadorDB();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        // CRUD METHODS

        // CREATE SEMESTRE
        public bool CreateProyecto (ClsProyecto _proyecto)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spAddProyecto";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@codigoProyecto", _proyecto.Codigo);
                sqlCommand.Parameters.AddWithValue("@nombreProyecto", _proyecto.NombreProyecto);
                sqlCommand.Parameters.AddWithValue("@fechaInicio", _proyecto.DiaInicio.ToString("yyyy-MM-dd"));
                sqlCommand.Parameters.AddWithValue("@fechaFin", _proyecto.DiaFin.ToString("yyyy-MM-dd"));
                sqlCommand.Parameters.AddWithValue("@presupuesto", _proyecto.Presupuesto);
                sqlCommand.Parameters.AddWithValue("@tipoProyecto", _proyecto.Tipo);
                sqlCommand.Parameters.AddWithValue("@urlAval", _proyecto.Url);

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
        public bool UpdateProyecto(ClsProyecto _proyecto)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spUpdateProyecto";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@idProyecto", _proyecto.IdProyecto);
                sqlCommand.Parameters.AddWithValue("@codigoProyecto", _proyecto.Codigo);
                sqlCommand.Parameters.AddWithValue("@nombreProyecto", _proyecto.NombreProyecto);
                sqlCommand.Parameters.AddWithValue("@fechaInicio", _proyecto.DiaInicio.ToString("yyyy-MM-dd"));
                sqlCommand.Parameters.AddWithValue("@fechaFin", _proyecto.DiaFin.ToString("yyyy-MM-dd"));
                sqlCommand.Parameters.AddWithValue("@presupuesto", _proyecto.Presupuesto);
                sqlCommand.Parameters.AddWithValue("@tipoProyecto", _proyecto.Tipo);
                sqlCommand.Parameters.AddWithValue("@urlAval", _proyecto.Url);

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
        public bool DeleteProyecto(ClsProyecto _proyecto)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spDeleteProyecto";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@idProyecto", _proyecto.IdProyecto);

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
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = ObjDataBase.sqlConexion;
                comando.CommandText = "spReadAllProyectos";
                comando.CommandType = CommandType.StoredProcedure;
                ObjDataBase.AbrirConexion();
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                ObjDataBase.CerrarConexion();
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
        public DataTable GetProjectInfo_DAL(ClsActividad _actividad)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = ObjDataBase.sqlConexion;
                comando.CommandText = "spGetProjectInfoFromActivity";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idActividad", _actividad.IdActividad);
                ObjDataBase.AbrirConexion();
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                ObjDataBase.CerrarConexion();
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

    }
}
