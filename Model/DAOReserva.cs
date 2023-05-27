using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DAOReserva
    {
        public int id;
        public string fechareserva;
        public int idCancha;
        public int idHorareserva;
        public int idPersona;

        

        conexion cn = new conexion();
        public int RegistrarReserva()
        {
            int Resultado = 0;
            try
            {
                id = GenerarID();
                string query = "INSERT INTO `reserva`(`id`, `fechareserva`, `estado`, `fecharegistro`, `idpersona`, `idcancha`, `idhorareserva`) VALUES (" +
                    id + ",'"
                    + fechareserva + "','"
                    + 1 + "','"
                    + DateTime.UtcNow.ToString() + "',"
                    + idPersona + ","
                    + idCancha + ","
                    + idHorareserva +")";

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
        public Boolean ModificarReserva()
        {
            Boolean Resultado = false;
            Int32 valor;
            try
            {
                string query = "UPDATE `reserva` SET " +
                    "fechareserva= '" + fechareserva+ "'," +
                    "idpersona= " + idPersona+ "," +
                    "idcancha= " + idCancha+ "," +
                    "idhorareserva= " + idHorareserva+ "," +
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
        public Boolean EliminarReserva()
        {
            Boolean Resultado = false;
            Int32 valor;
            try
            {
                string query = "UPDATE `reserva` SET " +
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
        public DataTable ConsultaReserva()
        {
            DataTable tablaRetorno = new DataTable();
            try
            {
                string query = "select * from reserva";
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
                string query = "select max(id) as id from reserva";
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
        public DataTable ConsultaReservaxCancha(int pidCancha)
        {
            DataTable tablaRetorno = new DataTable();
            try
            {
                string query = "SELECT fechareserva,hr.hora " +
                    "FROM `reserva` rs INNER JOIN `hora` hr on rs.idhorareserva = hr.id " +
                    "WHERE rs.estado = 1 and rs.idCancha = "+pidCancha+"";
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

        public DataTable ConsultaReservaxidUsuario(int pidUsuario)
        {
            DataTable tablaRetorno = new DataTable();
            try
            {
                string query = "SELECT r.fechareserva,h.hora,h.precio,p.tipopago,p.totalvalorpago,p.tipopago, "+
                            "p.abono,p.montoabono,c.nombrecancha,CONCAT(per.nombre, ' ', per.apellido) As Nombre,per.telefono" +
                            " FROM `reserva` r "+
                            " inner join `hora` h on r.idhorareserva = h.id"+
                            " inner join `pago` p on r.id = p.idreserva"+
                            " inner join `cancha` c on c.id = r.idcancha"+
                            " inner join `persona` per on per.id = r.idpersona"+
                            " WHERE r.estado = 1 and c.idUsuario = " + pidUsuario + "";
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

