using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Models;
using ProjectManager.Models.ProjectManagerContext;
using ProjectManager.Repository.Interface;

namespace ProjectManager.Repository.Implementation
{
    public class TeamMemberProjectRepository : ITeamMemberProjectRepository
    {
          private readonly ProjectManagerContext _projectManagerContext;
           public TeamMemberProjectRepository(ProjectManagerContext projectManagerContext)
        {
            _projectManagerContext = projectManagerContext;
        }
        public TeamMemberProject Add(TeamMemberProject teamMemberProject)
        {
           _projectManagerContext.TeamMemberProjects.Add(teamMemberProject);
            _projectManagerContext.SaveChanges();
            return teamMemberProject;
        }
        public void Delete(TeamMemberProject teamMemberProject)
        {
            _projectManagerContext.TeamMemberProjects.Remove(teamMemberProject);
            _projectManagerContext.SaveChanges();
        }

        public List<TeamMemberProject> GetAll()
        {
            return _projectManagerContext.TeamMemberProjects
            .ToList();
        }
        public TeamMemberProject GetTeamMemberProject(string id)
        {
            return _projectManagerContext.TeamMemberProjects
            .SingleOrDefault(x => x.Id == id);
        }

        public List<TeamMemberProject> GetUserProjects(string userId)
        {
           return _projectManagerContext.TeamMemberProjects
            .Where(tp => tp.UserId == userId)
            .ToList();
        }

        public void Update(TeamMemberProject teamMemberProject)
        {
            _projectManagerContext.Update(teamMemberProject);
            _projectManagerContext.SaveChanges();
        }
    }
}