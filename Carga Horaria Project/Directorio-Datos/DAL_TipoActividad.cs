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
    public class DAL_TipoActividad
    {
        #region Declaración de variables a utilizar
        ManejadorDB ObjDataBase = new ManejadorDB();
        ClsTipoActividad ObjTipoActividad= new ClsTipoActividad();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        #endregion

        #region CRUD Methods
        // CREATE TIPO ACTIVIDAD
        public bool CreateTipoActividad(ClsTipoActividad _tipoActividad)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spAddTipoActividad";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@nameTpActiv", _tipoActividad.NombreTpActividad);
                sqlCommand.Parameters.AddWithValue("@descripActividad", _tipoActividad.DescripcionTpActividad);

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
        // UPDATE TIPO ACTIVIDAD
        public bool UpdateTipoActividad(ClsTipoActividad _tipoActividad)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spUpdateTipoActividad";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@id", _tipoActividad.IdTipoActividad);
                sqlCommand.Parameters.AddWithValue("@nameTpActiv", _tipoActividad.NombreTpActividad);
                sqlCommand.Parameters.AddWithValue("@descripActividad", _tipoActividad.DescripcionTpActividad);

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
        // DELETE TIPO ACTIVIDAD
        public bool DeleteTipoActividad(ClsTipoActividad _tipoActividad)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spDeleteTipoActividad";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@id", _tipoActividad.IdTipoActividad);
                sqlCommand.Parameters.AddWithValue("@nameTpActiv", _tipoActividad.NombreTpActividad);
                sqlCommand.Parameters.AddWithValue("@descripActividad", _tipoActividad.DescripcionTpActividad);

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

        #region Public Methods
        // Metodo para cargar todos los registros de la tabla tblDepartamento
        public DataTable MostrarRegistros()
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
        #endregion
    }
}
