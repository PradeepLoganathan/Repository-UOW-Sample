using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain;
using BookStore.Domain.BooksAggregate;
using BookStore.Domain.CatalogueAggregate;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<Books>
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _unitOfWork.Books.GetAll();
        }

        [HttpGet]
        public IEnumerable<Book> GetByGenre([FromQuery] string Genre)
        {
            return _unitOfWork.Books.GetBooksByGenre(Genre);
        }

        // GET api/<Books>/5
        [HttpGet("{id}")]
        public async Task<Book> Get(int id)
        {
            return await _unitOfWork.Books.Get(id);
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

            var Catalog = new Catalogue
            {
                CatalogueId = 1,
                Name = "Programming Books",
                Description = "Books on Software development"
            };

            _unitOfWork.Books.Add(book);
            _unitOfWork.Catalogues.Add(Catalog);
            _unitOfWork.Complete();
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
