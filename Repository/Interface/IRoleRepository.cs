using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Models;

namespace ProjectManager.Repository.Interface
{
    public interface IRoleRepository
    {
        Role Add(Role role);
        void Delete(Role role);
        List<Role> GetAll();
        Role GetRole(string id);
        void Update(Role role);
    }
}