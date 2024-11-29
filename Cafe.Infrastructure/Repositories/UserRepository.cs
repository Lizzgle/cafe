using Cafe.Domain.Abstractions;
using Cafe.Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Cafe.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(string connectionString) : base(connectionString)
    {
    }

    public override string TableName => "users";

    public async Task<User?> GetUserByLogin(string login, CancellationToken token = default)
    {
        using var connection = new SqlConnection(_connectionString);

        await connection.OpenAsync(token);

        var command = connection.CreateCommand();

        command.CommandText = $"SELECT * FROM {TableName} WHERE Login = @Login";

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

        command.CommandText = $"SELECT * FROM {TableName} WHERE Login = @Login AND Password = @Password";

        command.Parameters.Add(new SqlParameter("@Login", login));
        command.Parameters.Add(new SqlParameter("@Password", password));

        using var reader = await command.ExecuteReaderAsync(token);

        if (await reader.ReadAsync(token))
        {
            return MapToEntity(reader);
        }

        return null;
    }

    public async Task AddRoleToUserAsync(User user, Role role, CancellationToken token)
    {
        using var connection = new SqlConnection(_connectionString);

        await connection.OpenAsync();

        var command = connection.CreateCommand();

        command.CommandText = "INSERT INTO UserRoles (UserId, RoleId) VALUES (@UserId, @RoleId)";

        command.Parameters.AddWithValue("@UserId", user.Id);
        command.Parameters.AddWithValue("@RoleId", role.Id);

        await command.ExecuteNonQueryAsync(token);
    }

    private List<Role> GetRolesForUser(Guid userId)
    {
        var roles = new List<Role>();

        using var connection = new SqlConnection(_connectionString);

        connection.Open();

        using var command = connection.CreateCommand();

        command.CommandText = "SELECT r.Id, r.Name FROM Roles r " +
                       "INNER JOIN UserRoles ur ON ur.RoleId = r.Id " +
                       "WHERE ur.UserId = @UserId"; ;

        command.Parameters.Add(new SqlParameter("@UserId", userId));

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var role = new Role(reader.GetOrdinal("Id"), reader.GetString(reader.GetOrdinal("Name")));

            roles.Add(role);
        }

        return roles;
    }

    public override User MapToEntity(IDataReader reader)
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

        user.Roles = GetRolesForUser(user.Id);

        return user;
    }

    protected override SqlCommand CreateInsertCommand(SqlConnection connection, User entity)
    {
        var command = connection.CreateCommand();

        command.CommandText = $"INSERT INTO {TableName} (Id, Login, Password, Name, DateOfBirth) " +
                              "VALUES (@Id, @Login, @Password, @Name, @DateOfBirth)";

        command.Parameters.Add(new SqlParameter("@Id", entity.Id));
        command.Parameters.Add(new SqlParameter("@Login", entity.Login));
        command.Parameters.Add(new SqlParameter("@Password", entity.Password));
        command.Parameters.Add(new SqlParameter("@Name", entity.Name));
        command.Parameters.Add(new SqlParameter("@DateOfBirth", entity.DateOfBirth));

        return command;
    }

    protected override SqlCommand CreateUpdateCommand(SqlConnection connection, User entity)
    {
        var command = connection.CreateCommand();

        command.CommandText = $"UPDATE {TableName} SET " +
                              "Login = @Login, Password = @Password, Name = @Name, DateOfBirth = @DateOfBirth, " +
                              "RefreshToken = @RefreshToken, RefreshTokenExpiry = @RefreshTokenExpiry " +
                              "WHERE Id = @Id";

        command.Parameters.Add(new SqlParameter("@Login", entity.Login));
        command.Parameters.Add(new SqlParameter("@Password", entity.Password));
        command.Parameters.Add(new SqlParameter("@Name", entity.Name));
        command.Parameters.Add(new SqlParameter("@DateOfBirth", entity.DateOfBirth));
        command.Parameters.Add(new SqlParameter("@RefreshToken", entity.RefreshToken));
        command.Parameters.Add(new SqlParameter("@RefreshTokenExpiry", entity.RefreshTokenExpiry ?? (object)DBNull.Value));
        command.Parameters.Add(new SqlParameter("@Id", entity.Id));

        return command;
    }
}
