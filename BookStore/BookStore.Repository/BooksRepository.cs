using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BookStore.Domain.BooksAggregate;

namespace BookStore.Repository
{
    public class BooksRepository:GenericRepository<Book>, IBooksRepository
    {
        public BooksRepository(BookStoreDbContext context) : base(context)
        {
            
        }

        public Task<IAsyncEnumerable<Book>>  GetBooksByGenre(string Genre)
        {
            throw new NotImplementedException();
        }
       
    }
}
