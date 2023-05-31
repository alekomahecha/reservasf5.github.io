using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReservaCanchasF5.Pages
{
    public partial class Contactenos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validaciones())
                {
                    EnvioCorreo();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enviado con Exito');" +
                            "setTimeout(function(){window.location.href ='../../Default.aspx'}, 0000);", true);
                    //Response.Redirect("~/Pages/Login.aspx"); 
                }
                else
                {
                    error.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Pages/404.aspx");
            }
        }

        public void EnvioCorreo()
        {

            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("reservacanchaf5@outlook.com", "@Areserva1234567.");
                smtp.EnableSsl = true;

                MailMessage mm = new MailMessage();
                mm.IsBodyHtml = true;
                mm.Priority = MailPriority.Normal;
                mm.From = new MailAddress("reservacanchaf5@outlook.com");
                mm.Subject = "Contactenos";
                mm.Body = "<h1>Contacto " + txtCorreo.Text + "</h1>";
                mm.Body += "<p>" + txtMensaje.Text + "</p>";
                mm.To.Add(new MailAddress("reservacanchaf5@outlook.com"));
                smtp.Send(mm); // Enviar el mensaje
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Pages/404.aspx");
            }
        }

        public Boolean validaciones()
        {
            Boolean validaciones = false;
            try
            {
                if (txtCorreo.Text == string.Empty)
                    validaciones = true;
                if (txtMensaje.Text == string.Empty)
                    validaciones = true;
            }
            catch (Exception ex)
            {

                Response.Redirect("~/Pages/404.aspx");
            }

            return validaciones;

        }
    }
}