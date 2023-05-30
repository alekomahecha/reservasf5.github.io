using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReservaCanchasF5.Pages.Canchas
{
    public partial class ModificarCancha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AgregarHoras();
                CargarDatos();
            }
        }

        public void CargarDatos()
        {
            try
            {
                Negocio.Cancha ngu = new Negocio.Cancha();
                DataTable dt = new DataTable();
                dt = ngu.ConsultarCanchaxIdCancha(Convert.ToInt32(Session["idCanchaConsulta"].ToString()));
                foreach (DataRow dr in dt.Rows)
                {
                    txtNombreCancha.Text = dr[1].ToString();
                    txtNumeroCancha.Text = dr[2].ToString();
                    txtDireccion.Text = dr[3].ToString();
                    txtBarrio.Text = dr[4].ToString();
                    txtTelefono.Text = dr[5].ToString();
                    dwHoraInicio.SelectedItem.Text = dr[6].ToString().Remove(dr[6].ToString().Length - 3);
                    dwHoraFinal.SelectedItem.Text = dr[7].ToString().Remove(dr[7].ToString().Length - 3);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Boolean validaciones()
        {

            Boolean validaciones = false;

            try
            {
                if (txtNombreCancha.Text == string.Empty)
                    validaciones = true;
                if (txtNumeroCancha.Text == string.Empty)
                    validaciones = true;
                if (txtDireccion.Text == string.Empty)
                    validaciones = true;
                if (txtBarrio.Text == string.Empty)
                    validaciones = true;
                if (txtTelefono.Text == string.Empty)
                    validaciones = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return validaciones;

        }

        public void AgregarHoras()
        {
            try
            {
                for (int i = 0; i < 24; i++)
                {
                    ListItem valor;
                    if (i == 0)
                        valor = new ListItem(i.ToString() + "0:00", i.ToString() + "0:00");
                    else
                        valor = new ListItem(i.ToString() + ":00", i.ToString() + ":00");
                    dwHoraInicio.Items.Add(valor);
                }

                for (int i = 0; i < 24; i++)
                {
                    ListItem valores;
                    if (i == 0)
                        valores = new ListItem(i.ToString() + "0:00", i.ToString() + "0:00");
                    else
                        valores = new ListItem(i.ToString() + ":00", i.ToString() + ":00");
                    dwHoraFinal.Items.Add(valores);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void ValidarRangoHoras(String pHoraInnicio, String pHoraFin)
        {

            try
            {
                string[] horaInicio = pHoraInnicio.Split(' ', ':');
                string[] horafin = pHoraFin.Split(' ', ':');
                int valorHoraInicio = Convert.ToInt32(horaInicio[0].ToString());
                int valorHoraFin = Convert.ToInt32(horafin[0].ToString());

                if (valorHoraInicio > valorHoraFin)
                {
                    errorHoras.Visible = true;
                }
                else
                {
                    errorHoras.Visible = false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        protected void dwHoraInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ValidarRangoHoras(dwHoraInicio.SelectedValue, dwHoraFinal.SelectedValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void dwHoraFinal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ValidarRangoHoras(dwHoraInicio.SelectedValue, dwHoraFinal.SelectedValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancha_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validaciones())
                {
                    Negocio.Cancha ngp = new Negocio.Cancha();
                    ngp.Modificar(Convert.ToInt32(Session["idCanchaConsulta"].ToString()), txtNombreCancha.Text, txtNumeroCancha.Text, txtDireccion.Text,
                        txtBarrio.Text, txtTelefono.Text, dwHoraInicio.SelectedValue, dwHoraFinal.SelectedValue);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Modificación con Exito');" +
                        "setTimeout(function(){window.location.href ='../Canchas/ConsultarCanchas.aspx'}, 0000);", true);
                    //Response.Redirect("~/Pages/Login.aspx");
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


    }
}