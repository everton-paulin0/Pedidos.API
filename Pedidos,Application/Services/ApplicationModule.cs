using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Pedidos_Application.Commands.InsertOrder;
using Pedidos_Application.Model;
using Pedidos_Application.Services.Interfaces;




namespace Pedidos_Application.Services
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddServices()
                .AddHandler()
                .AddValidation();
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

            services.AddTransient<IPipelineBehavior<InsertOrderCommand, ResultViewModel<int>>, ValidateInsertOrderCommandBevahior>();

            return services;
        }

        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<InsertOrderCommand>();

            return services;
        }
    }
}
