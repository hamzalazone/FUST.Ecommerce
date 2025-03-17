using MySqlConnector;
using Fust.Ecommerce.Models;
using Dapper;

namespace Fust.Ecommerce.Services;

public class ItemDataAccess : IItemDataAccess
{
    private string _connectionString;
    public ItemDataAccess(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
             ?? throw new Exception("Database not found");
    }
    public IEnumerable<Item> GetItems()
    {
        using var connection = new MySqlConnection(_connectionString);
        const string query = @"
            SELECT 
                id,
                Title,
                Description,
                CategoryId,
                UserId,
                Completed,
                CreatedDate,
                CompletedDate
            FROM
                items;
        ";



        return connection.Query<Item>(query);
    }
    public
        Item? GetItem(int Id)
    {
        using var connection = new MySqlConnection(_connectionString);
        const string query = @"
            SELECT 
                id,
                Title,
                Description,
                CategoryId,
                UserId,
                Completed,
                CreatedDate,
                CompletedDate
            FROM
                items
            WHERE
                id = @Id;
            "
        ;

        return connection.QueryFirstOrDefault<Item>(query, new { Id });
    }
    public void AddItem(Item item)
    {
        using var connection = new MySqlConnection(_connectionString);

        const string query = @"
            INSERT INTO items
            (id, Title, Description, CategoryId, UserId, Completed, CreatedDate, CompletedDate)
            VALUES
            (@Id, @Title, @Description, @CategoryId, @UserId, @Completed, @CreatedDate, @CompletedDate);
            
";

        item.Id = connection.ExecuteScalar<int>(query, item);
    }

    public void UpdateItem(Item item)
    {
        using var connection = new MySqlConnection(_connectionString);
        const string query = @"
            UPDATE items
            SET
                Title = @Title,
                Description = @Description,
                CategoryId = @CategoryId,
                UserId = @UserId,
                Completed = @Completed,
                CreatedDate = @CreatedDate,
                CompletedDate = @CompletedDate
            WHERE
                id = @Id;
            ";
        connection.Execute(query, item);
    }
    public void DeleteItem(int Id)
    {
        using var connection = new MySqlConnection(_connectionString);
        const string query = @"
            DELETE FROM items
            WHERE
                id = @Id;            
            ";
        connection.Execute(query, new { Id });
    }
    public void UpdateToTrue(Item item)
    {
        using var connection = new MySqlConnection(_connectionString);
        DateTime date = DateTime.Now;
        const string query = @"
            UPDATE items
            SET                
                Completed = true,                
                CompletedDate = @date
            WHERE
                id = @Id;
            ";
        connection.Execute(query, item);
    }
    public void UpdateToFalse(Item item)
    {
        using var connection = new MySqlConnection(_connectionString);
        
        const string query = @"
            UPDATE items
            SET                
                Completed = false,                
                CompletedDate = null
            WHERE
                id = @Id;
            ";
        connection.Execute(query, item);
    }
}
