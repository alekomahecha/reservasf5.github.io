using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class conexion
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        string myConnectionString = "server=127.0.0.1; username=root; password=; port=3306; database=sistemareservas";

        public Boolean conectar()
        {
            Boolean retorno;
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                conn.Open();
                retorno = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                retorno = false;
            }
            return retorno;
        }

        //Close connection
        public Boolean cerrar()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Error al cerrar [" + ex.Number + "]: " + ex.Message);
                return false;
            }
        }

        public int TransaccionBase(String query)
        {
            int retorno;
            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                retorno = Convert.ToInt32(cmd.ExecuteScalar());
                
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw ex;
            }
            return retorno;

        }

        public DataTable Consultar(String query)
        {
            DataTable dataSet = new DataTable();
            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                MySqlDataReader cursor = cmd.ExecuteReader();
                dataSet.Load(cursor);
                return dataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }


}
