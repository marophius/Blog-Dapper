using BlogDapperApi.Interfaces;
using BlogDapperApi.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Data;
using Dapper.Contrib.Extensions;

namespace BlogDapperApi.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly IDbConnection _connection;
        public CategoryRepository(IDbConnection connection) : base(connection) => _connection = connection;

        public List<Category> CategoriesWithPosts()
        {
            
            var query = @"
                SELECT 
                    [Category].*,
                    [Post].*
                FROM
                    [Category]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]
            ";

            var categories = new List<Category>();
            var items = _connection.Query<Category, Post, Category>(
                query,
                (category, post) =>
                {
                    var cat = categories.FirstOrDefault(x => x.Id == category.Id);
                    if (cat != null)
                    {
                        cat = category;
                        if (post != null)
                        {
                            cat.Posts.Add(post);
                        }
                        categories.Add(cat);
                    }
                    else
                    {
                        cat.Posts.Add(post);
                    }
                    return category;
                }, splitOn: "Id"
                );
            return categories;
        }

        public Category CategoryWithPosts(int id)
        {


            Category category = _connection.Get<Category>(id);

            category.Posts = _connection.GetAll<Post>().Where(x => x.CategoryId == id).ToList<Post>();

            return category;
        }
    }
}
