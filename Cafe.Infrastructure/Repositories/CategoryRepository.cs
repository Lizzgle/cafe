using Cafe.Domain.Abstractions;
using Cafe.Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        protected readonly string _connectionString;

        public CategoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string TableName = "categories";

        public Category MapToEntity(IDataReader reader)
        {
            var category = (Category)(int)reader["Id"];

            return category;
        }

        public async Task<List<Category>> GetAllAsync(CancellationToken token = default)
        {
            var entities = new List<Category>();

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
}
