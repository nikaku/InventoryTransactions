using System;
using System.ComponentModel;
using InventoryTransactions.Application.Commands.WarehouseTransactions;
using InventoryTransactions.Application.Interfaces;
using InventoryTransactions.Application.Services;
using InventoryTransactions.Domain.Contracts.Interfaces;
using InventoryTransactions.Domain.Contracts.Interfaces.Repositories;
using InventoryTransactions.Domain.Entities.Item;
using InventoryTransactions.Domain.Entities.Warehouse;
using Moq;
using Xunit;

namespace InventoryTransactions.Tests
{
    public class InventoryTransactionServiceTests
    {
        private readonly IWarehouseTransactionService _warehouseTransactionService;
        public InventoryTransactionServiceTests()
        {
            var whsTransactionRepositoryMock = new Mock<IWarehouseTransactionRepository>();
            var whsRepositoryMock = new Mock<IWarehouseRepository>();
            var uowMock = new Mock<IUnitOfWork>();
            var itemReposMock = new Mock<IItemRepository>();

            itemReposMock
                .Setup(x => x.Get(14))
                .Returns(new Item());

            _warehouseTransactionService = new WarehouseTransactionService
                (
                whsTransactionRepositoryMock.Object,
                uowMock.Object,
                itemReposMock.Object,
                whsRepositoryMock.Object
                );


        }

        [Fact]
        public void Create_Issue_With_Negative_Or_Zero_Quantity_Throws_Exception()
        {
            // ARRANGE
            var createIssueCommand = new CreateIssueCommand
            {
                Quantity = 0,
                ItemId = 14
            };

            //ASSERT
            Assert.Throws<InvalidEnumArgumentException>(() => _warehouseTransactionService.Issue(createIssueCommand));
        }

        [Fact]
        public void Create_Issue_With_NonExisting_Item_Throws_Exception()
        {
            // ARRANGE
            var createIssueCommand = new CreateIssueCommand
            {
                Quantity = 1,
                ItemId = 32
            };

            //ASSERT
            Assert.Throws<InvalidEnumArgumentException>(() => _warehouseTransactionService.Issue(createIssueCommand));
        }
    }
}
