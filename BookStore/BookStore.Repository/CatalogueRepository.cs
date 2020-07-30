using BookStore.Domain.CatalogueAggregate;

namespace BookStore.Repository
{
    class CatalogueRepository :GenericRepository<Catalogue>, ICatalogueRepository
    {
        public CatalogueRepository(BookStoreDbContext context):base(context)
        {
            
        }
    }
}
