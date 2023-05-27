using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReservaCanchasF5.Pages.Persona
{
    public partial class MiCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosIniciales();
            }
        }

        public void CargarDatosIniciales()
        {
            try
            {
                Negocio.Persona ngu = new Negocio.Persona();
                DataTable dt = new DataTable();
                dt = ngu.ConsultaPersonaxId(Convert.ToInt32(Session["idPersona"].ToString()));
                foreach (DataRow dr in dt.Rows)
                {
                    txtNombre.Text = dr[0].ToString();
                    txtApellido.Text = dr[1].ToString();
                    dwTipoIdentificacion.SelectedValue = dr[2].ToString();
                    txtNumeroIden.Text = dr[3].ToString();
                    txtCorreo.Text = dr[4].ToString();
                    txtTelefono.Text = dr[5].ToString();
                    txtUsuario.Text = dr[6].ToString();
                    txtContrasena.Text = dr[7].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!validaciones())
            {
                Negocio.Persona ngp = new Negocio.Persona();
                Negocio.Usuario ngu = new Negocio.Usuario();                
                ngp.Modificar(Convert.ToInt32(Session["idPersona"].ToString()),
                    dwTipoIdentificacion.SelectedValue,
                    txtNumeroIden.Text, txtNombre.Text, txtApellido.Text,
                    txtCorreo.Text,
                    txtTelefono.Text);
                ngu.Modificar(Convert.ToInt32(Session["IdUsuario"].ToString()),txtUsuario.Text, txtContrasena.Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Modificacion Realizada con Exito');" +
                            "setTimeout(function(){window.location.href ='../../Default.aspx'}, 0000);", true);
                //Response.Redirect("~/Pages/Login.aspx"); 
            }
            else
            {
                error.Visible = true;
            }
        }

        private Boolean validaciones()
        {

            Boolean validaciones = false;

            try
            {
                if (txtNumeroIden.Text == string.Empty)
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

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                Negocio.Persona ngp = new Negocio.Persona();
                Negocio.Usuario ngu = new Negocio.Usuario();
                ngp.Eliminar(Convert.ToInt32(Session["idPersona"].ToString()));
                ngu.Eliminar(Convert.ToInt32(Session["IdUsuario"].ToString()));
                Session.RemoveAll();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Inactivacion Realizada con Exito');" +
                            "setTimeout(function(){window.location.href ='../../Default.aspx'}, 0000);", true);
                //Response.Redirect("~/Pages/Login.aspx"); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}