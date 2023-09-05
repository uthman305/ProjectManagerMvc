using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Models;
using Task = ProjectManager.Models.Task;

namespace ProjectManager.Dto
{
    public class CreateTaskViewModel
    {
        public string ProjectId { get; set; }
        public string TeamMemberId { get; set; }
        public string Description { get; set; }
        public IFormFile Document { get; set; }
    }
}