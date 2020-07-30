using System;
using BookStore.Domain;
using BookStore.Domain.BooksAggregate;
using BookStore.Domain.CatalogueAggregate;

namespace BookStore.Repository
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly BookStoreDbContext _context;
        public IBooksRepository Books { get; }

        public ICatalogueRepository Catalogues { get; }

        public UnitOfWork(BookStoreDbContext bookStoreDbContext)
        {
            this._context = bookStoreDbContext;
            this.Books = new BooksRepository(_context);
            this.Catalogues = new CatalogueRepository(_context);
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
