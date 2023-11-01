using System;
using System.Dynamic;
using BookStore.Domain.BooksAggregate;
using BookStore.Domain.CatalogueAggregate;

namespace BookStore.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GetGenericRepository<T>() where T:class;
        void BeginTransaction();
        void Commit();
        void RollBack();
    }
}
