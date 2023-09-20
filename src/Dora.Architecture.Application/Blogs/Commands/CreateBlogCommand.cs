using Dora.Architecture.Application.Common.Interfaces.Presistence;
using Dora.Architecture.Domain.BlogAggregate;
using Dora.Architecture.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.Architecture.Application.Blogs.Commands;

public record CreateBlogCommand(string Title, string Content) : IRequest<int>;

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, int>
{
    IRepository<Blog> blogRepository;

    public CreateBlogCommandHandler(IRepository<Blog> blogRepository)
    {
        this.blogRepository = blogRepository;
    }

    public async Task<int> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var entity = new Blog { Title = request.Title, Content = request.Content };

        blogRepository.Insert(entity);

        await blogRepository.SaveChangesAsync();

        return entity.Id;
    }
}