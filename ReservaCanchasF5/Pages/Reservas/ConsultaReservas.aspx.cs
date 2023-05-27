using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReservaCanchasF5.Pages.Reservas
{
    public partial class ConsultaReservas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarReservas();
            }
        }

        public void CargarReservas()
        {
            try
            {
                Negocio.Reserva ngu = new Negocio.Reserva();
                DataTable dt = new DataTable();
                dt = ngu.ConsultaReservaxidUsuario(Convert.ToInt32(Session["IdUsuario"].ToString()));
                gvReservas.DataSource = dt;
                gvReservas.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}