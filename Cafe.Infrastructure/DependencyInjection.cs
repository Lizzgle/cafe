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
        // DatabaseHelper.CreateRolesTable(createConnectionString, "CafeDb");
        // DatabaseHelper.CreateUsersRolesTable(createConnectionString, "CafeDb");
        // DatabaseHelper.CreateFeedbacksTable(createConnectionString, "CafeDb");
        // DatabaseHelper.CreateDessertsTable(createConnectionString, "CafeDb");
        // DatabaseHelper.CreateCategoriesTable(createConnectionString, "CafeDb");
        // DatabaseHelper.CreateDrinksTable(createConnectionString, "CafeDb");
        // DatabaseHelper.CreateSizesTable(createConnectionString, "CafeDb");
        // DatabaseHelper.CreatePricesTable(createConnectionString, "CafeDb");
        // DatabaseHelper.CreateFAQsTable(createConnectionString, "CafeDb");

        // DatabaseHelper.CreateIngredientsTable(createConnectionString, "CafeDb");
        // DatabaseHelper.CreateDessertsIngredientsTable(createConnectionString, "CafeDb");
        // DatabaseHelper.CreateDrinksIngredientsTable(createConnectionString, "CafeDb");

        // DatabaseHelper.CreateLogTable(createConnectionString, "CafeDb");
        //DatabaseHelper.CreateLogTrigger(createConnectionString, "CafeDb");
        // DatabaseHelper.CreatePartialSearchIngredientFunction(createConnectionString, "CafeDb");

        // DatabaseHelper.CreateDrinkView(createConnectionString, "CafeDb");

        string connectionString = configuration.GetConnectionString("DefaultConnection")
                                                    ?? throw new ArgumentNullException("Не найдена строка подключения к базе данных");

        services.AddScoped<IUnitOfWork, UnitOfWork>(provider => new UnitOfWork(connectionString));

        return services;
    }
}
