using Moq;
using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Core.Repositories;
using SupportProductsEvaluation.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
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

            var shopService = new ShopService(shopRepositoryMock.Object);
            await shopService.Create(shop.Object);
            await shopService.Create(shop.Object);

            shopRepositoryMock.Verify(x => x.Create(It.IsAny<Shop>()), Times.Once);
        }

    }
}
