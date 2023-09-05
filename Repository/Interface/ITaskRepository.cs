using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = ProjectManager.Models.Task;

namespace ProjectManager.Repository.Interface
{
    public interface ITaskRepository
    {
        Task Add(Task task);
        
        void Delete(Task task);
        List<Task> GetAll();
        Task GetTask(string id);
        public List<Task> GetTasksByProjectId(string projectId);
        void Update(Task task);
    }
}