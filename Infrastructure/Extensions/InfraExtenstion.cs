using Domain.Events;
using Infrastructure.EventInfra;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public static IServiceCollection RegisterEventPublisher(this IServiceCollection services)
        {

            //List<Type> typesToRegister = new List<Type> { typeof(OrderStatusEvent) };
            //foreach (var type in typesToRegister)
            //{
            //    Console.WriteLine($"Registering EventPublisherService for {type.FullName}");
            //    var hostedServiceType = typeof(BaseEventPublisher<>).MakeGenericType(type);
            //    services.AddHostedService(provider => (IHostedService)Activator.CreateInstance(hostedServiceType));
            //}
            services.AddSingleton(typeof(EventPublisher<>));
            services.AddSingleton(typeof(EventQueue<>));
            services.AddHostedService<OrderStatusEventProcessor>();

            return services;
        }

    }
}
