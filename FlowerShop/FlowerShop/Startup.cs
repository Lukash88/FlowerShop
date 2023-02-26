using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Validators;
using FlowerShop.ApplicationServices.Components.Flowers;
using FlowerShop.ApplicationServices.Components.PasswordHasher;
using FlowerShop.ApplicationServices.Components.Sieve;
using FlowerShop.ApplicationServices.Mappings;
using FlowerShop.Authentication;
using FlowerShop.DataAccess;
using FlowerShop.DataAccess.CQRS;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sieve.Services;
using System.Text.Json;
using System.Text.Json.Serialization;
using FlowerShop.DataAccess.Data;
using FlowerShop.DataAccess.Repositories.AppRepository;
using FlowerShop.DataAccess.Repositories.BasketRepository;
using StackExchange.Redis;
using FlowerShop.DataAccess.Identity;

namespace FlowerShop
{
    public class Startup
    {
        private readonly IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IBasketRepository, BasketRepository>();

            services.AddDbContext<FlowerShopStorageContext>(opt =>
                opt.UseSqlServer(this.config.GetConnectionString("FlowerShopDatabaseConnection")));
            services.AddDbContext<AppIdentityDbContext>(opt =>
                opt.UseSqlServer(this.config.GetConnectionString("IdentityDatabaseConnection")));

            services.AddSingleton<IConnectionMultiplexer>(c => {
                var configuration = ConfigurationOptions.Parse(this.config.GetConnectionString("Redis"), true);

                return ConnectionMultiplexer.Connect(configuration);
            });

            //services.AddAuthentication("BasicAuthentication")
            //        .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            // services.AddScoped<IPasswordHasher<User>, BCryptPasswordHasher<User>>();

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

            services.AddAutoMapper(typeof(ReservationsProfile).Assembly);

            services.AddMediatR(typeof(ResponseBase<>));

            services.AddControllers();//options =>
            //{
            //    options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
            //    options.OutputFormatters.Add(new SystemTextJsonOutputFormatter(new JsonSerializerOptions(JsonSerializerDefaults.Web)
            //    {
            //        ReferenceHandler = ReferenceHandler.Preserve,
            //    }));
            //});

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FlowerShop", Version = "v1" });
            });

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FlowerShop v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
