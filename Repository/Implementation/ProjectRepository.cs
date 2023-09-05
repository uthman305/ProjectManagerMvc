using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Models;

using ProjectManager.Models.ProjectManagerContext;
using ProjectManager.Repository.Interface;

namespace ProjectManager.Repository.Implementation
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectManagerContext _projectManagerContext;
        public ProjectRepository(ProjectManagerContext projectManagerContext)
        {
            _projectManagerContext = projectManagerContext;
        }
        public Project Add(Project project)
        {
            _projectManagerContext.Projects.Add(project);
            _projectManagerContext.SaveChanges();
            return project;
        }
        public void Delete(Project project)
        {
            _projectManagerContext.Projects.Remove(project);
            _projectManagerContext.SaveChanges();
        }

        public List<Project> GetAll()
        {
            return _projectManagerContext.Projects
            .ToList();
        }

        public Project GetProject(string id)
        {
            var a = _projectManagerContext.Projects
              .FirstOrDefault(x => x.Id == id);
              return a;

           
        }

        public List<Project> GetProjectsByIds(List<string> projectIds)
        {
             return _projectManagerContext.Projects
            .Where(p => projectIds.Contains(p.Id))
            .ToList();
        }

        public void Update(Project project)
        {
            _projectManagerContext.Update(project);
            _projectManagerContext.SaveChanges();
        }
    }
}