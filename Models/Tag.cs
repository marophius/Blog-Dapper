using Dapper.Contrib.Extensions;

namespace Blog_Dapper.Models {
    [Table("[Tag]")]
    public class Tag {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}