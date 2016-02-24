using ejemploAJAX.Contracts.Administracion;
using ejemploAJAX.DTO.Administracion;
using ejemploAJAX.Infraestructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ejemploAJAX.Services.Administracion
{
    public class UsuarioService : IUsuarioService
    {

        private SqlConnection Conn { get; set; }


        #region constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public UsuarioService()
        {

        }

        #endregion


        #region Public Members

        public IList<String> SaveInfo(UsuarioDTO obj)
        {

            List<String> list = new List<String>();

            try
            {
                using (Conn = new Connection().Conexion)
                {

                    IDbCommand comm = Conn.CreateCommand();
                    IDbDataParameter dp = comm.CreateParameter();
                    comm.Connection = Conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.CommandText = "guardarUsuario";


                    //AÑADIR PARAMETROS AL PROCEDIMIENTO ALMACENADO
                    dp = comm.CreateParameter();
                    dp.ParameterName = "@Id";
                    dp.Value = obj.Id;
                    comm.Parameters.Add(dp);

                    dp = comm.CreateParameter();
                    dp.ParameterName = "@Usuario";
                    dp.Value = obj.Usuario;
                    comm.Parameters.Add(dp);


                    dp = comm.CreateParameter();
                    dp.ParameterName = "@Password";
                    dp.Value = obj.Password;
                    comm.Parameters.Add(dp);

                    Conn.Open();
                    IDataReader dr = comm.ExecuteReader(CommandBehavior.CloseConnection);
                    int columns = dr.FieldCount;

                    while (dr.Read())
                    {
                        for (int i = 0; i < columns; i++)
                        {
                            list.Add(dr.GetValue(i).ToString().Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                list.Add(String.Format("Error: {0}", ex.Message));
            }

            return list;
        }




        public IList<String> SearchInfo(String usuario)
        {

            List<String> list = new List<String>();

            try
            {
                using (Conn = new Connection().Conexion)
                {

                    IDbCommand comm = Conn.CreateCommand();
                    IDbDataParameter dp = comm.CreateParameter();
                    comm.Connection = Conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.CommandText = "buscarUsuario";


                    //AÑADIR PARAMETROS AL PROCEDIMIENTO ALMACENADO
                    dp = comm.CreateParameter();
                    dp.ParameterName = "@Usuario";
                    dp.Value = usuario;
                    comm.Parameters.Add(dp);


                    Conn.Open();
                    IDataReader dr = comm.ExecuteReader(CommandBehavior.CloseConnection);
                    int columns = dr.FieldCount;

                    while (dr.Read())
                    {
                        for (int i = 0; i < columns; i++)
                        {
                            list.Add(dr.GetValue(i).ToString().Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                list.Add(String.Format("Error: {0}", ex.Message));
            }

            return list;
        }




        public IList<String> DeleteInfo(int id)
        {

            List<String> list = new List<String>();

            try
            {
                using (Conn = new Connection().Conexion)
                {

                    IDbCommand comm = Conn.CreateCommand();
                    IDbDataParameter dp = comm.CreateParameter();
                    comm.Connection = Conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.CommandText = "eliminarUsuario";

                    //AÑADIR PARAMETROS AL PROCEDIMIENTO ALMACENADO
                    dp = comm.CreateParameter();
                    dp.ParameterName = "@Id";
                    dp.Value = id;
                    comm.Parameters.Add(dp);

                    Conn.Open();
                    IDataReader dr = comm.ExecuteReader(CommandBehavior.CloseConnection);
                    int columns = dr.FieldCount;

                    while (dr.Read())
                    {
                        for (int i = 0; i < columns; i++)
                        {
                            list.Add(dr.GetValue(i).ToString().Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                list.Add(String.Format("Error: {0}", ex.Message));
            }

            return list;
        }


                
        public IList<String> ListInfo()
        {

            List<String> list = new List<String>();

            try
            {
                using (Conn = new Connection().Conexion)
                {

                    IDbCommand comm = Conn.CreateCommand();
                    IDbDataParameter dp = comm.CreateParameter();
                    comm.Connection = Conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.CommandText = "listarUsuario";

                    Conn.Open();
                    IDataReader dr = comm.ExecuteReader(CommandBehavior.CloseConnection);
                    int columns = dr.FieldCount, rows = 0;

                    while (dr.Read())
                    {
                        for (int i = 0; i < columns; i++)
                        {
                            list.Add(dr.GetValue(i).ToString().Trim());
                        }

                        rows++;
                    }

                    if (list.Count > 0)
                    {
                        list.Add(columns + "");
                        list.Add(rows + "");
                    }

                }
            }
            catch (Exception ex)
            {
                list.Add(String.Format("Error: {0}", ex.Message));
            }

            return list;
        }


        #endregion

    }
}