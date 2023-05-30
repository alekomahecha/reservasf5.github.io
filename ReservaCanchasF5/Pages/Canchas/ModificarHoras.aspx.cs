using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReservaCanchasF5.Pages.Canchas
{
    public partial class ModificarHoras : System.Web.UI.Page
    {
        static DataTable dtHorasFinal;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dtHorasFinal = new DataTable();
                dtHorasFinal.Columns.Clear();
                dtHorasFinal.Columns.Add("Hora");
                dtHorasFinal.Columns.Add("Precio");
                dtHorasFinal.Columns.Add("id");
                AgregarHoras();
                CargarDatosCombo();
                ValidarRangoHoras(dwHoraInicio.SelectedItem.Text, dwHoraFinal.SelectedItem.Text);
                CargarDatosHoras();
                CargarPrecioHoras();
            }
        }

        public void CargarDatosCombo()
        {
            try
            {
                Negocio.Cancha ngu = new Negocio.Cancha();
                DataTable dt = new DataTable();
                dt = ngu.ConsultarCanchaxIdCancha(Convert.ToInt32(Session["idCanchaConsultaHoras"].ToString()));
                string horaI = "", horaF = "";
                foreach (DataRow dr in dt.Rows)
                {
                    horaI = dr[6].ToString().Remove(dr[6].ToString().Length - 3);
                    horaF = dr[7].ToString().Remove(dr[7].ToString().Length - 3);
                }
                dwHoraInicio.SelectedItem.Text = horaI;
                dwHoraFinal.SelectedItem.Text = horaF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarDatosHoras()
        {
            try
            {
                string valorHora = "";
                Negocio.Hora ngu = new Negocio.Hora();
                DataTable dt = new DataTable();
                dt = ngu.ConsultaHoraxCancha(Convert.ToInt32(Session["idCanchaConsultaHoras"].ToString()));
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[0].ToString().Length > 5)
                        valorHora = dr[0].ToString().Remove(dr[0].ToString().Length - 3);
                    else
                        valorHora = dr[0].ToString();
                    DataRow row = dtHorasFinal.NewRow();
                    row["Hora"] = valorHora;
                    row["Precio"] = dr[1].ToString();
                    row["id"] = dr[2].ToString();
                    dtHorasFinal.Rows.Add(row);
                }
                gvHoras.DataSource = dtHorasFinal;
                gvHoras.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void AgregarHoras()
        {
            try
            {
                for (int i = 0; i < 24; i++)
                {
                    ListItem valor;
                    if (i == 0)
                        valor = new ListItem(i.ToString() + "0:00", i.ToString() + "0:00");
                    else
                        valor = new ListItem(i.ToString() + ":00", i.ToString() + ":00");
                    dwHoraInicio.Items.Add(valor);
                }

                for (int i = 0; i < 24; i++)
                {
                    ListItem valores;
                    if (i == 0)
                        valores = new ListItem(i.ToString() + "0:00", i.ToString() + "0:00");
                    else
                        valores = new ListItem(i.ToString() + ":00", i.ToString() + ":00");
                    dwHoraFinal.Items.Add(valores);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void CargarPrecioHoras()
        {
            bool existe = false;
            string valorHora = "";
            try
            {
                foreach (DataRow dr in dtHorasFinal.Rows)
                {
                    if (dr[0].ToString().Length > 5)
                        valorHora = dr[0].ToString().Remove(dr[0].ToString().Length - 3);
                    else
                        valorHora = dr[0].ToString();
                    if (dwHora.SelectedItem.Text == valorHora)
                    {
                        txtPrecioHora.Text = dr[1].ToString();
                        existe = true;
                    }
                }

                if (!existe)
                    txtPrecioHora.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarHorasCancha(int pHoraIncio, int pHoraFin)
        {
            try
            {
                dwHora.Items.Clear();
                for (int i = pHoraIncio; i < pHoraFin; i++)
                {
                    ListItem valor;
                    if (i == 0)
                        valor = new ListItem(i.ToString() + "0:00", i.ToString() + "0:00");
                    else
                        valor = new ListItem(i.ToString() + ":00", i.ToString() + ":00");
                    dwHora.Items.Add(valor);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void ValidarRangoHoras(String pHoraInnicio, String pHoraFin)
        {

            try
            {
                string[] horaInicio = pHoraInnicio.Split(' ', ':');
                string[] horafin = pHoraFin.Split(' ', ':');
                int valorHoraInicio = Convert.ToInt32(horaInicio[0].ToString());
                int valorHoraFin = Convert.ToInt32(horafin[0].ToString());

                if (valorHoraInicio > valorHoraFin)
                {
                    //errorHoras.Visible = true;
                }
                else
                {
                    //errorHoras.Visible = false;
                    AgregarHorasCancha(valorHoraInicio, valorHoraFin);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        protected void btnCancha_Click(object sender, EventArgs e)
        {
            try
            {
                Negocio.Hora ngp = new Negocio.Hora();
                ngp.Modificar(dtHorasFinal, Convert.ToInt32(Session["idCanchaConsultaHoras"].ToString()));
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Modificación con Exito');" +
                    "setTimeout(function(){window.location.href ='../Canchas/ConsultarHoras.aspx'}, 0000);", true);
                //Response.Redirect("~/Pages/Login.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnAgregarHora_Click(object sender, EventArgs e)
        {
            bool existe = false;
            try
            {
                string valorHora = "";
                foreach (DataRow dr in dtHorasFinal.Rows)
                {
                    if (dr[0].ToString().Length > 5)
                        valorHora = dr[0].ToString().Remove(dr[0].ToString().Length - 3);
                    else
                        valorHora = dr[0].ToString();

                    if (dwHora.SelectedItem.Text == valorHora)
                    {
                        dtHorasFinal.Rows[0]["Hora"] = dwHora.SelectedValue;
                        dtHorasFinal.Rows[0]["Precio"] = txtPrecioHora.Text;
                        existe = true;
                    }
                }

                if (!existe)
                {
                    if (dwHora.SelectedValue != string.Empty)
                    {
                        DataRow row = dtHorasFinal.NewRow();
                        row["Hora"] = dwHora.SelectedValue;
                        row["Precio"] = txtPrecioHora.Text;
                        row["id"] = -1;
                        dtHorasFinal.Rows.Add(row);                        
                    }
                    else
                    {
                        txtPrecioHora.Enabled = false;
                    }
                }
                gvHoras.DataSource = dtHorasFinal;
                gvHoras.DataBind();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void dwHora_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarPrecioHoras();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}