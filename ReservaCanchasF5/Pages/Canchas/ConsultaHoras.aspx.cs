using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReservaCanchasF5.Pages.Canchas
{
    public partial class ConsultaHoras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDatos();
            }
        }

        public void cargarDatos()
        {
            try
            {
                Negocio.Cancha ngu = new Negocio.Cancha();
                DataTable dt = new DataTable();
                dt = ngu.ConsultarCanchaxIdUsuario(Convert.ToInt32(Session["IdUsuario"].ToString()));
                gvCanchas.DataSource = dt;
                gvCanchas.DataBind();
            }
            catch (Exception)
            {
                Response.Redirect("~/Pages/404.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }

        }

        protected void gvCanchas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                Session["idCanchaConsultaHoras"] = gvCanchas.SelectedDataKey.Value.ToString();
                Response.Redirect("~/Pages/Canchas/ModificarHoras.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {

                Response.Redirect("~/Pages/404.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }
}