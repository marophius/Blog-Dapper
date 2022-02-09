using BlogDapperApi.Interfaces;
using BlogDapperApi.Models;
using Microsoft.Data.SqlClient;

namespace BlogDapperApi.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(SqlConnection connection) : base(connection)
        {
        }
    }
}
