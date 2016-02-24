using ejemploAJAX.Contracts.Security;
using ejemploAJAX.DTO.Security;
using ejemploAJAX.Infraestructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ejemploAJAX.Services.Security
{
    /*Clase que implementa el CONTRACT- INTERFACE*/
    public class LoginService : ILoginService
    {

        /*Objeto propio .NET para la conexion a base de datos*/
        private SqlConnection Conexion { get; set; }


        #region constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public LoginService()
        {

        }

        #endregion

        #region Public Members

        public IList<String> LoginUser(LoginDTO obj)
        {
            /*Se define un array con posiciones nombradas*/
            String[] data = { "User", obj.User, "Key", obj.Password };

            /*Lista que almacenara la respuesta de la consulta*/
            List<String> res = new List<String>();

            try
            {
                /*Se instancia el objeto, y solo estara en memoria mientras este en el using, ademas
                 se instanca la conexion a partir de la clase Connection definida manualmente*/
                using (Conexion = new Connection().Conexion)
                {

                    /*Se establece objeto para encapsular el comando*/
                    IDbCommand comando = Conexion.CreateCommand();
                    /*Se establece objeto para añadir parametros*/
                    IDbDataParameter parametro = comando.CreateParameter();


                    /*Se añade la conexion establecida al comando*/
                    comando.Connection = Conexion;
                    /*Se define que se ejecutara un procedimiento almacenado*/
                    comando.CommandType = CommandType.StoredProcedure;
                    /*Se indica el nombre del procedimiento almacenado a ejecutar*/
                    comando.CommandText = "validarUsuario";


                    //AÑADIR PARAMETROS AL PROCEDIMIENTO ALMACENADO

                    /*Se instancia a partir del comando un nuevo parametro para el procedimiento almacenado*/
                    parametro = comando.CreateParameter();
                    /*Se define el nombre del parametro*/
                    parametro.ParameterName = "@usuario";
                    /*se le da valor al parametro a partir del DTO recibido*/
                    parametro.Value = obj.User;
                    /*Se añade el parametro al comando*/
                    comando.Parameters.Add(parametro);

                    /*Se instancia a partir del comando un nuevo parametro para el procedimiento almacenado*/
                    parametro = comando.CreateParameter();
                    /*Se define el nombre del parametro*/
                    parametro.ParameterName = "@password";
                    /*se le da valor al parametro a partir del DTO recibido*/
                    parametro.Value = obj.Password;
                    /*Se añade el parametro al comando*/
                    comando.Parameters.Add(parametro);

                    /*Se abre la conexion a la base de datos*/
                    Conexion.Open();
                    /*Se ejecuta el comando establecido hasta el momento, indicando que tan pronto ejecute se cierre 
                     la conexion, ademas el resultado se almacena en un reader*/
                    IDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);
                    /*Se saca el numero de columnas, para controlar la lectura*/
                    int columns = dr.FieldCount;

                    /*Mientras se encuentre un registro para leer*/
                    while (dr.Read())
                    {
                        /*Por cada columna de cada registro leido*/
                        for (int i = 0; i < columns; i++)
                        {
                            /*Añada la columna a la lista de respuesta, adicionalmente con el TRIM
                             Quita todos los caracteres de espacio en blanco del principio y el final de la cadena */
                            res.Add(dr.GetValue(i).ToString().Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                /*Se añade el error*/
                res.Add(String.Format("Error: {0}", ex.Message));
            }

            return res;
        }

        #endregion
    }
}
