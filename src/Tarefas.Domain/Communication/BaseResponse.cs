using System.Collections.Generic;

namespace Tarefas.Domain.Communication
{
    public abstract class BaseResponse<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Resource { get; set; }
        public IEnumerable<T> Resources { get; set; }

        protected BaseResponse(IEnumerable<T> resource)
        {
            Success = true;
            Message = string.Empty;
            Resources = resource;
        }

        protected BaseResponse(string message)
        {
            Success = false;
            Message = message;
            Resource = default;
        }

        protected BaseResponse(T resource)
        {
            Success = true;
            Message = string.Empty;
            Resource = resource;
        }

    }
}