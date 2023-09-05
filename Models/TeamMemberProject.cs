using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models
{
    public class TeamMemberProject:BaseClass
    {
        public string UserId {get;set;}
        public TeamMember TeamMember;
        public string ProjectId {get;set;}
        public string TeamMemberId { get; internal set; }

        public Project Project;
        
    }
}