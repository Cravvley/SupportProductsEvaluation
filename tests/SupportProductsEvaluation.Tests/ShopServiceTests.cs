using AutoMapper;
using Moq;
using SupportProductsEvaluation.Data.Entities;
using SupportProductsEvaluation.Data.Repositories;
using SupportProductsEvaluation.Infrastructure.Services;
using System.Threading.Tasks;
using Xunit;

namespace SupportProductsEvaluation.Tests
{
    public class ShopServiceTests
    {
        [Fact]
        public async Task create_should_invoke_create_on_repository()
        {
            var shopRepositoryMock = new Mock<IShopRepository>();
            var shop = new Mock<Shop>();
            var mapper = new Mock<IMapper>();

            var shopService = new ShopService(shopRepositoryMock.Object,mapper.Object);
            await shopService.Create(shop.Object);

            shopRepositoryMock.Verify(x => x.Create(It.IsAny<Shop>()), Times.Once);
        }

    }
}
