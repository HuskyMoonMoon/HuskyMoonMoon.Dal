using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuskyMoonMoon.Dal.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        bool HasConnection { get; set; }
        IDbTransaction Transaction { get; set; }
        IDbConnection Connection { get; set; }
        IDbCommand CreateCommand();
        void SaveChanges();
    }
}
