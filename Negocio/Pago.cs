using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Negocio
{
    public class Pago
    {
        public int Registrar(String pFechaPago, String pAbono,
           double pMontoAbono,String pTipoPago ,String pTotalPago, double pTotalValorPago, int pIdReserva)
        {

            int result = 0;
            Model.DAOPago cx = new Model.DAOPago();
            try
            {
                cx.fechapago = pFechaPago;
                cx.abono = pAbono;
                cx.montoabono = pMontoAbono;
                cx.tipopago = pTipoPago;
                cx.totalpago = pTotalPago;
                cx.totalvalorpago = pTotalValorPago;
                cx.idreserva = pIdReserva;
                result = cx.RegistrarPago();
            }
            catch (Exception ex)
            {
                result = 0;
                throw ex;
            }
            return result;
        }

        public Boolean Modificar(Int32 pId, String pFechaPago, String pAbono,
           double pMontoAbono, String pTotalPago, double pTotalValorPago, int pIdReserva)
        {

            Boolean result = false;
            Model.DAOPago cx = new Model.DAOPago();
            try
            {
                cx.fechapago = pFechaPago;
                cx.abono = pAbono;
                cx.montoabono = pMontoAbono;
                cx.totalpago = pTotalPago;
                cx.totalvalorpago = pTotalValorPago;
                cx.idreserva = pIdReserva;
                cx.ModificarPago();
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
            Model.DAOPago cx = new Model.DAOPago();
            try
            {
                cx.id = pId;
                cx.EliminarPago();
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
            Model.DAOPago cx = new Model.DAOPago();
            try
            {
                dt = cx.ConsultaPago();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
