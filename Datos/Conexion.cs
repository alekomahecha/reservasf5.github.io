namespace Datos
{
    public class Conexion
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        string myConnectionString = "server=localhost;uid=root;"
            + "pwd=usbw;database=empleados";

        public string conectar()
        {
            string retorno;
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                conn.Open();
                retorno = "Conecto";
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                retorno = ex.Message;
            }
            return retorno;
        }
    }
}