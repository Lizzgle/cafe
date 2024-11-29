using Cafe.Domain.Abstractions;
using Cafe.Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Cafe.Infrastructure.Repositories;

public class FeedbackRepository : IFeedbackRepository
{
    private readonly string _connectionString;
    private readonly string _tableName;

    public FeedbackRepository(string connectionString)
    {
        _connectionString = connectionString;
        _tableName = "feedbacks";
    }

    public async Task CreateFeedbackAsync(Feedback feedback, CancellationToken token = default)
    {
        using var connection = new SqlConnection(_connectionString);

        await connection.OpenAsync(token);

        var command = connection.CreateCommand();

        command.CommandText = $"INSERT INTO {_tableName} (Id, Description, Rating, Date, UserId) " +
                              "VALUES (@Id, @Description, @Rating, @Date, @UserId)";

        command.Parameters.Add(new SqlParameter("@Id", feedback.Id));
        command.Parameters.Add(new SqlParameter("@Description", feedback.Description));
        command.Parameters.Add(new SqlParameter("@Rating", feedback.Rating));
        command.Parameters.Add(new SqlParameter("@Date", feedback.Date));
        command.Parameters.Add(new SqlParameter("@UserId", feedback.UserId));

        await command.ExecuteNonQueryAsync(token);
    }

    public async Task DeleteFeedbackAsync(Feedback feedback, CancellationToken token = default)
    {
        using var connection = new SqlConnection(_connectionString);

        await connection.OpenAsync(token);

        var command = connection.CreateCommand();

        command.CommandText = $"DELETE FROM {_tableName} WHERE Id = @Id";

        command.Parameters.Add(new SqlParameter("@Id", feedback.Id));

        await command.ExecuteNonQueryAsync(token);
    }

    public async Task<List<Feedback>> GetAllFeedbacksAsync(CancellationToken token = default)
    {
        var users = new List<Feedback>();

        using var connection = new SqlConnection(_connectionString);

        await connection.OpenAsync(token);

        var command = connection.CreateCommand();

        command.CommandText = $"SELECT * FROM {_tableName}";

        using var reader = await command.ExecuteReaderAsync(token);

        while (await reader.ReadAsync(token))
        {
            users.Add(MapToEntity(reader));
        }

        return users;
    }

    public async Task<Feedback?> GetFeedbackByIdAsync(Guid id, CancellationToken token = default)
    {
        using var connection = new SqlConnection(_connectionString);

        await connection.OpenAsync(token);

        var command = connection.CreateCommand();

        command.CommandText = $"SELECT * FROM {_tableName} WHERE Id = @Id";

        command.Parameters.Add(new SqlParameter("@Id", id));

        using var reader = await command.ExecuteReaderAsync(token);

        if (await reader.ReadAsync(token))
        {
            return MapToEntity(reader);
        }

        return null;
    }

    private Feedback MapToEntity(IDataReader reader)
    {
        var feedback = new Feedback
        {
            Id = Guid.Parse(reader["Id"].ToString()),
            Description = reader["Description"].ToString(),
            Rating = (int)reader["Rating"],
            Date = (DateTime)reader["Date"],
            UserId = Guid.Parse(reader["UserId"].ToString()),
        };

        return feedback;
    }
}
