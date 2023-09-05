using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Models;

namespace ProjectManager.Repository.Interface
{
    public interface ITeamMemberProjectRepository
    {
        TeamMemberProject Add(TeamMemberProject teamMemberProject);
        
        void Delete(TeamMemberProject teamMemberProject);
        List<TeamMemberProject> GetAll();
         List<TeamMemberProject> GetUserProjects(string userId);
        TeamMemberProject GetTeamMemberProject(string id);
        void Update(TeamMemberProject teamMemberProject);
    }
}