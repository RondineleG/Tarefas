using System.Threading.Tasks;

namespace Tarefas.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}