using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Librerías usadas
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;
using System.Runtime.Intrinsics.X86;

namespace Directorio_Datos.DataBase
{
    public class ManejadorDB
    {

        private static string dbName = "dbCargaHorariaAgo15"; //dbCargaHorariaJune
        private static string pcName = "ASUS-GEORGE-AMA";
        public SqlConnection sqlConexion = new SqlConnection(@"Data Source=" + pcName + "\\SQLEXPRESS;Initial Catalog=" + dbName + ";Integrated Security=True;MultipleActiveResultSets=True");
        //private string connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;
        //public SqlConnection sqlConexion = new SqlConnection(@"Data Source=ASUS-GEORGE-AMA\\SQLEXPRESS;Initial Catalog=dbCargaHorariaJuly26; Integrated Security=True;MultipleActiveResultSets=True");
        //public SqlConnection sqlConexion = new SqlConnection(connectionString);
        // conectado
        // con entorno conectado para conexion base de datos

        //private string connectionString;
        //public SqlConnection sqlConexion;

        //public ManejadorDB()
        //{
        //    //connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;
        //    //connectionString = ConfigurationSettings.AppSettings["MyDatabaseConnection"];

        //    //sqlConexion = new SqlConnection(connectionString);
        //}


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
