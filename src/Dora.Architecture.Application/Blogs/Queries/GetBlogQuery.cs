using Dora.Architecture.Domain.BlogAggregate;
using Dora.Architecture.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.Architecture.Application.Blogs.Queries;
public record GetBlogQuery(int Id) : IRequest<BlogDto?>;

public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, BlogDto?>
{
    IRepository<Blog> _repository;

    public GetBlogQueryHandler(IRepository<Blog> repository)
    {
        _repository = repository;
    }

    public async Task<BlogDto?> Handle(GetBlogQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(request.Id);

        if (entity == null)
        {
            return default;
        }

        return new BlogDto { Id = entity.Id, Title = entity.Title };
    }
}