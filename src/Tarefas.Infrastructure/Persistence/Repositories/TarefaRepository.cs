using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tarefas.Domain.Entities;
using Tarefas.Domain.Repositories;
using Tarefas.Infrastructure.Persistence.Contexts;

namespace Tarefas.Infrastructure.Persistence.Repositories
{
    public class TarefaRepository : BaseRepository, ITarefaRepository
    {
        public TarefaRepository(TarefaDbContext context) : base(context) { }


        public async Task<Tarefa> BuscarPorId(int codigo)
        {
            return await _context.Tarefas
                                 .FirstOrDefaultAsync(p => p.Codigo == codigo);
        }

        public async Task Adicionar(Tarefa tarefa)
        {
            await _context.Tarefas.AddAsync(tarefa);
        }

        public void Atualizar(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
        }

        public void Deletar(Tarefa tarefa)
        {
            _context.Tarefas.Remove(tarefa);
        }

        public async Task<Tarefa> BuscarPorCodigo(int codigo)
        {
            return await _context.Tarefas
                                  .FirstOrDefaultAsync(p => p.Codigo == codigo);
        }

        public async Task<IList<Tarefa>> BuscarTodos()
        {
            return await _context.Tarefas.AsNoTracking().ToListAsync();
        }
    }
}