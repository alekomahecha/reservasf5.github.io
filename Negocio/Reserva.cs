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
        public int Registrar(String pfechareserva,Int32 pIdpersona,Int32 pIdcancha,Int32 pIdHoraReserva)
        {

            int result = 0;

            Model.DAOReserva cx = new Model.DAOReserva();
            try
            {
                cx.fechareserva= pfechareserva;
                cx.idPersona= pIdpersona;
                cx.idCancha= pIdcancha;
                cx.idHorareserva = pIdHoraReserva;
                result = cx.RegistrarReserva();
            }
            catch (Exception ex)
            {
                result = 0;
                throw ex;
            }
            return result;
        }

        public Boolean Modificar(Int32 pId, String pfechaReserva, Int32 pIdpersona, Int32 pIdcancha, Int32 pIdHoraReserva)
        {

            Boolean result = false;
            Model.DAOReserva cx = new Model.DAOReserva();
            try
            {
                cx.id = pId;
                cx.fechareserva= pfechaReserva;
                cx.idPersona = pIdpersona;
                cx.idCancha = pIdcancha;
                cx.idHorareserva = pIdHoraReserva;
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

        public DataTable ConsultaReservaxCancha(int pidCancha)
        {
            DataTable dt = new DataTable();
            Model.DAOReserva cx = new Model.DAOReserva();
            try
            {
                dt = cx.ConsultaReservaxCancha(pidCancha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
