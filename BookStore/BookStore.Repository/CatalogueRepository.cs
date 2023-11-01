using BookStore.Domain.CatalogueAggregate;

namespace BookStore.Repository
{
    public class CatalogueRepository :GenericRepository<Catalogue>, ICatalogueRepository
    {
        public CatalogueRepository(BookStoreDbContext context):base(context)
        {
            
        }
    }
}
