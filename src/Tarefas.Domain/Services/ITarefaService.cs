using System.Threading.Tasks;
using Tarefas.Domain.Communication;
using Tarefas.Domain.Models;

namespace Tarefas.Domain.Services
{
    public interface ITarefaService
    {
        Task<TarefaResponse> Adicionar(Tarefa tarefa);
        Task<TarefaResponse> Atualizar(int codigo, Tarefa tarefa);
        Task<TarefaResponse> Deletar(int codigo);
        Task<TarefaResponse> BuscarPorCodigo(int codigo);
        Task<TarefaResponse> BuscarTodos();
    }
}