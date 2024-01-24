using Demo.CA_CQRS_Pub_Sub.Application.Blogs.Queries.GetBlogs;
using MediatR;

namespace Demo.CA_CQRS_Pub_Sub.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommand : IRequest<BlogVm>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}