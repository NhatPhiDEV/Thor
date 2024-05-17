using System;
using System.Data.SqlClient;

namespace Thor.DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        SqlTransaction Transaction { get; }
    }
}
