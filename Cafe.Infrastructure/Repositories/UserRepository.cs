using Cafe.Domain.Abstractions;
using Cafe.Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Cafe.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;
    private readonly string _tableName;

    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
        _tableName = "users";
    }

    public async Task CreateUserAsync(User user, CancellationToken token = default)
    {
        using var connection = new SqlConnection(_connectionString);

        await connection.OpenAsync(token);

        var command = connection.CreateCommand();

        command.CommandText = $"INSERT INTO {_tableName} (Id, Login, Password, Name, DateOfBirth) " +
                              "VALUES (@Id, @Login, @Password, @Name, @DateOfBirth)";

        command.Parameters.Add(new SqlParameter("@Id", user.Id));
        command.Parameters.Add(new SqlParameter("@Login", user.Login));
        command.Parameters.Add(new SqlParameter("@Password", user.Password));
        command.Parameters.Add(new SqlParameter("@Name", user.Name));
        command.Parameters.Add(new SqlParameter("@DateOfBirth", user.DateOfBirth));

        await command.ExecuteNonQueryAsync(token);
    }

    public async Task DeleteUserAsync(User user, CancellationToken token = default)
    {
        using var connection = new SqlConnection(_connectionString);

        await connection.OpenAsync(token);

        var command = connection.CreateCommand();

        command.CommandText = $"DELETE FROM {_tableName} WHERE Id = @Id";

        command.Parameters.Add(new SqlParameter("@Id", user.Id));

        await command.ExecuteNonQueryAsync(token);
    }

    public async Task UpdateUserAsync(User user, CancellationToken token = default)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync(token);

        var command = connection.CreateCommand();
        command.CommandText = $"UPDATE {_tableName} SET " +
                              "Login = @Login, Password = @Password, Name = @Name, DateOfBirth = @DateOfBirth, " +
                              "RefreshToken = @RefreshToken, RefreshTokenExpiry = @RefreshTokenExpiry " +
                              "WHERE Id = @Id";

        command.Parameters.Add(new SqlParameter("@Login", user.Login));
        command.Parameters.Add(new SqlParameter("@Password", user.Password));
        command.Parameters.Add(new SqlParameter("@Name", user.Name));
        command.Parameters.Add(new SqlParameter("@DateOfBirth", user.DateOfBirth));
        command.Parameters.Add(new SqlParameter("@RefreshToken", user.RefreshToken));
        command.Parameters.Add(new SqlParameter("@RefreshTokenExpiry", user.RefreshTokenExpiry ?? (object)DBNull.Value));
        command.Parameters.Add(new SqlParameter("@Id", user.Id));

        await command.ExecuteNonQueryAsync(token);
    }

    public async Task<List<User>> GetAllUsersAsync(CancellationToken token = default)
    {
        var users = new List<User>();

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

    public async Task<User?> GetUserByIdAsync(Guid id, CancellationToken token = default)
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

    public async Task<User?> GetUserByLogin(string login, CancellationToken token = default)
    {
        using var connection = new SqlConnection(_connectionString);

        await connection.OpenAsync(token);

        var command = connection.CreateCommand();

        command.CommandText = $"SELECT * FROM {_tableName} WHERE Login = @Login";

        command.Parameters.Add(new SqlParameter("@Login", login));

        using var reader = await command.ExecuteReaderAsync(token);

        if (await reader.ReadAsync(token))
        {
            return MapToEntity(reader);
        }

        return null;
    }

    public async Task<User?> GetUserByLoginAndPassword(string login, string password, CancellationToken token = default)
    {
        using var connection = new SqlConnection(_connectionString);

        await connection.OpenAsync(token);

        var command = connection.CreateCommand();

        command.CommandText = $"SELECT * FROM {_tableName} WHERE Login = @Login AND Password = @Password";

        command.Parameters.Add(new SqlParameter("@Login", login));
        command.Parameters.Add(new SqlParameter("@Password", password));

        using var reader = await command.ExecuteReaderAsync(token);

        if (await reader.ReadAsync(token))
        {
            return MapToEntity(reader);
        }

        return null;
    }

    private User MapToEntity(IDataReader reader)
    {
        var user = new User
        {
            Id = Guid.Parse(reader["Id"].ToString()),
            Login = reader["Login"].ToString(),
            Password = reader["Password"].ToString(),
            Name = reader["Name"].ToString(),
            DateOfBirth = (DateTime)reader["DateOfBirth"],
            RefreshToken = reader["RefreshToken"].ToString(),
            RefreshTokenExpiry = reader["RefreshTokenExpiry"] as DateTime?
        };

        return user;
    }
}
