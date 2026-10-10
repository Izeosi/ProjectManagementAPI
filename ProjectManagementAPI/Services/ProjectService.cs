using AutoMapper;
using ProjectManagementAPI.Data;
using ProjectManagementAPI.Data.Repository;
using ProjectManagementAPI.Models.DTOs;

namespace ProjectManagementAPI.Services
{
    public class ProjectService: GenericService<Project, CreateProjectDTO, UpdateProjectDTO, ProjectResponseDTO>, IProjectService
    {
        public ProjectService(
            IRepository<Project> repository, 
            IMapper mapper, ApplicationDbContext context) : base(repository, mapper, context)
        { 
        }

        public async Task<ProjectResponseDTO> CreateProjectAsync(CreateProjectDTO createDTO)
        {
            if (createDTO.EndDate < createDTO.StartDate)
            {
                throw new ArgumentException("The Project end date cannot be earlier than the start date");
            }

            return await CreateAsync(createDTO);
        }

        public async Task<ProjectResponseDTO?> UpdateProjectAsync(int id, UpdateProjectDTO updateDTO)
        {
            if (updateDTO.EndDate < updateDTO.StartDate)
            {
                throw new ArgumentException("The Project end date cannot be earlier than the start date");
            }

            return await UpdateAsync(id, updateDTO);
        }
    }
}
