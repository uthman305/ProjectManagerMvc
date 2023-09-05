using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models
{
    public class Project : BaseClass
    {
        public string Name { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<TeamMemberProject> TeamMemberProjects { get; set; }

    }
}