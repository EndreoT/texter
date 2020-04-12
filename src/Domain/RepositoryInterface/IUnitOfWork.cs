using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Texter.Domain.RepositoryInterface
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
