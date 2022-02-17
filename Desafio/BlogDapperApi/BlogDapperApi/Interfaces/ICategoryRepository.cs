using BlogDapperApi.Models;

namespace BlogDapperApi.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        List<Category> CategoriesWithPosts();

        Category CategoryWithPosts(int id);
    }
}
