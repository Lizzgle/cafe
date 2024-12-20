﻿using Cafe.Domain.Abstractions;
using Cafe.Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Cafe.Infrastructure.Repositories;

public class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
{
    public IngredientRepository(string connectionString) : base(connectionString)
    {
    }

    public override string TableName => "ingredients";

    public async Task<Ingredient?> GetIngredientByName(string name, CancellationToken token = default)
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

    public override Ingredient MapToEntity(IDataReader reader)
    {
        var ingredient = new Ingredient
        {
            Id = Guid.Parse(reader["Id"].ToString()),
            Name = reader["Name"].ToString(),
        };

        return ingredient;
    }

    protected override SqlCommand CreateInsertCommand(SqlConnection connection, Ingredient entity)
    {
        var command = connection.CreateCommand();

        command.CommandText = @"
                INSERT INTO ingredients (Id, Name)
                VALUES (@Id, @Name)";

        command.Parameters.Add(new SqlParameter("@Id", entity.Id));
        command.Parameters.Add(new SqlParameter("@Name", entity.Name));

        return command;
    }

    protected override SqlCommand CreateUpdateCommand(SqlConnection connection, Ingredient entity)
    {
        var command = connection.CreateCommand();

        command.CommandText = @"
                UPDATE ingredients
                SET Name = @Name
                WHERE Id = @Id";

        command.Parameters.Add(new SqlParameter("@Id", entity.Id));
        command.Parameters.Add(new SqlParameter("@Name", entity.Name));

        return command;
    }
}