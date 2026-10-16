using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectManagementAPI.Data;
using ProjectManagementAPI.Data.Repository;
using ProjectManagementAPI.Models.DTOs;

namespace ProjectManagementAPI.Services
{
    public class ProjectTeamService: GenericService<ProjectTeam, AddProjectTeamDTO, AddProjectTeamDTO, ProjectTeamResponseDTO>, 
        IProjectTeamService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProjectTeamService(IRepository<ProjectTeam> repository, IMapper mapper, 
            ApplicationDbContext context, UserManager<ApplicationUser> userManager): base(repository, mapper, context)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ProjectTeamResponseDTO> AddMemberToProjectAsync(AddProjectTeamDTO createDTO)
        {
            var ProjectExists = await _context.Projects.AnyAsync(p => p.ProjectId == createDTO.ProjectId);

            if (!ProjectExists)
            {
                throw new ArgumentException("The Specified Project does not exist.");
            }

            var user = await _userManager.FindByIdAsync(createDTO.UserId);

            if (user == null)
            {
                throw new ArgumentException("The Specified User does not exist.");
            }

            var alreadyAssigned = await _context.ProjectTeams.AnyAsync(pt => 
                pt.ProjectId == createDTO.ProjectId && pt.UserId == createDTO.UserId);

            if (alreadyAssigned)
            {
                throw new ArgumentException("The User is already assigned to this Project.");
            }

            return await CreateAsync(createDTO);
        }
    }
}
