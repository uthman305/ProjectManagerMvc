using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Models;

namespace ProjectManager.Repository.Interface
{
    public interface IProjectRepository
    {
         Project Add(Project project);
        void Delete(Project project);
        List<Project> GetAll();
        Project GetProject(string id);
         List<Project> GetProjectsByIds(List<string> projectIds);
        void Update(Project project);
    }
}