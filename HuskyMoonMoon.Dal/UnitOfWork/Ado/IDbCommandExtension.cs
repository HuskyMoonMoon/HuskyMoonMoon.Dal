using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuskyMoonMoon.Dal.UnitOfWork.Ado
{
    /// <summary>
    /// Provide System.Data.IDbCommand extensions
    /// </summary>
    public static class IDbCommandExtension
    {
        /// <summary>
        /// Execute IDbCommand and return as System.Data.DataSet
        /// </summary>
        public static DataSet ExecuteToDataSet(this IDbCommand dbCommand)
        {
            DataSet dataSet = new DataSet();
            ExecuteToDataSet(dbCommand, dataSet);
            return dataSet;
        }

        /// <summary>
        /// Execute IDbCommand and fill into given System.Data.DataSet
        /// </summary>
        /// <param name="dataSet">
        /// DataSet to fill
        /// </param>
        public static void ExecuteToDataSet(this IDbCommand dbCommand, DataSet dataSet)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(dbCommand.CommandText, dbCommand.Connection as SqlConnection);
            adapter.Fill(dataSet);
        }
    }
}
