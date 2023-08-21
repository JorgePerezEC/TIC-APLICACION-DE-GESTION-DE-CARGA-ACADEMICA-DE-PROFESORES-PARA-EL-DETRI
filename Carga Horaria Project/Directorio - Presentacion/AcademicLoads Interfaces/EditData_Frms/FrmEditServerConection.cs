﻿using MaterialSkin.Controls;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Directorio___Presentacion.AcademicLoads_Interfaces.EditData_Frms
{
    public partial class FrmEditServerConection : MaterialForm
    {
        public FrmEditServerConection()
        {
            InitializeComponent();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEditServerConection_Load(object sender, EventArgs e)
        {

        }

        private void btnTestConection_Click(object sender, EventArgs e)
        {

        }

        private void rbSql_CheckedChanged(object sender, EventArgs e)
        {
            txtUser.Enabled= true;
            txtPassword.Enabled= true;
            txtUser.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        private void rbIntegrated_CheckedChanged(object sender, EventArgs e)
        {
            txtUser.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUser.Enabled = false;
            txtPassword.Enabled = false;
        }
    }
}