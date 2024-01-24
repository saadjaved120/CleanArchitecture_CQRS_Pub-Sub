using MediatR;

namespace Demo.CA_CQRS_Pub_Sub.Application.Blogs.Queries.GetBlogs
{
    public class GetBlogQuery : IRequest<List<BlogVm>>
    {
    }
}