using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
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

        private void btnSend_Click(object sender, EventArgs e)
        {
            foreach (var correoAdjunto in correosAdjuntos)
            {
                MailMessage mm = new MailMessage();
                SmtpClient sc = new SmtpClient("smtp.gmail.com");
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

                MessageBox.Show(correoAdjunto.CorreoDestino);

                try
                {
                    // Enviar el correo
                    sc.Send(mm);
                    MessageBox.Show("Correo enviado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al enviar el correo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            }
        }

        private void btnEditMail_Click(object sender, EventArgs e)
        {
            txtCorreoDestino.Enabled = true;
            btnEditMail.Enabled = false;
        }
    }
}
