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
            }
            else {

                mCanchas.Visible = true;
                mHoras.Visible = true;
                mReservas.Visible = true;
                mUsuario.Visible = true;
                mSalir.Visible = true;
                mLogin.Visible = false;
            }
        }
    }
}