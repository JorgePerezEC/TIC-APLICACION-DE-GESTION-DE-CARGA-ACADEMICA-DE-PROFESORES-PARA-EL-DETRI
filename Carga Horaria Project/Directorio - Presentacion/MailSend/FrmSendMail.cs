using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Directorio___Presentacion.MailSend
{
    public partial class FrmSendMail : Form
    {
        private List<CorreoAdjunto> correosAdjuntos;
        SystemSettings settings = new SystemSettings();

        public FrmSendMail(List<CorreoAdjunto> correosAdjuntos)
        {
            InitializeComponent();
            this.correosAdjuntos = correosAdjuntos;
            Image imagenOriginal = Properties.Resources.boton_editar;
            Image imagenRedimensionada = imagenOriginal.GetThumbnailImage(40, 40, null, IntPtr.Zero);

            btnEditMail.Image = imagenRedimensionada;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private async void btnSend_Click(object sender, EventArgs e)
        {
            bool errorEnEnvio = false;

            if (txtAsunto.Text == string.Empty || txtBody.Text == string.Empty || txtCorreoDestino.Text == string.Empty)
            {
                MessageBox.Show("Por favor, llene todos los campos del formulario para enviar el correo electrónico.", "Advertencia - Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ComprobarFormatoEmail(txtCorreoDestino.Text) == false)
            {
                MessageBox.Show("El Email ** " + txtCorreoDestino.Text + " ** ingresado es inválido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (correosAdjuntos.Count > 1)
            {
                MessageBox.Show("Los correos se enviarán en segundo plano, puede seguir utilizando el sistema y será notificado una vez concluya el proceso de envío.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            foreach (var correoAdjunto in correosAdjuntos)
            {
                MailMessage mm = new MailMessage();
                SmtpClient sc = new SmtpClient(settings.GetSmptServer());
                mm.From = new MailAddress(settings.GetCorreoElectronico());
                mm.To.Add(correoAdjunto.CorreoDestino);
                mm.Subject = txtAsunto.Text;
                mm.Body = txtBody.Text;

                if (!string.IsNullOrEmpty(correoAdjunto.RutaArchivo))
                {
                    Attachment archivo = new Attachment(correoAdjunto.RutaArchivo);
                    mm.Attachments.Add(archivo);
                }

                sc.Port = 587;
                sc.Credentials = new System.Net.NetworkCredential(settings.GetCorreoElectronico(), settings.GetPasswordCorreo());
                sc.EnableSsl = true;

                //try
                //{
                //    // Enviar el correo
                //    sc.Send(mm);
                //    if (correosAdjuntos.Count == 1)
                //    {
                //        MessageBox.Show("Correo enviado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //    this.Close();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Error al enviar el correo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}

                try
                {
                    // Enviar el correo de manera asincrónica
                    await sc.SendMailAsync(mm);
                    if (correosAdjuntos.Count == 1)
                    {
                        MessageBox.Show("Correo enviado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al enviar el correo a {correoAdjunto.CorreoDestino}: {ex.Message}"+" . Por favor revise las credenciales del correo electrónico o intentelo más tarde.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorEnEnvio = true;
                    break;
                }
            }

            if (!errorEnEnvio)
            {
                MessageBox.Show("Todos los correos han sido enviados.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.Close();
            }
        }

        private void FrmSendMail_Load(object sender, EventArgs e)
        {
            txtCorreoDestino.Text = correosAdjuntos[0].CorreoDestino;
            if (correosAdjuntos.Count > 2)
            {
                btnEditMail.Visible = false;
                txtCorreoDestino.Visible = false;
                lblPara.Visible = false;
                lblNota.Visible = true;
            }
        }

        private void btnEditMail_Click(object sender, EventArgs e)
        {
            txtCorreoDestino.Enabled = true;
            btnEditMail.Enabled = false;
        }
    }
}
