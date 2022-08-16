using Microsoft.AspNetCore.Mvc;
using Tarefas.API.ViewModels;
using Tarefas.Infrastructure.Extensions;

namespace Tarefas.API.Configuration
{
    public static class InvalidModelStateResponse
    {
        public static IActionResult ProduceErrorResponse(ActionContext context)
        {
            var errors = context.ModelState.GetErrorMessages();
            var response = new ErrorViewModel(messages: errors);

            return new BadRequestObjectResult(response);
        }
    }
}