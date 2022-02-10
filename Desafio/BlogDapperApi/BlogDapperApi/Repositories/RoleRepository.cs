using BlogDapperApi.Interfaces;
using BlogDapperApi.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BlogDapperApi.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly IDbConnection _connection;
        public RoleRepository(IDbConnection connection) : base(connection) => _connection = connection;
    }
}
