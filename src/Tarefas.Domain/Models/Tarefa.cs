namespace Tarefas.Domain.Models
{
    public class Tarefa
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public EStatus Status { get; set; }
    }
}