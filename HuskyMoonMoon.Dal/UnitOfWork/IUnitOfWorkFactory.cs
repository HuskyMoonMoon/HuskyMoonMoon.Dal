using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuskyMoonMoon.Dal.UnitOfWork
{

    public interface IUnitOfWorkFactory<T> where T : IUnitOfWork
    {
        /// <summary>
        /// Create Unit-of-Work from Named connection string defined in app.config
        /// </summary>
        /// <param name="connectionStringName"
        /// Connection string name
        /// </param>
        T Create(string connectionStringName);

        /// <summary>
        /// Create DbConnection from Named connection string defined in app.config
        /// </summary>
        /// <param name="connectionStringName"
        /// Connection string name
        /// </param>
        DbConnection CreateConnection(string connectionStringName);
    }
}
