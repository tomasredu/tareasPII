using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Data
{
    public class UnitOfWork : IDisposable
    {
        private IDbTransaction _transaction;
        private readonly Action<UnitOfWork> _rolledBack;
        private readonly Action<UnitOfWork> _committed;
        public UnitOfWork(IDbTransaction transaction, Action<UnitOfWork> rolledBack, Action<UnitOfWork> committed)
        {
            Transaction = transaction;
            _transaction = transaction;
            _rolledBack = rolledBack;
            _committed = committed;
        }
        public IDbTransaction Transaction { get; private set; }
        public void Dispose()
        {
            if (_transaction == null)
                return;
            _transaction.Rollback();
            _transaction.Dispose();
            _rolledBack(this);
            _transaction = null;
        }
        public void SaveChanges()
        {
            if (_transaction == null)
                throw new InvalidOperationException("No se puede guardar cambios dos veces.");
            _transaction.Commit();
            _committed(this);
            _transaction = null;
        }
    }
}
