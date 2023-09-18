using Dora.Architecture.API.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dora.Architecture.API.Controllers;

[ApiController]
[ApiExceptionFilter]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender _mediator = null!;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}