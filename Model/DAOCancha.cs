using System;
using System.Data;

namespace Model
{
    public class DAOCancha
    {
        public int id;
        public string nombrecancha;
        public string numerocancha;
        public string direccion;
        public string barrio;
        public string telefono;
        public string horainicio;
        public string horafin;
        public int idusuario;

        conexion cn = new conexion();

        public int RegistrarCancha()
        {
            int Resultado = 0;
            try
            {
                id = GenerarID();
                string query = "INSERT INTO `cancha` (`id`, `nombrecancha`, `numerocancha`, `direccion`," +
                    "`barrio`,`telefono`,`horainicio`,`horafin`, `estado`,`fecharegistro`,`idusuario`) VALUES (" +
                    id + ",'"
                    + nombrecancha + "','"
                    + numerocancha + "','"
                    + direccion + "','"
                    + barrio + "','"
                    + telefono + "','"
                    + horainicio + "','"
                    + horafin + "','"
                    + 1 + "','"
                    + DateTime.UtcNow.ToString() + "',"
                    + idusuario + ")";

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
        public Boolean ModificarCancha()
        {
            Boolean Resultado = false;
            Int32 valor;
            try
            {
                string query = "UPDATE `cancha` SET " +
                    "nombrecancha= '" + nombrecancha + "'," +
                    "numerocancha= '" + numerocancha + "'," +
                    "direccion= '" + direccion + "'," +
                    "barrio= '" + barrio + "'," +
                    "telefono= '" + telefono + "'," +
                    "horainicio= '" + horainicio + "'," +
                    "horafin= '" + horafin + "'," +
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
        public Boolean EliminarCancha()
        {
            Boolean Resultado = false;
            Int32 valor;
            try
            {
                string query = "UPDATE `cancha` SET " +
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
        public DataTable ConsultaCancha()
        {
            DataTable tablaRetorno = new DataTable();
            try
            {
                string query = "select * from cancha";
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
                string query = "select max(id) as id from cancha";
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

        public DataTable ConsultaCanchaxBarrio(String pBarrio)
        {
            DataTable tablaRetorno = new DataTable();
            try
            {
                string query = "SELECT id,nombrecancha,numerocancha,barrio,direccion,telefono,horainicio,horafin " +
                    "FROM `cancha` WHERE estado=1 and barrio like'%"+ pBarrio + "%'";

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

        public DataTable ConsultaNombrexIdCancha(int pIdCancha)
        {
            DataTable tablaRetorno = new DataTable();
            try
            {
                string query = "select nombrecancha from cancha where id = "+ pIdCancha +"";
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
