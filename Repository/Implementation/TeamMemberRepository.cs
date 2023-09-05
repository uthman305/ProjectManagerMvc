using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Models;
using ProjectManager.Models.ProjectManagerContext;
using ProjectManager.Repository.Interface;

namespace ProjectManager.Repository.Implementation
{
    public class TeamMemberRepository : ITeamMemberRepository
    {
        private readonly ProjectManagerContext _projectManagerContext;
        public TeamMemberRepository(ProjectManagerContext projectManagerContext)
        {
            _projectManagerContext = projectManagerContext;
        }
        public TeamMember Add(TeamMember teamMember)
        {
            _projectManagerContext.TeamMembers.Add(teamMember);
            _projectManagerContext.SaveChanges();
            return teamMember;
        }
        public void Delete(TeamMember teamMember)
        {
            _projectManagerContext.TeamMembers.Remove(teamMember);
            _projectManagerContext.SaveChanges();
        }

        public List<TeamMember> GetAll()
        {
            return _projectManagerContext.TeamMembers
            .ToList();
        }
        public TeamMember GetTeamMember(string id)
        {
            return _projectManagerContext.TeamMembers
            .SingleOrDefault(x => x.Id == id);
        }



        public void Update(TeamMember teamMember)
        {
            _projectManagerContext.Update(teamMember);
            _projectManagerContext.SaveChanges();
        }
        public string GetTeamMemberIdByUserId(string userId)
        {
            return _projectManagerContext.TeamMembers
                .Where(tm => tm.UserId == userId)
                .Select(tm => tm.Id)
                .FirstOrDefault();
        }
    }
}
