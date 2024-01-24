using Demo.CA_CQRS_Pub_Sub.Application.Common.Notifications;
using Demo.CA_CQRS_Pub_Sub.Domain.Entity;
using Demo.CA_CQRS_Pub_Sub.Domain.Events;
using Demo.CA_CQRS_Pub_Sub.Domain.IRepository;
using MediatR;

namespace Demo.CA_CQRS_Pub_Sub.Application.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, int>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMediator _mediator;

        public DeleteBlogCommandHandler(IBlogRepository blogRepository, IMediator mediator)
        {
            _blogRepository = blogRepository;
            _mediator = mediator;
        }

        public async Task<int> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var blogEntity = await _blogRepository.GetByIdAsync(request.Id);
            var result = await _blogRepository.DeleteAsync(request.Id);

            // blog deletion event
            await _mediator.Publish(new DomainEventNotification<EntityDeleteEvent<Blog>>(new EntityDeleteEvent<Blog>(blogEntity)));

            return result;
        }
    }
}