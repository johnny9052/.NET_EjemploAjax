using ejemploAJAX.Contracts.Reporte;
using ejemploAJAX.Infraestructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ejemploAJAX.Services.Reporte
{
    public class Reporte1Service : IReporte1Service
    {

        private SqlConnection Conn { get; set; }




        public IList<String> GenerarReporte()
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
                    comm.CommandText = "generarReporte1";

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


    }
}