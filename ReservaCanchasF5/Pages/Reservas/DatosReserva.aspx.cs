using System;
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
using AjaxControlToolkit;

namespace ReservaCanchasF5.Pages.Reservas
{
    public partial class DatosReserva : System.Web.UI.Page
    {
        static int idPersonaReserva = 0;
        static double valorHora = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarHorasxCancha();
                CargarReservas();
            }
            CalendarioFechaReserva();
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
                        idPersonaReserva = Convert.ToInt32(item[0].ToString());
                        dwTipoIdentificacion.SelectedValue = item[1].ToString();
                        txtNombre.Text = item[3].ToString();
                        txtApellido.Text = item[4].ToString();
                        txtCorreo.Text = item[5].ToString();
                        txtTelefono.Text = item[6].ToString();
                        dwTipoIdentificacion.Enabled = false;
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
                dwTipoIdentificacion.Enabled = true;
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtCorreo.Enabled = true;
                txtTelefono.Enabled = true;
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
                mm.Body += "<p>Has reservado en la cancha " + NombreCancha() + " En el horario de " + dwHorasReserva.SelectedItem +
                           "  con un valor de " + txtValorPago.Text + " con el metodo de pago " + dwTipoPago.SelectedValue + " " +
                           " El cual es un " + dwValorChange.SelectedValue + "</p>";
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
            try
            {
                if (!validaciones())
                {
                    if (!validacionesAbono())
                    {
                        if (!ValidarReservaxFechaHora())
                        {
                            string fechaPago = "";
                            string Abono = "NO";
                            double valorAbono = 0;
                            string PagoTotal = "NO";
                            double ValorPagoTotal = 0;
                            Negocio.Reserva ngp = new Negocio.Reserva();
                            Negocio.Persona ngper = new Negocio.Persona();
                            Negocio.Pago ngpago = new Negocio.Pago();

                            if (idPersonaReserva == 0)
                            {
                                idPersonaReserva = ngper.Registrar(dwTipoIdentificacion.SelectedValue, txtNumIde.Text,
                                    txtNombre.Text, txtApellido.Text, txtCorreo.Text, txtTelefono.Text);
                            }

                            int idreserva = ngp.Registrar(txtFechaReserva.Text, idPersonaReserva, Convert.ToInt32(Session["idCancha"].ToString()), Convert.ToInt32(dwHorasReserva.SelectedValue));
                            if (dwTipoPago.SelectedValue != "Efectivo")
                                fechaPago = DateTime.Now.ToString();
                            if (dwValorChange.SelectedValue == "Abono")
                            {
                                Abono = "SI";
                                valorAbono = Convert.ToDouble(txtValorPago.Text);
                            }
                            else
                            {
                                PagoTotal = "SI";
                                ValorPagoTotal = Convert.ToDouble(txtValorPago.Text);
                            }
                            ngpago.Registrar(fechaPago, Abono, valorAbono, PagoTotal, ValorPagoTotal, idreserva);
                            EnvioCorreo();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Reserva Realizada con Exito');" +
                            "setTimeout(function(){window.location.href ='../../Default.aspx'}, 0000);", true);
                            //Response.Redirect("~/Pages/Login.aspx");  
                        }
                        else
                        {
                            errorReservas.Visible = true;
                        }
                    }
                    else
                    {
                        errorValor.Visible = true;
                    }
                }
                else
                {
                    error.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                    valorHora = Convert.ToDouble(isa[0].ToString());
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
                if (!ValidarReservaxFechaHora())
                    errorReservas.Visible = true;
                else
                    errorReservas.Visible = false;
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
                if (dwValorChange.SelectedValue == "Pago Total")
                    txtValorPago.Enabled = false;
                else
                    txtValorPago.Enabled = true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public string NombreCancha()
        {
            try
            {
                string nombreCancha = string.Empty;
                Negocio.Cancha ngu = new Negocio.Cancha();
                DataTable dt = new DataTable();
                dt = ngu.ConsultarConsultaNombrexIdCancha(Convert.ToInt32(Session["idCancha"].ToString()));
                foreach (DataRow dr in dt.Rows)
                {
                    nombreCancha = dr[0].ToString();
                }

                return nombreCancha;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public Boolean validaciones()
        {
            Boolean validaciones = false;
            try
            {
                if (txtNumIde.Text == string.Empty)
                    validaciones = true;
                if (txtNombre.Text == string.Empty)
                    validaciones = true;
                if (txtApellido.Text == string.Empty)
                    validaciones = true;
                if (txtCorreo.Text == string.Empty)
                    validaciones = true;
                if (txtTelefono.Text == string.Empty)
                    validaciones = true;
                if (txtFechaReserva.Text == string.Empty)
                    validaciones = true;
                if (txtValorPago.Text == string.Empty)
                    validaciones = true;


            }
            catch (Exception ex)
            {

                throw;
            }

            return validaciones;

        }

        public Boolean validacionesAbono()
        {
            Boolean validaciones = false;
            try
            {
                if (dwValorChange.SelectedValue == "Abono")
                {
                    if (valorHora < Convert.ToDouble(txtValorPago.Text))
                        validaciones = true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return validaciones;

        }

        public void CargarReservas()
        {
            try
            {
                Negocio.Reserva ngu = new Negocio.Reserva();
                DataTable dt = new DataTable();
                dt = ngu.ConsultaReservaxCancha(Convert.ToInt32(Session["idCancha"].ToString()));
                gvReservas.DataSource = dt;
                gvReservas.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void CalendarioFechaReserva()
        {
            try
            {
                CalendarExtender myCalExt = new CalendarExtender();
                myCalExt.TargetControlID = "txtFechaReserva";
                myCalExt.StartDate = DateTime.Now;
                Place1.Controls.Add(myCalExt);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Boolean ValidarReservaxFechaHora()
        {

            Boolean validador = false;
            try
            {
                foreach (GridViewRow row in gvReservas.Rows)
                {
                    if (txtFechaReserva.Text == row.Cells[0].Text && dwHorasReserva.SelectedItem.Text == row.Cells[1].Text)
                    {
                        validador = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return validador;
        }
    }
}