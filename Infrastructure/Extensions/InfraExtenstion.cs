using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class InfraExtenstion
    {

        public static IServiceCollection ConfigureRespoitory(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IOrderRepository,OrderRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            return services;
        }

    }
}
