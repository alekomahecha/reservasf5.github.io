using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Negocio
{
    public class Cancha
    {
        public int Registrar(String pNombreCancha, String pNumerochancha,
            String pDireccion, String pBarrio, String
            pTelefono, String pHoraInicio, String pHoraFin,int pIdUsuario)
        {

            int result = 0;
            Model.DAOCancha cx = new Model.DAOCancha();
            try
            {
                cx.nombrecancha = pNombreCancha;
                cx.numerocancha = pNumerochancha;
                cx.direccion = pDireccion;
                cx.barrio = pBarrio;
                cx.telefono = pTelefono;
                cx.horainicio = pHoraInicio;
                cx.horafin = pHoraFin;
                cx.idusuario = pIdUsuario;
                result = cx.RegistrarCancha();
            }
            catch (Exception ex)
            {
                result = 0;
                throw ex;
            }
            return result;
        }

        public Boolean Modificar(Int32 pId, String pNombreCancha, String pNumerochancha,
            String pDireccion, String pBarrio, String
            pTelefono, String pHoraInicio, String pHoraFin)
        {

            Boolean result = false;
            Model.DAOCancha cx = new Model.DAOCancha();
            try
            {
                cx.id = pId;
                cx.nombrecancha = pNombreCancha;
                cx.numerocancha = pNumerochancha;
                cx.direccion = pDireccion;
                cx.barrio = pBarrio;
                cx.telefono = pTelefono;
                cx.horainicio = pHoraInicio;
                cx.horafin = pHoraFin;
                cx.ModificarCancha();
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
            Model.DAOCancha cx = new Model.DAOCancha();
            try
            {
                cx.id = pId;
                cx.EliminarCancha();
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
            Model.DAOCancha cx = new Model.DAOCancha();
            try
            {
                dt = cx.ConsultaCancha();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable ConsultarCanchaxBarrio(String pBarrio)
        {
            DataTable dt = new DataTable();
            Model.DAOCancha cx = new Model.DAOCancha();
            try
            {
                dt = cx.ConsultaCanchaxBarrio(pBarrio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
