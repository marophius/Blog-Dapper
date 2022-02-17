using BlogDapperApi.Interfaces;
using BlogDapperApi.Models;
using Dapper;
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
            var query = @"
                SELECT 
                    [Tag].*,
                    [Post].*
                FROM
                    [Tag]
                    LEFT JOIN [PostTag] ON [PostTag].[TagId] = [Tag].[Id]
                    LEFT JOIN [Post] ON [PostTag].[PostId] = [Post].[Id]
            ";

            var tags = new List<Tag>();
            var items = _connection.Query<Tag, Post, Tag>(
                query,
                (tag, post) =>
                {
                    var t = tags.FirstOrDefault(x => x.Id == tag.Id);
                    if (t != null)
                    {
                        t = tag;
                        if (post != null)
                        {
                            t.Posts.Add(post);
                        }
                        tags.Add(t);
                    }
                    else
                    {
                        t.Posts.Add(post);
                    }
                    return tag;
                }, splitOn: "Id"
                );
            return tags;
        }
    }
}
