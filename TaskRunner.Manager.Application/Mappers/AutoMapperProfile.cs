using AutoMapper;
using TaskRunner.Manager.Application.DTOs.Read;
using TaskRunner.Manager.Application.DTOs.Write;
using TaskRunner.Manager.Domain.Entities;

namespace TaskRunner.Manager.Application.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<TaskDefinition, TaskDefinitionReadDTO>()
                .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.CreatedDateTime, opt => opt.MapFrom(src => src.CreatedDateTime))
                .ForMember(dest => dest.ProcessDefinitions, opt => opt.MapFrom(src => src.ProcessDefinitions));

            CreateMap<TaskDefinitionWriteDTO, TaskDefinition>()
                .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));

            CreateMap<ProcessDefinition, ProcessDefinitionReadDTO>()
                .ForMember(dest => dest.ProcessId, opt => opt.MapFrom(src => src.ProcessId))
                .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.FunctionName, opt => opt.MapFrom(src => src.FunctionName))
                .ForMember(dest => dest.IsRetryAllowed, opt => opt.MapFrom(src => src.IsRetryAllowed))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                .ForMember(dest => dest.CreatedDateTime, opt => opt.MapFrom(src => src.CreatedDateTime));

            CreateMap<ProcessDefinitionWriteDTO, ProcessDefinition>()
                .ForMember(dest => dest.ProcessId, opt => opt.MapFrom(src => src.ProcessId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.FunctionName, opt => opt.MapFrom(src => src.FunctionName))
                .ForMember(dest => dest.IsRetryAllowed, opt => opt.MapFrom(src => src.IsRetryAllowed))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position));
        }
    }
}
