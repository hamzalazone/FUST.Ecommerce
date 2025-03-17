using Fust.Ecommerce.Models;

namespace Fust.Ecommerce.Services
{
    public interface IAspNetUsersDataAccess
    {
        Task<IEnumerable<AspNetUsers>> GetAspNetUsersAsync();
        AspNetUsers? getUser(string Id);
        Task<AspNetUsers?> GetUserAsync(string Id);
        Task UpdateUserAsync(AspNetUsers user);
    }
}