using System.Collections.Generic;
using Tarefas.Domain.Models;

namespace Tarefas.Domain.Communication
{
    public class TarefaResponse : BaseResponse<Tarefa>
    {
        public TarefaResponse(Tarefa tarefa) : base(tarefa) { }

        public TarefaResponse(string mensagem) : base(mensagem) { }

        public TarefaResponse(IEnumerable<Tarefa> tarefa) : base(tarefa) { }
    }
}