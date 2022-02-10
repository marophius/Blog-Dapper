using BlogDapperApi.Models;

namespace BlogDapperApi.Interfaces
{
    public interface ITagRepository : IRepository<Tag>
    {
        List<Tag> TagsWithPosts();
    }
}
