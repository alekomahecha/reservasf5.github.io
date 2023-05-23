using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Usuario
    {
        public Boolean Registrar(String pUsuario, String pContrasena,int pIdPersona)
        {

            Boolean result = false;
            Model.DAOUsuario cx = new Model.DAOUsuario();
            try
            {
                cx.usuario = pUsuario;
                cx.contrasena = pContrasena;
                cx.idPersona = pIdPersona;               
                cx.RegistrarUsuario();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        public Boolean Modificar(Int32 pId, String pUsuario, String pContrasena)
        {

            Boolean result = false;
            Model.DAOUsuario cx = new Model.DAOUsuario();
            try
            {
                cx.id = pId;
                cx.usuario = pUsuario;
                cx.contrasena = pContrasena;                
                cx.ModificarUsuario();
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
            Model.DAOUsuario cx = new Model.DAOUsuario();
            try
            {
                cx.id = pId;
                cx.EliminarUsuario();
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
            Model.DAOUsuario cx = new Model.DAOUsuario();
            try
            {
                dt = cx.ConsultaUsuario();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable AutenticacionUsuario(string pUsuario,string pContrasena)
        {
            DataTable dt = new DataTable();
            Model.DAOUsuario cx = new Model.DAOUsuario();
            try
            {
                dt = cx.AutenticarUsuario(pUsuario, pContrasena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }



    }
}
