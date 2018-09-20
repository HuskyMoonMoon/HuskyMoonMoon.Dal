using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuskyMoonMoon.Dal.UnitOfWork.Ado
{
    /// <summary>
    /// Provide System.Data.DataSet extensions
    /// </summary>
    public static class DataSetExtension
    {
        public static bool IsNullOrEmpty(this DataSet dataSet)
        {
            return dataSet != null || dataSet.Tables != null || dataSet.Tables.Count > 0;
        }
    }
}
