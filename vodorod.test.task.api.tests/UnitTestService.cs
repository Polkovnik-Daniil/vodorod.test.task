using Moq;
using vodorod.test.task.core.Abstractions;
using vodorod.test.task.core.Models;
using vodorod.test.task.application.Services;
namespace vodorod.test.task.api.tests
{
    public class UnitTestService
    {
        [Fact]
        public async void Check_RatesService_GetEntity()
        {
            // Arrange
            var mock = new Mock<IEntityClassesRepository>();
            var guid = Guid.NewGuid();
            mock.Setup(repo => repo.Get(new DateTime(2023, 10, 10), "PLN")).Returns(Arrange_GetEntity(guid));
            var service = new RatesService(mock.Object);
            //Act
            var result = await service.GetEntity(new DateTime(2023, 10, 10), "PLN");
            //Assert
            var viewResult = Assert.IsType<RateModel>(result);
            Assert.NotNull(result);
        }
        [Fact]
        public async void Check_RatesService_GetAllEntities()
        {
            // Arrange
            var mock = new Mock<IEntityClassesRepository>();
            var guid = Guid.NewGuid();
            mock.Setup(repo => repo.Get(new DateTime(2023, 10, 10))).Returns(Arrange_GetAllEntities(guid));
            var service = new RatesService(mock.Object);
            //Act
            var result = await service.GetAllEntities(new DateTime(2023, 10, 10));
            //Assert
            var viewResult = Assert.IsType<List<RateModel>>(result);
            Assert.NotNull(result);
        }

        public Task<RateModel> Arrange_GetEntity(Guid guid)
        {
            var value = new RateModel(guid, new decimal(7.7251), "PLN", 10, new DateTime(2023, 10, 10));
            return Task.FromResult(value);
        }

        public Task<List<RateModel>> Arrange_GetAllEntities(Guid guid)
        {
            var value = new List<RateModel>(){
                new RateModel(guid, new decimal(7.7251), "PLN", 10, new DateTime(2023, 10, 10)),
                new RateModel(guid, new decimal(4.7471), "DKK", 10, new DateTime(2023, 10, 10)),
                new RateModel(guid, new decimal(3.3609), "USD", 10, new DateTime(2023, 10, 10)),
            };
            return Task.FromResult(value);
        }
    }
}