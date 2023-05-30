using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Hora
    {
        public int Registrar(DataTable pHoras, int pIdcancha)
        {

            int result = 0;
            Model.DAOHora cx = new Model.DAOHora();
            try
            {
                foreach (DataRow dr in pHoras.Rows)
                {
                    cx.hora = dr[0].ToString();
                    cx.precio = dr[1].ToString(); ;
                    cx.idCancha = pIdcancha;
                    result = cx.RegistrarHora();
                }
            }
            catch (Exception ex)
            {
                result = 0;
                throw ex;
            }
            return result;
        }
        public Boolean Modificar(DataTable pHoras, int pIdcancha)
        {

            Boolean result = false;
            Model.DAOHora cx = new Model.DAOHora();
            try
            {
                foreach (DataRow dr in pHoras.Rows)
                {
                    if (dr[2].ToString() == "-1")
                    {
                        cx.hora = dr[0].ToString();
                        cx.precio = dr[1].ToString(); ;
                        cx.idCancha = pIdcancha;
                        cx.RegistrarHora();
                    }
                    else
                    {                        
                        cx.hora = dr[0].ToString();
                        cx.precio = dr[1].ToString(); ;
                        cx.id = Convert.ToInt32(dr[2].ToString());
                        cx.idCancha = pIdcancha;
                        cx.ModificarHora();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public Boolean Eliminar(Int32 pId)
        {
            Boolean result = false;
            Model.DAOHora cx = new Model.DAOHora();
            try
            {
                cx.id = pId;
                cx.EliminarHora();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }
        public DataTable Consultar()
        {
            DataTable dt = new DataTable();
            Model.DAOHora cx = new Model.DAOHora();
            try
            {
                dt = cx.ConsultaHora();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable ConsultaHoraxCanchaListaDesplegable(int pIdCancha)
        {
            DataTable dt = new DataTable();
            Model.DAOHora cx = new Model.DAOHora();
            try
            {
                dt = cx.ConsultaHoraxCanchaListaDesplegable(pIdCancha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable ConsultaPrecioHoraxCanchaid(int pId)
        {
            DataTable dt = new DataTable();
            Model.DAOHora cx = new Model.DAOHora();
            try
            {
                dt = cx.ConsultaPrecioHoraxCanchaid(pId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable ConsultaHoraxCancha(int pIdCancha)
        {
            DataTable dt = new DataTable();
            Model.DAOHora cx = new Model.DAOHora();
            try
            {
                dt = cx.ConsultaHoraxCancha(pIdCancha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

    }
}
