using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Models;

namespace ProjectManager.Repository.Interface
{
    public interface ITeamMemberRepository
    {
        TeamMember Add(TeamMember teamMember);
        
        void Delete(TeamMember teamMember);
        List<TeamMember> GetAll();
        TeamMember GetTeamMember(string id);
        void Update(TeamMember teamMember);
        string GetTeamMemberIdByUserId(string userId);
    }
}