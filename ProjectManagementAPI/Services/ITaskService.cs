using ProjectManagementAPI.Models.DTOs;

namespace ProjectManagementAPI.Services
{
    public interface ITaskService: IGenericService<ProjectManagementAPI.Data.Task, CreateTaskDTO, UpdateTaskDTO, TaskResponseDTO>
    {
        Task<TaskResponseDTO> CreateTaskAsync(CreateTaskDTO CreateDTO);

        Task<TaskResponseDTO> UpdateTaskAsync(int id, UpdateTaskDTO UpdateDTO);
    }
}
