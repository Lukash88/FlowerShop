using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.Mappings;
using FlowerShop.DataAccess.Data;
using FlowerShop.DataAccess.Identity;
using FlowerShop.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;

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
            services.AddDbContext<FlowerShopStorageContext>(opt =>
                opt.UseSqlServer(this.config.GetConnectionString("FlowerShopDatabaseConnection")));
            services.AddDbContext<AppIdentityDbContext>(opt =>
                opt.UseSqlServer(this.config.GetConnectionString("IdentityDatabaseConnection")));
            services.AddSingleton<IConnectionMultiplexer>(c => {
                var configuration = ConfigurationOptions.Parse(this.config.GetConnectionString("Redis"), true);

                return ConnectionMultiplexer.Connect(configuration);
            });

            services.AddApplicationServices();
            services.AddIdentityServices(this.config);
            services.AddSwaggerDocumentation();

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
                app.UseSwaggerDocumentation();
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