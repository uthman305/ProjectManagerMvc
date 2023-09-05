using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Models;
using ProjectManager.Models.ProjectManagerContext;
using ProjectManager.Repository.Interface;

namespace ProjectManager.Repository.Implementation
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ProjectManagerContext _projectManagerContext;
        public UserRoleRepository(ProjectManagerContext projectManagerContext)
        {
            _projectManagerContext = projectManagerContext;
        }

        public UserRole Add(UserRole userRole)
        {
            _projectManagerContext.UserRoles.Add(userRole);
            _projectManagerContext.SaveChanges();
            return userRole;
        }
        public void Delete(UserRole userRole)
        {
            _projectManagerContext.UserRoles.Remove(userRole);
            _projectManagerContext.SaveChanges();
        }

        public List<UserRole> GetAll()
        {
            return _projectManagerContext.UserRoles
            .ToList();
        }
        public UserRole GetUserRole(string id)
        {
            return _projectManagerContext.UserRoles
            .SingleOrDefault(x => x.Id == id);
        }

        public void Update(UserRole userRole)
        {
            _projectManagerContext.Update(userRole);
            _projectManagerContext.SaveChanges();
        }
    }
}