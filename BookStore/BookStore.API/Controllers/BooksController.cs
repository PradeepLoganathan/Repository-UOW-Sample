using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Domain;
using BookStore.Domain.BooksAggregate;
using BookStore.Domain.CatalogueAggregate;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private IBooksRepository BooksRepository;
        public BooksController(IBooksRepository booksRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            BooksRepository = booksRepository;
        }

        // GET: api/<Books>
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await BooksRepository.GetAll();
        }

        [HttpGet]
        public async Task<IAsyncEnumerable<Book>> GetByGenre([FromQuery] string Genre)
        {
            return await BooksRepository.GetBooksByGenre(Genre);
        }

        // GET api/<Books>/5
        [HttpGet("{id}")]
        public async Task<Book> Get(int id)
        {
            return await BooksRepository.Get(id);
        }

        // POST api/<Books>
        [HttpPost]
        public IActionResult Post()
        {
            var book = new Book
            {
                Id = 1,
                Genre = "Technology",
                Author = "Charles Petzold",
                Title = "Programming Windows 5th Edition",
                Price = 30,
                Publisher = "Microsoft Press"
            };

            var catalog = new Catalogue
            {
                CatalogueId = 1,
                Name = "Programming Books",
                Description = "Books on Software development"
            };

                
            var booksRepository = _unitOfWork.GetGenericRepository<Book>();
            var catalogueRepository = _unitOfWork.GetGenericRepository<Catalogue>();
            _unitOfWork.BeginTransaction();
            booksRepository.Add(book);
            catalogueRepository.Add(catalog);
            _unitOfWork.Commit();
            
            return Ok();
        }

        // PUT api/<Books>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Books>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
