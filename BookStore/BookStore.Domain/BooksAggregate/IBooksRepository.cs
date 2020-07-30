using System.Collections.Generic;

namespace BookStore.Domain.BooksAggregate
{
    public interface IBooksRepository :IGenericRepository<Book>
    {
        IEnumerable<Book> GetBooksByGenre(string Genre);
    }
}
