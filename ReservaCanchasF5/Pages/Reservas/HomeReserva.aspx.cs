using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReservaCanchasF5.Pages.Reservas
{
    public partial class HomeReserva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtUbicacion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Negocio.Cancha ngu = new Negocio.Cancha();
                DataTable dt = new DataTable();
                dt = ngu.ConsultarCanchaxBarrio(txtUbicacion.Text);
                gvUbicaciones.DataSource = dt;
                gvUbicaciones.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void gvUbicaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["idCancha"] = gvUbicaciones.SelectedDataKey.Value.ToString();
                Response.Redirect("~/Pages/Reservas/DatosReserva.aspx");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}