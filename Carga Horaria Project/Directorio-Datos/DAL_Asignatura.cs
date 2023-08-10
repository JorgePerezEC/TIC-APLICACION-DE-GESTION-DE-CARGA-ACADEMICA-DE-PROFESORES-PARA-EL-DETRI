﻿using System;
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
    public class DAL_Asignatura
    {
        ManejadorDB ObjDataBase = new ManejadorDB();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        ClsCargaHoraria objCargaHoraria = new ClsCargaHoraria();

        #region CRUD METHODS
        // CRUD METHODS
        // CREATE ASIGNATURA
        public bool CreateAsignatura(ClsAsignatura _asignatura, ClsCarrera _carrera)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();   
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spAddAsignatura";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@idCarrera", _carrera.IdCarrera);
                sqlCommand.Parameters.AddWithValue("@nameAsig", _asignatura.NombreAsignatura);
                sqlCommand.Parameters.AddWithValue("@tpAsig", _asignatura.TipoAsignatura);
                sqlCommand.Parameters.AddWithValue("@codAsig", _asignatura.CodigoAsignatura);
                sqlCommand.Parameters.AddWithValue("@hAsigTot", _asignatura.HorasAsignaturaTotales);
                sqlCommand.Parameters.AddWithValue("@hAsigSem", _asignatura.HorasAsignaturaSemanales);
                sqlCommand.Parameters.AddWithValue("@lvlAsig", _asignatura.NivelAsignatura);

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
        // UPDATE ASIGNATURA
        public bool UpdateAsignatura(ClsAsignatura _asignatura, ClsCarrera _carrera)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spUpdateAsignatura";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@id", _asignatura.IdAsignatura);
                sqlCommand.Parameters.AddWithValue("@idCarrera", _carrera.IdCarrera);
                sqlCommand.Parameters.AddWithValue("@nameAsig", _asignatura.NombreAsignatura);
                sqlCommand.Parameters.AddWithValue("@tpAsig", _asignatura.TipoAsignatura);
                sqlCommand.Parameters.AddWithValue("@codAsig", _asignatura.CodigoAsignatura);
                sqlCommand.Parameters.AddWithValue("@hAsigTot", _asignatura.HorasAsignaturaTotales);
                sqlCommand.Parameters.AddWithValue("@hAsigSem", _asignatura.HorasAsignaturaSemanales);
                sqlCommand.Parameters.AddWithValue("@lvlAsig", _asignatura.NivelAsignatura);

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
        // DELETE ASIGNATURA
        public bool DeleteAsignatura(ClsAsignatura _asignatura)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = ObjDataBase.sqlConexion;
                sqlCommand.CommandText = "spDeleteAsignatura";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@id", _asignatura.IdAsignatura);

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
        public DataTable MostrarRegistros()
        {
            //comando.Connection = manejador.AbrirConexion();
            var list = new List<ClsAsignatura>();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllAsignaturas";
            comando.CommandType = CommandType.StoredProcedure;
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();

            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarRegistrosToCmbDAL()
        {
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllAsignaturasCmb";
            comando.CommandType = CommandType.StoredProcedure;
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarAsignaturasConGrupos(ClsSemestre _semestre)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllAsignaturasWGroups";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarAsignaturasConGrupos_ByCarrera_DAL(ClsSemestre _semestre, ClsCarrera _carrera)
        {
            //comando.Connection = manejador.AbrirConexion();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllAsignaturasWGroups_ByCarrera";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);
            comando.Parameters.AddWithValue("@idCarrera", _carrera.IdCarrera);
            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarRegistrosByIdSemestre(ClsSemestre _semestre)
        {
            //comando.Connection = manejador.AbrirConexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spReadAllSmstreAsignaturaBySemestre";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);

            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarRegistrosAsignaturaWithDocenteByIdSemestre(ClsSemestre _semestre)
        {
            //comando.Connection = manejador.AbrirConexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spGetAsignaturaGrBySemestreWithDocente_Reporte";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);

            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarRegistrosAsignaturaWithOutDocenteByIdSemestre(ClsSemestre _semestre)
        {
            //comando.Connection = manejador.AbrirConexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = ObjDataBase.sqlConexion;
            comando.CommandText = "spGetAsignaturaGrBySemestreWithOutDocente_Reporte";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idSemestre", _semestre.IdSemestre);

            ObjDataBase.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            ObjDataBase.CerrarConexion();
            return tabla;
        }
    }
}
