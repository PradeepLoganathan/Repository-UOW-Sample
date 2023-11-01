using BookStore.Domain;
using BookStore.Domain.BooksAggregate;
using BookStore.Repository;
using Moq;

using Microsoft.EntityFrameworkCore;

namespace BookStore.Tests
{
    [TestFixture]
    public class Tests
    {
        // Unit of work
        private IUnitOfWork _unitOfWork;
        private IBooksRepository _bookRespository;

        private Mock<BookStoreDbContext> mockDbContext;
        private Mock<DbSet<Book>> mockDbSet;

        private List<Book> yourDataList;


        [SetUp]
        public void Setup()
        {
            mockDbContext = new Mock<BookStoreDbContext>();
            mockDbSet = new Mock<DbSet<Book>>();
            yourDataList = new List<Book>();
    

            _unitOfWork = new UnitOfWork(mockDbContext.Object);
            _bookRespository = new BooksRepository(mockDbContext.Object);

            
            //setup add
            mockDbSet.Setup(d => d.Add(It.IsAny<Book>()))
                .Callback<Book>(entity => yourDataList.Add(entity));

            //setup delete
            mockDbSet.Setup(d => d.Remove(It.IsAny<Book>()))
                .Callback<Book>(entity => yourDataList.Remove(entity));

            //setup update
            mockDbSet.Setup(d => d.Update(It.IsAny<Book>()))
                .Callback<Book>(entity =>
                {
                    var existingEntity = yourDataList.FirstOrDefault(e => e.Id == entity.Id);
                    if (existingEntity != null)
                    {
                        yourDataList.Remove(existingEntity);
                        yourDataList.Add(entity);
                    }
                });


            mockDbSet.Setup(s => s.Find(It.IsAny<int>()))
                .Returns((int id) => yourDataList.FirstOrDefault(e => e.Id == id));
            
            //setup the dbcontext
            mockDbContext.Setup(d => d.Set<Book>()).Returns(mockDbSet.Object);

            

        }

        [Test]
        public void AddEntity_ShouldAddToDataList()
        {
            // Arrange
            var entity = new Book(){ Id = 1, Author = "Pradeep", Genre = "Crime", Price = 32 };

            // Act
            mockDbSet.Object.Add(entity);

            // Assert
            Assert.Contains(entity, yourDataList);
        }

        [Test]
        public void DeleteEntity_ShouldRemoveFromDataList()
        {
            // Arrange
            var entity = yourDataList.First();

            // Act
            mockDbSet.Object.Remove(entity);

            // Assert
            Assert.That(yourDataList, Has.No.Member(entity));
        }

        [Test]
        public void UpdateEntity_ShouldUpdateDataList()
        {
            // Arrange
            var entity = yourDataList.First();
            var updatedEntity = new Book { Id = 1, Author = "Pradeep", Genre = "Crime", Price = 39 };

            // Act
            mockDbSet.Object.Update(updatedEntity);

            // Assert
            Assert.Contains(updatedEntity, yourDataList);
            Assert.That(yourDataList, Has.No.Member(entity));
        }

        [TearDown]
        public void Cleanup()
        {

        }
    }
}