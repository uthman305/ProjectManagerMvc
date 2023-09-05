using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Models;

namespace ProjectManager.Repository.Interface
{
    public interface IUserRoleRepository
    {
         UserRole Add(UserRole userRole);
        void Delete(UserRole userRole);
        List<UserRole> GetAll();
        UserRole GetUserRole(string id);
        void Update(UserRole userRole);
    }
}