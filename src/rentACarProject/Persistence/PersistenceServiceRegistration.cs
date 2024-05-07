using Application.Services.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Persistence.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<BaseDbContext>(options => options.UseInMemoryDatabase("BaseDb"));
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("RentACars")));
        //String ConnectionString = "data source=DESKTOP-GD6LN4O;initial catalog=RentACar;Trustservercertificate=true;";
        //SqlConnection connection = new SqlConnection(ConnectionString);
        //connection.Open();

        services.AddDbMigrationApplier(buildServices => buildServices.GetRequiredService<BaseDbContext>());

        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IModelRepository, ModelRepository>();
        services.AddScoped<IFuelRepository, FuelRepository>();
        services.AddScoped<ITransmissionRepository, TransmissionRepository>();
        services.AddScoped<IColorRepository, ColorRepository>();
        return services;
    }
}
