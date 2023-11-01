using BookStore.Domain;
using BookStore.Domain.BooksAggregate;
using BookStore.Repository;
using Moq;

using Microsoft.EntityFrameworkCore;

namespace BookStore.Tests
{
    [TestFixture]
    public class DbContextTests
    {
        private DbContextOptions<BookStoreDbContext> dbContextOptions;
        private BookStoreDbContext dbContext;

        [SetUp]
        public void Setup()
        {
            // Configure the in-memory database options
            dbContextOptions = new DbContextOptionsBuilder<BookStoreDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

             // Create a new DbContext for each test
            dbContext = new BookStoreDbContext(dbContextOptions);
        }

        [TearDown]
        public void TearDown()
        {
            // Dispose of the DbContext to release resources
            dbContext.Dispose();
        }

         [Test]
        public async Task AddBook_ShouldAddToDatabase()
        {
            // Arrange
             var book = new Book(){ Id = 1, Author = "Pradeep", Genre = "Crime", Price = 32 };
            // Act
            dbContext.Books.Add(book);
            await dbContext.SaveChangesAsync();

            // Assert
            Assert.That(dbContext.Books.Count(), Is.EqualTo(1));
        }


    }
}