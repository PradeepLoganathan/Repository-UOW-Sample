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

        public UnitOfWork(BookStoreDbContext bookStoreDbContext, 
            IBooksRepository booksRepository, 
            ICatalogueRepository catalogueRepository)
        {
            this._context = bookStoreDbContext;
            
            this.Books = booksRepository;
            this.Catalogues = catalogueRepository;
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
