using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Utils.UnityOfWork.Interface;
using NHibernate;

namespace Infra.Utils.UnityOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public UnitOfWork(ISession session)
        {
            _session = session;
        }

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public void Commit()
        {
            if (_transaction != null && _transaction.IsActive)
                _transaction.Commit();
        }

        public async Task CommitAsync()
        {
            if (_transaction != null && _transaction.IsActive)
                await _transaction.CommitAsync();
        }

        public void Rollback()
        {
            if (_transaction != null && _transaction.IsActive)
                _transaction.Rollback();
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null && _transaction.IsActive)
                await _transaction.RollbackAsync();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _session?.Dispose();
        }
    }
}
