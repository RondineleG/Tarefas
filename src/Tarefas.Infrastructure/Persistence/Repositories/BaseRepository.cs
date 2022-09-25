using Tarefas.Infrastructure.Persistence.Contexts;

namespace Tarefas.Infrastructure.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly TarefaDbContext _context;

        public BaseRepository(TarefaDbContext context)
        {
            _context = context;
        }
    }
}