using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.Mappings;
using FlowerShop.DataAccess.Core.Entities.Identity;
using FlowerShop.DataAccess.Data;
using FlowerShop.DataAccess.Identity;
using FlowerShop.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder();

// NLog: Setup NLog for Dependency imjection
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Host.UseNLog();

// configure services
builder.Services.AddDbContext<FlowerShopStorageContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("FlowerShopDatabaseConnection")));

builder.Services.AddDbContext<AppIdentityDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDatabaseConnection")));

builder.Services.AddSingleton<IConnectionMultiplexer>(c => {
    var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"), true);

    return ConnectionMultiplexer.Connect(configuration);
});

builder.Services.AddApplicationServices();
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddSwaggerDocumentation();

builder.Services.AddAutoMapper(typeof(ReservationsProfile).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(ResponseBase<>)));

builder.Services.AddControllers();//options =>
                          //{
                          //    options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
                          //    options.OutputFormatters.Add(new SystemTextJsonOutputFormatter(new JsonSerializerOptions(JsonSerializerDefaults.Web)
                          //    {
                          //        ReferenceHandler = ReferenceHandler.Preserve,
                          //    }));
                          //});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
    });
});

var app = builder.Build();

// configure
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();

    try
    {
        var userManager = services.GetRequiredService<UserManager<AppUser>>();
        var identityContext = services.GetRequiredService<AppIdentityDbContext>();
        await identityContext.Database.MigrateAsync();
        await AppIdentityDbContextSeed.SeedUsersAsync(userManager);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An error occurred during migration");
    }
}

if (app.Environment.IsDevelopment())
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

app.Run();