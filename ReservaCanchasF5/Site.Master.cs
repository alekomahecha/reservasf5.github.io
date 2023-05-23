using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReservaCanchasF5
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null) {

                mCanchas.Visible = false;
                mHoras.Visible = false;
                mReservas.Visible = false;
                mUsuario.Visible = false;
                mSalir.Visible = false;
                mLogin.Visible = true;
                mSobreNosotros.Visible = true;
                mContactenos.Visible = true;
                mReserva.Visible = true;
            }
            else {

                mCanchas.Visible = true;
                mHoras.Visible = true;
                mReservas.Visible = true;
                mUsuario.Visible = true;
                mSalir.Visible = true;
                mLogin.Visible = false;
                mSobreNosotros.Visible = false;
                mContactenos.Visible = false;
                mReserva.Visible = false;
                lblUsuario.Visible = true;
                lblUsuario.Text = "Bienvenido " + Session["nombre"].ToString() + " " + Session["Apellido"].ToString();
            }
        }
    }
}