using Tarefas.Domain.Enums;

namespace Tarefas.Domain.Entities
{
    public class Tarefa
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public EStatus Status { get; set; }
    }
}