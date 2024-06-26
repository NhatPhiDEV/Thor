﻿using System.Data.SqlClient;

namespace Thor.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString = "Server=.;Database=SchoolDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;";

        public SqlTransaction _transaction;

        public SqlTransaction Transaction
        {
            get { return _transaction; }
        }

        public void BeginTransaction()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            _transaction = connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
            _transaction.Dispose();
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }
        }

    }
}
