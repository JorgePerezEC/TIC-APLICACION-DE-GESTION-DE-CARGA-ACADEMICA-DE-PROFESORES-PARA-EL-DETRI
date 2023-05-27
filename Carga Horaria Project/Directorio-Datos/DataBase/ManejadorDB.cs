﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Librerías usadas
using System.Data;
using System.Data.SqlClient;

namespace Directorio_Datos.DataBase
{
    public class ManejadorDB
    {
        #region Comented

        //private SqlConnection _objSqlConnection;
        //private SqlDataAdapter _objSqlDataAdapter;
        //private SqlCommand _objSqlCommand;
        //private DataSet _dsResultados;  //Almacena datos en una tabla
        //private DataTable _dtParametros; //Parametros de los procedimientos almacenados
        //private string _nombreTabla, _nombreSP, _mensajeErrorDB, _valorScalar, _nombreDB;
        //private bool _scalar;

        //#endregion

        //#region Variables publicas
        //public SqlConnection ObjSqlConnection { get => _objSqlConnection; set => _objSqlConnection = value; }
        //public SqlDataAdapter ObjSqlDataAdapter { get => _objSqlDataAdapter; set => _objSqlDataAdapter = value; }
        //public SqlCommand ObjSqlCommand { get => _objSqlCommand; set => _objSqlCommand = value; }
        //public DataSet DsResultados { get => _dsResultados; set => _dsResultados = value; }
        //public DataTable DtParametros { get => _dtParametros; set => _dtParametros = value; }
        //public string NombreTabla { get => _nombreTabla; set => _nombreTabla = value; }
        //public string NombreSP { get => _nombreSP; set => _nombreSP = value; }
        //public string MensajeErrorDB { get => _mensajeErrorDB; set => _mensajeErrorDB = value; }
        //public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        //public string NombreDB { get => _nombreDB; set => _nombreDB = value; }
        //public bool Scalar { get => _scalar; set => _scalar = value; }
        //#endregion

        //#region Constructores
        //public ManejadorDB()
        //{
        //    DtParametros = new DataTable("SpParametros");
        //    DtParametros.Columns.Add("Nombre"); //[0]
        //    DtParametros.Columns.Add("TipoDato");//[1]
        //    DtParametros.Columns.Add("Valor");//[2]

        //    //NombreDB = string.Empty;
        //    NombreDB = "dbCargaHorariaData";

        //}
        //#endregion

        //#region Métodos Privados
        //private void CrearConexionDB(ref ManejadorDB ObjDataBase)
        //{
        //    switch (ObjDataBase.NombreDB) 
        //    {
        //        case "dbCargaHorariaData":
        //            ObjDataBase.ObjSqlConnection = new SqlConnection(@"Data Source=ASUS-GEORGE-AMA\SQLEXPRESS;Initial Catalog=dbCargaHorariaData;Integrated Security=True;MultipleActiveResultSets=True");
        //            break;
        //    }
        //}
        //private void ValidarConexionDB(ref ManejadorDB ObjDataBase)
        //{
        //    if (ObjDataBase.ObjSqlConnection.State == ConnectionState.Closed)
        //    {
        //        ObjDataBase.ObjSqlConnection.Open();
        //    }
        //    else {
        //        ObjDataBase.ObjSqlConnection.Close();
        //        ObjDataBase.ObjSqlConnection.Dispose();
        //    }
        //}
        //private void AgregarParametros(ref ManejadorDB ObjDataBase)
        //{
        //    if (ObjDataBase.DtParametros != null)
        //    {
        //        SqlDbType TipoDatoSql = new SqlDbType();

        //        foreach (DataRow item in ObjDataBase.DtParametros.Rows)
        //        {
        //            switch (item[1])//Validar tipo de dato
        //            {
        //                case "1":
        //                    TipoDatoSql = SqlDbType.Bit;
        //                    break;
        //                case "2":
        //                    TipoDatoSql = SqlDbType.TinyInt;
        //                    break;
        //                case "3":
        //                    TipoDatoSql = SqlDbType.SmallInt;
        //                    break;
        //                case "4":
        //                    TipoDatoSql = SqlDbType.Int;
        //                    break;
        //                case "5":
        //                    TipoDatoSql = SqlDbType.BigInt;
        //                    break;
        //                case "6":
        //                    TipoDatoSql = SqlDbType.Decimal;
        //                    break;
        //                case "7":
        //                    TipoDatoSql = SqlDbType.SmallMoney;
        //                    break;
        //                case "8":
        //                    TipoDatoSql = SqlDbType.Money;
        //                    break;
        //                case "9":
        //                    TipoDatoSql = SqlDbType.Float;
        //                    break;
        //                case "10":
        //                    TipoDatoSql = SqlDbType.Real;
        //                    break;
        //                case "11":
        //                    TipoDatoSql = SqlDbType.Date;
        //                    break;
        //                case "12":
        //                    TipoDatoSql = SqlDbType.Time;
        //                    break;
        //                case "13":
        //                    TipoDatoSql = SqlDbType.SmallDateTime;
        //                    break;
        //                case "14":
        //                    TipoDatoSql = SqlDbType.Char;
        //                    break;
        //                case "15":
        //                    TipoDatoSql = SqlDbType.NChar;
        //                    break;
        //                case "16":
        //                    TipoDatoSql = SqlDbType.VarChar;
        //                    break;
        //                case "17":
        //                    TipoDatoSql = SqlDbType.NVarChar;
        //                    break;
        //                case "18":
        //                    TipoDatoSql = SqlDbType.Time;
        //                    break;
        //                default:
        //                    break;
        //            }

