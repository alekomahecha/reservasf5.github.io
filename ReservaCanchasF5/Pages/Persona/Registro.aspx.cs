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

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Negocio.Persona ngp = new Negocio.Persona();
            Negocio.Usuario ngu = new Negocio.Usuario();
            int idPersona = 0;
            idPersona = ngp.Registrar(txtTipoIden.Text,
                txtNumIde.Text, txtNombre.Text, txtApellido.Text,
                txtCorreo.Text,
                txtTelefono.Text);
            ngu.Registrar(txtUsuario.Text, txtContrasena.Text,idPersona);


        }
    }
}