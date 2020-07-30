using System;
using BookStore.Domain.BooksAggregate;
using BookStore.Domain.CatalogueAggregate;

namespace BookStore.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IBooksRepository Books { get; }
        ICatalogueRepository Catalogues { get; }
        int Complete();
    }
}
