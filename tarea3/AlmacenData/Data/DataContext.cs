using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Data
{
    public class DataContext
    {
        private readonly IDbConnection _connection;
        private readonly ConnectionFactory _connectionFactory;
        private SqlTransaction _transaction;

        public DataContext(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _connection = _connectionFactory.Create();
        }
        
        public IDbCommand CreateCommand()
        {
            var cmd = _connection.CreateCommand();
            return cmd;
        }

        public IDbCommand CreateCommandTransaction()
        {
            var cmd = _connection.CreateCommand();
            if( _transaction != null)
            {
                _transaction = null;
            }
            cmd.Transaction = _connection.BeginTransaction();
            _transaction = (SqlTransaction)cmd.Transaction;
            

            return cmd;
        }

        public IDbTransaction GetTransaction()
        {
            return _transaction;
        }



        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
