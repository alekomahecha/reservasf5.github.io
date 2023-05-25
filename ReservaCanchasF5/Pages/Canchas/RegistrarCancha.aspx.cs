using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReservaCanchasF5.Pages
{
    public partial class RegistrarCancha : System.Web.UI.Page
    {
        DataTable dtHorasFinal = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            AgregarHoras();
            dtHorasFinal.Columns.Add("Hora");
            dtHorasFinal.Columns.Add("Precio");

        }

        protected void btnCancha_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validaciones())
                {
                    Negocio.Cancha ngp = new Negocio.Cancha();
                    ngp.Registrar(txtNombreCancha.Text, txtNumeroCancha.Text, txtDireccion.Text,
                        txtBarrio.Text, txtTelefono.Text, dwHoraInicio.SelectedValue, dwHoraFinal.SelectedValue, Convert.ToInt32(Session["IdUsuario"].ToString()));
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro Insertado con Exito');" +
                        "setTimeout(function(){window.location.href ='../Canchas/RegistrarCancha.aspx'}, 0000);", true);
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
                    valor = new ListItem(i.ToString() + ":00", i.ToString() + ":00");
                    dwHoraInicio.Items.Add(valor);
                    dwHoraFinal.Items.Add(valor);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        protected void dwHoraInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarRangoHoras(dwHoraInicio.SelectedValue, dwHoraFinal.SelectedValue);
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
                    AgregarHorasCancha(valorHoraInicio, valorHoraFin);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        protected void dwHoraFinal_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarRangoHoras(dwHoraInicio.SelectedValue, dwHoraFinal.SelectedValue);
        }

        public void AgregarHorasCancha(int pHoraIncio, int pHoraFin)
        {
            try
            {
                dwHora.Items.Clear();
                for (int i = pHoraIncio; i < pHoraFin; i++)
                {
                    ListItem valor;
                    valor = new ListItem(i.ToString() + ":00", i.ToString() + ":00");
                    dwHora.Items.Add(valor);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        protected void btnAgregarHora_Click(object sender, EventArgs e)
        {
            DataRow row = dtHorasFinal.NewRow();
            row["Hora"] = dwHora.SelectedValue;
            row["Precio"] = txtPrecioHora.Text;
            dtHorasFinal.Rows.Add(row);
            gvHoras.DataSource = dtHorasFinal;
            gvHoras.DataBind();

        }
    }
}