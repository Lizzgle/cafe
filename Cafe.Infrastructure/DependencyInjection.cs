using Cafe.Domain.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cafe.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
                                                            IConfiguration configuration)
    {

        string createConnectionString = configuration.GetConnectionString("CreateConnection")
                                                   ?? throw new ArgumentNullException("Не найдена строка подключения к базе данных");

        // DatabaseHelper.CreateDatabase(createConnectionString, "CafeDb");
        // DatabaseHelper.CreateUsersTable(createConnectionString, "CafeDb");

        string connectionString = configuration.GetConnectionString("DefaultConnection")
                                                    ?? throw new ArgumentNullException("Не найдена строка подключения к базе данных");

        services.AddScoped<IUnitOfWork, UnitOfWork>(provider => new UnitOfWork(connectionString));

        return services;
    }
}
