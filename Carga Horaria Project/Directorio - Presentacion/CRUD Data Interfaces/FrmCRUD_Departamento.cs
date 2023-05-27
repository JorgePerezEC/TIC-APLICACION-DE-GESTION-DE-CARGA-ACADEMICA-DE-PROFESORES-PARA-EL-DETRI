﻿using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_LogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Directorio___Presentacion.CRUD_Data_Interfaces
{
    public partial class FrmCRUD_Departamento : Form
    {
        CN_Departamento objetoCNegocio = new CN_Departamento();
        ClsStyles clsStyles = new ClsStyles();
        private string? idDepartamento = null;
        private string? nameDepartamento = null;
        private string? emailDepartamento = null;
        private bool Editar = false;
        public FrmCRUD_Departamento()
        {
            InitializeComponent();
            clsStyles.tableStyle(dgLstRegistros);
            
        }

        private void FrmCRUD_Departamento_Load(object sender, EventArgs e)
        {
            MostrarDepartamentos();

        }
        #region CRUD Methods

        private void MostrarDepartamentos()
        {
            CN_Departamento objetoCNegocio = new CN_Departamento();
            dgLstRegistros.DataSource = objetoCNegocio.MostrarDepartamentos();
        }


        private void btnCloseWin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    if (VerificacionCampos().Equals(true))
                    {
                        if (ComprobarFormatoEmail(txtEmailDepa.Text) == false)
                        {
                            MessageBox.Show("Email inválido.");
                        }
                        else
                        {
                            objetoCNegocio.CreateDepartamentoN(txtNameDepa.Text, txtEmailDepa.Text);
                            //objetoCNegocio.CreateDepartamentoNEntity(ObjDepartamento);
                            MessageBox.Show("Departamento insertado correctamente");
                            panelCreate.Visible = false;
                            MostrarDepartamentos();
                            ClearTxtBox();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepción: No se pudo registrar el Departamento. Motivo: " + ex.Message);
                }

            }
            if (Editar == true)
            {
                try
                {
                    if (VerificacionCampos().Equals(true))
                    {
                        if (ComprobarFormatoEmail(txtEmailDepa.Text) == false)
                        {
                            MessageBox.Show("Email inválido.");
                        }
                        else
                        {
                            objetoCNegocio.UpdateDepartamentoN(idDepartamento, txtNameDepa.Text, txtEmailDepa.Text);
                            MessageBox.Show("Departamento actualizado correctamente");
                            panelCreate.Visible = false;
                            MostrarDepartamentos();
                            Editar = false;
                            ClearTxtBox();
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Editar = false;
            if (panelCreate.Visible) {
                panelCreate.Visible = false;
            }
            else
            {
                panelCreate.Visible = true;
            }
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstRegistros.Rows.Count > 0)
                {
                    panelCreate.Visible = true;
                    Editar = true;
                    txtNameDepa.Text = dgLstRegistros.CurrentRow.Cells["Nombre del Departamento"].Value.ToString();
                    txtEmailDepa.Text = dgLstRegistros.CurrentRow.Cells["Correo electrónico del Departamento"].Value.ToString();
                    idDepartamento = dgLstRegistros.CurrentRow.Cells["ID"].Value.ToString()!;
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee editar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo actualizar el Departamento seleccionado. Motivo: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstRegistros.Rows.Count > 0)
                {
                    nameDepartamento = dgLstRegistros.CurrentRow.Cells["Nombre del Departamento"].Value.ToString()!;
                    emailDepartamento = dgLstRegistros.CurrentRow.Cells["Correo electrónico del Departamento"].Value.ToString()!;
                    idDepartamento = dgLstRegistros.CurrentRow.Cells["ID"].Value.ToString()!;
                    objetoCNegocio.DeleteDepartamentoN(idDepartamento, nameDepartamento, emailDepartamento);
                    MessageBox.Show("Departamento eliminado correctamente");
                    MostrarDepartamentos();
                    ClearTxtBox();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee eliminar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo eliminar el Departamento seleccionado. Motivo: " + ex.Message);
            }
        }
        #endregion

        #region Validation Methods
        private void ClearTxtBox()
        {
            txtNameDepa.Text = string.Empty;
            txtEmailDepa.Text = string.Empty;
        }
        private bool VerificacionCampos()
        {
            if (txtEmailDepa.Text.Length == 0 && txtNameDepa.Text.Length == 0)
            {
                MessageBox.Show("Llene los campos faltantes del formulario.");
                return false;
            }
            else if (txtNameDepa.Text.Length == 0)
            {
                MessageBox.Show("El nombre del departamento no puede estar vacío.");
                return false;
            }
            else if (txtEmailDepa.Text.Length == 0)
            {
                MessageBox.Show("El email del departamento no puede estar vacío.");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ComprobarFormatoEmail(string sEmailAComprobar)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(sEmailAComprobar, sFormato))
            {
                if (Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion

        

    }
}
