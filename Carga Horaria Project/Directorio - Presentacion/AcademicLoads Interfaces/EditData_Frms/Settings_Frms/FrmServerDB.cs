using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Directorio___Presentacion.AcademicLoads_Interfaces.EditData_Frms.Settings_Frms
{
    public partial class FrmServerDB : Form
    {
        private SystemSettings settings = new SystemSettings();
        private string cadenaPorDefecto;
        public FrmServerDB()
        {
            InitializeComponent();
        }

        #region BUTTONS

        private void FrmServerDB_Load(object sender, EventArgs e)
        {
            GetStringConnection();
            btnCancelar.Visible = false;
            btnGuardar.Visible = false;
            cadenaPorDefecto = settings.GetConnectionString("MyDefaultConnection");
        }

        private void GetStringConnection()
        {
            txtCadenaConexion.Text = settings.GetConnectionString("MyDatabaseConnection");
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCadenaConexion.Text == string.Empty)
            {
                MessageBox.Show("Por favor ingrese una cadena de conexión.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            settings.SaveConnectionString("MyDatabaseConnection", txtCadenaConexion.Text);
            MessageBox.Show("Cadena de conexión actualizada correctamente. Los cambios surtirán efecto después de reiniciar la aplicación.",
                    "CADENA DE CONEXIÓN ACTUALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reiniciar la aplicación
            Application.Restart();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtCadenaConexion.Enabled = true;
            btnGuardar.Visible= true;
            btnCancelar.Visible= true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCadenaConexion.Enabled = false;
            GetStringConnection();
            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
        }
        #endregion

        private void materialButton1_Click(object sender, EventArgs e)
        {
            settings.SaveConnectionString("MyDatabaseConnection", cadenaPorDefecto);
            MessageBox.Show("Cadena de conexión actualizada por defecto correctamente. Los cambios surtirán efecto después de reiniciar la aplicación.",
                    "CADENA DE CONEXIÓN POR DEFECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reiniciar la aplicación
            Application.Restart();
        }
    }
}
