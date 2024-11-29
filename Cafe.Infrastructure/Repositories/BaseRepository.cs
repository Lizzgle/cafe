using Cafe.Domain.Abstractions;
using Cafe.Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Cafe.Infrastructure.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : Base
{
    protected readonly string _connectionString;

    protected BaseRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public abstract string TableName { get; }
    public abstract T MapToEntity(IDataReader reader);

    public async Task CreateAsync(T entity, CancellationToken token = default)
    {
        using var connection = new SqlConnection(_connectionString);

        await connection.OpenAsync(token);

        var command = CreateInsertCommand(connection, entity);

        await command.ExecuteNonQueryAsync(token);
    }

    public async Task UpdateAsync(T entity, CancellationToken token = default)
    {
        using var connection = new SqlConnection(_connectionString);

        await connection.OpenAsync(token);

        var command = CreateUpdateCommand(connection, entity);

        await command.ExecuteNonQueryAsync(token);
    }


    public async Task DeleteAsync(T entity, CancellationToken token = default)
    {
        using var connection = new SqlConnection(_connectionString);

        await connection.OpenAsync(token);

        var command = connection.CreateCommand();

        command.CommandText = $"DELETE FROM {TableName} WHERE Id = @Id";

        command.Parameters.Add(new SqlParameter("@Id", entity.Id));

        await command.ExecuteNonQueryAsync(token);
    }

    public async Task<List<T>> GetAllAsync(CancellationToken token = default)
    {
        var entities = new List<T>();

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

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        using var connection = new SqlConnection(_connectionString);

        await connection.OpenAsync(token);

        var command = connection.CreateCommand();

        command.CommandText = $"SELECT * FROM {TableName} WHERE Id = @Id";
        command.Parameters.Add(new SqlParameter("@Id", id));

        using var reader = await command.ExecuteReaderAsync(token);

        if (await reader.ReadAsync(token))
        {
            return MapToEntity(reader);
        }

        return null;
    }

    protected abstract SqlCommand CreateInsertCommand(SqlConnection connection, T entity);

    protected abstract SqlCommand CreateUpdateCommand(SqlConnection connection, T entity);
}
