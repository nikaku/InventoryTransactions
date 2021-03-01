using InventoryTransactions.Application.Commands.WarehouseTransactions;
using InventoryTransactions.Application.Interfaces;
using InventoryTransactions.Application.Services;
using InventoryTransactions.Domain.Contracts.Interfaces;
using InventoryTransactions.Domain.Contracts.Interfaces.Repositories;
using InventoryTransactions.Domain.Entities.Item;
using Moq;
using System;
using System.ComponentModel;
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

            whsTransactionRepositoryMock
                .Setup(x => x.GetCumulativeQuantity(14))
                .Returns(50);

            whsTransactionRepositoryMock
                .Setup(x => x.GetCumulativeQuantityOnWarehouse(14, 1))
                .Returns(20);

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
                ItemId = 14,
                WarehouseId = 1,
                Comment = "Comment",
                PostingDate = DateTime.UtcNow
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
                ItemId = 32,
                WarehouseId = 1,
                Comment = "Comment",
                PostingDate = DateTime.UtcNow
            };

            //ASSERT
            Assert.Throws<InvalidEnumArgumentException>(() => _warehouseTransactionService.Issue(createIssueCommand));
        }

        [Fact]
        public void Create_Issue_With_Quantity_More_Then_Stock_Throws_Exception()
        {
            // ARRANGE
            var createIssueCommand = new CreateIssueCommand
            {
                Quantity = 100,
                ItemId = 14,
                WarehouseId = 1,
                Comment = "Comment",
                PostingDate = DateTime.UtcNow
            };

            //ASSERT
            Assert.Throws<InvalidOperationException>(() => _warehouseTransactionService.Issue(createIssueCommand));
        }

        [Fact]
        public void Create_Issue_With_Quantity_More_Then_Stock_In_Warehouse_Throws_Exception()
        {
            // ARRANGE
            var createIssueCommand = new CreateIssueCommand
            {
                Quantity = 30,
                ItemId = 14,
                WarehouseId = 1,
                Comment = "Comment",
                PostingDate = DateTime.UtcNow
            };

            //ASSERT
            Assert.Throws<InvalidOperationException>(() => _warehouseTransactionService.Issue(createIssueCommand));
        }

        [Fact]
        public void Create_Receipt_With_Negative_Or_Zero_Quantity_Throws_Exception()
        {
            // ARRANGE
            var createIssueCommand = new CreateReceiptCommand()
            {
                Quantity = 30,
                ItemId = 14,
                WarehouseId = 1,
                Comment = "Comment",
                PostingDate = DateTime.UtcNow
            };

            //ASSERT
            Assert.Throws<InvalidEnumArgumentException>(() => _warehouseTransactionService.Receipt(createIssueCommand));
        }

        [Fact]
        public void Create_Receipt_With_NonExisting_Item_Throws_Exception()
        {
            // ARRANGE
            var createIssueCommand = new CreateReceiptCommand()
            {
                Quantity = 1,
                ItemId = 32,
                WarehouseId = 1,
                Comment = "Comment",
                PostingDate = DateTime.UtcNow
            };

            //ASSERT
            Assert.Throws<InvalidEnumArgumentException>(() => _warehouseTransactionService.Receipt(createIssueCommand));
        }


        [Fact]
        public void Create_Receipt_With_NonExisting_Warehouse_Throws_Exception()
        {
            // ARRANGE
            var createIssueCommand = new CreateReceiptCommand()
            {
                Quantity = 1,
                ItemId = 32,
                WarehouseId = 31,
                Comment = "Comment",
                PostingDate = DateTime.UtcNow
            };

            //ASSERT
            Assert.Throws<InvalidEnumArgumentException>(() => _warehouseTransactionService.Receipt(createIssueCommand));
        }
    }
}
