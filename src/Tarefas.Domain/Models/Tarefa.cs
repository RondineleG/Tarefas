using System;
using System.Collections.Generic;

namespace Tarefas.Domain.Models
{
    public class Tarefa
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public EStatus Status { get; set; }

        public static explicit operator Tarefa(List<Tarefa> v)
        {
            throw new NotImplementedException();
        }
    }
}