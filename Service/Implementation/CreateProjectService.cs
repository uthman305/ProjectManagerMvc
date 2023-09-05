using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ProjectManager.Dto;
using ProjectManager.Models;
using ProjectManager.Repository.Interface;
using ProjectManager.Service.Interface;

namespace ProjectManager.Service.Implementation
{
    public class CreateProjectService : ICreateProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly ITeamMemberProjectRepository _teamMemberProjectRepository;
        private readonly IUserRepository _userRepository;
        public CreateProjectService(IProjectRepository projectRepository, ITeamMemberProjectRepository teamMemberProjectRepository, ITeamMemberRepository teamMemberRepository, IUserRepository userRepository)
        {
            _projectRepository = projectRepository;
            _teamMemberProjectRepository = teamMemberProjectRepository;
            _teamMemberRepository = teamMemberRepository;
            _userRepository = userRepository;   
        }
        public BaseResponse Create(CreateProjectRequestModel model, string userId, out string projectId)
        {
                        
            var project = new Project
            {
                Name = model.Name,
            };
            var teamMember = new  TeamMember
            {
                UserId = userId,

            };
            var teamMemberProject = new  TeamMemberProject
            {
                UserId = userId,
                ProjectId = project.Id,
                TeamMemberId = teamMember.Id,
            };
            _projectRepository.Add(project);
            _teamMemberRepository.Add(teamMember);
            _teamMemberProjectRepository.Add(teamMemberProject);
            projectId = project.Id;
              return new BaseResponse
            {
                Message = "Created Successfully",
                Status = true,
            };
        }

    }
}