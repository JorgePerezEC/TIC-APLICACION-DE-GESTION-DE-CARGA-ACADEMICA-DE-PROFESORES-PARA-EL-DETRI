using Directorio_Entidades.SettingsCls;
using Newtonsoft.Json;
using System.Configuration;
using System.Reflection;
using System.IO;
using System;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;

namespace Directorio___Presentacion.AcademicLoads_Interfaces.EditData_Frms.Settings_Frms
{
    public partial class FrmEditMail : Form
    {
        private string correo;
        private string password;
        private string jsonFilePath;
        private SystemSettings settings = new SystemSettings();
        public FrmEditMail()
        {
            InitializeComponent();
            jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettingsdetri.json");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnGuardar.Visible = true;
            txtCorreo.Enabled= true;
            txtPassword.Enabled= true;
            txtSmptServer.Enabled= true;
            btnEditar.Enabled= false;
            btnCancelar.Enabled = true;
            btnCancelar.Visible= true;
        }


        private void FrmEditMail_Load_1(object sender, EventArgs e)
        {
            LoadCredentials();
            btnCancelar.Visible = false;
            btnGuardar.Visible = false;

        }

        private void LoadCredentials()
        {
            txtCorreo.Text = settings.GetCorreoElectronico();
            txtPassword.Text = settings.GetPasswordCorreo();
            txtSmptServer.Text = settings.GetSmptServer();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text == string.Empty || txtCorreo.Text == string.Empty || txtSmptServer.Text == string.Empty)
                {
                    MessageBox.Show("Por favor complete todos los campos para continuar.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                settings.SaveCorreoElectronico(txtCorreo.Text);
                settings.SavePasswordCorreo(txtPassword.Text);
                settings.SaveSmptServer(txtSmptServer.Text);

                MessageBox.Show("Credenciales guardadas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnEditar.Enabled = true;
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
                btnCancelar.Visible = false;
                txtCorreo.Enabled = false;
                txtPassword.Enabled= false;
                txtSmptServer.Enabled=false;
                LoadCredentials();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar las credenciales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LoadCredentials(); 
            txtCorreo.Enabled = false; 
            txtPassword.Enabled = false; 
            txtSmptServer.Enabled = false;
            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
            btnEditar.Enabled = true;
        }
    }
}
