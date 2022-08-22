using System.Collections.Generic;
using Tarefas.Domain.Models;

namespace Tarefas.Domain.Communication
{
    public class TarefaResponse : Response<Tarefa>
    {
        public TarefaResponse(Tarefa tarefa) : base(tarefa) { }

        public TarefaResponse(string mensagem) : base(mensagem) { }

        public TarefaResponse(IEnumerable<Tarefa> tarefa) : base(tarefa) { }

        public TarefaResponse(IEnumerable<string> erros) : base(erros) { }

        public TarefaResponse(string mensagem, IEnumerable<Tarefa> tarefa) : base(mensagem, tarefa) { }

        public TarefaResponse(string mensagem, IEnumerable<string> erros) : base(mensagem, erros) { }

        public TarefaResponse(string mensagem, Tarefa tarefa) : base(mensagem, tarefa) { }

    }

    public class Response<T> : BaseResponse<T>
    {
        public Response(T resource) : base(resource) { }
        public Response(string mensagem) : base(mensagem) { }
        public Response(IEnumerable<T> resource) : base(resource) { }
        public Response(IEnumerable<string> erros) : base(erros) { }
        public Response(string mensagem, IEnumerable<T> resource) : base(mensagem, resource) { }
        public Response(string mensagem, IEnumerable<string> erros) : base(mensagem, erros) { }
        public Response(string mensagem, T resource) : base(mensagem, resource) { }
    }
}