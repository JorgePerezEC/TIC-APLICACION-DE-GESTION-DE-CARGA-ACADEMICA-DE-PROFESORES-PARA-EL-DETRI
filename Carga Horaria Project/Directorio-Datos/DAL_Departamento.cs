using System;
using System.Data;
using System.Data.SqlClient;
using Directorio_Datos.DataBase;
using Directorio_Entidades;

namespace Directorio_Datos
{
    public class DAL_Departamento
    {
        private ManejadorDB ObjDataBase = new ManejadorDB();
        private ClsDepartamento ObjDepartamento = new ClsDepartamento();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        // CRUD METHODS

        // CREATE DEPARTMENT
        public bool CreateDepartamento(string nameDepartament, string email)
        {
            try
            {
                
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spAddDepartamento";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@nameDepa", nameDepartament);
                sqlCommand.Parameters.AddWithValue("@emailDepa", email);

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
        public bool CreateDepartamentoEntity(ClsDepartamento _departamento)
        {
            try
            {
                
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spAddDepartamento";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@nameDepa", _departamento.NombreDepa);
                sqlCommand.Parameters.AddWithValue("@emailDepa", _departamento.EmailDepa);

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
        // UPDATE DEPARTMENT
        public bool UpdateDepartamentoEntity(ClsDepartamento _departamento)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spUpdateDepartamento";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@id", _departamento.IdDepartamento);
                sqlCommand.Parameters.AddWithValue("@nameDepa", _departamento.NombreDepa);
                sqlCommand.Parameters.AddWithValue("@emailDepa", _departamento.EmailDepa);

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
        // DELETE DEPARTMENT
        public bool DeleteDepartamento(int id, string nameDepartament, string email)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spDeleteDepartamento";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@nameDepa", nameDepartament);
                sqlCommand.Parameters.AddWithValue("@emailDepa", email);

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
        public bool DeleteDepartamentoEntity(ClsDepartamento _departamento)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spDeleteDepartamento";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@id", _departamento.IdDepartamento);
                sqlCommand.Parameters.AddWithValue("@nameDepa", _departamento.NombreDepa);
                sqlCommand.Parameters.AddWithValue("@emailDepa", _departamento.EmailDepa);

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
        // Metodo para cargar todos los registros de la tabla tblDepartamento
        public DataTable MostrarRegistros()
        {
            //comando.Connection = manejador.AbrirConexion();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllDepartamentos";
            comando.CommandType = CommandType.StoredProcedure;
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarRegistrosTV()
        {
            //comando.Connection = manejador.AbrirConexion();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadDepartamentosById";
            comando.CommandType = CommandType.StoredProcedure;
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
    }
}
