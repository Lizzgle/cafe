using Microsoft.Data.SqlClient;

namespace Cafe.Infrastructure;

public class DatabaseHelper
{
    public static void CreateDatabase(string connectionString, string databaseName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string createDatabaseQuery = $"CREATE DATABASE {databaseName}";

            ExecuteNonQuery(connection, createDatabaseQuery);
        }
    }

    public static void CreateUsersTable(string connectionString, string databaseName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            connection.ChangeDatabase(databaseName);

            string createTableQuery = @"
                    CREATE TABLE Users (
                        Id NVARCHAR(50) PRIMARY KEY,
                        Login NVARCHAR(20) NOT NULL,
                        Name NVARCHAR(20) NOT NULL,
                        Password NVARCHAR(255) NOT NULL,
                        DateOfBirth DATETIME NOT NULL,
                        RefreshToken NVARCHAR(MAX) NULL,
                        RefreshTokenExpiry DATETIME NULL
                )";
            
            ExecuteNonQuery(connection, createTableQuery);
        }
    }

    private static void ExecuteNonQuery(SqlConnection connection, string query)
    {
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.ExecuteNonQuery();
        }
    }
}
