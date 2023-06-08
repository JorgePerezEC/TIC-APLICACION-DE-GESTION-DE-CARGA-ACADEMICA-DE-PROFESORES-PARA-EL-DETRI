using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Directorio_Datos.DataBase;
using Directorio_Entidades;

namespace Directorio_Datos
{
    public class DAL_Docente
    {
        ManejadorDB ObjDataBase = new ManejadorDB();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        // CRUD METHODS
        // CREATE DOCENTE
        public bool CreateDocente(ClsDocente _docente)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spAddDocente";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@idDepa", _docente.IdDepa);
                sqlCommand.Parameters.AddWithValue("@name1", _docente.Nombre1Docente);
                sqlCommand.Parameters.AddWithValue("@name2", _docente.Nombre2Docente);
                sqlCommand.Parameters.AddWithValue("@apellido1", _docente.Apellido1Docente);
                sqlCommand.Parameters.AddWithValue("@apellido2", _docente.Apellido2Docente);
                sqlCommand.Parameters.AddWithValue("@tituloDoc", _docente.TituloDocente);

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
        // UPDATE DOCENTE
        public bool UpdateDocente(ClsDocente _docente)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spUpdateDocente";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@id", _docente.IdDocente);
                sqlCommand.Parameters.AddWithValue("@idDepa", _docente.IdDepa);
                sqlCommand.Parameters.AddWithValue("@name1", _docente.Nombre1Docente);
                sqlCommand.Parameters.AddWithValue("@name2", _docente.Nombre2Docente);
                sqlCommand.Parameters.AddWithValue("@apellido1", _docente.Apellido1Docente);
                sqlCommand.Parameters.AddWithValue("@apellido2", _docente.Apellido2Docente);
                sqlCommand.Parameters.AddWithValue("@tituloDoc", _docente.TituloDocente);

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
        // DELETE DOCENTE
        public bool DeleteDocente(ClsDocente _docente)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spDeleteDocente";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@id", _docente.IdDocente);

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

        public DataTable MostrarRegistros()
        {
            //comando.Connection = manejador.AbrirConexion();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllDocentes";
            comando.CommandType = CommandType.StoredProcedure;
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarDocentesNombresCompletos()
        {
            //comando.Connection = manejador.AbrirConexion();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllDocentesAllNames";
            comando.CommandType = CommandType.StoredProcedure;
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarDepartamentos()
        {
            //comando.Connection = manejador.AbrirConexion();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllDepartamentos2Carrera";
            comando.CommandType = CommandType.StoredProcedure;
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarRegistrosById(ClsDepartamento _depa, ClsSemestre _semestre)
        {
            //comando.Connection = manejador.AbrirConexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spDocentesByIdDepaWHorasExigiblesTV";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idDepa", _depa.IdDepartamento);
            comando.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);

            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
    }
}
