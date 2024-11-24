using Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Services.EventHandler;
using Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public static IServiceCollection RegisterEventHandlers(this IServiceCollection services)
        {
            services.RegisterEventPublisher();

            //To register automatically all classes which are singleton but not used anywhere else
            //especially event handlers
            var collection = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(IEagerSingleton).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
            foreach (var type in collection)
            {
                services.AddSingleton(typeof(IEagerSingleton), type);

            }            
            return services;
        }

    }
}
