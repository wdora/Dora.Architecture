using Dora.Architecture.Domain.BlogAggregate;
using Dora.Architecture.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.Architecture.Application.Common.Interfaces.Presistence;

public interface IBlogRepository// : IRepository<Blog>
{
    void Insert(Blog entity);

    void Update(Blog entity);

    IEnumerable<Blog> GetAll();

    Blog GetById();
}
