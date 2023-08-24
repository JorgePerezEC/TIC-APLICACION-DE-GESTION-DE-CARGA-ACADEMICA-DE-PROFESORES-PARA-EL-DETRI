using System;
using System.Collections.Generic;
using System.Configuration;

namespace Directorio___Presentacion
{
    public class SystemSettings
    {
        Configuration config;

        public SystemSettings()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            
        }
        public string GetConnectionString(string key)
        {
            return config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }
        public void SaveConnectionString(string key, string value)
        {
            config.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
            config.ConnectionStrings.ConnectionStrings[key].ProviderName = "System.Data.SqlClient";
            config.Save(ConfigurationSaveMode.Modified);
        }
        public string GetCorreoElectronico()
        {
            return ConfigurationManager.AppSettings["CorreoElectronico"];
        }
        public string GetSmptServer()
        {
            return ConfigurationManager.AppSettings["SmtpServer"];
        }

        public string GetPasswordCorreo()
        {
            return ConfigurationManager.AppSettings["PasswordCorreo"];
        }

        public void SaveCorreoElectronico(string correo)
        {
            config.AppSettings.Settings["CorreoElectronico"].Value = correo;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public void SavePasswordCorreo(string password)
        {
            config.AppSettings.Settings["PasswordCorreo"].Value = password;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        public void SaveSmptServer(string smtpServerName)
        {
            config.AppSettings.Settings["SmtpServer"].Value = smtpServerName;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

    }
}
