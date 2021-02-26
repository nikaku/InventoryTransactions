using System.Reflection;
using AutoMapper.Configuration;
using InventoryTransactions.Application.Commands;
using InventoryTransactions.Application.Commands.Item;
using InventoryTransactions.Application.Dtos;
using InventoryTransactions.Application.Dtos.Item;
using InventoryTransactions.Application.Interfaces;
using InventoryTransactions.Application.Queries;
using InventoryTransactions.Application.Services;
using InventoryTransactions.Core.Contracts.Interfaces;
using InventoryTransactions.Core.Contracts.Interfaces.Repositories;
using InventoryTransactions.Domain.Contracts.Interfaces;
using InventoryTransactions.Domain.Contracts.Interfaces.Repositories;
using InventoryTransactions.Infrastructure.Data.Config;
using InventoryTransactions.Infrastructure.Data.Implementations;
using InventoryTransactions.Infrastructure.Data.Implementations.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace InventoryTransactions.Infrastructure.Ioc
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //Context
            var connectionString = configuration.GetSection(nameof(CoreDb)).Get<CoreDb>().ConnectionString;
            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            //Repositories
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IWarehouseTransactionRepository, WarehousetransactionRepository>();

            //Services
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IWarehouseService, WarehouseService>();
            services.AddScoped<IWarehouseTransactionService, WarehouseTransactionService>();

            //MediatR
            services.AddMediatR(typeof(CreateItemCommand).GetTypeInfo().Assembly);

            //Unit Of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Mapper
            services.AddAutoMapper(typeof(GetItemDto).GetTypeInfo().Assembly);

            return services;
        }
    }
}
