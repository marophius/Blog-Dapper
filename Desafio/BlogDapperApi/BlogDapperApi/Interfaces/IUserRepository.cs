using BlogDapperApi.Models;

namespace BlogDapperApi.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetUsersWithRoles();
        Task<User> GetUserWithRoles();
    }
}
