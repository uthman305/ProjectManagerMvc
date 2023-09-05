using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models
{
    public class TeamMember :BaseClass
    {
        public string UserId {get;set;}
        public ICollection<TeamMemberProject> TeamMemberProjects{get; set;} 
        public ICollection<Task> Tasks{get; set;} 
        
    }
}