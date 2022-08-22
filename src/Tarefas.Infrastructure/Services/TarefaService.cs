using System;
using System.Threading.Tasks;
using Tarefas.Domain.Communication;
using Tarefas.Domain.Models;
using Tarefas.Domain.Repositories;
using Tarefas.Domain.Services;

namespace Tarefas.Infrastructure.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TarefaService(ITarefaRepository tarefaRepository, IUnitOfWork unitOfWork)
        {
            _tarefaRepository = tarefaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TarefaResponse> Adicionar(Tarefa tarefa)
        {

            if (tarefa.Status != 0)
            {
                return new TarefaResponse($"Tarefa não pode ser cadastrada como {EStatus.Concluido}, o campos Status deve ser {0}");
            }

            if (tarefa.Descricao == "")
            {
                return new TarefaResponse($"Campo {tarefa.Descricao} é obrigatorio");
            }


            try
            {
                await _tarefaRepository.Adicionar(tarefa);
                await _unitOfWork.CompleteAsync();
                return new TarefaResponse(tarefa);
            }
            catch (Exception ex)
            {
                return new TarefaResponse($"Ocorreu um erro ao salvar a tarefa: {ex.Message}");
            }
        }

        public async Task<TarefaResponse> Atualizar(int codigo, Tarefa tarefa)
        {
            var tarefaExistente = await _tarefaRepository.BuscarPorId(codigo);
            var myType = typeof(Tarefa);

            if (tarefaExistente == null)
            {
                return new TarefaResponse("Tarefa n�o encontrada!");
            }

            try
            {
                if (tarefa.Descricao == null)
                {
                    var descricao = myType.GetProperty("Descricao").Name;
                    return new TarefaResponse($"Campos {descricao} e obrigatorio!");
                }
                if (tarefa.Status == EStatus.Pendente)
                {
                    var status = myType.GetProperty("Status").Name;
                    return new TarefaResponse($"Tarefa n�o pode ser alterado para {EStatus.Pendente}, o campos Status deve ser  {1}");
                }
                tarefaExistente.Descricao = tarefa.Descricao;
                tarefaExistente.Status = tarefa.Status;
                _tarefaRepository.Atualizar(tarefaExistente);
                await _unitOfWork.CompleteAsync();

                return new TarefaResponse(tarefaExistente);
            }
            catch (Exception ex)
            {
                return new TarefaResponse($"Ocorreu um erro ao atualizar a tarefa: {ex.Message}");
            }
        }

        public async Task<TarefaResponse> Deletar(int codigo)
        {
            var tarefa = await _tarefaRepository.BuscarPorId(codigo);

            if (tarefa == null)
            {
                return new TarefaResponse("Tarefa não encontrada!");
            }
            try
            {
                _tarefaRepository.Deletar(tarefa);
                await _unitOfWork.CompleteAsync();

                return new TarefaResponse(tarefa);
            }
            catch (Exception ex)
            {
                return new TarefaResponse($"Ocorreu um erro ao deletar a tarefa: {ex.Message}");
            }
        }

        public async Task<TarefaResponse> BuscarPorCodigo(int codigo)
        {
            var tarefa = await _tarefaRepository.BuscarPorId(codigo);

            if (tarefa == null)
            {
                return new TarefaResponse("Tarefa não encontrada!");
            }

            return new TarefaResponse(tarefa);
        }


        public async Task<TarefaResponse> BuscarTodos()
        {
            var tarefas = await _tarefaRepository.BuscarTodos();

            if (tarefas == null)
            {
                return new TarefaResponse("Nehuma tarefa encontrada!");
            }

            return new TarefaResponse(tarefas);
        }
    }
}