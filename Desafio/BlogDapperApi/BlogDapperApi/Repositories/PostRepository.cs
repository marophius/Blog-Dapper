using BlogDapperApi.Interfaces;
using BlogDapperApi.Models;
using Microsoft.Data.SqlClient;

namespace BlogDapperApi.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(SqlConnection connection) : base(connection)
        {
        }
    }
}
