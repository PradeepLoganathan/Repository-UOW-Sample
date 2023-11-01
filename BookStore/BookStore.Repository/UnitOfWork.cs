using System;
using System.Transactions;
using BookStore.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly DbContext _context;
        private bool _disposed;
        private TransactionScope _transactionScope;
       
        public UnitOfWork(DbContext bookStoreDbContext)
        {
            this._context = bookStoreDbContext;
        }

        public void BeginTransaction()
        {
            _transactionScope = new TransactionScope();
        }

        public void Commit()
        {
            _transactionScope.Complete();
        }

        public void RollBack()
        {
            _transactionScope.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<T> GetGenericRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }

        
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transactionScope?.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
