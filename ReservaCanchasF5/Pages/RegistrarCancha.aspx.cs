using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReservaCanchasF5.Pages
{
    public partial class RegistrarCancha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancha_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validaciones())
                {
                    Negocio.Cancha ngp = new Negocio.Cancha();
                    ngp.Registrar(txtNombreCancha.Text, txtNumeroCancha.Text, txtDireccion.Text,
                        txtBarrio.Text, txtTelefono.Text, dwHoraInicio.SelectedValue, dwHoraFinal.SelectedValue,Convert.ToInt32(Session["IdUsuario"].ToString()));
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro Insertado con Exito');" +
                        "setTimeout(function(){window.location.href ='../Pages/RegistrarCancha.aspx'}, 0000);", true);
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
    }
}