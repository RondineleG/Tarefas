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

        protected BaseResponse(string message, T resource)
        {
            Success = false;
            Message = message;
            Resource = resource;
        }

        protected BaseResponse(string message, IEnumerable<T> resource)
        {
            Success = false;
            Message = message;
            Resources = resource;
        }

        protected BaseResponse(IEnumerable<string> erros)
        {
            Success = false;
            Message = string.Empty;
            foreach (var erro in erros)
            {
                Message += erro;
            }
        }

        protected BaseResponse(string message, IEnumerable<string> erros)
        {
            Success = false;
            Message = message;
            foreach (var erro in erros)
            {
                Message += erro;
            }
        }

        protected BaseResponse(string message, IEnumerable<string> erros, T resource)
        {
            Success = false;
            Message = message;
            foreach (var erro in erros)
            {
                Message += erro;
            }
            Resource = resource;
        }

        protected BaseResponse(string message, IEnumerable<string> erros, IEnumerable<T> resource)
        {
            Success = false;
            Message = message;
            foreach (var erro in erros)
            {
                Message += erro;
            }
            Resources = resource;
        }

    }
}