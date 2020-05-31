using System.Threading.Tasks;

namespace Texter.Domain.RepositoryInterface
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
