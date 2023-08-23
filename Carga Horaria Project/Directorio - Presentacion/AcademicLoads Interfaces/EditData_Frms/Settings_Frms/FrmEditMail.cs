using Directorio_Entidades.SettingsCls;
using Newtonsoft.Json;
using System.Configuration;
using System.Reflection;

namespace Directorio___Presentacion.AcademicLoads_Interfaces.EditData_Frms.Settings_Frms
{
    public partial class FrmEditMail : Form
    {
        public FrmEditMail()
        {
            InitializeComponent();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnGuardar.Visible = true;
            txtCorreo.Enabled= true;
            txtPassword.Enabled= true;
        }

        private void FrmEditMail_Load_1(object sender, EventArgs e)
        {
            string resourceName = "NombreDelProyecto.appsetting.json"; // Cambia "NombreDelProyecto" al nombre real de tu proyecto
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string json = reader.ReadToEnd();
                        ClsCredencialesCorreo credenciales = JsonConvert.DeserializeObject<ClsCredencialesCorreo>(json);

                        txtCorreo.Text = credenciales.CorreoElectronico;
                        txtPassword.Text = credenciales.PasswordCorreo;
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ClsCredencialesCorreo nuevasCredenciales = new ClsCredencialesCorreo
                {
                    CorreoElectronico = txtCorreo.Text,
                    PasswordCorreo = txtPassword.Text
                };

                string json = JsonConvert.SerializeObject(nuevasCredenciales);
                File.WriteAllText("appsettings.json", json);

                MessageBox.Show("Credenciales guardadas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar las credenciales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void FrmEditMail_Load_1(object sender, EventArgs e)
        //{
        //    string jsonFilePath = "appsettings.json";
        //    if (File.Exists(jsonFilePath))
        //    {
        //        string json = File.ReadAllText(jsonFilePath);
        //        MessageBox.Show(json);
        //        ClsCredencialesCorreo credenciales = JsonConvert.DeserializeObject<ClsCredencialesCorreo>(json);

        //        txtCorreo.Text = credenciales.CorreoElectronico;
        //        txtPassword.Text = credenciales.PasswordCorreo;
        //        MessageBox.Show(txtCorreo.Text);
        //    }
        //}

        //private void btnGuardar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ClsCredencialesCorreo nuevasCredenciales = new ClsCredencialesCorreo
        //        {
        //            CorreoElectronico = txtCorreo.Text,
        //            PasswordCorreo = txtPassword.Text
        //        };

        //        string json = JsonConvert.SerializeObject(nuevasCredenciales);
        //        File.WriteAllText("appsettings.json", json);

        //        MessageBox.Show("Credenciales guardadas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al guardar las credenciales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
    }
}
