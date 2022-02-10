using BlogDapperApi.Interfaces;
using BlogDapperApi.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BlogDapperApi.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IDbConnection _connection;
        public UserRepository(IDbConnection connection) : base(connection) => _connection = connection;
        public async Task<List<User>> GetUsersWithRoles()
        {
            var query = @"
                SELECT 
                    [User].*,
                    [Role].*
                FROM
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]
            ";

            var users = new List<User>();
            var items = _connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if(usr != null)
                    {
                        usr = user;
                        if(role != null)
                        {
                            usr.Roles.Add(role); 
                        }
                        users.Add(usr);
                    }else
                    {
                        usr.Roles.Add(role);
                    }
                    return user;
                }, splitOn: "Id"
                );
            return users;
        }

        public User GetUserWithRoles(int id)
        {
            var query = @"SELECT
                            [User].*,
                            [Role].*
                           FROM
                            [User],
                            [Role],
                            [UserRole]
                            WHERE [UserRole].[UserId] = [User].[Id] AND [Role].[Id] = [UserRole].[RoleId]";

            var user = new User();
            var items = _connection.Query<User, Role, User>(query
                , (usr, role) =>
                {
                    if(usr!= null)
                    {
                        user = usr;

                        user.Roles.Add(role);
                    }
                    return user;
                }, splitOn: "Id");

            return user;
        }
    }
}
