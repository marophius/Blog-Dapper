using BlogDapperApi.Interfaces;
using BlogDapperApi.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BlogDapperApi.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly IDbConnection _connection;
        public CategoryRepository(IDbConnection connection) : base(connection) => _connection = connection;

        public List<Category> CategoryWithPosts()
        {
            throw new NotImplementedException();
        }
    }
}
