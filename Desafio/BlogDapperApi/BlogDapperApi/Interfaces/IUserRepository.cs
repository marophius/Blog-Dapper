using BlogDapperApi.Models;

namespace BlogDapperApi.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetUsersWithRoles();
    }
}
