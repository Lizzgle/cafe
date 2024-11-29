using Cafe.Domain.Abstractions;
using Cafe.Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Cafe.Infrastructure.Repositories;

public class FeedbackRepository : BaseRepository<Feedback>, IFeedbackRepository
{
    public FeedbackRepository(string connectionString) : base(connectionString)
    {
    }

    public override string TableName => "feedbacks";

    public override Feedback MapToEntity(IDataReader reader)
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

    protected override SqlCommand CreateInsertCommand(SqlConnection connection, Feedback entity)
    {
        var command = connection.CreateCommand();

        command.CommandText = $"INSERT INTO {TableName} (Id, Description, Rating, Date, UserId) " +
                              "VALUES (@Id, @Description, @Rating, @Date, @UserId)";
        command.Parameters.Add(new SqlParameter("@Id", entity.Id));
        command.Parameters.Add(new SqlParameter("@Description", entity.Description));
        command.Parameters.Add(new SqlParameter("@Rating", entity.Rating));
        command.Parameters.Add(new SqlParameter("@Date", entity.Date));
        command.Parameters.Add(new SqlParameter("@UserId", entity.UserId));

        return command;
    }

    protected override SqlCommand CreateUpdateCommand(SqlConnection connection, Feedback entity)
    {
        var command = connection.CreateCommand();

        command.CommandText = $"UPDATE {TableName} " +
            $"SET Description = @Description, Rating = @Rating, Date = @Date, UserId = @UserId " +
            $"WHERE Id = @Id";

        command.Parameters.Add(new SqlParameter("@Id", entity.Id));
        command.Parameters.Add(new SqlParameter("@Description", entity.Description));
        command.Parameters.Add(new SqlParameter("@Rating", entity.Rating));
        command.Parameters.Add(new SqlParameter("@Date", entity.Date));
        command.Parameters.Add(new SqlParameter("@UserId", entity.UserId));

        return command;
    }
}
