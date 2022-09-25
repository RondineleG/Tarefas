using System.Collections.Generic;
using System.Threading.Tasks;
using Tarefas.Domain.Entities;

namespace Tarefas.Domain.Repositories
{
    public interface ITarefaRepository
    {
        Task Adicionar(Tarefa tarefa);
        Task<Tarefa> BuscarPorId(int codigo);
        void Atualizar(Tarefa tarefa);
        void Deletar(Tarefa tarefa);
        Task<Tarefa> BuscarPorCodigo(int codigo);
        Task<IList<Tarefa>> BuscarTodos();

    }
}