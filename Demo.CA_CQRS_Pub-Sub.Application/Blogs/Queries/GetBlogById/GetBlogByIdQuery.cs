using Demo.CA_CQRS_Pub_Sub.Application.Blogs.Queries.GetBlogs;
using MediatR;

namespace Demo.CA_CQRS_Pub_Sub.Application.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQuery : IRequest<BlogVm>
    {
        public int BlogId { get; set; }
    }
}