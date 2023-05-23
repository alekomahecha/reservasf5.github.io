using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DAOPersona
    {
        public int id;
        public string tipoIdentificacion;
        public string numeroIdentificacion;
        public string nombre;
        public string apellido;
        public string correo;
        public string telefono;

        conexion cn = new conexion();

        public int RegistrarPersona()
        {
            int Resultado = 0;            
            try
            {
                id = GenerarID();
                string query = "INSERT INTO `persona` (`id`, `tipoIdentificacion`, `numeroIdentificacion`, `nombre`," +
                    "`apellido`,`correo`,`telefono`,`estado`,`fechaRegistro`) VALUES (" +
                    id + ",'"
                    + tipoIdentificacion + "','"
                    + numeroIdentificacion + "','"
                    + nombre + "','"
                    + apellido + "','"
                    + correo + "','"
                    + telefono + "','"
                    + 1 + "','"
                    + DateTime.UtcNow.ToString() + "')";

                if (cn.conectar() == true)
                {
                    Resultado = cn.TransaccionBase(query);
                    Resultado = id;
                }                
            }
            catch (Exception ex)
            {
                Resultado = 0;
                throw;
            }
            return Resultado;
        }
        public Boolean ModificarPersona()
        {
            Boolean Resultado = false;
            Int32 valor;
            try
            {
                string query = "UPDATE `persona` SET " +
                    "tipoIdentificacion= '" + tipoIdentificacion + "'," +
                    "numeroIdentificacion= '" + numeroIdentificacion + "'," +
                    "nombre= '" + nombre + "'," +
                    "apellido= '" + apellido + "'," +
                    "correo= '" + correo + "'," +
                    "telefono= '" + telefono + "'," +
                    "Estado= '" + 1 + "'," +
                    "fechaRegistro= '" + DateTime.UtcNow.ToString() + "' " +
                    " WHERE id = " + id;                    

                if (cn.conectar() == true)
                {
                    valor = cn.TransaccionBase(query);
                    Resultado = true;
                }
            }
            catch (Exception ex)
            {
                Resultado = false;
                throw;
            }
            return Resultado;
        }
        public Boolean EliminarPersona()
        {
            Boolean Resultado = false;
            Int32 valor;
            try
            {
                string query = "UPDATE `persona` SET " +
                    "Estado= '" + 0 + "'," +
                    "fechaRegistro= '" + DateTime.UtcNow.ToString() + "' " +
                    " WHERE id = " + id;

                if (cn.conectar() == true)
                {
                    valor = cn.TransaccionBase(query);
                    Resultado = true;
                }
            }
            catch (Exception ex)
            {
                Resultado = false;
                throw;
            }
            return Resultado;
        }
        public DataTable ConsultaPersona()
        {
            DataTable tablaRetorno = new DataTable();
            try
            {
                string query = "select * from persona";
                //string query = "select max(codigo) as id from departamento";
                if (cn.conectar() == true)
                {
                    tablaRetorno = cn.Consultar(query);                    
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return tablaRetorno;
        }
        public int GenerarID()
        {
            int Count = 0;
            try
            {
                DataTable tablaRetorno = new DataTable();
                string query = "select max(id) as id from persona";
                //string query = "select max(codigo) as id from departamento";
                if (cn.conectar() == true)
                {
                    tablaRetorno = cn.Consultar(query);
                    foreach (DataRow item in tablaRetorno.Rows)
                    {
                        if (item[0].ToString() != String.Empty)
                            Count = Convert.ToInt32(item[0].ToString()) + 1;
                        else
                            Count = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Count;

        }
        public DataTable ConsultaPersonaxNumeroDocumento(String pNumDoc)
        {
            DataTable tablaRetorno = new DataTable();
            try
            {
                string query = "select * from persona where numeroidentificacion = '"+ pNumDoc +"'";
                //string query = "select max(codigo) as id from departamento";
                if (cn.conectar() == true)
                {
                    tablaRetorno = cn.Consultar(query);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return tablaRetorno;
        }


    }
}
