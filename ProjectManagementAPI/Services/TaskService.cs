using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagementAPI.Data;
using ProjectManagementAPI.Data.Repository;
using ProjectManagementAPI.Models.DTOs;

namespace ProjectManagementAPI.Services
{
    public class TaskService: GenericService<ProjectManagementAPI.Data.Task, CreateTaskDTO, UpdateTaskDTO, TaskResponseDTO>, 
        ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(IRepository<ProjectManagementAPI.Data.Task> repository, IMapper mapper, ApplicationDbContext context)
            : base(repository, mapper, context)
        {
            _context = context;
        }

        public async Task<TaskResponseDTO> CreateTaskAsync(CreateTaskDTO createDTO)
        {
            var projectExists = await _context.Projects.AnyAsync(p => p.ProjectId == createDTO.ProjectId);

            if (!projectExists)
            {
                throw new ArgumentException("The Specified Project does not exist.");
            }

            if (createDTO.DueDate.Date < DateTime.UtcNow.Date)
            {
                throw new ArgumentException("Due date cannot be in the past.");
            }

            return await CreateAsync(createDTO);
        }

        public async Task<TaskResponseDTO?> UpdateTaskAsync(int id, UpdateTaskDTO updateDTO)
        {
            var projectExists = await _context.Projects.AnyAsync(p => p.ProjectId == updateDTO.ProjectId);

            if (!projectExists)
            {
                throw new ArgumentException("The Specified Project does not exist.");
            }

            if (updateDTO.DueDate.Date < DateTime.UtcNow.Date)
            {
                throw new ArgumentException("Due date cannot be in the past.");
            }

            return await UpdateAsync(id, updateDTO);
        }
    }
}
