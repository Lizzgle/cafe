using Cafe.Domain.Abstractions;
using Cafe.Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Cafe.Infrastructure.Repositories;

public class FAQRepository : IFAQRepository
{
    protected readonly string _connectionString;

    public FAQRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public string TableName => "faqs";

    public FAQ MapToEntity(IDataReader reader)
    {
        return (FAQ)(int)reader["Id"];
    }

    public async Task<List<FAQ>> GetAllAsync(CancellationToken token = default)
    {
        var entities = new List<FAQ>();

        using var connection = new SqlConnection(_connectionString);

        await connection.OpenAsync(token);

        var command = connection.CreateCommand();

        command.CommandText = $"SELECT * FROM {TableName}";

        using var reader = await command.ExecuteReaderAsync(token);

        while (await reader.ReadAsync(token))
        {
            entities.Add(MapToEntity(reader));
        }

        return entities;
    }
}
