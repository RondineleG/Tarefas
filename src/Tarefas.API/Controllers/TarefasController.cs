using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarefas.API.ViewModels;
using Tarefas.Domain.Models;
using Tarefas.Domain.Services;

namespace Tarefas.API.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;
        private readonly IMapper _mapper;

        public TarefasController(ITarefaService tarefaService, IMapper mapper)
        {
            _tarefaService = tarefaService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> BuscarTodos()
        {

            var result = await _tarefaService.BuscarTodos();

            if (!result.Success)
            {
                return BadRequest(new ErrorViewModel(result.Message));
            }

            return Ok(result.Resources);
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> BuscarPorCodigo(int codigo)
        {
            var result = await _tarefaService.BuscarPorCodigo(codigo);

            if (!result.Success)
            {
                return BadRequest(new ErrorViewModel(result.Message));
            }

            return Ok(result.Resource);
        }


        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] SalvarTarefaViewModel resource)
        {
            var tarefa = _mapper.Map<SalvarTarefaViewModel, Tarefa>(resource);

            var result = await _tarefaService.Adicionar(tarefa);

            if (!result.Success)
            {
                return BadRequest(new ErrorViewModel(result.Message));
            }

            return Ok(result.Resource);
        }


        [HttpPut("{codigo}")]
        public async Task<IActionResult> Atualizar(int codigo, [FromBody] SalvarTarefaViewModel resource)
        {
            var tarefa = _mapper.Map<SalvarTarefaViewModel, Tarefa>(resource);

            var result = await _tarefaService.Atualizar(codigo, tarefa);

            if (!result.Success)
            {
                return BadRequest(new ErrorViewModel(result.Message));
            }

            return Ok(result.Resource);
        }


        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Deletar(int codigo)
        {
            var result = await _tarefaService.Deletar(codigo);

            if (!result.Success)
            {
                return BadRequest(new ErrorViewModel(result.Message));
            }
            return Ok(result.Resource);
        }
    }
}
