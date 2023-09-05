using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Dto;
using Task = ProjectManager.Models.Task;

namespace ProjectManager.Service.Interface
{
    public interface ICreateTaskService
    {
        BaseResponse Create(CreateTaskViewModel model, string userId,string projectId);
        public List<Task> GetTasksByProjectId(string projectId);
    }
}