using Microsoft.Extensions.DependencyInjection;
using Pedidos_Application.Commands.InsertOrder;
using Pedidos_Application.Services.Interfaces;




namespace Pedidos_Application.Services
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddServices()
                .AddHandler();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderServices, OrderServices>();
            

            return services;
        }

        private static IServiceCollection AddHandler(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<InsertOrderCommand>());

            return services;
        }
    }
}
