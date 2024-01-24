using AutoMapper;
using Demo.CA_CQRS_Pub_Sub.Application.Blogs.Queries.GetBlogs;
using Demo.CA_CQRS_Pub_Sub.Application.Common.Notifications;
using Demo.CA_CQRS_Pub_Sub.Domain.Entity;
using Demo.CA_CQRS_Pub_Sub.Domain.Events;
using Demo.CA_CQRS_Pub_Sub.Domain.IRepository;
using MediatR;

namespace Demo.CA_CQRS_Pub_Sub.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogVm>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper, IMediator mediator)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<BlogVm> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blogEntity = new Blog()
            {
                Name = request.Name,
                Description = request.Description,
                Author = request.Author,
            };
            var Result = await _blogRepository.CreateAsync(blogEntity);

            // blog creation event
            await _mediator.Publish(new DomainEventNotification<EntityUpsertEvent<Blog>>(new EntityUpsertEvent<Blog>(blogEntity)));

            return _mapper.Map<BlogVm>(Result);
        }
    }
}