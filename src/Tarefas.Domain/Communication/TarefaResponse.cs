using System.Collections.Generic;
using Tarefas.Domain.Models;

namespace Tarefas.Domain.Communication
{
    public class TarefaResponse : BaseResponse<Tarefa>
    {
        public TarefaResponse(Tarefa tarefa) : base(tarefa) { }

        public TarefaResponse(string mensagem) : base(mensagem) { }

        public TarefaResponse(IEnumerable<Tarefa> tarefa) : base(tarefa) { }

        public TarefaResponse(IEnumerable<string> erros) : base(erros) { }

        public TarefaResponse(string mensagem, IEnumerable<Tarefa> tarefa) : base(mensagem, tarefa) { }

        public TarefaResponse(string mensagem, IEnumerable<string> erros) : base(mensagem, erros) { }

        public TarefaResponse(string mensagem, Tarefa tarefa) : base(mensagem, tarefa) { }

    }
}

