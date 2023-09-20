using Dora.Architecture.Domain.BlogAggregate;
using Microsoft.EntityFrameworkCore;

namespace Dora.Architecture.EntityFrameworkCore;
public class DoraDbContext : DbContext
{
    public DoraDbContext(DbContextOptions<DoraDbContext> options) : base(options)
    {
        
    }

    public DbSet<Blog> Blogs { get; set; }
}
