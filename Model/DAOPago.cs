using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DAOPago
    {
        public int id;
        public string fechapago;
        public string abono;
        public double montoabono;
        public string totalpago;
        public string tipopago;
        public double totalvalorpago;
        public int idreserva;
        

        conexion cn = new conexion();

        public int RegistrarPago()
        {
            int Resultado = 0;
            try
            {
                id = GenerarID();
                string query = "INSERT INTO `pago` (`id`, `fechapago`,`abono`," +
                    "`montoabono`,`totalpago`,`tipopago`,`totalvalorpago`,`estado`,`fechaRegistro`,`idreserva`) VALUES (" +
                    id + ",'"
                    + fechapago + "','"
                    + abono+ "','"
                    + montoabono + "','"
                    + totalpago+ "','"
                    + tipopago + "','"
                    + totalvalorpago + "','"
                    + 1 + "','"
                    + DateTime.UtcNow.ToString() + "','"
                    +idreserva + "')";

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
        public Boolean ModificarPago()
        {
            Boolean Resultado = false;
            Int32 valor;
            try
            {
                string query = "UPDATE `pago` SET " +
                    "fechapago= '" + fechapago + "'," +
                    "abono= '" + abono + "'," +
                    "montoabono= '" + montoabono + "'," +
                    "totalpago= '" + totalpago + "'," +
                    "tipopago= '" + tipopago + "'," +
                    "totalvalorpago= '" + totalvalorpago + "'," +
                    "Estado= '" + 1 + "'," +
                    "fechaRegistro= '" + DateTime.UtcNow.ToString() + "' " +
                    "idreserva='" + idreserva+ "''"+
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
        public Boolean EliminarPago()
        {
            Boolean Resultado = false;
            Int32 valor;
            try
            {
                string query = "UPDATE `pago` SET " +
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
        public DataTable ConsultaPago()
        {
            DataTable tablaRetorno = new DataTable();
            try
            {
                string query = "select * from pago";
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
                string query = "select max(id) as id from pago";
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