        //            if (ObjDataBase.Scalar)
        //            {
        //                if (item[2].ToString().Equals(string.Empty))
        //                {
        //                    ObjDataBase.ObjSqlCommand.Parameters.Add(item[0].ToString(), TipoDatoSql).Value = DBNull.Value;
        //                }
        //                else
        //                {
        //                    ObjDataBase.ObjSqlCommand.Parameters.Add(item[0].ToString(), TipoDatoSql).Value = item[2].ToString;
        //                }
        //            }
        //            else
        //            {
        //                if (item[2].ToString().Equals(string.Empty))
        //                {
        //                    ObjDataBase.ObjSqlDataAdapter.SelectCommand.Parameters.Add(item[0].ToString(), TipoDatoSql).Value = DBNull.Value;
        //                }
        //                else
        //                {
        //                    ObjDataBase.ObjSqlDataAdapter.SelectCommand.Parameters.Add(item[0].ToString(), TipoDatoSql).Value = item[2].ToString;
        //                }
        //            }
        //        }
        //    }
        //}
        //private void PrepararConexionDB(ref ManejadorDB ObjDataBase)
        //{
        //    CrearConexionDB(ref ObjDataBase);
        //    ValidarConexionDB(ref ObjDataBase);
        //}
        //private void EjecutarDataAdapterDB(ref ManejadorDB ObjDataBase)
        //{
        //    try
        //    {
        //        PrepararConexionDB(ref ObjDataBase);

        //        ObjDataBase.ObjSqlDataAdapter = new SqlDataAdapter(ObjDataBase.NombreSP, ObjDataBase.ObjSqlConnection);
        //        ObjDataBase.ObjSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        AgregarParametros(ref ObjDataBase);
        //        ObjDataBase.DsResultados = new DataSet();
        //        ObjDataBase.ObjSqlDataAdapter.Fill(ObjDataBase.DsResultados, ObjDataBase.NombreTabla);
        //    }
        //    catch (Exception ex)
        //    {
        //        ObjDataBase.MensajeErrorDB = ex.Message.ToString();
        //    }
        //    finally
        //    {
        //        if(ObjDataBase.ObjSqlConnection.State == ConnectionState.Open)
        //        {
        //            ValidarConexionDB(ref ObjDataBase);
        //        }
        //    }

        //}
        //private void EjecutarCommand(ref ManejadorDB ObjDataBase)
        //{
        //    try
        //    {
        //        PrepararConexionDB(ref ObjDataBase);
        //        ObjDataBase.ObjSqlCommand = new SqlCommand(ObjDataBase.NombreSP, ObjDataBase.ObjSqlConnection)
        //        {
        //            CommandType = CommandType.StoredProcedure
        //        };
        //        AgregarParametros(ref ObjDataBase);

        //        if (ObjDataBase.Scalar)
        //        {
        //            ObjDataBase.ValorScalar = ObjDataBase.ObjSqlCommand.ExecuteScalar().ToString().Trim();
        //        }
        //        else
        //        {
        //            ObjDataBase.ObjSqlCommand.ExecuteNonQuery();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ObjDataBase.MensajeErrorDB = ex.Message.ToString();
        //    }
        //    finally
        //    {
        //        if (ObjDataBase.ObjSqlConnection.State == ConnectionState.Open)
        //        {
        //            ValidarConexionDB(ref ObjDataBase);
        //        }
        //    }
        //}
        //#endregion

        //#region Métodos Públicos
        //public void CRUD(ref ManejadorDB ObjDataBase)
        //{
        //    if (ObjDataBase.Scalar)
        //    {
        //        EjecutarCommand(ref ObjDataBase);
        //    }
        //    else
        //    {
        //        EjecutarDataAdapterDB(ref ObjDataBase);
        //    }
        //}
        #endregion
        private static string dbName = "dbCargaHorariaMay";
        private static string pcName = "ASUS-GEORGE-AMA";
        public SqlConnection sqlConexion = new SqlConnection(@"Data Source="+ pcName + "\\SQLEXPRESS;Initial Catalog=" + dbName + ";Integrated Security=True;MultipleActiveResultSets=True");

        // conectado
        // con entorno conectado para conexion base de datos
        public void AbrirConexion()
        {
            if (sqlConexion.State == ConnectionState.Closed)
                sqlConexion.Open();
        }
        public void CerrarConexion()
        {
            if (sqlConexion.State == ConnectionState.Open)
                sqlConexion.Close();
        }
    }
}
