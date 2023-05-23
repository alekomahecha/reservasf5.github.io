using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace ReservaCanchasF5.Pages.Persona
{
    public partial class Registro : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            error.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validaciones())
                {
                    Negocio.Persona ngp = new Negocio.Persona();
                    Negocio.Usuario ngu = new Negocio.Usuario();
                    int idPersona = 0;
                    idPersona = ngp.Registrar(txtTipoIden.Text,
                        txtNumIde.Text, txtNombre.Text, txtApellido.Text,
                        txtCorreo.Text,
                        txtTelefono.Text);
                    ngu.Registrar(txtUsuario.Text, txtContrasena.Text, idPersona);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro Insertado con Exito');" +
                        "setTimeout(function(){window.location.href ='../Login.aspx'}, 0000);", true);
                    //Response.Redirect("~/Pages/Login.aspx");
                }
                else {
                    error.Visible = true;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private Boolean validaciones() { 
        
            Boolean validaciones = false;

            try
            {
                if(txtTipoIden.Text == string.Empty)
                    validaciones = true;
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
                if (txtUsuario.Text == string.Empty)
                    validaciones = true;
                if (txtContrasena.Text == string.Empty)
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