using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = ProjectManager.Models.Task;

namespace ProjectManager.Dto
{
    public class TaskListingViewModel
    {
    public List<Task> Tasks { get; set; }
    public string ProjectName { get; set; }
    }
}