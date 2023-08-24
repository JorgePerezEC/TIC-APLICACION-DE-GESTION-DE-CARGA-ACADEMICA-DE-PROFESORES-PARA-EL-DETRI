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
using System.Diagnostics;
//using Microsoft.Extensions.Configuration;

namespace Directorio_Datos.DataBase
{
    public class ManejadorDB
    {
        private string? connectionString;

        //private static string dbName = "dbCargaHorariaTICtest"; //dbCargaHorariaJune
        //private static string pcName = "ASUS-GEORGE-AMA";
        //public SqlConnection sqlConexion = new SqlConnection(@"Data Source=" + pcName + "\\SQLEXPRESS;Initial Catalog=" + dbName + ";Integrated Security=True;MultipleActiveResultSets=True");
        //MessageBox("Cadena de Conexión: " + ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString);
        
        public SqlConnection sqlConexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString);


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


        //public ManejadorDB()
        //{
        //    if (Program.Configuration != null)
        //    {
        //        var mySettings = Program.Configuration.GetSection("SystemSettings").Get<SystemSettings>();

        //        if (mySettings != null)
        //        {
        //            connectionString = mySettings.CorreoElectronico;
        //            //password = mySettings.PasswordCorreo;
        //        }
        //    }
        //}
    }
}
