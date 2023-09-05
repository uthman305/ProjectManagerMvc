using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Dto;
using ProjectManager.Models;
using ProjectManager.Repository.Interface;
using ProjectManager.Service.Interface;

namespace ProjectManager.Service.Implementation
{
    public class JoinProjectService : IJoinProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly ITeamMemberProjectRepository _teamMemberProjectRepository;
        private readonly IUserRepository _userRepository;
        public JoinProjectService(IProjectRepository projectRepository, ITeamMemberProjectRepository teamMemberProjectRepository, ITeamMemberRepository teamMemberRepository, IUserRepository userRepository)
        {
            _projectRepository = projectRepository;
            _teamMemberProjectRepository = teamMemberProjectRepository;
            _teamMemberRepository = teamMemberRepository;
            _userRepository = userRepository;   
        }
        public BaseResponse Create(JoinProjectRequestModel model, string userId)
        {
                        
            var teamMember = new  TeamMember
            {
                UserId = userId,

            };
            var teamMemberProject = new  TeamMemberProject
            {
                UserId = userId,
                ProjectId =model.ProjectId ,
                TeamMemberId = teamMember.Id,
            };
            
            _teamMemberRepository.Add(teamMember);
            _teamMemberProjectRepository.Add(teamMemberProject);
              return new BaseResponse
            {
                Message = "Created Successfully",
                Status = true,
            };
        }

        public Project GetProjectById(string projectId)
    {
        return _projectRepository.GetProject(projectId);
    }

    }
}