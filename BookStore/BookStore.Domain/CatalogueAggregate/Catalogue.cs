using System.Collections.Generic;
using BookStore.Domain.BooksAggregate;

namespace BookStore.Domain.CatalogueAggregate
{
    public class Catalogue
    {
        public int CatalogueId { get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }
    }
}
