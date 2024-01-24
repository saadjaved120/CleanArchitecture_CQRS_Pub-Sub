using MediatR;

namespace Demo.CA_CQRS_Pub_Sub.Application.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}