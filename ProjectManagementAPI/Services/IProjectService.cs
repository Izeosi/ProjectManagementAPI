using ProjectManagementAPI.Data;
using ProjectManagementAPI.Models.DTOs;

namespace ProjectManagementAPI.Services
{
    public interface IProjectService: IGenericService<Project, CreateProjectDTO, UpdateProjectDTO, ProjectResponseDTO>
    {
        Task<ProjectResponseDTO> CreateProjectAsync(CreateProjectDTO CreateDTO);

        Task<ProjectResponseDTO> UpdateProjectAsync(int id, UpdateProjectDTO UpdateDTO);
    }
}
