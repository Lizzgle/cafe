using Cafe.Domain.Abstractions;
using Cafe.Domain.Entities;
using Cafe.Domain.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Cafe.Infrastructure.Repositories;

public class DrinkRepository : BaseRepository<Drink>, IDrinkRepository
{

    public override string TableName => "drinks";

    public DrinkRepository(string connectionString) : base(connectionString)
    {
    }

    public override Drink MapToEntity(IDataReader reader)
    {
        var drink = new Drink
        {
            Id = Guid.Parse(reader["Id"].ToString()),
            Description = reader["Description"].ToString(),
            Name = reader["Name"].ToString(),
            CategoryId = (int)reader["CategoryId"],
            Category = (Category)(int)reader["CategoryId"],
        };

        return drink;
    }

    protected override SqlCommand CreateInsertCommand(SqlConnection connection, Drink entity)
    {
        var command = connection.CreateCommand();

        command.CommandText = @"
                INSERT INTO drinks (Id, Name, Description, CategoryId)
                VALUES (@Id, @Name, @Description, @CategoryId)";

        command.Parameters.Add(new SqlParameter("@Id", entity.Id));
        command.Parameters.Add(new SqlParameter("@Name", entity.Name));
        command.Parameters.Add(new SqlParameter("@Description", (object?)entity.Description ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@CategoryId", (object?)entity.Category?.Id ?? DBNull.Value));

        return command;
    }

    protected override SqlCommand CreateUpdateCommand(SqlConnection connection, Drink entity)
    {
        var command = connection.CreateCommand();

        command.CommandText = @"
                UPDATE drinks
                SET Name = @Name, Description = @Description, CategoryId = @CategoryId
                WHERE Id = @Id";

        command.Parameters.Add(new SqlParameter("@Id", entity.Id));
        command.Parameters.Add(new SqlParameter("@Name", entity.Name));
        command.Parameters.Add(new SqlParameter("@Description", (object?)entity.Description ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@CategoryId", (object?)entity.Category?.Id ?? DBNull.Value));

        return command;
    }

    public async Task<Drink?> GetDrinkByName(string name, CancellationToken token = default)
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

    public List<DrinkDetail> GetDrinkDetails()
    {
        List<DrinkDetail> drinkDetails = new List<DrinkDetail>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM vw_DrinkDetails"; // Используем представление

            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    drinkDetails.Add(new DrinkDetail
                    {
                        DrinkId = Guid.Parse(reader["Id"].ToString()),
                        Name = reader["DrinkName"] == DBNull.Value ? null : (string)reader["DrinkName"],
                        Description = reader["Description"] == DBNull.Value ? null : reader["Description"].ToString(),
                        CategoryName = (string)reader["Name"],
                        SizesWithPrices = (string)reader["SizesWithPrices"],
                        Ingredients = reader["Ingredients"] == DBNull.Value ? null : (string)reader["Ingredients"]
                    });
                }
            }
        }

        return drinkDetails;
    }
}
