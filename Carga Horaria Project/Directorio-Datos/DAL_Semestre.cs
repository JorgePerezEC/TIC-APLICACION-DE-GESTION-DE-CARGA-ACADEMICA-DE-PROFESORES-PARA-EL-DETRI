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
    }
}
