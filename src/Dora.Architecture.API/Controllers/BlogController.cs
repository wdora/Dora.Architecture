using Dora.Architecture.Application.Blogs.Commands;
using Dora.Architecture.Application.Blogs.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Dora.Architecture.API.Controllers;

public class BlogController : ApiControllerBase
{
    [HttpPost]
    public Task<int> Create(CreateBlogCommand command)
    {
        return Mediator.Send(command);
    }

    [HttpGet("{id}")]
    public Task<BlogDto?> Get(int id)
    {
        return Mediator.Send(new GetBlogQuery(id));
    }
}
