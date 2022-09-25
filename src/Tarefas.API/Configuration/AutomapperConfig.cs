using AutoMapper;
using Tarefas.API.ViewModels;
using Tarefas.Domain.Entities;
using Tarefas.Domain.Enums;
using Tarefas.Infrastructure.Extensions;

namespace Tarefas.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {

            CreateMap<SalvarTarefaViewModel, Tarefa>()
               .ForMember(src => src.Status, opt => opt.MapFrom(src => (EStatus)src.Status));

            CreateMap<Tarefa, SalvarTarefaViewModel>()
              .ForMember(src => src.Status,
                         opt => opt.MapFrom(src => src.Status.GetEnumDescription()));

            CreateMap<Tarefa, TarefaViewModel>()
              .ForMember(src => src.Status,
                         opt => opt.MapFrom(src => src.Status.GetEnumDescription()));
        }
    }
}