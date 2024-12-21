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

    public static void CreateFAQsTable(string connectionString, string databaseName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            connection.ChangeDatabase(databaseName);

            string createTableQuery = @"
                CREATE TABLE faqs (
                    Id INT PRIMARY KEY,
                    Question NVARCHAR(100) NOT NULL,
                    Answer NVARCHAR(200) NOT NULL,
                )";

            ExecuteNonQuery(connection, createTableQuery);

            string insertCategoriesQuery = @"
            INSERT INTO faqs (Id, Question, Answer) 
            VALUES 
            (1, 'Можно ли придти с собакой в кафе?', 'Да, можно наше заведение dogfriendly.'),
            (2, 'Какое время работы вашего заведение', 'Мы открыты с 10:00 до 22:00.'),
            (3, 'Есть ли альтернативное молоко?', 'Да, у нас есть кокосовое, миндальное и пшеничное.'),
            (4, 'Можно ли у вас провести мероприятие?', 'Да, вы можете заранее оповестить и забронировать кафе на проведение мероприятия.'),
            (5, 'Можно ли придти к вам с ноутбуком?', 'Да, вы можете купить в нашем заведении любой напиток или дессерт и сидеть в ноутбуке.'),
            (6, 'Как устроиться к вам работать', 'Вы можете обратиться по номеру телефона или подойти к сотрудникам нашего заведение.')";

            ExecuteNonQuery(connection, insertCategoriesQuery);
        }
    }

    public static void CreateIngredientsTable(string connectionString, string databaseName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            connection.ChangeDatabase(databaseName);

            string createTableQuery = @"
            CREATE TABLE ingredients (
                Id NVARCHAR(50) PRIMARY KEY,
                Name NVARCHAR(100) NOT NULL,
            )";

            ExecuteNonQuery(connection, createTableQuery);
        }
    }

    public static void CreateDrinksIngredientsTable(string connectionString, string databaseName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            connection.ChangeDatabase(databaseName);

            string createTableQuery = @"
                    CREATE TABLE drinksIngredients (
                        DrinkId NVARCHAR(50),
                        IngredientId INT,
                        PRIMARY KEY (DrinkId, IngredientId),
                        FOREIGN KEY (DrinkId) REFERENCES users(Id) ON DELETE CASCADE,
                        FOREIGN KEY (IngredientId) REFERENCES roles(Id) ON DELETE CASCADE
                )";

            ExecuteNonQuery(connection, createTableQuery);
        }
    }

    public static void CreateDessertsIngredientsTable(string connectionString, string databaseName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            connection.ChangeDatabase(databaseName);

            string createTableQuery = @"
                    CREATE TABLE dessertsIngredients (
                        DessertId NVARCHAR(50),
                        IngredientId INT,
                        PRIMARY KEY (DessertId, IngredientId),
                        FOREIGN KEY (DessertId) REFERENCES users(Id) ON DELETE CASCADE,
                        FOREIGN KEY (IngredientId) REFERENCES roles(Id) ON DELETE CASCADE
                )";

            ExecuteNonQuery(connection, createTableQuery);
        }
    }

    public static void CreateLogTable(string connectionString, string databaseName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            connection.ChangeDatabase(databaseName);

            string createLogTableQuery = @"
            CREATE TABLE feedbackLogs (
                LogId INT IDENTITY(1,1) PRIMARY KEY,
                UserId NVARCHAR(50) NOT NULL,
                Action NVARCHAR(50) NOT NULL,
                ActionTime DATETIME DEFAULT GETDATE(),
                FOREIGN KEY (UserId) REFERENCES users(Id)
            )";

            ExecuteNonQuery(connection, createLogTableQuery);
        }
    }

    public static void CreateLogTrigger(string connectionString, string databaseName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            connection.ChangeDatabase(databaseName);

            string createTriggerQuery = @"
           CREATE OR ALTER TRIGGER LogFeedbackActions
ON feedbacks
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Логирование операций INSERT
    INSERT INTO feedbackLogs (UserId, Action, ActionTime)
    SELECT 
        i.UserId,
        'INSERT' AS Action,
        GETDATE() AS ActionTime
    FROM inserted i
    WHERE EXISTS (SELECT 1 FROM users WHERE Id = i.UserId);

    -- Логирование операций UPDATE
    INSERT INTO feedbackLogs (UserId, Action, ActionTime)
    SELECT 
        i.UserId,
        'UPDATE' AS Action,
        GETDATE() AS ActionTime
    FROM inserted i
    JOIN deleted d ON i.Id = d.Id
    WHERE EXISTS (SELECT 1 FROM users WHERE Id = i.UserId);

    -- Логирование операций DELETE
    INSERT INTO feedbackLogs (UserId, Action, ActionTime)
    SELECT 
        d.UserId,
        'DELETE' AS Action,
        GETDATE() AS ActionTime
    FROM deleted d
    WHERE EXISTS (SELECT 1 FROM users WHERE Id = d.UserId);
END;
";

            ExecuteNonQuery(connection, createTriggerQuery);
        }
    }

    public static void CreatePartialSearchIngredientFunction(string connectionString, string databaseName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            connection.ChangeDatabase(databaseName);

            string createFunctionQuery = @"
        CREATE FUNCTION PartialSearchIngredient(@partialName NVARCHAR(100))
        RETURNS @result TABLE (
            Id NVARCHAR(50),
            Name NVARCHAR(100)
        )
        AS
        BEGIN
            INSERT INTO @result
            SELECT i.Id, i.Name
            FROM ingredients AS i
            WHERE i.Name LIKE '%' + @partialName + '%';

            RETURN;
        END;";

            ExecuteNonQuery(connection, createFunctionQuery);
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
