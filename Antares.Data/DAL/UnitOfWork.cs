using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Antares.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected string ConnectionString;
        private AntaresContext context;

        public UnitOfWork(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public AntaresContext DbContext
        {
            get
            {
                if (context == null)
                {
                    context = new AntaresContext(ConnectionString);
                }
                return context;
            }
        }

        #region IUnitOfWork Members

        public int Save()
        {
            return context.SaveChanges();
        }

        #endregion

        #region IDisposable Members


        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}