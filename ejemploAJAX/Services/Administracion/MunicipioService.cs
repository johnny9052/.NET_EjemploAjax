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
    public class MunicipioService : IMunicipioService
    {



        private SqlConnection Conn { get; set; }


        #region constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public MunicipioService()
        {

        }

        #endregion


        #region Public Members

        public IList<String> SaveInfo(MunicipioDTO obj)
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
                    comm.CommandText = "guardarMunicipio";


                    //AÑADIR PARAMETROS AL PROCEDIMIENTO ALMACENADO
                    dp = comm.CreateParameter();
                    dp.ParameterName = "@Id";
                    dp.Value = obj.Id;
                    comm.Parameters.Add(dp);

                    dp = comm.CreateParameter();
                    dp.ParameterName = "@Nombre";
                    dp.Value = obj.Nombre;
                    comm.Parameters.Add(dp);


                    dp = comm.CreateParameter();
                    dp.ParameterName = "@Descripcion";
                    dp.Value = obj.Descripcion;
                    comm.Parameters.Add(dp);

                    dp = comm.CreateParameter();
                    dp.ParameterName = "@IdDepartamento";
                    dp.Value = obj.IdDepartamento;
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




        public IList<String> SearchInfo(String nombre)
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
                    comm.CommandText = "buscarMunicipio";


                    //AÑADIR PARAMETROS AL PROCEDIMIENTO ALMACENADO
                    dp = comm.CreateParameter();
                    dp.ParameterName = "@Nombre";
                    dp.Value = nombre;
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
                    comm.CommandText = "eliminarMunicipio";

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
                    comm.CommandText = "listarMunicipio";

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



        public IList<String> LoadDepartamento()
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
                    comm.CommandText = "cargarDepartamento";

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