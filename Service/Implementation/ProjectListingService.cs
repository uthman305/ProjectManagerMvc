using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Dto;
using ProjectManager.Repository.Interface;
using ProjectManager.Service.Interface;

namespace ProjectManager.Service.Implementation
{
    public class ProjectListingService: IProjectListingService
    {
        private readonly ITeamMemberProjectRepository _teamMemberProjectRepository;
    private readonly IProjectRepository _projectRepository;

    public ProjectListingService(ITeamMemberProjectRepository teamMemberProjectRepository, IProjectRepository projectRepository)
    {
        _teamMemberProjectRepository = teamMemberProjectRepository;
        _projectRepository = projectRepository;
    }

    public List<ProjectListingViewModel> GetUserProjects(string userId)
    {
        var userProjects = _teamMemberProjectRepository.GetUserProjects(userId);
        var projectIds = userProjects.Select(up => up.ProjectId).ToList();
        var projects = _projectRepository.GetProjectsByIds(projectIds);

        var projectViewModels = projects.Select(p => new ProjectListingViewModel
        {
            ProjectId = p.Id,
            ProjectName = p.Name,
            // Map other properties as needed
        }).ToList();


        return projectViewModels;
    }
    }
}