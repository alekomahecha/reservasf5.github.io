using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DAOHora
    {
        public int id;
        public string hora;
        public string precio;
        public int idCancha;

        conexion cn = new conexion();

        public int RegistrarHora()
        {
            int Resultado = 0;
            try
            {
                id = GenerarID();
                string query = "INSERT INTO `hora`(`id`, `hora`, `precio`, `estado`, `fecharegistro`, `idcancha`) VALUES (" +
                    id + ",'"
                    + hora + "','"
                    + precio + "','"                    
                    + 1 + "','"
                    + DateTime.UtcNow.ToString() + "',"
                    + idCancha + ")";

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
        public Boolean ModificarHora()
        {
            Boolean Resultado = false;
            Int32 valor;
            try
            {
                string query = "UPDATE `hora` SET " +
                    "hora= '" + hora + "'," +
                    "precio= '" + precio + "'," +                    
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
        public Boolean EliminarHora()
        {
            Boolean Resultado = false;
            Int32 valor;
            try
            {
                string query = "UPDATE `hora` SET " +
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
        public DataTable ConsultaHora()
        {
            DataTable tablaRetorno = new DataTable();
            try
            {
                string query = "select * from hora";
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
                string query = "select max(id) as id from hora";
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
        public DataTable ConsultaHoraxCanchaListaDesplegable(int pIdCancha)
        {
            DataTable tablaRetorno = new DataTable();
            try
            {
                string query = "SELECT  `id`, `hora`" +
                    "FROM `hora` WHERE estado = 1 and idCancha ="+ pIdCancha + "";
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
        public DataTable ConsultaPrecioHoraxCanchaid(int pId)
        {
            DataTable tablaRetorno = new DataTable();
            try
            {
                string query = "SELECT  `precio`" +
                    "FROM `hora` WHERE estado = 1 and id =" + pId + "";
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
        public DataTable ConsultaHoraxCancha(int pIdCancha)
        {
            DataTable tablaRetorno = new DataTable();
            try
            {
                string query = "SELECT  `hora`, `precio`,`id`" +
                    "FROM `hora` WHERE estado = 1 and idCancha =" + pIdCancha + "";
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
