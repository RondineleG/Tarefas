using System.Threading.Tasks;
using Tarefas.Domain.Repositories;
using Tarefas.Infrastructure.Persistence.Contexts;

namespace Tarefas.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}