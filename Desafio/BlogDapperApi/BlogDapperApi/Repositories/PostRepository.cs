using BlogDapperApi.Interfaces;
using BlogDapperApi.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BlogDapperApi.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private readonly IDbConnection _connection;
        public PostRepository(IDbConnection connection) : base(connection) => _connection = connection;
    }
}
