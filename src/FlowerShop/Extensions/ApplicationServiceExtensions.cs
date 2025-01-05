using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Validators.Bouquet;
using FlowerShop.ApplicationServices.Components.Flowers;
using FlowerShop.ApplicationServices.Components.FlowersRecords;
using FlowerShop.ApplicationServices.Components.Order;
using FlowerShop.ApplicationServices.Components.Payment;
using FlowerShop.ApplicationServices.Components.Sieve;
using FlowerShop.ApplicationServices.Components.Token;
using FlowerShop.ApplicationServices.Mappings;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.Data;
using FlowerShop.DataAccess.Repositories.AppRepository;
using FlowerShop.DataAccess.Repositories.BasketRepository;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using StackExchange.Redis;

namespace FlowerShop.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddDbContext<FlowerShopStorageContext>(opt =>
                opt.UseSqlServer(config.GetConnectionString("FlowerShopDatabaseConnection")));
            services.AddSingleton<IConnectionMultiplexer>(c => {
                var configuration = ConfigurationOptions.Parse(config.GetConnectionString("Redis"), true);

                return ConnectionMultiplexer.Connect(configuration);
            });

            services.AddAutoMapper(typeof(ReservationsProfile).Assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(ResponseBase<>)));
            services.AddControllers();
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<AddBouquetRequestValidator>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderData, OrderData>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IDeliveryMethodService, DeliveryMethodService>();
            services.AddScoped<ISieveProcessor, ApplicationSieveProcessor>();

            services.AddTransient<IQueryExecutor, QueryExecutor>();
            services.AddTransient<ICommandExecutor, CommandExecutor>();
            services.AddTransient<IFlowersConnector, FlowersConnector>();           

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                });
            });
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
    }
}