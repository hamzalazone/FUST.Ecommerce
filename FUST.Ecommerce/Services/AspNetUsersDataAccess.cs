using Dapper;
using Fust.Ecommerce.Components.Pages.Admin.Users;
using Fust.Ecommerce.Models;
using MySqlConnector;

namespace Fust.Ecommerce.Services
{
    public class AspNetUsersDataAccess : IAspNetUsersDataAccess
    {
        private string _connectionString;

        public AspNetUsersDataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new Exception("Database not found");
        }

        public async Task<IEnumerable<AspNetUsers>> GetAspNetUsersAsync()
        {
            await using var connection = new MySqlConnection(_connectionString);
            const string query = """
                SELECT 
                    Id, 
                    Email
                FROM 
                    AspNetUsers
                """;
            return await connection.QueryAsync<AspNetUsers>(query);
        }

        public AspNetUsers? getUser(string Id)
        {
            using var connection = new MySqlConnection(_connectionString);
            const string query = @"
            SELECT *
                
            FROM
                AspNetUsers 
            WHERE
                Id = @Id;
            "
            ;

            return connection.QueryFirstOrDefault<AspNetUsers>(query, new { Id });
        }
        public async Task<AspNetUsers?> GetUserAsync(string Id)
        {
            await using var connection = new MySqlConnection(_connectionString);
            const string query = @"
            SELECT *
            FROM AspNetUsers 
            WHERE Id = @Id;
            ";

            return await connection.QueryFirstOrDefaultAsync<AspNetUsers>(query, new { Id });
        }

        public async Task UpdateUserAsync(AspNetUsers user)
        {
            await using var connection = new MySqlConnection(_connectionString);
            const string query = @"
            UPDATE AspNetUsers
            SET
                id = @Id,
                email = @Email                
            WHERE
                id = @Id;
            ";
            await connection.ExecuteAsync(query, user);
        }
    }
}
