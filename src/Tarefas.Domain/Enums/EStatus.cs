using System.ComponentModel;

namespace Tarefas.Domain.Enums
{
    public enum EStatus : byte
    {
        [Description("P")]
        Pendente = 0,

        [Description("C")]
        Concluido = 1
    }
}