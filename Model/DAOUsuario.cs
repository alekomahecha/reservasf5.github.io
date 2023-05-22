using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DAOUsuario
    {
        public int id;
        public string usuario;
        public string contrasena;
        public int idPersona;

        conexion cn = new conexion();

        public Boolean RegistrarUsuario()
        {
            Boolean Resultado = false;
            Int32 valor;
            try
            {
                id = GenerarID();
                string query = "INSERT INTO `usuario`(`id`, `usuario`, `contrasena`, `estado`, `fecharegistro`, `idpersona`) VALUES (" +
                      id + ",'"
                    + usuario + "','"
                    + contrasena + "',"                   
                    + 1 + ",'"
                    + DateTime.UtcNow.ToString() + "',"
                    + idPersona + ")";

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
        public Boolean ModificarUsuario()
        {
            Boolean Resultado = false;
            int valor;
            try
            {
                string query = "UPDATE usuario SET " +
                    "usuario= '" + usuario + "'," +
                    "contrasena= '" + contrasena + "'," +                   
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
        public Boolean EliminarUsuario()
        {
            Boolean Resultado = false;
            int valor;
            try
            {
                string query = "UPDATE usuario SET " +
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
        public DataTable ConsultaUsuario()
        {
            DataTable tablaRetorno = new DataTable();
            try
            {
                string query = "select * from usuario";
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
                string query = "select max(id) as id from usuario";
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
    }
}
