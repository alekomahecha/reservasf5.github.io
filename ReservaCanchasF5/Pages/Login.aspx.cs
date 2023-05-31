using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReservaCanchasF5.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validaciones())
                {
                    Negocio.Usuario ngu = new Negocio.Usuario();
                    DataTable dt = new DataTable();
                    dt = ngu.AutenticacionUsuario(txtUsuario.Text, txtContrasena.Text);

                    if (dt.Rows.Count != 0)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            if (item[0].ToString() != String.Empty)
                            {
                                Session["IdUsuario"] = item[0].ToString();
                                Session["Usuario"] = item[1].ToString();
                                Session["idpersona"] = item[3].ToString();
                                Session["Apellido"] = item[4].ToString();
                                Session["Correo"] = item[5].ToString();
                                Session["Nombre"] = item[6].ToString();
                                Session["NumeroIden"] = item[7].ToString();
                                Session["TipoIden"] = item[8].ToString();
                                Response.Redirect("~/Default.aspx", false);
                                Context.ApplicationInstance.CompleteRequest();
                            }
                            else
                            {
                                error.Visible = true;
                            }
                        }
                    }
                    else {
                        error.Visible = true;
                    }                  
                }
                else
                {
                    error.Visible = true;
                }
            }
            catch (Exception)
            {

                Response.Redirect("~/Pages/404.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        private Boolean validaciones()
        {

            Boolean validaciones = false;

            try
            {                
                if (txtUsuario.Text == string.Empty)
                    validaciones = true;
                if (txtContrasena.Text == string.Empty)
                    validaciones = true;
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Pages/404.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }

            return validaciones;

        }
    }
}