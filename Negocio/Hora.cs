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
        public int Registrar(String pHora,String pPrecio,int pIdcancha)
        {

            int result = 0;
            Model.DAOHora cx = new Model.DAOHora();
            try
            {
                cx.hora = pHora;
                cx.precio = pPrecio;
                cx.idCancha = pIdcancha;               
                result = cx.RegistrarHora();
            }
            catch (Exception ex)
            {
                result = 0;
                throw ex;
            }
            return result;
        }

        public Boolean Modificar(Int32 pId, String pHora, String pPrecio)
        {

            Boolean result = false;
            Model.DAOHora cx = new Model.DAOHora();
            try
            {
                cx.id = pId;
                cx.hora = pHora;
                cx.precio = pPrecio;
                cx.ModificarHora();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
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

    }
}
