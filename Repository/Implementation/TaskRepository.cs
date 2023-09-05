using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Models;
using ProjectManager.Models.ProjectManagerContext;
using ProjectManager.Repository.Interface;
using Task = ProjectManager.Models.Task;

namespace ProjectManager.Repository.Implementation
{
    public class TaskRepository : ITaskRepository
    {
         private readonly ProjectManagerContext _projectManagerContext;
         public TaskRepository(ProjectManagerContext projectManagerContext)
        {
            _projectManagerContext = projectManagerContext;
        }
        public Task Add(Task task)
        {
           _projectManagerContext.Tasks.Add(task);
            _projectManagerContext.SaveChanges();
            return task;
        }
        public void Delete(Task task)
        {
            _projectManagerContext.Tasks.Remove(task);
            _projectManagerContext.SaveChanges();
        }
         public List<Task> GetTasksByProjectId(string projectId)
    {
        return _projectManagerContext.Tasks
            .Where(t => t.ProjectId == projectId)
            .ToList();
    }

        public List<Task> GetAll()
        {
            return _projectManagerContext.Tasks
            .ToList();
        }
        public Task GetTask(string id)
        {
            return _projectManagerContext.Tasks
            .SingleOrDefault(x => x.Id == id);
        }

        public void Update(Task task)
        {
            _projectManagerContext.Update(task);
            _projectManagerContext.SaveChanges();
        }
    }
}