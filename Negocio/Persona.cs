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
    public class Persona
    {
        public int Registrar(String pTipoDoc, String pNumeroDoc,
            String pNombre, String pApellido, String
            pCorreo, String pTelefono)
        {

            int result = 0;
            Model.DAOPersona cx = new Model.DAOPersona();
            try
            {
                cx.tipoIdentificacion = pTipoDoc;
                cx.numeroIdentificacion = pNumeroDoc;
                cx.nombre = pNombre;
                cx.apellido = pApellido;
                cx.correo = pCorreo;
                cx.telefono = pTelefono;
                result = cx.RegistrarPersona();               
            }
            catch (Exception ex)
            {
                result = 0;
                throw ex;
            }
            return result;
        }

        public Boolean Modificar(Int32 pId, String pTipoDoc, String pNumeroDoc,
            String pNombre, String pApellido, String
            pCorreo, String pTelefono)
        {

            Boolean result = false;
            Model.DAOPersona cx = new Model.DAOPersona();
            try
            {
                cx.id = pId;
                cx.tipoIdentificacion = pTipoDoc;
                cx.numeroIdentificacion = pNumeroDoc;
                cx.nombre = pNombre;
                cx.apellido = pApellido;
                cx.correo = pCorreo;
                cx.telefono = pTelefono;
                cx.ModificarPersona();
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
            Model.DAOPersona cx = new Model.DAOPersona();
            try
            {
                cx.id = pId;
                cx.EliminarPersona();
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
            Model.DAOPersona cx = new Model.DAOPersona();
            try
            {
                dt = cx.ConsultaPersona();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable ConsultaPersonaxNumeroDocumento(String pNumDoc)
        {
            DataTable dt = new DataTable();
            Model.DAOPersona cx = new Model.DAOPersona();
            try
            {
                dt = cx.ConsultaPersonaxNumeroDocumento(pNumDoc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable ConsultaPersonaxId(int pid)
        {
            DataTable dt = new DataTable();
            Model.DAOPersona cx = new Model.DAOPersona();
            try
            {
                dt = cx.ConsultaPersonaxId(pid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}


