using FlowerShop.ApplicationServices.API.Validators.Bouquet;
using FlowerShop.ApplicationServices.Components.Flowers;
using FlowerShop.ApplicationServices.Components.Order;
using FlowerShop.ApplicationServices.Components.Sieve;
using FlowerShop.ApplicationServices.Components.Token;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.Repositories.AppRepository;
using FlowerShop.DataAccess.Repositories.BasketRepository;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sieve.Services;

namespace FlowerShop.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IBasketRepository, BasketRepository>();

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<ISieveProcessor, ApplicationSieveProcessor>();
            // services.AddScoped<ISieveProcessor, SieveProcessor>();

            services.AddTransient<IQueryExecutor, QueryExecutor>();
            services.AddTransient<ICommandExecutor, CommandExecutor>();

            services.AddTransient<IFlowersConnector, FlowersConnector>();

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<AddBouquetRequestValidator>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
    }
}