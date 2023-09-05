using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Models;
using ProjectManager.Models.ProjectManagerContext;
using ProjectManager.Repository.Interface;

namespace ProjectManager.Repository.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ProjectManagerContext _projectManagerContext;
        public RoleRepository(ProjectManagerContext projectManagerContext)
        {
            _projectManagerContext = projectManagerContext;
        }
        public Role Add(Role role)
        {
           _projectManagerContext.Roles.Add(role);
            _projectManagerContext.SaveChanges();
            return role;
        }
        public void Delete(Role role)
        {
            _projectManagerContext.Roles.Remove(role);
            _projectManagerContext.SaveChanges();
        }

        public List<Role> GetAll()
        {
            return _projectManagerContext.Roles
            .ToList();
        }
        public Role GetRole(string id)
        {
            return _projectManagerContext.Roles
            .SingleOrDefault(x => x.Id == id);
        }

        public void Update(Role role)
        {
            _projectManagerContext.Update(role);
            _projectManagerContext.SaveChanges();
        }
    }
}