﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Web.Helpers;
using System.Security.Policy;
using System.Web.Caching;

namespace ReservaCanchasF5.Pages.Reservas
{
    public partial class DatosReserva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarHorasxCancha();
            }
        }

        protected void txtNumIde_TextChanged(object sender, EventArgs e)
        {
            Negocio.Persona ngu = new Negocio.Persona();
            DataTable dt = new DataTable();
            dt = ngu.ConsultaPersonaxNumeroDocumento(txtNumIde.Text);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    if (item[0].ToString() != String.Empty)
                    {
                        txtTipoIden.Text = item[1].ToString();
                        txtNombre.Text = item[3].ToString();
                        txtApellido.Text = item[4].ToString();
                        txtCorreo.Text = item[5].ToString();
                        txtTelefono.Text = item[6].ToString();
                        txtTipoIden.Enabled = false;
                        txtNombre.Enabled = false;
                        txtApellido.Enabled = false;
                        txtCorreo.Enabled = false;
                        txtTelefono.Enabled = false;                        
                    }
                    else
                    {
                        error.Visible = true;
                    }
                }
            }
            else
            {
                txtTipoIden.Enabled = true;
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtCorreo.Enabled = true;
                txtTelefono.Enabled = true;
                txtTipoIden.Text = String.Empty;
                txtNombre.Text = String.Empty;
                txtApellido.Text = String.Empty;
                txtCorreo.Text = String.Empty;
                txtTelefono.Text = String.Empty;
            }
        }

        public void EnvioCorreo()
        {

            try
            {
                Session["NombreCancha"] = "Prueba";
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
                mm.Subject = "Notificación Reserva";
                mm.Body = "<h1>Confirmación Reserva</h1>";
                mm.Body += "<p>Has reservado en la cancha " + Session["NombreCancha"].ToString() + " En el horario de " + dwHorasReserva.SelectedItem + "</p>";
                mm.To.Add(new MailAddress(txtCorreo.Text));
                smtp.Send(mm); // Enviar el mensaje
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnReserva_Click(object sender, EventArgs e)
        {

        }

        public void CargarHorasxCancha() 
        {
            try
            {
                Negocio.Hora ngu = new Negocio.Hora();
                DataTable dt = new DataTable();
                dt = ngu.ConsultaHoraxCanchaListaDesplegable(Convert.ToInt32(Session["IdCancha"]));
                
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem valor;
                    valor = new ListItem(dr[1].ToString(), dr[0].ToString());
                    dwHorasReserva.Items.Add(valor);
                }

                Negocio.Hora ngus = new Negocio.Hora();
                DataTable dte = new DataTable();
                dte = ngus.ConsultaPrecioHoraxCanchaid(Convert.ToInt32(dwHorasReserva.SelectedValue));
                foreach (DataRow isa in dte.Rows)
                {
                    txtValorPago.Text = isa[0].ToString();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        
        
        }

        protected void dwHorasReserva_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Negocio.Hora ngu = new Negocio.Hora();
                DataTable dt = new DataTable();
                dt = ngu.ConsultaPrecioHoraxCanchaid(Convert.ToInt32(dwHorasReserva.SelectedValue));
                foreach (DataRow dr in dt.Rows)
                {
                    txtValorPago.Text = dr[0].ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void dwValorChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(dwValorChange.SelectedValue == "Pago Total")
                    txtValorPago.Enabled = false;
                else
                    txtValorPago.Enabled = true;                    
            }
            catch (Exception ex)
            {

                throw;
            }
        }
       
    }
}