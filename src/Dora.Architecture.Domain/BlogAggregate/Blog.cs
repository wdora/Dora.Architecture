using Dora.Architecture.Domain.SeedWork;

namespace Dora.Architecture.Domain.BlogAggregate;

public class Blog
    : Entity, IAggregateRoot
{
    public string? Title { get; set; }

    public string? Content { get; set; }
}
