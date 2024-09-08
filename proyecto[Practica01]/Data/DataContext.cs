using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Data
{
    public class DataContext
    {
        private readonly IDbConnection _connection;
        private readonly ConnectionFactory _connectionFactory;
        private readonly ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim();
        private readonly LinkedList<UnitOfWork> _uows = new LinkedList<UnitOfWork>();
        public DataContext(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _connection = _connectionFactory.Create();
        }
        public UnitOfWork CreateUnitOfWork()
        {
            var transaction = _connection.BeginTransaction();
            var uow = new UnitOfWork(transaction, RemoveTransaction, RemoveTransaction);
            _rwLock.EnterWriteLock();
            _uows.AddLast(uow);
            _rwLock.ExitWriteLock();
            return uow;
        }
        public IDbCommand CreateCommand()
        {
            var cmd = _connection.CreateCommand();
            _rwLock.EnterReadLock();
            if (_uows.Count > 0)
                cmd.Transaction = _uows.First.Value.Transaction;
            _rwLock.ExitReadLock();
            return cmd;
        }
        private void RemoveTransaction(UnitOfWork obj)
        {
            _rwLock.EnterWriteLock();
            _uows.Remove(obj);
            _rwLock.ExitWriteLock();
        }
        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
