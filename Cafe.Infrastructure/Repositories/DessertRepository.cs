using Cafe.Domain.Abstractions;
using Cafe.Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Cafe.Infrastructure.Repositories;

public class DessertRepository : BaseRepository<Dessert>, IDessertRepository
{
    public override string TableName => "desserts";

    public DessertRepository(string connectionString) : base(connectionString)
    {
    }

    public override Dessert MapToEntity(IDataReader reader)
    {
        var dessert = new Dessert
        {
            Id = Guid.Parse(reader["Id"].ToString()),
            Name = reader["Name"].ToString(),
            Description = reader["Description"].ToString(),
            Calories = (int)reader["Calories"],
            Price = Convert.ToSingle(reader["Price"]),
            Ingredients = new List<Ingredient>()
        };

        dessert.Ingredients = LoadIngredientsForDessert(dessert);

        return dessert;
    }

    private List<Ingredient> LoadIngredientsForDessert(Dessert dessert)
    {
        using var connection = new SqlConnection(_connectionString);

        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
        SELECT i.Name 
        FROM Ingredients i
        INNER JOIN dessertsIngredients di ON i.Id = di.IngredientId
        WHERE di.DessertId = @DessertId";
        command.Parameters.Add(new SqlParameter("@DessertId", dessert.Id));

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            dessert.Ingredients.Add(new Ingredient()
            {
                Name = reader["Name"].ToString(),
            });
        }

        return dessert.Ingredients;
    }

    protected override SqlCommand CreateInsertCommand(SqlConnection connection, Dessert entity)
    {
        var command = connection.CreateCommand();

        command.CommandText = $"INSERT INTO {TableName} (Id, Name, Description, Price, Calories) " +
                              "VALUES (@Id, @Name, @Description, @Price, @Calories)";

        command.Parameters.Add(new SqlParameter("@Id", entity.Id));
        command.Parameters.Add(new SqlParameter("@Name", entity.Name));
        command.Parameters.Add(new SqlParameter("@Description", entity.Description));
        command.Parameters.Add(new SqlParameter("@Price", entity.Price));
        command.Parameters.Add(new SqlParameter("@Calories", entity.Calories));

        return command;
    }

    protected override SqlCommand CreateUpdateCommand(SqlConnection connection, Dessert entity)
    {
        var command = connection.CreateCommand();

        command.CommandText = $"UPDATE {TableName} " +
            $"SET Name = @Name, Description = @Description, Price = @Price, Calories = @Calories " +
            $"WHERE Id = @Id";

        command.Parameters.Add(new SqlParameter("@Id", entity.Id));
        command.Parameters.Add(new SqlParameter("@Description", entity.Description));
        command.Parameters.Add(new SqlParameter("@Name", entity.Name));
        command.Parameters.Add(new SqlParameter("@Price", entity.Price));
        command.Parameters.Add(new SqlParameter("@Calories", entity.Calories));

        return command;
    }

    public async Task<Dessert?> GetDessertByName(string name, CancellationToken token = default)
    {
        using var connection = new SqlConnection(_connectionString);

        await connection.OpenAsync(token);

        var command = connection.CreateCommand();

        command.CommandText = $"SELECT * FROM {TableName} WHERE Name = @Name";

        command.Parameters.Add(new SqlParameter("@Name", name));

        using var reader = await command.ExecuteReaderAsync(token);

        if (await reader.ReadAsync(token))
        {
            return MapToEntity(reader);
        }

        return null;
    }
}
