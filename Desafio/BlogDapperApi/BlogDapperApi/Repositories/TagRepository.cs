using BlogDapperApi.Interfaces;
using BlogDapperApi.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BlogDapperApi.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        private readonly IDbConnection _connection;
        public TagRepository(IDbConnection connection) : base(connection) => _connection = connection;

        public List<Tag> TagsWithPosts()
        {
            throw new NotImplementedException();
        }
    }
}
