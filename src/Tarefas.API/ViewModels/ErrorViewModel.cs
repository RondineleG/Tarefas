using System.Collections.Generic;

namespace Tarefas.API.ViewModels
{
    public class ErrorViewModel
    {
        public bool Success => false;
        public List<string> Messages { get; private set; }

        public ErrorViewModel(List<string> messages)
        {
            Messages = messages ?? new List<string>();
        }

        public ErrorViewModel(string message)
        {
            Messages = new List<string>();

            if (!string.IsNullOrWhiteSpace(message))
            {
                Messages.Add(message);
            }
        }
    }
}