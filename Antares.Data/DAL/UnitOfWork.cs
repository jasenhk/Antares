using System;

namespace Antares.Data
{
    public interface IUnitOfWork
    {
        UsersContext Context { get; }
        void Save();
    }

    public class UnitOfWork : IDisposable
    {
        protected string ConnectionString;
        private UsersContext context;

        public UnitOfWork(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public UsersContext UsersContext
        {
            get
            {
                if (context == null)
                {
                    context = new UsersContext(ConnectionString);
                    return context;
                }
                return context;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

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