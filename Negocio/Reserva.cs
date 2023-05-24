using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Negocio
{
    public class Reserva
    {
        public int Registrar(String pfechareserva)
        {

            int result = 0;

            Model.DAOReserva cx = new Model.DAOReserva();
            try
            {
                cx. fechareserva= pfechareserva;
                result = cx.RegistrarReserva();
            }
            catch (Exception ex)
            {
                result = 0;
                throw ex;
            }
            return result;
        }

        public Boolean Modificar(Int32 pId, String pfechaReserva)
        {

            Boolean result = false;
            Model.DAOReserva cx = new Model.DAOReserva();
            try
            {
                cx.id = pId;
                cx.fechareserva= pfechaReserva;
                cx.ModificarReserva();
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
            Model.DAOReserva cx = new Model.DAOReserva();
            try
            {
                cx.id = pId;
                cx.EliminarReserva();
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
            Model.DAOReserva cx = new Model.DAOReserva();
            try
            {
                dt = cx.ConsultaReserva();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
