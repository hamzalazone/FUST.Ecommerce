using MySqlConnector;
using Fust.Ecommerce.Models;
using Pomelo.EntityFrameworkCore.MySql;
using Dapper;


namespace Fust.Ecommerce.Services;

public class CategoryDataAccess : ICategoryDataAccess
{
    private string _connectionString;
    public CategoryDataAccess(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
             ?? throw new Exception("Database not found");
    }

    public IEnumerable<Category> GetCategories()
    {
        using var connection = new MySqlConnection(_connectionString);
        const string query = @"
            SELECT 
                Id,
                Name
            FROM
                categories;
        ";



        return connection.Query<Category>(query);
    }
    public Category? GetCategory(int Id)
    {
        using var connection = new MySqlConnection(_connectionString);
        const string query = @"
            SELECT *
                
            FROM
                categories
            WHERE
                Id = @Id;
            "
        ;

        return connection.QueryFirstOrDefault<Category>(query, new { Id });
    }
    public void AddCategory(Category category)
    {
        using var connection = new MySqlConnection(_connectionString);

        const string query = @"
            INSERT INTO categories
            (id, name)
            VALUES
            (@Id, @Name);
            ";

        category.Id = connection.ExecuteScalar<int>(query, category);
    }

    public void UpdateCategory(Category category)
    {
        using var connection = new MySqlConnection(_connectionString);
        const string query = @"
            UPDATE categories
            SET
                id = @Id,
                name = @Name                
            WHERE
                id = @Id;
            ";
        connection.Execute(query, category);
    }
    public void DeleteCategory(int Id)
    {
        using var connection = new MySqlConnection(_connectionString);
        const string query = @"
            DELETE FROM categories
            WHERE
                id = @Id;
            ";
        connection.Execute(query, new { Id });
    }
}

