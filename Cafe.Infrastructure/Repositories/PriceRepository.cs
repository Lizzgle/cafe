using Cafe.Domain.Abstractions;
using Cafe.Domain.Entities;
using Cafe.Domain.Enums;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Cafe.Infrastructure.Repositories;

public class PriceRepository : BaseRepository<Price>, IPriceRepository
{
    public PriceRepository(string connectionString) : base(connectionString)
    {
    }

    public override string TableName => "prices";

    public override Price MapToEntity(IDataReader reader)
    {
        var price = new Price
        {
            Id = Guid.Parse(reader["id"].ToString()),
            SizeId = (int)reader["SizeId"],
            Size = (Size)(int)reader["SizeId"],
            Cost = Convert.ToSingle(reader["Cost"]),
            DrinkId = Guid.Parse(reader["DrinkId"].ToString()),
        };

        return price;
    }

    protected override SqlCommand CreateInsertCommand(SqlConnection connection, Price entity)
    {
        var command = connection.CreateCommand();

        command.CommandText = @"
                INSERT INTO prices (Id, DrinkId, SizeId, Cost)
                VALUES (@Id, @DrinkId, @SizeId, @Cost)"
        ;

        command.Parameters.Add(new SqlParameter("@Id", entity.Id));
        command.Parameters.Add(new SqlParameter("@DrinkId", entity.DrinkId));
        command.Parameters.Add(new SqlParameter("@SizeId", entity.Size.Id));
        command.Parameters.Add(new SqlParameter("@Cost", entity.Cost));

        return command;
    }

    protected override SqlCommand CreateUpdateCommand(SqlConnection connection, Price entity)
    {
        var command = connection.CreateCommand();

        command.CommandText = $"UPDATE {TableName} " +
            $"SET Cost = @Cost " +
            $"WHERE Id = @Id";

        command.Parameters.Add(new SqlParameter("@Id", entity.Id));
        command.Parameters.Add(new SqlParameter("@Cost", entity.Cost));

        return command;
    }

    public async Task<List<Price>> GetPricesForDrink(Guid drinkId, CancellationToken token)
    {
        using var connection = new SqlConnection(_connectionString);

        await connection.OpenAsync(token);

        string query = @"
                SELECT p.Id, p.Cost, p.SizeId, p.DrinkId
                FROM prices p
                WHERE p.DrinkId = @DrinkId";

        var prices = new List<Price>();

        using (var command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@DrinkId", drinkId);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    prices.Add(MapToEntity(reader));
                }
            }
        }

        return prices;
    }

    public async Task<Price?> GetPriceForDrinkAndSize(Guid drinkId, int sizeId, CancellationToken token)
    {
        using var connection = new SqlConnection(_connectionString);

        await connection.OpenAsync(token);

        string query = @"
            SELECT p.Id, p.Cost, p.SizeId
            FROM prices p
            WHERE p.DrinkId = @DrinkId AND p.SizeId = @SizeId";
        
        using var command = new SqlCommand(query, connection);
        
        command.Parameters.AddWithValue("@DrinkId", drinkId);
        command.Parameters.AddWithValue("@SizeId", sizeId);

        using var reader = await command.ExecuteReaderAsync(token);

        if (await reader.ReadAsync(token))
        {
            return MapToEntity(reader);
        }

        return null;
    }
}
