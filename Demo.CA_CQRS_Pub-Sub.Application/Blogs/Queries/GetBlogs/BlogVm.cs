using Demo.CA_CQRS_Pub_Sub.Application.Common.Mappings;
using Demo.CA_CQRS_Pub_Sub.Domain.Entity;

namespace Demo.CA_CQRS_Pub_Sub.Application.Blogs.Queries.GetBlogs
{
    public class BlogVm : IMapFrom<Blog>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}