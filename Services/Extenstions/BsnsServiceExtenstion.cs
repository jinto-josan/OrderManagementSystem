using Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extenstions
{
    public static class ServiceExtenstion
    {
        public static IServiceCollection ConfigureAutoMapperServices(this IServiceCollection services)
        {
            return services.AddAutoMapper(typeof(ProductProfile));
        }

        public static IServiceCollection ConfigureBsnsServices(this IServiceCollection services)
        {
            services.ConfigureRespoitory();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ITransactionService, TransactionService>();
            return services;
        }
                
    }
}
