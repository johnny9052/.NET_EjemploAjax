using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ejemploAJAX.Infraestructure
{
    public class Connection
    {
        /*Objeto propio .NET para la conexion a base de datos*/
        public SqlConnection Conexion { get; set; }

        /*Cadena de conexion que se encuentra en el web config*/
        private String connectionString;


        public Connection()
        {
            /*Se obtiene la cadena de conexion*/
            connectionString = GetConnectionString();
            /*Se realiza la conexion a partir de la cadena*/
            Conexion = new SqlConnection(connectionString);
        }


        /*Retorna la cedena de conexion*/
        private String GetConnectionString()
        {
            String connectionString = ConfigurationManager.ConnectionStrings["SecurityConnection"].ToString();
            return connectionString;
        }


    }
}