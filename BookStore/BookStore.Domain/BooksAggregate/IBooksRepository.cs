using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Domain.BooksAggregate
{
    public interface IBooksRepository :IGenericRepository<Book>
    {
        Task<IAsyncEnumerable<Book>> GetBooksByGenre(string Genre);
    }
}
