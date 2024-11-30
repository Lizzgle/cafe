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
                    CREATE TABLE users (
                        Id NVARCHAR(50) PRIMARY KEY,
                        Login NVARCHAR(20) NOT NULL,
                        Name NVARCHAR(20) NOT NULL,
                        Password NVARCHAR(255) NOT NULL,
                        DateOfBirth DATETIME NOT NULL,
                        RefreshToken NVARCHAR(MAX) NULL,
                        RefreshTokenExpiry DATETIME NULL,
                )";
            
            ExecuteNonQuery(connection, createTableQuery);
        }
    }

    public static void CreateRolesTable(string connectionString, string databaseName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            connection.ChangeDatabase(databaseName);

            string createTableQuery = @"
                    CREATE TABLE roles (
                        Id INT PRIMARY KEY,
                        Name NVARCHAR(20) NOT NULL,
            )";

            ExecuteNonQuery(connection, createTableQuery);

            string insertRolesQuery = @"
                INSERT INTO roles (Id, Name) 
                VALUES 
                (1, 'client'),
                (2, 'moderator'),
                (3, 'admin')";

            ExecuteNonQuery(connection, insertRolesQuery);
        }
    }

    public static void CreateUsersRolesTable(string connectionString, string databaseName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            connection.ChangeDatabase(databaseName);

            string createTableQuery = @"
                    CREATE TABLE userRoles (
                        UserId NVARCHAR(50),
                        RoleId INT,
                        PRIMARY KEY (UserId, RoleId),
                        FOREIGN KEY (UserId) REFERENCES users(Id) ON DELETE CASCADE,
                        FOREIGN KEY (RoleId) REFERENCES roles(Id) ON DELETE CASCADE
                )";

            ExecuteNonQuery(connection, createTableQuery);
        }
    }

    public static void CreateFeedbacksTable(string connectionString, string databaseName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            connection.ChangeDatabase(databaseName);

            string createTableQuery = @"
                    CREATE TABLE feedbacks (
                        Id NVARCHAR(50) PRIMARY KEY,
                        Description NVARCHAR(255) NOT NULL,
                        Rating INT NOT NULL,
                        Date DATETIME NOT NULL,
                        UserId NVARCHAR(50) NOT NULL,
                        FOREIGN KEY (UserId) REFERENCES users(Id) ON DELETE CASCADE
                )";

            ExecuteNonQuery(connection, createTableQuery);
        }
    }

    public static void CreateDessertsTable(string connectionString, string databaseName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            connection.ChangeDatabase(databaseName);

            string createTableQuery = @"
            CREATE TABLE desserts (
                Id NVARCHAR(50) PRIMARY KEY,
                Name NVARCHAR(100) NOT NULL,
                Description NVARCHAR(255) NULL,
                Calories INT NOT NULL,
                Price FLOAT NOT NULL
            )";

            ExecuteNonQuery(connection, createTableQuery);
        }
    }
    public static void CreateCategoriesTable(string connectionString, string databaseName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            connection.ChangeDatabase(databaseName);

            string createTableQuery = @"
                CREATE TABLE categories (
                    Id INT PRIMARY KEY,
                    Name NVARCHAR(20) NOT NULL
                )";

            ExecuteNonQuery(connection, createTableQuery);

            string insertCategoriesQuery = @"
            INSERT INTO categories (Id, Name) 
            VALUES 
            (1, 'coffee'),
            (2, 'tea'),
            (3, 'milkshake'),
            (4, 'coctail'),
            (5, 'alcohol'),
            (6, 'other')";

            ExecuteNonQuery(connection, insertCategoriesQuery);
        }
    }

    public static void CreateDrinksTable(string connectionString, string databaseName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            connection.ChangeDatabase(databaseName);

            string createDrinksTableQuery = @"
            CREATE TABLE drinks (
                Id NVARCHAR(50) PRIMARY KEY,
                Name NVARCHAR(100) NOT NULL,
                Description NVARCHAR(255),
                CategoryId INT NOT NULL,
                FOREIGN KEY (CategoryId) REFERENCES categories(Id)
            )";

            ExecuteNonQuery(connection, createDrinksTableQuery);
        }
    }

    public static void CreateSizesTable(string connectionString, string databaseName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            connection.ChangeDatabase(databaseName);

            string createTableQuery = @"
            CREATE TABLE sizes (
                Id INT PRIMARY KEY,
                Name NVARCHAR(10) NOT NULL,
                Volume INT NOT NULL
            )";

            ExecuteNonQuery(connection, createTableQuery);

            string insertSizesQuery = @"
            INSERT INTO Sizes (Id, Name, Volume)
            VALUES 
                (1, 'xs', 30),
                (2, 's', 180),
                (3, 'm', 240),
                (4, 'l', 300)";

            ExecuteNonQuery(connection, insertSizesQuery);
        }
    }

    public static void CreatePricesTable(string connectionString, string databaseName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            connection.ChangeDatabase(databaseName);

            string createTableQuery = @"
            CREATE TABLE prices (
                Id NVARCHAR(50) PRIMARY KEY,
                Cost FLOAT NOT NULL,
                DrinkId NVARCHAR(50),
                SizeId INT,
                FOREIGN KEY (DrinkId) REFERENCES drinks(Id),
                FOREIGN KEY (SizeId) REFERENCES sizes(Id)
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
