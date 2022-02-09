using BlogDapperApi.Interfaces;
using BlogDapperApi.Models;
using Microsoft.Data.SqlClient;

namespace BlogDapperApi.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SqlConnection connection) : base(connection) 
        { 
        }
        public Task<IEnumerable<User>> GetUsersWithRoles()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserWithRoles()
        {
            throw new NotImplementedException();
        }
    }
}
