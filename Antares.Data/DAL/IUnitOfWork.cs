using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Antares.Data
{
    public interface IUnitOfWork : IDisposable
    {
        AntaresContext DbContext { get; }
        int Save();
    }
}
