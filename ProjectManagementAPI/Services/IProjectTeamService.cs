using ProjectManagementAPI.Data;
using ProjectManagementAPI.Models.DTOs;

namespace ProjectManagementAPI.Services
{
    public interface IProjectTeamService: IGenericService<ProjectTeam, AddProjectTeamDTO, AddProjectTeamDTO, ProjectTeamResponseDTO>
    {
        Task<ProjectTeamResponseDTO> AddMemberToProjectAsync(AddProjectTeamDTO addProjectTeamDTO);
    }
}
