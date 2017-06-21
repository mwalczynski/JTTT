using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JTTT.DaoModels;
using JTTT.Dtos;
using JTTT.ViewModels;
using JTTT.ViewModels.IfThisViewModels;
using JTTT.ViewModels.ThenThatViewModels;

namespace JTTT
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                // IfThis Mapping
                cfg.CreateMap<IsImageViewModel, ConditionDto>();
                cfg.CreateMap<ConditionDto, IsImageViewModel>();
                cfg.CreateMap<ConditionDto, JtttConditionImgAlt>();
                cfg.CreateMap<JtttConditionImgAlt, ConditionDto>();

                // ThenThat Mapping
                cfg.CreateMap<SendMailViewModel, ActionDto>();
                cfg.CreateMap<ActionDto, SendMailViewModel>();
                cfg.CreateMap<ActionDto, JtttActionEmail>();
                cfg.CreateMap<JtttActionEmail, ActionDto>();

                // Task Mapping
                cfg.CreateMap<JtttTask, TaskDto>()
                    .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => Mapper.Map<ConditionDto>(src.Condition)))
                    .ForMember(dest => dest.Action, opt => opt.MapFrom(src => Mapper.Map<ActionDto>(src.Action)));
                cfg.CreateMap<TaskDto, TaskViewModel>()
                    .ForMember(dest => dest.IfThisPage, opt => opt.MapFrom(src => src.Condition.CreateViewModel()))
                    .ForMember(dest => dest.ThenThatPage, opt => opt.MapFrom(src => src.Action.CreateViewModel()));

                cfg.CreateMap<TaskDto, JtttTask>()
                    .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.Condition.CreateDao()))
                    .ForMember(dest => dest.Action, opt => opt.MapFrom(src => src.Action.CreateDao()));
                cfg.CreateMap<TaskViewModel, TaskDto>()
                    .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.IfThisPage))
                    .ForMember(dest => dest.Action, opt => opt.MapFrom(src => src.ThenThatPage));
            });
        }
    }
}
