using Demo.CA_CQRS_Pub_Sub.Application.Common.Notifications;
using Demo.CA_CQRS_Pub_Sub.Domain.Entity;
using Demo.CA_CQRS_Pub_Sub.Domain.Events;
using Demo.CA_CQRS_Pub_Sub.Domain.IRepository;
using MediatR;

namespace Demo.CA_CQRS_Pub_Sub.Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMediator _mediator;

        public UpdateBlogCommandHandler(IBlogRepository blogRepository, IMediator mediator)
        {
            _blogRepository = blogRepository;
            _mediator = mediator;
        }

        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var UpdateblogEntity = new Blog()
            {
                Id = request.Id,
                Author = request.Author,
                Description = request.Description,
                Name = request.Name
            };

            var result = await _blogRepository.UpdateAsync(request.Id, UpdateblogEntity);

            // blog updation event
            await _mediator.Publish(new DomainEventNotification<EntityUpsertEvent<Blog>>(new EntityUpsertEvent<Blog>(UpdateblogEntity)));

            return result;
        }
    }
}