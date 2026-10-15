using AutoMapper;
using ProjectManagementAPI.Data;
using ProjectManagementAPI.Models.DTOs;

namespace ProjectManagementAPI.Configurations
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            // Project Mappings
            CreateMap<CreateProjectDTO, Project>();
            CreateMap<UpdateProjectDTO, Project>()
                .ForMember(dest => dest.ProjectId, opt => opt.Ignore())
                .ForMember(dest => dest.DateCreated, opt => opt.Ignore())
                .ForMember(dest => dest.DateModified, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());
            CreateMap<Project, ProjectResponseDTO>();

            //Task Mappings
            CreateMap<CreateTaskDTO, ProjectManagementAPI.Data.Task>();
            CreateMap<UpdateTaskDTO, ProjectManagementAPI.Data.Task>()
                .ForMember(dest => dest.TaskId, opt => opt.Ignore())
                .ForMember(dest => dest.DateCreated, opt => opt.Ignore())
                .ForMember(dest => dest.DateModified, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Project, opt => opt.Ignore());
            CreateMap<ProjectManagementAPI.Data.Task, TaskResponseDTO>();

            //ProjectTeam Mappings
            CreateMap<AddProjectTeamDTO, ProjectTeam>()
                .ForMember(dest => dest.ProjectTeamId, opt => opt.Ignore())
                .ForMember(dest => dest.DateCreated, opt => opt.Ignore())
                .ForMember(dest => dest.DateModified, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.Project, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedByUser, opt => opt.Ignore());
            CreateMap<ProjectTeam, ProjectTeamResponseDTO>();
        }
    }
}
