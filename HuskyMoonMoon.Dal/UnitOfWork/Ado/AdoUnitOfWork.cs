using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuskyMoonMoon.Dal.UnitOfWork.Ado
{
    /// <summary>
    /// Provide base implementation of ADO.NET based Unit-of-Work
    /// </summary>
    public class AdoUnitOfWork: IUnitOfWork
    {
        public bool HasConnection { get; set; }
        public IDbTransaction Transaction { get; set; }
        public IDbConnection Connection { get; set; }

        private bool disposed = false;

        public AdoUnitOfWork(IDbConnection connection, bool hasConnection)
        {
            Connection = connection;
            HasConnection = hasConnection;
            Transaction = connection.BeginTransaction();
        }

        public IDbCommand CreateCommand()
        {
            var command = Connection.CreateCommand();
            command.Transaction = Transaction;
            return command;
        }

        public void SaveChanges()
        {
            if (Transaction == null)
            {
                throw new InvalidOperationException("Cannot commit transaction");
            }

            Transaction.Commit();
            Transaction = null;
        }

        private void ReleaseUnmanagedResources()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
                Transaction = null;
            }

            if (Connection != null && HasConnection)
            {
                Connection.Close();
                Connection = null;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            ReleaseUnmanagedResources();

            if (disposing)
            {
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~AdoUnitOfWork()
        {
            Dispose(false);
        }

    }
}
